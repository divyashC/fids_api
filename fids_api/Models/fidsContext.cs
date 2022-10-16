using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace fids_api.Models
{
    public partial class fidsContext : DbContext
    {
        public fidsContext()
        {
        }

        public fidsContext(DbContextOptions<fidsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<FlightDetail> FlightDetails { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FlightDetail>(entity =>
            {
                entity.HasKey(e => e.FlightId);

                entity.ToTable("flight_details");

                entity.Property(e => e.FlightId).HasColumnName("flight_id");

                entity.Property(e => e.Airline)
                    .HasMaxLength(50)
                    .HasColumnName("airline");

                entity.Property(e => e.ArrivalTerminal).HasColumnName("arrival_terminal");

                entity.Property(e => e.ArrivalTime)
                    .HasColumnType("time(0)")
                    .HasColumnName("arrival_time");

                entity.Property(e => e.DepartureTerminal).HasColumnName("departure_terminal");

                entity.Property(e => e.DepartureTime)
                    .HasColumnType("time(0)")
                    .HasColumnName("departure_time");

                entity.Property(e => e.Destination)
                    .HasMaxLength(40)
                    .HasColumnName("destination");

                entity.Property(e => e.DestinationIata)
                    .HasMaxLength(5)
                    .HasColumnName("destination_iata");

                entity.Property(e => e.FlightDate)
                    .HasColumnType("date")
                    .HasColumnName("flight_date");

                entity.Property(e => e.FlightDuration)
                    .HasMaxLength(15)
                    .HasColumnName("flight_duration");

                entity.Property(e => e.FlightNo)
                    .HasMaxLength(10)
                    .HasColumnName("flight_no");

                entity.Property(e => e.Origin)
                    .HasMaxLength(40)
                    .HasColumnName("origin");

                entity.Property(e => e.OriginIata)
                    .HasMaxLength(5)
                    .HasColumnName("origin_iata");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
