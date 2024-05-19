using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ICamping
    {
        public List<Camping> GetCampings();
        public void AddCamping(Camping camping);
        public void UpdateCampingInfo(Camping camping);
        public Camping GetCampingInfo(string id);
        public void RemoveCamping(string id);
    }
}
