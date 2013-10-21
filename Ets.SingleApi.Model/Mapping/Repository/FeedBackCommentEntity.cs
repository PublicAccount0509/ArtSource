// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FeedBackCommentEntity.cs" company="Irdeto">
//   Copyright @ 2013
// </copyright>
// <summary>
//   Class:FeedBackCommentEntity
//   Namespace:Ets.SingleApi.Model.Repository
//   Class Funtion:Represent the class mapping the FeedBackCommentEntity table in the database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Ets.SingleApi.Model.Repository
{
	using System;
		
    /// <summary>
    /// Class:FeedBackCommentEntity
    /// Namespace:Ets.SingleApi.Model.Repository
    /// Class Funtion:Represent the class mapping the FeedBackCommentEntity table in the database.
    /// </summary>
    /// Creator:周超
    /// Creation Date:2013/10/13 14:18:48
    /// Modifier:
    /// Last Modified:
    /// ----------------------------------------------------------------------------------------
    [Serializable]
    public class FeedBackCommentEntity
    {
		#region private member

			/// <summary>
		/// The FeedBackCommentID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int feedBackCommentId;

			/// <summary>
		/// The FeedBackComment
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string feedBackComment;

			/// <summary>
		/// The FeedBackID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private FeedBackEntity feedBack;

		#endregion

		/// <summary>
        /// Initializes a new instance of the <see cref="FeedBackCommentEntity"/> class.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public FeedBackCommentEntity()
        {
			this.feedBackCommentId = 0;
			this.feedBackComment = string.Empty;
		}

		#region public member

			/// <summary>
        /// Gets or sets a value mapping the FeedBackCommentID of FeedBackCommentEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int FeedBackCommentId
		{
            get
            {
                return this.feedBackCommentId;
            }

            set
            {
                this.feedBackCommentId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the FeedBackComment of FeedBackCommentEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string FeedBackComment
		{
            get
            {
                return this.feedBackComment;
            }

            set
            {
                this.feedBackComment = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the FeedBackID of FeedBackCommentEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual FeedBackEntity FeedBack
		{
            get
            {
                return this.feedBack;
            }

            set
            {
                this.feedBack = value;
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

            var castObj = (FeedBackCommentEntity)obj;
            return this.FeedBackCommentId == castObj.FeedBackCommentId;
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
			hash = 27 * hash * this.FeedBackCommentId.GetHashCode();
			return hash;
		}
	}
}