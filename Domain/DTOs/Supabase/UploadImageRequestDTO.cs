namespace DocumentinAPI.Domain.DTOs.Supabase
{
    public class UploadImageRequestDTO
    {

        public string Name { get; set; }
        public IFormFile Image { get; set; }

    }
}
