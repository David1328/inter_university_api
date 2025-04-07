using System.ComponentModel.DataAnnotations;

namespace inter_university_api.Models.Dtos
{
    public class ClassParnertsModel
    {
        [Key]
        public int Id { get; set; }
        private string class_name;
        private string teacher_name;
        private string classmate_name;


        public string Class_name { get => class_name; set => class_name = value; }
        public string Teacher_name { get => teacher_name; set => teacher_name = value; }
        public string Classmate_name { get => classmate_name; set => classmate_name = value; }

    }
}
