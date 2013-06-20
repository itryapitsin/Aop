using System;

namespace Autofac.Aop.Exceptions
{
    public class EmptyGuidException: ArgumentException
    {
        public EmptyGuidException(string argumentName):base("Guid is empty", argumentName)
        {
        }
    }
}
