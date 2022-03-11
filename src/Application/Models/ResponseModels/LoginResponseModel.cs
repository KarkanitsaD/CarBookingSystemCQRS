namespace Application.Models.ResponseModels
{
    public class LoginResponseModel
    {
        public LoginResponseModel(string jwt)
        {
            Jwt = jwt;
        }

        public string Jwt { get; set; }
    }
}