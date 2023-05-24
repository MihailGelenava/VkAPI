using RestSharp;
using VkAPI.Configuration;
using VkAPI.Models;

namespace VkAPI.ApiServices
{
    public static class VkApiService
    {
        private static readonly RestClient vkApiClient = new RestClient(ApiConfiguration.BaseApiClientUrl);
        public static RestResponse CreateWallPost(WallPostModel wallPost)
        {
            RestRequest request = new RestRequest(ApiConfiguration.CreateWallPostEndpoint, Method.Post);

            request.AddParameter("access_token", ApiConfiguration.AccessToken);
            if (wallPost.Message != null ) {
                request.AddParameter("message", wallPost.Message);
            }
            request.AddParameter("v", ApiConfiguration.ApiVersion);

            return vkApiClient.Execute(request);
        }
        public static RestResponse EditWallPost(WallPostModel wallPost)
        {
            RestRequest request = new RestRequest(ApiConfiguration.EditWallPostEndpoint, Method.Post);

            request.AddParameter("access_token", ApiConfiguration.AccessToken);
            if (wallPost.Message != null)
            {
                request.AddParameter("message", wallPost.Message);
            }
            request.AddParameter("post_id", wallPost.Id);
            request.AddParameter("v", ApiConfiguration.ApiVersion);

            return vkApiClient.Execute(request);
        }

        public static RestResponse CreateWallComment(CommentModel comment)
        {
            RestRequest request = new RestRequest(ApiConfiguration.CreatePostCommentEndpoint, Method.Post);

            request.AddParameter("access_token", ApiConfiguration.AccessToken);
            request.AddParameter("message", comment.Message);
            request.AddParameter("post_id", comment.PostId);
            request.AddParameter("v", ApiConfiguration.ApiVersion);

            return vkApiClient.Execute(request);
        }

        public static RestResponse GetPostLikes(string postId)
        {
            RestRequest request = new RestRequest(ApiConfiguration.GetPostLikesEndpoint, Method.Get);

            request.AddParameter("access_token", ApiConfiguration.AccessToken);
            request.AddParameter("post_id", postId);
            request.AddParameter("v", ApiConfiguration.ApiVersion);

            return vkApiClient.Execute(request);
        }

        public static RestResponse DeletePost(WallPostModel post)
        {
            RestRequest request = new RestRequest(ApiConfiguration.DeleteWallPostEndpoint, Method.Post);

            request.AddParameter("access_token", ApiConfiguration.AccessToken);
            request.AddParameter("owner_id", post.AuthorId);
            request.AddParameter("post_id", post.Id);
            request.AddParameter("v", ApiConfiguration.ApiVersion);

            return vkApiClient.Execute(request);
        }

        public static RestResponse UploadPhoto(string endpoint)
        {
            RestClient client = new RestClient(endpoint);
            RestRequest request = new RestRequest("",Method.Post);

            request.AddHeader("Content-Type", "multipart/form-data");

            request.AddFile("photo", ApiConfiguration.ImagePath);

            return client.Execute(request);
        }

        public static RestResponse SaveWallPhoto(UploadPhotoServerModel uploadPhoto)
        {
            RestRequest request = new RestRequest(ApiConfiguration.SaveWallPhotoEndpoint, Method.Post);

            request.AddParameter("access_token", ApiConfiguration.AccessToken);
            request.AddParameter("server", uploadPhoto.Server);
            request.AddParameter("hash", uploadPhoto.Hash);
            request.AddParameter("photo", uploadPhoto.Photo);
            request.AddParameter("v", ApiConfiguration.ApiVersion);

            return vkApiClient.Execute(request);
        }

        public static RestResponse GetWallPhotosUploadServer()
        {
            RestRequest request = new RestRequest(ApiConfiguration.GetPhotoUploadServerEndpoint, Method.Get);

            request.AddParameter("access_token", ApiConfiguration.AccessToken);
            request.AddParameter("group_id", TestConfiguration.UserId);
            request.AddParameter("v", ApiConfiguration.ApiVersion);

            return vkApiClient.Execute(request);
        }
    }
}
