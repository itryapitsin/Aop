using System;
using Castle.DynamicProxy;

namespace Autofac.Aop.Aspects
{
    public class LoggingExceptionAttribute : OnMethodBondedAspect
    {
        private readonly ILog _log;

        public LoggingExceptionAttribute(ILog log) : base(isJideException: false)
        {
            _log = log;
        }

        public override void OnException(IInvocation invocation, Exception exception)
        {
            var message = string.Format(@"
                Exception was thrown:
                    Exception message: {0}
                    Stack trace: {1}
                    Inner exception: {2}",
                exception.Message,
                exception.StackTrace,
                exception.InnerException);

            _log.Write(exception);
            Console.WriteLine(message);
        }
    }
}
