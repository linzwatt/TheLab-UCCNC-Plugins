using System;
using System.Reflection;
using AjAhb4QLiU9IFaCBlx4;

namespace To6v38mIOGW2DrO2GSL
{
	internal class d4xrw3mkSRDujrFf6RH
	{
		internal delegate void OQ1bGWmJphSDhwrarG4(object o);

		internal static Module iM8mVn4lTo;

		internal static void WpeHhk7qlF(int typemdt)
		{
			//Discarded unreachable code: IL_0002
			Type type = iM8mVn4lTo.ResolveType(33554432 + typemdt);
			FieldInfo[] fields = type.GetFields();
			foreach (FieldInfo fieldInfo in fields)
			{
				fieldInfo.SetValue(null, (MulticastDelegate)Delegate.CreateDelegate(type, (MethodInfo)iM8mVn4lTo.ResolveMethod(fieldInfo.MetadataToken + 100663296)));
			}
		}

		public d4xrw3mkSRDujrFf6RH() : base() {
			//Discarded unreachable code: IL_0002
			feSgAXQtGpaLrQN7cjx.Lg7HGT6R6e();
		}

		static d4xrw3mkSRDujrFf6RH()
		{
			//Discarded unreachable code: IL_0002
			feSgAXQtGpaLrQN7cjx.Lg7HGT6R6e();
			iM8mVn4lTo = typeof(d4xrw3mkSRDujrFf6RH).Assembly.ManifestModule;
		}
	}
}
