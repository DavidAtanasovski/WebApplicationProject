using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebProjectCore;

namespace WebProjectData
{
    public class ChampionDataSql : IChampData
    {
        private readonly WebProjectDbContext webProjectDbContext;
        public ChampionDataSql(WebProjectDbContext webProjectDbContext)
        {
            this.webProjectDbContext = webProjectDbContext;
        }

        public int Commit()
        {
            return webProjectDbContext.SaveChanges();
        }

        public Champion Create(Champion champion)
        {
            webProjectDbContext.Champions.Add(champion);
            return champion;
        }

        public Champion Delete(int championId)
        {
            var tempChampion = webProjectDbContext.Champions.SingleOrDefault(r => r.Id == championId);
            if (tempChampion != null)
            {
                webProjectDbContext.Champions.Remove(tempChampion);

            }
            return tempChampion;
        }

        public Champion GetChampionById(int championId)
        {
            return webProjectDbContext.Champions.SingleOrDefault(r => r.Id == championId);
        }

        public IEnumerable<Champion> GetChampions(string name = null)
        {
            var param = !string.IsNullOrEmpty(name) ? $"{name}%" : name;
            return webProjectDbContext.Champions.Where(r => string.IsNullOrEmpty(name) || EF.Functions.Like(r.Name, param)).ToList();
        }
    }
}
