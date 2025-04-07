using System.ComponentModel.DataAnnotations;

namespace inter_university_api.Models.Dtos
{
    public class Login
    {
        [Key]
        public int Id { get; set; } // Esta será la Primary Key
        private long document;
        private int typeUser;

        public long Document { get => document; set => document = value; }
        public int TypeUser { get => typeUser; set => typeUser = value; }
    }
}
