using inter_university_api.Models.Context;
using inter_university_api.Models.Dtos;
using inter_university_api.Models.Others;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace inter_university_api.Models.Logica_de_Negocio
{
    public class SubjetLogic
    {
        private interUniversityContext _dbActividadesContext = new interUniversityContext();
        private AnswerAPI response = new AnswerAPI();
        public async Task<Subjet?> CanAssinateSubjetAsync(long documentStudent, string idSubjet)
        {
            var registedSubjetsForStudent = await _dbActividadesContext
                    .subjets
                    .FromSqlRaw("EXEC [dbo].[sp_registedSubjet] @idStudent", new SqlParameter("@idStudent", documentStudent))
                    .ToListAsync();

            var allSubjets = await _dbActividadesContext
                .subjets
                .FromSqlRaw("EXEC [dbo].[sp_allSubjets]")
                .ToListAsync();
            //primer validador de superar creditos
            if (registedSubjetsForStudent.Select(r => r.SubjectId).ToHashSet().Count==3)
            {
                return null;
            }
            //validar si ya tiene ese profesor
            var teacherToAssignate = long.Parse(allSubjets.Where(x => x.SubjectId == idSubjet).Select(r=>r.TeacherId).ToHashSet().FirstOrDefault().ToString());
            if (registedSubjetsForStudent.Where(x => x.TeacherId == teacherToAssignate).FirstOrDefault() != null)
            {
                return null;
            }
            else
            {
                return new Subjet { SubjectId = idSubjet, TeacherId = teacherToAssignate };
            }
        }
    }
}
