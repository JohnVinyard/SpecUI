using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace SpecUI.Data
{
    public class KeyValueStore : IKeyValueStore
    {
        public static readonly KeyValueStore Instance = new KeyValueStore();
        private static readonly JsonSerializerSettings Settings =
            new JsonSerializerSettings {
                TypeNameHandling = TypeNameHandling.All,
                Formatting = Formatting.Indented,
                DefaultValueHandling = DefaultValueHandling.Ignore
            };

        // KLUDGE: This is public for debugging purposes
        public IDictionary<string, string> Dict =
            new Dictionary<string, string>();

        public void Set<T>(string key, T value) where T : class {
            Dict[key] = JsonConvert.SerializeObject(value, Settings);
        }

        public T Get<T>(string key) where T : class {
            return JsonConvert.DeserializeObject<T>(Dict[key], Settings);
        }

        public IEnumerable<T> Find<T>(Predicate<T> predicate = null)
            where T : class {
            predicate = predicate ?? ((x) => true);
            return Dict.Values
                .Select(x => {
                    try {
                        return JsonConvert.DeserializeObject<T>(x, Settings);
                    } catch {
                        return null;
                    }
                })
                .Where(x => x != null && predicate(x));
        }

        public void Delete(string key) {
            Dict.Remove(key);
        }
    }
}
