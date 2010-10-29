// <file>
//     <copyright see="prj:///doc/copyright.txt"/>
//     <license see="prj:///doc/license.txt"/>
//     <owner name="David Srbecký" email="dsrbecky@gmail.com"/>
//     <version>$Revision$</version>
// </file>

// This file is automatically generated - any changes will be lost

#pragma warning disable 1591

namespace Debugger.Wrappers.CorDebug
{
	using System;
	
	
	public partial class ICorDebugChainEnum
	{
		
		private Debugger.Interop.CorDebug.ICorDebugChainEnum wrappedObject;
		
		internal Debugger.Interop.CorDebug.ICorDebugChainEnum WrappedObject
		{
			get
			{
				return this.wrappedObject;
			}
		}
		
		public ICorDebugChainEnum(Debugger.Interop.CorDebug.ICorDebugChainEnum wrappedObject)
		{
			this.wrappedObject = wrappedObject;
			ResourceManager.TrackCOMObject(wrappedObject, typeof(ICorDebugChainEnum));
		}
		
		public static ICorDebugChainEnum Wrap(Debugger.Interop.CorDebug.ICorDebugChainEnum objectToWrap)
		{
			if ((objectToWrap != null))
			{
				return new ICorDebugChainEnum(objectToWrap);
			} else
			{
				return null;
			}
		}
		
		~ICorDebugChainEnum()
		{
			object o = wrappedObject;
			wrappedObject = null;
			ResourceManager.ReleaseCOMObject(o, typeof(ICorDebugChainEnum));
		}
		
		public bool Is<T>() where T: class
		{
			System.Reflection.ConstructorInfo ctor = typeof(T).GetConstructors()[0];
			System.Type paramType = ctor.GetParameters()[0].ParameterType;
			return paramType.IsInstanceOfType(this.WrappedObject);
		}
		
		public T As<T>() where T: class
		{
			try {
				return CastTo<T>();
			} catch {
				return null;
			}
		}
		
		public T CastTo<T>() where T: class
		{
			return (T)Activator.CreateInstance(typeof(T), this.WrappedObject);
		}
		
		public static bool operator ==(ICorDebugChainEnum o1, ICorDebugChainEnum o2)
		{
			return ((object)o1 == null && (object)o2 == null) ||
			       ((object)o1 != null && (object)o2 != null && o1.WrappedObject == o2.WrappedObject);
		}
		
		public static bool operator !=(ICorDebugChainEnum o1, ICorDebugChainEnum o2)
		{
			return !(o1 == o2);
		}
		
		public override int GetHashCode()
		{
			return base.GetHashCode();
		}
		
		public override bool Equals(object o)
		{
			ICorDebugChainEnum casted = o as ICorDebugChainEnum;
			return (casted != null) && (casted.WrappedObject == wrappedObject);
		}
		
		
		public void Skip(uint celt)
		{
			this.WrappedObject.Skip(celt);
		}
		
		public void Reset()
		{
			this.WrappedObject.Reset();
		}
		
		public ICorDebugEnum Clone()
		{
			ICorDebugEnum ppEnum;
			Debugger.Interop.CorDebug.ICorDebugEnum out_ppEnum;
			this.WrappedObject.Clone(out out_ppEnum);
			ppEnum = ICorDebugEnum.Wrap(out_ppEnum);
			return ppEnum;
		}
		
		public uint Count
		{
			get
			{
				uint pcelt;
				this.WrappedObject.GetCount(out pcelt);
				return pcelt;
			}
		}
		
		public uint Next(uint celt, ICorDebugChain[] chains)
		{
			uint pceltFetched;
			Debugger.Interop.CorDebug.ICorDebugChain[] array_chains = new Debugger.Interop.CorDebug.ICorDebugChain[chains.Length];
			for (int i = 0; (i < chains.Length); i = (i + 1))
			{
				if ((chains[i] != null))
				{
					array_chains[i] = chains[i].WrappedObject;
				}
			}
			this.WrappedObject.Next(celt, array_chains, out pceltFetched);
			for (int i = 0; (i < chains.Length); i = (i + 1))
			{
				if ((array_chains[i] != null))
				{
					chains[i] = ICorDebugChain.Wrap(array_chains[i]);
				} else
				{
					chains[i] = null;
				}
			}
			return pceltFetched;
		}
	}
}

#pragma warning restore 1591