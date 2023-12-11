using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CLUVOS_HFT_2023241.Models;
using CLUVOS_HFT_2023241.Repository;

namespace CLUVOS_HFT_2023241.Logic
{
    public class LeagueLogic : ILeagueLogic
    {
        IRepository<League> repository;
        public LeagueLogic(IRepository<League> repository)
        {
            this.repository = repository;
        }
        public void Create(League item)
        {
            if (item.Id < 0)
            {
                throw new ArgumentException("The league ID cannot be negative!");
            }
            else
            {
                this.repository.Create(item);
            }
        }
        public League Read(int id)
        {
            var p = this.repository.Read(id);
            if (p == null)
            {
                throw new ArgumentException("Player not exists");
            }
            return p;
        }
        public void Delete(int id)
        {
            this.repository.Delete(id);
        }
        public IEnumerable<League> ReadAll()
        {
            return this.repository.ReadAll();
        }
        public void Update(League item)
        {
            this.repository.Update(item);
        }
        public IEnumerable<YouthSquadInfo> GetYouthSquadInfo()
        { 

            return this.repository.ReadAll()
            .SelectMany(t => t.Teams)
            .GroupBy(t => t.LeagueId)
            .Select(g => new YouthSquadInfo()
            {
                LeagueId = g.Key,
                YouthSquadsInLeague = g.Count(t => t.HasYoungLeagueTeam)
            });

        }
    }
//itt volt a YSI

}
