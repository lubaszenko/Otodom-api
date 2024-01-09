using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Otodom.Models;

namespace Otodom
{
    public partial class OtodomContext : DbContext
    {
        public OtodomContext()
        {
        }

        public OtodomContext(DbContextOptions<OtodomContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Agencja> Agencjas { get; set; } = null!;
        public virtual DbSet<Dzialka> Dzialkas { get; set; } = null!;
        public virtual DbSet<Garaz> Garazs { get; set; } = null!;
        public virtual DbSet<Klient> Klients { get; set; } = null!;
        public virtual DbSet<Nieruchomosc> Nieruchomoscs { get; set; } = null!;
        public virtual DbSet<Ogloszenie> Ogloszenies { get; set; } = null!;
        public virtual DbSet<RodzajGruntu> RodzajGruntus { get; set; } = null!;
        public virtual DbSet<RodzajOkna> RodzajOknas { get; set; } = null!;
        public virtual DbSet<RodzajZabudowy> RodzajZabudowies { get; set; } = null!;
        public virtual DbSet<StanWykonanium> StanWykonania { get; set; } = null!;
        public virtual DbSet<TypOgrzewanium> TypOgrzewania { get; set; } = null!;
        public virtual DbSet<WykonczenieGrazu> WykonczenieGrazus { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=127.0.0.1,1433;Database=Otodom;User=sa;Password=zaq1@WSX;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Agencja>(entity =>
            {
                entity.HasKey(e => e.IdAgencji)
                    .HasName("agencja_PK");

                entity.ToTable("agencja");

                entity.Property(e => e.IdAgencji)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_agencji");

                entity.Property(e => e.Email)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.NazwaAgencji)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("nazwa_agencji");

                entity.Property(e => e.Nip)
                    .HasColumnType("numeric(20, 0)")
                    .HasColumnName("nip");

                entity.Property(e => e.NrTelefonuAgencji)
                    .HasColumnType("numeric(9, 0)")
                    .HasColumnName("nr_telefonu_agencji");
            });

            modelBuilder.Entity<Dzialka>(entity =>
            {
                entity.HasKey(e => e.IdDzialki)
                    .HasName("dzialka_PK");

                entity.ToTable("dzialka");

                entity.HasIndex(e => e.RodzajGruntuIdRodzajGruntu, "dzialka__IDX")
                    .IsUnique();

                entity.HasIndex(e => e.NieruchomoscIdNieruchomosci, "dzialka__IDXv1")
                    .IsUnique();

                entity.Property(e => e.IdDzialki)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_dzialki");

                entity.Property(e => e.NieruchomoscIdNieruchomosci).HasColumnName("nieruchomosc_ID_nieruchomosci");

                entity.Property(e => e.PowierzchniaDzialki)
                    .HasColumnType("numeric(10, 0)")
                    .HasColumnName("powierzchnia_dzialki");

                entity.Property(e => e.RodzajGruntuIdRodzajGruntu).HasColumnName("rodzaj_gruntu_ID_rodzaj_gruntu");

                entity.HasOne(d => d.NieruchomoscIdNieruchomosciNavigation)
                    .WithOne(p => p.Dzialka)
                    .HasForeignKey<Dzialka>(d => d.NieruchomoscIdNieruchomosci)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("dzialka_nieruchomosc_FK");

                entity.HasOne(d => d.RodzajGruntuIdRodzajGruntuNavigation)
                    .WithOne(p => p.Dzialka)
                    .HasForeignKey<Dzialka>(d => d.RodzajGruntuIdRodzajGruntu)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("dzialka_rodzaj_gruntu_FK");
            });

            modelBuilder.Entity<Garaz>(entity =>
            {
                entity.HasKey(e => e.IdGarazu)
                    .HasName("garaz_PK");

                entity.ToTable("garaz");

                entity.HasIndex(e => e.WykonczenieGrazuIdWykonczenieGarazu, "garaz__IDX")
                    .IsUnique();

                entity.Property(e => e.IdGarazu)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_garazu");

                entity.Property(e => e.NieruchomoscIdNieruchomosci).HasColumnName("nieruchomosc_ID_nieruchomosci");

                entity.Property(e => e.PowierzchniaGarazu)
                    .HasColumnType("numeric(7, 0)")
                    .HasColumnName("powierzchnia_garazu");

                entity.Property(e => e.WykonczenieGrazuIdWykonczenieGarazu).HasColumnName("wykonczenie_grazu_ID_wykonczenie_garazu");

                entity.HasOne(d => d.NieruchomoscIdNieruchomosciNavigation)
                    .WithMany(p => p.Garazs)
                    .HasForeignKey(d => d.NieruchomoscIdNieruchomosci)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("garaz_nieruchomosc_FK");

                entity.HasOne(d => d.WykonczenieGrazuIdWykonczenieGarazuNavigation)
                    .WithOne(p => p.Garaz)
                    .HasForeignKey<Garaz>(d => d.WykonczenieGrazuIdWykonczenieGarazu)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("garaz_wykonczenie_grazu_FK");
            });

            modelBuilder.Entity<Klient>(entity =>
            {
                entity.HasKey(e => e.IdKlienta)
                    .HasName("klient_PK");

                entity.ToTable("klient");

                entity.Property(e => e.IdKlienta)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_klienta");

                entity.Property(e => e.AgencjaIdAgencji).HasColumnName("agencja_ID_agencji");

                entity.Property(e => e.Email)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Imie)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("imie");

                entity.Property(e => e.Nazwisko)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("nazwisko");

                entity.Property(e => e.NrTelefonuKlienta)
                    .HasColumnType("numeric(9, 0)")
                    .HasColumnName("nr_telefonu_klienta");

                entity.HasOne(d => d.AgencjaIdAgencjiNavigation)
                    .WithMany(p => p.Klients)
                    .HasForeignKey(d => d.AgencjaIdAgencji)
                    .HasConstraintName("klient_agencja_FK");
            });

            modelBuilder.Entity<Nieruchomosc>(entity =>
            {
                entity.HasKey(e => e.IdNieruchomosci)
                    .HasName("nieruchomosc_PK");

                entity.ToTable("nieruchomosc");

                entity.HasIndex(e => e.RodzajZabudowyIdRodzajZabudowy, "nieruchomosc__IDX")
                    .IsUnique();

                entity.HasIndex(e => e.RodzajOknaIdRodzajOkna, "nieruchomosc__IDXv1")
                    .IsUnique();

                entity.HasIndex(e => e.StanWykonaniaIdStanWykonania, "nieruchomosc__IDXv2")
                    .IsUnique();

                entity.HasIndex(e => e.TypOgrzewaniaIdTypOgrzewania, "nieruchomosc__IDXv3")
                    .IsUnique();

                entity.HasIndex(e => e.DzialkaIdDzialki, "nieruchomosc__IDXv4")
                    .IsUnique();

                entity.Property(e => e.IdNieruchomosci)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_nieruchomosci");

                entity.Property(e => e.DzialkaIdDzialki).HasColumnName("dzialka_ID_dzialki");

                entity.Property(e => e.KodPocztowy)
                    .HasColumnType("numeric(10, 0)")
                    .HasColumnName("kod_pocztowy");

                entity.Property(e => e.LiczbaPieter)
                    .HasColumnType("numeric(3, 0)")
                    .HasColumnName("liczba_pieter");

                entity.Property(e => e.Miasto)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("miasto");

                entity.Property(e => e.NrDomu)
                    .HasColumnType("numeric(10, 0)")
                    .HasColumnName("nr_domu");

                entity.Property(e => e.PowierzchniaDomu)
                    .HasColumnType("numeric(10, 0)")
                    .HasColumnName("powierzchnia_domu");

                entity.Property(e => e.RodzajOknaIdRodzajOkna).HasColumnName("rodzaj_okna_ID_rodzaj_okna");

                entity.Property(e => e.RodzajZabudowyIdRodzajZabudowy).HasColumnName("rodzaj_zabudowy_ID_rodzaj_zabudowy");

                entity.Property(e => e.RokBudowy)
                    .HasColumnType("numeric(4, 0)")
                    .HasColumnName("rok_budowy");

                entity.Property(e => e.StanWykonaniaIdStanWykonania).HasColumnName("stan_wykonania_ID_stan_wykonania");

                entity.Property(e => e.TypOgrzewaniaIdTypOgrzewania).HasColumnName("typ_ogrzewania_ID_typ_ogrzewania");

                entity.Property(e => e.Ulica)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("ulica");

                entity.Property(e => e.Wojewodztwo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("wojewodztwo");

                entity.HasOne(d => d.DzialkaIdDzialkiNavigation)
                    .WithOne(p => p.Nieruchomosc)
                    .HasForeignKey<Nieruchomosc>(d => d.DzialkaIdDzialki)
                    .HasConstraintName("nieruchomosc_dzialka_FK");

                entity.HasOne(d => d.RodzajOknaIdRodzajOknaNavigation)
                    .WithOne(p => p.Nieruchomosc)
                    .HasForeignKey<Nieruchomosc>(d => d.RodzajOknaIdRodzajOkna)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("nieruchomosc_rodzaj_okna_FK");

                entity.HasOne(d => d.RodzajZabudowyIdRodzajZabudowyNavigation)
                    .WithOne(p => p.Nieruchomosc)
                    .HasForeignKey<Nieruchomosc>(d => d.RodzajZabudowyIdRodzajZabudowy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("nieruchomosc_rodzaj_zabudowy_FK");

                entity.HasOne(d => d.StanWykonaniaIdStanWykonaniaNavigation)
                    .WithOne(p => p.Nieruchomosc)
                    .HasForeignKey<Nieruchomosc>(d => d.StanWykonaniaIdStanWykonania)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("nieruchomosc_stan_wykonania_FK");

                entity.HasOne(d => d.TypOgrzewaniaIdTypOgrzewaniaNavigation)
                    .WithOne(p => p.Nieruchomosc)
                    .HasForeignKey<Nieruchomosc>(d => d.TypOgrzewaniaIdTypOgrzewania)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("nieruchomosc_typ_ogrzewania_FK");
            });

            modelBuilder.Entity<Ogloszenie>(entity =>
            {
                entity.HasKey(e => e.IdOgloszenia)
                    .HasName("ogloszenie_PK");

                entity.ToTable("ogloszenie");

                entity.Property(e => e.IdOgloszenia)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_ogloszenia");

                entity.Property(e => e.Cena)
                    .HasColumnType("numeric(10, 0)")
                    .HasColumnName("cena");

                entity.Property(e => e.DataDodania)
                    .HasColumnType("date")
                    .HasColumnName("data_dodania");

                entity.Property(e => e.KlientIdKlienta).HasColumnName("klient_ID_klienta");

                entity.Property(e => e.NieruchomoscIdNieruchomosci).HasColumnName("nieruchomosc_ID_nieruchomosci");

                entity.Property(e => e.Opis)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("opis");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Tytul)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("tytul");

                entity.HasOne(d => d.KlientIdKlientaNavigation)
                    .WithMany(p => p.Ogloszenies)
                    .HasForeignKey(d => d.KlientIdKlienta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ogloszenie_klient_FK");

                entity.HasOne(d => d.NieruchomoscIdNieruchomosciNavigation)
                    .WithMany(p => p.Ogloszenies)
                    .HasForeignKey(d => d.NieruchomoscIdNieruchomosci)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ogloszenie_nieruchomosc_FK");
            });

            modelBuilder.Entity<RodzajGruntu>(entity =>
            {
                entity.HasKey(e => e.IdRodzajGruntu)
                    .HasName("rodzaj_gruntu_PK");

                entity.ToTable("rodzaj_gruntu");

                entity.Property(e => e.IdRodzajGruntu)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_rodzaj_gruntu");

                entity.Property(e => e.RodzajGruntu1)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("rodzaj_gruntu");
            });

            modelBuilder.Entity<RodzajOkna>(entity =>
            {
                entity.HasKey(e => e.IdRodzajOkna)
                    .HasName("rodzaj_okna_PK");

                entity.ToTable("rodzaj_okna");

                entity.Property(e => e.IdRodzajOkna)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_rodzaj_okna");

                entity.Property(e => e.RodzajOkna1)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("rodzaj_okna");
            });

            modelBuilder.Entity<RodzajZabudowy>(entity =>
            {
                entity.HasKey(e => e.IdRodzajZabudowy)
                    .HasName("rodzaj_zabudowy_PK");

                entity.ToTable("rodzaj_zabudowy");

                entity.Property(e => e.IdRodzajZabudowy)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_rodzaj_zabudowy");

                entity.Property(e => e.RodzajZabudowy1)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("rodzaj_zabudowy");
            });

            modelBuilder.Entity<StanWykonanium>(entity =>
            {
                entity.HasKey(e => e.IdStanWykonania)
                    .HasName("stan_wykonania_PK");

                entity.ToTable("stan_wykonania");

                entity.Property(e => e.IdStanWykonania)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_stan_wykonania");

                entity.Property(e => e.StanWykonania)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("stan_wykonania");
            });

            modelBuilder.Entity<TypOgrzewanium>(entity =>
            {
                entity.HasKey(e => e.IdTypOgrzewania)
                    .HasName("typ_ogrzewania_PK");

                entity.ToTable("typ_ogrzewania");

                entity.Property(e => e.IdTypOgrzewania)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_typ_ogrzewania");

                entity.Property(e => e.TypOgrzewania)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("typ_ogrzewania");
            });

            modelBuilder.Entity<WykonczenieGrazu>(entity =>
            {
                entity.HasKey(e => e.IdWykonczenieGarazu)
                    .HasName("wykonczenie_grazu_PK");

                entity.ToTable("wykonczenie_grazu");

                entity.Property(e => e.IdWykonczenieGarazu)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_wykonczenie_garazu");

                entity.Property(e => e.WykonczenieGarazu)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("wykonczenie_garazu");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
