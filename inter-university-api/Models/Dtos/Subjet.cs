using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace inter_university_api.Models.Dtos
{
    public class Subjet
    {
        [Key]
        private int id;
        private string? subjectId;
        private string? nameSubjet;
        private int numCredits;
        private long teacherId;
        private string? teacherName;


        public int Id { get => id; set => id = value; }
        public string? SubjectId { get => subjectId; set => subjectId = value; }
        public string? NameSubjet { get => nameSubjet; set => nameSubjet = value; }
        public int NumCredits { get => numCredits; set => numCredits = value; }
        public long TeacherId { get => teacherId; set => teacherId = value; }
        //[NotMapped]
        public string? TeacherName { get => teacherName; set => teacherName = value; }
    }
}
