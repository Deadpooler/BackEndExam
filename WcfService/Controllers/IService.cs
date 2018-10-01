using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService.Controllers
{
    [ServiceContract]
    public interface IService
    {

        [WebGet(UriTemplate = "/GetValues/{value}", ResponseFormat = WebMessageFormat.Xml)]
        [OperationContract(AsyncPattern =true)]
        string GetData(string value);
        [WebGet(UriTemplate = "/GetValues",ResponseFormat = WebMessageFormat.Xml)]
        [OperationContract(AsyncPattern = true)]
        string GetAllData();
    }
    
}
