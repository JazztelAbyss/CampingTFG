using DAL.Models;

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
