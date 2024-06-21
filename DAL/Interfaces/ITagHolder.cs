using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ITagHolder
    {
        public List<TagHolder> GetCampingTags(string Id);
        public void PostCampingTag(TagHolder tagHolder);
    }
}
