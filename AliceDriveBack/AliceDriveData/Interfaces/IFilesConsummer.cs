using AliceDriveEntity;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AliceDriveData.Interfaces
{
    public interface IFilesConsummer
    {
        Task createDisk(AppSettings settings, Files file, int usuario);// Discos
        Task<List<Files>> getDisk(AppSettings settings, int usuario); //Discos
        Task upload(AppSettings settings, Files files, IFormFile file, int usuario);//Archivos
        Task<List<Files>> getChildren(AppSettings settings, string baseId, int usuario);
        Task<(string, string, string)> download(AppSettings settings, string baseId, int usuario);
    }
}
