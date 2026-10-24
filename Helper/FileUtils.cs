namespace Employee_Self_Service_Capstone.Helper;

public class FileUtils
{
   private const long MaxFileSize = 5 * 1024 * 1024;

    private static readonly Dictionary<string, string[]> AllowedFiles =
        new()
        {
            [".pdf"] = new[] { "application/pdf" },
            [".jpg"] = new[] { "image/jpeg" },
            [".jpeg"] = new[] { "image/jpeg" },
            [".png"] = new[] { "image/png" }
        };

    public static async Task<string> SaveFileAsync(
        IFormFile file,
        string storagePath,
        CancellationToken cancellationToken = default)
    {
        if (file == null || file.Length == 0)
        {
            throw new Exception("A file is required.");
        }

        if (file.Length > MaxFileSize)
        {
            throw new Exception("File size cannot exceed 5 MB.");
        }

        var extension = Path.GetExtension(file.FileName).ToLowerInvariant();

        if (!AllowedFiles.TryGetValue(extension, out var contentTypes) ||
            !contentTypes.Contains(file.ContentType, StringComparer.OrdinalIgnoreCase))
        {
            throw new Exception("Only PDF, JPG, JPEG and PNG files are allowed.");
        }

        Directory.CreateDirectory(storagePath);

        var fileName = $"{Guid.NewGuid():N}{extension}";
        var fullPath = Path.Combine(storagePath, fileName);

        await using var stream = new FileStream(
            fullPath,
            FileMode.CreateNew,
            FileAccess.Write,
            FileShare.None);

        await file.CopyToAsync(stream, cancellationToken);

        return fileName;
    }

    public static string GetFilePath(string storagePath, string fileName)
    {
        if (string.IsNullOrWhiteSpace(fileName) || fileName != Path.GetFileName(fileName))
        {
            throw new Exception("Invalid file name.");
        }

        return Path.Combine(storagePath, fileName);
    }

    public static void DeleteFileIfExists(string storagePath, string fileName)
    {
        if (string.IsNullOrWhiteSpace(fileName) || fileName != Path.GetFileName(fileName))
        {
            return;
        }

        var fullPath = Path.Combine(storagePath, fileName);
        if (File.Exists(fullPath))
        {
            File.Delete(fullPath);
        }
    }
}