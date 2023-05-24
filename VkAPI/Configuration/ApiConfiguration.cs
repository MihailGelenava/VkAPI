using Aquality.Selenium.Core.Configurations;
using Aquality.Selenium.Core.Utilities;

namespace VkAPI.Configuration
{
    public static class ApiConfiguration
    {
        private static ISettingsFile ApiConfigurationFile => new JsonSettingsFile("apiConfig.json");

        public static string BaseApiClientUrl => ApiConfigurationFile.GetValue<string>("base_url");
        public static string AccessToken => ApiConfigurationFile.GetValue<string>("access_token");
        public static string ApiVersion => ApiConfigurationFile.GetValue<string>("api_version");
        public static string ImagePath => ApiConfigurationFile.GetValue<string>("upload_image_absolute_path");
        public static string CreateWallPostEndpoint => ApiConfigurationFile.GetValue<string>("endpoints.create_wall_post");
        public static string EditWallPostEndpoint => ApiConfigurationFile.GetValue<string>("endpoints.edit_wall_post");
        public static string CreatePostCommentEndpoint => ApiConfigurationFile.GetValue<string>("endpoints.create_post_comment");
        public static string GetPostLikesEndpoint => ApiConfigurationFile.GetValue<string>("endpoints.get_post_likes");
        public static string DeleteWallPostEndpoint => ApiConfigurationFile.GetValue<string>("endpoints.delete_wall_post");
        public static string SaveWallPhotoEndpoint => ApiConfigurationFile.GetValue<string>("endpoints.save_wall_photo");
        public static string GetPhotoUploadServerEndpoint => ApiConfigurationFile.GetValue<string>("endpoints.get_photo_upload_server");

    }
}
