using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOADTrainning
{
    public class SingleInstance
    {
        private static SingleInstance _instance=null;

        private SingleInstance() { }

        static readonly object _locker = new object();
        public static SingleInstance GetSingleInstance()
        {

            lock (_locker)
            {
                if(_instance==null)
                {
                    _instance = new SingleInstance();
                }
                return _instance;
            }


        }
    }
}
