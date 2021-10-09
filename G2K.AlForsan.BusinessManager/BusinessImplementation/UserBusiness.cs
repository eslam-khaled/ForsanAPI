
using aeoswsService;
using G2K.AlForsan.BusinessManager.BusinessInterface;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static G2K.AlForsan.Base.DTOs.CarrierIdentifierDataDto;
using static G2K.AlForsan.Base.DTOs.EmployeeInfoDto;

namespace G2K.AlForsan.BusinessManager.BusinessImplementation
{

    public class UserBusiness : IUserBusiness
    {
        private readonly aeoswsService.AeosWebServiceTypeClient aeoswsServiceClient;
        //private readonly aeoswsService.AeosWebServiceTypeClient aeoswsServiceClient;

        public UserBusiness()
        {
            aeoswsServiceClient = new aeoswsService.AeosWebServiceTypeClient(aeoswsService.AeosWebServiceTypeClient.EndpointConfiguration.aeoswsTypePort);
            aeoswsServiceClient.ClientCredentials.UserName.UserName = "admin";
            aeoswsServiceClient.ClientCredentials.UserName.Password = "Grolle@nedap1";
            //aeoswsServiceClient.ClientCredentials.ClientCertificate.
        }

        public bool AddEmployee(EmployeeInfoRequest addEmployeeObj)
        {

            //var EndPoint = "https://192.168.0.1/api";
            //var httpClientHandler = new HttpClientHandler();
            //httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, sslPolicyErrors) =>
            //{
            //    return true;
            //};
            //httpClient = new HttpClient(httpClientHandler) { BaseAddress = new Uri(EndPoint) };


            //using (var httpClientHandler = new HttpClientHandler())
            //{
            //    httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
            //    using (var client = new HttpClient(httpClientHandler))
            //    {
            //        // Make your request...
            //    }
            //}

            System.Net.ServicePointManager.ServerCertificateValidationCallback +=
            (se, cert, chain, sslerror) =>
             {
                 aeoswsService.EmployeeInfo employeeInfo = new aeoswsService.EmployeeInfo()
                 {
                     LastName = addEmployeeObj.LastName,
                     PersonnelNo = addEmployeeObj.PersonalNumber,
                     ArrivalDateTime = addEmployeeObj.arrivalDateTimeField,
                     LeaveDateTime = DateTime.Now.AddYears(20)
                 };

                 var result = aeoswsServiceClient.addEmployee(employeeInfo);
                 return true;
             };



            return true;
        }

        public bool assignToken(CarrierIdentifierRequestDto carrierIdentifierRequestDto)
        {
            CarrierIdentifierData carrierIdentifierData = new CarrierIdentifierData()
            {
                CarrierId = carrierIdentifierRequestDto.carrierIdField,
                IdentifierType = carrierIdentifierRequestDto.identifierTypeField,
                BadgeNumber = carrierIdentifierRequestDto.badgeNumberField
            };

            var result = aeoswsServiceClient.assignToken(carrierIdentifierData);
            return true;
        }

        public bool changeCarrierProfile()
        {
            List<UnitOfAuthType> unitOfAuthTypeList = new List<UnitOfAuthType>();
            TemplateSearchInfo templateSearchInfo = new TemplateSearchInfo()
            {
                //SearchRange = new aeosws.SearchRange()
                //{
                //    nrOfRecords = 2,
                //    nrOfRecordsSpecified = true,
                //    startRecordNo = 1
                //},
                TemplateInfo = new TemplateInfo()
                {
                    //Description = "test",
                    Name = "Full Access",
                    //IdSpecified = true,
                    UnitOfAuthType = (UnitOfAuthType)(int)UnitOfAuthType.OnLine
                }
            };

            var temp = aeoswsServiceClient.findTemplate(templateSearchInfo);

            ProfileInfo profileInfo = new ProfileInfo()
            {
                //AuthorisationLoXS = temp,
                //AuthorisationOnline
            };

            var result = aeoswsServiceClient.changeCarrierProfile(profileInfo);
            return true;
        }

        public bool AddVisitor()
        {
            VisitorInfo visitorInfo = new VisitorInfo()
            {

            };
            var result = aeoswsServiceClient.addVisitor(visitorInfo);
            return true;
        }


    }
}
