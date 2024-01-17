namespace Talegen.Imaging.Moderation.Aws
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using Amazon.Rekognition;
    using Amazon.Rekognition.Model;
    using Talegen.Common.Core.Extensions;
    using Talegen.Imaging.Moderation.Extensions;

    /// <summary>
    /// This class implements an image moderation service using the AWS Rekognition moderation service
    /// </summary>
    public class AwsImageModerationService : IImageModerationService
    {
        /// <summary>
        /// Contains an instance of the image moderation settings.
        /// </summary>
        private readonly AwsImageModerationSettings settings;

        /// <summary>
        /// Initializes a new instance of the <see cref="AwsImageModerationService"/> class.
        /// </summary>
        /// <param name="settings">Contains the image moderation settings.</param>
        public AwsImageModerationService(AwsImageModerationSettings settings)
        {
            this.settings = settings;
        }

        /// <summary>
        /// This method is used to evalute an image using defined service settings.
        /// </summary>
        /// <returns>Returns a new <see cref="ImageModerationResult"/> with findings.</returns>
        public async Task<ImageModerationResult> EvaluateAsync()
        {
            return await EvaluateBucketImageAsync(this.settings.EvaluateFileName, this.settings.EvaluateBucketName);
        }

        /// <summary>
        /// This method is used to evalute the image contents passed in byte form.
        /// </summary>
        /// <param name="imageContents">Contains the bytes to evaluate.</param>
        /// <returns>Returns a new <see cref="ImageModerationResult"/> with findings.</returns>
        public async Task<ImageModerationResult> EvaluateAsync(byte[] imageContents)
        {
            using var stream = new System.IO.MemoryStream(imageContents);
            var evaluationResult = await EvaluateAsync(stream);
            return evaluationResult;
        }

        /// <summary>
        /// This method is used to evalute the image contents passed in byte form.
        /// </summary>
        /// <param name="imageContents">Contains the bytes to evaluate.</param>
        /// <returns>Returns a new <see cref="ImageModerationResult"/> with findings.</returns>
        public async Task<ImageModerationResult> EvaluateAsync(MemoryStream memoryStream)
        {
            var detectModerationLabelsRequest = new DetectModerationLabelsRequest
            {
                Image = new Image()
                {
                    Bytes = memoryStream
                },

                // set the minimum confidence to the minimum threshold setting.
                MinConfidence = this.settings.Thresholds.Select(t => t.MinimumConfidenceThreshold).Min()
            };
            var evaluationResult = await InternalEvaluateAsync(detectModerationLabelsRequest);
            return evaluationResult;
        }

        /// <summary>
        /// This method is used to evalute the image contents in an S3 bucket file.
        /// </summary>
        /// <param name="fileName">Contains the file name to evaluate.</param>
        /// <param name="bucketName">Contains the bucket name to find the file.</param>
        /// <returns>Returns a new <see cref="ImageModerationResult"/> with findings.</returns>
        public async Task<ImageModerationResult> EvaluateBucketImageAsync(string fileName, string bucketName)
        {
            var detectModerationLabelsRequest = new DetectModerationLabelsRequest
            {
                Image = new Image()
                {
                    S3Object = new S3Object()
                    {
                        Name = fileName,
                        Bucket = bucketName
                    }
                },

                // set the minimum confidence to the minimum threshold setting.
                MinConfidence = this.settings.Thresholds.Select(t => t.MinimumConfidenceThreshold).Min()
            };
            var evaluationResult = await InternalEvaluateAsync(detectModerationLabelsRequest);

            return evaluationResult;
        }

        /// <summary>
        /// This method is used to evaluate the results from the moderation call.
        /// </summary>
        /// <param name="detectModerationLabelsRequest">Contains the detect moderation request to make.</param>
        /// <returns>Returns an <see cref="ImageModerationResult"/> object.</returns>
        private async Task<ImageModerationResult> InternalEvaluateAsync(DetectModerationLabelsRequest detectModerationLabelsRequest)
        {
            var rekognitionClient = 
                !string.IsNullOrWhiteSpace(this.settings.Connection.AccessKey) ? 
                    new AmazonRekognitionClient(this.settings.Connection.AccessKey, 
                        this.settings.Connection.Secret, 
                        this.settings.Connection.RegionEndpoint) : 
                    new AmazonRekognitionClient();
            bool success = true;
            ImageModerationEvaluationResult? moderationEvaluationResult = null;
            Exception? exception = null;
            string? message = null;

            List<ImageModerationLabel> moderationLabels = new List<ImageModerationLabel>();

            try
            {
                var detectModerationLabelsResponse = await rekognitionClient.DetectModerationLabelsAsync(detectModerationLabelsRequest);
                var mapping = TypeExtensions.ToCharMapDictionary<ModerationLabelTypes>();

                foreach (ModerationLabel label in detectModerationLabelsResponse.ModerationLabels)
                {
                    string parentLabelName = label.ParentName;
                    string labelName = label.Name;
                    string labelTypeName = !string.IsNullOrWhiteSpace(parentLabelName) ? parentLabelName : labelName.Replace(" ", string.Empty);
                    ModerationLabelTypes labelType;

                    if (!mapping.TryGetValue(labelTypeName, out labelType))
                    {
                        labelType = labelTypeName.ToEnum<ModerationLabelTypes>(true);
                    }

                    moderationLabels.Add(new ImageModerationLabel { Name = label.Name, Type = labelType, Confidence = label.Confidence });

                    Debug.WriteLine($"Label: {label.Name}");
                    Debug.WriteLine($"Confidence: {label.Confidence}");
                    Debug.WriteLine($"Parent: {label.ParentName}");
                }

                // next evaluate results
                moderationEvaluationResult = moderationLabels.Evaluate(this.settings);
            }
            catch (Exception ex)
            {
                success = false;
                message = ex.Message;
                exception = ex;
                Debug.WriteLine(ex.Message);
            }

            return new ImageModerationResult(success, moderationEvaluationResult, message, exception);
        }
    }
}
