using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace RestfulCalculator.Interface.Constants
{
    public struct ServiceType
    {
        public const string GetVerb = "GET";
        public const string PutVerb = "PUT";
        public const string PostVerb = "POST";
        public const string DeleteVerb = "DELETE";

        private ServiceType(string name)
        {
            Name = name;
        }

        public string Name { get;}

        public static ServiceType Get { get; } = new ServiceType(GetVerb);

    }
}
