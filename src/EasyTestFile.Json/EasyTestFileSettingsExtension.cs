namespace EasyTestFile.Json;

using System;
using Newtonsoft.Json;

/// <summary>
/// 
/// </summary>
public static class EasyTestFileSettingsExtension
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="settings"></param>
    /// <param name="jsonSerializer"></param>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="Exception"></exception>
    public static void SetNewtonSoftJsonSerializerSettings(this EasyTestFileSettings settings, JsonSerializer jsonSerializer)
    {
        if (settings == null)
        {
            throw new ArgumentNullException(nameof(settings));
        }

        if (jsonSerializer == null)
        {
            throw new ArgumentNullException(nameof(jsonSerializer));
        }

        if (settings.Context.ContainsKey(ExtensionKey.JSON_SERIALIZER))
        {
            settings.Context[ExtensionKey.JSON_SERIALIZER] = jsonSerializer;
            return;
        }

        try
        {
            settings.Context.Add(ExtensionKey.JSON_SERIALIZER, jsonSerializer);
        }
        catch (Exception e)
        {
            throw new($"Could not add settings", e);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="settings"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static JsonSerializer? GetNewtonSoftJsonSerializerSettings(this EasyTestFileSettings settings)
    {
        if (settings == null)
        {
            throw new ArgumentNullException(nameof(settings));
        }

        if (!settings.Context.TryGetValue(ExtensionKey.JSON_SERIALIZER, out var value))
        {
            return null;
        }

        return value as JsonSerializer;
    }

}