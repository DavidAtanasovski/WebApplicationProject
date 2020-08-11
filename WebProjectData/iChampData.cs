using System;
using System.Collections.Generic;
using System.Text;
using WebProjectCore;

namespace WebProjectData
{
    public interface IChampData
    {
        IEnumerable<Champion> GetChampions(string name = null);

        Champion GetChampionById(int championId);

        Champion Create(Champion champion);

        int Commit();

        Champion Delete(int championId);

        
    }
}
