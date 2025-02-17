using System.ComponentModel.DataAnnotations;
using Bogus;

namespace GetriWebApi.Models
{
    public class Activity
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Venue { get; set; }
    }

    public class ActivitySeeder
    {
        public List<Activity> GenerateMockData()
        {
            return new List<Activity>
            {
                new Activity
                {
                    Id = new Guid("13d5fd5b-5168-49cf-b8b6-a79fd6d65457"),
                    Title = "Music Concert: Rock Legends",
                    Date = new DateTime(2025, 5, 15, 19, 30, 0),
                    Description = "Join us for an unforgettable night of classic rock music with top bands.",
                    Category = "Music",
                    City = "New York",
                    Venue = "Madison Square Garden"
                },
                new Activity
                {
                    Id = new Guid("7f1d989e-c19a-4445-91c2-1f4e22cb2805"),
                    Title = "Art Exhibition: Modern Masterpieces",
                    Date = new DateTime(2025, 6, 1, 10, 0, 0),
                    Description = "Explore the world of contemporary art with works from renowned artists.",
                    Category = "Art",
                    City = "San Francisco",
                    Venue = "SFMOMA"
                },
                new Activity
                {
                    Id = new Guid("b9ff0b3b-832f-4ea1-b835-b58a68e39531"),
                    Title = "Tech Conference: Future of AI",
                    Date = new DateTime(2025, 7, 20, 8, 0, 0),
                    Description = "A deep dive into the latest trends and innovations in artificial intelligence.",
                    Category = "Technology",
                    City = "Chicago",
                    Venue = "McCormick Place"
                },
                new Activity
                {
                    Id = new Guid("cb40a1ea-5df7-4f7b-a154-5a4caecd3c5e"),
                    Title = "Food Festival: Taste of Italy",
                    Date = new DateTime(2025, 8, 12, 12, 0, 0),
                    Description = "Savor authentic Italian dishes from the best chefs and local vendors.",
                    Category = "Food",
                    City = "Los Angeles",
                    Venue = "Los Angeles Convention Center"
                },
                new Activity
                {
                    Id = new Guid("d8c14150-874b-4e2e-b069-2b154f7f74bb"),
                    Title = "Fitness Bootcamp: Summer Challenge",
                    Date = new DateTime(2025, 6, 10, 6, 0, 0),
                    Description = "Get in shape this summer with an intensive bootcamp that will push your limits.",
                    Category = "Fitness",
                    City = "Miami",
                    Venue = "South Beach"
                }
            };
        }
    }

}

