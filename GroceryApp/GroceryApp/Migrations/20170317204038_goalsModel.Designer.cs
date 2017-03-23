using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using GroceryApp.Models;

namespace GroceryApp.Migrations
{
    [DbContext(typeof(GroceryAppContext))]
    [Migration("20170317204038_goalsModel")]
    partial class goalsModel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GroceryApp.Models.Candidates", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Goals");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Candidates");
                });
        }
    }
}
