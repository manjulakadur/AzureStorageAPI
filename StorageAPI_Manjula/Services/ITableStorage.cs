using StorageAPI_Manjula.BL;

namespace StorageAPI_Manjula.Services
{
    public interface ITableStorage
    {
        Task<GroceryItemEntity> GetEntityAsync(string name, string id);
        Task<GroceryItemEntity> UpsertEntityAsync(GroceryItemEntity entity);
        Task DeleteEntityAsync(string name, string id);
    }
}
