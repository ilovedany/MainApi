using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MainAPI.Services;
namespace MainAPI.Controllers
{
    public class SpecialistRankController : ControllerBase
    {
        private readonly ISpecialistRankService _specialistRankService;

        public SpecialistRankController(ISpecialistRankService specialistRankService)
        {
            _specialistRankService = specialistRankService;
        }

        [HttpGet]
        [Route("getRank/")]
        public async Task<ActionResult<IEnumerable<SpecialistRank>>> GetRankAsync()
        {
            try
            {
                var users = await _specialistRankService.GetRankAsync(); 
                return Ok(users); 
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("addRank/")]
        public ActionResult<SpecialistRank> AddRank(SpecialistRank specialistRank)
        {
            try
            {
                _specialistRankService.AddRank(specialistRank);
                return Ok(specialistRank.Id_rank); 
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete]
        [Route("deleteRank/")]
        public ActionResult<SpecialistRank> DeleteRank(int id_rank)
        {
            try
            {
                _specialistRankService.DeleteRank(id_rank);
                return Ok(); 
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        [Route("putRank/")]
        public ActionResult<SpecialistRank> PutRank(SpecialistRank specialistRank)
        {
            try
            {
                _specialistRankService.PutRank(specialistRank);
                return Ok(specialistRank); 
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("searchRank/")]
        public ActionResult<SpecialistRank> GetRankToID(int id)
        {
            try
            {
                var users = _specialistRankService.GetRankToID(id); 
                return Ok(users); 
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
