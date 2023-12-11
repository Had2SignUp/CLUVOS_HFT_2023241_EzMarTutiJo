using System.Collections.Generic;
using CLUVOS_HFT_2023241.Models;

namespace CLUVOS_HFT_2023241.Logic
{
    public interface ILeagueLogic
    {
        void Create(League item);
        void Delete(int id);
        IEnumerable<YouthSquadInfo> GetYouthSquadInfo();
        League Read(int id);
        IEnumerable<League> ReadAll();
        void Update(League item);
    }
}