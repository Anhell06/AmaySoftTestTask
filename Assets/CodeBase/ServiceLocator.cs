using System;
using System.Collections.Generic;

namespace Assets.CodeBase.Infracstructure
{
    public class ServiceLocator : IServiceLocator
    {
        private Dictionary<Type, IService> _services = new Dictionary<Type, IService>();
        public void RegestrateService<TService>(TService service) where TService : IService
        {
            _services.Add(typeof(TService), service);
        }

        public TService GetService<TService>() where TService : class
        {
            return _services[typeof(TService)] as TService;
        }
    }
}
