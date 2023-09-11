using BAL.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Services
{
    public interface IAlbumService
    {
        Task<List<AlbumsDTO>> GetAlbumsList();
        Task<List<AlbumsImagesDTO>> GetAlbumsImagesList(int albumID);
    }
}
