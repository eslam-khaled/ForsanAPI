
using aeoswsService;
using G2K.AlForsan.BusinessManager.BusinessInterface;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.ServiceModel.Security;
using System.Text;
using System.Threading.Tasks;
using static G2K.AlForsan.Base.DTOs.CarrierIdentifierDataDto;
using static G2K.AlForsan.Base.DTOs.EmployeeInfoDto;

namespace G2K.AlForsan.BusinessManager.BusinessImplementation
{

    public class UserBusiness : IUserBusiness
    {
        private readonly aeoswsService.AeosWebServiceTypeClient aeoswsServiceClient;
        public UserBusiness()
        {
            aeoswsServiceClient = new aeoswsService.AeosWebServiceTypeClient(aeoswsService.AeosWebServiceTypeClient.EndpointConfiguration.aeoswsTypePort);
            aeoswsServiceClient.ClientCredentials.UserName.UserName = "admin";
            aeoswsServiceClient.ClientCredentials.UserName.Password = "Grolle@nedap1";

            aeoswsServiceClient.ClientCredentials.ServiceCertificate.SslCertificateAuthentication =
            new X509ServiceCertificateAuthentication()
            {
                CertificateValidationMode = X509CertificateValidationMode.None,
                RevocationMode = System.Security.Cryptography.X509Certificates.X509RevocationMode.NoCheck
            };
        }

        public bool AddEmployee(EmployeeInfoRequest addEmployeeObj)
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
        }

        public bool assignToken(CarrierIdentifierRequestDto carrierIdentifierRequestDto)
        {
            CarrierIdentifierData carrierIdentifierData = new CarrierIdentifierData()
            {
                CarrierId = carrierIdentifierRequestDto.carrierIdField,
                BadgeNumber = carrierIdentifierRequestDto.badgeNumberField
            };

            // This is a Lookup
            var response = aeoswsServiceClient.findIdentifierType(new IdentifierTypeInfo { Id = carrierIdentifierData.CarrierId });
            carrierIdentifierData.IdentifierType = response[0].Id;
            var result = aeoswsServiceClient.assignToken(carrierIdentifierData);
            return true;
        }

        public bool changeCarrierProfile()
        {
            List<UnitOfAuthType> unitOfAuthTypeList = new List<UnitOfAuthType>();
            TemplateSearchInfo templateSearchInfo = new TemplateSearchInfo()
            {

                TemplateInfo = new TemplateInfo()
                {

                    Name = "Full Access",

                    UnitOfAuthType = (UnitOfAuthType)(int)UnitOfAuthType.OnLine
                }
            };

            var temp = aeoswsServiceClient.findTemplate(templateSearchInfo);

            ProfileInfo profileInfo = new ProfileInfo()
            {

            };
            TemplateAuthorisationOnline[] templateAuthorisationOnlineArray = new TemplateAuthorisationOnline[1];
            TemplateAuthorisationOnline templateAuthorisationOnline = new TemplateAuthorisationOnline
            {
                Enabled = true,
                TemplateId = temp[0].Id,
                DateFrom = DateTime.Now,
                DateUntil = DateTime.Now.AddYears(1)
            };
            templateAuthorisationOnlineArray[0] = templateAuthorisationOnline;

            AuthorisationOnline authorisationOnline = new AuthorisationOnline()
            {
                TemplateAuthorisation = templateAuthorisationOnlineArray
            };
            profileInfo.AuthorisationOnline = authorisationOnline;
            profileInfo.CarrierId = 115;

            var result = aeoswsServiceClient.changeCarrierProfile(profileInfo);
            return true;
        }

        public bool findCarrierProfile(long CarrierId)
        {
            var result = aeoswsServiceClient.findCarrierProfile(CarrierId);
            return true;
        }
        public bool AddVisitor()
        {

            VisitorInfo visitorInfo = new VisitorInfo()
            {
                Approvee = true,
                ArrivalDateTime = DateTime.Now,
                CarrierType = "Visitor",
                Company = "G2K",
                ContactPersonId = 115,
                FirstName = "eslam",
                Gender = "Male",
                LastName = "khaled",
                Language = "Ar",
                LeaveDateTime = DateTime.Now.AddYears(1),
                Title = "Eng",
               
            };
            var result = aeoswsServiceClient.addVisitor(visitorInfo);
            return true;
        }


    }
}
