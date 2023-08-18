using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKART.USER.CORE.Services.Azure
{
    public interface IStorageService
    {

        Task<string> UploadAsync(string containerName, byte[] content, string fileName, string contentType, CancellationToken cancellation);
        Task<string> UploadAsync(string containerName, byte[] content, string fileName, string contentType,bool overwriteIfExists, CancellationToken cancellation);
    }
}
