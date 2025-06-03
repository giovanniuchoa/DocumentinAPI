using DocumentinAPI.Domain.DTOs.Supabase;
using DocumentinAPI.Domain.Utils;

namespace DocumentinAPI.Interfaces.IRepository
{
    public interface ISupabaseRepository
    {

        public Task<Retorno<UploadImageResponseDTO>> UploadImageAsync(UploadImageRequestDTO dto);

    }
}
