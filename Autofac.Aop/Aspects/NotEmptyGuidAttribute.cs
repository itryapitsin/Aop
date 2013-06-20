using System;
using Autofac.Aop.Exceptions;

namespace Autofac.Aop.Aspects
{
    [AttributeUsage(AttributeTargets.Parameter | AttributeTargets.ReturnValue)]
    public class NotEmptyGuidAttribute: OnMethodArgumentBoundedAspect
    {
        public override void CheckArgument(string argumentName, object value)
        {
            var guid = (Guid)value;
            if (guid == Guid.Empty)
            {
                throw new EmptyGuidException(argumentName);
            }
        }
    }
}
