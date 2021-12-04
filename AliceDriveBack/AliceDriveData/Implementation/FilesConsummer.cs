using AliceDriveData.Interfaces;
using AliceDriveEntity;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace AliceDriveData.Implementation
{
    public class FilesConsummer : IFilesConsummer
    {
        private readonly IDapper dapper;
        public FilesConsummer(IDapper dapper)
        {
            this.dapper = dapper;
        }

        public async Task createDisk(AppSettings settings, Files file, int usuario)
        {
            try
            {
                dynamic response = await dapper.Consultas<dynamic>(settings.ConexionString, "file.Files_create_disk", new
                {
                    @FileNombre = file.FileNombre,
                    @UsuarioID = usuario
                });
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        #region guardarArchivo
        public async Task upload(AppSettings settings, Files files, IFormFile file, int usuario)
        {
            try
            {
                (string, string, string) route = await getFileRoute(settings, files.FileBase, usuario);
                
                if (files.FileType.Equals("folder")) await crearCarpeta(route.Item1+"/"+files.FileNombre);
                else await guardarArchivo(settings, files, file, route.Item1);

                dynamic response = await dapper.Consultas<dynamic>(settings.ConexionString, "file.Files_upload", new
                {
                    @FileNombre = files.FileNombre,
                    @FileSize = files.FileSize,
                    @FileType = files.FileType,
                    @FileBase = files.FileBase,
                    @FileUsuarioRegistro = usuario
                });
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private async Task crearCarpeta(string route)
        {
            try
            {
                if (!Directory.Exists(route)) Directory.CreateDirectory(route);
                else throw new Exception("El directorio ya existe.");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private async Task guardarArchivo(AppSettings settings, Files files, IFormFile file, string route)
        {
            try
            {
                using (FileStream fileStream = new FileStream(route + "/" + files.FileNombre, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        
        #endregion


        public async Task<List<Files>> getDisk(AppSettings settings, int usuario)
        {
            try
            {
                return await dapper.Consultas<Files>(settings.ConexionString, "[file].Files_select_disk", new
                {
                    @UsuarioID = usuario
                });
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<List<Files>> getChildren(AppSettings settings, string baseId, int usuario)
        {
            try
            {
                return await dapper.Consultas<Files>(settings.ConexionString, "[file].Files_select_childs", new
                {
                    @FileBase = baseId,
                    @UsuarioID = usuario
                });
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<(string, string, string)> download(AppSettings settings, string baseId, int usuario)
        {
            try
            {
                (string, string, string) responseRoute = await getFileRoute(settings, baseId, 1);
                string path = responseRoute.Item1;
                string fileName = responseRoute.Item2;
                string fileType = responseRoute.Item3;
                string fileBase64 = Convert.ToBase64String(File.ReadAllBytes(path));
                return (fileBase64, fileType, fileName);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        #region obtiene ruta de un archivo hasta su parent mas alto
        private async Task<(string, string, string)> getFileRoute(AppSettings settings, string baseId, int usuario)
        {
            try
            {
                Files fileConsultingBase = await getFileByBase(settings, baseId, usuario);
                int fileIdPresent = fileConsultingBase.FilePadreID;
                string path = fileConsultingBase.FileNombre;

                while (fileIdPresent > 0)
                {
                    Files fileConsulting = await getFileById(settings, fileIdPresent, usuario);
                    path = fileConsulting.FileNombre + "/" + path;
                    fileIdPresent = fileConsulting.FilePadreID;
                }

                return (path, fileConsultingBase.FileNombre, fileConsultingBase.FileType);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private async Task<Files> getFileById(AppSettings settings, int idFile, int usuario)
        {
            try
            {
                List<Files> files = await dapper.Consultas<Files>(settings.ConexionString, "file.Files_getById", new
                {
                    @FileId = idFile,
                    @UsuarioId = usuario
                });
                return files[0];
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private async Task<Files> getFileByBase(AppSettings settings, string fileBase, int usuario)
        {
            try
            {
                List<Files> files = await dapper.Consultas<Files>(settings.ConexionString, "file.Files_getByBase", new
                {
                    @FileBase = fileBase,
                    @UsuarioId = usuario
                });
                return files[0];
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion


    }
}