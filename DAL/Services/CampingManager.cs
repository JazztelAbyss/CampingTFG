using DAL.Interfaces;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
    public class CampingManager : ICamping
    {
        readonly DBContext _dbContext = new();

        public CampingManager(DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddCamping(Camping camping)
        {
            try
            {
                _dbContext.Campings.Add(camping);
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public Camping GetCampingInfo(string id)
        {
            try
            {
                Camping? camping = _dbContext.Campings.Find(id);
                if (camping != null) 
                {
                    return camping;
                }
                throw new ArgumentNullException();
            }
            catch
            {
                throw;
            }
        }

        public List<Camping> GetCampings()
        {
            try
            {
                return _dbContext.Campings.ToList();
            }
            catch
            {
                throw;
            }
        }

        public void RemoveCamping(string id)
        {
            try
            {
                Camping? camping = _dbContext.Campings.Find(id);
                if(camping != null)
                {
                    _dbContext.Campings.Remove(camping);
                    _dbContext.SaveChanges();
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch
            {
                throw;
            }
        }

        public void UpdateCampingInfo(Camping camping)
        {
            try
            {
                _dbContext.Entry(camping).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
    }
}
