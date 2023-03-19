using Microsoft.Extensions.Logging;
using RestfulCalculator.Resources;
using RestfulCalculator.Interface.Services;
using Microsoft.AspNetCore.Http;
using RestfulCalculator.Interface.Services.DataContracts.Base;

namespace RestfulCalculator.Services
{
    public abstract class BaseService<TRequest, TResponse> : IService<TRequest, TResponse> where TResponse : BaseResponse, new()
    {
        protected readonly ILogger<BaseService<TRequest, TResponse>> _logger;
        protected BaseService(ILogger<BaseService<TRequest, TResponse>> logger)
        {
            _logger = logger;
        }

        public abstract TResponse ValidateRequest(TRequest request);


        public TResponse Run(TRequest request)
        {
            try
            {
                _logger.LogInformation(string.Format(Messages.ServiceStarted, GetType().FullName, DateTime.Now));

                var errors = OnBusinessValidation(request);

                if (errors != null)
                {
                    var error = string.Join(',', errors);
                    _logger.LogError(string.Format(Messages.ServiceEndedWithError, GetType().FullName, error, DateTime.Now));
                    throw new Exception(error);
                }

                var response = OnRun(request);
                _logger.LogInformation(string.Format(Messages.ServiceEnded, GetType().FullName, DateTime.Now));

                return response;
            }
            catch (Exception ex)
            {
                return new TResponse() { Error = ex.Message };
            }
        }

        protected virtual IEnumerable<string>? OnBusinessValidation(TRequest request) { return null; }
        protected abstract TResponse OnRun(TRequest request);
    }
}
