using System;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using AjAhb4QLiU9IFaCBlx4;
using MfKP42m2oa64TIB4sD0;
using Plugininterface;

namespace Plugins
{
	public class UCCNCplugin
	{
		private bool zr3mvIXL2i;

		public Entry UC;

		private PluginForm Q9GmtP4pmp;

		public bool loopstop;

		public bool loopworking;

		public string Ver;

		private int n5dmL7IcL2;

		public UCCNCplugin() : base() {
			//Discarded unreachable code: IL_0002
			feSgAXQtGpaLrQN7cjx.Lg7HGT6R6e();
			zr3mvIXL2i = true;
			Ver = SGIrQcmgt97uvDTgI6P.InHOenpqO0(0x58864335 ^ 0x588657CB);
		}

		public void Buttonpress_event(int buttonnumber, bool onscreen)
		{
			//Discarded unreachable code: IL_0002
			if (buttonnumber == 226 || buttonnumber == 227 || buttonnumber == 228 || buttonnumber == 220 || buttonnumber == 221 || buttonnumber == 222 || buttonnumber == 223 || buttonnumber == 224 || buttonnumber == 225 || buttonnumber == 159 || buttonnumber == 160 || buttonnumber == 167 || buttonnumber == 168)
			{
				Q9GmtP4pmp.KeyTime = 3;
				Q9GmtP4pmp.MPGsumma = 0.0;
			}
			if (buttonnumber == 100 || buttonnumber == 101 || buttonnumber == 102 || buttonnumber == 103 || buttonnumber == 104 || buttonnumber == 105)
			{
				Q9GmtP4pmp.MPGsumma = 0.0;
				Q9GmtP4pmp.KeyTime = 3;
			}
		}

		public void Configure_event()
		{
			//Discarded unreachable code: IL_0002
			new ConfigForm().ShowDialog();
		}

		public Entry.Pluginproperties Getproperties_event(Entry.Pluginproperties Properties)
		{
			//Discarded unreachable code: IL_0002
			Properties.author = SGIrQcmgt97uvDTgI6P.InHOenpqO0(-1009634455 ^ -1009637791);
			Properties.pluginname = SGIrQcmgt97uvDTgI6P.InHOenpqO0(-608047808 ^ -608044968);
			Properties.pluginversion = Ver;
			return Properties;
		}

		public void Init_event(Entry UC)
		{
			//Discarded unreachable code: IL_0002
			this.UC = UC;
			Q9GmtP4pmp = new PluginForm(this);
			Q9GmtP4pmp.WindowState = FormWindowState.Minimized;
			Q9GmtP4pmp.ShowInTaskbar = false;
			Q9GmtP4pmp.Show();
			loopstop = false;
		}

		public void Loop_event()
		{
			//Discarded unreachable code: IL_0002
			Thread.CurrentThread.CurrentUICulture = new CultureInfo(SGIrQcmgt97uvDTgI6P.InHOenpqO0(0x12BE7EBF ^ 0x12BE6B85), useUserOverride: false);
			Thread.CurrentThread.CurrentCulture = new CultureInfo(SGIrQcmgt97uvDTgI6P.InHOenpqO0(-407835460 ^ -407832186), useUserOverride: false);
			if (loopstop || Q9GmtP4pmp == null || Q9GmtP4pmp.IsDisposed)
			{
				return;
			}
			if (zr3mvIXL2i)
			{
				zr3mvIXL2i = false;
			}
			loopworking = true;
			try
			{
				n5dmL7IcL2++;
				if (n5dmL7IcL2 > 1)
				{
					n5dmL7IcL2 = 0;
					if (Q9GmtP4pmp != null)
					{
						Q9GmtP4pmp.SendDisplayData(End: false);
					}
				}
				if (Q9GmtP4pmp != null)
				{
					Q9GmtP4pmp.MPGEvent();
				}
			}
			catch (Exception)
			{
			}
			loopworking = false;
		}

		private void SEGmBKf1fr()
		{
		}//Discarded unreachable code: IL_0002


		public void Showup_event()
		{
			//Discarded unreachable code: IL_0002
			if (Q9GmtP4pmp == null || Q9GmtP4pmp.IsDisposed)
			{
				Q9GmtP4pmp = new PluginForm(this);
			}
			loopstop = false;
			SEGmBKf1fr();
			if (!Q9GmtP4pmp.Visible)
			{
				Q9GmtP4pmp.Visible = true;
			}
			Q9GmtP4pmp.BringToFront();
		}

		public void Shutdown_event()
		{
			try
			{
				loopstop = true;
				Q9GmtP4pmp.SaveParam();
				Q9GmtP4pmp.MpgNotifyIcon.Dispose();
				Q9GmtP4pmp.Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}

		public void Startup_event()
		{
			//Discarded unreachable code: IL_0002
			if (Q9GmtP4pmp == null || Q9GmtP4pmp.IsDisposed)
			{
				Q9GmtP4pmp = new PluginForm(this);
			}
			Thread.Sleep(20);
			loopstop = false;
			SEGmBKf1fr();
			Q9GmtP4pmp.Text = SGIrQcmgt97uvDTgI6P.InHOenpqO0(0x496B5A49 ^ 0x496B4F01) + Ver;
			loopstop = false;
		}
	}
}
