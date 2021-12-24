using SocialNetwork.DAL.Entities;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.DAL.EF
{
    public partial class DataContext : DbContext
    {
        public DbSet<Users> Users { get; set; }
        public DbSet<MessList> MessList { get; set; }
        public DbSet<FriendRequest> FriendRequest { get; set; }
        public DbSet<Chat> Chat { get; set; }
        public DbSet<Relationships> Relationships { get; set; }


        public DataContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<MessList>().HasMany(w => w.ChatL).WithOne(e => e.MessList).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Users>().HasMany(w => w.ChatFrom).WithOne(e => e.FromUsers).HasForeignKey(p => p.FromUser_Id).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Users>().HasMany(w => w.ChatTo).WithOne(e => e.ToUsers).HasForeignKey(p => p.ToUser_Id).OnDelete(DeleteBehavior.NoAction);
            //
            modelBuilder.Entity<Users>().HasMany(w => w.FriendRequestFrom).WithOne(e => e.FromUsers).HasForeignKey(p => p.FromUser_Id).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Users>().HasMany(w => w.FriendRequestTo).WithOne(e => e.ToUsers).HasForeignKey(p => p.ToUser_Id).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Users>().HasMany(w => w.MessList1).WithOne(e => e.Users1).HasForeignKey(p => p.User1_Id).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Users>().HasMany(w => w.MessList2).WithOne(e => e.Users2).HasForeignKey(p => p.User2_Id).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Users>().HasMany(w => w.Relationships1).WithOne(e => e.Users1).HasForeignKey(p => p.User1_Id).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Users>().HasMany(w => w.Relationships2).WithOne(e => e.Users2).HasForeignKey(p => p.User2_Id).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Users>().HasData(
            new Users[]
            {
                new Users
                {
                    Id = 1,
                    SurName = "Поночовний",
                    Name = "Павло",
                    Patronymic = "Сергійович",
                    BirthdayCity = "Славута",
                    Birthday = "10.07.2002",
                    Password = "1234",
                    Email = "pauluayt@gmail.com",
                    Mobile = "+380680271933",
                    RegistrationDate = new DateTime(2021, 11, 28, 16, 29, 15)
                },
                new Users
                {
                    Id = 2,
                    SurName = "Гутенюк",
                    Name = "Дмитро",
                    Patronymic = "Вікторович",
                    BirthdayCity = "Шепетівка",
                    Birthday = "23.10.2002",
                    Password = "1234",
                    Email = "gutenukdima@gmail.com",
                    Mobile = "+380972474448",
                    RegistrationDate = new DateTime(2021, 11, 30, 15, 13, 15)
                },
                new Users
                {
                    Id = 3,
                    SurName = "Петров",
                    Name = "Ігор",
                    Patronymic = "Владиславович",
                    BirthdayCity = "Київ",
                    Birthday = "23.04.2000",
                    Password = "1234",
                    Email = "petrovv@gmail.com",
                    Mobile = "+380972055017",
                    RegistrationDate = new DateTime(2021, 12, 02, 18, 29, 00)
                }
            });

            modelBuilder.Entity<FriendRequest>().HasData(
            new FriendRequest[]
            {
                new FriendRequest{Id = 1, FromUser_Id = 2,ToUser_Id = 3}
            });

            modelBuilder.Entity<MessList>().HasData(
            new MessList[]
            {
                new MessList{Id = 1, User1_Id = 1,User2_Id = 2},
                new MessList{Id = 2, User1_Id = 1,User2_Id = 3}
            });

            modelBuilder.Entity<Relationships>().HasData(
            new Relationships[]
            {
                new Relationships{Id = 1, User1_Id = 1,User2_Id = 2},
                new Relationships{Id = 2, User1_Id = 2,User2_Id = 1},
                new Relationships{Id = 3, User1_Id = 1,User2_Id = 3},
                new Relationships{Id = 4, User1_Id = 3,User2_Id = 1}
            });

            modelBuilder.Entity<Chat>().HasData(
            new Chat[]
            {
                new Chat
                {
                    Id = 1,
                    messList_Id = 1,
                    FromUser_Id = 1,
                    ToUser_Id = 2,
                    Text = "Hi, how are u?"
                },
                new Chat
                {
                    Id = 2,
                    messList_Id = 1,
                    FromUser_Id = 1,
                    ToUser_Id = 2,
                    Text = "Hey, I'm so good..."
                },
                new Chat
                {
                    Id = 3,
                    messList_Id = 1,
                    FromUser_Id = 1,
                    ToUser_Id = 2,
                    Text = "This is good"
                },
                new Chat
                {
                    Id = 4,
                    messList_Id = 2,
                    FromUser_Id = 1,
                    ToUser_Id = 3,
                    Text = "Hi, what are you doing?"
                }
            });
        }
    }
}
