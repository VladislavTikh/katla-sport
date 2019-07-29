namespace KatlaSport.Services.BlobManagment
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Web;

    public interface IBlobService
    {
        Task<IEnumerable<Uri>> ListAsync();

        Task UploadAsync(HttpPostedFile fileData);

        Task DeleteAsync(string fileUri);

        Task<string> GetBlobUriAsync();
    }
}
