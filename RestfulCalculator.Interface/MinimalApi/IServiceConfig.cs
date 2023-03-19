using RestfulCalculator.Interface.Constants;
using RestfulCalculator.Interface.Services;

namespace RestfulCalculator.Interface.MinimalApi
{
    public interface IServiceConfig
    {
        string EndPointName { get; }
        string RoutePattern { get; }
        ServiceType Type { get; }
        Delegate AsyncHandler { get; }

    }
}
