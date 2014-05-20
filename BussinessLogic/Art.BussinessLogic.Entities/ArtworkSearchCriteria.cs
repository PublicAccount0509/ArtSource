using Art.Data.Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebExpress.Core;

namespace Art.BussinessLogic.Entities
{
    public class ArtworkSearchCriteria
    {
        public ArtworkSearchCriteria(PagingRequest paging)
        {
            this.PagingRequest = paging;
            this.OrderByItems = new List<OrderByItem<Artwork>>();
        }

        public string NamePart { get; set; }
        public int? ArtworkTypeId { get; set; }
        public int? ArtMaterialId { get; set; }
        public int? ArtistId { get; set; }

        public int? CollectionCustomerId { get; set; }
        public int? PraiseCustomerId { get; set; }

        public int? BeginYear { get; set; }
        public int? EndYear { get; set; }
        public int? ArtworkType { get; set; }
        public int? MinPrice { get; set; }
        public int? MaxPrice { get; set; }

        public IList<OrderByItem<Artwork>> OrderByItems { get; set; }
        public PagingRequest PagingRequest { get; set; }
    }

    public class OrderByItem<TEntity>
    {
        public OrderByItem(Expression<Func<TEntity, object>> keySelector, SortOrder direction)
        {
            KeySelector = keySelector;
            Direction = direction;
        }

        public Expression<Func<TEntity, object>> KeySelector { get; private set; }
        public SortOrder Direction { get; private set; }
    }
     
}
