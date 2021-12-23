using System;
using System.Collections.Generic;
using System.Text;

namespace RfIDAicTec.Shared
{
    public class RequestResult<T>
    {
        #region Ctors

        private RequestResult()
        {

        }
        /// <summary>
        /// return data
        /// </summary>
        /// <param name="data"></param>
        public RequestResult(T data)
        {
            Data = data;
            IsSuccess = true;
        }
        /// <summary>
        /// return data and page count
        /// </summary>
        /// <param name="data"></param>
        /// <param name="pagesCount"></param>
        public RequestResult(T data, int pagesCount)
        {
            Data = data;
            IsSuccess = true;
            PagesCount = pagesCount;
        }
        /// <summary>
        /// return data and page count and total item count
        /// </summary>
        /// <param name="data"></param>
        /// <param name="totalItemsCount"></param>
        /// <param name="pagesCount"></param>
        public RequestResult(T data, int totalItemsCount, int pagesCount)
        {
            Data = data;
            IsSuccess = true;
            PagesCount = pagesCount;
            TotalItemsCount = totalItemsCount;
        }
        /// <summary>
        /// retun eeror code 
        /// </summary>
        /// <param name="errorCode"></param>
        /// <param name="errorMassage"></param>
        public RequestResult(Enum errorCode, string errorMassage)
        {
            ErrorCode = errorCode;
            IsSuccess = false;
            ErrorMassage = errorMassage;
        }
        /// <summary>
        /// retun exception
        /// </summary>
        /// <param name="errorCode"></param>
        /// <param name="exception"></param>
        public RequestResult(Enum errorCode, Exception exception)
        {
            ErrorCode = errorCode;
            IsSuccess = false;
            Exception = exception;
        }
        /// <summary>
        /// return error code
        /// </summary>
        /// <param name="errorCode"></param>
        public RequestResult(Enum errorCode)
        {
            ErrorCode = errorCode;
            IsSuccess = false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="errorCode"></param>
        public RequestResult(T data, Enum errorCode)
        {
            Data = data;
            ErrorCode = errorCode;
            IsSuccess = true;

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="exception"></param>
        public RequestResult(Exception exception)
        {
            Exception = exception;
            IsSuccess = false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="errorCode"></param>
        public RequestResult(Exception exception, Enum errorCode)
        {
            Exception = exception;
            ErrorCode = errorCode;
            IsSuccess = false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="messageResponse"></param>
        public RequestResult(MessageResponse<T> messageResponse)
        {
            ErrorCode = messageResponse.ErrorCode;
            Data = messageResponse.Data;
            TotalItemsCount = messageResponse.TotalItemsCount;
            IsSuccess = messageResponse.StatusCode == 200;
            ErrorMassage = messageResponse.ExceptionMessage;
        }

        #endregion Ctors
        /// <summary>
        /// data
        /// </summary>
        public T Data { get; set; }
        /// <summary>
        /// page count
        /// </summary>
        public int PagesCount { get; set; } = 0;
        /// <summary>
        /// total item count
        /// </summary>
        public int TotalItemsCount { get; set; } = 0;
        /// <summary>
        /// is success
        /// </summary>
        public bool IsSuccess { get; set; }
        /// <summary>
        /// error code
        /// </summary>
        public Enum ErrorCode { get; set; }
        /// <summary>
        /// exception
        /// </summary>
        public Exception Exception { get; set; }
        /// <summary>
        /// message
        /// </summary>
        public string ErrorMassage { get; set; } = "";

    }


}
