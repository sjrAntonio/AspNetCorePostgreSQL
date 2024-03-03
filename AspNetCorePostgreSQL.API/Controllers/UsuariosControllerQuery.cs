using AspNetCorePostgreSQL.API.BusinessRules;
using AspNetCorePostgreSQL.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace CuidandoDoMeuCarro.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UsuariosControllerQuery : ControllerBase
    {

        private readonly UsuariosRulesQuery rules;

        public UsuariosControllerQuery(UsuariosRulesQuery Rules)
        {
            rules = Rules;
        }

        [HttpGet]
        [ProducesResponseType(statusCode: 200, type: typeof(List<Usuario>))]
        [ProducesResponseType(500)]
        public ActionResult GetAllUsers()

        {
            try
            {
                var ret = rules.BuscaTodosUsuarios();
                List<Usuario> result = (ret.Result);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return Problem("User list cannot be displayed because of an error. Message: " + ex.Message);
            }
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(statusCode: 200, type: typeof(List<Usuario>))]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public ActionResult GetUserById(int id)
        {
            try
            {
                var ret = rules.BuscaUsuarioPorId(id);
                List<Usuario> result = (ret.Result);

                if (result.Count() > 0)
                    return Ok(result);
                else
                    return BadRequest("User not found");

            }
            catch (Exception ex)
            {
                return Problem("User cannot be displayed because of an error. Message: " + ex.Message);
            }
        }
    }
}
