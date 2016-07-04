using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.OData.Builder;
using System.Web.Http.OData.Extensions;
using P2K.WebApp.Models;

namespace P2K.WebApp
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {

            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<Customer>("Customers");
            builder.EntitySet<Order>("Orders");
            builder.EntitySet<Product>("Products");
            builder.EntitySet<Category>("Categories");
            builder.EntitySet<Order_Detail>("Order_Details");
            builder.EntitySet<Order_Details_Extended>("Order_Details_Extendeds");
            builder.EntitySet<Supplier>("Suppliers"); 
            builder.EntitySet<CustomerDemographic>("CustomerDemographics");
            builder.EntitySet<Customer>("Customers");
            builder.EntitySet<Employee>("Employees");
            builder.EntitySet<Shipper>("Shippers"); 
            config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());


            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
