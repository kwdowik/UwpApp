using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UwpApp.Models;

namespace UwpApp.DataAccess.Repositories
{
    public class CityRepository : IRepository<City>
    {
        public void Create(City item)
        {
            if (item == null)
            {
                return;
            }
            using (var db = new ApplicationDbContext())
            {
                if (db.Cities.Any(t => t.Id == item.Id))
                {
                    Debug.Write(string.Format("Database already contains item id: {0}.", item.Id));
                    return;
                }
                db.Cities.Add(item);
                db.SaveChanges();
            }
        }

        public async Task Create(List<City> items)
        {
            if (items == null)
            {
                return;
            }
            using (var db = new ApplicationDbContext())
            {
                foreach (var item in items)
                {
                    if (db.Cities.Any(t => t.Id == item.Id))
                    {
                        Debug.Write(string.Format("Database alraedy contains item id: {0}.", item.Id));
                        continue;
                    }
                    await db.Cities.AddAsync(item);
                }
                await db.SaveChangesAsync();
            }
        }

        public async Task Delete(List<City> items)
        {
            using (var db = new ApplicationDbContext())
            {
                foreach (var item in items)
                {
                    if (!db.Cities.Any(t => t.Id == item.Id))
                    {
                        Debug.Write(string.Format("Database doesn't contains item id: {0}.", item.Id));
                        continue;
                    }
                    db.Cities.Remove(item);
                }
                await db.SaveChangesAsync();
            }
        }

        public void Delete(City item)
        {
            using (var db = new ApplicationDbContext())
            {
                if (!db.Cities.Any(t => t.Id == item.Id))
                {
                    Debug.Write(string.Format("Database doesn't contains item id: {0}.", item.Id));
                    return;
                }
                db.Cities.Remove(item);
                db.SaveChanges();
            }
        }

        public async Task<List<City>> ReadAll()
        {
            using(var db = new ApplicationDbContext())
            {
                return await db.Cities.ToListAsync();
            }
        }

        public City Read(string id)
        {
            using (var db = new ApplicationDbContext())
            {
                return db.Cities.FirstOrDefault(t => t.Id == id);
            }
        }

        public async Task Update(List<City> items)
        {
            using (var db = new ApplicationDbContext())
            {
                foreach (var item in items)
                {
                    if (!db.Cities.Any(t => t.Id == item.Id))
                    {
                        Debug.Write(string.Format("Database doesn't contains item id: {0}.", item.Id));
                        continue;
                    }
                    db.Cities.Update(item);
                }
                await db.SaveChangesAsync();
            }
        }

        public void Update(City item)
        {
            using (var db = new ApplicationDbContext())
            {
                if (!db.Cities.Any(t => t.Id == item.Id))
                {
                    Debug.Write(string.Format("Database doesn't contains item id: {0}.", item.Id));
                    return;
                }
                db.Cities.Update(item);
                db.SaveChanges();
            }
        }
    }
}
