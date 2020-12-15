using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EP.API.Models
{ 

    public class Carrera
    {
        //public Carrera()
        //{
        //    CursoCarrera = new HashSet<CursoCarrera>();
        //    Curso = new HashSet<Curso>();
        //}

        [Key]
        public int IdCarrera { get; set; }
        public string NombreCarrera { get; set; }
        public List<SelectListItem> Cursos  { get; set; }
        
        public string[] SelectedCursos { get; set; }

        //public virtual ICollection<CursoCarrera> CursoCarrera { get; set; }
        //public virtual ICollection<Curso> Curso { get; set; }
    }
}
