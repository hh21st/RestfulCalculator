using Microsoft.AspNetCore.Http.HttpResults;
using RestfulCalculator.Interface.Constants;
using RestfulCalculator.Interface.Services.Calculator;
using RestfulCalculator.Interface.Services.DataContracts.Calculator;
using RestfulCalculator.Resources;
using RestfulCalculator.Services.Calculator;

namespace RestfulCalculator.Minimal.WebApi.Config.Calculator
{
    internal class SubtractServiceConfig : BaseServiceConfig
    {
        private string RoutePatternRoot = "/calculator/Subtract";

        public override string EndPointName { get => "SubtractNumbers"; }
        public override string RoutePattern { get => RoutePatternRoot + "/{minuend:decimal}/{subtrahend:decimal}"; }
        public override ServiceType Type { get => ServiceType.Get; }

        public override Delegate AsyncHandler { get; } =
            async Task<Results<BadRequest<SubtractServiceResponse>, Ok<SubtractServiceResponse>>> (ISubtractService subtractService, decimal minuend, decimal subtrahend) =>
            {
                var request = new SubtractServiceRequest { Minuend = minuend, Subtrahend = subtrahend };
                var validationResult = subtractService.ValidateRequest(request);
                return validationResult.Error == null ?
                await Task.Run(() => TypedResults.Ok(subtractService.Run(request))) :
                await Task.Run(() => TypedResults.BadRequest<SubtractServiceResponse>(validationResult));
            };

        public override void Map(WebApplication app)
        {
            base.Map(app);
            app.MapGet(RoutePatternRoot + "/{*rest}", (string rest)
                => TypedResults.BadRequest(new SubtractServiceResponse { Error = string.Format(ErrorMessages.ErrorInRequestParameters, rest) }));
        }
    }
}
