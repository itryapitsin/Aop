using System;

namespace Autofac.Aop.Aspects
{
    [AttributeUsage(AttributeTargets.Parameter | AttributeTargets.ReturnValue)]
    public class NotNullOrEmptyAttribute : OnMethodArgumentBoundedAspect
    {
        public override void CheckArgument(string argumentName, object value)
        {
            if (String.IsNullOrEmpty(value as string))
            {
                throw new ArgumentNullException(argumentName);
            }
        }
    }
}
