using System;

namespace proyecto_proga.CapaDatos
{
    public class Cls_Reparacion
    {
        public int ReparacionID { get; set; }
        public string Estado { get; set; }
        public DateTime Fecha { get; set; }
        public int EquipoID { get; set; }
        public int UsuarioID { get; set; }
        public int TecnicoID { get; set; }
    }
}
