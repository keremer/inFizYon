// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool Xbim.CodeGeneration 
//  
//     Changes to this file may cause incorrect behaviour and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------

using Xbim.Ifc4.Interfaces;
using System.Collections.Generic;
using System.Linq;
using Xbim.Common;

// ReSharper disable once CheckNamespace
namespace Xbim.Ifc2x3.PlumbingFireProtectionDomain
{
	public partial class @IfcFireSuppressionTerminalType : IIfcFireSuppressionTerminalType
	{

		[CrossSchemaAttribute(typeof(IIfcFireSuppressionTerminalType), 10)]
		Ifc4.Interfaces.IfcFireSuppressionTerminalTypeEnum IIfcFireSuppressionTerminalType.PredefinedType 
		{ 
			get
			{
				//## Custom code to handle enumeration of PredefinedType
				//##
				switch (PredefinedType)
				{
					case IfcFireSuppressionTerminalTypeEnum.BREECHINGINLET:
						return Ifc4.Interfaces.IfcFireSuppressionTerminalTypeEnum.BREECHINGINLET;
					case IfcFireSuppressionTerminalTypeEnum.FIREHYDRANT:
						return Ifc4.Interfaces.IfcFireSuppressionTerminalTypeEnum.FIREHYDRANT;
					case IfcFireSuppressionTerminalTypeEnum.HOSEREEL:
						return Ifc4.Interfaces.IfcFireSuppressionTerminalTypeEnum.HOSEREEL;
					case IfcFireSuppressionTerminalTypeEnum.SPRINKLER:
						return Ifc4.Interfaces.IfcFireSuppressionTerminalTypeEnum.SPRINKLER;
					case IfcFireSuppressionTerminalTypeEnum.SPRINKLERDEFLECTOR:
						return Ifc4.Interfaces.IfcFireSuppressionTerminalTypeEnum.SPRINKLERDEFLECTOR;
					case IfcFireSuppressionTerminalTypeEnum.USERDEFINED:
						//## Optional custom handling of PredefinedType == .USERDEFINED. 
						//##
						return Ifc4.Interfaces.IfcFireSuppressionTerminalTypeEnum.USERDEFINED;
					case IfcFireSuppressionTerminalTypeEnum.NOTDEFINED:
						return Ifc4.Interfaces.IfcFireSuppressionTerminalTypeEnum.NOTDEFINED;
					
					default:
						throw new System.ArgumentOutOfRangeException();
				}
			} 
			set
			{
				//## Custom code to handle setting of enumeration of PredefinedType
				//##
				switch (value)
				{
					case Ifc4.Interfaces.IfcFireSuppressionTerminalTypeEnum.BREECHINGINLET:
						PredefinedType = IfcFireSuppressionTerminalTypeEnum.BREECHINGINLET;
						return;
					case Ifc4.Interfaces.IfcFireSuppressionTerminalTypeEnum.FIREHYDRANT:
						PredefinedType = IfcFireSuppressionTerminalTypeEnum.FIREHYDRANT;
						return;
					case Ifc4.Interfaces.IfcFireSuppressionTerminalTypeEnum.HOSEREEL:
						PredefinedType = IfcFireSuppressionTerminalTypeEnum.HOSEREEL;
						return;
					case Ifc4.Interfaces.IfcFireSuppressionTerminalTypeEnum.SPRINKLER:
						PredefinedType = IfcFireSuppressionTerminalTypeEnum.SPRINKLER;
						return;
					case Ifc4.Interfaces.IfcFireSuppressionTerminalTypeEnum.SPRINKLERDEFLECTOR:
						PredefinedType = IfcFireSuppressionTerminalTypeEnum.SPRINKLERDEFLECTOR;
						return;
					case Ifc4.Interfaces.IfcFireSuppressionTerminalTypeEnum.USERDEFINED:
						PredefinedType = IfcFireSuppressionTerminalTypeEnum.USERDEFINED;
						return;
					case Ifc4.Interfaces.IfcFireSuppressionTerminalTypeEnum.NOTDEFINED:
						PredefinedType = IfcFireSuppressionTerminalTypeEnum.NOTDEFINED;
						return;
					default:
						throw new System.ArgumentOutOfRangeException();
				}
				
			}
		}
	//## Custom code
	//##
	}
}