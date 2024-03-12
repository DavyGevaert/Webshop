﻿// <auto-generated />
using System;
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

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Webshop.Model.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ButtonText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CurrentInStock")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("OutOfStock")
                        .HasColumnType("bit");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TrailerURL")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Item");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ButtonText = "Buy",
                            CurrentInStock = 7,
                            Description = "Arnold Schwarzenegger stars as Dutch Schaefer, the leader of an elite paramilitary rescue team on a mission to save hostages in guerrilla-held territory in a Central American rainforest, who encounter the deadly Predator (Kevin Peter Hall), a skilled, technologically advanced alien who stalks and hunts them down.",
                            ImageURL = "https://images.static-bluray.com/movies/covers/207590_large.jpg?t=1529471856",
                            OutOfStock = false,
                            Price = 7,
                            Quantity = 0,
                            Title = "Predator",
                            TrailerURL = "https://www.youtube.com/watch?v=_1wDBNHYDv8"
                        },
                        new
                        {
                            Id = 2,
                            ButtonText = "Buy",
                            CurrentInStock = 7,
                            Description = "Set in the far future, it stars Sigourney Weaver as Ellen Ripley, the sole survivor of an alien attack on her ship. When communications are lost with a human colony on the moon where her crew first saw the alien creatures, Ripley agrees to return to the site with a unit of Colonial Marines to investigate.",
                            ImageURL = "https://images.static-bluray.com/movies/covers/110039_large.jpg?t=1468393673",
                            OutOfStock = false,
                            Price = 8,
                            Quantity = 0,
                            Title = "Aliens",
                            TrailerURL = "https://www.youtube.com/watch?v=oSeQQlaCZgU"
                        },
                        new
                        {
                            Id = 3,
                            ButtonText = "Buy",
                            CurrentInStock = 7,
                            Description = "A New York City police officer tries to save his estranged wife and several others taken hostage by terrorists during a Christmas party at the Nakatomi Plaza in Los Angeles.",
                            ImageURL = "https://images.static-bluray.com/movies/covers/201262_large.jpg?t=1521164675",
                            OutOfStock = false,
                            Price = 7,
                            Quantity = 0,
                            Title = "Die Hard",
                            TrailerURL = "https://www.youtube.com/watch?v=jaJuwKCmJbY"
                        },
                        new
                        {
                            Id = 4,
                            ButtonText = "Buy",
                            CurrentInStock = 7,
                            Description = "Following clues to the origin of mankind, a team finds a structure on a distant moon, but they soon realize they are not alone.",
                            ImageURL = "https://images.static-bluray.com/movies/covers/143008_large.jpg?t=1445573391",
                            OutOfStock = false,
                            Price = 10,
                            Quantity = 0,
                            Title = "Prometheus",
                            TrailerURL = "https://www.youtube.com/watch?v=5UEv03g51kU"
                        },
                        new
                        {
                            Id = 5,
                            ButtonText = "Buy",
                            CurrentInStock = 7,
                            Description = "The story follows a writer who takes an experimental drug that increases mental ability, allowing him to become a high-powered business broker, but his success comes at a price and is full of danger. Bradley Cooper, Robert De Niro, and Abbie Cornish lead the cast and give fairly strong performances.",
                            ImageURL = "https://images.static-bluray.com/movies/covers/24274_large.jpg?t=1452554093",
                            OutOfStock = false,
                            Price = 12,
                            Quantity = 0,
                            Title = "Limitless",
                            TrailerURL = "https://www.youtube.com/watch?v=4TLppsfzQH8"
                        },
                        new
                        {
                            Id = 6,
                            ButtonText = "Buy",
                            CurrentInStock = 10,
                            Description = "A successful cocaine dealer gets two tough assignments from his boss on the eve of his planned early retirement. An unnamed drug-dealer (Daniel Craig) has always had his priorities straight: he wants to quit while he's ahead.",
                            ImageURL = "https://images.static-bluray.com/movies/covers/166_large.jpg?t=1391838335",
                            OutOfStock = false,
                            Price = 12,
                            Quantity = 0,
                            Title = "Layer Cake",
                            TrailerURL = "https://www.youtube.com/watch?v=Yk4wX4FPRzE"
                        },
                        new
                        {
                            Id = 7,
                            ButtonText = "Buy",
                            CurrentInStock = 20,
                            Description = "Ethan Hunt (Tom Cruise) and his IMF team embark on their most dangerous mission yet: To track down a terrifying new weapon that threatens all of humanity before it falls into the wrong hands.",
                            ImageURL = "https://images.static-bluray.com/movies/covers/341691_large.jpg?t=1689180080",
                            OutOfStock = false,
                            Price = 20,
                            Quantity = 0,
                            Title = "Mission Impossible: Dead Reckoning Part One",
                            TrailerURL = "https://www.youtube.com/watch?v=avz06PDqDbM"
                        },
                        new
                        {
                            Id = 8,
                            ButtonText = "Buy",
                            CurrentInStock = 20,
                            Description = "The third and final season of the American television series Star Trek: Picard features the character Jean-Luc Picard in the year 2401 as he reunites with the former command crew of the USS Enterprise (Geordi La Forge, Worf, William Riker, Beverly Crusher, Deanna Troi, and Data) while facing a mysterious enemy who is hunting Picard's son.",
                            ImageURL = "https://images.static-bluray.com/movies/covers/340118_large.jpg?t=1686942159",
                            OutOfStock = false,
                            Price = 28,
                            Quantity = 0,
                            Title = "Star Trek: Picard - 3rd Season",
                            TrailerURL = "https://www.youtube.com/watch?v=DI9hty_iT4Q"
                        },
                        new
                        {
                            Id = 9,
                            ButtonText = "Buy",
                            CurrentInStock = 12,
                            Description = "In the dead of a Wyoming winter, a bounty hunter and his prisoner find shelter in a cabin currently inhabited by a collection of nefarious characters. Years after the American Civil War, bounty hunter Major Marquis Warren is transporting three dead bounties to the town of Red Rock, Wyoming.",
                            ImageURL = "https://images.static-bluray.com/movies/covers/123505_large.jpg?t=1456098039",
                            OutOfStock = false,
                            Price = 10,
                            Quantity = 0,
                            Title = "The Hateful Eight",
                            TrailerURL = "https://www.youtube.com/watch?v=jEEp9fXgBiY"
                        },
                        new
                        {
                            Id = 10,
                            ButtonText = "Buy",
                            CurrentInStock = 12,
                            Description = "A heist crew driving three heavily modified Honda Civics hijack a semi-truck trailer carrying electronic goods and escape into the night along Terminal Island Freeway. Meanwhile, LAPD officer Brian O'Conner is sent undercover as part of a joint LAPD-FBI task force to locate the crew responsible.",
                            ImageURL = "https://images.static-bluray.com/movies/covers/41888_large.jpg?t=0",
                            OutOfStock = false,
                            Price = 12,
                            Quantity = 0,
                            Title = "The Fast and the Furious",
                            TrailerURL = "https://www.youtube.com/watch?v=2TAOizOnNPo"
                        },
                        new
                        {
                            Id = 11,
                            ButtonText = "Buy",
                            CurrentInStock = 15,
                            Description = "Bond has left active service. His peace is short-lived when his old friend Felix Leiter from the CIA turns up asking for help, leading Bond onto the trail of a mysterious villain armed with dangerous new technology.",
                            ImageURL = "https://images.static-bluray.com/movies/covers/348465_large.jpg?t=1699694249",
                            OutOfStock = false,
                            Price = 15,
                            Quantity = 0,
                            Title = "No Time to Die",
                            TrailerURL = "https://www.youtube.com/watch?v=BIhNsAtPbPI"
                        },
                        new
                        {
                            Id = 12,
                            ButtonText = "Buy",
                            CurrentInStock = 10,
                            Description = "A young boy learns that he has extraordinary powers and is not of this Earth. As a young man, he journeys to discover where he came from and what he was sent here to do. But the hero in him must emerge if he is to save the world from annihilation and become the symbol of hope for all mankind.",
                            ImageURL = "https://images.static-bluray.com/movies/covers/51265_large.jpg?t=1442152541",
                            OutOfStock = false,
                            Price = 10,
                            Quantity = 0,
                            Title = "Man of Steel",
                            TrailerURL = "https://www.youtube.com/watch?v=OZfKfs0vIBw"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
