// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserFeedbackEntity.cs" company="Irdeto">
//   Copyright @ 2014
// </copyright>
// <summary>
//   Class:UserFeedbackEntity
//   Namespace:Ets.SingleApi.Model.Repository
//   Class Funtion:Represent the class mapping the UserFeedbackEntity table in the database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Ets.SingleApi.Model.Repository
{
	using System;
		
    /// <summary>
    /// Class:UserFeedbackEntity
    /// Namespace:Ets.SingleApi.Model.Repository
    /// Class Funtion:Represent the class mapping the UserFeedbackEntity table in the database.
    /// </summary>
    /// Creator:ww
    /// Creation Date:2014/4/11 11:25:57
    /// Modifier:
    /// Last Modified:
    /// ----------------------------------------------------------------------------------------
    [Serializable]
    public class UserFeedbackEntity
    {
		#region private member

			/// <summary>
		/// The FeedbackId
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/4/11 11:25:57
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int feedbackId;

			/// <summary>
		/// The UserId
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/4/11 11:25:57
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? userId;

			/// <summary>
		/// The IPAddress
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/4/11 11:25:57
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string iPAddress;

			/// <summary>
		/// The Content
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/4/11 11:25:57
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string content;

			/// <summary>
		/// The EmailOrPhone
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/4/11 11:25:57
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string emailOrPhone;

			/// <summary>
		/// The Source
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/4/11 11:25:57
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string source;

			/// <summary>
		/// The Path
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/4/11 11:25:57
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string path;

		#endregion

		/// <summary>
        /// Initializes a new instance of the <see cref="UserFeedbackEntity"/> class.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/4/11 11:25:57
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public UserFeedbackEntity()
        {
			this.feedbackId = 0;
			this.iPAddress = string.Empty;
			this.content = string.Empty;
			this.emailOrPhone = string.Empty;
			this.source = string.Empty;
			this.path = string.Empty;
		}

		#region public member

			/// <summary>
        /// Gets or sets a value mapping the FeedbackId of UserFeedbackEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/4/11 11:25:57
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int FeedbackId
		{
            get
            {
                return this.feedbackId;
            }

            set
            {
                this.feedbackId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the UserId of UserFeedbackEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/4/11 11:25:57
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int? UserId
		{
            get
            {
                return this.userId;
            }

            set
            {
                this.userId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the IPAddress of UserFeedbackEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/4/11 11:25:57
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string IPAddress
		{
            get
            {
                return this.iPAddress;
            }

            set
            {
                this.iPAddress = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the Content of UserFeedbackEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/4/11 11:25:57
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string Content
		{
            get
            {
                return this.content;
            }

            set
            {
                this.content = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the EmailOrPhone of UserFeedbackEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/4/11 11:25:57
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string EmailOrPhone
		{
            get
            {
                return this.emailOrPhone;
            }

            set
            {
                this.emailOrPhone = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the Source of UserFeedbackEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/4/11 11:25:57
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string Source
		{
            get
            {
                return this.source;
            }

            set
            {
                this.source = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the Path of UserFeedbackEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/4/11 11:25:57
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string Path
		{
            get
            {
                return this.path;
            }

            set
            {
                this.path = value;
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
        /// Creation Date:2014/4/11 11:25:57
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public override bool Equals(object obj)
        {
            if (obj == null || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }

            var castObj = (UserFeedbackEntity)obj;
            return this.FeedbackId == castObj.FeedbackId;
        }

		/// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        /// Creator:ww
        /// Creation Date:2014/4/11 11:25:57
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public override int GetHashCode()
		{
			var hash = 57; 
			hash = 27 * hash * this.FeedbackId.GetHashCode();
			return hash;
		}
	}
}