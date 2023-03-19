using RestfulCalculator.Interface.Services.DataContracts.Calculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestfulCalculator.Interface.Services.Calculator
{
    public interface ISubtractService : IService<SubtractServiceRequest, SubtractServiceResponse>
    {
    }
}
