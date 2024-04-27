using System.ComponentModel.DataAnnotations;

namespace Labb3_API.Models
{
    public class Link
    {
        [Key]
        public int Id { get; set; }
        public string URL { get; set; }

        public int PersonInterestId { get; set; }
        
        public PersonInterest PersonInterest { get; set; }
    }
}
