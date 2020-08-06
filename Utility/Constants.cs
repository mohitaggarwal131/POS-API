namespace Utility
{
    public class Constants
    {
        public const string SecurityKey = "JWT:Key";
        public const string IssuerKey = "Jwt:Issuer";
        public const string ApplicationJson = "application/json";
        public const string InternalServerError = "Internal Server Error.";
        public const string SwaggerDoc = "v1";
        public const string SwaggerTitle = "POS API";
        public const string ApiVersion = "v1";
        public const string SecurityScheme = "Bearer ";
        public const string Description = "Please enter into field the word 'Bearer' following by space and JWT";
        public const string Authorization = "Authorization";
        public const string SecuritySchemeType = "oauth2";
        public const string SwaggerEndPoint = "/swagger/v1/swagger.json";
        public const string SecretKey = "SecretKey";
        public const string AccessTokenKey = "access_token";
        public const string NoIssuerAudience = "no";
        public const int JwsExpireTime = 12;
        public const string ErrorProductNotFound = "Product could not found";
        public const string ErrorCategoryNotFound = "Category could not found";
        public const string ErrorUserNotFound = "User could not found";
        public const string InvalidProductQuantity = "Invalid Product Quantity";
    }
}
