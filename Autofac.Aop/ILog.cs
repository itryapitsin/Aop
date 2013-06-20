using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autofac.Aop
{
    public interface ILog
    {
        void Write(string message);

        void Write(Exception ex);
    }
}
