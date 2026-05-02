using CloudinaryDotNet;
using CloudinaryDotNet.Actions;

public class CloudinaryService
{
    private readonly Cloudinary _cloudinary;

    public CloudinaryService(IConfiguration config)
    {
        var account = new Account(
            config["CloudinarySettings:CloudName"],
            config["CloudinarySettings:ApiKey"],
            config["CloudinarySettings:ApiSecret"]
        );

        _cloudinary = new Cloudinary(account);
    }

    public async Task<string> UploadAsync(IFormFile file)
    {
        using var stream = file.OpenReadStream();

        RawUploadParams uploadParams;

        if (file.ContentType.StartsWith("image"))
        {
            uploadParams = new ImageUploadParams
            {
                File = new FileDescription(file.FileName, stream)
            };
        }
        else
        {
            uploadParams = new VideoUploadParams
            {
                File = new FileDescription(file.FileName, stream)
            };
        }

        var result = await _cloudinary.UploadAsync(uploadParams);
        return result.SecureUrl.ToString();
    }

    public async Task<List<Resource>> GetAllMediaAsync()
    {
        var resources = new List<Resource>();

        var result = await _cloudinary.ListResourcesAsync(new ListResourcesParams()
        {
            MaxResults = 50
        });

        resources.AddRange(result.Resources);

        // get videos also
        var videoResult = await _cloudinary.ListResourcesAsync(new ListResourcesParams()
        {
            ResourceType = ResourceType.Video,
            MaxResults = 50
        });

        resources.AddRange(videoResult.Resources);

        return resources;
    }

    public async Task DeleteAsync(string publicId, string resourceType)
    {
        if (resourceType == "video")
        {
            await _cloudinary.DestroyAsync(new DeletionParams(publicId)
            {
                ResourceType = ResourceType.Video
            });
        }
        else
        {
            await _cloudinary.DestroyAsync(new DeletionParams(publicId));
        }
    }
}