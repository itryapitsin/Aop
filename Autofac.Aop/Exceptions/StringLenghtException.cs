using System;

namespace Autofac.Aop.Exceptions
{
    public class StringLenghtException: ArgumentException
    {   
        public StringLenghtException(string argumentName): base("String lenght is incorrect", argumentName){}
    }
}
