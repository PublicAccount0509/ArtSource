namespace Ets.SingleApi.Model.Repository
{
    using System;
    public class ETaoShiLightStatisticsDataModelEntity
    {
        public virtual int id { get; set; }
        public virtual DateTime DeliveryDate { get; set; }
        public virtual int PaymentMethod { get; set; }
        public virtual int IsPaid { get; set; }
        public virtual int CompleteStatus { get; set; }
        public virtual int OrderCount { get; set; }
        public virtual int CustomerTotal { get; set; }
        public virtual int Total { get; set; }
    }
}