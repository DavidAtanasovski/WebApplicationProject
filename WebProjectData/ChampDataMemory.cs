/*using System.Collections.Generic;
using System.Linq;
using WebProjectCore;

namespace WebProjectData
{
    public class ChampDataMemory : IChampData
    {
        private List<Champion> champions;
        

        public ChampDataMemory()
        {
            champions = new List<Champion>
            {
                new Champion
                {
                    Id = 1,
                    Name = "Akali",
                    Overview = "Abandoning the Kinkou Order and her title of the Fist of Shadow, Akali now strikes alone, ready to be the deadly weapon her people need. Though she holds onto all she learned from her master Shen, she has pledged to defend Ionia from its enemies, one kill at a time. Akali may strike in silence, but her message will be heard loud and clear: fear the assassin with no master.",
                    Role = Role.Mid,
                    UltimateName = "PERFECT EXECUTION",
                    UltimateDesc = "Akali leaps in a direction, damaging enemies she strikes.  Re-cast: Akali dashes in a direction, executing all enemies she strikes.",
                   LinkUrl = "https://ddragon.leagueoflegends.com/cdn/img/champion/splash/Akali_0.jpg",
                   VideoUrl = "https://d28xe8vt774jo5.cloudfront.net/champion-abilities/0084/ability_0084_R1.webm"

                },
                new Champion
                {
                    Id = 2,
                    Name = "Braum",
                    Overview = "Blessed with massive biceps and an even bigger heart, Braum is a beloved hero of the Freljord. Every mead hall north of Frostheld toasts his legendary strength, said to have felled a forest of oaks in a single night, and punched an entire mountain into rubble. Bearing an enchanted vault door as his shield, Braum roams the frozen north sporting a mustachioed smile as big as his muscles — a true friend to all those in need.",
                    Role = Role.Support,
                    UltimateName = "GLACIAL FISSURE",
                    UltimateDesc = "Braum slams the ground, knocking up enemies nearby and in a line in front of him. A fissure is left along the line that slows enemies.",
                    LinkUrl = "https://ddragon.leagueoflegends.com/cdn/img/champion/splash/Braum_0.jpg",
                    VideoUrl = "https://d28xe8vt774jo5.cloudfront.net/champion-abilities/0201/ability_0201_R1.webm"

                },
            };
        }

        public int Commit()
        {
            return 0;
        }

        public Champion Create(Champion champion)
        {
            champion.Id = champions.Max(r => r.Id) + 1;
            champions.Add(champion);
            return champion;
        }

        public Champion Delete(int championId)
        {
            var tempRes = champions.SingleOrDefault(r => r.Id == championId);
            if (tempRes != null)
            {
                champions.Remove(tempRes);
            }
            return tempRes;
        }

        public Champion GetChampionById(int championId)
        {
            return champions.SingleOrDefault(r => r.Id == championId);
        }
        public IEnumerable<Champion> GetChampions(string name = null)
        {
            return champions.Where(r => string.IsNullOrEmpty(name) || r.Name.ToLower().StartsWith(name.ToLower())).OrderBy(r => r.Name);
        }
    }
}
*/