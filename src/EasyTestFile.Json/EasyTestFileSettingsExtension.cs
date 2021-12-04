namespace EasyTestFile.Json;

using System;
using Newtonsoft.Json;

/// <summary>
/// 
/// </summary>
public static class EasyTestFileSettingsExtension
{
    /// <summary>
    /// Set <paramref name="jsonSerializer"/> as the default json serializer when deserializing testfiles.
    /// </summary>
    /// <param name="settings">The settings.</param>
    /// <param name="jsonSerializer">The serializer.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="settings"/> or when <paramref name="jsonSerializer"/> is <c>null</c>.</exception>
    /// <exception cref="Exception">Thrown when key cannot be inserted.</exception>
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

    internal static JsonSerializer? GetNewtonSoftJsonSerializerSettings(this EasyTestFileSettings settings)
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