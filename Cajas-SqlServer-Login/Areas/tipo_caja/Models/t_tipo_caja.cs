using Cajas_SqlServer_Login.Areas.caja.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cajas_SqlServer_Login.Areas.tipo_caja.Models
{
    public class t_tipo_caja
    {
        // 1 tipo de caja en mcuhas cajas
        [Key]
        public int idtipocaja { get; set; }
        [Required(ErrorMessage = "Ingrese un Nombre")]
        [Display(Name = "Nombre")]
        public string nombre { get; set; }
        //para poder obtener la lista de todas las cajas que pertenescan al tipo de caja
        public virtual ICollection<t_caja> lcaja { get; set; }
    }
}
