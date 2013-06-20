using System;
using Autofac.Aop.Exceptions;

namespace Autofac.Aop.Aspects
{
    [AttributeUsage(AttributeTargets.Parameter | AttributeTargets.ReturnValue)]
    public class StringLenghtAttribute: OnMethodArgumentBoundedAspect
    {
        private readonly int _min;
        private readonly int _max;

        public StringLenghtAttribute(int min = 0, int max = int.MaxValue)
        {
            _min = min;
            _max = max;
        }

        public override void CheckArgument(string argumentName, object value)
        {
            var str = (string)value;

            if (str.Length > _max || str.Length < _min)
                throw new StringLenghtException(argumentName);
        }
    }
}
