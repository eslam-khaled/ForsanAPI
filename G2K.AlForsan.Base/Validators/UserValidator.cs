using G2K.AlForsan.Base.Base;
using System;
using System.Collections.Generic;
using System.Text;
using static G2K.AlForsan.Base.DTOs.EmployeeInfoDto;

namespace G2K.AlForsan.Base.Validators
{
    public static class UserValidator
    {
        public static ValidationModel IsValid(this EmployeeInfoRequest request)
        {
            return ValidationModel.Valid();
        }
    }
}
