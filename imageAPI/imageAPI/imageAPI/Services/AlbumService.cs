using BAL.Configurations;
using BAL.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace BAL.Services
{
    public class AlbumService : AppDbContext, IAlbumService
    {
        
        public async Task<List<AlbumsDTO>> GetAlbumsList()
        {
            try
            {
                OpenContext();
                var query = "select * from albums";
                DataTable tbl_albums = await _sqlCommand.Select_Table(query,CommandType.Text);

                List<AlbumsDTO> albums = new List<AlbumsDTO>();

                foreach (DataRow item in tbl_albums.Rows)
                {
     
                    albums.Add(new AlbumsDTO
                    {
                        albumID = Convert.ToInt32(item["albumID"]),
                        albumName = item["albumName"].ToString(),
                        albumImagePath = await ReadImageFileAsync(item["albumImagePath"].ToString(), item["albumImageContentType"].ToString()), 
                        albumImageContentType = item["albumImageContentType"].ToString()
                    });
                }


                return albums;
            }
            catch(Exception)
            {
                throw new Exception();
            }
            finally
            {
                CloseContext();
            } 
        }

        public async Task<List<AlbumsImagesDTO>> GetAlbumsImagesList(int albumID)
        {
            try
            {
                OpenContext();
                _sqlCommand.Add_Parameter_WithValue("prm_albumID",albumID);
                var query = "select * from albums_images where albumID = @prm_albumID";
                DataTable tbl_albums_imgages = await _sqlCommand.Select_Table(query, CommandType.Text);

                List<AlbumsImagesDTO> albumsImages = new List<AlbumsImagesDTO>();

                foreach (DataRow item in tbl_albums_imgages.Rows) 
                {
                    albumsImages.Add(
                        new AlbumsImagesDTO
                        {
                            imageID = Convert.ToInt32(item["imageID"]),
                            albumID = Convert.ToInt32(item["albumID"]),
                            imageName = item["imageName"].ToString(),
                            imagePath = await ReadImageFileAsync(item["imagePath"].ToString(), item["imageContentType"].ToString()),
                            imageContentType = item["imageContentType"].ToString()
                        });
                }
                return albumsImages;
            }
            catch (Exception)
            {
                throw new Exception();
            }
            finally
            {
                CloseContext();
            }
        }

        public async Task<FileContentResult> ReadImageFileAsync(string yourImageDirectory, string yourContentType)
        {
            string imageDirectory = Path.Combine(Directory.GetCurrentDirectory(), yourImageDirectory);
            byte[] imageBytes = await File.ReadAllBytesAsync(imageDirectory);
            string ContentType = yourContentType;
            return new FileContentResult(imageBytes, ContentType);
        }


    }
}
