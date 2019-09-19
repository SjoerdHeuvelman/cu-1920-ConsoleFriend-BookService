﻿// <auto-generated />
using System;
using BookService.WebAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BookService.WebAPI.Migrations
{
    [DbContext(typeof(BookServiceContext))]
    partial class BookServiceContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BookService.WebAPI.Models.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BirthDate");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.HasKey("Id");

                    b.ToTable("Author");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BirthDate = new DateTime(1980, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "James",
                            LastName = "Sharp"
                        },
                        new
                        {
                            Id = 2,
                            BirthDate = new DateTime(1992, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Sophie",
                            LastName = "Netty"
                        },
                        new
                        {
                            Id = 3,
                            BirthDate = new DateTime(1996, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Elisa",
                            LastName = "Yammy"
                        });
                });

            modelBuilder.Entity("BookService.WebAPI.Models.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AuthorId");

                    b.Property<string>("FileName");

                    b.Property<string>("ISBN");

                    b.Property<int>("NumberOfPages");

                    b.Property<decimal>("Price");

                    b.Property<int?>("PublisherId");

                    b.Property<string>("Title");

                    b.Property<int>("Year");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("PublisherId");

                    b.ToTable("Book");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AuthorId = 1,
                            FileName = "book1.jpg",
                            ISBN = "123456789",
                            NumberOfPages = 420,
                            Price = 24.99m,
                            PublisherId = 1,
                            Title = "Learning C#",
                            Year = 2018
                        },
                        new
                        {
                            Id = 2,
                            AuthorId = 2,
                            FileName = "book2.jpg",
                            ISBN = "45689132",
                            NumberOfPages = 360,
                            Price = 35.99m,
                            PublisherId = 1,
                            Title = "Mastering Linq",
                            Year = 2016
                        },
                        new
                        {
                            Id = 3,
                            AuthorId = 1,
                            FileName = "book3.jpg",
                            ISBN = "15856135",
                            NumberOfPages = 360,
                            Price = 50.00m,
                            PublisherId = 1,
                            Title = "Mastering Xamarin",
                            Year = 2017
                        },
                        new
                        {
                            Id = 4,
                            AuthorId = 2,
                            FileName = "book1.jpg",
                            ISBN = "56789564",
                            NumberOfPages = 360,
                            Price = 45.00m,
                            PublisherId = 1,
                            Title = "Exploring ASP.Net Core 2.0",
                            Year = 2018
                        },
                        new
                        {
                            Id = 5,
                            AuthorId = 2,
                            FileName = "book2.jpg",
                            ISBN = "234546684",
                            NumberOfPages = 420,
                            Price = 70.50m,
                            PublisherId = 1,
                            Title = "Unity Game Development",
                            Year = 2017
                        },
                        new
                        {
                            Id = 6,
                            AuthorId = 3,
                            FileName = "book3.jpg",
                            ISBN = "789456258",
                            NumberOfPages = 40,
                            Price = 52.00m,
                            PublisherId = 2,
                            Title = "Cooking is fun",
                            Year = 2007
                        },
                        new
                        {
                            Id = 7,
                            AuthorId = 3,
                            FileName = "book3.jpg",
                            ISBN = "94521546",
                            NumberOfPages = 53,
                            Price = 30.00m,
                            PublisherId = 2,
                            Title = "Secret recipes",
                            Year = 2017
                        });
                });

            modelBuilder.Entity("BookService.WebAPI.Models.Publisher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Country");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Publisher");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Country = "UK",
                            Name = "IT-publishers"
                        },
                        new
                        {
                            Id = 2,
                            Country = "Sweden",
                            Name = "FoodBooks"
                        });
                });

            modelBuilder.Entity("BookService.WebAPI.Models.Book", b =>
                {
                    b.HasOne("BookService.WebAPI.Models.Author", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId");

                    b.HasOne("BookService.WebAPI.Models.Publisher", "Publisher")
                        .WithMany()
                        .HasForeignKey("PublisherId");
                });
#pragma warning restore 612, 618
        }
    }
}