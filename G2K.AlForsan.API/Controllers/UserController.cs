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
        public int AddEmployee(EmployeeInfoRequest addEmployeeObj)
        {

            var res = _userBusiness.AddEmployee(addEmployeeObj);


            return 1;
        }

        [HttpPost]
        [Route("assignToken")]
        public bool assignTokenAsync()
        {
            CarrierIdentifierRequestDto carrierIdentifierRequestDto = new CarrierIdentifierRequestDto()
            {
                carrierIdField = 115,
                identifierTypeField = 1,
                badgeNumberField = "115",
                unitIdField = 115,
                unitIdFieldSpecified = true
            };
            return _userBusiness.assignToken(carrierIdentifierRequestDto);
        }

        [HttpPost]
        [Route("changeCarrierProfile")]
        public bool changeCarrierProfile()
        {
            return _userBusiness.changeCarrierProfile();
        }



        [HttpPost]
        [Route("findCarrierProfile")]
        public bool findCarrierProfile(long CarrierId)
        {
            return _userBusiness.findCarrierProfile(CarrierId);
        }

        [HttpPost]
        [Route("AddVisitor")]
        public bool AddVisitor()
        {
            return _userBusiness.AddVisitor();
        }
    }
}
