using Aspose.Words.Saving;
using DocumentinAPI.Domain.DTOs.Supabase;
using DocumentinAPI.Interfaces.IServices;
using Microsoft.AspNetCore.Http;

namespace DocumentinAPI.Services
{
    public class AsposeService : IImageSavingCallback
    {

        private readonly List<(string TempName, MemoryStream Stream)> _imagens = new();
        public IReadOnlyList<(string TempName, MemoryStream Stream)> Imagens => _imagens;

        public void ImageSaving(ImageSavingArgs args)
        {

            var ms = new MemoryStream();
            args.ImageStream = ms;
            args.KeepImageStreamOpen = true; 

            var tempName = Guid.NewGuid().ToString("N") + Path.GetExtension(args.ImageFileName);
            args.ImageFileName = tempName;

            _imagens.Add((tempName, ms));

        }

    }

}


