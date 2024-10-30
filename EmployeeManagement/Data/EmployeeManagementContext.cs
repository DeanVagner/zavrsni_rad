using Microsoft.EntityFrameworkCore;
using EmployeeManagement.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace EmployeeManagement.Data
{
    /// <summary>
    /// Baza podataka za aplikaciju za upravljanje zaposlenicima.
    /// Upravljanja pristupom tablici zaposlenika.
    /// </summary>
    public class EmployeeManagementContext : DbContext
    {
        /// <summary>
        /// Dohvaća ili postavlja tablicu zaposlenika.
        /// </summary>
        public DbSet<Employee> Employees { get; set; }

        /// <summary>
        /// Inicijalizira novu instancu klase <see cref="EmployeeManagementContext"/>.
        /// </summary>
        /// <param name="options">Opcije za konfiguraciju konteksta.</param>
        public EmployeeManagementContext(DbContextOptions<EmployeeManagementContext> options) : base(options) { }

        /// <summary>
        /// Konfigurira model za kontekst.
        /// </summary>
        /// <param name="modelBuilder">Graditelj modela.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }
    }
}
