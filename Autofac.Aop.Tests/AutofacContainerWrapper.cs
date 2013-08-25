using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Qualificator.Kernel;

namespace Autofac.Aop.Tests
{
    public class AutofacContainerWrapper : IContainerWrapper<IContainer>
    {
        private readonly Action<ContainerBuilder> _register;

        public AutofacContainerWrapper(Action<ContainerBuilder> register)
        {
            if (register == null)
                throw new NullReferenceException("_register");

            _register = register;
        }

        public IContainer GetContainer()
        {
            var builder = new ContainerBuilder();

            _register(builder);

            return builder.Build();
        }
    }
}
