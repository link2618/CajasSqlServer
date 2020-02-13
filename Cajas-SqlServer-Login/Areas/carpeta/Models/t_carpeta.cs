using Cajas_SqlServer_Login.Areas.caja.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Cajas_SqlServer_Login.Areas.carpeta.Models
{
    public class t_carpeta
    {
        // cada carpeta tiene 1 caja
        [Key]
        public int idcarpeta { get; set; }

        [Required(ErrorMessage = "Ingrese un nit")]
        [Display(Name = "Nit")]
        public int nit { get; set; }

        [Display(Name = "Fecha de Registro")]
        [DataType(DataType.Date)]
        public DateTime fecha_registro { get; set; }

        [Display(Name = "Fecha de Cierre")]
        [DataType(DataType.Date)]
        public DateTime fecha_cierre { get; set; }

        //llave foranea haciendo referencia a t_caja
        [Required(ErrorMessage = "Seleccione una caja")]
        [Display(Name = "Caja")]
        public int caja { get; set; }
        [ForeignKey("caja")]
        [Display(Name = "Caja")]
        public virtual t_caja rcaja { get; set; } // referencia a t_caja
    }
}
