// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AwardEntity.cs" company="Irdeto">
//   Copyright @ 2013
// </copyright>
// <summary>
//   Class:AwardEntity
//   Namespace:Ets.SingleApi.Model.Repository
//   Class Funtion:Represent the class mapping the AwardEntity table in the database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Ets.SingleApi.Model.Repository
{
	using System;
	using System.Collections.Generic;
		
    /// <summary>
    /// Class:AwardEntity
    /// Namespace:Ets.SingleApi.Model.Repository
    /// Class Funtion:Represent the class mapping the AwardEntity table in the database.
    /// </summary>
    /// Creator:周超
    /// Creation Date:2013/10/13 14:18:47
    /// Modifier:
    /// Last Modified:
    /// ----------------------------------------------------------------------------------------
    [Serializable]
    public class AwardEntity
    {
		#region private member

			/// <summary>
		/// The AwardID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:47
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int awardId;

			/// <summary>
		/// The AwardName
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:47
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string awardName;

			/// <summary>
		/// The AwardDescription
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:47
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string awardDescription;

			/// <summary>
		/// The AwardDate
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:47
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private DateTime awardDate;

			/// <summary>
		/// The AwardSponsor
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:47
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string awardSponsor;

			/// <summary>
		/// The ChefList
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:47
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private IList<ChefEntity> chefList;

		#endregion

		/// <summary>
        /// Initializes a new instance of the <see cref="AwardEntity"/> class.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:47
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public AwardEntity()
        {
			this.awardId = 0;
			this.awardName = string.Empty;
			this.awardDescription = string.Empty;
			this.awardDate = DateTime.Now;
			this.awardSponsor = string.Empty;
		}

		#region public member

			/// <summary>
        /// Gets or sets a value mapping the AwardID of AwardEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:47
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int AwardId
		{
            get
            {
                return this.awardId;
            }

            set
            {
                this.awardId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the AwardName of AwardEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:47
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string AwardName
		{
            get
            {
                return this.awardName;
            }

            set
            {
                this.awardName = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the AwardDescription of AwardEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:47
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string AwardDescription
		{
            get
            {
                return this.awardDescription;
            }

            set
            {
                this.awardDescription = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the AwardDate of AwardEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:47
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual DateTime AwardDate
		{
            get
            {
                return this.awardDate;
            }

            set
            {
                this.awardDate = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the AwardSponsor of AwardEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:47
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string AwardSponsor
		{
            get
            {
                return this.awardSponsor;
            }

            set
            {
                this.awardSponsor = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the ChefList of AwardEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:47
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual IList<ChefEntity> ChefList
		{
            get
            {
                return this.chefList;
            }

            set
            {
                this.chefList = value;
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
        /// Creation Date:2013/10/13 14:18:47
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public override bool Equals(object obj)
        {
            if (obj == null || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }

            var castObj = (AwardEntity)obj;
            return this.AwardId == castObj.AwardId;
        }

		/// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:47
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public override int GetHashCode()
		{
			var hash = 57; 
			hash = 27 * hash * this.AwardId.GetHashCode();
			return hash;
		}
	}
}