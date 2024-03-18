using Microsoft.AspNetCore.Hosting.Server;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitAppAPI
{
    public class User
    {
        public int id { get; set; }
        public string email { get; set; }
        public string nickname { get; set; }
        public string password { get; set; }

        [ForeignKey("Profile")]
        public int profileId { get; set; }
       
      
    }
}
