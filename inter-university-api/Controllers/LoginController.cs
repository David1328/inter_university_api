using inter_university_api.Models.Context;
using inter_university_api.Models.Dtos;
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
    public class LoginController : Controller
    {
        #region variables de conexión
        private interUniversityContext _dbActividadesContext = new interUniversityContext();
        private AnswerAPI response = new AnswerAPI();
        #endregion

        /// <summary>
        /// Verifica si el usuario esta registrado para ingresar a el aplicativo
        /// </summary>
        /// <param name="user_document"></param>
        /// <param name="user_password"></param>
        /// <returns></returns>
        [HttpGet("GetVerifyAccessUser/{user_document}/{user_password}")]
        [SwaggerOperation("Verifica si el usuario esta registrado para ingresar a el aplicativo")]
        public async Task<IActionResult> GetVerifyAccessUser([FromRoute] string user_document, [FromRoute] string user_password)
        {
            try
            {
                var CheckUserExist = await _dbActividadesContext
                    .LoginModel
                    .FromSqlRaw("EXEC [dbo].[sp_getUserForDocumentAndPasword] @idDocumento,@idPassword",
                    new SqlParameter("@idDocumento", user_document),
                    new SqlParameter("@idPassword", user_password))
                    .ToListAsync();

                if (CheckUserExist != null && CheckUserExist.Any())
                {
                    response.Error = "";
                    response.Valido = true;
                    response.data = CheckUserExist;
                    return Ok(response);
                }
                else
                {
                    response.Error = "No tienes un usuario asigando o contraseña incorrecta";
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
        /// Crea un nuevo estudiante
        /// </summary>
        /// <param name="newStudent"></param>
        /// <returns></returns>
        [HttpPost("PostCreateNewStudent")]
        [SwaggerOperation("Crea un nuevo estudiante")]
        public async Task<IActionResult> PostCreateNewStudent([FromBody] Student newStudent)
        {
            try
            {
                var checkStudentExist = await _dbActividadesContext
                    .student
                    .FromSqlRaw("EXEC [dbo].[sp_getUserForDocument] @idDocumento",
                    new SqlParameter("@idDocumento", newStudent.Document))
                    .ToListAsync();
                if (checkStudentExist == null || checkStudentExist?.Count < 1)
                {
                    var successParam = new SqlParameter("@success", SqlDbType.Bit)
                    {
                        Direction = ParameterDirection.Output
                    };
                    await _dbActividadesContext
                    .Database
                    .ExecuteSqlRawAsync("EXEC [dbo].[sp_createNewStudent] @nameStudent, @lastName, @document,@career,@passwordUser,@typeUser,@success OUTPUT",
                    new SqlParameter("@nameStudent", newStudent.NameStudent),
                    new SqlParameter("@lastName", newStudent.LastName),
                    new SqlParameter("@document", newStudent.Document),
                    new SqlParameter("@career", newStudent.Career),
                    new SqlParameter("@passwordUser", newStudent.PasswordUser),
                    new SqlParameter("@typeUser", 1),
                    successParam);
                    bool wasCreated = Convert.ToBoolean(successParam.Value);
                    if (wasCreated)
                    {
                        response.Error = "";
                        response.Valido = true;
                        response.data = "Se creo el estudiante de manera exitosa";
                        return StatusCode(201, response);
                    }
                    else
                    {
                        response.Error = "No se logro crear el usuario";
                        response.Valido = false;
                        response.data = "";
                        return StatusCode(500, response);
                    }

                }
                else
                {
                    response.Error = "Ya existe un usuario con esa cedula";
                    response.Valido = true;
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
    }
}
