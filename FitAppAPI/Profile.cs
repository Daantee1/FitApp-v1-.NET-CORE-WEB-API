using System.ComponentModel.DataAnnotations.Schema;

namespace FitAppAPI
{
    public class Profile
    {
        public int id { get; set; }
        public string gender { get; set; }
        public int age { get; set; }
        public int weight { get; set; } 
        public int height { get; set; }
        public string activity { get; set; }
        public string goal { get; set; }

        [ForeignKey("User")]
        public int userId { get; set; }
       
       

       



    }
}
