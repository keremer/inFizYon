// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool Xbim.CodeGeneration 
//  
//     Changes to this file may cause incorrect behaviour and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------

using Xbim.Ifc2x3.MeasureResource;
using Xbim.Ifc2x3.ActorResource;
using System;
using System.Collections.Generic;
using System.Linq;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.Interfaces;
using Xbim.Ifc2x3.ConstructionMgmtDomain;
//## Custom using statements
//##

namespace Xbim.Ifc2x3.Interfaces
{
	/// <summary>
    /// Readonly interface for IfcConstructionMaterialResource
    /// </summary>
	// ReSharper disable once PartialTypeWithSinglePart
	public partial interface @IIfcConstructionMaterialResource : IIfcConstructionResource
	{
		IItemSet<IIfcActorSelect> @Suppliers { get; }
		IfcRatioMeasure? @UsageRatio { get;  set; }
	
	}
}

namespace Xbim.Ifc2x3.ConstructionMgmtDomain
{
	[ExpressType("IfcConstructionMaterialResource", 243)]
	// ReSharper disable once PartialTypeWithSinglePart
	public  partial class @IfcConstructionMaterialResource : IfcConstructionResource, IInstantiableEntity, IIfcConstructionMaterialResource, IContainsEntityReferences, IEquatable<@IfcConstructionMaterialResource>
	{
		#region IIfcConstructionMaterialResource explicit implementation
		IItemSet<IIfcActorSelect> IIfcConstructionMaterialResource.Suppliers { 
			get { return new Common.Collections.ProxyItemSet<IfcActorSelect, IIfcActorSelect>( @Suppliers); } 
		}	
		IfcRatioMeasure? IIfcConstructionMaterialResource.UsageRatio { 
 
			get { return @UsageRatio; } 
			set { UsageRatio = value;}
		}	
		 
		#endregion

		//internal constructor makes sure that objects are not created outside of the model/ assembly controlled area
		internal IfcConstructionMaterialResource(IModel model, int label, bool activated) : base(model, label, activated)  
		{
			_suppliers = new OptionalItemSet<IfcActorSelect>( this, 0,  10);
		}

		#region Explicit attribute fields
		private readonly OptionalItemSet<IfcActorSelect> _suppliers;
		private IfcRatioMeasure? _usageRatio;
		#endregion
	
		#region Explicit attribute properties
		[EntityAttribute(10, EntityAttributeState.Optional, EntityAttributeType.Set, EntityAttributeType.Class, 1, -1, 16)]
		public IOptionalItemSet<IfcActorSelect> @Suppliers 
		{ 
			get 
			{
				if(_activated) return _suppliers;
				Activate();
				return _suppliers;
			} 
		}	
		[EntityAttribute(11, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, -1, -1, 17)]
		public IfcRatioMeasure? @UsageRatio 
		{ 
			get 
			{
				if(_activated) return _usageRatio;
				Activate();
				return _usageRatio;
			} 
			set
			{
				SetValue( v =>  _usageRatio = v, _usageRatio, value,  "UsageRatio", 11);
			} 
		}	
		#endregion




		#region IPersist implementation
		public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
		{
			switch (propIndex)
			{
				case 0: 
				case 1: 
				case 2: 
				case 3: 
				case 4: 
				case 5: 
				case 6: 
				case 7: 
				case 8: 
					base.Parse(propIndex, value, nestedIndex); 
					return;
				case 9: 
					_suppliers.InternalAdd((IfcActorSelect)value.EntityVal);
					return;
				case 10: 
					_usageRatio = value.RealVal;
					return;
				default:
					throw new XbimParserException(string.Format("Attribute index {0} is out of range for {1}", propIndex + 1, GetType().Name.ToUpper()));
			}
		}
		#endregion

		#region Equality comparers and operators
        public bool Equals(@IfcConstructionMaterialResource other)
	    {
	        return this == other;
	    }
        #endregion

		#region IContainsEntityReferences
		IEnumerable<IPersistEntity> IContainsEntityReferences.References 
		{
			get 
			{
				if (@OwnerHistory != null)
					yield return @OwnerHistory;
				if (@BaseQuantity != null)
					yield return @BaseQuantity;
				foreach(var entity in @Suppliers)
					yield return entity;
			}
		}
		#endregion

		#region Custom code (will survive code regeneration)
		//## Custom code
		//##
		#endregion
	}
}