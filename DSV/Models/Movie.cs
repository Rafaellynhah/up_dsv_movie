using System.ComponentModel.DataAnnotations;

namespace DSV.Models
{

    public class Movie{
        public int Id { get; set; }

        [StringLength(30, MinimumLength=3)]
        public string Name { get; set; }

        [StringLength(30, MinimumLength=3)]
        public string Category { get; set; }

        [StringLength(100, MinimumLength=5)]
        public string Description { get; set; }
    }



}