namespace KatlaSport.Services.BlobManagment
{
    using System.Threading.Tasks;
    using Microsoft.WindowsAzure.Storage.Blob;

    public interface IAzureBlobConnectionFactory
    {
        Task<CloudBlobContainer> GetBlobContainer();

        CloudBlobClient GetClient();
    }
}
