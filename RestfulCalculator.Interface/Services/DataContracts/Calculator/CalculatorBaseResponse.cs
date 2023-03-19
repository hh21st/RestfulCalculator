using RestfulCalculator.Interface.Services.DataContracts.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestfulCalculator.Interface.Services.DataContracts.Calculator
{
    public class CalculatorBaseResponse<TResult> : BaseResponse
    {
        public TResult? Result { get; set; }
    }
}
