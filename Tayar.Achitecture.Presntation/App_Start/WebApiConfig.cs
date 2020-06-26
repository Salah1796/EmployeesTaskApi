using Autofac;
using Autofac.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Reflection;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.ExceptionHandling;
using Tayar.Architecture.Repositories;
using Tayar.Architecture.Services;

namespace Tayar.Achitecture.Presntation
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            
            var cors = new EnableCorsAttribute("http://localhost:4200", "*", "*");
            config.EnableCors(cors);
            config.Services.Replace(typeof(IExceptionHandler), new OopsExceptionHandler());
            config.MapHttpAttributeRoutes();
           
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );


            config.Formatters.Clear();
            config.Formatters.Add(new JsonMediaTypeFormatter());
            config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;


            ContainerBuilder builder
                = new ContainerBuilder();

            builder.RegisterApiControllers
                (Assembly.GetExecutingAssembly())
                .PropertiesAutowired()
                .InstancePerRequest();

            builder.RegisterType<EnitiesContext>
                ().InstancePerRequest();

            builder.RegisterGeneric(typeof(Generic<>))
                .InstancePerRequest();

            builder.RegisterType<UnitOfWork>
               ().InstancePerRequest();

            builder.RegisterAssemblyTypes
                (
                typeof(EmployeeService).Assembly
                ).Where(i => i.Name.EndsWith("Service"))
                .InstancePerRequest();

            IContainer IoC = builder.Build();
            config.DependencyResolver =
                new AutofacWebApiDependencyResolver(IoC);
        }
    }
}
