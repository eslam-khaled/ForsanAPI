using G2K.AlForsan.BusinessManager.BusinessInterface;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using static G2K.AlForsan.Base.DTOs.EmployeeInfoDto;
using static G2K.AlForsan.Base.DTOs.CarrierIdentifierDataDto;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace G2K.AlForsan.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : APIControllerBase
    {
        private readonly IUserBusiness _userBusiness;
        private readonly IMapper _mapper;

        public UserController(IUserBusiness userBusiness, IMapper mapper)
        {
            _userBusiness = userBusiness;
            _mapper = mapper;
        }


        [HttpPost]
        public int AddUser(EmployeeInfoRequest addEmployeeObj)
        {
            //return await HandledCall(addEmployeeObj, addEmployeeObj.IsValid, () =>
            //{
            //    var response = new EmployeeInfoResponse();
            //    var res = _userBusiness.AddUser(addEmployeeObj); ;
            //    response = _mapper.Map<EmployeeInfoResponse>(res);
            //    return response;
            //}, r => { });
            var res = _userBusiness.AddEmployee(addEmployeeObj);


            return 1;
        }

        [HttpPost]
        [Route("assignToken")]
        public bool assignTokenAsync()
        {
            CarrierIdentifierRequestDto carrierIdentifierRequestDto = new CarrierIdentifierRequestDto()
            {
                carrierIdField = 32,
                identifierTypeField = 32,
                badgeNumberField = "32",
                unitIdField = 32,
                unitIdFieldSpecified = true
            };
            return _userBusiness.assignToken(carrierIdentifierRequestDto);
        }

        [HttpPost]
        [Route("addCarrierAuthorizationsAsync")]
        public bool addCarrierAuthorizationsAsync()
        {
            return _userBusiness.changeCarrierProfile();
        }


    }
}
