using System;
using System.Collections.Generic;
using System.Text;

namespace AliceDriveEntity
{
    public class Post
    {
        public int IDPost {get;set;}
        public string DetallePost { get; set; }
        public string Tipo { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int UsuarioId { get; set; }
    }
}
