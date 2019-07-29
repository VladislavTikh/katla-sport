namespace KatlaSport.Services.BlobManagment
{
    using System;
    using System.Configuration;
    using System.Threading.Tasks;
    using Microsoft.WindowsAzure.Storage;
    using Microsoft.WindowsAzure.Storage.Blob;

    public class AzureBlobConnectionFactory : IAzureBlobConnectionFactory
    {
        private CloudBlobClient _blobClient;
        private CloudBlobContainer _blobContainer;

        public AzureBlobConnectionFactory()
        {
        }

        public async Task<CloudBlobContainer> GetBlobContainer()
        {
            if (_blobContainer != null)
            {
                return _blobContainer;
            }

            var containerName = ConfigurationManager.AppSettings["ContainerName"].ToString();
            if (string.IsNullOrWhiteSpace(containerName))
            {
                throw new ArgumentException("Configuration must contain ContainerName");
            }

            var blobClient = GetClient();
            _blobContainer = blobClient.GetContainerReference(containerName);
            if (await _blobContainer.CreateIfNotExistsAsync())
            {
                await _blobContainer.SetPermissionsAsync(new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Blob });
            }

            return _blobContainer;
        }

        public CloudBlobClient GetClient()
        {
            if (_blobClient != null)
            {
                return _blobClient;
            }

            var storageConnectionString = ConfigurationManager.AppSettings["StorageConnectionString"].ToString();
            if (string.IsNullOrWhiteSpace(storageConnectionString))
            {
                throw new ArgumentException("Configuration must contain StorageConnectionString");
            }

            if (!CloudStorageAccount.TryParse(storageConnectionString, out CloudStorageAccount storageAccount))
            {
                throw new Exception("Could not create storage account with StorageConnectionString configuration");
            }

            _blobClient = storageAccount.CreateCloudBlobClient();
            return _blobClient;
        }
    }
}
