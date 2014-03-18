using Castle.Services.Transaction;
using Ets.SingleApi.Model.Repository;
using Ets.SingleApi.Services.IRepository;

namespace Ets.SingleApi.Services
{
    /// <summary>
    /// 类名称：EtsWapDingTaiOrderProvider
    /// 命名空间：Ets.SingleApi.Services
    /// 类功能：订台订单
    /// </summary>
    /// 创建者：苏建峰
    /// 创建日期：3/18/2014 12:00 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    [Transactional]
    public class EtsWapDingTaiOrderProvider : DingTaiOrderProvider
    {
        public EtsWapDingTaiOrderProvider(INHibernateRepository<OrderNumberDtEntity> orderNumberDtEntityRepository)
            : base(orderNumberDtEntityRepository)
        {

        }
    }
}
