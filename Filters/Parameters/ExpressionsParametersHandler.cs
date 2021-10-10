using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace MyPhotoshop
{
    public class ExpressionsParametersHandler<TParameters> : IParametersHandler<TParameters>
        where TParameters : IParameters, new()
    {
        private static ParameterInfo[] descriptions;
        private static Func<double[], TParameters> parser;
        
        static ExpressionsParametersHandler()
        {
            descriptions = typeof(TParameters)
                .GetProperties()
                .Select(z => z.GetCustomAttributes(typeof(ParameterInfo), false))
                .Where(z => z.Length > 0)
                .Select(z => z[0])
                .Cast<ParameterInfo>()
                .ToArray();

            var properties = typeof(TParameters)
                .GetProperties()
                .Where(z => z.GetCustomAttributes(typeof(ParameterInfo), false).Length > 0)
                .ToArray();
            
            var arg = Expression.Parameter(typeof(double[]), "values");
            var bindings = properties.Select(
                (t, i) => Expression.Bind(
                    t, 
                    Expression.ArrayIndex(
                        arg, 
                        Expression.Constant(i))))
                .Cast<MemberBinding>()
                .ToList();
            var body = Expression.MemberInit(
                Expression.New(typeof(TParameters).GetConstructor(new Type[0])),
                bindings);
            var lambda = Expression.Lambda<Func<double[], TParameters>>(body, arg);
            parser = lambda.Compile();
        }
        
        public ParameterInfo[] GetDescription()
        {
            return descriptions;
        }

        public TParameters CreateParameters(double[] values)
        {
            return parser(values);
        }
    }
}