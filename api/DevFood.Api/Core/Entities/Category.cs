namespace DevFood.Api.Core.Entities
{
    public class Category : BaseEntity
    {
        public Category(string title, string description)
        {
            Title = title;
            Description = description;
        }

        public string Title { get; set; }
        public string Description { get; set; } 
    }
}
