using System;
using System.Collections.Generic;

namespace SpecUI.Data
{
    public interface IKeyValueStore
    {
        void Set<T>(string key, T value) where T : class;
        T Get<T>(string key) where T : class;
        IEnumerable<T> Find<T>(Predicate<T> predicate = null) where T : class;
        void Delete(string key);
    }
}