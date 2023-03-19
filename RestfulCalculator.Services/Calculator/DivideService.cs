using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using RestfulCalculator.Interface.BusinessLogic;
using RestfulCalculator.Interface.Constants;
using RestfulCalculator.Interface.Services;
using RestfulCalculator.Interface.Services.Calculator;
using RestfulCalculator.Interface.Services.DataContracts.Calculator;

namespace RestfulCalculator.Services.Calculator
{
    public class DivideService : BaseService<DivideServiceRequest, DivideServiceResponse>, IDivideService
    {
        private readonly ICalculator _calculator;

        public DivideService(ILogger<BaseService<DivideServiceRequest, DivideServiceResponse>> logger, ICalculator calculator) : base(logger)
        {
            _calculator = calculator;
        }

        public override DivideServiceResponse ValidateRequest(DivideServiceRequest request)
        {
            return new DivideServiceResponse();
        }

        protected override DivideServiceResponse OnRun(DivideServiceRequest request)
        {
            return new DivideServiceResponse { Result = _calculator.Divide(request.Dividend, request.Divisor) };
        }

    }
}