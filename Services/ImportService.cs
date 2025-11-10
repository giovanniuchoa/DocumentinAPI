using DocumentinAPI.Domain.DTOs.Auth;
using DocumentinAPI.Domain.DTOs.Document;
using DocumentinAPI.Domain.DTOs.Import;
using DocumentinAPI.Domain.DTOs.Supabase;
using DocumentinAPI.Domain.Utils;
using DocumentinAPI.Interfaces.IRepository;
using DocumentinAPI.Interfaces.IServices;
using System.Text;
using System.Text.RegularExpressions;

namespace DocumentinAPI.Services
{
    public class ImportService : IImportService
    {

        private readonly IDocumentService _documentService;

        private readonly ISupabaseService _supabaseService;

        public ImportService(IDocumentService documentService, ISupabaseService supabaseService)
        {
            _documentService = documentService;
            _supabaseService = supabaseService;
        }

        public async Task<Retorno<DocumentResponseDTO>> ImportDocumentAsync(ImportRequestDTO dto, UserClaimDTO ssn)
        {

            Retorno<DocumentResponseDTO> oRetorno = new();

            try
            {

                var titulo = Path.GetFileNameWithoutExtension(dto.File.FileName);
                titulo = titulo.Length > 100 ? titulo[..100].Trim() : titulo.Trim();

                using var pdfStream = dto.File.OpenReadStream();

                var loadOptions = new Aspose.Words.Loading.LoadOptions { LoadFormat = Aspose.Words.LoadFormat.Pdf };

                var doc = new Aspose.Words.Document(pdfStream, loadOptions);

                var callback = new AsposeService();

                var saveOptions = new Aspose.Words.Saving.MarkdownSaveOptions
                {
                    ExportImagesAsBase64 = false,
                    ImageSavingCallback = callback
                };

                using var mdStream = new MemoryStream();

                doc.Save(mdStream, saveOptions);

                var urlMap = new Dictionary<string, string>();

                foreach (var (tempName, stream) in callback.Imagens)
                {
                    stream.Position = 0;
                    var formFile = new FormFile(stream, 0, stream.Length, tempName, tempName);
                    var ret = await _supabaseService.UploadImageAsync(new UploadImageRequestDTO { Image = formFile });
                    urlMap[tempName] = ret.Objeto.Url;
                }

                mdStream.Position = 0;

                var markdown = Encoding.UTF8.GetString(mdStream.ToArray());

                foreach (var kv in urlMap)
                {
                    markdown = markdown.Replace($"({kv.Key})", $"({kv.Value})");
                }

                markdown = Helpers.TratarMarkdown(markdown);

                try
                {

                    DocumentRequestDTO documentDTO = new()
                    {
                        Title = titulo,
                        Content = markdown,
                        FolderId = dto.FolderId
                    };

                    var ret = await _documentService.AddDocumentAsync(documentDTO, ssn);

                    if (ret.Erro)
                    {
                        throw new Exception("importError");
                    }
                    else
                    {
                        oRetorno.Objeto = ret.Objeto;
                    }
                        
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
