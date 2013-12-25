// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CustomizationOptionEntity.cs" company="Irdeto">
//   Copyright @ 2013
// </copyright>
// <summary>
//   Class:CustomizationOptionEntity
//   Namespace:Ets.SingleApi.Model.Repository
//   Class Funtion:Represent the class mapping the CustomizationOptionEntity table in the database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Ets.SingleApi.Model.Repository
{
	using System;
		
    /// <summary>
    /// Class:CustomizationOptionEntity
    /// Namespace:Ets.SingleApi.Model.Repository
    /// Class Funtion:Represent the class mapping the CustomizationOptionEntity table in the database.
    /// </summary>
    /// Creator:周超
    /// Creation Date:2013/12/25 15:16:51
    /// Modifier:
    /// Last Modified:
    /// ----------------------------------------------------------------------------------------
    [Serializable]
    public class CustomizationOptionEntity
    {
		#region private member

			/// <summary>
		/// The OptionID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/25 15:16:51
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int optionId;

			/// <summary>
		/// The OptionTitle
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/25 15:16:51
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string optionTitle;

			/// <summary>
		/// The Price
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/25 15:16:51
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private decimal? price;

			/// <summary>
		/// The OptionGroupID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/25 15:16:51
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private OptionGroupEntity optionGroup;

		#endregion

		/// <summary>
        /// Initializes a new instance of the <see cref="CustomizationOptionEntity"/> class.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/25 15:16:51
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public CustomizationOptionEntity()
        {
			this.optionId = 0;
			this.optionTitle = string.Empty;
		}

		#region public member

			/// <summary>
        /// Gets or sets a value mapping the OptionID of CustomizationOptionEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/25 15:16:51
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int OptionId
		{
            get
            {
                return this.optionId;
            }

            set
            {
                this.optionId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the OptionTitle of CustomizationOptionEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/25 15:16:51
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string OptionTitle
		{
            get
            {
                return this.optionTitle;
            }

            set
            {
                this.optionTitle = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the Price of CustomizationOptionEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/25 15:16:51
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual decimal? Price
		{
            get
            {
                return this.price;
            }

            set
            {
                this.price = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the OptionGroupID of CustomizationOptionEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/25 15:16:51
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

            var castObj = (CustomizationOptionEntity)obj;
            return this.OptionId == castObj.OptionId;
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
			hash = 27 * hash * this.OptionId.GetHashCode();
			return hash;
		}
	}
}