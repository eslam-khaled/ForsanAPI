
using System.Threading.Tasks;
using static G2K.AlForsan.Base.DTOs.CarrierIdentifierDataDto;
using static G2K.AlForsan.Base.DTOs.EmployeeInfoDto;

namespace G2K.AlForsan.BusinessManager.BusinessInterface
{
    public interface IUserBusiness
    {
        bool AddEmployee(EmployeeInfoRequest addEmployeeObj);
        bool assignToken(CarrierIdentifierRequestDto carrierIdentifierRequestDto);
        bool changeCarrierProfile();
        bool AddVisitor();
        bool findCarrierProfile(long CarrierId);
    }
}
