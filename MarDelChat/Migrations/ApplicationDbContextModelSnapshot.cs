// <auto-generated />
using System;
using API_CoreBusiness;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MarDelChat.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("API_CoreBusiness.Authentication.Response.UserResponse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaAlta")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("UserResponse");
                });

            modelBuilder.Entity("API_CoreBusiness.Entities.Chat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Chat");
                });

            modelBuilder.Entity("API_CoreBusiness.Entities.ChatUsuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ChatId")
                        .HasColumnType("int");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<int?>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ChatId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("ChatUsuario");
                });

            modelBuilder.Entity("API_CoreBusiness.Entities.Contactos", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<int?>("UsuarioId")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioId1")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("UsuarioId");

                    b.HasIndex("UsuarioId1");

                    b.ToTable("Contactos");
                });

            modelBuilder.Entity("API_CoreBusiness.Entities.Mensaje", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("ChatId")
                        .HasColumnType("int");

                    b.Property<string>("mensaje")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("time")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ChatId");

                    b.ToTable("Mensaje");
                });

            modelBuilder.Entity("API_CoreBusiness.Entities.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaAlta")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("API_CoreBusiness.Entities.ChatUsuario", b =>
                {
                    b.HasOne("API_CoreBusiness.Entities.Chat", null)
                        .WithMany("usuario")
                        .HasForeignKey("ChatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API_CoreBusiness.Entities.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("API_CoreBusiness.Entities.Contactos", b =>
                {
                    b.HasOne("API_CoreBusiness.Entities.Usuario", null)
                        .WithMany("contactos")
                        .HasForeignKey("UsuarioId");

                    b.HasOne("API_CoreBusiness.Authentication.Response.UserResponse", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("API_CoreBusiness.Entities.Mensaje", b =>
                {
                    b.HasOne("API_CoreBusiness.Entities.Chat", null)
                        .WithMany("mensaje")
                        .HasForeignKey("ChatId");
                });

            modelBuilder.Entity("API_CoreBusiness.Entities.Chat", b =>
                {
                    b.Navigation("mensaje");

                    b.Navigation("usuario");
                });

            modelBuilder.Entity("API_CoreBusiness.Entities.Usuario", b =>
                {
                    b.Navigation("contactos");
                });
#pragma warning restore 612, 618
        }
    }
}
