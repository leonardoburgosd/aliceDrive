using AliceDriveEntity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AliceDriveData.Interfaces
{
    public interface IPostConsummer
    {
        Task<List<Post>> getByUsuario(AppSettings settings, int usuario);
        Task<string> create(AppSettings settings, Post post);
    }
}
