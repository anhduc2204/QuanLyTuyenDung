﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QuanLyTuyenDung.Models;

#nullable disable

namespace QuanLyTuyenDung.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240721184023_initDatabase")]
    partial class initDatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.31")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("QuanLyTuyenDung.Models.DonUngTuyen", b =>
                {
                    b.Property<int>("MaDon")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("iMaDon");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaDon"), 1L, 1);

                    b.Property<string>("MoTa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("sMoTa");

                    b.Property<int>("iMaND")
                        .HasColumnType("int");

                    b.Property<int>("iMaViecLam")
                        .HasColumnType("int");

                    b.HasKey("MaDon");

                    b.HasIndex("iMaND");

                    b.HasIndex("iMaViecLam");

                    b.ToTable("tbl_DonUngTuyen");
                });

            modelBuilder.Entity("QuanLyTuyenDung.Models.NguoiDung", b =>
                {
                    b.Property<int>("MaND")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("iMaND");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaND"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("sEmail");

                    b.Property<string>("GioiTinh")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasColumnName("sGioiTinh");

                    b.Property<DateTime?>("NgaySinh")
                        .HasColumnType("datetime2")
                        .HasColumnName("dNgaySinh");

                    b.Property<string>("SDT")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)")
                        .HasColumnName("sSDT");

                    b.Property<string>("TenND")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("sTenND");

                    b.Property<int>("iMaTaiKhoan")
                        .HasColumnType("int");

                    b.HasKey("MaND");

                    b.HasIndex("iMaTaiKhoan")
                        .IsUnique();

                    b.ToTable("tbl_NguoiDung");
                });

            modelBuilder.Entity("QuanLyTuyenDung.Models.QuyenHan", b =>
                {
                    b.Property<int>("MaQuyen")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("iMaQuyen");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaQuyen"), 1L, 1);

                    b.Property<string>("TenQuyen")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("sTenQuyen");

                    b.HasKey("MaQuyen");

                    b.ToTable("tbl_QuyenHan");
                });

            modelBuilder.Entity("QuanLyTuyenDung.Models.TaiKhoan", b =>
                {
                    b.Property<int>("MaTaiKhoan")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("iMaTaiKhoan");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaTaiKhoan"), 1L, 1);

                    b.Property<string>("MatKhau")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("sMatKhau");

                    b.Property<string>("TenTaiKhoan")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("sTaiKhoan");

                    b.Property<int>("iMaQuyen")
                        .HasColumnType("int");

                    b.HasKey("MaTaiKhoan");

                    b.HasIndex("iMaQuyen");

                    b.ToTable("tbl_TaiKhoan");
                });

            modelBuilder.Entity("QuanLyTuyenDung.Models.ThongBao", b =>
                {
                    b.Property<int>("MaTB")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("iMaTB");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaTB"), 1L, 1);

                    b.Property<string>("FromEmail")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("sFromEmail");

                    b.Property<string>("NoiDung")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("sNoiDung");

                    b.Property<string>("TieuDe")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("sTieuDe");

                    b.Property<string>("ToEmail")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("sToEmail");

                    b.Property<int>("iMaND")
                        .HasColumnType("int");

                    b.HasKey("MaTB");

                    b.HasIndex("iMaND");

                    b.ToTable("tbl_ThongBao");
                });

            modelBuilder.Entity("QuanLyTuyenDung.Models.ViecLam", b =>
                {
                    b.Property<int>("MaViecLam")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("iMaViecLam");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaViecLam"), 1L, 1);

                    b.Property<string>("MoTa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("sMota");

                    b.Property<double>("MucLuong")
                        .HasColumnType("float")
                        .HasColumnName("fMucLuong");

                    b.Property<DateTime>("NgayHetHan")
                        .HasColumnType("datetime2")
                        .HasColumnName("dNgayHetHan");

                    b.Property<DateTime>("NgayTao")
                        .HasColumnType("datetime2")
                        .HasColumnName("dNgayTao");

                    b.Property<string>("TieuDe")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("sTieuDe");

                    b.Property<bool>("TrangThai")
                        .HasColumnType("bit")
                        .HasColumnName("bTrangThai");

                    b.HasKey("MaViecLam");

                    b.ToTable("tbl_ViecLam");
                });

            modelBuilder.Entity("QuanLyTuyenDung.Models.DonUngTuyen", b =>
                {
                    b.HasOne("QuanLyTuyenDung.Models.NguoiDung", "NguoiDung")
                        .WithMany()
                        .HasForeignKey("iMaND")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QuanLyTuyenDung.Models.ViecLam", "ViecLam")
                        .WithMany("DSDonUT")
                        .HasForeignKey("iMaViecLam")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("NguoiDung");

                    b.Navigation("ViecLam");
                });

            modelBuilder.Entity("QuanLyTuyenDung.Models.NguoiDung", b =>
                {
                    b.HasOne("QuanLyTuyenDung.Models.TaiKhoan", "TaiKhoan")
                        .WithOne("NguoiDung")
                        .HasForeignKey("QuanLyTuyenDung.Models.NguoiDung", "iMaTaiKhoan")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TaiKhoan");
                });

            modelBuilder.Entity("QuanLyTuyenDung.Models.TaiKhoan", b =>
                {
                    b.HasOne("QuanLyTuyenDung.Models.QuyenHan", "QuyenHan")
                        .WithMany()
                        .HasForeignKey("iMaQuyen")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("QuyenHan");
                });

            modelBuilder.Entity("QuanLyTuyenDung.Models.ThongBao", b =>
                {
                    b.HasOne("QuanLyTuyenDung.Models.NguoiDung", "NguoiDung")
                        .WithMany()
                        .HasForeignKey("iMaND")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("NguoiDung");
                });

            modelBuilder.Entity("QuanLyTuyenDung.Models.TaiKhoan", b =>
                {
                    b.Navigation("NguoiDung")
                        .IsRequired();
                });

            modelBuilder.Entity("QuanLyTuyenDung.Models.ViecLam", b =>
                {
                    b.Navigation("DSDonUT");
                });
#pragma warning restore 612, 618
        }
    }
}
