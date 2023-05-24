using Aquality.Selenium.Browsers;
using Aquality.Selenium.Core.Waitings;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using VkAPI.ApiServices;
using VkAPI.Configuration;
using VkAPI.Forms;
using VkAPI.Models;
using VkAPI.Steps;
using VkAPI.Utils;

namespace VkAPI.Tests
{
    public class Tests : BaseTest
    {
        private NavigationBarForm navigationBarForm = new NavigationBarForm();
        private WallLegacyForm wallLegacyForm = new WallLegacyForm();

        private VkUISteps vkUIStep = new VkUISteps();
        
        [Test]
        public void TC0001_TestVkServices()
        {

            vkUIStep.AuthorizeVk();

            navigationBarForm.State.WaitForDisplayed();
            navigationBarForm.GoToMyProfile();

            WallPostModel wallPost = new WallPostModel();

            wallPost.AuthorId = TestConfiguration.UserId;
            wallPost.Message = RandomGenerate.GetRandomString(10);

            var response = VkApiService.CreateWallPost(wallPost);

            wallPost.Id = ApiUtils.GetFieldFromResponse(response,"post_id").ToString();

            ConditionalWait.Equals(wallLegacyForm.GetWallPost().Id, wallPost.Id);

            WallPostModel actualLastPost = wallLegacyForm.GetWallPost();

            Assert.Multiple(() =>
            {
                Assert.That(actualLastPost.Id, Is.EqualTo(wallPost.Id), "Actual last post id dowsn't match with expected post id");

                Assert.That(actualLastPost.AuthorId, Is.EqualTo(wallPost.AuthorId), "Actual last post owner dowsn't match with expected post owner");

                Assert.That(actualLastPost.Message, Is.EqualTo(wallPost.Message), "Actual last post message dowsn't match with expected post message");
            });


            wallPost.Message = RandomGenerate.GetRandomString(10);

            response = VkApiService.EditWallPost(wallPost);

            AqualityServices.ConditionalWait.WaitFor(() => 
            { 
                return wallLegacyForm.GetWallPost().Message.Equals(wallPost.Message); 
            });

            WallPostModel actualPostAfterEdit = wallLegacyForm.GetWallPost();

            Assert.Multiple(() =>
            {
                Assert.That(actualPostAfterEdit.Id, Is.EqualTo(wallPost.Id), "Post wasn't edit. Idies don't match");

                Assert.That(actualPostAfterEdit.AuthorId, Is.EqualTo(wallPost.AuthorId), "Post wasn't edit. Owners don't match");

                Assert.That(actualPostAfterEdit.Message, Is.EqualTo(wallPost.Message), "Post wasn't edit. Messages don't match");
            });
            
            CommentModel comment = new CommentModel();
            comment.AuthorId = TestConfiguration.UserId;
            comment.PostId = wallPost.Id;
            comment.Message = RandomGenerate.GetRandomString(10);

            response = VkApiService.CreateWallComment(comment);

            comment.CommentId = ApiUtils.GetFieldFromResponse(response, "comment_id").ToString();

            wallLegacyForm.ShowReplies();


            //ÏÐÎÂÅÐÈÒÜ ÌÁ ÁÅÇ ÝÒÎÃÎ ÐÀÁÎÒÀÅÒ!!!!
            AqualityServices.ConditionalWait.WaitFor(() => { return wallLegacyForm.CommentLocated(); });

            CommentModel actualCreatedComment = wallLegacyForm.GetPostCommentInfo();

            Assert.Multiple(() =>
            {
                Assert.That(actualCreatedComment.CommentId, Is.EqualTo(comment.CommentId), "Actual comment id of comment doens't match with expected");

                Assert.That(actualCreatedComment.PostId, Is.EqualTo(comment.PostId), "Actual post id of comment doens't match with expected");

                Assert.That(actualCreatedComment.Message, Is.EqualTo(comment.Message), "Actual message of comment doens't match with expected");

                Assert.That(actualCreatedComment.AuthorId, Is.EqualTo(comment.AuthorId), "Actual owner of comment doens't match with expected");
            });

            wallLegacyForm.LikePost();

            response = VkApiService.GetPostLikes(wallPost.Id);

            dynamic parsedResponse = JsonConvert.DeserializeObject(response.Content);

            List<string> uidList = ApiUtils.GetFieldFromResponse(response,"users").Select(user => user["uid"].ToString()).ToList();

            Assert.That(uidList.Contains(TestConfiguration.UserId));

            response = VkApiService.DeletePost(wallPost);

            WallPostModel actualLastPostAfterDelete = wallLegacyForm.GetWallPost();

            Assert.That(wallLegacyForm.PostIsUnshown(actualLastPostAfterDelete),"The post wasn't deleted");
        }

        [Test]
        //[Ignore("")]
        public void Test2()
        {
            var response = VkApiService.GetWallPhotosUploadServer();

            JObject responseObj = JObject.Parse(response.Content);

            //UploadServerUrlModel uploadServerUrl = JsonConvert.DeserializeObject<UploadServerUrlModel>(response.Content);

            response = VkApiService.UploadPhoto(responseObj["response"]["upload_url"].ToString());

            Console.WriteLine(response.Content);

            UploadPhotoServerModel uploadPhoto = JsonConvert.DeserializeObject<UploadPhotoServerModel>(response.Content);

            //Console.WriteLine(uploadPhoto.Server);

            response = VkApiService.SaveWallPhoto(uploadPhoto);

            Console.WriteLine(response.Content);
        }
    }
}