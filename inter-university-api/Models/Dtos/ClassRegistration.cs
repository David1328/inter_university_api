using System.ComponentModel.DataAnnotations;

namespace inter_university_api.Models.Dtos
{
    public class ClassRegistration
    {
        [Key]
        private int id;
        private string idSubjet;
        private long idStudent; 

        public int Id { get => id; set => id = value; }
        public string IdSubjet { get => idSubjet; set => idSubjet = value; }
        public long IdStudent { get => idStudent; set => idStudent = value; }
    }
}
