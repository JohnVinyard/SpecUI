using System.Collections.Generic;
using System.Web.Http;
using SpecUI.Data;

namespace SpecUI
{
    public class DataController : ApiController
    {
        public IDictionary<string, string> Get() {
            return KeyValueStore.Instance.Dict;
        }
    }
}
