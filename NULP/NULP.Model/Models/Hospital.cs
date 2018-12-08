using System.Collections.Generic;

namespace NULP.Model.Models
{
    public class Hospital : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public virtual IList<Department> Departments { get; set; }
    }
}