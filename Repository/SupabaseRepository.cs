using DocumentinAPI.Domain.DTOs.Supabase;
using DocumentinAPI.Domain.Utils;
using DocumentinAPI.Interfaces.IRepository;

namespace DocumentinAPI.Repository
{
    public class SupabaseRepository : ISupabaseRepository
    {

        private readonly Supabase.Client _client;

        public SupabaseRepository(Supabase.Client client)
        {
            _client = client;
        }

        public async Task<Retorno<UploadImageResponseDTO>> UploadImageAsync(UploadImageRequestDTO dto)
        {

            Retorno<UploadImageResponseDTO> oRetorno = new();

            try
            {

                using var memoryStream = new MemoryStream();
                await dto.Image.CopyToAsync(memoryStream);
                var imageBytes = memoryStream.ToArray();

                var bucket = _client.Storage.From("pictures");

                var fileName = $"{Guid.NewGuid()}_{dto.Image.FileName}";

                await bucket.Upload(imageBytes, fileName);

                UploadImageResponseDTO resposta = new()
                {
                    Url = bucket.GetPublicUrl(fileName)
                };

                oRetorno.Objeto = resposta;

                oRetorno.SetSucesso();

            }
            catch(Exception ex)
            {
                oRetorno.SetErro(ex.Message);
            }

            return oRetorno;

        }
    }
}
