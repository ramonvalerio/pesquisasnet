using System;
using System.Collections;
using System.Collections.Generic;
using Amazon;
using Amazon.SimpleEmail;
using Amazon.SimpleEmail.Model;
using PesquisasNet.Infra.Interfaces.AWS;

namespace PesquisasNet.Infra.Services.AWS
{
    public class SESService : AWSServiceBase, ISESService
    {
        const string from = "contatopesquisasnet@gmail.com";
        private AmazonSimpleEmailServiceConfig _config = new AmazonSimpleEmailServiceConfig();
        private AmazonSimpleEmailServiceClient _client;

        public SESService()
        {
            _config.RegionEndpoint = RegionEndpoint.USEast1;
            _config.ProxyPort = 25;
            _client = new AmazonSimpleEmailServiceClient(_config);
        }

        public void EnviarEmail(IList destinos, string subject, string body)
        {
            destinos.Add(from);

            var _destination = new Destination((List<string>)destinos);
            var _content_subject = new Content(subject);
            var _content_body = new Content(body);
            var _body = new Body(_content_body);

            var message = new Message(_content_subject, _body);
            var _sendEmailRequest = new SendEmailRequest(from, _destination, message);

            _config.RegionEndpoint = RegionEndpoint.USEast1;
            _client = new AmazonSimpleEmailServiceClient(_config);

            try
            {
                _client.SendEmail(_sendEmailRequest);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
