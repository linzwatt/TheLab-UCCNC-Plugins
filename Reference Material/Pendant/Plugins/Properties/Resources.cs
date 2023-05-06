using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace Plugins.Properties {
	[global::System.CodeDom.Compiler.GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
	[global::System.Diagnostics.DebuggerNonUserCode]
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	internal class Resources {
		private static global::System.Resources.ResourceManager resourceManager;

		private static global::System.Globalization.CultureInfo cultureInfo;

		internal Resources() { }

		[global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Advanced)]
		internal static global::System.Resources.ResourceManager _ResourceManager {
			get {
				if (global::Plugins.Properties.Resources.resourceManager == null) { 
					global::Plugins.Properties.Resources.resourceManager = new global::System.Resources.ResourceManager("Plugins.Properties.Resources", typeof(global::Plugins.Properties.Resources).Assembly); }
				return global::Plugins.Properties.Resources.resourceManager; } }
		 
		[global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Advanced)]
		internal static global::System.Globalization.CultureInfo _CultureInfo {
			get { return global::Plugins.Properties.Resources.cultureInfo; } 
			set { global::Plugins.Properties.Resources.cultureInfo = value; } }
		 
		internal static global::System.Drawing.Bitmap AlwaysOnTop {
			get { return (global::System.Drawing.Bitmap)global::Plugins.Properties.Resources._ResourceManager.GetObject("AlwaysOnTop", global::Plugins.Properties.Resources.cultureInfo); } }
		 
		internal static global::System.Drawing.Bitmap AlwaysOnTopBlack {
			get { return (global::System.Drawing.Bitmap)global::Plugins.Properties.Resources._ResourceManager.GetObject("AlwaysOnTopBlack", global::Plugins.Properties.Resources.cultureInfo); } }
		 
		internal static global::System.Drawing.Icon Letter_N_blue {
			get { return (global::System.Drawing.Icon)global::Plugins.Properties.Resources._ResourceManager.GetObject("Letter_N_blue", global::Plugins.Properties.Resources.cultureInfo); } }

		internal static global::System.Drawing.Bitmap WHB4_04 {
			get { return (global::System.Drawing.Bitmap)global::Plugins.Properties.Resources._ResourceManager.GetObject("WHB4-04", global::Plugins.Properties.Resources.cultureInfo); } }
	}
}
