using System;
using System.Collections.Generic;
using System.Text;
using static G2K.AlForsan.Base.Enums.ErrorCodes;

namespace G2K.AlForsan.Base.Base
{
    public class ValidationModel
    {
        /// <summary>
        /// Category of the error if occurred
        /// </summary>
        public ErrorCode ErrorCode { get; internal set; }
        /// <summary>
        /// Field that causes the error
        /// </summary>
        public string SourceField { get; internal set; }
        /// <summary>
        /// Extra error details
        /// </summary>
        public string Error { get; internal set; }

        private ValidationModel()
        {

        }

        /// <summary>
        /// Construct an invalid validation model
        /// </summary>
        /// <param name="errorCode">Error Code</param>
        /// <param name="sourceField">Field that causes the error</param>
        /// <param name="error">Extra error details</param>
        /// <returns>An instance of validation model</returns>
        public static ValidationModel Invalid(ErrorCode errorCode, string sourceField, string error = null)
        {
            return new ValidationModel
            {
                ErrorCode = errorCode,
                SourceField = sourceField,
                Error = error
            };
        }

        public static ValidationModel Exception(string error)
        {
            return new ValidationModel
            {
                ErrorCode = ErrorCode.UnhandledError,
                Error = error
            };
        }

        public static ValidationModel Valid()
        {
            return new ValidationModel
            {
                ErrorCode = ErrorCode.None
            };
        }

    }
}
