using System;
using System.Linq;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace AudioProcessing.Core
{
    public sealed class SerializeHelper
    {
        public static string Serialize(Object instance)
        {
            using (var stream = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(stream, instance);
                return stream.ToString();
            }
        }

        public static string Serialize(Stream stream, object instance)
        {
            var formatter = new BinaryFormatter();
            formatter.Serialize(stream, instance);
            return stream.ToString();
        }

        public static string Serialize(Stream stream, SharpNL.DocumentCategorizer.DocumentCategorizerModel instance)
        {
            instance.Serialize(stream);
            return stream.ToString();
        }
    }

    public static class ExtensionMethods
    {
        public static string ConvertRawTextAsSentence(this string value)
        {
            return AudioProcessor.SENTENCE_SEPERATORS.Where(x => value.EndsWith(x)).Count() == 0 ? string.Format("{0}.", value) : value;
        }

        public static SentimentAnalyzeResult ConvertRawResultAsSentimentResult(this string value)
        {
            var result = Convert.ToInt32(string.IsNullOrEmpty(value) ? "0" : value);
            return (SentimentAnalyzeResult)result;
        }
    }
}
