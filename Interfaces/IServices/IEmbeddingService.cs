namespace DocumentinAPI.Interfaces.IServices
{
    public interface IEmbeddingService
    {

        public Task<string> GetEmbeddingAsync(string input);

    }
}
