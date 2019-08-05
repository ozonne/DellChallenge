using System.ComponentModel.DataAnnotations;

namespace DellChallenge.D1.Api.Dal
{
    public class Product
    {
        [Required]
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Category { get; set; }
    }
}