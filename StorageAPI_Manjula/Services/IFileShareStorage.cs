namespace StorageAPI_Manjula.Services
{
    public interface IFileShareStorage
    {
        Task<string> FileShareAsync(string directoryName, string filename, string shareName, Stream fileContent);
        //Task CreateShareAsync(string shareNamepath);
        Task<List<string>> GetAllFileShares();
        Task DeleteSnapshotAsync(string share);
    }
}
