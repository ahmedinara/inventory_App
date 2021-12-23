using IMS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Core.Repository
{
   public interface IWebHookRepository
    {
        #region Add
        Task<WebHook> AddWebHook(WebHook webHook);
        #endregion

        #region Get
        Task<IEnumerable<WebHook>> GetWebHook();
        #endregion
    }
}
