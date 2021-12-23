using System;
using System.Collections.Generic;
using System.Text;

namespace RfIDAicTec.Shared
{
    public enum ResponseMessagesEnum
    {
        /// <summary>
        /// validate data 
        /// </summary>
        DataNotValid = 2,
        /// <summary>
        ///request failed 
        /// </summary>
        NoContent = 204,
        /// <summary>
        /// request success 
        /// </summary>
        Ok = 200,
        /// <summary>
        /// user not have permission 
        /// </summary>
        UnAuthorized = 401,
        /// <summary>
        /// exception occurred 
        /// </summary>
        Exception = 400,


    }
}
