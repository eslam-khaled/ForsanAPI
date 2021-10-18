using System;
using System.Collections.Generic;
using System.Text;

namespace G2K.AlForsan.BusinessEnrollement
{
    public class UserEnrollement
    {
        private readonly aeoswsService.AeosWebServiceTypeClient aeoswsServiceClient;
        public UserEnrollement()
        {
            aeoswsServiceClient = new aeoswsService.AeosWebServiceTypeClient(aeoswsService.AeosWebServiceTypeClient.EndpointConfiguration.aeoswsTypePort);
        }
        public void AssignToken()
        {
            //using (aeoswsServiceClient)
            //{
            //    using (var transaction = aeoswsServiceClient. Database.BeginTransaction())
            //    {
            //    }
            //}
        }
    }
}
