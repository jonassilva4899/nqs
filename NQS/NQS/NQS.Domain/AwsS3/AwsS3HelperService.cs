﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;
using Amazon.Util;
using Microsoft.Extensions.Logging;

namespace CSharpAwsS3ServiceManager.AwsS3
{
    public class AwsS3HelperService : IAwsS3HelperService
    {
        private readonly ILogger<AwsS3HelperService> _logger;
        private readonly IAmazonS3 _s3Client;
        private readonly AwsS3BucketOptions _s3BucketOptions;

        public AwsS3HelperService(IAmazonS3 s3Client, AwsS3BucketOptions s3BucketOptions,
            ILogger<AwsS3HelperService> logger)
        {
            _s3Client = s3Client;
            _logger = logger;
            _s3BucketOptions = s3BucketOptions;
        }

        /// <summary>
        /// upload de imagem base64
        /// </summary>
        /// <param name="fileStream"></param>
        /// <param name="fileName"></param>
        /// <param name="directory"></param>
        /// <returns></returns>
        public async Task<bool> UploadFileAsync(string arquivoBase64, string nomeArquivo, string directory = null)
        {
            try
            {
                var contentType = arquivoBase64.Split(';')[0].Split(':')[1];
                var bucketPath = !string.IsNullOrWhiteSpace(directory)
                    ? _s3BucketOptions.BucketName + @"/" + directory
                    : _s3BucketOptions.BucketName;
                arquivoBase64 = arquivoBase64.Split(',')[1];

                arquivoBase64 = arquivoBase64.Replace('_', '/').Replace('-', '+');
                switch (arquivoBase64.Length % 4)
                {
                    case 2: arquivoBase64 += "=="; break;
                    case 3: arquivoBase64 += "="; break;
                }
                byte[] bytes = Convert.FromBase64String(arquivoBase64);
                var stream = new MemoryStream(bytes);
                var putRequest = new PutObjectRequest
                {
                    ContentType = contentType,
                    BucketName = _s3BucketOptions.BucketName,
                    Key = nomeArquivo,
                    CannedACL = S3CannedACL.BucketOwnerFullControl,
                    InputStream = stream
                };
                var response = await _s3Client.PutObjectAsync(putRequest);
                if (response.HttpStatusCode == HttpStatusCode.OK)
                {
                    _logger.LogInformation(
                        $"upload com sucesso {nomeArquivo} para {bucketPath} às {DateTime.UtcNow:O}");
                    return true;
                }

                _logger.LogError($"falhou no upload {nomeArquivo} para {bucketPath} às {DateTime.UtcNow:O}");
                return false;
            }
            catch (AmazonS3Exception amazonS3Exception)
            {
                if (amazonS3Exception.ErrorCode != null &&
                    (amazonS3Exception.ErrorCode.Equals("InvalidAccessKeyId") ||
                     amazonS3Exception.ErrorCode.Equals("InvalidSecurity")))
                {
                    _logger.LogError("Por favor, cheque as credenciais da AWS.");
                }
                else
                {
                    _logger.LogError(
                        $"Ocorreu o erro: '{amazonS3Exception.Message}' fazendo o upload do arquivo: {nomeArquivo}");
                }

                return false;
            }
        }

        /// <summary>
        /// uploads file to s3 bucket using file stream
        /// </summary>
        /// <param name="fileStream"></param>
        /// <param name="fileName"></param>
        /// <param name="directory"></param>
        /// <returns></returns>
        public async Task<bool> UploadExcelFileAsync(Stream fileStream, string fileName, string directory = null)
        {
            try
            {
                var fileTransferUtility = new TransferUtility(_s3Client);
                var bucketPath = !string.IsNullOrWhiteSpace(directory)
                    ? _s3BucketOptions.BucketName + @"/" + directory
                    : _s3BucketOptions.BucketName;

                var putRequest = new PutObjectRequest
                {
                    ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                    BucketName = _s3BucketOptions.BucketName,
                    Key = fileName,
                    CannedACL = S3CannedACL.BucketOwnerFullControl,
                    InputStream = fileStream
                };
                var response = await _s3Client.PutObjectAsync(putRequest);
                if (response.HttpStatusCode == HttpStatusCode.OK)
                {
                    _logger.LogInformation(
                        $"upload com sucesso {fileName} para {bucketPath} às {DateTime.UtcNow:O}");
                    return true;
                }

                _logger.LogError($"falhou no upload {fileName} para {bucketPath} às {DateTime.UtcNow:O}");
                return false;
            }
            catch (AmazonS3Exception amazonS3Exception)
            {
                if (amazonS3Exception.ErrorCode != null &&
                    (amazonS3Exception.ErrorCode.Equals("InvalidAccessKeyId") ||
                     amazonS3Exception.ErrorCode.Equals("InvalidSecurity")))
                {
                    _logger.LogError("Please check the provided AWS Credentials.");
                }
                else
                {
                    _logger.LogError(
                        $"An error occurred with the message '{amazonS3Exception.Message}' when uploading {fileName}");
                }
                return false;
            }
        }

        /// <summary>
        /// uploads file to s3 bucket using file stream
        /// </summary>
        /// <param name="fileStream"></param>
        /// <param name="fileName"></param>
        /// <param name="directory"></param>
        /// <returns></returns>
        public async Task<bool> UploadArquivoFileAsync(Stream fileStream, string fileName, string contentType, string directory = null)
        {
            try
            {
                var fileTransferUtility = new TransferUtility(_s3Client);
                var bucketPath = !string.IsNullOrWhiteSpace(directory)
                    ? _s3BucketOptions.BucketName + @"/" + directory
                    : _s3BucketOptions.BucketName;

                var putRequest = new PutObjectRequest
                {
                    ContentType = contentType,
                    BucketName = _s3BucketOptions.BucketName,
                    Key = fileName,
                    CannedACL = S3CannedACL.BucketOwnerFullControl,
                    InputStream = fileStream
                };
                var response = await _s3Client.PutObjectAsync(putRequest);
                if (response.HttpStatusCode == HttpStatusCode.OK)
                {
                    _logger.LogInformation(
                        $"upload com sucesso {fileName} para {bucketPath} às {DateTime.UtcNow:O}");
                    return true;
                }

                _logger.LogError($"falhou no upload {fileName} para {bucketPath} às {DateTime.UtcNow:O}");
                return false;
            }
            catch (AmazonS3Exception amazonS3Exception)
            {
                if (amazonS3Exception.ErrorCode != null &&
                    (amazonS3Exception.ErrorCode.Equals("InvalidAccessKeyId") ||
                     amazonS3Exception.ErrorCode.Equals("InvalidSecurity")))
                {
                    _logger.LogError("Please check the provided AWS Credentials.");
                }
                else
                {
                    _logger.LogError(
                        $"An error occurred with the message '{amazonS3Exception.Message}' when uploading {fileName}");
                }
                return false;
            }
        }

        /// <summary>
        /// uploads file to s3 bucket using file stream
        /// </summary>
        /// <param name="fileStream"></param>
        /// <param name="fileName"></param>
        /// <param name="directory"></param>
        /// <returns></returns>
        public async Task<bool> UploadFileAsync(Stream fileStream, string nomeArquivo, string directory = null)
        {
            try
            {
                var fileTransferUtility = new TransferUtility(_s3Client);
                var bucketPath = !string.IsNullOrWhiteSpace(directory)
                    ? _s3BucketOptions.BucketName + @"/" + directory
                    : _s3BucketOptions.BucketName;

                var putRequest = new PutObjectRequest
                {
                    BucketName = _s3BucketOptions.BucketName,
                    Key = nomeArquivo,
                    CannedACL = S3CannedACL.BucketOwnerFullControl,
                    InputStream = fileStream
                };
                var response = await _s3Client.PutObjectAsync(putRequest);
                if (response.HttpStatusCode == HttpStatusCode.OK)
                {
                    _logger.LogInformation(
                        $"upload com sucesso {nomeArquivo} para {bucketPath} às {DateTime.UtcNow:O}");
                    return true;
                }

                _logger.LogError($"falhou no upload {nomeArquivo} para {bucketPath} às {DateTime.UtcNow:O}");
                return false;
            }
            catch (AmazonS3Exception amazonS3Exception)
            {
                if (amazonS3Exception.ErrorCode != null &&
                    (amazonS3Exception.ErrorCode.Equals("InvalidAccessKeyId") ||
                     amazonS3Exception.ErrorCode.Equals("InvalidSecurity")))
                {
                    _logger.LogError("Please check the provided AWS Credentials.");
                }
                else
                {
                    _logger.LogError(
                        $"An error occurred with the message '{amazonS3Exception.Message}' when uploading {nomeArquivo}");
                }

                return false;
            }
        }

        /// <summary>
        /// uploads file to s3 bucket from specified file path
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="directory"></param>
        /// <returns></returns>
        public async Task<bool> UploadFileAsync(string filePath, string directory = null)
        {
            try
            {
                var fileTransferUtility = new TransferUtility(_s3Client);
                var bucketPath = !string.IsNullOrWhiteSpace(directory)
                    ? _s3BucketOptions.BucketName + @"/" + directory
                    : _s3BucketOptions.BucketName;
                // 1. Upload a file, file name is used as the object key name.
                var fileUploadRequest = new TransferUtilityUploadRequest()
                {
                    CannedACL = S3CannedACL.PublicRead,
                    BucketName = bucketPath,
                    FilePath = filePath,
                };
                fileUploadRequest.UploadProgressEvent += (sender, args) =>
                    _logger.LogInformation($"{args.FilePath} upload complete : {args.PercentDone}%");
                await fileTransferUtility.UploadAsync(fileUploadRequest);
                _logger.LogInformation($"successfully uploaded {filePath} to {bucketPath} on {DateTime.UtcNow:O}");
                return true;
            }
            catch (AmazonS3Exception amazonS3Exception)
            {
                if (amazonS3Exception.ErrorCode != null &&
                    (amazonS3Exception.ErrorCode.Equals("InvalidAccessKeyId") ||
                     amazonS3Exception.ErrorCode.Equals("InvalidSecurity")))
                {
                    _logger.LogInformation("Please check the provided AWS Credentials.");
                }
                else
                {
                    _logger.LogError(
                        $"An error occurred with the message '{amazonS3Exception.Message}' when uploading {filePath}");
                }

                return false;
            }
        }

        /// <summary>
        /// writes file to s3 bucket using specified contents, content type
        /// </summary>
        /// <param name="contents"></param>
        /// <param name="contentType"></param>
        /// <param name="fileName"></param>
        /// <param name="directory"></param>
        /// <returns></returns>
        public async Task<bool> UploadFileAsync(string contents, string contentType, string fileName,
            string directory = null)
        {
            try
            {
                var bucketPath = !string.IsNullOrWhiteSpace(directory)
                    ? _s3BucketOptions.BucketName + @"/" + directory
                    : _s3BucketOptions.BucketName;
                //1. put object 
                var putRequest = new PutObjectRequest
                {
                    BucketName = bucketPath,
                    Key = fileName,
                    ContentBody = contents,
                    ContentType = contentType,
                    CannedACL = S3CannedACL.PublicRead
                };
                var response = await _s3Client.PutObjectAsync(putRequest);
                if (response.HttpStatusCode == HttpStatusCode.OK)
                {
                    _logger.LogInformation($"successfully uploaded {fileName} to {bucketPath} on {DateTime.UtcNow:O}");
                    return true;
                }

                _logger.LogError($"failed to upload {fileName} to {bucketPath} on {DateTime.UtcNow:O}");
                return false;
            }
            catch (AmazonS3Exception amazonS3Exception)
            {
                if (amazonS3Exception.ErrorCode != null &&
                    (amazonS3Exception.ErrorCode.Equals("InvalidAccessKeyId") ||
                     amazonS3Exception.ErrorCode.Equals("InvalidSecurity")))
                {
                    Console.WriteLine("Please check the provided AWS Credentials.");
                }
                else
                {
                    _logger.LogError(
                        $"An error occurred with the message '{amazonS3Exception.Message}' when writing {fileName}");
                }

                return false;
            }
        }

        /// <summary>
        /// returns file stream from s3 bucket
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="directory"></param>
        /// <returns></returns>
        public async Task<(Stream FileStream, string ContentType)> ReadFileAsync(string fileName,
            string directory = null)
        {
            try
            {
                var fileTransferUtility = new TransferUtility(_s3Client);
                var bucketPath = !string.IsNullOrWhiteSpace(directory)
                    ? _s3BucketOptions.BucketName + @"/" + directory
                    : _s3BucketOptions.BucketName;
                var request = new GetObjectRequest()
                {
                    BucketName = bucketPath,
                    Key = fileName
                };
                // 1. read files
                var objectResponse = await fileTransferUtility.S3Client.GetObjectAsync(request);
                return (objectResponse.ResponseStream, objectResponse.Headers.ContentType);
            }
            catch (AmazonS3Exception amazonS3Exception)
            {
                if (amazonS3Exception.ErrorCode != null &&
                    (amazonS3Exception.ErrorCode.Equals("InvalidAccessKeyId") ||
                     amazonS3Exception.ErrorCode.Equals("InvalidSecurity")))
                {
                    _logger.LogError("Please check the provided AWS Credentials.");
                }
                else
                {
                    _logger.LogError("An error occurred with the message '{0}' when reading an object",
                        amazonS3Exception.Message);
                }

                return (null, null);
            }
        }

        /// <summary>
        /// returns files from s3 folder
        /// </summary>
        /// <param name="directory"></param>
        /// <returns></returns>
        public async Task<List<(Stream FileStream, string fileName, string ContentType)>> ReadDirectoryAsync(
            string directory)
        {
            var objectCollection = new List<(Stream, string, string)>();
            try
            {
                var fileTransferUtility = new TransferUtility(_s3Client);
                var request = new ListObjectsRequest()
                {
                    BucketName = _s3BucketOptions.BucketName,
                    Prefix = directory
                };
                // 1. read files
                var objectResponse = await fileTransferUtility.S3Client.ListObjectsAsync(request);
                foreach (var entry in objectResponse.S3Objects)
                {
                    var fileName = entry.Key.Split('/').Last();
                    if (!string.IsNullOrEmpty(fileName))
                    {
                        var response = await ReadFileAsync(fileName, directory);
                        objectCollection.Add((response.FileStream, fileName, response.ContentType));
                    }
                }

                return objectCollection;
            }
            catch (AmazonS3Exception amazonS3Exception)
            {
                if (amazonS3Exception.ErrorCode != null &&
                    (amazonS3Exception.ErrorCode.Equals("InvalidAccessKeyId") ||
                     amazonS3Exception.ErrorCode.Equals("InvalidSecurity")))
                {
                    _logger.LogError("Please check the provided AWS Credentials.");
                }
                else
                {
                    _logger.LogError("An error occurred with the message '{0}' when reading an object",
                        amazonS3Exception.Message);
                }

                return objectCollection;
            }
        }

        /// <summary>
        /// moves file (object) between bucket folders
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="sourceDirectory"></param>
        /// <param name="destDirectory"></param>
        /// <returns></returns>
        public async Task<bool> MoveFileAsync(string fileName, string sourceDirectory, string destDirectory)
        {
            try
            {
                var copyRequest = new CopyObjectRequest
                {
                    SourceBucket = _s3BucketOptions.BucketName + @"/" + sourceDirectory,
                    SourceKey = fileName,
                    DestinationBucket = _s3BucketOptions.BucketName + @"/" + destDirectory,
                    DestinationKey = fileName
                };
                var response = await _s3Client.CopyObjectAsync(copyRequest);
                if (response.HttpStatusCode == HttpStatusCode.OK)
                {
                    var deleteRequest = new DeleteObjectRequest
                    {
                        BucketName = _s3BucketOptions.BucketName + @"/" + sourceDirectory,
                        Key = fileName
                    };
                    await _s3Client.DeleteObjectAsync(deleteRequest);
                    return true;
                }

                return false;
            }
            catch (AmazonS3Exception amazonS3Exception)
            {
                if (amazonS3Exception.ErrorCode != null &&
                    (amazonS3Exception.ErrorCode.Equals("InvalidAccessKeyId") ||
                     amazonS3Exception.ErrorCode.Equals("InvalidSecurity")))
                {
                    Console.WriteLine("Please check the provided AWS Credentials.");
                }
                else
                {
                    _logger.LogError("An error occurred with the message '{0}' when moving object",
                        amazonS3Exception.Message);
                }

                return false;
            }
        }

        /// <summary>
        /// removes file from s3 bucket
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="directory"></param>
        /// <returns></returns>
        public async Task<bool> RemoveFileAsync(string fileName, string directory = null)
        {
            try
            {
                var fileTransferUtility = new TransferUtility(_s3Client);
                var bucketPath = !string.IsNullOrWhiteSpace(directory)
                    ? _s3BucketOptions.BucketName + @"/" + directory
                    : _s3BucketOptions.BucketName;
                // 1. deletes files
                await fileTransferUtility.S3Client.DeleteObjectAsync(new DeleteObjectRequest()
                {
                    BucketName = bucketPath,
                    Key = fileName
                });
                _logger.LogInformation($"successfully deleted {fileName} from {bucketPath}");
                return true;
            }
            catch (AmazonS3Exception s3Exception)
            {
                if (s3Exception.ErrorCode != null &&
                    (s3Exception.ErrorCode.Equals("InvalidAccessKeyId") ||
                     s3Exception.ErrorCode.Equals("InvalidSecurity")))
                {
                    _logger.LogError("Please check the provided AWS Credentials.");
                }
                else
                {
                    _logger.LogError(s3Exception.Message,
                        s3Exception.InnerException);
                }
            }
            catch (Exception e)
            {
                _logger.LogError(
                    "Unknown encountered on server. Message:'{0}' when writing an object"
                    , e.Message);

                throw;
            }

            return false;
        }
    }
}