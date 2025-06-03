using DocumentinAPI.Domain.DTOs.Supabase;
using DocumentinAPI.Domain.Utils;
using DocumentinAPI.Interfaces.IRepository;
using DocumentinAPI.Interfaces.IServices;

namespace DocumentinAPI.Services
{
    public class SupabaseService : ISupabaseService
    {

        private readonly ISupabaseRepository _repository;

        public SupabaseService(ISupabaseRepository repository)
        {
            _repository = repository;
        }

        public async Task<Retorno<UploadImageResponseDTO>> UploadImageAsync(UploadImageRequestDTO dto)
        {

            Retorno<UploadImageResponseDTO> oRetorno = new();

            try
            {

                var ret = await _repository.UploadImageAsync(dto);
                oRetorno = ret;

            }
            catch (Exception ex)
            {
                oRetorno.SetErro(ex.Message);
            }

            return oRetorno;

        }
    }
}
