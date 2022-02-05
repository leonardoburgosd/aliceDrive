using AliceDriveData.Interfaces;
using AliceDriveEntity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AliceDriveData.Implementation
{
    public class PostConsummer : IPostConsummer
    {
        private readonly IDapper dapper;
        public PostConsummer(IDapper dapper)
        {
            this.dapper = dapper;
        }
        public async Task<string> create(AppSettings settings, Post post)
        {
            try
            {
                dynamic response = await dapper.Consultas<dynamic>(settings.ConexionString, "Post_create", new
                {
                    @DetallePost = post.DetallePost,
                    @UsuarioId = post.UsuarioId
                });
                return "Post creado correctamente.";
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<List<Post>> getByUsuario(AppSettings settings, int usuario)
        {
            try
            {
                return await dapper.Consultas<Post>(settings.ConexionString, "Post_getByUserId", new {
                    @UsuarioId = usuario
                });
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
