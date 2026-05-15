using System.ComponentModel.DataAnnotations;
namespace Zealand_lokale_booking.Models;

public class Role
{
    public int RoleId { get; set; }
    public string RoleName { get; set; }

    public Role()
    {
    }

    public Role(int roleId, string roleName)
    {
        RoleId = roleId;
        RoleName = roleName;
    }

    public override string ToString()
    {
        return RoleName;
    }
}

//dette klasse bruges kun  i DB 


