// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LangOptionGroupEntity.cs" company="Irdeto">
//   Copyright @ 2014
// </copyright>
// <summary>
//   Class:LangOptionGroupEntity
//   Namespace:Ets.SingleApi.Model.Repository
//   Class Funtion:Represent the class mapping the LangOptionGroupEntity table in the database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Ets.SingleApi.Model.Repository
{
	using System;
		
    /// <summary>
    /// Class:LangOptionGroupEntity
    /// Namespace:Ets.SingleApi.Model.Repository
    /// Class Funtion:Represent the class mapping the LangOptionGroupEntity table in the database.
    /// </summary>
    /// Creator:周超
    /// Creation Date:2014/8/20 15:03:21
    /// Modifier:
    /// Last Modified:
    /// ----------------------------------------------------------------------------------------
    [Serializable]
    public class LangOptionGroupEntity
    {
		#region private member

			/// <summary>
		/// The OptionGroupTitleEn
        /// </summary>
        /// Creator:周超
        /// Creation Date:2014/8/20 15:03:21
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string optionGroupTitleEn;

			/// <summary>
		/// The DescriptionEn
        /// </summary>
        /// Creator:周超
        /// Creation Date:2014/8/20 15:03:21
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string descriptionEn;

			/// <summary>
		/// The OptionUnitEn
        /// </summary>
        /// Creator:周超
        /// Creation Date:2014/8/20 15:03:21
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string optionUnitEn;

			/// <summary>
		/// The OptionGroupID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2014/8/20 15:03:21
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private OptionGroupEntity optionGroup;

		#endregion

		/// <summary>
        /// Initializes a new instance of the <see cref="LangOptionGroupEntity"/> class.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2014/8/20 15:03:21
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public LangOptionGroupEntity()
        {
			this.optionGroupTitleEn = string.Empty;
			this.descriptionEn = string.Empty;
			this.optionUnitEn = string.Empty;
		}

		#region public member

			/// <summary>
        /// Gets or sets a value mapping the OptionGroupTitleEn of LangOptionGroupEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2014/8/20 15:03:21
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string OptionGroupTitleEn
		{
            get
            {
                return this.optionGroupTitleEn;
            }

            set
            {
                this.optionGroupTitleEn = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the DescriptionEn of LangOptionGroupEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2014/8/20 15:03:21
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string DescriptionEn
		{
            get
            {
                return this.descriptionEn;
            }

            set
            {
                this.descriptionEn = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the OptionUnitEn of LangOptionGroupEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2014/8/20 15:03:21
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string OptionUnitEn
		{
            get
            {
                return this.optionUnitEn;
            }

            set
            {
                this.optionUnitEn = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the OptionGroupID of LangOptionGroupEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2014/8/20 15:03:21
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual OptionGroupEntity OptionGroup
		{
            get
            {
                return this.optionGroup;
            }

            set
            {
                this.optionGroup = value;
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
        /// Creation Date:2014/8/20 15:03:21
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public override bool Equals(object obj)
        {
            if (obj == null || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }

            var castObj = (LangOptionGroupEntity)obj;
			    return this.OptionGroupTitleEn == castObj.OptionGroupTitleEn && this.DescriptionEn == castObj.DescriptionEn
			           && this.OptionUnitEn == castObj.OptionUnitEn;
        }

		/// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        /// Creator:周超
        /// Creation Date:2014/8/20 15:03:21
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public override int GetHashCode()
		{
			var hash = 57; 
			return hash;
		}
	}
}