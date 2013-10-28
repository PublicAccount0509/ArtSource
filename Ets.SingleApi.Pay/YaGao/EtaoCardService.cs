using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Ets.SingleApi.Pay.YaGao
{
    public class EtaoCardService : MpiService
    {
        /// <summary>
        /// 获取mpi配置文件地址
        /// </summary>
        /// <returns></returns>
        public override string GetMpiPropPath()
        {
            return _basePath + "MPIPropertiesLoy.xml";
        }

        public override string GetMerchantID()
        {
            return "0000040810";
        }
    }
}