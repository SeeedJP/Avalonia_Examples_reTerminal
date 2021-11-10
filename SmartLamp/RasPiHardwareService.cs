using System;
using System.Collections.Generic;
using System.Device.Gpio;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLamp
{
    class RasPiHardwareService : IHardwareService
    {
        private const int LAMP_PIN = 24;    // GPIO24

        private GpioController Gpio;

        public RasPiHardwareService()
        {
            this.Gpio = new GpioController();
            this.Gpio.OpenPin(LAMP_PIN, PinMode.Output);
        }

        public void SetLamp(bool on)
        {
            this.Gpio.Write(LAMP_PIN, on ? PinValue.High : PinValue.Low);
        }
    }
}
