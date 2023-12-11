using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CLUVOS_HFT_2023241.Models;

namespace CLUVOS_HFT_2023241.Repository
{
    public class TeamRepository : Repository<Team>,IRepository<Team>
    {
        public TeamRepository(BasketBallDbContext ctx) : base(ctx)
        {

        }
        public override Team Read(int id)
        {
            return this.ctx.Teams.First(t => t.Id == id);
        }
        public override void Update(Team item)
        {
            var old = Read(item.Id);
            foreach (var p in old.GetType().GetProperties())
            {
                if (p.GetAccessors().FirstOrDefault(t => t.IsVirtual) == null)
                {
                    p.SetValue(old, p.GetValue(item));
                }
            }
            ctx.SaveChanges();
        }
    }
}
