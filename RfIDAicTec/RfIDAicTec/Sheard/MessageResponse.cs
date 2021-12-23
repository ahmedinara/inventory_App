using System;
using System.Collections.Generic;
using System.Text;

namespace RfIDAicTec.Shared
{
    public class MessageResponse<T>
    {
        /// <summary>
        /// Status Code
        /// </summary>
        public int StatusCode { get; set; }
        /// <summary>
        /// Data
        /// </summary>
        public T Data { get; set; }
        /// <summary>
        ///  error code 
        /// </summary>
        public Enum ErrorCode { get; set; }
        /// <summary>
        /// exception
        /// </summary>
        public string ExceptionMessage { get; set; }
        /// <summary>
        /// total item cont 
        /// </summary>
        public int TotalItemsCount { get; set; }
        /// <summary>
        /// page count 
        /// </summary>
        public int PagesCount { get; set; } = 0;
    }
}
