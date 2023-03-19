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
    public class MultiplyService : BaseService<MultiplyServiceRequest, MultiplyServiceResponse>, IMultiplyService
    {
        private readonly ICalculator _calculator;

        public MultiplyService(ILogger<BaseService<MultiplyServiceRequest, MultiplyServiceResponse>> logger, ICalculator calculator) : base(logger)
        {
            _calculator = calculator;
        }

        public override MultiplyServiceResponse ValidateRequest(MultiplyServiceRequest request)
        {
            return new MultiplyServiceResponse();
        }

        protected override MultiplyServiceResponse OnRun(MultiplyServiceRequest request)
        {
            return new MultiplyServiceResponse { Result = _calculator.Multiply(request.Factor1, request.Factor2) };
        }

    }
}