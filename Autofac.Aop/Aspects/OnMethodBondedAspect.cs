using System;
using Castle.DynamicProxy;

namespace Autofac.Aop.Aspects
{
    public abstract class OnMethodBondedAspect: Attribute
    {
        internal bool IsJideException;

        protected OnMethodBondedAspect(bool isJideException = true)
        {
            IsJideException = isJideException;
        }

        public virtual void OnExecuting(IInvocation invocation){}

        public virtual void OnExecuted(IInvocation invocation){}

        public virtual void OnExit(IInvocation invocation){}

        public virtual void OnException(IInvocation invocation, Exception exception){}
    }
}
