namespace NULP.Model.Models
{
    public class Person : IEntity
    {
        public int Id { get; set; }
        
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string GetFullName()
        {
            return $"{FirstName} {LastName}";
        }
    }
}