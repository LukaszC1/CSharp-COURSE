using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericTypes
{
    public class Repository<T> where T : IEntity, new()
    {
        private List<T> _items = new();

        public void Add(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            Console.WriteLine($"Adding {item.Id}");
            _items.Add(item);
        }

        public T GetElementById(int id)
        {
            var item = new T();
            item = _items.FirstOrDefault(x => x.Id == id);
            return item;
        }
        public void Remove(T item)
        {
            _items.Remove(item);
        }

        public T? GetEelement(int index)
        {
            if (index < _items.Count || index < 0)
            {
                return _items[index];
            }
            else
            {
                return default;
            }
        }
    }

    public class Repository<TKey,TValue>
        where TKey : struct
        where TValue : class, IEntity, new()
    {
        private Dictionary<TKey, TValue> _items = new();

        public void Add(TKey key, TValue item)
        {
            _items.Add(key,item);
        }

        public void Remove(TKey key)
        {
            _items.Remove(key);
        }

        public TValue? GetEelement(TKey index)
        {
            if (_items.TryGetValue(index,out TValue result))
            {
                return result;
            }
            else
            {
                return default;
            }
        }
    }
}
