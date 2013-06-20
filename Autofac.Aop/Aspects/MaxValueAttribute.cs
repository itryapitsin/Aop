using System;

namespace Autofac.Aop.Aspects
{
    [AttributeUsage(AttributeTargets.Parameter | AttributeTargets.ReturnValue | AttributeTargets.Property)]
    public class MaxValueAttribute : OnMethodArgumentBoundedAspect
    {
        private readonly int _max;

        public MaxValueAttribute(int max)
        {
            _max = max;
        }

        public override void CheckArgument(string argumentName, object value)
        {
            var val = (int)value;

            if (val > _max)
                throw new ArgumentOutOfRangeException(argumentName);
        }
    }
}
