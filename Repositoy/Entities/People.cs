using System.ComponentModel.DataAnnotations;

namespace Repository.Entities
{
    public class People
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }    
    }
}
