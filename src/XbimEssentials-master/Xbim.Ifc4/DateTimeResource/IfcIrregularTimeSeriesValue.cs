// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool Xbim.CodeGeneration 
//  
//     Changes to this file may cause incorrect behaviour and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------

using Xbim.Ifc4.MeasureResource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using Xbim.Common.Metadata;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.DateTimeResource;
//## Custom using statements
//##

namespace Xbim.Ifc4.Interfaces
{
	/// <summary>
    /// Readonly interface for IfcIrregularTimeSeriesValue
    /// </summary>
	// ReSharper disable once PartialTypeWithSinglePart
	public partial interface @IIfcIrregularTimeSeriesValue : IPersistEntity
	{
		IfcDateTime @TimeStamp { get;  set; }
		IItemSet<IIfcValue> @ListValues { get; }
	
	}
}

namespace Xbim.Ifc4.DateTimeResource
{
	[ExpressType("IfcIrregularTimeSeriesValue", 609)]
	// ReSharper disable once PartialTypeWithSinglePart
	public  partial class @IfcIrregularTimeSeriesValue : PersistEntity, IInstantiableEntity, IIfcIrregularTimeSeriesValue, IEquatable<@IfcIrregularTimeSeriesValue>
	{
		#region IIfcIrregularTimeSeriesValue explicit implementation
		IfcDateTime IIfcIrregularTimeSeriesValue.TimeStamp { 
 
			get { return @TimeStamp; } 
			set { TimeStamp = value;}
		}	
		IItemSet<IIfcValue> IIfcIrregularTimeSeriesValue.ListValues { 
			get { return new Common.Collections.ProxyItemSet<IfcValue, IIfcValue>( @ListValues); } 
		}	
		 
		#endregion

		//internal constructor makes sure that objects are not created outside of the model/ assembly controlled area
		internal IfcIrregularTimeSeriesValue(IModel model, int label, bool activated) : base(model, label, activated)  
		{
			_listValues = new ItemSet<IfcValue>( this, 0,  2);
		}

		#region Explicit attribute fields
		private IfcDateTime _timeStamp;
		private readonly ItemSet<IfcValue> _listValues;
		#endregion
	
		#region Explicit attribute properties
		[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, -1, -1, 1)]
		public IfcDateTime @TimeStamp 
		{ 
			get 
			{
				if(_activated) return _timeStamp;
				Activate();
				return _timeStamp;
			} 
			set
			{
				SetValue( v =>  _timeStamp = v, _timeStamp, value,  "TimeStamp", 1);
			} 
		}	
		[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.List, EntityAttributeType.Class, 1, -1, 2)]
		public IItemSet<IfcValue> @ListValues 
		{ 
			get 
			{
				if(_activated) return _listValues;
				Activate();
				return _listValues;
			} 
		}	
		#endregion




		#region IPersist implementation
		public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
		{
			switch (propIndex)
			{
				case 0: 
					_timeStamp = value.StringVal;
					return;
				case 1: 
					_listValues.InternalAdd((IfcValue)value.EntityVal);
					return;
				default:
					throw new XbimParserException(string.Format("Attribute index {0} is out of range for {1}", propIndex + 1, GetType().Name.ToUpper()));
			}
		}
		#endregion

		#region Equality comparers and operators
        public bool Equals(@IfcIrregularTimeSeriesValue other)
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