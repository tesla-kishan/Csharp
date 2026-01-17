using System;
using System.Collections.Generic;

namespace MiniSocialMedia
{
    // Generic repository that accepts only reference types
    public class Repository<T> where T : class
    {
        // Internal storage
        private readonly List<T> _items = new();

        // Add item (lambda-friendly)
        public void Add(T item) => _items.Add(item);

        // Get all items safely
        public IReadOnlyList<T> GetAll() => _items.AsReadOnly();

        // Find first matching item
        public T? Find(Predicate<T> match)
        {
            foreach (var item in _items)
            {
                if (match(item))
                    return item;
            }
            return null;
        }
    }
}