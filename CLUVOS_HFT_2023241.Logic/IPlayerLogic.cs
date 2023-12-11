using System.Collections.Generic;
using CLUVOS_HFT_2023241.Models;

namespace CLUVOS_HFT_2023241.Logic
{
    public interface IPlayerLogic
    {
        void Create(Player item);
        void Delete(int id);
        IEnumerable<Player> GetPlayersYoungerThanX(int x);
        int GetYoungestPlayerAge();
        int GetYounsterSalaryInfo();
        Player Read(int id);
        IEnumerable<Player> ReadAll();
        void Update(Player item);
    }
}