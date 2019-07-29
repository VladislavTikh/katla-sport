namespace KatlaSport.Services.BlobManagment
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Web;
    using Microsoft.WindowsAzure.Storage.Blob;

    public class BlobService : IBlobService
    {

        private readonly IAzureBlobConnectionFactory _azureBlobConnectionFactory;

        public BlobService(IAzureBlobConnectionFactory azureBlobConnectionFactory)
        {
            _azureBlobConnectionFactory = azureBlobConnectionFactory;
        }

        public Task DeleteAsync(string fileUri)
        {
            throw new NotImplementedException();
        }

        public async Task<string> GetBlobUriAsync()
        {
            var blobContainer = await _azureBlobConnectionFactory.GetBlobContainer();
            return blobContainer.Uri.AbsoluteUri;
        }

        public async Task<IEnumerable<Uri>> ListAsync()
        {
            var blobContainer = await _azureBlobConnectionFactory.GetBlobContainer();
            var allBlobs = new List<Uri>();
            BlobContinuationToken blobContinuationToken = null;
            do
            {
                var response = await blobContainer.ListBlobsSegmentedAsync(blobContinuationToken);
                foreach (IListBlobItem blob in response.Results)
                {
                    if (blob.GetType() == typeof(CloudBlockBlob))
                    {
                        allBlobs.Add(blob.Uri);
                    }
                }

                blobContinuationToken = response.ContinuationToken;
            }
            while (blobContinuationToken != null);
            return allBlobs;
        }

        public async Task UploadAsync(HttpPostedFile fileData)
        {
            var blobContainer = await _azureBlobConnectionFactory.GetBlobContainer();
            var blobItemName = fileData.FileName;
            var blob = blobContainer.GetBlockBlobReference(blobItemName);
            await blob.UploadFromStreamAsync(fileData.InputStream);
        }
    }
}
