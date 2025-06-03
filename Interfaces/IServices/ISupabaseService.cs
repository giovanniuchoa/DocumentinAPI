using DocumentinAPI.Domain.DTOs.Supabase;
using DocumentinAPI.Domain.Utils;
using Microsoft.AspNetCore.Mvc;

namespace DocumentinAPI.Interfaces.IServices
{
    public interface ISupabaseService
    {

        public Task<Retorno<UploadImageResponseDTO>> UploadImageAsync(UploadImageRequestDTO dto);

    }
}
