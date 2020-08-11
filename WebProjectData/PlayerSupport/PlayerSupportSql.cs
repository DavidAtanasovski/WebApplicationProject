using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebProjectCore.PlayerSupport;

namespace WebProjectData
{
    public class PlayerSupportSql : iPlayerSupport
    {
        private readonly WebProjectDbContext webProjectDbContext;
        public PlayerSupportSql(WebProjectDbContext webProjectDbContext)
        {
            this.webProjectDbContext = webProjectDbContext;
        }

        public int Commit()
        {
            return webProjectDbContext.SaveChanges();
        }

        public PlayerSupport Create(PlayerSupport playerSupport)
        {
            webProjectDbContext.PlayerSupports.Add(playerSupport);

            return playerSupport;
        }

        public PlayerSupport GetPlayerSupportById(int supportId)
        {
            return webProjectDbContext.PlayerSupports.SingleOrDefault(r => r.Id == supportId);
        }

        public IEnumerable<PlayerSupport> GetPlayerSupports(string name = null)
        {
            var param = !string.IsNullOrEmpty(name) ? $"{name}%" : name;
            return webProjectDbContext.PlayerSupports.Where(r => string.IsNullOrEmpty(name) || EF.Functions.Like(r.Username, param)).ToList();
        }
    }
}
