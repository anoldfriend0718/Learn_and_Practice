using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOADTrainning
{
    public interface ILog
    {
        void Log();
    }

    public class MyClass
    {
        private ILog mlogger;

        public MyClass(ILog logger)
        {
            mlogger = logger;
        }
    }
}
