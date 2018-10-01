using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WcfService.Views;

namespace WcfService.Controllers
{
    public class Service : IService
    {
        private ValuesView vv = ValuesView.GetInstance();

        public string GetAllData()
        {
            WebOperationContext.Current.OutgoingResponse.ContentType = "text/html";
            return vv.GetValues("0");
        }

        public string GetData(string value)
        {
            WebOperationContext.Current.OutgoingResponse.ContentType = "text/html";
            return vv.GetValues(value);
        }


    }
}
