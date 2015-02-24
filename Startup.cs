using System.Net.Http.Formatting;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Owin;
using System.Web.Http;

namespace SpecUI
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder) {
            var config = new HttpConfiguration();
            config.SuppressDefaultHostAuthentication();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            config.Formatters.Clear();
            config.Formatters.Add(new JsonMediaTypeFormatter());
            config.Formatters.JsonFormatter.SerializerSettings =
            new JsonSerializerSettings {
                Formatting = Formatting.Indented,
                DefaultValueHandling = DefaultValueHandling.Ignore
            };
            config.Formatters.JsonFormatter.SerializerSettings.Converters.Add(
                new StringEnumConverter());
            appBuilder.UseWebApi(config);
        }
    }
}