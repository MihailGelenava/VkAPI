using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;
using VkAPI.Models;

namespace VkAPI.Forms
{
    public class WallLegacyForm : Form
    {
        private ILabel LastWallPosts => ElementFactory.Get<ILabel>(By.XPath("//div[@id='page_wall_posts']/div[contains(@id,'post')][1]"),"Recent wall post");

        private IButton ShowRepliesButton => ElementFactory.Get<IButton>(By.XPath("//span[@class='js-replies_next_label']"), "");
        
        public WallLegacyForm() : base(By.Id("page_wall_posts"), "Wall Legacy form")
        {
        }
        public WallPostModel GetWallPost()
        {
            WallPostModel post = new WallPostModel();
            post.Id = LastWallPosts.GetElement().GetAttribute("data-post-id").Split("_")[1];
            post.AuthorId = LastWallPosts.GetElement().GetAttribute("data-post-id").Split("_")[0];
            post.Message = LastWallPosts.GetElement().FindElement(By.XPath(".//div[contains(@class,'wall_post_text')]")).GetAttribute("innerText"); 

            return post;
        }

        public CommentModel GetPostCommentInfo()
        {
            CommentModel comment = new CommentModel();
            comment.PostId = LastWallPosts.GetElement().GetAttribute("data-post-id").Split("_")[1];
            comment.CommentId = LastWallPosts.GetElement().FindElement(By.XPath(".//div[contains(@class,'reply ')]")).GetAttribute("data-post-id").Split("_")[1];
            comment.Message = LastWallPosts.GetElement().FindElement(By.XPath(".//div[contains(@class,'reply ')]//div[@class='wall_reply_text']")).GetAttribute("innerText");
            comment.AuthorId = LastWallPosts.GetElement().FindElement(By.XPath(".//div[contains(@class,'reply ')]//div[@class='reply_author']/a")).GetAttribute("data-from-id");
            return comment;
        }
        public bool CommentLocated()
        {
            return (LastWallPosts.GetElement().FindElements(By.XPath(".//div[contains(@class,'reply ')]")).Count() > 0);
        }

        public void ShowReplies() => ShowRepliesButton.Click();

        public void LikePost()
        {
            LastWallPosts.GetElement().FindElement(By.XPath(".//div[contains(@class,'PostButtonReactions__icon')]")).Click();
        }

        public bool PostIsUnshown(WallPostModel post)
        {
            return LastWallPosts.State.IsDisplayed;
        }
    }
}
