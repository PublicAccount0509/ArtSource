// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LangCustomizationOptionEntity.cs" company="Irdeto">
//   Copyright @ 2014
// </copyright>
// <summary>
//   Class:LangCustomizationOptionEntity
//   Namespace:Ets.SingleApi.Model.Repository
//   Class Funtion:Represent the class mapping the LangCustomizationOptionEntity table in the database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Ets.SingleApi.Model.Repository
{
	using System;
		
    /// <summary>
    /// Class:LangCustomizationOptionEntity
    /// Namespace:Ets.SingleApi.Model.Repository
    /// Class Funtion:Represent the class mapping the LangCustomizationOptionEntity table in the database.
    /// </summary>
    /// Creator:周超
    /// Creation Date:2014/8/20 15:00:49
    /// Modifier:
    /// Last Modified:
    /// ----------------------------------------------------------------------------------------
    [Serializable]
    public class LangCustomizationOptionEntity
    {
		#region private member

			/// <summary>
		/// The OptionTitleEn
        /// </summary>
        /// Creator:周超
        /// Creation Date:2014/8/20 15:00:49
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string optionTitleEn;

			/// <summary>
		/// The ValueEn
        /// </summary>
        /// Creator:周超
        /// Creation Date:2014/8/20 15:00:49
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string valueEn;

			/// <summary>
		/// The OptionID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2014/8/20 15:00:49
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private CustomizationOptionEntity option;

		#endregion

		/// <summary>
        /// Initializes a new instance of the <see cref="LangCustomizationOptionEntity"/> class.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2014/8/20 15:00:49
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public LangCustomizationOptionEntity()
        {
			this.optionTitleEn = string.Empty;
			this.valueEn = string.Empty;
		}

		#region public member

			/// <summary>
        /// Gets or sets a value mapping the OptionTitleEn of LangCustomizationOptionEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2014/8/20 15:00:49
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string OptionTitleEn
		{
            get
            {
                return this.optionTitleEn;
            }

            set
            {
                this.optionTitleEn = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the ValueEn of LangCustomizationOptionEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2014/8/20 15:00:49
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string ValueEn
		{
            get
            {
                return this.valueEn;
            }

            set
            {
                this.valueEn = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the OptionID of LangCustomizationOptionEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2014/8/20 15:00:49
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual CustomizationOptionEntity Option
		{
            get
            {
                return this.option;
            }

            set
            {
                this.option = value;
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
        /// Creation Date:2014/8/20 15:00:49
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public override bool Equals(object obj)
        {
            if (obj == null || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }

            var castObj = (LangCustomizationOptionEntity)obj;
            return this.OptionTitleEn == castObj.OptionTitleEn && this.ValueEn == castObj.ValueEn;
        }

		/// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        /// Creator:周超
        /// Creation Date:2014/8/20 15:00:49
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