using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace inter_university_api.Models.Dtos
{
    public class Student
    {
        [Key]
        private int id;
        private string? nameStudent;
        private string? lastName;
        private long document;
        private string? career;
        private string? passwordUser;
        private int typeUser;

        public int Id { get => id; set => id = value; }
        public string? NameStudent { get => nameStudent; set => nameStudent = value; }
        public string? LastName { get => lastName; set => lastName = value; }
        public long Document { get => document; set => document = value; }
        public string? Career { get => career; set => career = value; }
        public string? PasswordUser { get => passwordUser; set => passwordUser = value; }
        public int TypeUser { get => typeUser; set => typeUser = value; }
    }
}
