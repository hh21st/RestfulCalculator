using Microsoft.AspNetCore.Http.HttpResults;
using RestfulCalculator.Interface.Constants;
using RestfulCalculator.Interface.Services.Calculator;
using RestfulCalculator.Interface.Services.DataContracts.Calculator;
using RestfulCalculator.Resources;
using RestfulCalculator.Services.Calculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestfulCalculator.Minimal.WebApi.Config.Calculator
{
    internal class AddServiceConfig : BaseServiceConfig
    {
        private string RoutePatternRoot = "/calculator/add";

        public override string EndPointName { get => "AddNumbers"; }
        public override string RoutePattern { get => RoutePatternRoot + "/{number1:decimal}/{number2:decimal}"; }
        public override ServiceType Type { get => ServiceType.Get; }
        public override Delegate AsyncHandler { get; } =
            async Task<Results<BadRequest<AddServiceResponse>, Ok<AddServiceResponse>>> (IAddService addService, decimal number1, decimal number2) =>
            {
                var request = new AddServiceRequest { Number1 = number1, Number2 = number2 };
                var validationResult = addService.ValidateRequest(request);
                return validationResult.Error == null ?
                await Task.Run(() => TypedResults.Ok(addService.Run(request))) :
                await Task.Run(() => TypedResults.BadRequest(validationResult));
            };

        public override void Map(WebApplication app)
        {
            base.Map(app);
            app.MapGet(RoutePatternRoot + "/{*rest}", (string rest)
                => TypedResults.BadRequest(new AddServiceResponse { Error = string.Format(ErrorMessages.ErrorInRequestParameters, rest) }));
        }
    }
}
