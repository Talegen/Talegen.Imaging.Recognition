namespace Talegen.Imaging.Moderation.Aws
{
    /// <summary>
    /// This class defines the settings for the AWS image moderation service.
    /// </summary>
    public class AwsImageModerationSettings : ImageModerationSettings
    {
        /// <summary>
        /// Gets or sets AWS moderation connection settings.
        /// </summary>
        public AwsImageModerationConnectionSettings Connection { get; set; } = new AwsImageModerationConnectionSettings();

        /// <summary>
        /// Gets an optional evaluation file name if using S3 object to evaluate.
        /// </summary>
        public string EvaluateFileName { get; set; } = string.Empty;

        /// <summary>
        /// Gets an optional evaluation bucket name if using S3 object to evaluate.
        /// </summary>
        public string EvaluateBucketName { get; set; } = string.Empty;
    }
}
