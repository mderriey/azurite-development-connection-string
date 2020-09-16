using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Azure.Storage.Blobs;

namespace AzuriteDevelopmentConnectionString
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var blobServiceClient = new BlobServiceClient("UseDevelopmentStorage=true");
            
            var containerClient = blobServiceClient.GetBlobContainerClient("azurite");
            await containerClient.CreateIfNotExistsAsync();

            var content = Guid.NewGuid().ToString("n").Substring(0, 8);
            var fileName = $"{content}.txt";

            using var uploadStream = new MemoryStream(Encoding.ASCII.GetBytes(content));
            await containerClient.UploadBlobAsync(fileName, uploadStream);

            var blobClient = containerClient.GetBlobClient(fileName);
            var downloadResponse = await blobClient.DownloadAsync();

            using var downloadStream = new MemoryStream();
            using var downloadStreamReader = new StreamReader(downloadStream);
            await blobClient.DownloadToAsync(downloadStream);

            downloadStream.Position = 0;
            var value = await downloadStreamReader.ReadToEndAsync();

            Console.WriteLine(value);
        }
    }
}
