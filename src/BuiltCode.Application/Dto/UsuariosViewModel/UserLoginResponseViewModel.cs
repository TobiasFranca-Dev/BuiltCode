namespace BuiltCode.Application.Dto.UsuariosViewModel
{
    public class UserLoginResponseViewModel
    {
        public string AccessToken { get; set; }
        public string ExpiresIn { get; set; }
        public object UserInfo { get; set; }
    }
}
