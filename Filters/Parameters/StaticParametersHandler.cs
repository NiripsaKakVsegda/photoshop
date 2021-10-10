using System;
using System.Linq;
using System.Reflection;

namespace MyPhotoshop
{
    public class StaticParametersHandler<TParameters> : IParametersHandler<TParameters>
        where TParameters : IParameters, new()
    {
        private static PropertyInfo[] properties;
        private static ParameterInfo[] descriptions;
        
        static StaticParametersHandler()
        {
            properties = typeof(TParameters)
                .GetProperties()
                .Where(z => z.GetCustomAttributes(typeof(ParameterInfo), false).Length > 0)
                .ToArray();
            descriptions = typeof(TParameters)
                .GetProperties()
                .Select(z => z.GetCustomAttributes(typeof(ParameterInfo), false))
                .Where(z => z.Length > 0)
                .Select(z => z[0])
                .Cast<ParameterInfo>()
                .ToArray();
        }
        
        public ParameterInfo[] GetDescription()
        {
            return descriptions;
        }

        public TParameters CreateParameters(double[] values)
        {
            var parameters = new TParameters();
            
            if (properties.Length != values.Length)
                throw new ArgumentException();
            
            for (var i = 0; i < values.Length; i++)
                properties[i].SetValue(parameters, values[i], new object[0]);

            return parameters;
        }
    }
}