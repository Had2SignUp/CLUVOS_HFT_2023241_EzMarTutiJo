using System.Collections.Generic;
using CLUVOS_HFT_2023241.Models;

namespace CLUVOS_HFT_2023241.Logic
{
    public interface ITeamLogic
    {
        void Create(Team item);
        void Delete(int id);
        double GetAverageSalaryInTeam(int teamId);
        Team Read(int id);
        IEnumerable<Team> ReadAll();
        void Update(Team item);
    }
}