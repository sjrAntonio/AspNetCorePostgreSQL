using AspNetCorePostgreSQL.API.BusinessRules;
using AspNetCorePostgreSQL.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCorePostgreSQL.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UsuariosControllerCommand : ControllerBase
    {
        private readonly UsuariosRulesCommand rules;

        public UsuariosControllerCommand(UsuariosRulesCommand Rules)
        {
            rules = Rules;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public ActionResult DeleteUser(int id)
        {
            try
            {
                var ret = rules.DeletaUsuarioPorId(id);
                bool result = (ret.Result);

                if (result)
                    return Ok("User deleted from database");
                else
                    return BadRequest("User not found");

            }
            catch (Exception ex)
            {
                return Problem("User cannot be deleted because of an error. Message: " + ex.Message);
            }
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public ActionResult InsertUser(Usuario user)
        {
            try
            {
                var ret = rules.InsereUsuario(user);
                bool result = (ret.Result);

                if (result)
                    return Ok("User added to database");
                else
                    return BadRequest("User not created");
            }
            catch (Exception ex)
            {
                return Problem("User cannot be created because of an error. Message: " + ex.Message);
            }
        }

        [HttpPut()]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public ActionResult UpdateUser(Usuario user)
        {
            var ret = rules.AtualizaUsuarioPorId(user);
            bool result = (ret.Result);

            try
            {
                if (result)
                    return Ok("User updated in the database");
                else
                    return BadRequest("User not found");

            }
            catch (Exception ex)
            {
                return Problem("User was not updated in the database because of an error. Message: " + ex.Message);
            }
        }
    }
}
