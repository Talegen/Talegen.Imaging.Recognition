namespace Talegen.Imaging.Moderation.Extensions
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// This class contains extension methods for working with image moderation results.
    /// </summary>
    public static class ImageModeratulResultExtensions
    {
        /// <summary>
        /// This extension method is used to evaluate the image moderation results against a defined set of thresholds and return a result determining if moderation has exceeded the specified minimum confidence rank thresholds.
        /// </summary>
        /// <param name="imageModerationResults">Contains the image moderation result.</param>
        /// <param name="settings">Contains the image moderation settings.</param>
        /// <returns>Returns a new <see cref="ImageModerationEvaluationResult"/> containing the evalution results.</returns>
        public static ImageModerationEvaluationResult Evaluate(this List<ImageModerationLabel> imageModerationResults, ImageModerationSettings settings) 
        {
            List<ImageModerationLabel> moderatedLabels = new List<ImageModerationLabel>();

            foreach (var label in imageModerationResults)
            {
                if (settings.Thresholds.Any(t => t.Type == label.Type && label.Confidence >= t.MinimumConfidenceThreshold))
                {
                    moderatedLabels.Add(label);
                }
            }

            return new ImageModerationEvaluationResult(settings.Thresholds, imageModerationResults, moderatedLabels);
        }
    }
}
