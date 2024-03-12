using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Webshop.Repository.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrailerURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<int>(type: "int", nullable: false),
                    CurrentInStock = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    OutOfStock = table.Column<bool>(type: "bit", nullable: false),
                    ButtonText = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Item",
                columns: new[] { "Id", "ButtonText", "CurrentInStock", "Description", "ImageURL", "OutOfStock", "Price", "Quantity", "Title", "TrailerURL" },
                values: new object[,]
                {
                    { 1, "Buy", 7, "Arnold Schwarzenegger stars as Dutch Schaefer, the leader of an elite paramilitary rescue team on a mission to save hostages in guerrilla-held territory in a Central American rainforest, who encounter the deadly Predator (Kevin Peter Hall), a skilled, technologically advanced alien who stalks and hunts them down.", "https://images.static-bluray.com/movies/covers/207590_large.jpg?t=1529471856", false, 7, 0, "Predator", "https://www.youtube.com/watch?v=_1wDBNHYDv8" },
                    { 2, "Buy", 7, "Set in the far future, it stars Sigourney Weaver as Ellen Ripley, the sole survivor of an alien attack on her ship. When communications are lost with a human colony on the moon where her crew first saw the alien creatures, Ripley agrees to return to the site with a unit of Colonial Marines to investigate.", "https://images.static-bluray.com/movies/covers/110039_large.jpg?t=1468393673", false, 8, 0, "Aliens", "https://www.youtube.com/watch?v=oSeQQlaCZgU" },
                    { 3, "Buy", 7, "A New York City police officer tries to save his estranged wife and several others taken hostage by terrorists during a Christmas party at the Nakatomi Plaza in Los Angeles.", "https://images.static-bluray.com/movies/covers/201262_large.jpg?t=1521164675", false, 7, 0, "Die Hard", "https://www.youtube.com/watch?v=jaJuwKCmJbY" },
                    { 4, "Buy", 7, "Following clues to the origin of mankind, a team finds a structure on a distant moon, but they soon realize they are not alone.", "https://images.static-bluray.com/movies/covers/143008_large.jpg?t=1445573391", false, 10, 0, "Prometheus", "https://www.youtube.com/watch?v=5UEv03g51kU" },
                    { 5, "Buy", 7, "The story follows a writer who takes an experimental drug that increases mental ability, allowing him to become a high-powered business broker, but his success comes at a price and is full of danger. Bradley Cooper, Robert De Niro, and Abbie Cornish lead the cast and give fairly strong performances.", "https://images.static-bluray.com/movies/covers/24274_large.jpg?t=1452554093", false, 12, 0, "Limitless", "https://www.youtube.com/watch?v=4TLppsfzQH8" },
                    { 6, "Buy", 10, "A successful cocaine dealer gets two tough assignments from his boss on the eve of his planned early retirement. An unnamed drug-dealer (Daniel Craig) has always had his priorities straight: he wants to quit while he's ahead.", "https://images.static-bluray.com/movies/covers/166_large.jpg?t=1391838335", false, 12, 0, "Layer Cake", "https://www.youtube.com/watch?v=Yk4wX4FPRzE" },
                    { 7, "Buy", 20, "Ethan Hunt (Tom Cruise) and his IMF team embark on their most dangerous mission yet: To track down a terrifying new weapon that threatens all of humanity before it falls into the wrong hands.", "https://images.static-bluray.com/movies/covers/341691_large.jpg?t=1689180080", false, 20, 0, "Mission Impossible: Dead Reckoning Part One", "https://www.youtube.com/watch?v=avz06PDqDbM" },
                    { 8, "Buy", 20, "The third and final season of the American television series Star Trek: Picard features the character Jean-Luc Picard in the year 2401 as he reunites with the former command crew of the USS Enterprise (Geordi La Forge, Worf, William Riker, Beverly Crusher, Deanna Troi, and Data) while facing a mysterious enemy who is hunting Picard's son.", "https://images.static-bluray.com/movies/covers/340118_large.jpg?t=1686942159", false, 28, 0, "Star Trek: Picard - 3rd Season", "https://www.youtube.com/watch?v=DI9hty_iT4Q" },
                    { 9, "Buy", 12, "In the dead of a Wyoming winter, a bounty hunter and his prisoner find shelter in a cabin currently inhabited by a collection of nefarious characters. Years after the American Civil War, bounty hunter Major Marquis Warren is transporting three dead bounties to the town of Red Rock, Wyoming.", "https://images.static-bluray.com/movies/covers/123505_large.jpg?t=1456098039", false, 10, 0, "The Hateful Eight", "https://www.youtube.com/watch?v=jEEp9fXgBiY" },
                    { 10, "Buy", 12, "A heist crew driving three heavily modified Honda Civics hijack a semi-truck trailer carrying electronic goods and escape into the night along Terminal Island Freeway. Meanwhile, LAPD officer Brian O'Conner is sent undercover as part of a joint LAPD-FBI task force to locate the crew responsible.", "https://images.static-bluray.com/movies/covers/41888_large.jpg?t=0", false, 12, 0, "The Fast and the Furious", "https://www.youtube.com/watch?v=2TAOizOnNPo" },
                    { 11, "Buy", 15, "Bond has left active service. His peace is short-lived when his old friend Felix Leiter from the CIA turns up asking for help, leading Bond onto the trail of a mysterious villain armed with dangerous new technology.", "https://images.static-bluray.com/movies/covers/348465_large.jpg?t=1699694249", false, 15, 0, "No Time to Die", "https://www.youtube.com/watch?v=BIhNsAtPbPI" },
                    { 12, "Buy", 10, "A young boy learns that he has extraordinary powers and is not of this Earth. As a young man, he journeys to discover where he came from and what he was sent here to do. But the hero in him must emerge if he is to save the world from annihilation and become the symbol of hope for all mankind.", "https://images.static-bluray.com/movies/covers/51265_large.jpg?t=1442152541", false, 10, 0, "Man of Steel", "https://www.youtube.com/watch?v=OZfKfs0vIBw" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
