using inter_university_api.Models.Context;
using inter_university_api.Models.Dtos;
using inter_university_api.Models.Logica_de_Negocio;
using inter_university_api.Models.Others;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;
using System.Data;

namespace inter_university_api.Controllers
{
    [EnableCors("AllowAllOrigins")]
    [ApiController]
    [Route("api/[controller]")]
    public class ClassRegistrationController : Controller
    {
        /// <summary>
        /// Metodo para asignar clase a un estudiante
        /// </summary>
        /// <param name="ClassToAssignate"></param>
        /// <returns></returns>
        [HttpPost("PostAddSubjet")]
        [SwaggerOperation("Metodo para asignar clase a un estudiante")]
        public async Task<IActionResult> PostAddSubjet([FromBody] ClassRegistration ClassToAssignate)
        {
            interUniversityContext _dbActividadesContext = new interUniversityContext();
            AnswerAPI response = new AnswerAPI();
            try
            {
                var canCreate = await new SubjetLogic().CanAssinateSubjetAsync(ClassToAssignate.IdStudent, ClassToAssignate.IdSubjet);
                if (canCreate != null)
                {
                    var successParam = new SqlParameter("@success", SqlDbType.Bit)
                    {
                        Direction = ParameterDirection.Output
                    };
                    await _dbActividadesContext
                    .Database
                    .ExecuteSqlRawAsync("EXEC [dbo].[sp_assignateSubjetToStudent] @idSubjet, @idStudent, @idTeacher,@success OUTPUT",
                    new SqlParameter("@idSubjet", ClassToAssignate.IdSubjet),
                    new SqlParameter("@idStudent", ClassToAssignate.IdStudent),
                    new SqlParameter("@idTeacher", canCreate.TeacherId),
                    successParam);
                    bool wasCreated = Convert.ToBoolean(successParam.Value);

                    response.Error = "";
                    response.Valido = true;
                    response.data = wasCreated ? "Clase agregada con exito" : "Algo salio mal agregando la clase";
                    return StatusCode(201, response);
                }
                else
                {
                    response.Error = "No puedes tener clase con el mismo docente";
                    response.Valido = false;
                    response.data = "";
                    return StatusCode(409, response);
                }
            }
            catch (Exception ex)
            {
                response.Error = ex.Message + ex.StackTrace;
                response.Valido = false;
                response.data = "";
                return StatusCode(500, response);
            }
        }

        /// <summary>
        /// Metodo para eliminar clase a un estudiante
        /// </summary>
        /// <param name="documentStudent"></param>
        /// <param name="idSubjet"></param>
        /// <returns></returns>
        [HttpDelete("DeleteSubjetToStudent/{documentStudent}/{idSubjet}")]
        [SwaggerOperation("Metodo para eliminar clase a un estudiante")]
        public async Task<IActionResult> DeleteSubjetToStudent([FromRoute] long documentStudent, [FromRoute] string idSubjet)
        {
            interUniversityContext _dbActividadesContext = new interUniversityContext();
            AnswerAPI response = new AnswerAPI();
            try
            {
                var successParam = new SqlParameter("@success", SqlDbType.Bit)
                {
                    Direction = ParameterDirection.Output
                };
                await _dbActividadesContext
                .Database
                .ExecuteSqlRawAsync("EXEC [dbo].[sp_deleteSubjetToStudent] @idSubjet, @idStudent,@success OUTPUT",
                new SqlParameter("@idSubjet", idSubjet),
                new SqlParameter("@idStudent", documentStudent),
                successParam);
                bool wasCreated = Convert.ToBoolean(successParam.Value);
                if (wasCreated)
                {
                    response.Error = "";
                    response.Valido = true;
                    response.data = "Se elimino exitosamente de tu lista la clase";
                    return StatusCode(200, response);
                }
                response.Error = "No se logro eliminar el registro";
                response.Valido = false;
                response.data = "";
                return StatusCode(500, response);
            }
            catch (Exception ex)
            {
                response.Error = ex.Message + ex.StackTrace;
                response.Valido = false;
                response.data = null;
                return StatusCode(500, response);
            }
        }
    }
}
