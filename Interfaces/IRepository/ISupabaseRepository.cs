using DocumentinAPI.Domain.DTOs.Supabase;
using DocumentinAPI.Domain.Utils;

namespace DocumentinAPI.Interfaces.IRepository
{
    public interface ISupabaseRepository
    {

        public Task<Retorno<string>> UploadImageAsync(UploadImageRequestDTO dto);

    }
}
