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
    /// <param name="testFile">The TestFile. Cannot be <c>null</c>.</param>
    /// <typeparam name="T">The type of the object to deserialize.</typeparam>
    /// <returns>The instance of <typeparamref name="T"/> being deserialized.</returns>
    public static Task<T> AsObjectUsingNewtonsoft<T>(this TestFile testFile)
    {
        if (testFile == null)
        {
            throw new ArgumentNullException(nameof(testFile));
        }

        JsonSerializer jsonSerializer = testFile.GetSettings().GetNewtonSoftJsonSerializerSettings() ?? new JsonSerializer();
        return AsObjectUsingNewtonsoft<T>(testFile, jsonSerializer);
    }

    /// <summary>
    /// Deserializes the <paramref name="testFile"/> using <see cref="Newtonsoft"/>.
    /// </summary>
    /// <param name="testFile">The TestFile. Cannot be <c>null</c>.</param>
    /// <param name="serializer">Json serializer. Cannot be <c>null</c>.</param>
    /// <typeparam name="T">The type of the object to deserialize.</typeparam>
    /// <returns>The instance of <typeparamref name="T"/> being deserialized.</returns>
    public static async Task<T> AsObjectUsingNewtonsoft<T>(this TestFile testFile, JsonSerializer serializer)
    {
        if (testFile == null)
        {
            throw new ArgumentNullException(nameof(testFile));
        }

        if (serializer == null)
        {
            throw new ArgumentNullException(nameof(serializer));
        }

        Stream stream = await testFile.AsStream().ConfigureAwait(false);
        return DeserializeFromStream<T>(stream, serializer);
    }

    internal static T DeserializeFromStream<T>(Stream stream, JsonSerializer jsonSerializer)
    {
        using var sr = new StreamReader(stream);
        using var jsonTextReader = new JsonTextReader(sr);
        return jsonSerializer.Deserialize<T>(jsonTextReader)!;
    }
}