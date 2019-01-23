using System.IO;
using System.Web;

namespace Pruebas.Backend.Helpers
{
    public static class FilesHelper
    {
        //Metodo para subir una imagen
        public static string UploadPhoto(HttpPostedFileBase archivo, string carpeta)
        {
            string ruta = string.Empty;
            string foto = string.Empty;
            if (archivo != null)
            {
                foto = Path.GetFileName(archivo.FileName);
                ruta = Path.Combine(HttpContext.Current.Server.MapPath(carpeta), foto);
                archivo.SaveAs(ruta);
            }
            return foto;
        }
    }
}