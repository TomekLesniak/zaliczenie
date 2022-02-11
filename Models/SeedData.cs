using System;
using System.Linq;
using LibApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LibApp.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var context = serviceProvider.GetRequiredService<ApplicationDbContext>();

            if (context.MembershipTypes.Any())
            {
                Console.WriteLine("Database already seeded");
                return;
            }

            context.MembershipTypes.AddRange(
                new MembershipType
                {
                    Id = 1,
                    Name = "membershiptype1",
                    SignUpFee = 0,
                    DurationInMonths = 0,
                    DiscountRate = 0
                },
                new MembershipType
                {
                    Id = 2,
                    Name = "membershiptype2",
                    SignUpFee = 30,
                    DurationInMonths = 1,
                    DiscountRate = 10
                },
                new MembershipType
                {
                    Id = 3,
                    Name = "membershiptype3",
                    SignUpFee = 90,
                    DurationInMonths = 3,
                    DiscountRate = 15
                },
                new MembershipType
                {
                    Id = 4,
                    Name = "membershiptype4",
                    SignUpFee = 300,
                    DurationInMonths = 12,
                    DiscountRate = 20
                });

            context.Rentals.AddRange(
                new Rental
                {
                    Customer = new Customer
                    {
                        Birthdate = DateTime.Now.AddYears(-10),
                        HasNewsletterSubscribed = true,
                        MembershipTypeId = 1,
                        Name = "Customer1"
                    },
                    Book = new Book
                    {
                        AuthorName = "author1",
                        DateAdded = DateTime.Now.AddDays(-1),
                        GenreId = 1,
                        Name = "Name1",
                        NumberAvailable = 10,
                        NumberInStock = 10,
                        ReleaseDate = DateTime.Now.AddDays(-2)
                    },
                    DateRented = DateTime.Now.AddDays(-1)
                },
                new Rental
                {
                    Customer = new Customer
                    {
                        Birthdate = DateTime.Now.AddYears(-10),
                        HasNewsletterSubscribed = true,
                        MembershipTypeId = 1,
                        Name = "Customer2"
                    },
                    Book = new Book
                    {
                        AuthorName = "author2",
                        DateAdded = DateTime.Now.AddDays(-1),
                        GenreId = 2,
                        Name = "Name2",
                        NumberAvailable = 10,
                        NumberInStock = 10,
                        ReleaseDate = DateTime.Now.AddDays(-2)
                    },
                    DateRented = DateTime.Now.AddDays(-1)
                },
                new Rental
                {
                    Customer = new Customer
                    {
                        Birthdate = DateTime.Now.AddYears(-10),
                        HasNewsletterSubscribed = true,
                        MembershipTypeId = 3,
                        Name = "Customer3"
                    },
                    Book = new Book
                    {
                        AuthorName = "author3",
                        DateAdded = DateTime.Now.AddDays(-1),
                        GenreId = 3,
                        Name = "Name3",
                        NumberAvailable = 10,
                        NumberInStock = 10,
                        ReleaseDate = DateTime.Now.AddDays(-2)
                    },
                    DateRented = DateTime.Now.AddDays(-1)
                }
                );

            context.SaveChanges();
        }
    }
}