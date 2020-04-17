namespace LearningDataStorage.Core.Models
{
    public class Site
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int MainPageLinkId { get; set; }

        public Link MainPageLink { get; set; }
        
    }
}
