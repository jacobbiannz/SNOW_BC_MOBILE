namespace snow_bc_mobile.Services.Dependency
{
    public interface IDependencyService
    {
        T Get<T>() where T : class;
    }
}
