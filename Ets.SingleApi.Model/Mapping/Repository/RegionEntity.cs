// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RegionEntity.cs" company="Irdeto">
//   Copyright @ 2013
// </copyright>
// <summary>
//   Class:RegionEntity
//   Namespace:Ets.SingleApi.Model.Repository
//   Class Funtion:Represent the class mapping the RegionEntity table in the database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Ets.SingleApi.Model.Repository
{
	using System;
		
    /// <summary>
    /// Class:RegionEntity
    /// Namespace:Ets.SingleApi.Model.Repository
    /// Class Funtion:Represent the class mapping the RegionEntity table in the database.
    /// </summary>
    /// Creator:周超
    /// Creation Date:2013/10/14 11:55:03
    /// Modifier:
    /// Last Modified:
    /// ----------------------------------------------------------------------------------------
    [Serializable]
    public class RegionEntity
    {
		#region private member

			/// <summary>
		/// The Id
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/14 11:55:04
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int id;

			/// <summary>
		/// The Code
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/14 11:55:04
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string code;

			/// <summary>
		/// The Name
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/14 11:55:04
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string name;

			/// <summary>
		/// The ChnName
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/14 11:55:04
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string chnName;

			/// <summary>
		/// The BriefName
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/14 11:55:04
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string briefName;

			/// <summary>
		/// The EnName
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/14 11:55:04
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string enName;

			/// <summary>
		/// The Creator
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/14 11:55:04
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string creator;

			/// <summary>
		/// The CreateDate
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/14 11:55:04
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private DateTime? createDate;

			/// <summary>
		/// The ModifyUser
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/14 11:55:04
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string modifyUser;

			/// <summary>
		/// The ModifyDate
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/14 11:55:04
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private DateTime? modifyDate;

			/// <summary>
		/// The Fid
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/14 11:55:04
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int f;

			/// <summary>
		/// The Provinceid
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/14 11:55:04
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int provinceId;

			/// <summary>
		/// The Cityid
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/14 11:55:04
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int cityId;

			/// <summary>
		/// The Depth
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/14 11:55:04
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int depth;

			/// <summary>
		/// The Isbroad
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/14 11:55:04
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? isbroad;

			/// <summary>
		/// The QPing
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/14 11:55:04
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string qPing;

			/// <summary>
		/// The JPing
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/14 11:55:04
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string jPing;

			/// <summary>
		/// The BriefQPing
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/14 11:55:04
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string briefQPing;

			/// <summary>
		/// The BriefJPing
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/14 11:55:04
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string briefJPing;

			/// <summary>
		/// The IsGov
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/14 11:55:04
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private bool? isGov;

			/// <summary>
		/// The Host
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/14 11:55:04
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string host;

		#endregion

		/// <summary>
        /// Initializes a new instance of the <see cref="RegionEntity"/> class.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/14 11:55:04
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public RegionEntity()
        {
			this.id = 0;
			this.code = string.Empty;
			this.name = string.Empty;
			this.chnName = string.Empty;
			this.briefName = string.Empty;
			this.enName = string.Empty;
			this.creator = string.Empty;
			this.modifyUser = string.Empty;
			this.f = 0;
			this.provinceId = 0;
			this.cityId = 0;
			this.depth = 0;
			this.qPing = string.Empty;
			this.jPing = string.Empty;
			this.briefQPing = string.Empty;
			this.briefJPing = string.Empty;
			this.host = string.Empty;
		}

		#region public member

			/// <summary>
        /// Gets or sets a value mapping the Id of RegionEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/14 11:55:04
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
        /// Gets or sets a value mapping the Code of RegionEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/14 11:55:04
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string Code
		{
            get
            {
                return this.code;
            }

            set
            {
                this.code = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the Name of RegionEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/14 11:55:04
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string Name
		{
            get
            {
                return this.name;
            }

            set
            {
                this.name = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the ChnName of RegionEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/14 11:55:04
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string ChnName
		{
            get
            {
                return this.chnName;
            }

            set
            {
                this.chnName = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the BriefName of RegionEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/14 11:55:04
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string BriefName
		{
            get
            {
                return this.briefName;
            }

            set
            {
                this.briefName = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the EnName of RegionEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/14 11:55:04
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string EnName
		{
            get
            {
                return this.enName;
            }

            set
            {
                this.enName = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the Creator of RegionEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/14 11:55:04
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string Creator
		{
            get
            {
                return this.creator;
            }

            set
            {
                this.creator = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the CreateDate of RegionEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/14 11:55:04
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual DateTime? CreateDate
		{
            get
            {
                return this.createDate;
            }

            set
            {
                this.createDate = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the ModifyUser of RegionEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/14 11:55:04
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string ModifyUser
		{
            get
            {
                return this.modifyUser;
            }

            set
            {
                this.modifyUser = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the ModifyDate of RegionEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/14 11:55:04
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual DateTime? ModifyDate
		{
            get
            {
                return this.modifyDate;
            }

            set
            {
                this.modifyDate = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the Fid of RegionEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/14 11:55:04
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int F
		{
            get
            {
                return this.f;
            }

            set
            {
                this.f = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the Provinceid of RegionEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/14 11:55:04
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int ProvinceId
		{
            get
            {
                return this.provinceId;
            }

            set
            {
                this.provinceId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the Cityid of RegionEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/14 11:55:04
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int CityId
		{
            get
            {
                return this.cityId;
            }

            set
            {
                this.cityId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the Depth of RegionEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/14 11:55:04
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int Depth
		{
            get
            {
                return this.depth;
            }

            set
            {
                this.depth = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the Isbroad of RegionEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/14 11:55:04
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int? Isbroad
		{
            get
            {
                return this.isbroad;
            }

            set
            {
                this.isbroad = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the QPing of RegionEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/14 11:55:04
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string QPing
		{
            get
            {
                return this.qPing;
            }

            set
            {
                this.qPing = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the JPing of RegionEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/14 11:55:04
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string JPing
		{
            get
            {
                return this.jPing;
            }

            set
            {
                this.jPing = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the BriefQPing of RegionEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/14 11:55:04
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string BriefQPing
		{
            get
            {
                return this.briefQPing;
            }

            set
            {
                this.briefQPing = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the BriefJPing of RegionEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/14 11:55:04
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string BriefJPing
		{
            get
            {
                return this.briefJPing;
            }

            set
            {
                this.briefJPing = value;
            }
        }

			/// <summary>
        /// Gets or sets a value indicating whether mapping the IsGov of RegionEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/14 11:55:04
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual bool? IsGov
		{
            get
            {
                return this.isGov;
            }

            set
            {
                this.isGov = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the Host of RegionEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/14 11:55:04
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string Host
		{
            get
            {
                return this.host;
            }

            set
            {
                this.host = value;
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
        /// Creation Date:2013/10/14 11:55:04
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public override bool Equals(object obj)
        {
            if (obj == null || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }

            var castObj = (RegionEntity)obj;
            return this.Id == castObj.Id;
        }

		/// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        /// Creator:周超
        /// Creation Date:2013/10/14 11:55:04
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