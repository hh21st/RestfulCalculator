using Microsoft.AspNetCore.Http.HttpResults;
using RestfulCalculator.Interface.Constants;
using RestfulCalculator.Interface.Services.Calculator;
using RestfulCalculator.Interface.Services.DataContracts.Calculator;
using RestfulCalculator.Resources;
using RestfulCalculator.Services.Calculator;

namespace RestfulCalculator.Minimal.WebApi.Config.Calculator
{
    internal class DivideServiceConfig : BaseServiceConfig
    {
        private string RoutePatternRoot = "/calculator/divide";

        public override string EndPointName { get => "DivideNumbers"; }
        public override string RoutePattern { get => RoutePatternRoot + "/{dividend:decimal}/{divisor:decimal}"; }
        public override ServiceType Type { get => ServiceType.Get; }

        public override Delegate AsyncHandler { get; } =
            async Task<Results<BadRequest<DivideServiceResponse>, Ok<DivideServiceResponse>>> (IDivideService divideService, decimal dividend, decimal divisor) =>
            {
                var request = new DivideServiceRequest { Dividend = dividend, Divisor = divisor };
                var validationResult = divideService.ValidateRequest(request);
                return validationResult.Error == null ?
                await Task.Run(() => TypedResults.Ok(divideService.Run(request))) :
                await Task.Run(() => TypedResults.BadRequest<DivideServiceResponse>(validationResult));
            };

        public override void Map(WebApplication app)
        {
            base.Map(app);
            app.MapGet(RoutePatternRoot + "/{*rest}", (string rest)
                => TypedResults.BadRequest(new DivideServiceResponse { Error = string.Format(ErrorMessages.ErrorInRequestParameters, rest) }));
        }
    }
}
