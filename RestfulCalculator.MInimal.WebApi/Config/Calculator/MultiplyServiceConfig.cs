using Microsoft.AspNetCore.Http.HttpResults;
using RestfulCalculator.Interface.Constants;
using RestfulCalculator.Interface.Services.Calculator;
using Microsoft.AspNetCore.Http.HttpResults;
using RestfulCalculator.Interface.Constants;
using RestfulCalculator.Interface.Services.Calculator;
using RestfulCalculator.Interface.Services.DataContracts.Calculator;
using RestfulCalculator.Resources;
using RestfulCalculator.Services.Calculator;
using System.Numerics;

namespace RestfulCalculator.Minimal.WebApi.Config.Calculator
{
    internal class MultiplyServiceConfig : BaseServiceConfig
    {
        private string RoutePatternRoot = "/calculator/multiply";

        public override string EndPointName { get => "MultiplyNumbers"; }
        public override string RoutePattern { get => RoutePatternRoot + "/{factor1:decimal}/{factor2:decimal}"; }
        public override ServiceType Type { get => ServiceType.Get; }

        public override Delegate AsyncHandler { get; } =
            async Task<Results<BadRequest<MultiplyServiceResponse>, Ok<MultiplyServiceResponse>>> (IMultiplyService multiplyService, decimal factor1, decimal factor2) =>
            {
                var request = new MultiplyServiceRequest { Factor1 = factor1, Factor2 = factor2 };
                var validationResult = multiplyService.ValidateRequest(request);
                return validationResult.Error == null ?
                await Task.Run(() => TypedResults.Ok(multiplyService.Run(request))) :
                await Task.Run(() => TypedResults.BadRequest<MultiplyServiceResponse>(validationResult));
            };

        public override void Map(WebApplication app)
        {
            base.Map(app);
            app.MapGet(RoutePatternRoot + "/{*rest}", (string rest)
                => TypedResults.BadRequest(new MultiplyServiceResponse { Error = string.Format(ErrorMessages.ErrorInRequestParameters, rest) }));
        }
    }
}