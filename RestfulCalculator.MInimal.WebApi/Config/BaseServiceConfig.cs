using RestfulCalculator.Interface.Constants;
using RestfulCalculator.Interface.MinimalApi;
using RestfulCalculator.Interface.Services;
using RestfulCalculator.Resources;

namespace RestfulCalculator.Minimal.WebApi.Config
{
    internal abstract class BaseServiceConfig : IServiceConfig
    {
        private static readonly List<IServiceConfig> _serviceConfigs = new List<IServiceConfig>();


        public abstract string EndPointName { get; }
        public abstract string RoutePattern { get; }
        public abstract ServiceType Type { get; }
        public abstract Delegate AsyncHandler { get; }

        public virtual void Map(WebApplication app)
        {
            switch (Type.Name)
            {
                case ServiceType.GetVerb:
                    MapGet(app);
                    break;
                default:
                    break;
            }

            AddConfigService(this);
        }


        protected void MapGet(WebApplication app)
        {
            app.MapGet(RoutePattern, AsyncHandler)
            .WithName(EndPointName)
            .WithOpenApi();
        }

        private static bool AddConfigService(IServiceConfig serviceConfig)
        {
            if (_serviceConfigs.Contains(serviceConfig))
                return false;

            if (_serviceConfigs.Any(s => s.RoutePattern == serviceConfig.RoutePattern))
                throw new Exception(string.Format(ErrorMessages.ServiceWIthTheSameRoutePatternAlreadyExists, serviceConfig.RoutePattern));

            if (_serviceConfigs.Any(s => s.EndPointName == serviceConfig.EndPointName))
                throw new Exception(string.Format(ErrorMessages.ServiceWIthTheSameEndPointNameAlreadyExists, serviceConfig.EndPointName));

            _serviceConfigs.Add(serviceConfig);

            return true;
        }

    }
}
