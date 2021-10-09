using System;
using System.Collections.Generic;
using System.Text;

namespace G2K.AlForsan.Base.Enums
{
    public class ErrorCodes
    {
        public enum ErrorCode
        {
            /// <summary>
            /// Data is valid
            /// </summary>
            None = 0,
            /// <summary>
            /// Unhandled error occurred and doesn't relate to the data itself, used by API HandledCall Only
            /// </summary>
            UnhandledError = 10,
            /// <summary>
            /// Unauthorized
            /// </summary>
            Unauthorized = 11,
            /// <summary>
            /// Data in repository is not exist, usually occurred when selecting data with in existent selector
            /// </summary>
            InExistentData = 100,
            /// <summary>
            /// Field is mandatory even though its missing
            /// </summary>
            MissingField = 101,
            /// <summary>
            /// Field doesn't have the minimum length
            /// </summary>
            SmallLength = 102,
            /// <summary>
            /// Field's length exceeds the maximum length
            /// </summary>
            BigLength = 103,
            /// <summary>
            /// Field is out of valid range
            /// </summary>
            InvalidRange = 104,
            /// <summary>
            /// Field is out of valid range
            /// </summary>
            ExistsBefore = 105,
            /// <summary>
            /// Operation faild to submit
            /// </summary>
            OperationFaild = 106,
            /// <summary>
            /// Invalid license to create a new site
            /// </summary>
            InvalidLicense = 107,
            /// <summary>
            /// Can't change alarm to positive or negative because it is not under inspection
            /// </summary>
            AlarmIsNotUnderInspection = 108,
            /// <summary>
            /// Alarm doesn't has a qr info
            /// </summary>
            AlarmDoesNotHasQRInfo = 109,
            /// <summary>
            /// Requested data not found
            /// </summary>
            NotFound = 110,
            /// <summary>
            /// Duplicated name
            /// </summary>
            DuplicatedName = 111,
            /// <summary>
            /// InActiveUser
            /// </summary>
            InActiveUser = 112,
            /// <summary>
            /// Item exists Before and deleted
            /// </summary>
            ExistsBeforeAndDeleted = 113,
        }
    }
}
