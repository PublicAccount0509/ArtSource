// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SupplierDishImageEntity.cs" company="Irdeto">
//   Copyright @ 2013
// </copyright>
// <summary>
//   Class:SupplierDishImageEntity
//   Namespace:Ets.SingleApi.Model.Repository
//   Class Funtion:Represent the class mapping the SupplierDishImageEntity table in the database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Ets.SingleApi.Model.Repository
{
    using System;

    /// <summary>
    /// Class:SupplierDishImageEntity
    /// Namespace:Ets.SingleApi.Model.Repository
    /// Class Funtion:Represent the class mapping the SupplierDishImageEntity table in the database.
    /// </summary>
    /// Creator:周超
    /// Creation Date:2013/11/3 16:23:26
    /// Modifier:
    /// Last Modified:
    /// ----------------------------------------------------------------------------------------
    [Serializable]
    public class SupplierDishImageEntity
    {
        #region private member

        /// <summary>
        /// The SupplierDishImageID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/11/3 16:23:26
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        private int supplierDishImageId;

        /// <summary>
        /// The SupplierDishID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/11/3 16:23:26
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        private int supplierDishId;

        /// <summary>
        /// The ImagePath
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/11/3 16:23:26
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        private string imagePath;

        /// <summary>
        /// The Online
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/11/3 16:23:26
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        private bool? online;

        /// <summary>
        /// The Position
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/11/3 16:23:26
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        private int position;

        /// <summary>
        /// The Width
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/11/3 16:23:26
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        private int? wIdth;

        /// <summary>
        /// The Height
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/11/3 16:23:26
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        private int? height;

        /// <summary>
        /// The DateAdded
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/11/3 16:23:26
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        private DateTime? dateAdded;

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="SupplierDishImageEntity"/> class.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/11/3 16:23:26
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public SupplierDishImageEntity()
        {
            this.supplierDishImageId = 0;
            this.supplierDishId = 0;
            this.imagePath = string.Empty;
            this.position = 0;
        }

        #region public member

        /// <summary>
        /// Gets or sets a value mapping the SupplierDishImageID of SupplierDishImageEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/11/3 16:23:26
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public virtual int SupplierDishImageId
        {
            get
            {
                return this.supplierDishImageId;
            }

            set
            {
                this.supplierDishImageId = value;
            }
        }

        /// <summary>
        /// Gets or sets a value mapping the SupplierDishID of SupplierDishImageEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/11/3 16:23:26
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public virtual int SupplierDishId
        {
            get
            {
                return this.supplierDishId;
            }

            set
            {
                this.supplierDishId = value;
            }
        }

        /// <summary>
        /// Gets or sets a value mapping the ImagePath of SupplierDishImageEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/11/3 16:23:26
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public virtual string ImagePath
        {
            get
            {
                return this.imagePath;
            }

            set
            {
                this.imagePath = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether mapping the Online of SupplierDishImageEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/11/3 16:23:26
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public virtual bool? Online
        {
            get
            {
                return this.online;
            }

            set
            {
                this.online = value;
            }
        }

        /// <summary>
        /// Gets or sets a value mapping the Position of SupplierDishImageEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/11/3 16:23:26
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public virtual int Position
        {
            get
            {
                return this.position;
            }

            set
            {
                this.position = value;
            }
        }

        /// <summary>
        /// Gets or sets a value mapping the Width of SupplierDishImageEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/11/3 16:23:26
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public virtual int? WIdth
        {
            get
            {
                return this.wIdth;
            }

            set
            {
                this.wIdth = value;
            }
        }

        /// <summary>
        /// Gets or sets a value mapping the Height of SupplierDishImageEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/11/3 16:23:26
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public virtual int? Height
        {
            get
            {
                return this.height;
            }

            set
            {
                this.height = value;
            }
        }

        /// <summary>
        /// Gets or sets a value mapping the DateAdded of SupplierDishImageEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/11/3 16:23:26
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public virtual DateTime? DateAdded
        {
            get
            {
                return this.dateAdded;
            }

            set
            {
                this.dateAdded = value;
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
        /// Creation Date:2013/11/3 16:23:26
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public override bool Equals(object obj)
        {
            if (obj == null || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }

            var castObj = (SupplierDishImageEntity)obj;
            return this.SupplierDishImageId == castObj.SupplierDishImageId;
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        /// Creator:周超
        /// Creation Date:2013/11/3 16:23:26
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public override int GetHashCode()
        {
            var hash = 57;
            hash = 27 * hash * this.SupplierDishImageId.GetHashCode();
            return hash;
        }
    }
}