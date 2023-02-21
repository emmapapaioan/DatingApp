using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using API.Extensions;
using Microsoft.AspNetCore.Identity;

namespace API.Entities
{
    public class AppUser
    {
        public int Id { get; set;} 
        public string UserName { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public DateOnly DateOfBirth { get; set;}
        public string KnownAs { get; set; }
        // UtcNow format returns date to utc format which is prefered because we are storing it in the db
        // If we wanted to show the date to tha user we should use DateTime.Now that is a local date format
        public DateTime Created { get; set; } = DateTime.UtcNow; 
        public DateTime LastActive { get; set; } = DateTime.UtcNow;
        public string Gender { get; set; }
        public string Introduction { get; set; }
        public string LookingFor { get; set; }
        public string Interests { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public List<Photo> Photos { get; set; } = new List<Photo>();
        
        // public int GetAge(){
        //     return DateOfBirth.CalculateAge();
        // } 
    }
}