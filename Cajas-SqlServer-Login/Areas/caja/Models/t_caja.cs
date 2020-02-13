using Cajas_SqlServer_Login.Areas.carpeta.Models;
using Cajas_SqlServer_Login.Areas.tipo_caja.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Cajas_SqlServer_Login.Areas.caja.Models
{
    public class t_caja
    {
        // 1 caja en muchas carpetas
        // cada caja tiene un tipo de caja
        [Key]
        public int idtcaja { get; set; }

        [Display(Name = "Fecha de Registro")]
        [DataType(DataType.Date)] //formao de fecha
        public DateTime fecha_registro { get; set; }

        [Display(Name = "Fecha de Cierre")]
        [DataType(DataType.Date)]
        public DateTime fecha_cierre { get; set; }

        [Display(Name = "Usuario")]
        public string usuario { get; set; }

        [Required(ErrorMessage = "Ingrese un año")]
        [Display(Name = "Año")]
        public int anio { get; set; }

        //llave foranea
        [Required(ErrorMessage = "Seleccione un tipo")]
        [Display(Name = "Tipo de caja")]
        public int tipo { get; set; }
        [ForeignKey("tipo")]
        [Display(Name = "Tipo de caja")]
        //[JsonIgnore]
        //[IgnoreDataMember]
        public virtual t_tipo_caja rtipocaja { get; set; } //referencia a t_tipo_caja
        //para poder obtener la lista de todas las carpetas que pertenescan a la caja
        public virtual ICollection<t_carpeta> lcarpeta { get; set; }
    }
}
