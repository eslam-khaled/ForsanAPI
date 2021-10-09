using System;
using System.Collections.Generic;
using System.Text;
using static G2K.AlForsan.Base.DTOs.BaseDto;

namespace G2K.AlForsan.Base.DTOs
{
    public class CarrierIdentifierDataDto
    {
        public class CarrierIdentifierRequestDto: BaseRequestDto
        {
            public long carrierIdField;

            public long identifierTypeField;

            public string badgeNumberField;

            public long unitIdField;

            public bool unitIdFieldSpecified;
        }

        public class assignTokenResponseDto : BaseResponseDto
        {
            public long idField;

            public long identifierTypeField;

            public string badgeNumberField;

            public bool blockedField;

            public bool replacedField;

            public bool replacedFieldSpecified;

            public long replacedByField;

            public bool replacedByFieldSpecified;

            public System.DateTime dateBlockedField;

            public bool dateBlockedFieldSpecified;

            public long blockReasonField;

            public bool blockReasonFieldSpecified;

            public int statusField;

            public bool statusFieldSpecified;

            public long unitIdField;

            public bool unitIdFieldSpecified;
        }

    }
}
