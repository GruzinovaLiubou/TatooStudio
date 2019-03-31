using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Unity;

namespace ITAcademy.Gallery.Dependency
{
    public class MyDependencyResolver :
        IDependencyResolver
    {
        readonly IUnityContainer _container;

        public MyDependencyResolver()
        {
            _container = new UnityContainer();
            _container.RegisterType<IPhotoService, PhotoService>();
            //_container.RegisterType<IContext, Context>();
        }

        public object GetService(Type serviceType)
        {
            try
            {
                return _container.Resolve(serviceType);
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return _container.ResolveAll(serviceType);
            }
            catch
            {
                return null;
            }
        }
    }
}
