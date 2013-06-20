using System;

namespace Autofac.Aop.Exceptions
{
    public class RegexMismatchException: ArgumentException
    {
        public RegexMismatchException(string argumentName): base("String mismatch with pattern", argumentName){}
    }
}
