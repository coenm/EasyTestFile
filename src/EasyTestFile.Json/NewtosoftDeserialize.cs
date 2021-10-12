namespace EasyTestFile.Json
{
    using System.IO;
    using System.Threading.Tasks;
    using Newtonsoft.Json;

    public static class NewtonsoftDeserialize
    {
        public static Task<T> AsObjectUsingNewtonsoft<T>(this TestFile testFile)
        {
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
}
