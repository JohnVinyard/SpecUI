using System.Collections.Generic;
using System.Web.Http;
using SpecUI.Data;

namespace SpecUI.Controllers
{
    public class DataController : ApiController
    {
        public IDictionary<string, string> Get() {
            return KeyValueStore.Instance.Dict;
        }
    }
}
