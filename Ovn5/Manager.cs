using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovn5
{
    /// <summary>
    ///  Pratar med IUI/UI och IHandler/Handler
    /// </summary>
    internal class Manager
    {
        private IUI iui = new UI();
        private IHandler iHandler = new Handler();
       
        public Manager(IUI iui, IHandler iHandler)
        {
            this.iui = iui;
            this.iHandler = iHandler;
        }

        public IUI Iui
        {
            get => iui;
            set => iui = value;
        }
        public IHandler IHandler
        {
            get => iHandler;
            set => iHandler = value;
        }
    }
}
