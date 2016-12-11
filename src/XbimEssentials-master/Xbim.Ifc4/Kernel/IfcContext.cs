// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool Xbim.CodeGeneration 
//  
//     Changes to this file may cause incorrect behaviour and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------

using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.RepresentationResource;
using System;
using System.Collections.Generic;
using System.Linq;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
//## Custom using statements
//##

namespace Xbim.Ifc4.Interfaces
{
	/// <summary>
    /// Readonly interface for IfcContext
    /// </summary>
	// ReSharper disable once PartialTypeWithSinglePart
	public partial interface @IIfcContext : IIfcObjectDefinition
	{
		IfcLabel? @ObjectType { get;  set; }
		IfcLabel? @LongName { get;  set; }
		IfcLabel? @Phase { get;  set; }
		IItemSet<IIfcRepresentationContext> @RepresentationContexts { get; }
		IIfcUnitAssignment @UnitsInContext { get;  set; }
		IEnumerable<IIfcRelDefinesByProperties> @IsDefinedBy {  get; }
		IEnumerable<IIfcRelDeclares> @Declares {  get; }
	
	}
}

namespace Xbim.Ifc4.Kernel
{
	[ExpressType("IfcContext", 1138)]
	// ReSharper disable once PartialTypeWithSinglePart
	public abstract partial class @IfcContext : IfcObjectDefinition, IIfcContext, IEquatable<@IfcContext>
	{
		#region IIfcContext explicit implementation
		IfcLabel? IIfcContext.ObjectType { 
 
			get { return @ObjectType; } 
			set { ObjectType = value;}
		}	
		IfcLabel? IIfcContext.LongName { 
 
			get { return @LongName; } 
			set { LongName = value;}
		}	
		IfcLabel? IIfcContext.Phase { 
 
			get { return @Phase; } 
			set { Phase = value;}
		}	
		IItemSet<IIfcRepresentationContext> IIfcContext.RepresentationContexts { 
			get { return new Common.Collections.ProxyItemSet<IfcRepresentationContext, IIfcRepresentationContext>( @RepresentationContexts); } 
		}	
		IIfcUnitAssignment IIfcContext.UnitsInContext { 
 
 
			get { return @UnitsInContext; } 
			set { UnitsInContext = value as IfcUnitAssignment;}
		}	
		 
		IEnumerable<IIfcRelDefinesByProperties> IIfcContext.IsDefinedBy {  get { return @IsDefinedBy; } }
		IEnumerable<IIfcRelDeclares> IIfcContext.Declares {  get { return @Declares; } }
		#endregion

		//internal constructor makes sure that objects are not created outside of the model/ assembly controlled area
		internal IfcContext(IModel model, int label, bool activated) : base(model, label, activated)  
		{
			_representationContexts = new OptionalItemSet<IfcRepresentationContext>( this, 0,  8);
		}

		#region Explicit attribute fields
		private IfcLabel? _objectType;
		private IfcLabel? _longName;
		private IfcLabel? _phase;
		private readonly OptionalItemSet<IfcRepresentationContext> _representationContexts;
		private IfcUnitAssignment _unitsInContext;
		#endregion
	
		#region Explicit attribute properties
		[EntityAttribute(5, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, -1, -1, 12)]
		public IfcLabel? @ObjectType 
		{ 
			get 
			{
				if(_activated) return _objectType;
				Activate();
				return _objectType;
			} 
			set
			{
				SetValue( v =>  _objectType = v, _objectType, value,  "ObjectType", 5);
			} 
		}	
		[EntityAttribute(6, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, -1, -1, 13)]
		public IfcLabel? @LongName 
		{ 
			get 
			{
				if(_activated) return _longName;
				Activate();
				return _longName;
			} 
			set
			{
				SetValue( v =>  _longName = v, _longName, value,  "LongName", 6);
			} 
		}	
		[EntityAttribute(7, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, -1, -1, 14)]
		public IfcLabel? @Phase 
		{ 
			get 
			{
				if(_activated) return _phase;
				Activate();
				return _phase;
			} 
			set
			{
				SetValue( v =>  _phase = v, _phase, value,  "Phase", 7);
			} 
		}	
		[EntityAttribute(8, EntityAttributeState.Optional, EntityAttributeType.Set, EntityAttributeType.Class, 1, -1, 15)]
		public IOptionalItemSet<IfcRepresentationContext> @RepresentationContexts 
		{ 
			get 
			{
				if(_activated) return _representationContexts;
				Activate();
				return _representationContexts;
			} 
		}	
		[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, -1, -1, 16)]
		public IfcUnitAssignment @UnitsInContext 
		{ 
			get 
			{
				if(_activated) return _unitsInContext;
				Activate();
				return _unitsInContext;
			} 
			set
			{
				if (value != null && !(ReferenceEquals(Model, value.Model)))
					throw new XbimException("Cross model entity assignment.");
				SetValue( v =>  _unitsInContext = v, _unitsInContext, value,  "UnitsInContext", 9);
			} 
		}	
		#endregion



		#region Inverse attributes
		[InverseProperty("RelatedObjects")]
		[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, 0, -1, 17)]
		public IEnumerable<IfcRelDefinesByProperties> @IsDefinedBy 
		{ 
			get 
			{
				return Model.Instances.Where<IfcRelDefinesByProperties>(e => e.RelatedObjects != null &&  e.RelatedObjects.Contains(this), "RelatedObjects", this);
			} 
		}
		[InverseProperty("RelatingContext")]
		[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, 0, -1, 18)]
		public IEnumerable<IfcRelDeclares> @Declares 
		{ 
			get 
			{
				return Model.Instances.Where<IfcRelDeclares>(e => Equals(e.RelatingContext), "RelatingContext", this);
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
					base.Parse(propIndex, value, nestedIndex); 
					return;
				case 4: 
					_objectType = value.StringVal;
					return;
				case 5: 
					_longName = value.StringVal;
					return;
				case 6: 
					_phase = value.StringVal;
					return;
				case 7: 
					_representationContexts.InternalAdd((IfcRepresentationContext)value.EntityVal);
					return;
				case 8: 
					_unitsInContext = (IfcUnitAssignment)(value.EntityVal);
					return;
				default:
					throw new XbimParserException(string.Format("Attribute index {0} is out of range for {1}", propIndex + 1, GetType().Name.ToUpper()));
			}
		}
		#endregion

		#region Equality comparers and operators
        public bool Equals(@IfcContext other)
	    {
	        return this == other;
	    }
        #endregion

		#region Custom code (will survive code regeneration)
		//## Custom code
		//##
		#endregion
	}
}