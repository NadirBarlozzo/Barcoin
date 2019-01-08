using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM
{
    public abstract class ViewBindableBase : BindableBase
    {
        public abstract string Name { get; }
        protected abstract void RegisterMessages();   // per la comunicazione tra vm
        protected abstract void RegisterCommands();   // per la gestione di comandi / eventi
    }
}
