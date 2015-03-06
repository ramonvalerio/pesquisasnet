using System;
using System.Linq;
using System.Collections.Generic;
using System.Configuration;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using PesquisasNet.Domain.Interfaces;
using PesquisasNet.Infra.Interfaces.AWS;

namespace PesquisasNet.Infra.Contexto
{
    public class DDBContext : IDDBContext, IDisposable
    {
        private string _awsAccessKeyId = "AKIAJ2OOTCRW6SGNUOYA";
        private string _awsSecretAccessKey = "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";
        private AmazonDynamoDBConfig _config;
        private AmazonDynamoDBClient _client;
        private DynamoDBContext _context;

        public DDBContext()
        {
            _config = new AmazonDynamoDBConfig { ServiceURL = "http://dynamodb.us-east-1.amazonaws.com" };
            //_config = new AmazonDynamoDBConfig { ServiceURL = "http://localhost:8000" };
            _client = new AmazonDynamoDBClient(_awsAccessKeyId, _awsSecretAccessKey, _config);
            _context = new DynamoDBContext(_client);
        }

        public DDBContext(string accessKey, string secretKey)
        {
            this._awsAccessKeyId = accessKey;
            this._awsSecretAccessKey = secretKey;

            _config = new AmazonDynamoDBConfig { ServiceURL = "http://dynamodb.us-east-1.amazonaws.com" };
            _client = new AmazonDynamoDBClient(_awsAccessKeyId, _awsSecretAccessKey, _config);
            _context = new DynamoDBContext(_client);
        }

        public T GetByHashKey<T>(object hashKey)
        {
            var obj = _context.Load<T>(hashKey);
            return obj;
        }

        public T GetByHashKeyAndRangeKey<T>(object hashKey, object rangeKey)
        {
            var obj = _context.Load<T>(hashKey, rangeKey);
            return obj;
        }

        public IEnumerable<T> ListAll<T>()
        {
            var result = _context.Scan<T>().AsEnumerable<T>();
            return result;
        }

        public void Save<T>(T value)
        {
            _context.Save<T>(value);
        }

        public void Delete<T>(object hashKey)
        {
            _context.Delete<T>(hashKey);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        protected bool ExisteDataModel()
        {
            return false;
        }

        #region CreateTable
        protected void CreateTable(string tableName, string hashKey, long readCapacityUnits, long writeCapacityUnits)
        {
            var request = new CreateTableRequest
            {
                TableName = tableName,
                AttributeDefinitions = new List<AttributeDefinition>()
            {
            new AttributeDefinition
            {
                AttributeName = hashKey,
                AttributeType = "N"
            }
            },
                KeySchema = new List<KeySchemaElement>()
            {
            new KeySchemaElement
            {
                AttributeName = hashKey,
                KeyType = "HASH"
            }
            },
                ProvisionedThroughput = new ProvisionedThroughput
                {
                    ReadCapacityUnits = readCapacityUnits,
                    WriteCapacityUnits = writeCapacityUnits
                }
            };

            var response = _client.CreateTable(request);
        }

        protected void CreateTable(string tableName, string hashKey, string rangeKey, long readCapacityUnits, long writeCapacityUnits)
        {
            var request = new CreateTableRequest
            {
                TableName = tableName,
                AttributeDefinitions = new List<AttributeDefinition>()
            {
            new AttributeDefinition
            {
                AttributeName = hashKey,
                AttributeType = "N"
            },
            new AttributeDefinition
            {
                AttributeName = rangeKey,
                AttributeType = "N"
            }
            },
                KeySchema = new List<KeySchemaElement>()
            {
            new KeySchemaElement
            {
                AttributeName = hashKey,
                KeyType = "HASH"
            },
            new KeySchemaElement
            {
                AttributeName = rangeKey,
                KeyType = "RANGE"
            }
            },
                ProvisionedThroughput = new ProvisionedThroughput
                {
                    ReadCapacityUnits = readCapacityUnits,
                    WriteCapacityUnits = writeCapacityUnits
                }
            };

            var response = _client.CreateTable(request);
        }
        #endregion
    }
}
