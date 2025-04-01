namespace DocumentinAPI.Domain.DTOs.Auth
{
    public class AuthResponseDTO
    {

        public AuthResponseDTO(string token)
        {
            this.Token = token;
        }

        public string Token { get; set; }


    }
}
