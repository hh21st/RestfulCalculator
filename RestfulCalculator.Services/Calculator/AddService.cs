using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Logging;
using RestfulCalculator.Interface.BusinessLogic;
using RestfulCalculator.Interface.Constants;
using RestfulCalculator.Interface.Services;
using RestfulCalculator.Interface.Services.Calculator;
using RestfulCalculator.Interface.Services.DataContracts.Calculator;

namespace RestfulCalculator.Services.Calculator
{
    public class AddService : BaseService<AddServiceRequest, AddServiceResponse>, IAddService
    {
        private readonly ICalculator _calculator;

        public AddService(ILogger<BaseService<AddServiceRequest, AddServiceResponse>> logger, ICalculator calculator) : base(logger)
        {
            _calculator = calculator;
        }

        public override AddServiceResponse ValidateRequest(AddServiceRequest request)
        {
            return new AddServiceResponse();
        }

        protected override AddServiceResponse OnRun(AddServiceRequest request)
        {
            return new AddServiceResponse { Result = _calculator.Add(request.Number1, request.Number2) };
        }
    }
}