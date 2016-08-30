using Autofac;
using Autofac.Integration.WebApi;
using Microsoft.Owin.Cors;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Owin;
using ProjetoGentileza.ControleDeAcesso.IoC;
using System.Reflection;
using System.Web.Http;

namespace ProjetoGentileza.ControleDeAcesso.Api
{
	public class Startup
	{
		public void Configuration(IAppBuilder app)
		{
			var config = new HttpConfiguration();
			ConfigurarSerialize(config);
			ConfigurarRotas(config);
			ConfigurarDI(config);

			app.UseCors(CorsOptions.AllowAll);
			app.UseWebApi(config);
		}

		private void ConfigurarDI(HttpConfiguration config)
		{
			var builder = new ContainerBuilder();

			// Register your Web API controllers.
			builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

			InjecaoDependencia.Resolver(builder);

			// Set the dependency resolver to be Autofac.
			var container = builder.Build();
			config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
		}

		private void ConfigurarRotas(HttpConfiguration config)
		{
			config.MapHttpAttributeRoutes();

			config.Routes.MapHttpRoute(
				name: "DefaultApi",
				routeTemplate: "api/{controller}/{id}",
				defaults: new { id = RouteParameter.Optional }
			);
		}

		private void ConfigurarSerialize(HttpConfiguration config)
		{
			var formato = config.Formatters;
			formato.Remove(formato.XmlFormatter);

			var jsonSettings = formato.JsonFormatter.SerializerSettings;
			jsonSettings.Formatting = Formatting.Indented;
			jsonSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

			formato.JsonFormatter.SerializerSettings.PreserveReferencesHandling = PreserveReferencesHandling.Objects;
		}
	}
}