using System.ComponentModel.DataAnnotations.Schema;

namespace ITI_MVC_Project.Models
{
    [Table("Trainee")]
    public class Trainee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Address { get; set; }
        [Column("dept_id")]
        public int DepartmentId { get; set; }

        [ForeignKey("DepartmentId")]
        public virtual Department Department { get; set; }

        public virtual List<crsResult> CrsResults { get; set; }
    }
}
