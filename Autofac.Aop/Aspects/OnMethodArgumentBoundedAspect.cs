using System;

namespace Autofac.Aop.Aspects
{
    public abstract class OnMethodArgumentBoundedAspect: Attribute
    {
        public abstract void CheckArgument(string argumentName, object value);
    }
}
