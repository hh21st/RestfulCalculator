namespace RestfulCalculator.Interface.Services
{
    public interface IService<in TRequest, TResponse>: IService
    {
        TResponse Run(TRequest request);
        TResponse ValidateRequest(TRequest request);
    }

    public interface IService
    {
    }

}
