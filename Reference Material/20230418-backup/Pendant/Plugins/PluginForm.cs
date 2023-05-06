using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using AjAhb4QLiU9IFaCBlx4;
using MfKP42m2oa64TIB4sD0;
using Plugininterface;
using Plugins.Properties;
using UsbLibrary;

namespace Plugins
{
	public class PluginForm : Form
	{
		public struct Nyg
		{
			public bool Reset;

			public bool Stop;

			public bool GotoZero;

			public bool StartPause;

			public bool ProbeZ;

			public bool Spindle;

			public bool Null;

			public bool SafeZ;

			public bool FeedPlus;

			public bool FeedMinus;

			public bool SpindlePlus;

			public bool SpindleMinus;

			public bool Home;

			public bool Macro1;

			public bool Macro2;

			public bool Macro3;

			public bool Macro4;

			public bool Macro5;

			public bool Macro6;

			public bool Macro7;

			public bool Macro8;

			public bool Macro9;

			public bool Macro10;

			public bool StepMode;

			public bool ContinuousMode;
		}

		public enum WHB04BPendantControl : byte
		{
			None = 0,
			Reset = 1,
			Stop = 2,
			Start = 3,
			FeedPlus = 4,
			FeedMinus = 5,
			SpindlePlus = 6,
			SpindleMinus = 7,
			MOrigin = 8,
			SafeZ = 9,
			WOrigin = 10,
			SpindleToggle = 11,
			Function = 12,
			ProbeZ = 13,
			Continious = 14,
			Step = 15,
			Macro10 = 16
		}

		public enum WHB04BAxisSwitchControl : byte
		{
			Unknown = 0,
			Off = 6,
			X = 17,
			Y = 18,
			Z = 19,
			A = 20
		}

		public enum Whb04BPendantButton : byte
		{
			None = 0,
			Reset = 1,
			Stop = 2,
			Start = 3,
			MacroOne = 4,
			MacroTwo = 5,
			MacroThree = 6,
			MacroFour = 7,
			MacroFive = 8,
			MacroSix = 9,
			MacroSeven = 10,
			MacroEight = 11,
			Function = 12,
			MacroNine = 13,
			MacroTen = 16,
			Continuous = 14,
			Step = 15
		}

		public enum Whb04BJogModeSwitch : byte
		{
			Unknown = 0,
			TwoPercent = 13,
			FivePercent = 14,
			TenPercent = 15,
			ThirtyPercent = 16,
			SixtyPercent = 26,
			HundredPercent = 27,
			Lead = 155
		}

		private Entry xnebTvyAOQ;

		private UCCNCplugin jUvbZDBtyE;

		public int Counter;

		private byte[] gcZb0ZVm8p;

		private int[] fKgb1T8nuG;

		private double fkwbfUPG3J;

		public int KeyTime;

		public int MPG;

		private int Y1JbMv8qwH;

		private int nlHbpVvlo6;

		public int MPGFilter;

		private int tmAbybR6so;

		public double MPGSpeedMultiplier;

		private int[] LcabRmTEUe;

		public double MPGsumma;

		private int bq3b8ROAwH;

		private double t8BbhdSDhT;

		private Nyg gUJb7McOB9;

		private Nyg bnabG0ArER;

		private int oWcbuNLLed;

		private byte tA0bcXfa88;

		private double xFobCRdUyk;

		private bool XvVbUROtg0;

		private int oJjblAMHSQ;

		private int c67brgCs6C;

		private double sMbbDD49Ui;

		private IContainer lvmbAjgU5k;

		private UsbHidPort vZDbaMj4Ql;

		private PictureBox B7IbBTSM5B;

		private Label y37bvXgkj0;

		private TextBox Mldbt8Zqt4;

		private CheckBox FsHbLAoHPO;

		private ComboBox Jylb9kP3d7;

		private CheckBox o0mboTi7X3;

		private Label k0LbkLmWbd;

		private TextBox zZgbIH7xFN;

		private TextBox XeWbVIdjce;

		private CheckBox Qs0bJKaFBw;

		private CheckBox E4DbgGGpcM;

		private ComboBox qXpb2LOPqX;

		private ComboBox R18bK9ookx;

		private CheckBox xwkb6SHMUC;

		private CheckBox YLDbXSHZ1K;

		private Label xw1bz0SK4w;

		private Label wdLm5fHcVm;

		private TextBox ctlmbK54hi;

		private TextBox Y22mm3reOe;

		private CheckBox MXQmOf2ifb;

		private CheckBox d1TmQGDX6w;

		private ComboBox JfFmHevaoo;

		private ComboBox OKWmno7guW;

		private CheckBox q3wm40oMBr;

		private CheckBox vEtmF4A4wm;

		private Label k7TmSdsfTe;

		private Label AJKms0lewQ;

		private Label dEnm37R6sH;

		private TextBox wgBmdev3Ll;

		private TextBox XZamxMrGIy;

		private TextBox kYemqTcBDI;

		private TextBox HI9mYBsjkF;

		private TextBox C6fmeRiJ10;

		private CheckBox nmDmEtxprn;

		private CheckBox h6HmNQ6hc5;

		private CheckBox vxKmi3AeBK;

		private CheckBox K20mjcDvgt;

		private CheckBox YFbmPNmvji;

		private GroupBox glymwqjAOk;

		private TextBox dZ9mWckw4V;

		private ComboBox X0UmTTKfnQ;

		private Label WxOmZbwb8E;

		private Label vFPm059VHW;

		private Label fjcm1TkRlW;

		private ComboBox RMTmfGCqEE;

		private ComboBox gINmM2fk89;

		private ComboBox ocGmpFAaJK;

		private ComboBox GYVmykrvxI;

		private ComboBox VQ9mRoWWfE;

		private CheckBox kWwm802q8H;

		private CheckBox LUImhwSclU;

		private CheckBox kjCm7BPKIA;

		private CheckBox BebmGxuFru;

		private CheckBox bJNmu7IdXZ;

		private Label EEkmctOg4k;

		private Label UXdmCSV0PB;

		private Label AdimUd9GBa;

		private Label TVHmluBr1b;

		private Label dELmrfEYC7;

		private Button kXQmDXF4HH;

		public NotifyIcon MpgNotifyIcon;

		private TextBox N5JmAUwG5P;

		private CheckBox gXpmaknpZT;

		public PluginForm(UCCNCplugin Pluginmain) : base(Pluginmain) {
			//Discarded unreachable code: IL_0002
			feSgAXQtGpaLrQN7cjx.Lg7HGT6R6e();
			gcZb0ZVm8p = new byte[8];
			MPGFilter = 5;
			MPGSpeedMultiplier = 20.0;
			LcabRmTEUe = new int[28];
			XvVbUROtg0 = true;
			oJjblAMHSQ = -1;
			c67brgCs6C = -1;
			xnebTvyAOQ = Pluginmain.UC;
			jUvbZDBtyE = Pluginmain;
			LF2bWWLDab();
			LoadParam();
		}

		private void hLXLHJtYb(object _0020, EventArgs _0020)
		{
		}//Discarded unreachable code: IL_0002


		private void Imd9dNhhW(object _0020, EventArgs _0020)
		{
			try
			{
				vZDbaMj4Ql.ProductId = 60307;
				vZDbaMj4Ql.VendorId = 4302;
				vZDbaMj4Ql.CheckDevicePresent();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}

		private void Q6yof51DC(object _0020, EventArgs _0020)
		{
		}//Discarded unreachable code: IL_0002


		private void g34khBb3h(object _0020, EventArgs _0020)
		{
			//Discarded unreachable code: IL_0002
			if (base.InvokeRequired)
			{
				Invoke(args: new object[2] { _0020, _0020 }, method: new EventHandler(g34khBb3h));
			}
		}

		private void W0oISGaA0(object _0020, EventArgs _0020)
		{
			//Discarded unreachable code: IL_0002
			dEnm37R6sH.Text = SGIrQcmgt97uvDTgI6P.InHOenpqO0(-9234614 ^ -9235110);
		}

		private void Ak9Vw974Q(object _0020, EventArgs _0020)
		{
			//Discarded unreachable code: IL_0002
			if (!base.InvokeRequired)
			{
				dEnm37R6sH.Text = SGIrQcmgt97uvDTgI6P.InHOenpqO0(-528050159 ^ -528049579);
				return;
			}
			Invoke(args: new object[2] { _0020, _0020 }, method: new EventHandler(Ak9Vw974Q));
		}

		private void E2sJxilmE(object _0020, DataRecievedEventArgs _0020)
		{
			//Discarded unreachable code: IL_0002
			if (base.InvokeRequired)
			{
				try
				{
					Invoke(new DataRecievedEventHandler(E2sJxilmE), _0020, _0020);
					return;
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.ToString());
					return;
				}
			}
			if (_0020.data[0] == 4 && _0020.data[2] == 0 && _0020.data[3] == 0 && _0020.data[4] == 0 && _0020.data[5] == 0 && _0020.data[6] == 0)
			{
				xnebTvyAOQ.JogOnSpeed(0, Dir: false, 0.0);
				xnebTvyAOQ.JogOnSpeed(1, Dir: false, 0.0);
				xnebTvyAOQ.JogOnSpeed(2, Dir: false, 0.0);
				xnebTvyAOQ.JogOnSpeed(3, Dir: false, 0.0);
				xnebTvyAOQ.JogOnSpeed(4, Dir: false, 0.0);
				xnebTvyAOQ.JogOnSpeed(5, Dir: false, 0.0);
				return;
			}
			if (_0020.data[6] != 0)
			{
				byte b = _0020.data[6];
				if (b < 128)
				{
					Y1JbMv8qwH += _0020.data[6];
				}
				else
				{
					Y1JbMv8qwH -= 256 - b;
				}
			}
			if (_0020.data[5] != 6)
			{
				switch (_0020.data[5])
				{
				case 17:
					tA0bcXfa88 = 1;
					break;
				case 18:
					tA0bcXfa88 = 2;
					break;
				case 19:
					tA0bcXfa88 = 3;
					break;
				case 20:
					tA0bcXfa88 = 4;
					break;
				case 21:
					tA0bcXfa88 = 5;
					break;
				case 22:
					tA0bcXfa88 = 6;
					break;
				}
			}
			else
			{
				tA0bcXfa88 = 0;
			}
			int num = 0;
			if (_0020.data[4] == 13)
			{
				xFobCRdUyk = 2.0;
				num = 241;
			}
			if (_0020.data[4] == 14)
			{
				xFobCRdUyk = 5.0;
				num = 164;
			}
			if (_0020.data[4] == 15)
			{
				xFobCRdUyk = 10.0;
				num = 165;
			}
			if (_0020.data[4] == 16)
			{
				xFobCRdUyk = 30.0;
				num = 166;
			}
			if (_0020.data[4] == 26)
			{
				xFobCRdUyk = 60.0;
			}
			if (_0020.data[4] == 27)
			{
				xFobCRdUyk = 100.0;
			}
			KeyTime = 3;
			if (XvVbUROtg0)
			{
				if ((double)xnebTvyAOQ.Getfieldint(isAS3: false, 913) != xFobCRdUyk)
				{
					xnebTvyAOQ.Setfield(isAS3: false, xFobCRdUyk, 913);
					xnebTvyAOQ.Validatefield(isAS3: false, 913);
					xnebTvyAOQ.Setfield(isAS3: true, xFobCRdUyk, 913);
					xnebTvyAOQ.Validatefield(isAS3: true, 913);
				}
			}
			else if (num != 0 && num != c67brgCs6C)
			{
				xnebTvyAOQ.Callbutton(num);
				c67brgCs6C = num;
			}
			if (_0020.data[2] != 0 || _0020.data[3] != 0)
			{
				byte b2 = _0020.data[2];
				byte b3 = _0020.data[3];
				bnabG0ArER = gUJb7McOB9;
				if (b2 == 1)
				{
					gUJb7McOB9.Reset = true;
				}
				else
				{
					gUJb7McOB9.Reset = false;
				}
				if (b2 == 2)
				{
					gUJb7McOB9.Stop = true;
				}
				else
				{
					gUJb7McOB9.Stop = false;
				}
				if (b2 == 3)
				{
					gUJb7McOB9.StartPause = true;
				}
				else
				{
					gUJb7McOB9.StartPause = false;
				}
				if (gXpmaknpZT.Checked)
				{
					if (b2 == 12)
					{
						if (b3 == 4)
						{
							gUJb7McOB9.Macro1 = true;
						}
						else
						{
							gUJb7McOB9.Macro1 = false;
						}
						if (b3 == 5)
						{
							gUJb7McOB9.Macro2 = true;
						}
						else
						{
							gUJb7McOB9.Macro2 = false;
						}
						if (b3 == 6)
						{
							gUJb7McOB9.Macro3 = true;
						}
						else
						{
							gUJb7McOB9.Macro3 = false;
						}
						if (b3 == 7)
						{
							gUJb7McOB9.Macro4 = true;
						}
						else
						{
							gUJb7McOB9.Macro4 = false;
						}
						if (b3 == 8)
						{
							gUJb7McOB9.Macro5 = true;
						}
						else
						{
							gUJb7McOB9.Macro5 = false;
						}
						if (b3 == 9)
						{
							gUJb7McOB9.Macro6 = true;
						}
						else
						{
							gUJb7McOB9.Macro6 = false;
						}
						if (b3 == 10)
						{
							gUJb7McOB9.Macro7 = true;
						}
						else
						{
							gUJb7McOB9.Macro7 = false;
						}
						if (b3 == 11)
						{
							gUJb7McOB9.Macro8 = true;
						}
						else
						{
							gUJb7McOB9.Macro8 = false;
						}
						if (b3 == 13)
						{
							gUJb7McOB9.Macro9 = true;
						}
						else
						{
							gUJb7McOB9.Macro9 = false;
						}
					}
					if (b2 == 10)
					{
						gUJb7McOB9.GotoZero = true;
					}
					else
					{
						gUJb7McOB9.GotoZero = false;
					}
					if (b2 == 13)
					{
						gUJb7McOB9.ProbeZ = true;
					}
					else
					{
						gUJb7McOB9.ProbeZ = false;
					}
					if (b2 == 11)
					{
						gUJb7McOB9.Spindle = true;
					}
					else
					{
						gUJb7McOB9.Spindle = false;
					}
					if (b2 == 9)
					{
						gUJb7McOB9.SafeZ = true;
					}
					else
					{
						gUJb7McOB9.SafeZ = false;
					}
					if (b2 == 8)
					{
						gUJb7McOB9.Home = true;
					}
					else
					{
						gUJb7McOB9.Home = false;
					}
					if (b2 == 4)
					{
						gUJb7McOB9.FeedPlus = true;
					}
					else
					{
						gUJb7McOB9.FeedPlus = false;
					}
					if (b2 == 5)
					{
						gUJb7McOB9.FeedMinus = true;
					}
					else
					{
						gUJb7McOB9.FeedMinus = false;
					}
					if (b2 == 6)
					{
						gUJb7McOB9.SpindlePlus = true;
					}
					else
					{
						gUJb7McOB9.SpindlePlus = false;
					}
					if (b2 == 7)
					{
						gUJb7McOB9.SpindleMinus = true;
					}
					else
					{
						gUJb7McOB9.SpindleMinus = false;
					}
				}
				else
				{
					if (b2 == 12)
					{
						if (b3 == 10)
						{
							gUJb7McOB9.GotoZero = true;
						}
						else
						{
							gUJb7McOB9.GotoZero = false;
						}
						if (b3 == 13)
						{
							gUJb7McOB9.ProbeZ = true;
						}
						else
						{
							gUJb7McOB9.ProbeZ = false;
						}
						if (b3 == 11)
						{
							gUJb7McOB9.Spindle = true;
						}
						else
						{
							gUJb7McOB9.Spindle = false;
						}
						if (b3 == 9)
						{
							gUJb7McOB9.SafeZ = true;
						}
						else
						{
							gUJb7McOB9.SafeZ = false;
						}
						if (b3 == 8)
						{
							gUJb7McOB9.Home = true;
						}
						else
						{
							gUJb7McOB9.Home = false;
						}
						if (b3 == 4)
						{
							gUJb7McOB9.FeedPlus = true;
						}
						else
						{
							gUJb7McOB9.FeedPlus = false;
						}
						if (b3 == 5)
						{
							gUJb7McOB9.FeedMinus = true;
						}
						else
						{
							gUJb7McOB9.FeedMinus = false;
						}
						if (b3 == 6)
						{
							gUJb7McOB9.SpindlePlus = true;
						}
						else
						{
							gUJb7McOB9.SpindlePlus = false;
						}
						if (b3 == 7)
						{
							gUJb7McOB9.SpindleMinus = true;
						}
						else
						{
							gUJb7McOB9.SpindleMinus = false;
						}
					}
					if (b2 == 4)
					{
						gUJb7McOB9.Macro1 = true;
					}
					else
					{
						gUJb7McOB9.Macro1 = false;
					}
					if (b2 == 5)
					{
						gUJb7McOB9.Macro2 = true;
					}
					else
					{
						gUJb7McOB9.Macro2 = false;
					}
					if (b2 == 6)
					{
						gUJb7McOB9.Macro3 = true;
					}
					else
					{
						gUJb7McOB9.Macro3 = false;
					}
					if (b2 == 7)
					{
						gUJb7McOB9.Macro4 = true;
					}
					else
					{
						gUJb7McOB9.Macro4 = false;
					}
					if (b2 == 8)
					{
						gUJb7McOB9.Macro5 = true;
					}
					else
					{
						gUJb7McOB9.Macro5 = false;
					}
					if (b2 == 9)
					{
						gUJb7McOB9.Macro6 = true;
					}
					else
					{
						gUJb7McOB9.Macro6 = false;
					}
					if (b2 == 10)
					{
						gUJb7McOB9.Macro7 = true;
					}
					else
					{
						gUJb7McOB9.Macro7 = false;
					}
					if (b2 == 11)
					{
						gUJb7McOB9.Macro8 = true;
					}
					else
					{
						gUJb7McOB9.Macro8 = false;
					}
					if (b2 == 13)
					{
						gUJb7McOB9.Macro9 = true;
					}
					else
					{
						gUJb7McOB9.Macro9 = false;
					}
				}
				if (b2 == 16)
				{
					gUJb7McOB9.Macro10 = true;
				}
				else
				{
					gUJb7McOB9.Macro10 = false;
				}
				if (b2 == 15)
				{
					gUJb7McOB9.StepMode = true;
				}
				else
				{
					gUJb7McOB9.StepMode = false;
				}
				if (b2 == 14)
				{
					gUJb7McOB9.ContinuousMode = true;
				}
				else
				{
					gUJb7McOB9.ContinuousMode = false;
				}
			}
			else
			{
				gUJb7McOB9.GotoZero = false;
				gUJb7McOB9.Home = false;
				gUJb7McOB9.Macro1 = false;
				gUJb7McOB9.Macro2 = false;
				gUJb7McOB9.Macro3 = false;
				gUJb7McOB9.Macro4 = false;
				gUJb7McOB9.Macro5 = false;
				gUJb7McOB9.Macro6 = false;
				gUJb7McOB9.Macro7 = false;
				gUJb7McOB9.Macro8 = false;
				gUJb7McOB9.Macro9 = false;
				gUJb7McOB9.Macro10 = false;
				gUJb7McOB9.ContinuousMode = false;
				gUJb7McOB9.Null = false;
				gUJb7McOB9.ProbeZ = false;
				gUJb7McOB9.Reset = false;
				gUJb7McOB9.SafeZ = false;
				gUJb7McOB9.Spindle = false;
				gUJb7McOB9.StartPause = false;
				gUJb7McOB9.StepMode = false;
				gUJb7McOB9.Stop = false;
				gUJb7McOB9.FeedPlus = false;
				gUJb7McOB9.FeedMinus = false;
				gUJb7McOB9.SpindlePlus = false;
				gUJb7McOB9.SpindleMinus = false;
			}
			EJxgQw9to();
		}

		private void EJxgQw9to()
		{
			//Discarded unreachable code: IL_0002
			if (tA0bcXfa88 == 1 && !xnebTvyAOQ.GetLED(155))
			{
				xnebTvyAOQ.Callbutton(220);
			}
			else if (tA0bcXfa88 == 2 && !xnebTvyAOQ.GetLED(156))
			{
				xnebTvyAOQ.Callbutton(221);
			}
			else if (tA0bcXfa88 == 3 && !xnebTvyAOQ.GetLED(157))
			{
				xnebTvyAOQ.Callbutton(222);
			}
			else if (tA0bcXfa88 == 4 && !xnebTvyAOQ.GetLED(158))
			{
				xnebTvyAOQ.Callbutton(223);
			}
			else if (tA0bcXfa88 == 5 && !xnebTvyAOQ.GetLED(159))
			{
				xnebTvyAOQ.Callbutton(224);
			}
			else if (tA0bcXfa88 == 6 && !xnebTvyAOQ.GetLED(160))
			{
				xnebTvyAOQ.Callbutton(225);
			}
			if (!bnabG0ArER.Reset && gUJb7McOB9.Reset)
			{
				xnebTvyAOQ.Callbutton(144);
			}
			if (!bnabG0ArER.Stop && gUJb7McOB9.Stop)
			{
				xnebTvyAOQ.Callbutton(130);
			}
			if (!bnabG0ArER.Home && gUJb7McOB9.Home)
			{
				xnebTvyAOQ.Callbutton(113);
			}
			if (!bnabG0ArER.FeedPlus && gUJb7McOB9.FeedPlus)
			{
				xnebTvyAOQ.Callbutton(132);
			}
			if (!bnabG0ArER.FeedMinus && gUJb7McOB9.FeedMinus)
			{
				xnebTvyAOQ.Callbutton(133);
			}
			if (!bnabG0ArER.SpindlePlus && gUJb7McOB9.SpindlePlus)
			{
				xnebTvyAOQ.Callbutton(134);
			}
			if (!bnabG0ArER.SpindleMinus && gUJb7McOB9.SpindleMinus)
			{
				xnebTvyAOQ.Callbutton(135);
			}
			if (!bnabG0ArER.StartPause && gUJb7McOB9.StartPause)
			{
				if (xnebTvyAOQ.GetLED(18))
				{
					xnebTvyAOQ.Callbutton(128);
				}
				else if (xnebTvyAOQ.GetLED(217))
				{
					xnebTvyAOQ.Callbutton(524);
				}
				else
				{
					xnebTvyAOQ.Callbutton(523);
				}
			}
			if (!bnabG0ArER.ProbeZ && gUJb7McOB9.ProbeZ)
			{
				xnebTvyAOQ.Callbutton(196);
			}
			if (!bnabG0ArER.Spindle && gUJb7McOB9.Spindle)
			{
				xnebTvyAOQ.Callbutton(114);
			}
			if (!bnabG0ArER.Null && gUJb7McOB9.Null && xnebTvyAOQ.GetLED(18))
			{
				if (tA0bcXfa88 == 1 && xnebTvyAOQ.GetLED(155))
				{
					xnebTvyAOQ.Callbutton(100);
				}
				if (tA0bcXfa88 == 2 && xnebTvyAOQ.GetLED(156))
				{
					xnebTvyAOQ.Callbutton(101);
				}
				if (tA0bcXfa88 == 3 && xnebTvyAOQ.GetLED(157))
				{
					xnebTvyAOQ.Callbutton(102);
				}
				if (tA0bcXfa88 == 4 && xnebTvyAOQ.GetLED(158))
				{
					xnebTvyAOQ.Callbutton(103);
				}
				if (tA0bcXfa88 == 5 && xnebTvyAOQ.GetLED(159))
				{
					xnebTvyAOQ.Callbutton(104);
				}
				if (tA0bcXfa88 == 6 && xnebTvyAOQ.GetLED(160))
				{
					xnebTvyAOQ.Callbutton(105);
				}
			}
			if (!bnabG0ArER.SafeZ && gUJb7McOB9.SafeZ && xnebTvyAOQ.GetLED(18))
			{
				xnebTvyAOQ.Code(SGIrQcmgt97uvDTgI6P.InHOenpqO0(--1998319630 ^ 0x771BF288) + xnebTvyAOQ.Getfield(isAS3: true, 225));
			}
			if (!bnabG0ArER.GotoZero && gUJb7McOB9.GotoZero)
			{
				xnebTvyAOQ.Callbutton(131);
			}
			if (!bnabG0ArER.StepMode && gUJb7McOB9.StepMode)
			{
				if (!xnebTvyAOQ.GetLED(152) && !xnebTvyAOQ.GetLED(153) && !xnebTvyAOQ.GetLED(154))
				{
					xnebTvyAOQ.Callbutton(226);
				}
				else if (xnebTvyAOQ.GetLED(152))
				{
					xnebTvyAOQ.Callbutton(227);
				}
				else if (xnebTvyAOQ.GetLED(153))
				{
					xnebTvyAOQ.Callbutton(228);
				}
				else if (xnebTvyAOQ.GetLED(154))
				{
					xnebTvyAOQ.Callbutton(226);
				}
				KeyTime = 3;
				XvVbUROtg0 = false;
			}
			if (!bnabG0ArER.ContinuousMode && gUJb7McOB9.ContinuousMode)
			{
				xnebTvyAOQ.Callbutton(161);
				KeyTime = 3;
				XvVbUROtg0 = true;
			}
			if (!bnabG0ArER.Macro1 && gUJb7McOB9.Macro1)
			{
				if (bJNmu7IdXZ.Checked)
				{
					if (VQ9mRoWWfE.Items.Count == fKgb1T8nuG.Length)
					{
						xnebTvyAOQ.Callbutton(fKgb1T8nuG[VQ9mRoWWfE.SelectedIndex]);
					}
				}
				else
				{
					try
					{
						xnebTvyAOQ.Code(SGIrQcmgt97uvDTgI6P.InHOenpqO0(0x31FDEB81 ^ 0x31FDE913) + C6fmeRiJ10.Text);
					}
					catch
					{
					}
				}
			}
			if (!bnabG0ArER.Macro2 && gUJb7McOB9.Macro2)
			{
				if (BebmGxuFru.Checked)
				{
					if (GYVmykrvxI.Items.Count == fKgb1T8nuG.Length)
					{
						xnebTvyAOQ.Callbutton(fKgb1T8nuG[GYVmykrvxI.SelectedIndex]);
					}
				}
				else
				{
					try
					{
						xnebTvyAOQ.Code(SGIrQcmgt97uvDTgI6P.InHOenpqO0(0x5CEF7519 ^ 0x5CEF778B) + HI9mYBsjkF.Text);
					}
					catch
					{
					}
				}
			}
			if (!bnabG0ArER.Macro3 && gUJb7McOB9.Macro3)
			{
				if (kjCm7BPKIA.Checked)
				{
					if (ocGmpFAaJK.Items.Count == fKgb1T8nuG.Length)
					{
						xnebTvyAOQ.Callbutton(fKgb1T8nuG[ocGmpFAaJK.SelectedIndex]);
					}
				}
				else
				{
					try
					{
						xnebTvyAOQ.Code(SGIrQcmgt97uvDTgI6P.InHOenpqO0(-644831706 ^ -644832076) + kYemqTcBDI.Text);
					}
					catch
					{
					}
				}
			}
			if (!bnabG0ArER.Macro4 && gUJb7McOB9.Macro4)
			{
				if (vEtmF4A4wm.Checked)
				{
					if (OKWmno7guW.Items.Count == fKgb1T8nuG.Length)
					{
						xnebTvyAOQ.Callbutton(fKgb1T8nuG[OKWmno7guW.SelectedIndex]);
					}
				}
				else
				{
					try
					{
						xnebTvyAOQ.Code(SGIrQcmgt97uvDTgI6P.InHOenpqO0(0x74327B00 ^ 0x74327992) + Y22mm3reOe.Text);
					}
					catch
					{
					}
				}
			}
			if (!bnabG0ArER.Macro5 && gUJb7McOB9.Macro5)
			{
				if (q3wm40oMBr.Checked)
				{
					if (JfFmHevaoo.Items.Count == fKgb1T8nuG.Length)
					{
						xnebTvyAOQ.Callbutton(fKgb1T8nuG[JfFmHevaoo.SelectedIndex]);
					}
				}
				else
				{
					try
					{
						xnebTvyAOQ.Code(SGIrQcmgt97uvDTgI6P.InHOenpqO0(--874242767 ^ 0x341BE05D) + ctlmbK54hi.Text);
					}
					catch
					{
					}
				}
			}
			if (!bnabG0ArER.Macro6 && gUJb7McOB9.Macro6)
			{
				if (LUImhwSclU.Checked)
				{
					if (gINmM2fk89.Items.Count == fKgb1T8nuG.Length)
					{
						xnebTvyAOQ.Callbutton(fKgb1T8nuG[gINmM2fk89.SelectedIndex]);
					}
				}
				else
				{
					try
					{
						xnebTvyAOQ.Code(SGIrQcmgt97uvDTgI6P.InHOenpqO0(-429223925 ^ -429223271) + XZamxMrGIy.Text);
					}
					catch
					{
					}
				}
			}
			if (!bnabG0ArER.Macro7 && gUJb7McOB9.Macro7)
			{
				if (kWwm802q8H.Checked)
				{
					if (RMTmfGCqEE.Items.Count == fKgb1T8nuG.Length)
					{
						xnebTvyAOQ.Callbutton(fKgb1T8nuG[RMTmfGCqEE.SelectedIndex]);
					}
				}
				else
				{
					try
					{
						xnebTvyAOQ.Code(SGIrQcmgt97uvDTgI6P.InHOenpqO0(-1251800226 ^ -1251800628) + wgBmdev3Ll.Text);
					}
					catch
					{
					}
				}
			}
			if (!bnabG0ArER.Macro8 && gUJb7McOB9.Macro8)
			{
				if (o0mboTi7X3.Checked)
				{
					if (Jylb9kP3d7.Items.Count == fKgb1T8nuG.Length)
					{
						xnebTvyAOQ.Callbutton(fKgb1T8nuG[Jylb9kP3d7.SelectedIndex]);
					}
				}
				else
				{
					try
					{
						xnebTvyAOQ.Code(SGIrQcmgt97uvDTgI6P.InHOenpqO0(0x76C85970 ^ 0x76C85BE2) + Mldbt8Zqt4.Text);
					}
					catch
					{
					}
				}
			}
			if (!bnabG0ArER.Macro9 && gUJb7McOB9.Macro9)
			{
				if (YLDbXSHZ1K.Checked)
				{
					if (R18bK9ookx.Items.Count == fKgb1T8nuG.Length)
					{
						xnebTvyAOQ.Callbutton(fKgb1T8nuG[R18bK9ookx.SelectedIndex]);
					}
				}
				else
				{
					try
					{
						xnebTvyAOQ.Code(SGIrQcmgt97uvDTgI6P.InHOenpqO0(0x68882BB9 ^ 0x6888292B) + XeWbVIdjce.Text);
					}
					catch
					{
					}
				}
			}
			if (bnabG0ArER.Macro10 || !gUJb7McOB9.Macro10)
			{
				return;
			}
			if (xwkb6SHMUC.Checked)
			{
				if (qXpb2LOPqX.Items.Count == fKgb1T8nuG.Length)
				{
					xnebTvyAOQ.Callbutton(fKgb1T8nuG[qXpb2LOPqX.SelectedIndex]);
				}
				return;
			}
			try
			{
				xnebTvyAOQ.Code(SGIrQcmgt97uvDTgI6P.InHOenpqO0(0x4A7956E4 ^ 0x4A795476) + zZgbIH7xFN.Text);
			}
			catch
			{
			}
		}

		private void iRN23cHbx(object _0020, EventArgs _0020)
		{
		}//Discarded unreachable code: IL_0002


		public void LoadParam()
		{
			//Discarded unreachable code: IL_0002
			List<Entry.Functionproperties> list = xnebTvyAOQ.Getbuttonsdescriptions();
			Array.Resize(ref fKgb1T8nuG, list.Count);
			for (int i = 0; i < list.Count; i++)
			{
				fKgb1T8nuG[i] = list[i].functioncode;
				VQ9mRoWWfE.Items.Add(list[i].functiondescription);
				GYVmykrvxI.Items.Add(list[i].functiondescription);
				ocGmpFAaJK.Items.Add(list[i].functiondescription);
				OKWmno7guW.Items.Add(list[i].functiondescription);
				JfFmHevaoo.Items.Add(list[i].functiondescription);
				gINmM2fk89.Items.Add(list[i].functiondescription);
				RMTmfGCqEE.Items.Add(list[i].functiondescription);
				Jylb9kP3d7.Items.Add(list[i].functiondescription);
				R18bK9ookx.Items.Add(list[i].functiondescription);
				qXpb2LOPqX.Items.Add(list[i].functiondescription);
			}
			VQ9mRoWWfE.SelectedIndex = 0;
			GYVmykrvxI.SelectedIndex = 0;
			ocGmpFAaJK.SelectedIndex = 0;
			OKWmno7guW.SelectedIndex = 0;
			JfFmHevaoo.SelectedIndex = 0;
			gINmM2fk89.SelectedIndex = 0;
			RMTmfGCqEE.SelectedIndex = 0;
			Jylb9kP3d7.SelectedIndex = 0;
			R18bK9ookx.SelectedIndex = 0;
			qXpb2LOPqX.SelectedIndex = 0;
			X0UmTTKfnQ.SelectedIndex = 0;
			try
			{
				MPGFilter = Convert.ToInt32(xnebTvyAOQ.Readkey(SGIrQcmgt97uvDTgI6P.InHOenpqO0(-1429533589 ^ -1429532941), SGIrQcmgt97uvDTgI6P.InHOenpqO0(0x4D697BA4 ^ 0x4D697902), SGIrQcmgt97uvDTgI6P.InHOenpqO0(0x6A204D50 ^ 0x6A204FE6)));
				if (MPGFilter < 0)
				{
					MPGFilter = 0;
				}
				if (MPGFilter > 25)
				{
					MPGFilter = 25;
				}
				X0UmTTKfnQ.SelectedIndex = MPGFilter;
				string s = xnebTvyAOQ.Readkey(SGIrQcmgt97uvDTgI6P.InHOenpqO0(-320687442 ^ -320688074), SGIrQcmgt97uvDTgI6P.InHOenpqO0(-1484701502 ^ -1484701058), SGIrQcmgt97uvDTgI6P.InHOenpqO0(0x5F8C08DA ^ 0x5F8C0A04));
				double result = 0.0;
				if (double.TryParse(s, out result))
				{
					MPGSpeedMultiplier = result;
				}
				else
				{
					result = 5.0;
					MessageBox.Show(SGIrQcmgt97uvDTgI6P.InHOenpqO0(0x7C1D8C67 ^ 0x7C1D8E81));
				}
				if (result < 0.001)
				{
					result = 0.001;
				}
				if (result > 25.0)
				{
					result = 25.0;
				}
				MPGSpeedMultiplier = result;
				dZ9mWckw4V.Text = MPGSpeedMultiplier.ToString();
				s = xnebTvyAOQ.Readkey(SGIrQcmgt97uvDTgI6P.InHOenpqO0(-1420261768 ^ -1420262176), SGIrQcmgt97uvDTgI6P.InHOenpqO0(0x78B1E17 ^ 0x78B1D81), SGIrQcmgt97uvDTgI6P.InHOenpqO0(0x263FA100 ^ 0x263FA2A6));
				if (s == "")
				{
					s = SGIrQcmgt97uvDTgI6P.InHOenpqO0(-259352232 ^ -259351810);
				}
				C6fmeRiJ10.Text = s;
				s = xnebTvyAOQ.Readkey(SGIrQcmgt97uvDTgI6P.InHOenpqO0(0x2AB63FB2 ^ 0x2AB63D2A), SGIrQcmgt97uvDTgI6P.InHOenpqO0(-295321864 ^ -295322296), SGIrQcmgt97uvDTgI6P.InHOenpqO0(-295321864 ^ -295322274));
				if (s == "")
				{
					s = SGIrQcmgt97uvDTgI6P.InHOenpqO0(-559005114 ^ -559005216);
				}
				HI9mYBsjkF.Text = s;
				s = xnebTvyAOQ.Readkey(SGIrQcmgt97uvDTgI6P.InHOenpqO0(-39008884 ^ -39008492), SGIrQcmgt97uvDTgI6P.InHOenpqO0(-548021409 ^ -548022113), SGIrQcmgt97uvDTgI6P.InHOenpqO0(-403980296 ^ -403981218));
				if (s == "")
				{
					s = SGIrQcmgt97uvDTgI6P.InHOenpqO0(--1951529289 ^ 0x7451FAEF);
				}
				kYemqTcBDI.Text = s;
				s = xnebTvyAOQ.Readkey(SGIrQcmgt97uvDTgI6P.InHOenpqO0(0x7F29E0FB ^ 0x7F29E263), SGIrQcmgt97uvDTgI6P.InHOenpqO0(0x78B1E17 ^ 0x78B1DC7), SGIrQcmgt97uvDTgI6P.InHOenpqO0(0x5D5C141C ^ 0x5D5C17BA));
				if (s == "")
				{
					s = SGIrQcmgt97uvDTgI6P.InHOenpqO0(-708915048 ^ -708914370);
				}
				Y22mm3reOe.Text = s;
				s = xnebTvyAOQ.Readkey(SGIrQcmgt97uvDTgI6P.InHOenpqO0(-1251800226 ^ -1251800634), SGIrQcmgt97uvDTgI6P.InHOenpqO0(0x4F791E58 ^ 0x4F791DB8), SGIrQcmgt97uvDTgI6P.InHOenpqO0(-212200409 ^ -212199551));
				if (s == "")
				{
					s = SGIrQcmgt97uvDTgI6P.InHOenpqO0(0x54D84440 ^ 0x54D847E6);
				}
				ctlmbK54hi.Text = s;
				s = xnebTvyAOQ.Readkey(SGIrQcmgt97uvDTgI6P.InHOenpqO0(0x12BE7EBF ^ 0x12BE7C27), SGIrQcmgt97uvDTgI6P.InHOenpqO0(0x4EE059C0 ^ 0x4EE05A30), SGIrQcmgt97uvDTgI6P.InHOenpqO0(-439072256 ^ -439072346));
				if (s == "")
				{
					s = SGIrQcmgt97uvDTgI6P.InHOenpqO0(0x475293C ^ 0x4752A9A);
				}
				XZamxMrGIy.Text = s;
				s = xnebTvyAOQ.Readkey(SGIrQcmgt97uvDTgI6P.InHOenpqO0(0x43D3ACC8 ^ 0x43D3AE50), SGIrQcmgt97uvDTgI6P.InHOenpqO0(0x4BC9F336 ^ 0x4BC9F736), SGIrQcmgt97uvDTgI6P.InHOenpqO0(-476989957 ^ -476989859));
				if (s == "")
				{
					s = SGIrQcmgt97uvDTgI6P.InHOenpqO0(0x12BE7EBF ^ 0x12BE7D19);
				}
				wgBmdev3Ll.Text = s;
				s = xnebTvyAOQ.Readkey(SGIrQcmgt97uvDTgI6P.InHOenpqO0(-23011901 ^ -23011493), SGIrQcmgt97uvDTgI6P.InHOenpqO0(0x1E446DCB ^ 0x1E4469DB), SGIrQcmgt97uvDTgI6P.InHOenpqO0(--300629843 ^ 0x11EB3CF5));
				if (s == "")
				{
					s = SGIrQcmgt97uvDTgI6P.InHOenpqO0(0x4BC9F336 ^ 0x4BC9F090);
				}
				Mldbt8Zqt4.Text = s;
				s = xnebTvyAOQ.Readkey(SGIrQcmgt97uvDTgI6P.InHOenpqO0(-407835460 ^ -407835100), SGIrQcmgt97uvDTgI6P.InHOenpqO0(0x6F291957 ^ 0x6F291D77), SGIrQcmgt97uvDTgI6P.InHOenpqO0(-1139029737 ^ -1139029327));
				if (s == "")
				{
					s = SGIrQcmgt97uvDTgI6P.InHOenpqO0(0x49D0EFA6 ^ 0x49D0EC00);
				}
				XeWbVIdjce.Text = s;
				s = xnebTvyAOQ.Readkey(SGIrQcmgt97uvDTgI6P.InHOenpqO0(-403980296 ^ -403980960), SGIrQcmgt97uvDTgI6P.InHOenpqO0(-1420261768 ^ -1420262840), SGIrQcmgt97uvDTgI6P.InHOenpqO0(0x7C1D8C67 ^ 0x7C1D8FC1));
				if (s == "")
				{
					s = SGIrQcmgt97uvDTgI6P.InHOenpqO0(--429991535 ^ 0x19A125C9);
				}
				zZgbIH7xFN.Text = s;
				if (Convert.ToBoolean(xnebTvyAOQ.Readkey(SGIrQcmgt97uvDTgI6P.InHOenpqO0(-10389363 ^ -10388971), SGIrQcmgt97uvDTgI6P.InHOenpqO0(0x71C79B4C ^ 0x71C79F0E), SGIrQcmgt97uvDTgI6P.InHOenpqO0(--429991535 ^ 0x19A12201))))
				{
					fVfz2CMw3(this, new EventArgs());
				}
				else
				{
					K8lb5vBEAM(this, new EventArgs());
				}
				if (Convert.ToBoolean(xnebTvyAOQ.Readkey(SGIrQcmgt97uvDTgI6P.InHOenpqO0(0x78B1E17 ^ 0x78B1C8F), SGIrQcmgt97uvDTgI6P.InHOenpqO0(-476989957 ^ -476991103), SGIrQcmgt97uvDTgI6P.InHOenpqO0(-992444272 ^ -992443138))))
				{
					bGjbbFh5ck(this, new EventArgs());
				}
				else
				{
					tMEbmpD2C3(this, new EventArgs());
				}
				if (Convert.ToBoolean(xnebTvyAOQ.Readkey(SGIrQcmgt97uvDTgI6P.InHOenpqO0(--874242767 ^ 0x341BE057), SGIrQcmgt97uvDTgI6P.InHOenpqO0(--429991535 ^ 0x19A122C9), SGIrQcmgt97uvDTgI6P.InHOenpqO0(0x50AD665B ^ 0x50AD6235))))
				{
					Gw7bOxhH6c(this, new EventArgs());
				}
				else
				{
					cP2bQlSeTG(this, new EventArgs());
				}
				if (Convert.ToBoolean(xnebTvyAOQ.Readkey(SGIrQcmgt97uvDTgI6P.InHOenpqO0(-883650111 ^ -883649703), SGIrQcmgt97uvDTgI6P.InHOenpqO0(-476989957 ^ -476991191), SGIrQcmgt97uvDTgI6P.InHOenpqO0(-476989957 ^ -476991083))))
				{
					anHbSoOlV9(this, new EventArgs());
				}
				else
				{
					Tkdbql3lee(this, new EventArgs());
				}
				if (Convert.ToBoolean(xnebTvyAOQ.Readkey(SGIrQcmgt97uvDTgI6P.InHOenpqO0(-403980296 ^ -403980960), SGIrQcmgt97uvDTgI6P.InHOenpqO0(0x6F291957 ^ 0x6F291DA9), SGIrQcmgt97uvDTgI6P.InHOenpqO0(--300629843 ^ 0x11EB3B3D))))
				{
					aCebsXkoRS(this, new EventArgs());
				}
				else
				{
					nQxbYsbkkb(this, new EventArgs());
				}
				if (Convert.ToBoolean(xnebTvyAOQ.Readkey(SGIrQcmgt97uvDTgI6P.InHOenpqO0(-1764764966 ^ -1764765630), SGIrQcmgt97uvDTgI6P.InHOenpqO0(--520036851 ^ 0x1EFF24D9), SGIrQcmgt97uvDTgI6P.InHOenpqO0(-1787266801 ^ -1787265695))))
				{
					lCWbHeXPea(this, new EventArgs());
				}
				else
				{
					B9WbnNPtnh(this, new EventArgs());
				}
				if (Convert.ToBoolean(xnebTvyAOQ.Readkey(SGIrQcmgt97uvDTgI6P.InHOenpqO0(0x2944AFE7 ^ 0x2944AD7F), SGIrQcmgt97uvDTgI6P.InHOenpqO0(0x50AD665B ^ 0x50AD630D), SGIrQcmgt97uvDTgI6P.InHOenpqO0(0x475293C ^ 0x4752D52))))
				{
					HWWb4iDDfA(this, new EventArgs());
				}
				else
				{
					N5UbFqx9wM(this, new EventArgs());
				}
				if (Convert.ToBoolean(xnebTvyAOQ.Readkey(SGIrQcmgt97uvDTgI6P.InHOenpqO0(-1301707872 ^ -1301708488), SGIrQcmgt97uvDTgI6P.InHOenpqO0(0x40198C91 ^ 0x40198913), SGIrQcmgt97uvDTgI6P.InHOenpqO0(-403980296 ^ -403981418))))
				{
					tGIb3G5u2f(this, new EventArgs());
				}
				else
				{
					gDTbefCRoM(this, new EventArgs());
				}
				if (Convert.ToBoolean(xnebTvyAOQ.Readkey(SGIrQcmgt97uvDTgI6P.InHOenpqO0(0x17C7A9C4 ^ 0x17C7AB5C), SGIrQcmgt97uvDTgI6P.InHOenpqO0(-2059087340 ^ -2059085894), SGIrQcmgt97uvDTgI6P.InHOenpqO0(--520036851 ^ 0x1EFF259D))))
				{
					arqbd6GJG4(this, new EventArgs());
				}
				else
				{
					e8wbEdSqy1(this, new EventArgs());
				}
				if (Convert.ToBoolean(xnebTvyAOQ.Readkey(SGIrQcmgt97uvDTgI6P.InHOenpqO0(0x3526A9D6 ^ 0x3526AB4E), SGIrQcmgt97uvDTgI6P.InHOenpqO0(0x68882BB9 ^ 0x68882E63), SGIrQcmgt97uvDTgI6P.InHOenpqO0(0x6AD7164D ^ 0x6AD71223))))
				{
					DLnbx56a7J(this, new EventArgs());
				}
				else
				{
					PWybN0cWvW(this, new EventArgs());
				}
				string value = xnebTvyAOQ.Readkey(SGIrQcmgt97uvDTgI6P.InHOenpqO0(-1349070334 ^ -1349070694), SGIrQcmgt97uvDTgI6P.InHOenpqO0(-804019520 ^ -804019000), SGIrQcmgt97uvDTgI6P.InHOenpqO0(-188556840 ^ -188555280));
				VQ9mRoWWfE.SelectedIndex = Convert.ToInt32(value);
				string value2 = xnebTvyAOQ.Readkey(SGIrQcmgt97uvDTgI6P.InHOenpqO0(-559005114 ^ -559005474), SGIrQcmgt97uvDTgI6P.InHOenpqO0(0x4888141E ^ 0x48881230), SGIrQcmgt97uvDTgI6P.InHOenpqO0(0x6593139F ^ 0x659315B7));
				GYVmykrvxI.SelectedIndex = Convert.ToInt32(value2);
				string value3 = xnebTvyAOQ.Readkey(SGIrQcmgt97uvDTgI6P.InHOenpqO0(0xBEB1C64 ^ 0xBEB1EFC), SGIrQcmgt97uvDTgI6P.InHOenpqO0(-798949530 ^ -798951128), SGIrQcmgt97uvDTgI6P.InHOenpqO0(-236709298 ^ -236708762));
				ocGmpFAaJK.SelectedIndex = Convert.ToInt32(value3);
				string value4 = xnebTvyAOQ.Readkey(SGIrQcmgt97uvDTgI6P.InHOenpqO0(--874242767 ^ 0x341BE057), SGIrQcmgt97uvDTgI6P.InHOenpqO0(-446893345 ^ -446892879), SGIrQcmgt97uvDTgI6P.InHOenpqO0(0x718CB4E ^ 0x718CD66));
				OKWmno7guW.SelectedIndex = Convert.ToInt32(value4);
				string value5 = xnebTvyAOQ.Readkey(SGIrQcmgt97uvDTgI6P.InHOenpqO0(-9234614 ^ -9234990), SGIrQcmgt97uvDTgI6P.InHOenpqO0(0x55C3063 ^ 0x55C36ED), SGIrQcmgt97uvDTgI6P.InHOenpqO0(-508791245 ^ -508792805));
				JfFmHevaoo.SelectedIndex = Convert.ToInt32(value5);
				string value6 = xnebTvyAOQ.Readkey(SGIrQcmgt97uvDTgI6P.InHOenpqO0(-1139029737 ^ -1139029105), SGIrQcmgt97uvDTgI6P.InHOenpqO0(-644831706 ^ -644833144), SGIrQcmgt97uvDTgI6P.InHOenpqO0(0x4D697BA4 ^ 0x4D697D8C));
				gINmM2fk89.SelectedIndex = Convert.ToInt32(value6);
				string value7 = xnebTvyAOQ.Readkey(SGIrQcmgt97uvDTgI6P.InHOenpqO0(0xBEB1C64 ^ 0xBEB1EFC), SGIrQcmgt97uvDTgI6P.InHOenpqO0(--429991535 ^ 0x19A120A1), SGIrQcmgt97uvDTgI6P.InHOenpqO0(0x74327B00 ^ 0x74327D28));
				RMTmfGCqEE.SelectedIndex = Convert.ToInt32(value7);
				string value8 = xnebTvyAOQ.Readkey(SGIrQcmgt97uvDTgI6P.InHOenpqO0(-1290596360 ^ -1290597024), SGIrQcmgt97uvDTgI6P.InHOenpqO0(-281721232 ^ -281722722), SGIrQcmgt97uvDTgI6P.InHOenpqO0(0x4C5125B5 ^ 0x4C51239D));
				Jylb9kP3d7.SelectedIndex = Convert.ToInt32(value8);
				string value9 = xnebTvyAOQ.Readkey(SGIrQcmgt97uvDTgI6P.InHOenpqO0(-528050159 ^ -528049527), SGIrQcmgt97uvDTgI6P.InHOenpqO0(0x74327B00 ^ 0x74327C0E), SGIrQcmgt97uvDTgI6P.InHOenpqO0(-1699964154 ^ -1699963602));
				R18bK9ookx.SelectedIndex = Convert.ToInt32(value9);
				string value10 = xnebTvyAOQ.Readkey(SGIrQcmgt97uvDTgI6P.InHOenpqO0(0x1D7D9F95 ^ 0x1D7D9D0D), SGIrQcmgt97uvDTgI6P.InHOenpqO0(-734611327 ^ -734609489), SGIrQcmgt97uvDTgI6P.InHOenpqO0(0x6F291957 ^ 0x6F291F7F));
				qXpb2LOPqX.SelectedIndex = Convert.ToInt32(value10);
				gXpmaknpZT.Checked = bool.Parse(xnebTvyAOQ.Readkey(SGIrQcmgt97uvDTgI6P.InHOenpqO0(-883650111 ^ -883649703), SGIrQcmgt97uvDTgI6P.InHOenpqO0(-403980296 ^ -403982168), SGIrQcmgt97uvDTgI6P.InHOenpqO0(-528393286 ^ -528393014)));
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}

		public void SaveParam()
		{
			try
			{
				string value = MPGFilter.ToString();
				xnebTvyAOQ.Writekey(SGIrQcmgt97uvDTgI6P.InHOenpqO0(-11375094 ^ -11375470), SGIrQcmgt97uvDTgI6P.InHOenpqO0(0x4FB9E673 ^ 0x4FB9E4D5), value);
				if (MPGSpeedMultiplier < 0.0 || MPGSpeedMultiplier > 25.0)
				{
					MPGSpeedMultiplier = 5.0;
				}
				string value2 = MPGSpeedMultiplier.ToString();
				xnebTvyAOQ.Writekey(SGIrQcmgt97uvDTgI6P.InHOenpqO0(-1988417526 ^ -1988416878), SGIrQcmgt97uvDTgI6P.InHOenpqO0(-39008884 ^ -39008464), value2);
				xnebTvyAOQ.Writekey(SGIrQcmgt97uvDTgI6P.InHOenpqO0(0x6F3EE3C9 ^ 0x6F3EE151), SGIrQcmgt97uvDTgI6P.InHOenpqO0(-798949530 ^ -798950160), C6fmeRiJ10.Text);
				xnebTvyAOQ.Writekey(SGIrQcmgt97uvDTgI6P.InHOenpqO0(0x6AD7164D ^ 0x6AD714D5), SGIrQcmgt97uvDTgI6P.InHOenpqO0(-543846006 ^ -543845830), HI9mYBsjkF.Text);
				xnebTvyAOQ.Writekey(SGIrQcmgt97uvDTgI6P.InHOenpqO0(-1429533589 ^ -1429532941), SGIrQcmgt97uvDTgI6P.InHOenpqO0(0x6BD6822 ^ 0x6BD6BE2), kYemqTcBDI.Text);
				xnebTvyAOQ.Writekey(SGIrQcmgt97uvDTgI6P.InHOenpqO0(0x263FA100 ^ 0x263FA398), SGIrQcmgt97uvDTgI6P.InHOenpqO0(0x5CEF7519 ^ 0x5CEF76C9), Y22mm3reOe.Text);
				xnebTvyAOQ.Writekey(SGIrQcmgt97uvDTgI6P.InHOenpqO0(-528050159 ^ -528049527), SGIrQcmgt97uvDTgI6P.InHOenpqO0(-1543606119 ^ -1543605383), ctlmbK54hi.Text);
				xnebTvyAOQ.Writekey(SGIrQcmgt97uvDTgI6P.InHOenpqO0(0x4888141E ^ 0x48881686), SGIrQcmgt97uvDTgI6P.InHOenpqO0(-1988417526 ^ -1988416518), XZamxMrGIy.Text);
				xnebTvyAOQ.Writekey(SGIrQcmgt97uvDTgI6P.InHOenpqO0(-51230102 ^ -51230478), SGIrQcmgt97uvDTgI6P.InHOenpqO0(0x4EE059C0 ^ 0x4EE05DC0), wgBmdev3Ll.Text);
				xnebTvyAOQ.Writekey(SGIrQcmgt97uvDTgI6P.InHOenpqO0(-292836720 ^ -292837368), SGIrQcmgt97uvDTgI6P.InHOenpqO0(0x51F60F79 ^ 0x51F60B69), Mldbt8Zqt4.Text);
				xnebTvyAOQ.Writekey(SGIrQcmgt97uvDTgI6P.InHOenpqO0(-1693174992 ^ -1693175384), SGIrQcmgt97uvDTgI6P.InHOenpqO0(-692479268 ^ -692478212), XeWbVIdjce.Text);
				xnebTvyAOQ.Writekey(SGIrQcmgt97uvDTgI6P.InHOenpqO0(-1133012468 ^ -1133012844), SGIrQcmgt97uvDTgI6P.InHOenpqO0(0x29B3A14 ^ 0x29B3E24), zZgbIH7xFN.Text);
				xnebTvyAOQ.Writekey(SGIrQcmgt97uvDTgI6P.InHOenpqO0(0x5D5C141C ^ 0x5D5C1684), SGIrQcmgt97uvDTgI6P.InHOenpqO0(0x4EE059C0 ^ 0x4EE05D82), bJNmu7IdXZ.Checked.ToString());
				xnebTvyAOQ.Writekey(SGIrQcmgt97uvDTgI6P.InHOenpqO0(-883650111 ^ -883649703), SGIrQcmgt97uvDTgI6P.InHOenpqO0(0x51F60F79 ^ 0x51F60B03), BebmGxuFru.Checked.ToString());
				xnebTvyAOQ.Writekey(SGIrQcmgt97uvDTgI6P.InHOenpqO0(0x54D84440 ^ 0x54D846D8), SGIrQcmgt97uvDTgI6P.InHOenpqO0(-292836720 ^ -292835786), kjCm7BPKIA.Checked.ToString());
				xnebTvyAOQ.Writekey(SGIrQcmgt97uvDTgI6P.InHOenpqO0(0x7577541B ^ 0x75775683), SGIrQcmgt97uvDTgI6P.InHOenpqO0(0x76C85970 ^ 0x76C85DA2), vEtmF4A4wm.Checked.ToString());
				xnebTvyAOQ.Writekey(SGIrQcmgt97uvDTgI6P.InHOenpqO0(-1508183274 ^ -1508183666), SGIrQcmgt97uvDTgI6P.InHOenpqO0(0x71C79B4C ^ 0x71C79FB2), q3wm40oMBr.Checked.ToString());
				xnebTvyAOQ.Writekey(SGIrQcmgt97uvDTgI6P.InHOenpqO0(-212200409 ^ -212199745), SGIrQcmgt97uvDTgI6P.InHOenpqO0(0x1E446DCB ^ 0x1E4468E1), LUImhwSclU.Checked.ToString());
				xnebTvyAOQ.Writekey(SGIrQcmgt97uvDTgI6P.InHOenpqO0(0x6BD6822 ^ 0x6BD6ABA), SGIrQcmgt97uvDTgI6P.InHOenpqO0(-1787266801 ^ -1787265959), kWwm802q8H.Checked.ToString());
				xnebTvyAOQ.Writekey(SGIrQcmgt97uvDTgI6P.InHOenpqO0(0x4BC9F336 ^ 0x4BC9F1AE), SGIrQcmgt97uvDTgI6P.InHOenpqO0(-798949530 ^ -798950684), o0mboTi7X3.Checked.ToString());
				xnebTvyAOQ.Writekey(SGIrQcmgt97uvDTgI6P.InHOenpqO0(-1996091808 ^ -1996092168), SGIrQcmgt97uvDTgI6P.InHOenpqO0(0x18BCCD25 ^ 0x18BCC88B), YLDbXSHZ1K.Checked.ToString());
				xnebTvyAOQ.Writekey(SGIrQcmgt97uvDTgI6P.InHOenpqO0(0x1E446DCB ^ 0x1E446F53), SGIrQcmgt97uvDTgI6P.InHOenpqO0(0x4086BCF4 ^ 0x4086B92E), xwkb6SHMUC.Checked.ToString());
				xnebTvyAOQ.Writekey(SGIrQcmgt97uvDTgI6P.InHOenpqO0(-543846006 ^ -543845614), SGIrQcmgt97uvDTgI6P.InHOenpqO0(0x54D84440 ^ 0x54D84248), Convert.ToString(VQ9mRoWWfE.SelectedIndex));
				xnebTvyAOQ.Writekey(SGIrQcmgt97uvDTgI6P.InHOenpqO0(0x7F29E0FB ^ 0x7F29E263), SGIrQcmgt97uvDTgI6P.InHOenpqO0(-16739846 ^ -16738348), Convert.ToString(GYVmykrvxI.SelectedIndex));
				xnebTvyAOQ.Writekey(SGIrQcmgt97uvDTgI6P.InHOenpqO0(0x58864335 ^ 0x588641AD), SGIrQcmgt97uvDTgI6P.InHOenpqO0(-16739846 ^ -16738380), Convert.ToString(ocGmpFAaJK.SelectedIndex));
				xnebTvyAOQ.Writekey(SGIrQcmgt97uvDTgI6P.InHOenpqO0(0x4C5125B5 ^ 0x4C51272D), SGIrQcmgt97uvDTgI6P.InHOenpqO0(-955479080 ^ -955478602), Convert.ToString(OKWmno7guW.SelectedIndex));
				xnebTvyAOQ.Writekey(SGIrQcmgt97uvDTgI6P.InHOenpqO0(0x496B5A49 ^ 0x496B58D1), SGIrQcmgt97uvDTgI6P.InHOenpqO0(0x2EE19E9B ^ 0x2EE19815), Convert.ToString(JfFmHevaoo.SelectedIndex));
				xnebTvyAOQ.Writekey(SGIrQcmgt97uvDTgI6P.InHOenpqO0(-2059087340 ^ -2059087732), SGIrQcmgt97uvDTgI6P.InHOenpqO0(-1301707872 ^ -1301707506), Convert.ToString(gINmM2fk89.SelectedIndex));
				xnebTvyAOQ.Writekey(SGIrQcmgt97uvDTgI6P.InHOenpqO0(0x62429C89 ^ 0x62429E11), SGIrQcmgt97uvDTgI6P.InHOenpqO0(-1251800226 ^ -1251799664), Convert.ToString(RMTmfGCqEE.SelectedIndex));
				xnebTvyAOQ.Writekey(SGIrQcmgt97uvDTgI6P.InHOenpqO0(--1998319630 ^ 0x771BF296), SGIrQcmgt97uvDTgI6P.InHOenpqO0(0x4086BCF4 ^ 0x4086BA1A), Convert.ToString(Jylb9kP3d7.SelectedIndex));
				xnebTvyAOQ.Writekey(SGIrQcmgt97uvDTgI6P.InHOenpqO0(-429223925 ^ -429223277), SGIrQcmgt97uvDTgI6P.InHOenpqO0(-1009634455 ^ -1009634201), Convert.ToString(R18bK9ookx.SelectedIndex));
				xnebTvyAOQ.Writekey(SGIrQcmgt97uvDTgI6P.InHOenpqO0(-2146361446 ^ -2146362110), SGIrQcmgt97uvDTgI6P.InHOenpqO0(-117603921 ^ -117602687), Convert.ToString(qXpb2LOPqX.SelectedIndex));
				xnebTvyAOQ.Writekey(SGIrQcmgt97uvDTgI6P.InHOenpqO0(0x31FDEB81 ^ 0x31FDE919), SGIrQcmgt97uvDTgI6P.InHOenpqO0(0x191AA1F1 ^ 0x191AA6A1), Convert.ToString(gXpmaknpZT.Checked));
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}

		public void MPGEvent()
		{
			//Discarded unreachable code: IL_0002
			if (KeyTime == 1 || xnebTvyAOQ.GetLED(236))
			{
				xnebTvyAOQ.MPGJogOff(0);
			}
			if (KeyTime != 0)
			{
				KeyTime--;
			}
			if (tA0bcXfa88 == 1 || tA0bcXfa88 == 2 || tA0bcXfa88 == 3 || tA0bcXfa88 == 4 || tA0bcXfa88 == 5 || tA0bcXfa88 == 6)
			{
				int num = 0;
				if (xnebTvyAOQ.GetLED(155))
				{
					num = 0;
				}
				if (xnebTvyAOQ.GetLED(156))
				{
					num = 1;
				}
				if (xnebTvyAOQ.GetLED(157))
				{
					num = 2;
				}
				if (xnebTvyAOQ.GetLED(158))
				{
					num = 3;
				}
				if (xnebTvyAOQ.GetLED(159))
				{
					num = 4;
				}
				if (xnebTvyAOQ.GetLED(160))
				{
					num = 5;
				}
				oJjblAMHSQ = num;
				if (xnebTvyAOQ.GetLED(152))
				{
					bool flag = false;
					int num2 = 0;
					MPG = nlHbpVvlo6 - Y1JbMv8qwH;
					tmAbybR6so++;
					if (tmAbybR6so >= MPGFilter || tmAbybR6so > 25)
					{
						tmAbybR6so = 0;
					}
					LcabRmTEUe[tmAbybR6so] = MPG;
					if (MPGFilter > 1)
					{
						oWcbuNLLed = 0;
						for (num2 = 0; num2 < MPGFilter; num2++)
						{
							oWcbuNLLed += LcabRmTEUe[num2];
						}
						t8BbhdSDhT = (double)oWcbuNLLed / (double)MPGFilter;
					}
					else
					{
						t8BbhdSDhT = LcabRmTEUe[0];
					}
					fkwbfUPG3J = t8BbhdSDhT * MPGSpeedMultiplier;
					fkwbfUPG3J = fkwbfUPG3J * Het67qm3q() / 100.0;
					if (fkwbfUPG3J > 100.0)
					{
						fkwbfUPG3J = 100.0;
					}
					if (fkwbfUPG3J < -100.0)
					{
						fkwbfUPG3J = -100.0;
					}
					if (fkwbfUPG3J < 0.0)
					{
						fkwbfUPG3J = Math.Abs(fkwbfUPG3J);
						flag = false;
					}
					else
					{
						flag = true;
					}
					switch (num)
					{
					case 0:
						xnebTvyAOQ.JogOnSpeed(0, flag, fkwbfUPG3J);
						xnebTvyAOQ.JogOnSpeed(1, Dir: false, 0.0);
						xnebTvyAOQ.JogOnSpeed(2, Dir: false, 0.0);
						xnebTvyAOQ.JogOnSpeed(3, Dir: false, 0.0);
						xnebTvyAOQ.JogOnSpeed(4, Dir: false, 0.0);
						xnebTvyAOQ.JogOnSpeed(5, Dir: false, 0.0);
						break;
					case 1:
						xnebTvyAOQ.JogOnSpeed(0, Dir: false, 0.0);
						xnebTvyAOQ.JogOnSpeed(1, flag, fkwbfUPG3J);
						xnebTvyAOQ.JogOnSpeed(2, Dir: false, 0.0);
						xnebTvyAOQ.JogOnSpeed(3, Dir: false, 0.0);
						xnebTvyAOQ.JogOnSpeed(4, Dir: false, 0.0);
						xnebTvyAOQ.JogOnSpeed(5, Dir: false, 0.0);
						break;
					case 2:
						xnebTvyAOQ.JogOnSpeed(0, Dir: false, 0.0);
						xnebTvyAOQ.JogOnSpeed(1, Dir: false, 0.0);
						xnebTvyAOQ.JogOnSpeed(2, flag, fkwbfUPG3J);
						xnebTvyAOQ.JogOnSpeed(3, Dir: false, 0.0);
						xnebTvyAOQ.JogOnSpeed(4, Dir: false, 0.0);
						xnebTvyAOQ.JogOnSpeed(5, Dir: false, 0.0);
						break;
					case 3:
						xnebTvyAOQ.JogOnSpeed(0, Dir: false, 0.0);
						xnebTvyAOQ.JogOnSpeed(1, Dir: false, 0.0);
						xnebTvyAOQ.JogOnSpeed(2, Dir: false, 0.0);
						xnebTvyAOQ.JogOnSpeed(3, flag, fkwbfUPG3J);
						xnebTvyAOQ.JogOnSpeed(4, Dir: false, 0.0);
						xnebTvyAOQ.JogOnSpeed(5, Dir: false, 0.0);
						break;
					case 4:
						xnebTvyAOQ.JogOnSpeed(0, Dir: false, 0.0);
						xnebTvyAOQ.JogOnSpeed(1, Dir: false, 0.0);
						xnebTvyAOQ.JogOnSpeed(2, Dir: false, 0.0);
						xnebTvyAOQ.JogOnSpeed(3, Dir: false, 0.0);
						xnebTvyAOQ.JogOnSpeed(4, flag, fkwbfUPG3J);
						xnebTvyAOQ.JogOnSpeed(5, Dir: false, 0.0);
						break;
					case 5:
						xnebTvyAOQ.JogOnSpeed(0, Dir: false, 0.0);
						xnebTvyAOQ.JogOnSpeed(1, Dir: false, 0.0);
						xnebTvyAOQ.JogOnSpeed(2, Dir: false, 0.0);
						xnebTvyAOQ.JogOnSpeed(3, Dir: false, 0.0);
						xnebTvyAOQ.JogOnSpeed(4, Dir: false, 0.0);
						xnebTvyAOQ.JogOnSpeed(5, flag, fkwbfUPG3J);
						break;
					}
				}
				if (xnebTvyAOQ.GetLED(153))
				{
					MPG = nlHbpVvlo6 - Y1JbMv8qwH;
					if (MPG > 0)
					{
						MPG = 1;
					}
					if (MPG < 0)
					{
						MPG = -1;
					}
					MPGsumma += (double)MPG * IFlX3P8Qg();
					MPG = 0;
					if (Math.Abs(MPGsumma) >= D0gK95sqc(num))
					{
						double num3 = 0.0;
						MPG = (int)((!(MPGsumma > 0.0)) ? (MPGsumma / D0gK95sqc(num) - 0.5) : (MPGsumma / D0gK95sqc(num) + 0.5));
						MPGsumma -= (double)MPG * D0gK95sqc(num);
					}
					if (bq3b8ROAwH > 0)
					{
						bq3b8ROAwH--;
					}
					if (bq3b8ROAwH == 0)
					{
						if (MPG > 0)
						{
							xnebTvyAOQ.AddLinearMoveRel(num, D0gK95sqc(num), Math.Abs(MPG), 100.0, Dir: true);
						}
						if (MPG < 0)
						{
							xnebTvyAOQ.AddLinearMoveRel(num, D0gK95sqc(num), Math.Abs(MPG), 100.0, Dir: false);
						}
					}
					if (MPG != 0)
					{
						bq3b8ROAwH = 9;
					}
				}
				if (xnebTvyAOQ.GetLED(154))
				{
					MPG = nlHbpVvlo6 - Y1JbMv8qwH;
					MPGsumma += (double)MPG * IFlX3P8Qg();
					MPG = 0;
					if (Math.Abs(MPGsumma) >= D0gK95sqc(num))
					{
						double num3 = 0.0;
						MPG = (int)((!(MPGsumma > 0.0)) ? (MPGsumma / D0gK95sqc(num) - 0.5) : (MPGsumma / D0gK95sqc(num) + 0.5));
						MPGsumma -= (double)MPG * D0gK95sqc(num);
					}
					if (MPG > 0)
					{
						xnebTvyAOQ.AddLinearMoveRel(num, D0gK95sqc(num), Math.Abs(MPG), 100.0, Dir: true);
					}
					if (MPG < 0)
					{
						xnebTvyAOQ.AddLinearMoveRel(num, D0gK95sqc(num), Math.Abs(MPG), 100.0, Dir: false);
					}
				}
			}
			else if (oJjblAMHSQ != -1)
			{
				xnebTvyAOQ.JogOnSpeed(oJjblAMHSQ, Dir: false, 0.0);
				oJjblAMHSQ = -1;
				Y1JbMv8qwH = 0;
				for (int i = 0; i < MPGFilter; i++)
				{
					LcabRmTEUe[i] = 0;
				}
			}
			nlHbpVvlo6 = Y1JbMv8qwH;
		}

		public void SendDisplayData(bool End)
		{
			try
			{
				double xpos = xnebTvyAOQ.GetXpos();
				xpos = ((!(xpos >= 0.0)) ? ((xpos * 10000.0 - 0.5) / 10000.0) : ((xpos * 10000.0 + 0.5) / 10000.0));
				double ypos = xnebTvyAOQ.GetYpos();
				ypos = ((!(ypos >= 0.0)) ? ((ypos * 10000.0 - 0.5) / 10000.0) : ((ypos * 10000.0 + 0.5) / 10000.0));
				double zpos = xnebTvyAOQ.GetZpos();
				zpos = ((!(zpos >= 0.0)) ? ((zpos * 10000.0 - 0.5) / 10000.0) : ((zpos * 10000.0 + 0.5) / 10000.0));
				double apos = xnebTvyAOQ.GetApos();
				apos = ((!(apos >= 0.0)) ? ((apos * 10000.0 - 0.5) / 10000.0) : ((apos * 10000.0 + 0.5) / 10000.0));
				double bpos = xnebTvyAOQ.GetBpos();
				bpos = ((!(bpos >= 0.0)) ? ((bpos * 10000.0 - 0.5) / 10000.0) : ((bpos * 10000.0 + 0.5) / 10000.0));
				double cpos = xnebTvyAOQ.GetCpos();
				cpos = ((!(cpos >= 0.0)) ? ((cpos * 10000.0 - 0.5) / 10000.0) : ((cpos * 10000.0 + 0.5) / 10000.0));
				if (End)
				{
					xpos = 0.0;
					ypos = 0.0;
					zpos = 0.0;
					apos = 0.0;
					bpos = 0.0;
					cpos = 0.0;
				}
				int num = (int)Math.Abs(xpos);
				int num2 = (int)((Math.Abs(xpos) - (double)(int)Math.Abs(xpos)) * 10000.0);
				if (xpos < 0.0)
				{
					num2 |= 0x8000;
				}
				int num3 = (int)Math.Abs(ypos);
				int num4 = (int)((Math.Abs(ypos) - (double)(int)Math.Abs(ypos)) * 10000.0);
				if (ypos < 0.0)
				{
					num4 |= 0x8000;
				}
				int num5 = (int)Math.Abs(zpos);
				int num6 = (int)((Math.Abs(zpos) - (double)(int)Math.Abs(zpos)) * 10000.0);
				if (zpos < 0.0)
				{
					num6 |= 0x8000;
				}
				int num7 = (int)Math.Abs(apos);
				int num8 = (int)((Math.Abs(apos) - (double)(int)Math.Abs(apos)) * 10000.0);
				if (apos < 0.0)
				{
					num8 |= 0x8000;
				}
				int num9 = (int)Math.Abs(bpos);
				int num10 = (int)((Math.Abs(bpos) - (double)(int)Math.Abs(bpos)) * 10000.0);
				if (bpos < 0.0)
				{
					num10 |= 0x8000;
				}
				int num11 = (int)Math.Abs(cpos);
				int num12 = (int)((Math.Abs(cpos) - (double)(int)Math.Abs(cpos)) * 10000.0);
				if (cpos < 0.0)
				{
					num12 |= 0x8000;
				}
				string text = xnebTvyAOQ.Getfield(isAS3: true, 232);
				int num13 = 0;
				int num14 = 0;
				try
				{
					Convert.ToInt32(text.Remove(text.Length - 1, 1));
					text = xnebTvyAOQ.Getfield(isAS3: true, 233);
					Convert.ToInt32(text.Remove(text.Length - 1, 1));
					text = xnebTvyAOQ.Getfield(isAS3: true, 867);
					num13 = Convert.ToInt32(text.Remove(text.Length - 2, 2));
					text = xnebTvyAOQ.Getfield(isAS3: true, 869);
					num14 = Convert.ToInt32(text.Remove(text.Length - 2, 2));
				}
				catch
				{
				}
				if (!xnebTvyAOQ.GetLED(151) && !xnebTvyAOQ.GetLED(150) && !xnebTvyAOQ.GetLED(149))
				{
					xnebTvyAOQ.GetLED(148);
				}
				if (!xnebTvyAOQ.GetLED(152) && !xnebTvyAOQ.GetLED(153))
				{
					xnebTvyAOQ.GetLED(154);
				}
				gcZb0ZVm8p[0] = 6;
				gcZb0ZVm8p[1] = 254;
				gcZb0ZVm8p[2] = 253;
				gcZb0ZVm8p[3] = 12;
				byte b = 0;
				if (xnebTvyAOQ.GetLED(25))
				{
					b = (byte)(b | 0x40u);
				}
				if (xnebTvyAOQ.GetLED(153))
				{
					b = (byte)(b | 1u);
				}
				gcZb0ZVm8p[4] = b;
				if (tA0bcXfa88 >= 4)
				{
					gcZb0ZVm8p[5] = (byte)((uint)num7 & 0xFFu);
					gcZb0ZVm8p[6] = (byte)(num7 >> 8);
					gcZb0ZVm8p[7] = (byte)((uint)num8 & 0xFFu);
				}
				else
				{
					gcZb0ZVm8p[5] = (byte)((uint)num & 0xFFu);
					gcZb0ZVm8p[6] = (byte)(num >> 8);
					gcZb0ZVm8p[7] = (byte)((uint)num2 & 0xFFu);
				}
				if (vZDbaMj4Ql.SpecifiedDeviceWrite != null)
				{
					vZDbaMj4Ql.SpecifiedDeviceWrite.SendData(gcZb0ZVm8p);
				}
				gcZb0ZVm8p[0] = 6;
				if (tA0bcXfa88 >= 4)
				{
					gcZb0ZVm8p[1] = (byte)(num8 >> 8);
					gcZb0ZVm8p[2] = (byte)((uint)num9 & 0xFFu);
					gcZb0ZVm8p[3] = (byte)(num9 >> 8);
					gcZb0ZVm8p[4] = (byte)((uint)num10 & 0xFFu);
					gcZb0ZVm8p[5] = (byte)(num10 >> 8);
					gcZb0ZVm8p[6] = (byte)((uint)num11 & 0xFFu);
					gcZb0ZVm8p[7] = (byte)(num11 >> 8);
				}
				else
				{
					gcZb0ZVm8p[1] = (byte)(num2 >> 8);
					gcZb0ZVm8p[2] = (byte)((uint)num3 & 0xFFu);
					gcZb0ZVm8p[3] = (byte)(num3 >> 8);
					gcZb0ZVm8p[4] = (byte)((uint)num4 & 0xFFu);
					gcZb0ZVm8p[5] = (byte)(num4 >> 8);
					gcZb0ZVm8p[6] = (byte)((uint)num5 & 0xFFu);
					gcZb0ZVm8p[7] = (byte)(num5 >> 8);
				}
				if (vZDbaMj4Ql.SpecifiedDeviceWrite != null)
				{
					vZDbaMj4Ql.SpecifiedDeviceWrite.SendData(gcZb0ZVm8p);
				}
				gcZb0ZVm8p[0] = 6;
				if (tA0bcXfa88 >= 4)
				{
					gcZb0ZVm8p[1] = (byte)((uint)num12 & 0xFFu);
					gcZb0ZVm8p[2] = (byte)(num12 >> 8);
				}
				else
				{
					gcZb0ZVm8p[1] = (byte)((uint)num6 & 0xFFu);
					gcZb0ZVm8p[2] = (byte)(num6 >> 8);
				}
				gcZb0ZVm8p[3] = (byte)((uint)num13 & 0xFFu);
				gcZb0ZVm8p[4] = (byte)(num13 >> 8);
				gcZb0ZVm8p[5] = (byte)((uint)num14 & 0xFFu);
				gcZb0ZVm8p[6] = (byte)(num14 >> 8);
				gcZb0ZVm8p[7] = (byte)((uint)num11 & 0xFFu);
				if (vZDbaMj4Ql.SpecifiedDeviceWrite != null)
				{
					vZDbaMj4Ql.SpecifiedDeviceWrite.SendData(gcZb0ZVm8p);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}

		private double D0gK95sqc(int _0020)
		{
			//Discarded unreachable code: IL_0002
			if (_0020 < 0)
			{
				_0020 = 0;
			}
			if (_0020 > 5)
			{
				_0020 = 5;
			}
			_0020 = 8 + _0020 * 15;
			return 1.0 / xnebTvyAOQ.Getfielddouble(isAS3: true, _0020);
		}

		private double Het67qm3q()
		{
			//Discarded unreachable code: IL_0002
			if (xnebTvyAOQ.GetLED(148))
			{
				return 0.1;
			}
			if (!xnebTvyAOQ.GetLED(149))
			{
				if (xnebTvyAOQ.GetLED(150))
				{
					return 10.0;
				}
				if (xnebTvyAOQ.GetLED(151))
				{
					return 100.0;
				}
			}
			return 1.0;
		}

		private double IFlX3P8Qg()
		{
			//Discarded unreachable code: IL_0002
			if (xnebTvyAOQ.GetLED(148))
			{
				return 0.001;
			}
			if (xnebTvyAOQ.GetLED(149))
			{
				return 0.01;
			}
			if (xnebTvyAOQ.GetLED(150))
			{
				return 0.1;
			}
			if (xnebTvyAOQ.GetLED(151))
			{
				return 1.0;
			}
			return xnebTvyAOQ.Getfielddouble(isAS3: false, 2027);
		}

		protected override void OnHandleCreated(EventArgs e)
		{
			//Discarded unreachable code: IL_0002
			base.OnHandleCreated(e);
			vZDbaMj4Ql.RegisterHandle(base.Handle);
		}

		protected override void WndProc(ref Message m)
		{
			//Discarded unreachable code: IL_0002
			vZDbaMj4Ql.ParseMessages(ref m);
			base.WndProc(ref m);
		}

		private void fVfz2CMw3(object _0020, EventArgs _0020)
		{
			//Discarded unreachable code: IL_0002
			bJNmu7IdXZ.Checked = true;
			YFbmPNmvji.Checked = false;
			VQ9mRoWWfE.Enabled = true;
			C6fmeRiJ10.Enabled = false;
		}

		private void K8lb5vBEAM(object _0020, EventArgs _0020)
		{
			//Discarded unreachable code: IL_0002
			bJNmu7IdXZ.Checked = false;
			YFbmPNmvji.Checked = true;
			VQ9mRoWWfE.Enabled = false;
			C6fmeRiJ10.Enabled = true;
		}

		private void bGjbbFh5ck(object _0020, EventArgs _0020)
		{
			//Discarded unreachable code: IL_0002
			BebmGxuFru.Checked = true;
			K20mjcDvgt.Checked = false;
			GYVmykrvxI.Enabled = true;
			HI9mYBsjkF.Enabled = false;
		}

		private void tMEbmpD2C3(object _0020, EventArgs _0020)
		{
			//Discarded unreachable code: IL_0002
			BebmGxuFru.Checked = false;
			K20mjcDvgt.Checked = true;
			GYVmykrvxI.Enabled = false;
			HI9mYBsjkF.Enabled = true;
		}

		private void Gw7bOxhH6c(object _0020, EventArgs _0020)
		{
			//Discarded unreachable code: IL_0002
			kjCm7BPKIA.Checked = true;
			vxKmi3AeBK.Checked = false;
			ocGmpFAaJK.Enabled = true;
			kYemqTcBDI.Enabled = false;
		}

		private void cP2bQlSeTG(object _0020, EventArgs _0020)
		{
			//Discarded unreachable code: IL_0002
			kjCm7BPKIA.Checked = false;
			vxKmi3AeBK.Checked = true;
			ocGmpFAaJK.Enabled = false;
			kYemqTcBDI.Enabled = true;
		}

		private void lCWbHeXPea(object _0020, EventArgs _0020)
		{
			//Discarded unreachable code: IL_0002
			LUImhwSclU.Checked = true;
			h6HmNQ6hc5.Checked = false;
			gINmM2fk89.Enabled = true;
			XZamxMrGIy.Enabled = false;
		}

		private void B9WbnNPtnh(object _0020, EventArgs _0020)
		{
			//Discarded unreachable code: IL_0002
			LUImhwSclU.Checked = false;
			h6HmNQ6hc5.Checked = true;
			gINmM2fk89.Enabled = false;
			XZamxMrGIy.Enabled = true;
		}

		private void HWWb4iDDfA(object _0020, EventArgs _0020)
		{
			//Discarded unreachable code: IL_0002
			kWwm802q8H.Checked = true;
			nmDmEtxprn.Checked = false;
			RMTmfGCqEE.Enabled = true;
			wgBmdev3Ll.Enabled = false;
		}

		private void N5UbFqx9wM(object _0020, EventArgs _0020)
		{
			//Discarded unreachable code: IL_0002
			kWwm802q8H.Checked = false;
			nmDmEtxprn.Checked = true;
			RMTmfGCqEE.Enabled = false;
			wgBmdev3Ll.Enabled = true;
		}

		private void anHbSoOlV9(object _0020, EventArgs _0020)
		{
			//Discarded unreachable code: IL_0002
			vEtmF4A4wm.Checked = true;
			d1TmQGDX6w.Checked = false;
			OKWmno7guW.Enabled = true;
			Y22mm3reOe.Enabled = false;
		}

		private void aCebsXkoRS(object _0020, EventArgs _0020)
		{
			//Discarded unreachable code: IL_0002
			q3wm40oMBr.Checked = true;
			MXQmOf2ifb.Checked = false;
			JfFmHevaoo.Enabled = true;
			ctlmbK54hi.Enabled = false;
		}

		private void tGIb3G5u2f(object _0020, EventArgs _0020)
		{
			//Discarded unreachable code: IL_0002
			o0mboTi7X3.Checked = true;
			FsHbLAoHPO.Checked = false;
			Jylb9kP3d7.Enabled = true;
			Mldbt8Zqt4.Enabled = false;
		}

		private void arqbd6GJG4(object _0020, EventArgs _0020)
		{
			//Discarded unreachable code: IL_0002
			YLDbXSHZ1K.Checked = true;
			E4DbgGGpcM.Checked = false;
			R18bK9ookx.Enabled = true;
			XeWbVIdjce.Enabled = false;
		}

		private void DLnbx56a7J(object _0020, EventArgs _0020)
		{
			//Discarded unreachable code: IL_0002
			xwkb6SHMUC.Checked = true;
			Qs0bJKaFBw.Checked = false;
			qXpb2LOPqX.Enabled = true;
			zZgbIH7xFN.Enabled = false;
		}

		private void Tkdbql3lee(object _0020, EventArgs _0020)
		{
			//Discarded unreachable code: IL_0002
			vEtmF4A4wm.Checked = false;
			d1TmQGDX6w.Checked = true;
			OKWmno7guW.Enabled = false;
			Y22mm3reOe.Enabled = true;
		}

		private void nQxbYsbkkb(object _0020, EventArgs _0020)
		{
			//Discarded unreachable code: IL_0002
			q3wm40oMBr.Checked = false;
			MXQmOf2ifb.Checked = true;
			JfFmHevaoo.Enabled = false;
			ctlmbK54hi.Enabled = true;
		}

		private void gDTbefCRoM(object _0020, EventArgs _0020)
		{
			//Discarded unreachable code: IL_0002
			o0mboTi7X3.Checked = false;
			FsHbLAoHPO.Checked = true;
			Jylb9kP3d7.Enabled = false;
			Mldbt8Zqt4.Enabled = true;
		}

		private void e8wbEdSqy1(object _0020, EventArgs _0020)
		{
			//Discarded unreachable code: IL_0002
			YLDbXSHZ1K.Checked = false;
			E4DbgGGpcM.Checked = true;
			R18bK9ookx.Enabled = false;
			XeWbVIdjce.Enabled = true;
		}

		private void PWybN0cWvW(object _0020, EventArgs _0020)
		{
			//Discarded unreachable code: IL_0002
			xwkb6SHMUC.Checked = false;
			Qs0bJKaFBw.Checked = true;
			qXpb2LOPqX.Enabled = false;
			zZgbIH7xFN.Enabled = true;
		}

		private void UpYbiVg4Ht(object _0020, FormClosingEventArgs _0020)
		{
			//Discarded unreachable code: IL_0002
			_0020.Cancel = true;
			MpgNotifyIcon.Visible = true;
			Hide();
		}

		private void fQ6bjvSbw8(object _0020, EventArgs _0020)
		{
			//Discarded unreachable code: IL_0002
			Show();
			base.WindowState = FormWindowState.Normal;
			base.ShowInTaskbar = true;
		}

		private void H6TbPwBfZa(object _0020, EventArgs _0020)
		{
			//Discarded unreachable code: IL_0002
			MPGFilter = X0UmTTKfnQ.SelectedIndex;
		}

		private void CTlbwH3eEt(object _0020, KeyEventArgs _0020)
		{
			//Discarded unreachable code: IL_0002
			if (_0020.KeyData != Keys.Return)
			{
				return;
			}
			double result = 0.0;
			if (double.TryParse(dZ9mWckw4V.Text, out result))
			{
				if (result < 0.01)
				{
					result = 0.01;
				}
				if (result > 25.0)
				{
					result = 25.0;
				}
				MPGSpeedMultiplier = result;
				dZ9mWckw4V.Text = MPGSpeedMultiplier.ToString();
			}
			else
			{
				MessageBox.Show(SGIrQcmgt97uvDTgI6P.InHOenpqO0(-439072256 ^ -439071362));
				dZ9mWckw4V.Text = MPGSpeedMultiplier.ToString();
			}
		}

		protected override void Dispose(bool disposing)
		{
			//Discarded unreachable code: IL_0002
			if (disposing && lvmbAjgU5k != null)
			{
				lvmbAjgU5k.Dispose();
			}
			base.Dispose(disposing);
		}

		private void LF2bWWLDab()
		{
			//Discarded unreachable code: IL_0002
			lvmbAjgU5k = new Container();
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(PluginForm));
			B7IbBTSM5B = new PictureBox();
			y37bvXgkj0 = new Label();
			Mldbt8Zqt4 = new TextBox();
			FsHbLAoHPO = new CheckBox();
			Jylb9kP3d7 = new ComboBox();
			o0mboTi7X3 = new CheckBox();
			k0LbkLmWbd = new Label();
			zZgbIH7xFN = new TextBox();
			XeWbVIdjce = new TextBox();
			Qs0bJKaFBw = new CheckBox();
			E4DbgGGpcM = new CheckBox();
			qXpb2LOPqX = new ComboBox();
			R18bK9ookx = new ComboBox();
			xwkb6SHMUC = new CheckBox();
			YLDbXSHZ1K = new CheckBox();
			xw1bz0SK4w = new Label();
			wdLm5fHcVm = new Label();
			ctlmbK54hi = new TextBox();
			Y22mm3reOe = new TextBox();
			MXQmOf2ifb = new CheckBox();
			d1TmQGDX6w = new CheckBox();
			JfFmHevaoo = new ComboBox();
			OKWmno7guW = new ComboBox();
			q3wm40oMBr = new CheckBox();
			vEtmF4A4wm = new CheckBox();
			k7TmSdsfTe = new Label();
			AJKms0lewQ = new Label();
			dEnm37R6sH = new Label();
			wgBmdev3Ll = new TextBox();
			XZamxMrGIy = new TextBox();
			kYemqTcBDI = new TextBox();
			HI9mYBsjkF = new TextBox();
			C6fmeRiJ10 = new TextBox();
			nmDmEtxprn = new CheckBox();
			h6HmNQ6hc5 = new CheckBox();
			vxKmi3AeBK = new CheckBox();
			K20mjcDvgt = new CheckBox();
			YFbmPNmvji = new CheckBox();
			glymwqjAOk = new GroupBox();
			dZ9mWckw4V = new TextBox();
			X0UmTTKfnQ = new ComboBox();
			WxOmZbwb8E = new Label();
			vFPm059VHW = new Label();
			fjcm1TkRlW = new Label();
			RMTmfGCqEE = new ComboBox();
			gINmM2fk89 = new ComboBox();
			ocGmpFAaJK = new ComboBox();
			GYVmykrvxI = new ComboBox();
			VQ9mRoWWfE = new ComboBox();
			kWwm802q8H = new CheckBox();
			LUImhwSclU = new CheckBox();
			kjCm7BPKIA = new CheckBox();
			BebmGxuFru = new CheckBox();
			bJNmu7IdXZ = new CheckBox();
			EEkmctOg4k = new Label();
			UXdmCSV0PB = new Label();
			AdimUd9GBa = new Label();
			TVHmluBr1b = new Label();
			dELmrfEYC7 = new Label();
			kXQmDXF4HH = new Button();
			MpgNotifyIcon = new NotifyIcon(lvmbAjgU5k);
			vZDbaMj4Ql = new UsbHidPort(lvmbAjgU5k);
			N5JmAUwG5P = new TextBox();
			gXpmaknpZT = new CheckBox();
			((ISupportInitialize)B7IbBTSM5B).BeginInit();
			glymwqjAOk.SuspendLayout();
			SuspendLayout();
			B7IbBTSM5B.Image = Resources.WHB4_04;
			B7IbBTSM5B.ImeMode = ImeMode.NoControl;
			B7IbBTSM5B.InitialImage = null;
			B7IbBTSM5B.Location = new Point(482, 299);
			B7IbBTSM5B.Name = SGIrQcmgt97uvDTgI6P.InHOenpqO0(0x68882BB9 ^ 0x6888239D);
			B7IbBTSM5B.Size = new Size(76, 160);
			B7IbBTSM5B.TabIndex = 399;
			B7IbBTSM5B.TabStop = false;
			y37bvXgkj0.AutoSize = true;
			y37bvXgkj0.ImeMode = ImeMode.NoControl;
			y37bvXgkj0.Location = new Point(479, 9);
			y37bvXgkj0.Name = SGIrQcmgt97uvDTgI6P.InHOenpqO0(0x4D697BA4 ^ 0x4D6973E6);
			y37bvXgkj0.Size = new Size(84, 13);
			y37bvXgkj0.TabIndex = 398;
			y37bvXgkj0.Text = SGIrQcmgt97uvDTgI6P.InHOenpqO0(0x78B1E17 ^ 0x78B1641);
			Mldbt8Zqt4.Location = new Point(482, 214);
			Mldbt8Zqt4.Name = SGIrQcmgt97uvDTgI6P.InHOenpqO0(0x6AD7164D ^ 0x6AD71E39);
			Mldbt8Zqt4.Size = new Size(76, 20);
			Mldbt8Zqt4.TabIndex = 397;
			Mldbt8Zqt4.TextAlign = HorizontalAlignment.Center;
			FsHbLAoHPO.AutoSize = true;
			FsHbLAoHPO.ImeMode = ImeMode.NoControl;
			FsHbLAoHPO.Location = new Point(458, 216);
			FsHbLAoHPO.Name = SGIrQcmgt97uvDTgI6P.InHOenpqO0(0x17C7A9C4 ^ 0x17C7A156);
			FsHbLAoHPO.Size = new Size(15, 14);
			FsHbLAoHPO.TabIndex = 396;
			FsHbLAoHPO.Tag = SGIrQcmgt97uvDTgI6P.InHOenpqO0(0x1E446DCB ^ 0x1E446575);
			FsHbLAoHPO.UseVisualStyleBackColor = true;
			FsHbLAoHPO.Click += gDTbefCRoM;
			Jylb9kP3d7.DropDownStyle = ComboBoxStyle.DropDownList;
			Jylb9kP3d7.FormattingEnabled = true;
			Jylb9kP3d7.Location = new Point(152, 213);
			Jylb9kP3d7.Name = SGIrQcmgt97uvDTgI6P.InHOenpqO0(-1978552644 ^ -1978554760);
			Jylb9kP3d7.Size = new Size(276, 21);
			Jylb9kP3d7.TabIndex = 393;
			o0mboTi7X3.AutoSize = true;
			o0mboTi7X3.ImeMode = ImeMode.NoControl;
			o0mboTi7X3.Location = new Point(129, 218);
			o0mboTi7X3.Name = SGIrQcmgt97uvDTgI6P.InHOenpqO0(-428565958 ^ -428567870);
			o0mboTi7X3.Size = new Size(15, 14);
			o0mboTi7X3.TabIndex = 392;
			o0mboTi7X3.Tag = SGIrQcmgt97uvDTgI6P.InHOenpqO0(-708915048 ^ -708913488);
			o0mboTi7X3.UseVisualStyleBackColor = true;
			o0mboTi7X3.Click += tGIb3G5u2f;
			k0LbkLmWbd.AutoSize = true;
			k0LbkLmWbd.ImeMode = ImeMode.NoControl;
			k0LbkLmWbd.Location = new Point(20, 216);
			k0LbkLmWbd.Name = SGIrQcmgt97uvDTgI6P.InHOenpqO0(0x233C91D6 ^ 0x233C98FA);
			k0LbkLmWbd.Size = new Size(87, 13);
			k0LbkLmWbd.TabIndex = 391;
			k0LbkLmWbd.Text = SGIrQcmgt97uvDTgI6P.InHOenpqO0(-320687442 ^ -320685074);
			zZgbIH7xFN.Location = new Point(482, 266);
			zZgbIH7xFN.Name = SGIrQcmgt97uvDTgI6P.InHOenpqO0(0x51F60F79 ^ 0x51F6061B);
			zZgbIH7xFN.Size = new Size(76, 20);
			zZgbIH7xFN.TabIndex = 390;
			zZgbIH7xFN.TextAlign = HorizontalAlignment.Center;
			XeWbVIdjce.Location = new Point(482, 240);
			XeWbVIdjce.Name = SGIrQcmgt97uvDTgI6P.InHOenpqO0(0x2944AFE7 ^ 0x2944A665);
			XeWbVIdjce.Size = new Size(76, 20);
			XeWbVIdjce.TabIndex = 389;
			XeWbVIdjce.TextAlign = HorizontalAlignment.Center;
			Qs0bJKaFBw.AutoSize = true;
			Qs0bJKaFBw.ImeMode = ImeMode.NoControl;
			Qs0bJKaFBw.Location = new Point(458, 268);
			Qs0bJKaFBw.Name = SGIrQcmgt97uvDTgI6P.InHOenpqO0(0x4EE059C0 ^ 0x4EE05060);
			Qs0bJKaFBw.Size = new Size(15, 14);
			Qs0bJKaFBw.TabIndex = 388;
			Qs0bJKaFBw.Tag = SGIrQcmgt97uvDTgI6P.InHOenpqO0(-1251800226 ^ -1251802144);
			Qs0bJKaFBw.UseVisualStyleBackColor = true;
			Qs0bJKaFBw.Click += PWybN0cWvW;
			E4DbgGGpcM.AutoSize = true;
			E4DbgGGpcM.ImeMode = ImeMode.NoControl;
			E4DbgGGpcM.Location = new Point(458, 242);
			E4DbgGGpcM.Name = SGIrQcmgt97uvDTgI6P.InHOenpqO0(0x5CEF7519 ^ 0x5CEF7CD7);
			E4DbgGGpcM.Size = new Size(15, 14);
			E4DbgGGpcM.TabIndex = 387;
			E4DbgGGpcM.Tag = SGIrQcmgt97uvDTgI6P.InHOenpqO0(0x58864335 ^ 0x58864B8B);
			E4DbgGGpcM.UseVisualStyleBackColor = true;
			E4DbgGGpcM.Click += e8wbEdSqy1;
			qXpb2LOPqX.DropDownStyle = ComboBoxStyle.DropDownList;
			qXpb2LOPqX.FormattingEnabled = true;
			qXpb2LOPqX.Location = new Point(152, 265);
			qXpb2LOPqX.Name = SGIrQcmgt97uvDTgI6P.InHOenpqO0(-259352232 ^ -259354462);
			qXpb2LOPqX.Size = new Size(276, 21);
			qXpb2LOPqX.TabIndex = 382;
			R18bK9ookx.DropDownStyle = ComboBoxStyle.DropDownList;
			R18bK9ookx.FormattingEnabled = true;
			R18bK9ookx.Location = new Point(152, 239);
			R18bK9ookx.Name = SGIrQcmgt97uvDTgI6P.InHOenpqO0(-528050159 ^ -528051679);
			R18bK9ookx.Size = new Size(276, 21);
			R18bK9ookx.TabIndex = 381;
			xwkb6SHMUC.AutoSize = true;
			xwkb6SHMUC.ImeMode = ImeMode.NoControl;
			xwkb6SHMUC.Location = new Point(129, 270);
			xwkb6SHMUC.Name = SGIrQcmgt97uvDTgI6P.InHOenpqO0(-9234614 ^ -9233106);
			xwkb6SHMUC.Size = new Size(15, 14);
			xwkb6SHMUC.TabIndex = 380;
			xwkb6SHMUC.Tag = SGIrQcmgt97uvDTgI6P.InHOenpqO0(-16739846 ^ -16738350);
			xwkb6SHMUC.UseVisualStyleBackColor = true;
			xwkb6SHMUC.Click += DLnbx56a7J;
			YLDbXSHZ1K.AutoSize = true;
			YLDbXSHZ1K.ImeMode = ImeMode.NoControl;
			YLDbXSHZ1K.Location = new Point(129, 244);
			YLDbXSHZ1K.Name = SGIrQcmgt97uvDTgI6P.InHOenpqO0(-992444272 ^ -992441846);
			YLDbXSHZ1K.Size = new Size(15, 14);
			YLDbXSHZ1K.TabIndex = 379;
			YLDbXSHZ1K.Tag = SGIrQcmgt97uvDTgI6P.InHOenpqO0(-644831706 ^ -644833266);
			YLDbXSHZ1K.UseVisualStyleBackColor = true;
			YLDbXSHZ1K.Click += arqbd6GJG4;
			xw1bz0SK4w.AutoSize = true;
			xw1bz0SK4w.ImeMode = ImeMode.NoControl;
			xw1bz0SK4w.Location = new Point(13, 268);
			xw1bz0SK4w.Name = SGIrQcmgt97uvDTgI6P.InHOenpqO0(0x4888141E ^ 0x48881ED0);
			xw1bz0SK4w.Size = new Size(93, 13);
			xw1bz0SK4w.TabIndex = 378;
			xw1bz0SK4w.Text = SGIrQcmgt97uvDTgI6P.InHOenpqO0(0x71C79B4C ^ 0x71C791AE);
			wdLm5fHcVm.AutoSize = true;
			wdLm5fHcVm.ImeMode = ImeMode.NoControl;
			wdLm5fHcVm.Location = new Point(20, 242);
			wdLm5fHcVm.Name = SGIrQcmgt97uvDTgI6P.InHOenpqO0(0x11308876 ^ 0x11308370);
			wdLm5fHcVm.Size = new Size(87, 13);
			wdLm5fHcVm.TabIndex = 377;
			wdLm5fHcVm.Text = SGIrQcmgt97uvDTgI6P.InHOenpqO0(-508791245 ^ -508789463);
			ctlmbK54hi.Location = new Point(482, 136);
			ctlmbK54hi.Name = SGIrQcmgt97uvDTgI6P.InHOenpqO0(-883650111 ^ -883647747);
			ctlmbK54hi.Size = new Size(76, 20);
			ctlmbK54hi.TabIndex = 376;
			ctlmbK54hi.TextAlign = HorizontalAlignment.Center;
			Y22mm3reOe.Location = new Point(482, 110);
			Y22mm3reOe.Name = SGIrQcmgt97uvDTgI6P.InHOenpqO0(-559005114 ^ -559003364);
			Y22mm3reOe.Size = new Size(76, 20);
			Y22mm3reOe.TabIndex = 375;
			Y22mm3reOe.TextAlign = HorizontalAlignment.Center;
			MXQmOf2ifb.AutoSize = true;
			MXQmOf2ifb.ImeMode = ImeMode.NoControl;
			MXQmOf2ifb.Location = new Point(458, 138);
			MXQmOf2ifb.Name = SGIrQcmgt97uvDTgI6P.InHOenpqO0(-259352232 ^ -259354080);
			MXQmOf2ifb.Size = new Size(15, 14);
			MXQmOf2ifb.TabIndex = 374;
			MXQmOf2ifb.Tag = SGIrQcmgt97uvDTgI6P.InHOenpqO0(-188556840 ^ -188559002);
			MXQmOf2ifb.UseVisualStyleBackColor = true;
			MXQmOf2ifb.Click += nQxbYsbkkb;
			d1TmQGDX6w.AutoSize = true;
			d1TmQGDX6w.ImeMode = ImeMode.NoControl;
			d1TmQGDX6w.Location = new Point(458, 112);
			d1TmQGDX6w.Name = SGIrQcmgt97uvDTgI6P.InHOenpqO0(0x11308876 ^ 0x113083D2);
			d1TmQGDX6w.Size = new Size(15, 14);
			d1TmQGDX6w.TabIndex = 373;
			d1TmQGDX6w.Tag = SGIrQcmgt97uvDTgI6P.InHOenpqO0(-548021409 ^ -548023327);
			d1TmQGDX6w.UseVisualStyleBackColor = true;
			d1TmQGDX6w.Click += Tkdbql3lee;
			JfFmHevaoo.DropDownStyle = ComboBoxStyle.DropDownList;
			JfFmHevaoo.FormattingEnabled = true;
			JfFmHevaoo.Location = new Point(152, 135);
			JfFmHevaoo.Name = SGIrQcmgt97uvDTgI6P.InHOenpqO0(0x78B1E17 ^ 0x78B15C7);
			JfFmHevaoo.Size = new Size(276, 21);
			JfFmHevaoo.TabIndex = 368;
			OKWmno7guW.DropDownStyle = ComboBoxStyle.DropDownList;
			OKWmno7guW.FormattingEnabled = true;
			OKWmno7guW.Location = new Point(152, 109);
			OKWmno7guW.Name = SGIrQcmgt97uvDTgI6P.InHOenpqO0(0x263FA100 ^ 0x263FAD04);
			OKWmno7guW.Size = new Size(276, 21);
			OKWmno7guW.TabIndex = 367;
			q3wm40oMBr.AutoSize = true;
			q3wm40oMBr.ImeMode = ImeMode.NoControl;
			q3wm40oMBr.Location = new Point(129, 140);
			q3wm40oMBr.Name = SGIrQcmgt97uvDTgI6P.InHOenpqO0(-548021409 ^ -548022425);
			q3wm40oMBr.Size = new Size(15, 14);
			q3wm40oMBr.TabIndex = 366;
			q3wm40oMBr.Tag = SGIrQcmgt97uvDTgI6P.InHOenpqO0(-692479268 ^ -692478732);
			q3wm40oMBr.UseVisualStyleBackColor = true;
			q3wm40oMBr.Click += aCebsXkoRS;
			vEtmF4A4wm.AutoSize = true;
			vEtmF4A4wm.ImeMode = ImeMode.NoControl;
			vEtmF4A4wm.Location = new Point(129, 114);
			vEtmF4A4wm.Name = SGIrQcmgt97uvDTgI6P.InHOenpqO0(-212200409 ^ -212199349);
			vEtmF4A4wm.Size = new Size(15, 14);
			vEtmF4A4wm.TabIndex = 365;
			vEtmF4A4wm.Tag = SGIrQcmgt97uvDTgI6P.InHOenpqO0(0x5F8C08DA ^ 0x5F8C0EF2);
			vEtmF4A4wm.UseVisualStyleBackColor = true;
			vEtmF4A4wm.Click += anHbSoOlV9;
			k7TmSdsfTe.AutoSize = true;
			k7TmSdsfTe.ImeMode = ImeMode.NoControl;
			k7TmSdsfTe.Location = new Point(20, 138);
			k7TmSdsfTe.Name = SGIrQcmgt97uvDTgI6P.InHOenpqO0(0x2944AFE7 ^ 0x2944A347);
			k7TmSdsfTe.Size = new Size(87, 13);
			k7TmSdsfTe.TabIndex = 364;
			k7TmSdsfTe.Text = SGIrQcmgt97uvDTgI6P.InHOenpqO0(0x718CB4E ^ 0x718C7FA);
			AJKms0lewQ.AutoSize = true;
			AJKms0lewQ.ImeMode = ImeMode.NoControl;
			AJKms0lewQ.Location = new Point(20, 112);
			AJKms0lewQ.Name = SGIrQcmgt97uvDTgI6P.InHOenpqO0(-1693174992 ^ -1693171738);
			AJKms0lewQ.Size = new Size(87, 13);
			AJKms0lewQ.TabIndex = 363;
			AJKms0lewQ.Text = SGIrQcmgt97uvDTgI6P.InHOenpqO0(0x142C3C0A ^ 0x142C30E0);
			dEnm37R6sH.AutoSize = true;
			dEnm37R6sH.ImeMode = ImeMode.NoControl;
			dEnm37R6sH.Location = new Point(13, 445);
			dEnm37R6sH.Name = SGIrQcmgt97uvDTgI6P.InHOenpqO0(-1438821067 ^ -1438820295);
			dEnm37R6sH.Size = new Size(113, 13);
			dEnm37R6sH.TabIndex = 362;
			dEnm37R6sH.Text = SGIrQcmgt97uvDTgI6P.InHOenpqO0(0x4888141E ^ 0x48881924);
			wgBmdev3Ll.Location = new Point(482, 188);
			wgBmdev3Ll.Name = SGIrQcmgt97uvDTgI6P.InHOenpqO0(-292836720 ^ -292837386);
			wgBmdev3Ll.Size = new Size(76, 20);
			wgBmdev3Ll.TabIndex = 361;
			wgBmdev3Ll.TextAlign = HorizontalAlignment.Center;
			XZamxMrGIy.Location = new Point(482, 162);
			XZamxMrGIy.Name = SGIrQcmgt97uvDTgI6P.InHOenpqO0(-188556840 ^ -188558244);
			XZamxMrGIy.Size = new Size(76, 20);
			XZamxMrGIy.TabIndex = 360;
			XZamxMrGIy.TextAlign = HorizontalAlignment.Center;
			kYemqTcBDI.Location = new Point(482, 84);
			kYemqTcBDI.Name = SGIrQcmgt97uvDTgI6P.InHOenpqO0(0x46C3DEA6 ^ 0x46C3D304);
			kYemqTcBDI.Size = new Size(76, 20);
			kYemqTcBDI.TabIndex = 359;
			kYemqTcBDI.TextAlign = HorizontalAlignment.Center;
			HI9mYBsjkF.Location = new Point(482, 58);
			HI9mYBsjkF.Name = SGIrQcmgt97uvDTgI6P.InHOenpqO0(0x51F60F79 ^ 0x51F602B9);
			HI9mYBsjkF.Size = new Size(76, 20);
			HI9mYBsjkF.TabIndex = 358;
			HI9mYBsjkF.TextAlign = HorizontalAlignment.Center;
			C6fmeRiJ10.Location = new Point(482, 32);
			C6fmeRiJ10.Name = SGIrQcmgt97uvDTgI6P.InHOenpqO0(0x71C79B4C ^ 0x71C79692);
			C6fmeRiJ10.Size = new Size(76, 20);
			C6fmeRiJ10.TabIndex = 357;
			C6fmeRiJ10.TextAlign = HorizontalAlignment.Center;
			nmDmEtxprn.AutoSize = true;
			nmDmEtxprn.ImeMode = ImeMode.NoControl;
			nmDmEtxprn.Location = new Point(458, 190);
			nmDmEtxprn.Name = SGIrQcmgt97uvDTgI6P.InHOenpqO0(0x4A7956E4 ^ 0x4A795B18);
			nmDmEtxprn.Size = new Size(15, 14);
			nmDmEtxprn.TabIndex = 356;
			nmDmEtxprn.Tag = SGIrQcmgt97uvDTgI6P.InHOenpqO0(0x2944AFE7 ^ 0x2944A759);
			nmDmEtxprn.UseVisualStyleBackColor = true;
			nmDmEtxprn.Click += N5UbFqx9wM;
			h6HmNQ6hc5.AutoSize = true;
			h6HmNQ6hc5.ImeMode = ImeMode.NoControl;
			h6HmNQ6hc5.Location = new Point(458, 164);
			h6HmNQ6hc5.Name = SGIrQcmgt97uvDTgI6P.InHOenpqO0(0x71C79B4C ^ 0x71C79564);
			h6HmNQ6hc5.Size = new Size(15, 14);
			h6HmNQ6hc5.TabIndex = 355;
			h6HmNQ6hc5.Tag = SGIrQcmgt97uvDTgI6P.InHOenpqO0(0x7A393CD1 ^ 0x7A39346F);
			h6HmNQ6hc5.UseVisualStyleBackColor = true;
			h6HmNQ6hc5.Click += B9WbnNPtnh;
			vxKmi3AeBK.AutoSize = true;
			vxKmi3AeBK.ImeMode = ImeMode.NoControl;
			vxKmi3AeBK.Location = new Point(458, 86);
			vxKmi3AeBK.Name = SGIrQcmgt97uvDTgI6P.InHOenpqO0(-692479268 ^ -692480888);
			vxKmi3AeBK.Size = new Size(15, 14);
			vxKmi3AeBK.TabIndex = 354;
			vxKmi3AeBK.Tag = SGIrQcmgt97uvDTgI6P.InHOenpqO0(0x976AB9 ^ 0x976207);
			vxKmi3AeBK.UseVisualStyleBackColor = true;
			vxKmi3AeBK.Click += cP2bQlSeTG;
			K20mjcDvgt.AutoSize = true;
			K20mjcDvgt.ImeMode = ImeMode.NoControl;
			K20mjcDvgt.Location = new Point(458, 60);
			K20mjcDvgt.Name = SGIrQcmgt97uvDTgI6P.InHOenpqO0(0x4888141E ^ 0x48881A9E);
			K20mjcDvgt.Size = new Size(15, 14);
			K20mjcDvgt.TabIndex = 353;
			K20mjcDvgt.Tag = SGIrQcmgt97uvDTgI6P.InHOenpqO0(0x29B3A14 ^ 0x29B32AA);
			K20mjcDvgt.UseVisualStyleBackColor = true;
			K20mjcDvgt.Click += tMEbmpD2C3;
			YFbmPNmvji.AutoSize = true;
			YFbmPNmvji.ImeMode = ImeMode.NoControl;
			YFbmPNmvji.Location = new Point(458, 34);
			YFbmPNmvji.Name = SGIrQcmgt97uvDTgI6P.InHOenpqO0(-992444272 ^ -992440772);
			YFbmPNmvji.Size = new Size(15, 14);
			YFbmPNmvji.TabIndex = 352;
			YFbmPNmvji.Tag = SGIrQcmgt97uvDTgI6P.InHOenpqO0(-798949530 ^ -798951464);
			YFbmPNmvji.UseVisualStyleBackColor = true;
			YFbmPNmvji.Click += K8lb5vBEAM;
			glymwqjAOk.Controls.Add(dZ9mWckw4V);
			glymwqjAOk.Controls.Add(X0UmTTKfnQ);
			glymwqjAOk.Controls.Add(WxOmZbwb8E);
			glymwqjAOk.Controls.Add(vFPm059VHW);
			glymwqjAOk.Location = new Point(16, 305);
			glymwqjAOk.Name = SGIrQcmgt97uvDTgI6P.InHOenpqO0(-476989957 ^ -476988637);
			glymwqjAOk.Size = new Size(263, 82);
			glymwqjAOk.TabIndex = 351;
			glymwqjAOk.TabStop = false;
			glymwqjAOk.Text = SGIrQcmgt97uvDTgI6P.InHOenpqO0(-734611327 ^ -734611855);
			dZ9mWckw4V.Location = new Point(177, 47);
			dZ9mWckw4V.Name = SGIrQcmgt97uvDTgI6P.InHOenpqO0(0x40198C91 ^ 0x40198381);
			dZ9mWckw4V.Size = new Size(57, 20);
			dZ9mWckw4V.TabIndex = 10;
			dZ9mWckw4V.Text = SGIrQcmgt97uvDTgI6P.InHOenpqO0(-51230102 ^ -51231408);
			dZ9mWckw4V.KeyUp += CTlbwH3eEt;
			X0UmTTKfnQ.DropDownStyle = ComboBoxStyle.DropDownList;
			X0UmTTKfnQ.FormattingEnabled = true;
			X0UmTTKfnQ.Items.AddRange(new object[26]
			{
				SGIrQcmgt97uvDTgI6P.InHOenpqO0(-1693174992 ^ -1693174504),
				SGIrQcmgt97uvDTgI6P.InHOenpqO0(-1429533589 ^ -1429535531),
				SGIrQcmgt97uvDTgI6P.InHOenpqO0(-1693174992 ^ -1693172622),
				SGIrQcmgt97uvDTgI6P.InHOenpqO0(0x1CF5D0E4 ^ 0x1CF5DFAC),
				SGIrQcmgt97uvDTgI6P.InHOenpqO0(-446893345 ^ -446890607),
				SGIrQcmgt97uvDTgI6P.InHOenpqO0(0x5CEF7519 ^ 0x5CEF77AF),
				SGIrQcmgt97uvDTgI6P.InHOenpqO0(-1764764966 ^ -1764762226),
				SGIrQcmgt97uvDTgI6P.InHOenpqO0(-51230102 ^ -51231440),
				SGIrQcmgt97uvDTgI6P.InHOenpqO0(-23011901 ^ -23014749),
				SGIrQcmgt97uvDTgI6P.InHOenpqO0(--1951529289 ^ 0x7451F62F),
				SGIrQcmgt97uvDTgI6P.InHOenpqO0(0x6593139F ^ 0x65931141),
				SGIrQcmgt97uvDTgI6P.InHOenpqO0(-446893345 ^ -446890573),
				SGIrQcmgt97uvDTgI6P.InHOenpqO0(-1420261768 ^ -1420261108),
				SGIrQcmgt97uvDTgI6P.InHOenpqO0(0x4F791E58 ^ 0x4F791124),
				SGIrQcmgt97uvDTgI6P.InHOenpqO0(0x7F29E0FB ^ 0x7F29EF7F),
				SGIrQcmgt97uvDTgI6P.InHOenpqO0(0x76C85970 ^ 0x76C856FC),
				SGIrQcmgt97uvDTgI6P.InHOenpqO0(-429223925 ^ -429219937),
				SGIrQcmgt97uvDTgI6P.InHOenpqO0(-2146361446 ^ -2146365434),
				SGIrQcmgt97uvDTgI6P.InHOenpqO0(0x71C79B4C ^ 0x71C794E8),
				SGIrQcmgt97uvDTgI6P.InHOenpqO0(-446893345 ^ -446890637),
				SGIrQcmgt97uvDTgI6P.InHOenpqO0(0x50AD665B ^ 0x50AD6961),
				SGIrQcmgt97uvDTgI6P.InHOenpqO0(0x1E446DCB ^ 0x1E44627F),
				SGIrQcmgt97uvDTgI6P.InHOenpqO0(0x191AA1F1 ^ 0x191AAE4D),
				SGIrQcmgt97uvDTgI6P.InHOenpqO0(-212200409 ^ -212198429),
				SGIrQcmgt97uvDTgI6P.InHOenpqO0(0x5EC4E4AE ^ 0x5EC4EB62),
				SGIrQcmgt97uvDTgI6P.InHOenpqO0(0x4888141E ^ 0x48881BCA)
			});
			X0UmTTKfnQ.Location = new Point(177, 20);
			X0UmTTKfnQ.Name = SGIrQcmgt97uvDTgI6P.InHOenpqO0(0x4EE059C0 ^ 0x4EE0561C);
			X0UmTTKfnQ.Size = new Size(57, 21);
			X0UmTTKfnQ.TabIndex = 7;
			X0UmTTKfnQ.SelectedIndexChanged += H6TbPwBfZa;
			WxOmZbwb8E.AutoSize = true;
			WxOmZbwb8E.ImeMode = ImeMode.NoControl;
			WxOmZbwb8E.Location = new Point(43, 23);
			WxOmZbwb8E.Name = SGIrQcmgt97uvDTgI6P.InHOenpqO0(-429223925 ^ -429228023);
			WxOmZbwb8E.Size = new Size(101, 13);
			WxOmZbwb8E.TabIndex = 8;
			WxOmZbwb8E.Text = SGIrQcmgt97uvDTgI6P.InHOenpqO0(-1508183274 ^ -1508187392);
			vFPm059VHW.AutoSize = true;
			vFPm059VHW.ImeMode = ImeMode.NoControl;
			vFPm059VHW.Location = new Point(35, 50);
			vFPm059VHW.Name = SGIrQcmgt97uvDTgI6P.InHOenpqO0(-429223925 ^ -429227957);
			vFPm059VHW.Size = new Size(109, 13);
			vFPm059VHW.TabIndex = 9;
			vFPm059VHW.Text = SGIrQcmgt97uvDTgI6P.InHOenpqO0(-2146361446 ^ -2146365490);
			fjcm1TkRlW.AutoSize = true;
			fjcm1TkRlW.ImeMode = ImeMode.NoControl;
			fjcm1TkRlW.Location = new Point(235, 9);
			fjcm1TkRlW.Name = SGIrQcmgt97uvDTgI6P.InHOenpqO0(-1988417526 ^ -1988413304);
			fjcm1TkRlW.Size = new Size(88, 13);
			fjcm1TkRlW.TabIndex = 349;
			fjcm1TkRlW.Text = SGIrQcmgt97uvDTgI6P.InHOenpqO0(0x78B1E17 ^ 0x78B0E81);
			RMTmfGCqEE.DropDownStyle = ComboBoxStyle.DropDownList;
			RMTmfGCqEE.FormattingEnabled = true;
			RMTmfGCqEE.Location = new Point(152, 187);
			RMTmfGCqEE.Name = SGIrQcmgt97uvDTgI6P.InHOenpqO0(--531712925 ^ 0x1FB15B2B);
			RMTmfGCqEE.Size = new Size(276, 21);
			RMTmfGCqEE.TabIndex = 338;
			gINmM2fk89.DropDownStyle = ComboBoxStyle.DropDownList;
			gINmM2fk89.FormattingEnabled = true;
			gINmM2fk89.Location = new Point(152, 161);
			gINmM2fk89.Name = SGIrQcmgt97uvDTgI6P.InHOenpqO0(-528050159 ^ -528054021);
			gINmM2fk89.Size = new Size(276, 21);
			gINmM2fk89.TabIndex = 337;
			ocGmpFAaJK.DropDownStyle = ComboBoxStyle.DropDownList;
			ocGmpFAaJK.FormattingEnabled = true;
			ocGmpFAaJK.Location = new Point(152, 83);
			ocGmpFAaJK.Name = SGIrQcmgt97uvDTgI6P.InHOenpqO0(0x4086BCF4 ^ 0x4086ADEA);
			ocGmpFAaJK.Size = new Size(276, 21);
			ocGmpFAaJK.TabIndex = 336;
			GYVmykrvxI.DropDownStyle = ComboBoxStyle.DropDownList;
			GYVmykrvxI.FormattingEnabled = true;
			GYVmykrvxI.Location = new Point(152, 57);
			GYVmykrvxI.Name = SGIrQcmgt97uvDTgI6P.InHOenpqO0(-403980296 ^ -403984726);
			GYVmykrvxI.Size = new Size(276, 21);
			GYVmykrvxI.TabIndex = 335;
			VQ9mRoWWfE.DropDownStyle = ComboBoxStyle.DropDownList;
			VQ9mRoWWfE.FormattingEnabled = true;
			VQ9mRoWWfE.Location = new Point(152, 31);
			VQ9mRoWWfE.Name = SGIrQcmgt97uvDTgI6P.InHOenpqO0(-528050159 ^ -528053865);
			VQ9mRoWWfE.Size = new Size(276, 21);
			VQ9mRoWWfE.TabIndex = 334;
			kWwm802q8H.AutoSize = true;
			kWwm802q8H.ImeMode = ImeMode.NoControl;
			kWwm802q8H.Location = new Point(129, 192);
			kWwm802q8H.Name = SGIrQcmgt97uvDTgI6P.InHOenpqO0(0x51F60F79 ^ 0x51F61EC3);
			kWwm802q8H.Size = new Size(15, 14);
			kWwm802q8H.TabIndex = 333;
			kWwm802q8H.Tag = SGIrQcmgt97uvDTgI6P.InHOenpqO0(0x58864335 ^ 0x5886451D);
			kWwm802q8H.UseVisualStyleBackColor = true;
			kWwm802q8H.Click += HWWb4iDDfA;
			LUImhwSclU.AutoSize = true;
			LUImhwSclU.ImeMode = ImeMode.NoControl;
			LUImhwSclU.Location = new Point(129, 166);
			LUImhwSclU.Name = SGIrQcmgt97uvDTgI6P.InHOenpqO0(-236709298 ^ -236713056);
			LUImhwSclU.Size = new Size(15, 14);
			LUImhwSclU.TabIndex = 332;
			LUImhwSclU.Tag = SGIrQcmgt97uvDTgI6P.InHOenpqO0(-188556840 ^ -188555280);
			LUImhwSclU.UseVisualStyleBackColor = true;
			LUImhwSclU.Click += lCWbHeXPea;
			kjCm7BPKIA.AutoSize = true;
			kjCm7BPKIA.ImeMode = ImeMode.NoControl;
			kjCm7BPKIA.Location = new Point(129, 88);
			kjCm7BPKIA.Name = SGIrQcmgt97uvDTgI6P.InHOenpqO0(--531712925 ^ 0x1FB159BF);
			kjCm7BPKIA.Size = new Size(15, 14);
			kjCm7BPKIA.TabIndex = 331;
			kjCm7BPKIA.Tag = SGIrQcmgt97uvDTgI6P.InHOenpqO0(-27817024 ^ -27816472);
			kjCm7BPKIA.UseVisualStyleBackColor = true;
			kjCm7BPKIA.Click += Gw7bOxhH6c;
			BebmGxuFru.AutoSize = true;
			BebmGxuFru.ImeMode = ImeMode.NoControl;
			BebmGxuFru.Location = new Point(129, 62);
			BebmGxuFru.Name = SGIrQcmgt97uvDTgI6P.InHOenpqO0(-608047808 ^ -608043242);
			BebmGxuFru.Size = new Size(15, 14);
			BebmGxuFru.TabIndex = 330;
			BebmGxuFru.Tag = SGIrQcmgt97uvDTgI6P.InHOenpqO0(0x191AA1F1 ^ 0x191AA7D9);
			BebmGxuFru.UseVisualStyleBackColor = true;
			BebmGxuFru.Click += bGjbbFh5ck;
			bJNmu7IdXZ.AutoSize = true;
			bJNmu7IdXZ.ImeMode = ImeMode.NoControl;
			bJNmu7IdXZ.Location = new Point(129, 36);
			bJNmu7IdXZ.Name = SGIrQcmgt97uvDTgI6P.InHOenpqO0(-428565958 ^ -428570448);
			bJNmu7IdXZ.Size = new Size(15, 14);
			bJNmu7IdXZ.TabIndex = 329;
			bJNmu7IdXZ.Tag = SGIrQcmgt97uvDTgI6P.InHOenpqO0(0xF321DE8 ^ 0xF321BC0);
			bJNmu7IdXZ.UseVisualStyleBackColor = true;
			bJNmu7IdXZ.Click += fVfz2CMw3;
			EEkmctOg4k.AutoSize = true;
			EEkmctOg4k.ImeMode = ImeMode.NoControl;
			EEkmctOg4k.Location = new Point(20, 190);
			EEkmctOg4k.Name = SGIrQcmgt97uvDTgI6P.InHOenpqO0(0x4FB9E673 ^ 0x4FB9F4CD);
			EEkmctOg4k.Size = new Size(87, 13);
			EEkmctOg4k.TabIndex = 328;
			EEkmctOg4k.Text = SGIrQcmgt97uvDTgI6P.InHOenpqO0(0x2AB63FB2 ^ 0x2AB62D60);
			UXdmCSV0PB.AutoSize = true;
			UXdmCSV0PB.ImeMode = ImeMode.NoControl;
			UXdmCSV0PB.Location = new Point(20, 164);
			UXdmCSV0PB.Name = SGIrQcmgt97uvDTgI6P.InHOenpqO0(-883650111 ^ -883653835);
			UXdmCSV0PB.Size = new Size(87, 13);
			UXdmCSV0PB.TabIndex = 327;
			UXdmCSV0PB.Text = SGIrQcmgt97uvDTgI6P.InHOenpqO0(-27817024 ^ -27813688);
			AdimUd9GBa.AutoSize = true;
			AdimUd9GBa.ImeMode = ImeMode.NoControl;
			AdimUd9GBa.Location = new Point(20, 86);
			AdimUd9GBa.Name = SGIrQcmgt97uvDTgI6P.InHOenpqO0(0x539D2461 ^ 0x539D374B);
			AdimUd9GBa.Size = new Size(87, 13);
			AdimUd9GBa.TabIndex = 326;
			AdimUd9GBa.Text = SGIrQcmgt97uvDTgI6P.InHOenpqO0(-9234614 ^ -9239436);
			TVHmluBr1b.AutoSize = true;
			TVHmluBr1b.ImeMode = ImeMode.NoControl;
			TVHmluBr1b.Location = new Point(20, 60);
			TVHmluBr1b.Name = SGIrQcmgt97uvDTgI6P.InHOenpqO0(-439072256 ^ -439068320);
			TVHmluBr1b.Size = new Size(87, 13);
			TVHmluBr1b.TabIndex = 325;
			TVHmluBr1b.Text = SGIrQcmgt97uvDTgI6P.InHOenpqO0(-86283554 ^ -86279766);
			dELmrfEYC7.AutoSize = true;
			dELmrfEYC7.ImeMode = ImeMode.NoControl;
			dELmrfEYC7.Location = new Point(20, 34);
			dELmrfEYC7.Name = SGIrQcmgt97uvDTgI6P.InHOenpqO0(--1951529289 ^ 0x7451EADF);
			dELmrfEYC7.Size = new Size(87, 13);
			dELmrfEYC7.TabIndex = 324;
			dELmrfEYC7.Text = SGIrQcmgt97uvDTgI6P.InHOenpqO0(-1791199285 ^ -1791204255);
			kXQmDXF4HH.ImeMode = ImeMode.NoControl;
			kXQmDXF4HH.Location = new Point(193, 419);
			kXQmDXF4HH.Name = SGIrQcmgt97uvDTgI6P.InHOenpqO0(-992444272 ^ -992439460);
			kXQmDXF4HH.Size = new Size(86, 40);
			kXQmDXF4HH.TabIndex = 323;
			kXQmDXF4HH.Text = SGIrQcmgt97uvDTgI6P.InHOenpqO0(-281721232 ^ -281717346);
			kXQmDXF4HH.UseVisualStyleBackColor = true;
			kXQmDXF4HH.Click += Imd9dNhhW;
			MpgNotifyIcon.Icon = (Icon)componentResourceManager.GetObject(SGIrQcmgt97uvDTgI6P.InHOenpqO0(-299386311 ^ -299389387));
			MpgNotifyIcon.Text = SGIrQcmgt97uvDTgI6P.InHOenpqO0(-1420261768 ^ -1420258740);
			MpgNotifyIcon.Visible = true;
			MpgNotifyIcon.Click += fQ6bjvSbw8;
			vZDbaMj4Ql.ProductId = 60307;
			vZDbaMj4Ql.VendorId = 4302;
			vZDbaMj4Ql.OnSpecifiedDeviceArrived += W0oISGaA0;
			vZDbaMj4Ql.OnSpecifiedDeviceRemoved += Ak9Vw974Q;
			vZDbaMj4Ql.OnDeviceArrived += Q6yof51DC;
			vZDbaMj4Ql.OnDeviceRemoved += g34khBb3h;
			vZDbaMj4Ql.OnDataRecieved += E2sJxilmE;
			N5JmAUwG5P.Location = new Point(286, 305);
			N5JmAUwG5P.Multiline = true;
			N5JmAUwG5P.Name = SGIrQcmgt97uvDTgI6P.InHOenpqO0(0x11308876 ^ 0x11309C3E);
			N5JmAUwG5P.Size = new Size(190, 153);
			N5JmAUwG5P.TabIndex = 400;
			N5JmAUwG5P.Visible = false;
			gXpmaknpZT.AutoSize = true;
			gXpmaknpZT.Location = new Point(16, 403);
			gXpmaknpZT.Name = SGIrQcmgt97uvDTgI6P.InHOenpqO0(-1764764966 ^ -1764768066);
			gXpmaknpZT.Size = new Size(68, 17);
			gXpmaknpZT.TabIndex = 401;
			gXpmaknpZT.Text = SGIrQcmgt97uvDTgI6P.InHOenpqO0(0x29B3A14 ^ 0x29B2E80);
			gXpmaknpZT.UseVisualStyleBackColor = true;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.White;
			base.ClientSize = new Size(580, 471);
			base.Controls.Add(gXpmaknpZT);
			base.Controls.Add(N5JmAUwG5P);
			base.Controls.Add(B7IbBTSM5B);
			base.Controls.Add(y37bvXgkj0);
			base.Controls.Add(Mldbt8Zqt4);
			base.Controls.Add(FsHbLAoHPO);
			base.Controls.Add(Jylb9kP3d7);
			base.Controls.Add(o0mboTi7X3);
			base.Controls.Add(k0LbkLmWbd);
			base.Controls.Add(zZgbIH7xFN);
			base.Controls.Add(XeWbVIdjce);
			base.Controls.Add(Qs0bJKaFBw);
			base.Controls.Add(E4DbgGGpcM);
			base.Controls.Add(qXpb2LOPqX);
			base.Controls.Add(R18bK9ookx);
			base.Controls.Add(xwkb6SHMUC);
			base.Controls.Add(YLDbXSHZ1K);
			base.Controls.Add(xw1bz0SK4w);
			base.Controls.Add(wdLm5fHcVm);
			base.Controls.Add(ctlmbK54hi);
			base.Controls.Add(Y22mm3reOe);
			base.Controls.Add(MXQmOf2ifb);
			base.Controls.Add(d1TmQGDX6w);
			base.Controls.Add(JfFmHevaoo);
			base.Controls.Add(OKWmno7guW);
			base.Controls.Add(q3wm40oMBr);
			base.Controls.Add(vEtmF4A4wm);
			base.Controls.Add(k7TmSdsfTe);
			base.Controls.Add(AJKms0lewQ);
			base.Controls.Add(dEnm37R6sH);
			base.Controls.Add(wgBmdev3Ll);
			base.Controls.Add(XZamxMrGIy);
			base.Controls.Add(kYemqTcBDI);
			base.Controls.Add(HI9mYBsjkF);
			base.Controls.Add(C6fmeRiJ10);
			base.Controls.Add(nmDmEtxprn);
			base.Controls.Add(h6HmNQ6hc5);
			base.Controls.Add(vxKmi3AeBK);
			base.Controls.Add(K20mjcDvgt);
			base.Controls.Add(YFbmPNmvji);
			base.Controls.Add(glymwqjAOk);
			base.Controls.Add(fjcm1TkRlW);
			base.Controls.Add(RMTmfGCqEE);
			base.Controls.Add(gINmM2fk89);
			base.Controls.Add(ocGmpFAaJK);
			base.Controls.Add(GYVmykrvxI);
			base.Controls.Add(VQ9mRoWWfE);
			base.Controls.Add(kWwm802q8H);
			base.Controls.Add(LUImhwSclU);
			base.Controls.Add(kjCm7BPKIA);
			base.Controls.Add(BebmGxuFru);
			base.Controls.Add(bJNmu7IdXZ);
			base.Controls.Add(EEkmctOg4k);
			base.Controls.Add(UXdmCSV0PB);
			base.Controls.Add(AdimUd9GBa);
			base.Controls.Add(TVHmluBr1b);
			base.Controls.Add(dELmrfEYC7);
			base.Controls.Add(kXQmDXF4HH);
			base.Icon = (Icon)componentResourceManager.GetObject(SGIrQcmgt97uvDTgI6P.InHOenpqO0(0x4086BCF4 ^ 0x4086A85E));
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = SGIrQcmgt97uvDTgI6P.InHOenpqO0(-1133012468 ^ -1133015346);
			base.StartPosition = FormStartPosition.CenterScreen;
			Text = SGIrQcmgt97uvDTgI6P.InHOenpqO0(0x40198C91 ^ 0x4019984B);
			base.TopMost = true;
			base.FormClosing += UpYbiVg4Ht;
			base.Load += hLXLHJtYb;
			((ISupportInitialize)B7IbBTSM5B).EndInit();
			glymwqjAOk.ResumeLayout(performLayout: false);
			glymwqjAOk.PerformLayout();
			ResumeLayout(performLayout: false);
			PerformLayout();
		}
	}
}
