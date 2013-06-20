using System;

namespace Autofac.Aop.Aspects
{
    [AttributeUsage(AttributeTargets.Parameter | AttributeTargets.ReturnValue | AttributeTargets.Property)]
    public class MinValueAttribute: OnMethodArgumentBoundedAspect
    {
        private readonly int _min;

        public MinValueAttribute(int min)
        {
            _min = min;
        }

        public override void CheckArgument(string argumentName, object value)
        {
            var val = (int) value;

            if(val < _min)
                throw new ArgumentOutOfRangeException(argumentName);
        }
    }
}
