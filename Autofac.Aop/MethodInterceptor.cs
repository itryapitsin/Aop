using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Autofac.Aop.Aspects;
using Castle.DynamicProxy;

namespace Autofac.Aop
{
    public class MethodInterceptor : StandardInterceptor
    {
        protected List<OnMethodBondedAspect> OnMethodBondedAspects { get; private set; }
        protected List<KeyValuePair<ParameterInfo, OnMethodArgumentBoundedAspect>> OnMethodArgumetnBoundedAspects { get; private set; }
        protected List<OnMethodArgumentBoundedAspect> OnMethodResultBoundedAspects { get; private set; }

        public MethodInterceptor()
        {
            OnMethodBondedAspects = new List<OnMethodBondedAspect>();
            OnMethodArgumetnBoundedAspects = new List<KeyValuePair<ParameterInfo, OnMethodArgumentBoundedAspect>>();
            OnMethodResultBoundedAspects = new List<OnMethodArgumentBoundedAspect>();
        }


        //[DebuggerStepThrough]
        protected override void PerformProceed(IInvocation invocation)
        {
            OnMethodBondedAspects
                .AddRange(GetOnMethodBondedAspects(invocation));

            OnMethodArgumetnBoundedAspects
                .AddRange(GetOnMethodArgumetnBoundedAspects(invocation));

            OnMethodResultBoundedAspects
                .AddRange(GetOnMethodResultBoundedAspects(invocation));

            try
            {
                foreach (var aspect in OnMethodArgumetnBoundedAspects)
                    aspect.Value.CheckArgument(aspect.Key.Name, invocation.Arguments[aspect.Key.Position]);

                foreach (var aspect in OnMethodBondedAspects)
                    aspect.OnExecuting(invocation);

                base.PerformProceed(invocation);

                foreach (var aspect in OnMethodBondedAspects)
                    aspect.OnExecuted(invocation);

                foreach (var aspect in OnMethodResultBoundedAspects)
                    aspect.CheckArgument("return", invocation.ReturnValue);

            }
            catch (Exception ex)
            {
                foreach (var methodAspect in OnMethodBondedAspects)
                    methodAspect.OnException(invocation, ex);

                if (OnMethodBondedAspects.Any(x => x.IsJideException) || OnMethodBondedAspects.Count == 0)
                    throw;
            }
            finally
            {
                foreach (var methodAspect in OnMethodBondedAspects)
                    methodAspect.OnExit(invocation);
            }

            OnMethodBondedAspects.Clear();
            OnMethodArgumetnBoundedAspects.Clear();
            OnMethodResultBoundedAspects.Clear();
        }

        private IEnumerable<KeyValuePair<ParameterInfo, OnMethodArgumentBoundedAspect>> GetOnMethodArgumetnBoundedAspects(IInvocation invocation)
        {
            var parameters = invocation.Method.GetParameters();
            var result = new List<KeyValuePair<ParameterInfo, OnMethodArgumentBoundedAspect>>(); 

            foreach (var parameter in parameters)
            {
                var aspects = parameter
                    .GetCustomAttributes(typeof (OnMethodArgumentBoundedAspect), true) as OnMethodArgumentBoundedAspect[];

                if (aspects != null)
                    result.AddRange(aspects
                        .Select(aspect => new KeyValuePair<ParameterInfo, OnMethodArgumentBoundedAspect>(parameter, aspect)));
            }

            return result;
        }

        private IEnumerable<OnMethodBondedAspect> GetOnMethodBondedAspects(IInvocation invocation)
        {
            var result = new List<OnMethodBondedAspect>();

            var methodAspects = invocation.Method
                .GetCustomAttributes(typeof (OnMethodBondedAspect), true) as OnMethodBondedAspect[];
            if (methodAspects != null) 
                result.AddRange(methodAspects);

            return result;
        }

        private IEnumerable<OnMethodArgumentBoundedAspect> GetOnMethodResultBoundedAspects(IInvocation invocation)
        {
            var result = new List<OnMethodArgumentBoundedAspect>();

            if (invocation.Method.ReturnParameter == null)
                return result;

            var aspects = invocation.Method.ReturnParameter
                .GetCustomAttributes(typeof(OnMethodArgumentBoundedAspect), true) as OnMethodArgumentBoundedAspect[];

            if (aspects != null) 
                result.AddRange(aspects);

            return result;
        }
    }
}
