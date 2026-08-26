using System;
using System.Collections.Generic;
using System.Text;

using System.Text.Json;
using ReportingTool.Models;

namespace ReportingTool.Services;

public class SettingsService
{
    private readonly string _settingsFolder;
    private readonly string _settingsFilePath;

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

            return JsonSerializer.Deserialize<AppSettings>(json)
                   ?? new AppSettings();
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

        var options = new JsonSerializerOptions
        {
            WriteIndented = true
        };

        string json =
            JsonSerializer.Serialize(settings, options);

        File.WriteAllText(
            _settingsFilePath,
            json
        );
    }
}
