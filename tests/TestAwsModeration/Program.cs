namespace TestAwsModeration
{
    using System.Reflection;
    using Talegen.Common.Core.Extensions;
    using Talegen.Imaging.Moderation;
    using Talegen.Imaging.Moderation.Aws;

    /// <summary>
    /// This is the main entry point of the test program.
    /// </summary>
    /// <remarks>
    /// To avoid issues with posting test data that is against community rules, the test image dataset has been zipped and password protected with password "testthese"
    /// </remarks>
    internal class Program
    { 
        /// <summary>
        /// Initial main routine of console program.
        /// </summary>
        /// <param name="args">Contains command line arguments.</param>
        static async Task Main(string[] args)
        {
            // configure settings
            AwsImageModerationSettings settings = new AwsImageModerationSettings();
            ImageModerationResult? result = null;

            // you will need to set your credentials in environment variables.
            settings.Connection.Region = Environment.GetEnvironmentVariable("AWS_DEFAULT_REGION").ConvertToString(AwsImageModerationConnectionSettings.DefaultRegion);
            settings.Connection.AccessKey = Environment.GetEnvironmentVariable("AWS_ACCESS_KEY_ID").ConvertToString();
            settings.Connection.Secret = Environment.GetEnvironmentVariable("AWS_SECRET_ACCESS_KEY").ConvertToString();

            // define set of thresholds to evaluate
            settings.Thresholds = [ 
                new ImageModerationThreshold { Type = ModerationLabelTypes.ExplicitNudity, MinimumConfidenceThreshold = .50F },
                new ImageModerationThreshold { Type = ModerationLabelTypes.Suggestive, MinimumConfidenceThreshold = .50F },
                new ImageModerationThreshold { Type = ModerationLabelTypes.HateSymbols, MinimumConfidenceThreshold = .50F },
                new ImageModerationThreshold { Type = ModerationLabelTypes.RudeGestures, MinimumConfidenceThreshold = .50F },
                new ImageModerationThreshold { Type = ModerationLabelTypes.Violence, MinimumConfidenceThreshold = .50F },
                new ImageModerationThreshold { Type = ModerationLabelTypes.VisuallyDisturbing, MinimumConfidenceThreshold = .50F },
                new ImageModerationThreshold { Type = ModerationLabelTypes.Gambling, MinimumConfidenceThreshold = .50F },
                new ImageModerationThreshold { Type = ModerationLabelTypes.Drugs, MinimumConfidenceThreshold = .50F },
            ];

            AwsImageModerationService service = new AwsImageModerationService(settings);

            if (!string.IsNullOrWhiteSpace(settings.EvaluateFileName))
            {
                result = await service.EvaluateAsync();
            }
            else
            {
                string directory = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? string.Empty, "dataset");
                DirectoryInfo directoryInfo = new DirectoryInfo(directory);

                if (directoryInfo.Exists)
                {
                    FileInfo[] files = directoryInfo.GetFiles();
                    Random random = new Random();
                    int testIndex = random.Next(0, files.Length);
                    string fileName = files[testIndex].Name;

                    Console.WriteLine("Evaluating {0}:", fileName);

                    using FileStream fileStream = files[testIndex].Open(FileMode.Open);
                    byte[] contents = await fileStream.ReadAllBytesAsync();

                    result = await service.EvaluateAsync(contents);
                }
            }

            if (result != null)
            {
                if (result.EvaluationSuccess)
                {
                    Console.WriteLine("Evaluation successful.\r\n");
                    Console.WriteLine("Results");
                    Console.WriteLine("------------\r\n");

                    if (result.EvaluationResult != null)
                    {
                        Console.WriteLine("Must Moderate: {0}", result.EvaluationResult.MustModerate);
                        Console.WriteLine("Moderated Labels\r\n-----------------\r\n");
                        
                        result.EvaluationResult.ModeratedLabels.ForEach(label =>
                        {
                            Console.WriteLine("-> {0}:{1}:{2}", label.Type, label.Name, label.Confidence);
                        });
                    }
                    else
                    {
                        Console.WriteLine("No evalution result object found.");
                    }
                }
                else
                {
                    Console.WriteLine("Evaluation unsuccessful.");
                    Console.WriteLine($"Reason: {result.Message}");
                    Console.WriteLine("Exception:", result.Exception != null ? result.Exception.Message : string.Empty);
                }
            }
        }
    }
}
