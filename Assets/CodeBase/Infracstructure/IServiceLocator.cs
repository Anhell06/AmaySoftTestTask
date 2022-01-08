namespace Assets.CodeBase.Infracstructure
{
    public interface IServiceLocator
    {
        TService GetService<TService>() where TService : class;
        void RegestrateService<TService>(TService service) where TService : IService;
    }
}