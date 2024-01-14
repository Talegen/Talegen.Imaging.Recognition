namespace Talegen.Imaging.Moderation
{
    /// <summary>
    /// This class defines a moderation threshold configuration used for determining if an image should be moderated.
    /// </summary>
    public class ImageModerationThreshold
    {
        /// <summary>
        /// Gets the type of moderation to detect a range of confidence.
        /// </summary>
        public ModerationLabelTypes Type { get; set; } = ModerationLabelTypes.None;

        /// <summary>
        /// Gets or sets a threshold rabge for a needs moderation result.
        /// </summary>
        public float MinimumConfidenceThreshold { get; set; } = 0.5F;
    }
}
