using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Plugins {
    class Pendant {
		private global::Plugininterface.Entry UC;
		private global::Plugins.UCCNCplugin uccncPlugin;
		private global::UsbLibrary.UsbHidPort usbHidPort;
		public static double FilterAxisPosition(double axisPosition, bool end) {
			// Set it to zero is the end thingo is called
			if (end) { return 0.0; };

			// Do The actual filtering
			if (axisPosition >= 0.0) { return (axisPosition * 10000.0 + 0.5) / 10000.0; } else { return (axisPosition * 10000.0 - 0.5) / 10000.0; }
		}
		public static int DecimalSigned(double axisPosition) {
			int returnValue = (int)((Math.Abs(axisPosition) - (double)((int)Math.Abs(axisPosition))) * 10000.0);
			if (axisPosition < 0.0) { returnValue |= 32768; }

			// Return
			return returnValue;
		}
	}
}
