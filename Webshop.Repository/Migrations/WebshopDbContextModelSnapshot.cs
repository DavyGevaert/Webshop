﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Webshop.Repository;

#nullable disable

namespace Webshop.Repository.Migrations
{
    [DbContext(typeof(WebshopDbContext))]
    partial class WebshopDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Webshop.Model.Bluray", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TrailerURL")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Blurays");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Arnold Schwarzenegger stars as Dutch Schaefer, the leader of an elite paramilitary rescue team on a mission to save hostages in guerrilla-held territory in a Central American rainforest, who encounter the deadly Predator (Kevin Peter Hall), a skilled, technologically advanced alien who stalks and hunts them down.",
                            ImageURL = "https://images.static-bluray.com/movies/covers/207590_large.jpg?t=1529471856",
                            Price = 7,
                            Title = "Predator",
                            TrailerURL = "https://youtu.be/_1wDBNHYDv8"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Set in the far future, it stars Sigourney Weaver as Ellen Ripley, the sole survivor of an alien attack on her ship. When communications are lost with a human colony on the moon where her crew first saw the alien creatures, Ripley agrees to return to the site with a unit of Colonial Marines to investigate.",
                            ImageURL = "https://images.static-bluray.com/movies/covers/110039_large.jpg?t=1468393673",
                            Price = 8,
                            Title = "Aliens",
                            TrailerURL = "https://youtu.be/oSeQQlaCZgU"
                        },
                        new
                        {
                            Id = 3,
                            Description = "A New York City police officer tries to save his estranged wife and several others taken hostage by terrorists during a Christmas party at the Nakatomi Plaza in Los Angeles.",
                            ImageURL = "https://images.static-bluray.com/movies/covers/201262_large.jpg?t=1521164675",
                            Price = 7,
                            Title = "Die Hard",
                            TrailerURL = "https://youtu.be/jaJuwKCmJbY"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Following clues to the origin of mankind, a team finds a structure on a distant moon, but they soon realize they are not alone.",
                            ImageURL = "https://images.static-bluray.com/movies/covers/143008_large.jpg?t=1445573391",
                            Price = 10,
                            Title = "Prometheus",
                            TrailerURL = "https://youtu.be/5UEv03g51kU"
                        },
                        new
                        {
                            Id = 5,
                            Description = "The story follows a writer who takes an experimental drug that increases mental ability, allowing him to become a high-powered business broker, but his success comes at a price and is full of danger. Bradley Cooper, Robert De Niro, and Abbie Cornish lead the cast and give fairly strong performances.",
                            ImageURL = "https://images.static-bluray.com/movies/covers/24274_large.jpg?t=1452554093",
                            Price = 12,
                            Title = "Limitless",
                            TrailerURL = "https://youtu.be/4TLppsfzQH8"
                        },
                        new
                        {
                            Id = 6,
                            Description = "A successful cocaine dealer gets two tough assignments from his boss on the eve of his planned early retirement. An unnamed drug-dealer (Daniel Craig) has always had his priorities straight: he wants to quit while he's ahead.",
                            ImageURL = "https://images.static-bluray.com/movies/covers/166_large.jpg?t=1391838335",
                            Price = 12,
                            Title = "Layer Cake",
                            TrailerURL = "https://youtu.be/Yk4wX4FPRzE"
                        },
                        new
                        {
                            Id = 7,
                            Description = "Ethan Hunt (Tom Cruise) and his IMF team embark on their most dangerous mission yet: To track down a terrifying new weapon that threatens all of humanity before it falls into the wrong hands.",
                            ImageURL = "https://images.static-bluray.com/movies/covers/341691_large.jpg?t=1689180080",
                            Price = 20,
                            Title = "Mission Impossible: Dead Reckoning Part One",
                            TrailerURL = "https://youtu.be/avz06PDqDbM"
                        },
                        new
                        {
                            Id = 8,
                            Description = "The third and final season of the American television series Star Trek: Picard features the character Jean-Luc Picard in the year 2401 as he reunites with the former command crew of the USS Enterprise (Geordi La Forge, Worf, William Riker, Beverly Crusher, Deanna Troi, and Data) while facing a mysterious enemy who is hunting Picard's son.",
                            ImageURL = "https://images.static-bluray.com/movies/covers/340118_large.jpg?t=1686942159",
                            Price = 28,
                            Title = "Star Trek: Picard - 3rd Season",
                            TrailerURL = "https://youtu.be/DI9hty_iT4Q"
                        },
                        new
                        {
                            Id = 9,
                            Description = "In the dead of a Wyoming winter, a bounty hunter and his prisoner find shelter in a cabin currently inhabited by a collection of nefarious characters. Years after the American Civil War, bounty hunter Major Marquis Warren is transporting three dead bounties to the town of Red Rock, Wyoming.",
                            ImageURL = "https://images.static-bluray.com/movies/covers/123505_large.jpg?t=1456098039",
                            Price = 10,
                            Title = "The Hateful Eight",
                            TrailerURL = "https://youtu.be/jEEp9fXgBiY"
                        },
                        new
                        {
                            Id = 10,
                            Description = "A heist crew driving three heavily modified Honda Civics hijack a semi-truck trailer carrying electronic goods and escape into the night along Terminal Island Freeway. Meanwhile, LAPD officer Brian O'Conner is sent undercover as part of a joint LAPD-FBI task force to locate the crew responsible.",
                            ImageURL = "https://images.static-bluray.com/movies/covers/41888_large.jpg?t=0",
                            Price = 12,
                            Title = "The Fast and the Furious",
                            TrailerURL = "https://youtu.be/2TAOizOnNPo"
                        },
                        new
                        {
                            Id = 11,
                            Description = "Bond has left active service. His peace is short-lived when his old friend Felix Leiter from the CIA turns up asking for help, leading Bond onto the trail of a mysterious villain armed with dangerous new technology.",
                            ImageURL = "https://images.static-bluray.com/movies/covers/348465_large.jpg?t=1699694249",
                            Price = 15,
                            Title = "No Time to Die",
                            TrailerURL = "https://youtu.be/BIhNsAtPbPI"
                        },
                        new
                        {
                            Id = 12,
                            Description = "A young boy learns that he has extraordinary powers and is not of this Earth. As a young man, he journeys to discover where he came from and what he was sent here to do. But the hero in him must emerge if he is to save the world from annihilation and become the symbol of hope for all mankind.",
                            ImageURL = "https://images.static-bluray.com/movies/covers/51265_large.jpg?t=1442152541",
                            Price = 10,
                            Title = "Man of Steel",
                            TrailerURL = "https://youtu.be/OZfKfs0vIBw"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
