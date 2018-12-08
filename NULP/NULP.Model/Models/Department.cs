using System.Collections.Generic;

namespace NULP.Model.Models
{
    public class Department : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public virtual IList<Person> Persons { get; set; }
    }
}