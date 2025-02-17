﻿// <auto-generated />
using System;
using GetriWebApi.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GetriWebApi.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250212055855_DbSetActivityAdded")]
    partial class DbSetActivityAdded
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GetriWebApi.Models.Activity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Venue")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Activities");

                    b.HasData(
                        new
                        {
                            Id = new Guid("13d5fd5b-5168-49cf-b8b6-a79fd6d65457"),
                            Category = "Music",
                            City = "New York",
                            Date = new DateTime(2025, 5, 15, 19, 30, 0, 0, DateTimeKind.Unspecified),
                            Description = "Join us for an unforgettable night of classic rock music with top bands.",
                            Title = "Music Concert: Rock Legends",
                            Venue = "Madison Square Garden"
                        },
                        new
                        {
                            Id = new Guid("7f1d989e-c19a-4445-91c2-1f4e22cb2805"),
                            Category = "Art",
                            City = "San Francisco",
                            Date = new DateTime(2025, 6, 1, 10, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Explore the world of contemporary art with works from renowned artists.",
                            Title = "Art Exhibition: Modern Masterpieces",
                            Venue = "SFMOMA"
                        },
                        new
                        {
                            Id = new Guid("b9ff0b3b-832f-4ea1-b835-b58a68e39531"),
                            Category = "Technology",
                            City = "Chicago",
                            Date = new DateTime(2025, 7, 20, 8, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "A deep dive into the latest trends and innovations in artificial intelligence.",
                            Title = "Tech Conference: Future of AI",
                            Venue = "McCormick Place"
                        },
                        new
                        {
                            Id = new Guid("cb40a1ea-5df7-4f7b-a154-5a4caecd3c5e"),
                            Category = "Food",
                            City = "Los Angeles",
                            Date = new DateTime(2025, 8, 12, 12, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Savor authentic Italian dishes from the best chefs and local vendors.",
                            Title = "Food Festival: Taste of Italy",
                            Venue = "Los Angeles Convention Center"
                        },
                        new
                        {
                            Id = new Guid("d8c14150-874b-4e2e-b069-2b154f7f74bb"),
                            Category = "Fitness",
                            City = "Miami",
                            Date = new DateTime(2025, 6, 10, 6, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Get in shape this summer with an intensive bootcamp that will push your limits.",
                            Title = "Fitness Bootcamp: Summer Challenge",
                            Venue = "South Beach"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
