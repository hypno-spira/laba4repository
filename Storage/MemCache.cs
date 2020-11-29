using System;
using System.Collections.Generic;
using System.Linq;
using thefirst.Models;

namespace thefirst.Storage
{
    public class MemCache : IStorage<ModelData> //
    {
        private object _sync = new object();
        private List<ModelData> _memCache = new List<ModelData>();
        public ModelData this[Guid id] 
        { 
            get
            {
                lock (_sync)
                {
                    if (!Has(id)) throw new IncorrectModelDataException($"No ModelData with id {id}");

                    return _memCache.Single(x => x.Id == id);
                }
            }
            set
            {
                if (id == Guid.Empty) throw new IncorrectModelDataException("Cannot request ModelData with an empty id");

                lock (_sync)
                {
                    if (Has(id))
                    {
                        RemoveAt(id);
                    }

                    value.Id = id;
                    _memCache.Add(value);
                }
            }
        }

        public System.Collections.Generic.List<ModelData> All => _memCache.Select(x => x).ToList();

        public void Add(ModelData value)
        {
            if (value.Id != Guid.Empty) throw new IncorrectModelDataException($"Cannot add value with predefined id {value.Id}");

            value.Id = Guid.NewGuid();
            this[value.Id] = value;
        }

        public bool Has(Guid id)
        {
            return _memCache.Any(x => x.Id == id);
        }

        public void RemoveAt(Guid id)
        {
            lock (_sync)
            {
                _memCache.RemoveAll(x => x.Id == id);
            }
        }

        public string StorageType => $"{nameof(MemCache)}";
    }
}