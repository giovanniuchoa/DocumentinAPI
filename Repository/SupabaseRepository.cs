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

        public async Task<Retorno<string>> UploadImageAsync(UploadImageRequestDTO dto)
        {

            Retorno<string> oRetorno = new();

            try
            {

                using var memoryStream = new MemoryStream();
                await dto.Image.CopyToAsync(memoryStream);
                var imageBytes = memoryStream.ToArray();

                var bucket = _client.Storage.From("photos");

                var fileName = $"{Guid.NewGuid()}_{dto.Image.FileName}";

                await bucket.Upload(imageBytes, fileName);

                var publicUrl = bucket.GetPublicUrl(fileName);

                oRetorno.Objeto = publicUrl;

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
