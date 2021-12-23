using IMS.Core.Entities;
using IMS.Core.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Data.Repository
{
   public class WebHookRepository: IWebHookRepository
    {
        private readonly AppDbContext _dbContext;

        public WebHookRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        #region Add
        public async Task<WebHook> AddWebHook(WebHook webHook)
        {
            var entity = await _dbContext.WebHooks.AddAsync(webHook);
            await _dbContext.SaveChangesAsync();
            return entity.Entity;
        }
        #endregion

        #region Get
        public async Task<IEnumerable<WebHook>> GetWebHook()
        {
            return await _dbContext.WebHooks.ToListAsync();
        }
        #endregion
    }
}
