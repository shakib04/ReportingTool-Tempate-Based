using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using ReportingTool.Models;

namespace ReportingTool.Services;

public class SettingsService
{
    private readonly string _settingsFolder;
    private readonly string _settingsFilePath;

    private readonly JsonSerializerOptions _jsonOptions =
    new()
    {
        WriteIndented = true,
        Converters =
        {
            new JsonStringEnumConverter()
        }
    };

    public SettingsService()
    {
        string localAppData =
            Environment.GetFolderPath(
                Environment.SpecialFolder.LocalApplicationData);

        _settingsFolder = Path.Combine(
            localAppData,
            "ReportingTool"
        );

        _settingsFilePath = Path.Combine(
            _settingsFolder,
            "settings.json"
        );
    }

    public AppSettings Load()
    {
        try
        {
            if (!File.Exists(_settingsFilePath))
            {
                return new AppSettings();
            }

            string json =
                File.ReadAllText(_settingsFilePath);

            return JsonSerializer.Deserialize<AppSettings>(
                    json,
                    _jsonOptions
            ) ?? new AppSettings();
        }
        catch
        {
            return new AppSettings();
        }
    }

    public void Save(AppSettings settings)
    {
        if (!Directory.Exists(_settingsFolder))
        {
            Directory.CreateDirectory(_settingsFolder);
        }

        string json =
            JsonSerializer.Serialize(settings, _jsonOptions);

        File.WriteAllText(
            _settingsFilePath,
            json
        );
    }
}
