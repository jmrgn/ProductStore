using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;
using ProductStore.Models;
using ProductStore.Controllers;

namespace ProductStore
{
    class SimpleContainer : IDependencyResolver
    {
        static readonly IProductRepository respository = new ProductRepository();

        public IDependencyScope BeginScope()
        {
            // This example does not support child scopes, so we simply return 'this'.
            return this;
        }

        public object GetService(Type serviceType)
        {
            if (serviceType == typeof(ProductsController))
            {
                return new ProductsController(respository);
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return new List<object>();
        }

        public void Dispose()
        {
            // When BeginScope returns 'this', the Dispose method must be a no-op.
        }
    }
}