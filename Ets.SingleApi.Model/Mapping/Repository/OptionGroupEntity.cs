// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OptionGroupEntity.cs" company="Irdeto">
//   Copyright @ 2013
// </copyright>
// <summary>
//   Class:OptionGroupEntity
//   Namespace:Ets.SingleApi.Model.Repository
//   Class Funtion:Represent the class mapping the OptionGroupEntity table in the database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Ets.SingleApi.Model.Repository
{
	using System;
	using System.Collections.Generic;
		
    /// <summary>
    /// Class:OptionGroupEntity
    /// Namespace:Ets.SingleApi.Model.Repository
    /// Class Funtion:Represent the class mapping the OptionGroupEntity table in the database.
    /// </summary>
    /// Creator:周超
    /// Creation Date:2013/12/25 15:16:51
    /// Modifier:
    /// Last Modified:
    /// ----------------------------------------------------------------------------------------
    [Serializable]
    public class OptionGroupEntity
    {
		#region private member

			/// <summary>
		/// The OptionGroupID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/25 15:16:51
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int optionGroupId;

			/// <summary>
		/// The OptionGroupTitle
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/25 15:16:51
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string optionGroupTitle;

			/// <summary>
		/// The Description
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/25 15:16:51
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string description;

			/// <summary>
		/// The IsMultiple
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/25 15:16:51
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private bool? isMultiple;

			/// <summary>
		/// The CustomizationOptionList
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/25 15:16:51
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private IList<CustomizationOptionEntity> customizationOptionList;

		#endregion

		/// <summary>
        /// Initializes a new instance of the <see cref="OptionGroupEntity"/> class.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/25 15:16:51
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public OptionGroupEntity()
        {
			this.optionGroupId = 0;
			this.optionGroupTitle = string.Empty;
			this.description = string.Empty;
		}

		#region public member

			/// <summary>
        /// Gets or sets a value mapping the OptionGroupID of OptionGroupEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/25 15:16:51
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int OptionGroupId
		{
            get
            {
                return this.optionGroupId;
            }

            set
            {
                this.optionGroupId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the OptionGroupTitle of OptionGroupEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/25 15:16:51
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string OptionGroupTitle
		{
            get
            {
                return this.optionGroupTitle;
            }

            set
            {
                this.optionGroupTitle = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the Description of OptionGroupEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/25 15:16:51
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
        /// Gets or sets a value indicating whether mapping the IsMultiple of OptionGroupEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/25 15:16:51
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual bool? IsMultiple
		{
            get
            {
                return this.isMultiple;
            }

            set
            {
                this.isMultiple = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the CustomizationOptionList of OptionGroupEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/25 15:16:51
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual IList<CustomizationOptionEntity> CustomizationOptionList
		{
            get
            {
                return this.customizationOptionList;
            }

            set
            {
                this.customizationOptionList = value;
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
        /// Creator:周超
        /// Creation Date:2013/12/25 15:16:51
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public override bool Equals(object obj)
        {
            if (obj == null || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }

            var castObj = (OptionGroupEntity)obj;
            return this.OptionGroupId == castObj.OptionGroupId;
        }

		/// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        /// Creator:周超
        /// Creation Date:2013/12/25 15:16:51
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public override int GetHashCode()
		{
			var hash = 57; 
			hash = 27 * hash * this.OptionGroupId.GetHashCode();
			return hash;
		}
	}
}