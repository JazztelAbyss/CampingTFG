using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
    public class TagHolderManager : ITagHolder
    {
        readonly DBContext _dbContext = new();

        public TagHolderManager(DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<TagHolder> GetCampingTags(string Id)
        {
            try
            {
                return _dbContext.TagHolders.Where(t => t.CampingId == Id).ToList();
            }
            catch
            {
                throw;
            }
        }

        public void PostCampingTag(TagHolder tagHolder)
        {
            try
            {
                _dbContext.TagHolders.Add(tagHolder);
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
            
        }
    }
}
