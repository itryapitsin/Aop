using System;

namespace Autofac.Aop.Tests.Aspects
{
    public class Experimental : IExperimental
    {
        public object ExperimentalProperty { get; set; }

        public void NullParamExperimentalAction(object obj)
        {
        }

        public object ReturnNullExperimentalAction()
        {
            return null;
        }

        public object ReturnNullExperimentalAction2()
        {
            return new object();
        }

        public void MinValueExperimentalAction(int arg)
        {
        }

        public void MaxValueEperimentalAction(int arg)
        {
        }

        public void NotEmptyGuidEperimentalAction(Guid arg)
        {
        }

        public void NotNullOrEmptyEperimentalAction(string arg)
        {
        }

        public void RegexEperimentalAction(string arg)
        {
            
        }

        public void StringLengthEperimentalAction(string arg)
        {
            
        }

        public void MethodBondedAspectEperimentalAction()
        {
            
        }
    }
}
