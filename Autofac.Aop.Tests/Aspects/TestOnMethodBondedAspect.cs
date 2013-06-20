using Autofac.Aop.Aspects;
using NUnit.Framework;

namespace Autofac.Aop.Tests.Aspects
{
    public class TestOnMethodBondedAspect: OnMethodBondedAspect
    {
        public override void OnExecuting(Castle.DynamicProxy.IInvocation invocation)
        {
            throw new SuccessException("On executing called");
        }
    }
}
