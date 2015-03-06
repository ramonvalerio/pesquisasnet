using System.IO;

namespace PesquisasNet.Infra.Interfaces.AWS
{
    public interface IS3Service
    {
        Stream GetFile(string key, string bucketName);

        string UploadFile(Stream file, string bucketName);

        void DeleteFile(string key);
    }
}
