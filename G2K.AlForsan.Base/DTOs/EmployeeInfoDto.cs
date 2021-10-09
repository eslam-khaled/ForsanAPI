using System;
using System.Collections.Generic;
using System.Text;
using static G2K.AlForsan.Base.DTOs.BaseDto;

namespace G2K.AlForsan.Base.DTOs
{
    public class EmployeeInfoDto
    {

        public class EmployeeInfoRequest : BaseRequestDto
        {
            public string LastName { get; set; }
            public string PersonalNumber { get; set; }
            public DateTime arrivalDateTimeField = DateTime.Now;
        }

        public class EmployeeInfoResponse : BaseResponseDto
        {
            public long contactPersonIdField;

            public bool contactPersonIdFieldSpecified;

            public long departmentIdField;

            public bool departmentIdFieldSpecified;
        }
    }
}
