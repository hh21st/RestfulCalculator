using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;
using Microsoft.Graph;
using RestfulCalculator.Interface.Services.Calculator;
using RestfulCalculator.Interface.Services.DataContracts.Calculator;
using Microsoft.AspNetCore.Http.HttpResults;

namespace WebApi.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]")]
    [RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
    public class CalculatorController : ControllerBase
    {
        private readonly ILogger<CalculatorController> _logger;
        private readonly IAddService _addService;
        private readonly ISubtractService _subtractService;
        private readonly IMultiplyService _multiplyService;
        private readonly IDivideService _divideService;

        public CalculatorController(ILogger<CalculatorController> logger, 
            IAddService addService,
            ISubtractService subtractService,
            IMultiplyService multiplyService,
            IDivideService divideService)
        {
            _logger = logger;
            _addService = addService;
            _subtractService = subtractService;
            _multiplyService = multiplyService;
            _divideService = divideService;
        }

        [HttpGet("AddNumbers")]
        public async Task<Results<BadRequest<AddServiceResponse>, Ok<AddServiceResponse>>> AddNumbers(decimal number1, decimal number2)
        {
            var request = new AddServiceRequest { Number1 = number1, Number2 = number2 };
            var validationResult = _addService.ValidateRequest(request);
            return validationResult.Error == null ?
            await Task.Run(() => TypedResults.Ok(_addService.Run(request))) :
            await Task.Run(() => TypedResults.BadRequest(validationResult));
        }

        [HttpGet("SubtractNumbers")]
        public async Task<Results<BadRequest<SubtractServiceResponse>, Ok<SubtractServiceResponse>>> SubtractNumbers(decimal minuend, decimal subtrahend)
        {
            var request = new SubtractServiceRequest { Minuend = minuend, Subtrahend = subtrahend };
            var validationResult = _subtractService.ValidateRequest(request);
            return validationResult.Error == null ?
            await Task.Run(() => TypedResults.Ok(_subtractService.Run(request))) :
            await Task.Run(() => TypedResults.BadRequest(validationResult));
        }

        [HttpGet("MultiplyNumbers")]
        public async Task<Results<BadRequest<MultiplyServiceResponse>, Ok<MultiplyServiceResponse>>> MultiplyNumbers(decimal factor1, decimal factor2)
        {
            var request = new MultiplyServiceRequest { Factor1 = factor1, Factor2 = factor2 };
            var validationResult = _multiplyService.ValidateRequest(request);
            return validationResult.Error == null ?
            await Task.Run(() => TypedResults.Ok(_multiplyService.Run(request))) :
            await Task.Run(() => TypedResults.BadRequest(validationResult));
        }

        [HttpGet("DivideNumbers")]
        public async Task<Results<BadRequest<DivideServiceResponse>, Ok<DivideServiceResponse>>> DivideNumbers(decimal dividend, decimal divisor)
        {
            var request = new DivideServiceRequest { Dividend = dividend, Divisor = divisor };
            var validationResult = _divideService.ValidateRequest(request);
            return validationResult.Error == null ?
            await Task.Run(() => TypedResults.Ok(_divideService.Run(request))) :
            await Task.Run(() => TypedResults.BadRequest(validationResult));
        }

    }
}