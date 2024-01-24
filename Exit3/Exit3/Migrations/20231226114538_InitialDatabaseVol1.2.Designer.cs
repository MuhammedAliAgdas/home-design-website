﻿// <auto-generated />
using System;
using Exit3.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Exit3.Migrations
{
    [DbContext(typeof(ExitDbConnection))]
    [Migration("20231226114538_InitialDatabaseVol1.2")]
    partial class InitialDatabaseVol12
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Exit3.Models.Begeni", b =>
                {
                    b.Property<int>("BegeniId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("BegeniSayisi")
                        .HasColumnType("int");

                    b.Property<int>("BegenmemeSayisi")
                        .HasColumnType("int");

                    b.Property<int>("ResimId")
                        .HasColumnType("int");

                    b.HasKey("BegeniId");

                    b.HasIndex("ResimId");

                    b.ToTable("Begeniler");
                });

            modelBuilder.Entity("Exit3.Models.Etiket", b =>
                {
                    b.Property<int>("EtiketId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("EtiketName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("EtiketId");

                    b.ToTable("Etiketler");
                });

            modelBuilder.Entity("Exit3.Models.Kullanici", b =>
                {
                    b.Property<int>("KullaniciId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Adi")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("Cinsiyet")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("DogumTarih")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("KullanciAdi")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Mail")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Sifre")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Soyadi")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("KullaniciId");

                    b.ToTable("Kullanicilar");
                });

            modelBuilder.Entity("Exit3.Models.Paylasim", b =>
                {
                    b.Property<int>("PaylasimId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("KullaniciId")
                        .HasColumnType("int");

                    b.Property<int>("ResimId")
                        .HasColumnType("int");

                    b.HasKey("PaylasimId");

                    b.HasIndex("KullaniciId");

                    b.HasIndex("ResimId");

                    b.ToTable("Paylasimlar");
                });

            modelBuilder.Entity("Exit3.Models.Resim", b =>
                {
                    b.Property<int>("ResimId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ResimDetaylariId")
                        .HasColumnType("int");

                    b.Property<string>("ResimUrl")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("ResimId");

                    b.HasIndex("ResimDetaylariId")
                        .IsUnique();

                    b.ToTable("Resimler");
                });

            modelBuilder.Entity("Exit3.Models.ResimDetaylari", b =>
                {
                    b.Property<int>("ResimDetaylariId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("EtiketId")
                        .HasColumnType("int");

                    b.Property<string>("ResimAciklama")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("ResimDate")
                        .HasColumnType("datetime(6)");

                    b.HasKey("ResimDetaylariId");

                    b.HasIndex("EtiketId");

                    b.ToTable("ResimDetaylari");
                });

            modelBuilder.Entity("Exit3.Models.Yorumlar", b =>
                {
                    b.Property<int>("YorumId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ResimId")
                        .HasColumnType("int");

                    b.Property<string>("Yorum")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("YorumId");

                    b.HasIndex("ResimId");

                    b.ToTable("Yorumlar");
                });

            modelBuilder.Entity("Exit3.Models.Begeni", b =>
                {
                    b.HasOne("Exit3.Models.Resim", "Resim")
                        .WithMany()
                        .HasForeignKey("ResimId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Resim");
                });

            modelBuilder.Entity("Exit3.Models.Paylasim", b =>
                {
                    b.HasOne("Exit3.Models.Kullanici", "Kullanici")
                        .WithMany()
                        .HasForeignKey("KullaniciId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Exit3.Models.Resim", "Resim")
                        .WithMany()
                        .HasForeignKey("ResimId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Kullanici");

                    b.Navigation("Resim");
                });

            modelBuilder.Entity("Exit3.Models.Resim", b =>
                {
                    b.HasOne("Exit3.Models.ResimDetaylari", "ResimDetaylari")
                        .WithOne("Resim")
                        .HasForeignKey("Exit3.Models.Resim", "ResimDetaylariId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ResimDetaylari");
                });

            modelBuilder.Entity("Exit3.Models.ResimDetaylari", b =>
                {
                    b.HasOne("Exit3.Models.Etiket", "Etiket")
                        .WithMany()
                        .HasForeignKey("EtiketId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Etiket");
                });

            modelBuilder.Entity("Exit3.Models.Yorumlar", b =>
                {
                    b.HasOne("Exit3.Models.Resim", "Resim")
                        .WithMany()
                        .HasForeignKey("ResimId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Resim");
                });

            modelBuilder.Entity("Exit3.Models.ResimDetaylari", b =>
                {
                    b.Navigation("Resim")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
