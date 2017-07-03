using System;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using Dating.Models;

namespace Dating.Data
{
    public class Profile
    {
        
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Sex { get; set; }

        
        public DateTime DateOfBirth { get; set; }

        [Required]
        public int Height { get; set; }

        [Required]
        public int Weitght { get; set; }

        
        public string Country { get; set; }

        
        public string Town { get; set; }

        
        public RelationType Relationship { get; set; }


        public int Children { get; set; }

        
        public string Sign { get; set; }

        
        public string Ocupation { get; set; }

        
        public string[] Languages { get; set; }

        
        public bool Smoker { get; set; }

        
        public bool Drinker { get; set; }

       
        public string LookingFor { get; set; }

        
        public string Resume { get; set; }


        public string Image { get; set; }


        public string UserId { get; set; }


        public virtual User User { get; set; }
    }
}