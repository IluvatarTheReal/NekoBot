﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NekoBot.Infrastructure.Data;

namespace NekoBot.Infrastructure.Migrations
{
    [DbContext(typeof(NekoDbContext))]
    [Migration("20190723021519_initial-commit")]
    partial class initialcommit
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity("NekoBot.Infrastructure.Model.ModerationLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Action");

                    b.Property<ulong>("ExecutingUserId");

                    b.Property<string>("ExecutingUsername");

                    b.Property<string>("Reason");

                    b.Property<string>("TargetUsername");

                    b.Property<ulong>("TargetedUserId");

                    b.Property<DateTime>("Timestamp");

                    b.HasKey("Id");

                    b.ToTable("ModerationLogs");
                });
#pragma warning restore 612, 618
        }
    }
}
