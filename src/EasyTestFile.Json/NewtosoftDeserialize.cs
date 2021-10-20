namespace EasyTestFile.Json;

using System;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;

/// <summary>
/// Containing extension method for deserializing an <see cref="TestFile"/> using Newtonsoft json.
/// </summary>
public static class NewtonsoftDeserialize
{
    /// <summary>
    /// Deserializes the <paramref name="testFile"/> using <see cref="Newtonsoft"/>.
    /// </summary>
    /// <param name="testFile">The TestFile. Cannot be null</param>
    /// <typeparam name="T">The type of the object to deserialize.</typeparam>
    /// <returns>The instance of <typeparamref name="T"/> being deserialized.</returns>
    public static Task<T> AsObjectUsingNewtonsoft<T>(this TestFile testFile)
    {
        if (testFile == null)
        {
            throw new ArgumentNullException(nameof(testFile));
        }

        return Task.FromResult(DeserializeFromStream<T>(testFile.AsStream()));
    }

    internal static T DeserializeFromStream<T>(Stream stream)
    {
        var serializer = new JsonSerializer();
        using var sr = new StreamReader(stream);
        using var jsonTextReader = new JsonTextReader(sr);
        return serializer.Deserialize<T>(jsonTextReader)!;
    }
}