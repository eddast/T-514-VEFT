namespace template.Models
{
    public class Model
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameDE { get; set; }
        public string Race { get; set; }
        public string RaceDE { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string DescriptionDE { get; set; }
        public int Rarity { get; set; }
        public string DifficultyLevel { get; set; }
        public string DifficultyLevelDE { get; set; }
        public int YearOfRelease { get; set; }
        public string ImageUrl { get; set; }
    }
}