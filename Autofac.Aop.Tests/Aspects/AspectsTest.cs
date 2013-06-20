using System;
using Autofac.Extras.DynamicProxy2;
using NUnit.Framework;

namespace Autofac.Aop.Tests.Aspects
{
    [TestFixture]
    public class AspectsTest : BaseTest<IExperimental>
    {
        [SetUp]
        public override void TestInitialize()
        {
            base.TestInitialize();

            var builder = new ContainerBuilder();

            builder
                .RegisterType<Experimental>()
                .As<IExperimental>()
                .EnableInterfaceInterceptors()
                .InterceptedBy(typeof (MethodInterceptor));

            builder
                .RegisterType(typeof(Experimental))
                .EnableClassInterceptors()
                .InterceptedBy(typeof(MethodInterceptor));

            builder.Register(x => new MethodInterceptor());

            var container = builder.Build();

            TestObject = container.Resolve<IExperimental>();
        }

        [Test]
        public void Throw_exception_when_set_nullable_argument()
        {
            Assert.Throws<ArgumentNullException>(
                () => TestObject.NullParamExperimentalAction(null));

            TestObject.NullParamExperimentalAction(new object());
        }

        [Test]
        public void Throw_exception_when_call_OnMethodBondedAspect_OnExecuting()
        {
            Assert.Throws<SuccessException>(
                () => TestObject.MethodBondedAspectEperimentalAction());
        }

        [Test]
        public void Throw_exception_when_return_nullable_argument()
        {
            Assert.Throws<ArgumentNullException>(
                () => TestObject.ReturnNullExperimentalAction());

            TestObject.ReturnNullExperimentalAction2();
        }

        [Test]
        public void Throw_exception_when_argument_min_value_less()
        {
            Assert.Throws<ArgumentOutOfRangeException>(
                () => TestObject.MinValueExperimentalAction(-1));

            TestObject.MinValueExperimentalAction(10);
        }

        [Test]
        public void Throw_exception_when_argument_max_value_great()
        {
            Assert.Throws<ArgumentOutOfRangeException>(
                () => TestObject.MaxValueEperimentalAction(10));

            TestObject.MaxValueEperimentalAction(0);
        }

        [Test]
        public void Throw_exception_when_argument_empty_guid()
        {
            Assert.Throws<EmptyGuidException>(
                () => TestObject.NotEmptyGuidEperimentalAction(Guid.Empty));

            TestObject.NotEmptyGuidEperimentalAction(Guid.NewGuid());
        }

        [Test]
        public void Throw_exception_when_argument_string_empty()
        {
            Assert.Throws<ArgumentNullException>(
                () => TestObject.NotNullOrEmptyEperimentalAction(String.Empty));

            TestObject.NotNullOrEmptyEperimentalAction("abcdefg");
        }

        [Test]
        public void Throw_exception_when_argument_mismatch_regex()
        {
            Assert.Throws<RegexMismatchException>(
                () => TestObject.RegexEperimentalAction("abcdefg"));

            TestObject.RegexEperimentalAction("1");
        }

        [Test]
        public void Throw_exception_when_argument_string_length_invalid()
        {
            Assert.Throws<StringLenghtException>(
                () => TestObject.StringLengthEperimentalAction("a"));

            TestObject.StringLengthEperimentalAction("abcdefg");
        }
    }
}
