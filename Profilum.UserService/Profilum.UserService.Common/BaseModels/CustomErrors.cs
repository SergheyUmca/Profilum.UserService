namespace Profilum.UserService.Common.BaseModels
{
    public class CustomError
    {
        public ResponseCodes ResponseCode { get; set; }

        public string? ResultMessage { get; set; }
    }
}