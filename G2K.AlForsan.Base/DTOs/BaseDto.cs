using G2K.AlForsan.Base.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace G2K.AlForsan.Base.DTOs
{
    public class BaseDto
    {
        /// <summary>
        /// Request dto object represents an input for API method
        /// </summary>
        public abstract class BaseRequestDto
        {
            public bool Sucess { get; set; }
            public string Message { get; set; }
        }

        /// <summary>
        /// Request dto object represents an output for API method
        /// </summary>
        public abstract class BaseResponseDto
        {
            /// <summary>
            /// Describes the result of the process
            /// </summary>
            public ValidationModel ValidationModel { get; set; }

        }
    }
}
