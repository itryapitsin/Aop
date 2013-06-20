using System;
using System.Text.RegularExpressions;
using Autofac.Aop.Exceptions;

namespace Autofac.Aop.Aspects
{
    [AttributeUsage(AttributeTargets.Parameter | AttributeTargets.ReturnValue)]
    public class RegexAttribute: OnMethodArgumentBoundedAspect
    {
        private readonly string _pattern;

        public RegexAttribute(string pattern)
        {
            _pattern = pattern;
        }

        public override void CheckArgument(string argumentName, object value)
        {
            var str = (string)value;

            var regex = new Regex(_pattern);

            if (!regex.IsMatch(str))
                throw new RegexMismatchException(argumentName);
        }
    }
}
