namespace Talegen.Imaging.Moderation.Extensions
{
    using System.Collections.Generic;

    /// <summary>
    /// This class represents the results of evaluating the moderation results.
    /// </summary>
    public class ImageModerationEvaluationResult
    {
        /// <summary>
        /// Initializes a new empty instance of the <see cref="ImageModerationEvaluationResult"/> class.
        /// </summary>
        public ImageModerationEvaluationResult() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ImageModerationEvaluationResult"/> class.
        /// </summary>
        /// <param name="thresholds">Contains the configuration thresholds.</param>
        /// <param name="labels">Contains the evaluation labels.</param>
        /// <param name="evaluationResults">Contains the evaluation results.</param>
        public ImageModerationEvaluationResult(List<ImageModerationThreshold> thresholds, List<ImageModerationLabel> labels, List<ImageModerationLabel> evaluationResults) 
        { 
            this.Thresholds = thresholds;
            this.Labels = labels;   
            this.ModeratedLabels = evaluationResults;
        }

        /// <summary>
        /// Gets a list of thresholds used in the evaluation.
        /// </summary>
        public List<ImageModerationThreshold> Thresholds { get; private set; } = new List<ImageModerationThreshold>();

        /// <summary>
        /// Gets a list of labels that were evaluated.
        /// </summary>
        public List<ImageModerationLabel> Labels { get; private set; } = new List<ImageModerationLabel>();

        /// <summary>
        /// Gets a list of labels found to have exceeded thresholds.
        /// </summary>
        public List<ImageModerationLabel> ModeratedLabels { get; private set; } = new List<ImageModerationLabel>();

        /// <summary>
        /// Gets a value indicating if the result must be moderated.
        /// </summary>
        public bool MustModerate => this.ModeratedLabels.Count > 0;
    }
}
