namespace StorageAPI_Manjula.Services
{
    public interface IBlobStorage
    {
        Task<List<string>> GetAllDocuments(string connectionString, string containerName);
        Task UploadDocument(string connectionString, string containerName, string fileName, Stream fileContent);
        Task<Stream> GetDocument(string connectionString, string containerName, string fileName);
        Task<bool> DeleteDocument(string connectionString, string containerName, string fileName);
    }
}
