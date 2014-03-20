// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TableTypeEntity.cs" company="Irdeto">
//   Copyright @ 2014
// </copyright>
// <summary>
//   Class:TableTypeEntity
//   Namespace:Ets.SingleApi.Model.Repository
//   Class Funtion:Represent the class mapping the TableTypeEntity table in the database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Ets.SingleApi.Model.Repository
{
	using System;
	using System.Collections.Generic;
		
    /// <summary>
    /// Class:TableTypeEntity
    /// Namespace:Ets.SingleApi.Model.Repository
    /// Class Funtion:Represent the class mapping the TableTypeEntity table in the database.
    /// </summary>
    /// Creator:ww
    /// Creation Date:2014-3-20 16:37:43
    /// Modifier:
    /// Last Modified:
    /// ----------------------------------------------------------------------------------------
    [Serializable]
    public class TableTypeEntity
    {
		#region private member

			/// <summary>
		/// The Id
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-20 16:37:43
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int id;

			/// <summary>
		/// The TblTypeName
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-20 16:37:43
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string tblTypeName;

			/// <summary>
		/// The SupplierId
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-20 16:37:43
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int supplierId;

			/// <summary>
		/// The Description
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-20 16:37:43
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string description;

			/// <summary>
		/// The DeskTypeList
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-20 16:37:43
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private IList<DeskTypeEntity> deskTypeList;

		#endregion

		/// <summary>
        /// Initializes a new instance of the <see cref="TableTypeEntity"/> class.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-20 16:37:43
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public TableTypeEntity()
        {
			this.id = 0;
			this.tblTypeName = string.Empty;
			this.supplierId = 0;
			this.description = string.Empty;
		}

		#region public member

			/// <summary>
        /// Gets or sets a value mapping the Id of TableTypeEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-20 16:37:43
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int Id
		{
            get
            {
                return this.id;
            }

            set
            {
                this.id = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the TblTypeName of TableTypeEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-20 16:37:43
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string TblTypeName
		{
            get
            {
                return this.tblTypeName;
            }

            set
            {
                this.tblTypeName = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the SupplierId of TableTypeEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-20 16:37:43
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int SupplierId
		{
            get
            {
                return this.supplierId;
            }

            set
            {
                this.supplierId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the Description of TableTypeEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-20 16:37:43
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string Description
		{
            get
            {
                return this.description;
            }

            set
            {
                this.description = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the DeskTypeList of TableTypeEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-20 16:37:43
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual IList<DeskTypeEntity> DeskTypeList
		{
            get
            {
                return this.deskTypeList;
            }

            set
            {
                this.deskTypeList = value;
            }
        }

		#endregion

			/// <summary>
        /// Determines whether the specified is equal to this instance.
        /// </summary>
        /// <param name="obj">The to compare with this instance.</param>
        /// <returns>
        /// true if the specified is equal to this instance; otherwise,false.
        /// </returns>
        /// Creator:ww
        /// Creation Date:2014-3-20 16:37:43
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public override bool Equals(object obj)
        {
            if (obj == null || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }

            var castObj = (TableTypeEntity)obj;
            return this.Id == castObj.Id;
        }

		/// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        /// Creator:ww
        /// Creation Date:2014-3-20 16:37:43
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public override int GetHashCode()
		{
			var hash = 57; 
			hash = 27 * hash * this.Id.GetHashCode();
			return hash;
		}
	}
}