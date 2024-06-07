﻿// <auto-generated />
using System;
using MemeLib.DbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MemeLib.DbContext.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240607124633_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("MemeLib.DbContext.Models.MemeDbModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id")
                        .HasComment("Meme Id");

                    b.Property<string>("Alias")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("alias")
                        .HasComment("Meme Alias");

                    b.Property<Guid>("AuthorId")
                        .HasColumnType("uuid")
                        .HasColumnName("author_id")
                        .HasComment("Meme's author id");

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description")
                        .HasComment("Meme description");

                    b.Property<DateOnly>("PublishDate")
                        .HasColumnType("date")
                        .HasColumnName("publish_date")
                        .HasComment("Meme publish date");

                    b.Property<DateTime>("Ts")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("ts")
                        .HasComment("Meme last update timestamp");

                    b.HasKey("Id");

                    b.ToTable("memes", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
