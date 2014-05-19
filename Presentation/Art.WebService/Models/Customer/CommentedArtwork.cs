 
﻿using Art.Common;
using Art.Data.Domain;
using System;
using System.Collections.Generic;
using System.IO; 
﻿using Art.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebExpress.Core;

namespace Art.WebService.Models
{
    /// <summary>
    /// 评价过的作品数据
    /// </summary>
    public class CommentedArtworkModel
    {
        /// <summary>
        /// 作品图地址
        /// </summary>
        public string ArtworkImagePath { get; set; }
        /// <summary>
        /// 评论时间
        /// </summary>
        public DateTime CommentDateTime { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; }
    }

    public class CommentedArtworkModelTranslator : TranslatorBase<Comment, CommentedArtworkModel>
    {
        public static readonly CommentedArtworkModelTranslator Instance = new CommentedArtworkModelTranslator();

        public override CommentedArtworkModel Translate(Comment from)
        {
            var to = new CommentedArtworkModel();
            to.Content = from.Text;
            to.CommentDateTime = from.FADateTime;
            var image = from.Artwork.Images.Where(i => i.ImageType == Data.Common.ArtworkImageResizeType.Size_W180_H140).FirstOrDefault();
            if (image != null)
            {
                to.ArtworkImagePath = CommonHelper.GetUploadFileRelativePath_SlantStyle(image.ImagePath);
            }
            return to;
        }

        public override Comment Translate(CommentedArtworkModel from)
        {
            throw new NotImplementedException();
        }
    }
}