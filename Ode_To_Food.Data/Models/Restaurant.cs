using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ode_To_Food.Data.Models
{
    public class Restaurant
    {
        public int Id { get; set; }                                             // After bringing in ComponentModel.DataAnnotations namespace, Data Annotation is available for properties/fields
        [Required]
        
        public string Name { get; set; }                                                    // If Name is not input by user, Validation will not pass/return true in Restaurant controller's post create method
        [Required]
        [Display(Name="Type of Cuisine")]
        public CuisineType Cuisine { get; set; }

    }
}
