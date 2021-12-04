using System;

namespace AliceDriveEntity
{
    public class Files
    {
        public int FilesId { get; set; }
        public string FileBase { get; set; }
        public string FileNombre { get; set; }
        public int FilePadreID { get; set; }
        public long FileSize { get; set; }
        public string FileType { get; set; }
        public int FileUsuarioRegistro { get; set; }
        public DateTime FileFechaRegistro { get; set; }
        public int FileUsuarioModificado { get; set; }
        public DateTime FileFechaModificado { get; set; }
        public Boolean FileEliminado { get; set; }
    }
}
