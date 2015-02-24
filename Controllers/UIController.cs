using System.Text;
using System.Net;
using System.Web.Http;
using System.Net.Http;
using System.IO;

namespace SpecUI
{
    public class UIController : ApiController
    {
        public HttpResponseMessage Get() {
            var resp = Request.CreateResponse(HttpStatusCode.OK);
            string contents;
            // TODO: This will break if not built in debug mode
            using (var fs = File.OpenRead(@"..\..\index.html")) {
                using (var sr = new StreamReader(fs)) {
                    contents = sr.ReadToEnd();
                }
            }
            resp.Content = new StringContent(
                contents, Encoding.UTF8, "text/html");
            return resp;
        }
    }
}
