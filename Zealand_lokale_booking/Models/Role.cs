using System.ComponentModel.DataAnnotations;

namespace Zealand_lokale_booking.Models
{
    public class Role
    {
        [Key]
        public int RoleId { get; set; }

        [Required]
        public string Name { get; set; } = "";


        public List<User> Users { get; set; } = new List<User>();

        // Default constructor
        public Role() { }

        // Constructor me parametra
        public Role(int roleId, string name)
        {
            RoleId = roleId;
            Name = name;
        }
    }
}


//dette klasse bruges kun  i DB 


