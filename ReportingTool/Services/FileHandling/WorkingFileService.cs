namespace ReportingTool.Services.FileHandling;

public class WorkingFileService
{
    private readonly string _workingDirectory;

    public WorkingFileService()
    {
        _workingDirectory = Path.Combine(
            Path.GetTempPath(),
            "ReportingTool",
            Guid.NewGuid().ToString()
        );

        Directory.CreateDirectory(_workingDirectory);
    }

    public string CreateWorkingCopy(string sourceFilePath)
    {
        if (!File.Exists(sourceFilePath))
        {
            throw new FileNotFoundException(
                "Source file not found.",
                sourceFilePath
            );
        }

        string extension = Path.GetExtension(sourceFilePath);

        string fileName =
            $"{Guid.NewGuid()}{extension}";

        string destinationPath =
            Path.Combine(
                _workingDirectory,
                fileName
            );

        using var sourceStream = new FileStream(
            sourceFilePath,
            FileMode.Open,
            FileAccess.Read,
            FileShare.ReadWrite);

        using var destinationStream = new FileStream(
            destinationPath,
            FileMode.Create,
            FileAccess.Write,
            FileShare.None);

        sourceStream.CopyTo(destinationStream);

        return destinationPath;
    }

    public string CreateWorkingFilePath(
        string extension)
    {
        return Path.Combine(
            _workingDirectory,
            $"{Guid.NewGuid()}{extension}"
        );
    }

    public void Cleanup()
    {
        try
        {
            if (Directory.Exists(_workingDirectory))
            {
                Directory.Delete(
                    _workingDirectory,
                    recursive: true
                );
            }
        }
        catch
        {
            // Temporary cleanup failure should not
            // break the application.
        }
    }
}