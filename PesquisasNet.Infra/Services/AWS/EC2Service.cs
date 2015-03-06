using Amazon.EC2;

namespace PesquisasNet.Infra.Services.AWS
{
    public class EC2Service
    {
        private string _awsAccessKeyId = "AKIAJ2OOTCRW6SGNUOYA";
        private string _awsSecretAccessKey = "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";
        private AmazonEC2Config _config;
        private AmazonEC2Client _client;

        public EC2Service()
        {
            _config = new AmazonEC2Config { ServiceURL = "http://dynamodb.us-east-1.amazonaws.com" };
            _client = new AmazonEC2Client(_awsAccessKeyId, _awsSecretAccessKey, _config);
        }

        public EC2Service(string accessKey, string secretKey)
        {
            this._awsAccessKeyId = accessKey;
            this._awsSecretAccessKey = secretKey;

            _config = new AmazonEC2Config { ServiceURL = "http://dynamodb.us-east-1.amazonaws.com" };
            _client = new AmazonEC2Client(_awsAccessKeyId, _awsSecretAccessKey, _config);
            // new AmazonEC2Client(RegionEndpoint.EUCentral1);
        }
    }
}
