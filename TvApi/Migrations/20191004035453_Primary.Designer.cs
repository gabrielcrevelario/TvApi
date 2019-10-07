﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TvApi.Context;

namespace TvApi.Migrations
{
    [DbContext(typeof(TvContext))]
    [Migration("20191004035453_Primary")]
    partial class Primary
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TvApi.Models.Audience", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("AudiencePoints");

                    b.Property<DateTime>("DateAndTimeAudience");

                    b.Property<long>("TvChannelId");

                    b.HasKey("Id");

                    b.HasIndex("TvChannelId");

                    b.ToTable("Audiences");
                });

            modelBuilder.Entity("TvApi.Models.TvChannel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasFilter("[Name] IS NOT NULL");

                    b.ToTable("TvChannels");
                });

            modelBuilder.Entity("TvApi.Models.Audience", b =>
                {
                    b.HasOne("TvApi.Models.TvChannel", "TvChannel")
                        .WithMany("Audiences")
                        .HasForeignKey("TvChannelId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
