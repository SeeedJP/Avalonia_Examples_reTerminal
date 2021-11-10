using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLamp
{
    class DummyHardwareService : IHardwareService
    {
        public void SetLamp(bool on)
        {
            if (on)
                Debug.WriteLine("Turn on the Lamp.");
            else
                Debug.WriteLine("Turn off the Lamp.");
        }
    }
}
