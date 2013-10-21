// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MenuLayoutStyleEntity.cs" company="Irdeto">
//   Copyright @ 2013
// </copyright>
// <summary>
//   Class:MenuLayoutStyleEntity
//   Namespace:Ets.SingleApi.Model.Repository
//   Class Funtion:Represent the class mapping the MenuLayoutStyleEntity table in the database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Ets.SingleApi.Model.Repository
{
	using System;
	using System.Collections.Generic;
		
    /// <summary>
    /// Class:MenuLayoutStyleEntity
    /// Namespace:Ets.SingleApi.Model.Repository
    /// Class Funtion:Represent the class mapping the MenuLayoutStyleEntity table in the database.
    /// </summary>
    /// Creator:周超
    /// Creation Date:2013/10/13 14:18:48
    /// Modifier:
    /// Last Modified:
    /// ----------------------------------------------------------------------------------------
    [Serializable]
    public class MenuLayoutStyleEntity
    {
		#region private member

			/// <summary>
		/// The Id
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int id;

			/// <summary>
		/// The Name
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string name;

			/// <summary>
		/// The DishNumber
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private byte dishNumber;

			/// <summary>
		/// The CreateTime
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private DateTime? createTime;

			/// <summary>
		/// The ImgUrlX
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string imgUrlX;

			/// <summary>
		/// The ImgUrlZ
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string imgUrlZ;

			/// <summary>
		/// The ImgUrlD
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string imgUrlD;

			/// <summary>
		/// The MenuLayoutSupplierList
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private IList<MenuLayoutSupplierEntity> menuLayoutSupplierList;

		#endregion

		/// <summary>
        /// Initializes a new instance of the <see cref="MenuLayoutStyleEntity"/> class.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public MenuLayoutStyleEntity()
        {
			this.id = 0;
			this.name = string.Empty;
			this.dishNumber = 1;
			this.imgUrlX = string.Empty;
			this.imgUrlZ = string.Empty;
			this.imgUrlD = string.Empty;
		}

		#region public member

			/// <summary>
        /// Gets or sets a value mapping the Id of MenuLayoutStyleEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
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
        /// Gets or sets a value mapping the Name of MenuLayoutStyleEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
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
        /// Gets or sets a value mapping the DishNumber of MenuLayoutStyleEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual byte DishNumber
		{
            get
            {
                return this.dishNumber;
            }

            set
            {
                this.dishNumber = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the CreateTime of MenuLayoutStyleEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual DateTime? CreateTime
		{
            get
            {
                return this.createTime;
            }

            set
            {
                this.createTime = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the ImgUrlX of MenuLayoutStyleEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string ImgUrlX
		{
            get
            {
                return this.imgUrlX;
            }

            set
            {
                this.imgUrlX = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the ImgUrlZ of MenuLayoutStyleEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string ImgUrlZ
		{
            get
            {
                return this.imgUrlZ;
            }

            set
            {
                this.imgUrlZ = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the ImgUrlD of MenuLayoutStyleEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string ImgUrlD
		{
            get
            {
                return this.imgUrlD;
            }

            set
            {
                this.imgUrlD = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the MenuLayoutSupplierList of MenuLayoutStyleEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual IList<MenuLayoutSupplierEntity> MenuLayoutSupplierList
		{
            get
            {
                return this.menuLayoutSupplierList;
            }

            set
            {
                this.menuLayoutSupplierList = value;
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
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public override bool Equals(object obj)
        {
            if (obj == null || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }

            var castObj = (MenuLayoutStyleEntity)obj;
            return this.Id == castObj.Id;
        }

		/// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
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