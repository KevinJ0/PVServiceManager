using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupervicionCajas._helpers.Enums
{
    public enum Sucursal
    {

        Consolidado,
        [Display(Name = "Orense Plaza")]
        OrensePlaza,
        [Display(Name = "Hiper Romana")]
        HiperRomana,
        [Display(Name = "Orense Villa Hermosa")]
        OrenseVillaHermosa,
        [Display(Name = "El Ofertazo")]
        ElOfertazo
    }
}
