using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using SharpNL.DocumentCategorizer;
using SharpNL.Utility;

namespace AudioProcessing.Core
{
    public enum SentimentAnalyzeSource { File, Text }
    public enum SentimentAnalyzeResult { Negative, Positive }

    public class SentimentAnalyzer : IDisposable
    {
        private FileStream fileStream = null;
        private PlainTextByLineStream plainTextStream = null;

        public SentimentAnalyzeSource Source { get; private set; }
        public string SourceFilePath { get; private set; }
        public string SourceText     { get; private set; }

        public const string DEFAULT_SENTIMENT_FILE_ENCODING = "UTF-8";

        public SentimentAnalyzer(SentimentAnalyzeSource source, string sourceValue)
        {
            Source = source;
            switch (source)
            {
                case SentimentAnalyzeSource.File:
                    SourceFilePath = sourceValue;
                    break;
                case SentimentAnalyzeSource.Text:
                    SourceText = sourceValue;
                    break;
            }
            if (Source == SentimentAnalyzeSource.File && !File.Exists(sourceValue))
                throw new FileNotFoundException(string.Format("Source file does not exist for sentiment analysis:{0}", sourceValue));
        }

        public string GetSourceText()
        {
            return Source == SentimentAnalyzeSource.File ? GetTextFileContent(SourceFilePath) : SourceText;
        }

        public SentimentAnalyzeResult Analyze()
        {
            var model     = Train();
            var category  = new DocumentCategorizerME(model);
            var evaluator = new DocumentCategorizerEvaluator(category);
            //var expectedDocumentCategory = "Movies";
            var content   = GetSourceText();
            var sample    = new DocumentSample("Call", content);
            var distribution      = category.Categorize(content);
            var predictedCategory = category.GetBestCategory(distribution);

            using (var stream = new FileStream(Path.Combine(AppConfig.GetAppBasePath(), "en-sentiment.bin"), FileMode.Append))
                SerializeHelper.Serialize(stream, model);
            return predictedCategory.ConvertRawResultAsSentimentResult();
        }

        public IObjectStream<DocumentSample> GetSentimentModelStream()
        {
            Dispose();
            string path     = Path.Combine(AppConfig.GetAppBasePath(), AppConfig.GetConfigValue("SENTIMENT_MODEL_FILE"));
            fileStream      = new FileStream(path, FileMode.Open, FileAccess.Read);
            plainTextStream = new PlainTextByLineStream(fileStream);
            return new DocumentSampleStream(plainTextStream);
        }

        public DocumentCategorizerModel Train(DocumentCategorizerFactory factory = null)
        {
            return DocumentCategorizerME.Train("en", GetSentimentModelStream(), 
                                                TrainingParameters.DefaultParameters(), 
                                                factory != null ? factory : new DocumentCategorizerFactory());
        }

        public static string GetTextFileContent(string filePath)
        {
            try
            {
                using (var stream = File.OpenText(filePath))
                    return stream.ReadToEnd();
            }
            catch { }
            return string.Empty;
        }

        public void Dispose()
        {
            if (fileStream != null)
            {
                fileStream.Close();
                fileStream.Dispose();
            }
            if (plainTextStream != null)
                plainTextStream.Dispose();
        }
    }
}
