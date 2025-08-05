using DocumentinAPI.Domain.DTOs.Supabase;
using DocumentinAPI.Domain.Utils;
using DocumentinAPI.Domain.DTOs.Auth;

namespace DocumentinAPI.Interfaces.IRepository
{
    public interface ISupabaseRepository
    {

        public Task<Retorno<UploadImageResponseDTO>> UploadImageAsync(UploadImageRequestDTO dto);

    }
}
