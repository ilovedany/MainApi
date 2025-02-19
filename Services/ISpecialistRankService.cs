
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MainAPI.Services
{
    public interface ISpecialistRankService
    {
        public Task<IEnumerable<SpecialistRank>> GetRankAsync();
        public void AddRank(SpecialistRank specialistRank);
        public void DeleteRank(int id_rank);
        public void PutRank(SpecialistRank specialistRank);
        public IEnumerable<SpecialistRank> GetRankToID(int id);



    }
}
