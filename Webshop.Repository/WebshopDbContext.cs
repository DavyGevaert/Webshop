using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webshop.Model;

namespace Webshop.Repository
{
    public class WebshopDbContext : DbContext
    {
        public static string ConnectionString { get; set; } =
            @"Data Source=DESKTOP-6BF840K\VIVES;Initial Catalog=WebshopDB;Integrated Security=True";

        public WebshopDbContext(DbContextOptions<WebshopDbContext> options) : base(options)
        {

        }

        public WebshopDbContext()
        {

        }

        public DbSet<Bluray> Blurays { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Bluray>().HasData(
                new Bluray
                {
                    Id = 1,
                    Title = "Predator",
                    Description = "Arnold Schwarzenegger stars as Dutch Schaefer, the leader of an elite paramilitary rescue team on a mission to save hostages in guerrilla-held territory in a Central American rainforest, who encounter the deadly Predator (Kevin Peter Hall), a skilled, technologically advanced alien who stalks and hunts them down.",
                    Image = "https://images.static-bluray.com/movies/covers/207590_large.jpg?t=1529471856",
                    TrailerURL = "https://youtu.be/_1wDBNHYDv8",
                    Price = 7
                },
                new Bluray
                {
                    Id = 2,
                    Title = "Aliens",
                    Description = "Set in the far future, it stars Sigourney Weaver as Ellen Ripley, the sole survivor of an alien attack on her ship. When communications are lost with a human colony on the moon where her crew first saw the alien creatures, Ripley agrees to return to the site with a unit of Colonial Marines to investigate.",
                    Image = "https://images.static-bluray.com/movies/covers/110039_large.jpg?t=1468393673",
                    TrailerURL = "https://youtu.be/oSeQQlaCZgU",
                    Price = 8
                },
                new Bluray
                {
                    Id = 3,
                    Title = "Die Hard",
                    Description = "A New York City police officer tries to save his estranged wife and several others taken hostage by terrorists during a Christmas party at the Nakatomi Plaza in Los Angeles.",
                    Image = "https://images.static-bluray.com/movies/covers/201262_large.jpg?t=1521164675",
                    TrailerURL = "https://youtu.be/jaJuwKCmJbY",
                    Price = 7
                },
                new Bluray
                {
                    Id = 4,
                    Title = "Prometheus",
                    Description = "Following clues to the origin of mankind, a team finds a structure on a distant moon, but they soon realize they are not alone.",
                    Image = "https://images.static-bluray.com/movies/covers/143008_large.jpg?t=1445573391",
                    TrailerURL = "https://youtu.be/5UEv03g51kU",
                    Price = 10
                },
                new Bluray
                {
                    Id = 5,
                    Title = "Limitless",
                    Description = "The story follows a writer who takes an experimental drug that increases mental ability, allowing him to become a high-powered business broker, but his success comes at a price and is full of danger. Bradley Cooper, Robert De Niro, and Abbie Cornish lead the cast and give fairly strong performances.",
                    Image = "https://images.static-bluray.com/movies/covers/24274_large.jpg?t=1452554093",
                    TrailerURL = "https://youtu.be/4TLppsfzQH8",
                    Price = 12
                },
                new Bluray
                {
                    Id = 6,
                    Title = "Layer Cake",
                    Description = "A successful cocaine dealer gets two tough assignments from his boss on the eve of his planned early retirement. An unnamed drug-dealer (Daniel Craig) has always had his priorities straight: he wants to quit while he's ahead.",
                    Image = "https://images.static-bluray.com/movies/covers/166_large.jpg?t=1391838335",
                    TrailerURL = "https://youtu.be/Yk4wX4FPRzE",
                    Price = 12
                },
                new Bluray
                {
                    Id = 7,
                    Title = "Mission Impossible: Dead Reckoning Part One",
                    Description = "Ethan Hunt (Tom Cruise) and his IMF team embark on their most dangerous mission yet: To track down a terrifying new weapon that threatens all of humanity before it falls into the wrong hands.",
                    Image = "https://images.static-bluray.com/movies/covers/341691_large.jpg?t=1689180080",
                    TrailerURL = "https://youtu.be/avz06PDqDbM",
                    Price = 20
                },
                new Bluray
                {
                    Id = 8,
                    Title = "Star Trek: Picard - 3rd Season",
                    Description = "The third and final season of the American television series Star Trek: Picard features the character Jean-Luc Picard in the year 2401 as he reunites with the former command crew of the USS Enterprise (Geordi La Forge, Worf, William Riker, Beverly Crusher, Deanna Troi, and Data) while facing a mysterious enemy who is hunting Picard's son.",
                    Image = "https://images.static-bluray.com/movies/covers/340118_large.jpg?t=1686942159",
                    TrailerURL = "https://youtu.be/DI9hty_iT4Q",
                    Price = 28
                },
                new Bluray
                {
                    Id = 9,
                    Title = "The Hateful Eight",
                    Description = "In the dead of a Wyoming winter, a bounty hunter and his prisoner find shelter in a cabin currently inhabited by a collection of nefarious characters. Years after the American Civil War, bounty hunter Major Marquis Warren is transporting three dead bounties to the town of Red Rock, Wyoming.",
                    Image = "https://images.static-bluray.com/movies/covers/123505_large.jpg?t=1456098039",
                    TrailerURL = "https://youtu.be/jEEp9fXgBiY",
                    Price = 10
                },
                new Bluray
                {
                    Id = 10,
                    Title = "The Fast and the Furious",
                    Description = "A heist crew driving three heavily modified Honda Civics hijack a semi-truck trailer carrying electronic goods and escape into the night along Terminal Island Freeway. Meanwhile, LAPD officer Brian O'Conner is sent undercover as part of a joint LAPD-FBI task force to locate the crew responsible.",
                    Image = "https://images.static-bluray.com/movies/covers/41888_large.jpg?t=0",
                    TrailerURL = "https://youtu.be/2TAOizOnNPo",
                    Price = 12
                },
                new Bluray
                {
                    Id = 11,
                    Title = "No Time to Die",
                    Description = "Bond has left active service. His peace is short-lived when his old friend Felix Leiter from the CIA turns up asking for help, leading Bond onto the trail of a mysterious villain armed with dangerous new technology.",
                    Image = "https://images.static-bluray.com/movies/covers/348465_large.jpg?t=1699694249",
                    TrailerURL = "https://youtu.be/BIhNsAtPbPI",
                    Price = 15
                },
                new Bluray
                {
                    Id = 12,
                    Title = "Man of Steel",
                    Description = "A young boy learns that he has extraordinary powers and is not of this Earth. As a young man, he journeys to discover where he came from and what he was sent here to do. But the hero in him must emerge if he is to save the world from annihilation and become the symbol of hope for all mankind.",
                    Image = "https://images.static-bluray.com/movies/covers/51265_large.jpg?t=1442152541",
                    TrailerURL = "https://youtu.be/OZfKfs0vIBw",
                    Price = 10
                }
            );
        }
    }
}
