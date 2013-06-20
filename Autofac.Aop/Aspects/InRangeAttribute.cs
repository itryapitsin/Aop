using System;

namespace Autofac.Aop.Aspects
{
    [AttributeUsage(AttributeTargets.Parameter | AttributeTargets.ReturnValue)]
    public class InRangeAttribute : OnMethodArgumentBoundedAspect
    {
        private readonly int _min;
        private readonly int _max;

        public InRangeAttribute(int min, int max)
        {
            _min = min;
            _max = max;
        }

        public override void CheckArgument(string argumentName, object value)
        {
            var intValue = (int)value;
            if (intValue < _min || intValue > _max)
            {
                throw new ArgumentOutOfRangeException(argumentName, string.Format("min={0}, max={1}", _min, _max));
            }
        }
    }
}
