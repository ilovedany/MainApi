
using Microsoft.AspNetCore.Mvc;
using MainAPI.Services;
using System.Xml;
namespace MainAPI.Controllers
{
    public class UserController : ControllerBase
    {
        
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route("getUsers/")]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            try
            {
                var users = await _userService.GetUsersAsync(); 
                return Ok(users); 
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("addUser/")]
        public ActionResult<User> AddUser(User user)
        {
            try
            {
                _userService.AddUser(user);
                return Ok(user); 
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete]
        [Route("deleteUser/")]
        public ActionResult<User> DeleteUser(int id)
        {
            try
            {
                _userService.DeleteUser(id);
                return Ok(id); 
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        [Route("putUser/")]
        public ActionResult<User> PutUser(User user)
        {
            try
            {
                _userService.PutUser(user);
                return Ok(user); 
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("getXml/")]
        public ActionResult<string> GetXml(int id)
        {
            try
            {
                var xml = _userService.GetXml(id);
                return Ok(xml); 
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
      
}