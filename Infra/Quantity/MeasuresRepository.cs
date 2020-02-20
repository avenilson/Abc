using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abc.Domain.Quantity;
using Microsoft.EntityFrameworkCore;

namespace Abc.Infra.Quantity
{
    public class MeasuresRepository: IMeasuresRepository
    {
        private readonly QuantityDbContext db;
        public MeasuresRepository(QuantityDbContext c)
        {
            db = c;
        }
        public async Task<List<Measure>> Get() //index
        {
            var l = await db.Measures.ToListAsync();
            return l.Select(e => (new Measure(e))).ToList();
        }

        public async Task<Measure> Get(string id) //delete
        {
            var d = await db.Measures.FirstOrDefaultAsync(m => m.Id == id);
            return new Measure(d);
        }

        public async Task Delete(string id) //details
        {
            var d = await db.Measures.FindAsync(id);

            if (d is null) return;

            db.Measures.Remove(d);
            await db.SaveChangesAsync();
        }

        public async Task Add(Measure obj) //create
        {
            db.Measures.Add(obj.Data);
            await db.SaveChangesAsync();
        }

        public async Task Update(Measure obj) //edit post
        {
            var d = await db.Measures.FirstOrDefaultAsync(x=> x.Id ==obj.Data.Id);
            d.Code = obj.Data.Code;
            d.Name = obj.Data.Name;
            d.Definition = obj.Data.Definition;
            d.ValidFrom = obj.Data.ValidFrom;
            d.ValidTo = obj.Data.ValidTo;
            db.Measures.Update(d);
            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!MeasureViewExists(MeasureView.Id))
                //{
                //    return NotFound();
                //}
                //else
                //{
                    throw;
                //}
            }
        }
    }
}
