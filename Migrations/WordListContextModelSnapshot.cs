﻿// <auto-generated />
using Fiszki.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Fiszki.Migrations
{
    [DbContext(typeof(WordListContext))]
    partial class WordListContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("Fiszki.Models.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Color")
                        .HasColumnType("int");

                    b.Property<double>("LevelHard")
                        .HasColumnType("float");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isPolishTranslation")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Account");
                });

            modelBuilder.Entity("Fiszki.Models.Word", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("EnglishVersion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PolishVersion")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Word");
                });
#pragma warning restore 612, 618
        }
    }
}
