using System;
using System.IO;
using Amazon.S3;
using Amazon.S3.Model;
using PesquisasNet.Infra.Interfaces.AWS;

namespace PesquisasNet.Infra.Services.AWS
{
    public class S3Service : IS3Service
    {
        private AmazonS3Config _config;
        private AmazonS3Client _client;

        //private string _awsAccessKeyId = "AKIAJ2OOTCRW6SGNUOYA";
        //private string _awsSecretAccessKey = "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";
        private string _bucketName;

        public S3Service()
        {
            this._config = new AmazonS3Config();
            this._config.ServiceURL = "http://pesquisasnet.img.s3-website-us-east-1.amazonaws.com";


            this._bucketName = "pesquisasnet.img";
            this._client = new AmazonS3Client(_config);
        }

        public Stream GetFile(string key, string bucketName)
        {
            var request = new GetObjectRequest();
            request.Key = key;
            request.BucketName = _bucketName;

            var response = this._client.GetObject(request);

            return response.ResponseStream;
        }

        public string UploadFile(Stream file, string bucketName)
        {
            string awsAccessKeyId = "AKIAJ2OOTCRW6SGNUOYA";
            string awsSecretAccessKey = "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";

            var config = new AmazonS3Config { ServiceURL = "http://file.pesquisasnet.com.s3-website-us-east-1.amazonaws.com" };
            var client = new AmazonS3Client(awsAccessKeyId, awsSecretAccessKey, config);

            var key = Guid.NewGuid().ToString() + ".jpg";

            PutObjectRequest request = new PutObjectRequest();
            request.BucketName = _bucketName;
            request.Key = key;
            request.InputStream = file;

            var response = client.PutObject(request);

            return key;
        }

        public void DeleteFile(string key)
        {
            DeleteObjectRequest request = new DeleteObjectRequest();
            request.BucketName = _bucketName;
            request.Key = key;

            this._client.DeleteObject(request);
        }
    }
}
