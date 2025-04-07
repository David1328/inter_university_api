using inter_university_api.Models.Context;
using inter_university_api.Models.Dtos;
using inter_university_api.Models.Others;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;

namespace inter_university_api.Controllers
{
    [EnableCors("AllowAllOrigins")]
    [ApiController]
    [Route("api/[controller]")]
    public class SubjetController : Controller
    {
        /// <summary>
        /// Metodo para obtener las clases por agregar
        /// </summary>
        /// <param name="documentStudent"></param>
        /// <returns></returns>
        [HttpGet("GetSubjetForAdd/{documentStudent}")]
        [SwaggerOperation("Metodo para obtener las clases por agregar")]
        public async Task<IActionResult> GetSubjetForAdd([FromRoute] long documentStudent)
        {
            interUniversityContext _dbActividadesContext = new interUniversityContext();
            AnswerAPI response = new AnswerAPI();
            try
            {
                var registedSubjetsForStudent = await _dbActividadesContext
                    .subjets
                    .FromSqlRaw("EXEC [dbo].[sp_registedSubjet] @idStudent", new SqlParameter("@idStudent", documentStudent))
                    .ToListAsync();

                var allSubjets = await _dbActividadesContext
                    .subjets
                    .FromSqlRaw("EXEC [dbo].[sp_allSubjets]")
                    .ToListAsync();
                if (registedSubjetsForStudent != null && registedSubjetsForStudent.Any())
                {
                    var registeredIds = registedSubjetsForStudent.Select(r => r.SubjectId).ToHashSet();
                    if (registeredIds.Count < 3)
                    {
                        var subjetForAdd = allSubjets
                        .Where(s => !registeredIds.Contains(s.SubjectId))
                        .ToList();
                        response.Error = "";
                        response.Valido = true;
                        response.data = subjetForAdd;
                        return Ok(response);
                    }
                    else
                    {
                        response.Error = "Superaste el numero de creditos";
                        response.Valido = false;
                        response.data = "";
                        return StatusCode(409, response);
                    }

                }
                else
                {
                    response.Error = "";
                    response.Valido = true;
                    response.data = allSubjets;
                    return Ok(response);
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
        /// Metodo para obtener las clases agregadas
        /// </summary>
        /// <param name="documentStudent"></param>
        /// <returns></returns>
        [HttpGet("GetSubjetAsignated/{documentStudent}")]
        [SwaggerOperation("Metodo para obtener las clases agregadas")]
        public async Task<IActionResult> GetSubjetAsignated([FromRoute] long documentStudent)
        {
            interUniversityContext _dbActividadesContext = new interUniversityContext();
            AnswerAPI response = new AnswerAPI();
            try
            {

                var registedSubjetsForStudent = await _dbActividadesContext
                    .subjets
                    .FromSqlRaw("EXEC [dbo].[sp_registedSubjet] @idStudent", new SqlParameter("@idStudent", documentStudent))
                    .ToListAsync();
                if (registedSubjetsForStudent.Count > 0)
                {
                    response.Error = "";
                    response.Valido = true;
                    response.data = registedSubjetsForStudent;
                    return Ok(response);
                }
                else
                {
                    response.Error = "No tienes asiganturas registradas";
                    response.Valido = true;
                    response.data = "";
                    return StatusCode(404, response);
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
        /// Metodo para obtener los compañeros de clase de un estudiante por ID
        /// </summary>
        /// <param name="documentStudent"></param>
        /// <returns></returns>
        [HttpGet("GetClassParnerts/{documentStudent}")]
        [SwaggerOperation("Metodo para obtener los compañeros de clase de un estudiante por ID")]
        public async Task<IActionResult> GetSubjetAsignated([FromRoute] long documentStudent)
        {
            interUniversityContext _dbActividadesContext = new interUniversityContext();
            AnswerAPI response = new AnswerAPI();
            try
            {

                var registedSubjetsForStudent = await _dbActividadesContext
                    .subjets
                    .FromSqlRaw("EXEC [dbo].[sp_registedSubjet] @idStudent", new SqlParameter("@idStudent", documentStudent))
                    .ToListAsync();
                if (registedSubjetsForStudent.Count > 0)
                {
                    response.Error = "";
                    response.Valido = true;
                    response.data = registedSubjetsForStudent;
                    return Ok(response);
                }
                else
                {
                    response.Error = "No tienes asiganturas registradas";
                    response.Valido = true;
                    response.data = "";
                    return StatusCode(404, response);
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
    }
}
