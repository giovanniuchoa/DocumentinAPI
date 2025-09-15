using DocumentinAPI.Domain.DTOs.Auth;
using DocumentinAPI.Domain.DTOs.Document;
using DocumentinAPI.Domain.DTOs.Import;
using DocumentinAPI.Domain.Utils;
using DocumentinAPI.Interfaces.IRepository;
using DocumentinAPI.Interfaces.IServices;
using System.Text;

namespace DocumentinAPI.Services
{
    public class ImportService : IImportService
    {

        private readonly IDocumentRepository _documentRepository;

        public ImportService(IDocumentRepository repository)
        {
            _documentRepository = repository;
        }

        public async Task<Retorno<DocumentResponseDTO>> ImportDocumentAsync(ImportRequestDTO dto, UserClaimDTO ssn)
        {

            Retorno<DocumentResponseDTO> oRetorno = new();

            try
            {

                var titulo = Path.GetFileNameWithoutExtension(dto.Pdf.FileName);

                using var pdfStream = dto.Pdf.OpenReadStream();

                var loadOptions = new Aspose.Words.Loading.LoadOptions { LoadFormat = Aspose.Words.LoadFormat.Pdf };

                var doc = new Aspose.Words.Document(pdfStream, loadOptions);

                var saveOptions = new Aspose.Words.Saving.MarkdownSaveOptions
                {
                    //ExportImagesAsBase64 = false, // queremos controlar as imagens
                    //ImageSavingCallback = new SupabaseImageSavingCallback()

                    ExportImagesAsBase64 = true
                };

                using var mdStream = new MemoryStream();

                doc.Save(mdStream, saveOptions);

                mdStream.Position = 0;

                var markdown = Encoding.UTF8.GetString(mdStream.ToArray());

                try
                {

                    DocumentRequestDTO documentDTO = new()
                    {
                        Title = titulo,
                        Content = markdown,
                        FolderId = dto.FolderId
                    };

                    var ret = await _documentRepository.AddDocumentAsync(documentDTO, ssn);

                    oRetorno.Objeto = ret.Objeto;

                    oRetorno.SetSucesso();

                }
                catch (Exception)
                {
                    throw;
                }

            }
            catch (Exception ex)
            {
                oRetorno.SetErro(ex.Message);
            }

            return oRetorno;

        }
    }
}
