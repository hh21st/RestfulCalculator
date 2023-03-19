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
    public class SubtractService : BaseService<SubtractServiceRequest, SubtractServiceResponse>, ISubtractService
    {
        private readonly ICalculator _calculator;

        public SubtractService(ILogger<BaseService<SubtractServiceRequest, SubtractServiceResponse>> logger, ICalculator calculator) : base(logger)
        {
            _calculator = calculator;
        }

        public override SubtractServiceResponse ValidateRequest(SubtractServiceRequest request)
        {
            return new SubtractServiceResponse();
        }

        protected override SubtractServiceResponse OnRun(SubtractServiceRequest request)
        {
            return new SubtractServiceResponse { Result = _calculator.Subtract(request.Minuend, request.Subtrahend) };
        }

    }
}