using thefirst.Models;

namespace thefirst.Storage
{
    public class StorageService
    {
        private readonly IStorage<ModelData> _storage;

        public StorageService(IStorage<ModelData> storage)
        {
            _storage = storage;
        }

        public string GetStorageType()
        {
            return _storage.StorageType;
        }

        public int GetNumberOfItems()
        {
            return _storage.All.Count;
        }
    }
} 