using System;
using Autofac.Aop.Aspects;

namespace Autofac.Aop.Tests.Aspects
{
    public interface IExperimental
    {
        
        object ExperimentalProperty
        {
            get;
            set;
        }

        void NullParamExperimentalAction([NotNull] object obj);

        [return: NotNull]
        object ReturnNullExperimentalAction();

        [return: NotNull]
        object ReturnNullExperimentalAction2();

        void MinValueExperimentalAction([MinValue(1)]int arg);

        void MaxValueEperimentalAction([MaxValue(1)]int arg);

        void NotEmptyGuidEperimentalAction([NotEmptyGuid]Guid arg);

        void NotNullOrEmptyEperimentalAction([NotNullOrEmpty]string arg);

        void RegexEperimentalAction([Regex(@"\d")]string arg);

        void StringLengthEperimentalAction([StringLenght(2)]string arg);

        [TestOnMethodBondedAspect]
        void MethodBondedAspectEperimentalAction();
    }
}
