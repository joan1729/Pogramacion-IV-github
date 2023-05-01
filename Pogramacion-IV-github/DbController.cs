using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace GitHub_programacion
{
    public class DbController:DbContext
    {
        public string ruta { get; set; }
        public DbSet<Estudiante> Estudiantes { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={ruta}");
        public void GuardarEstudiante(Estudiante estudiante)
        {
            DbController db = new DbController();
            db.Add(estudiante);
            db.SaveChanges();
        }
        public List<Estudiante> BuscarEstudiante(string matricula)
        {
            return Estudiantes.Where(o => o.Matricula==matricula).ToList();
        }
        public DbController()
        {
            ruta = "../../../BDEstudiante";
        }
    }
}
