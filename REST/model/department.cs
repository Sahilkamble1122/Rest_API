namespace REST.model
{
    public class department
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public ICollection<Employee>? Employees { get; set; }
    }
}
