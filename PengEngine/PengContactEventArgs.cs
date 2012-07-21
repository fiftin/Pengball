using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PengEngine
{
    public class PengContactEventArgs : EventArgs
    {
        public PengContactEventArgs(PengObject contactee)
        {
            Contactee = contactee;
        }

        public PengObject Contactee { get; private set; }
    }
}
