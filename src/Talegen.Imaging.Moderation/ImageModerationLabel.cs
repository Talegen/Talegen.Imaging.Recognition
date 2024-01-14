namespace Talegen.Imaging.Moderation
{
    using System.ComponentModel;

    /// <summary>
    /// Contains an enumerated list of moderation label types.
    /// </summary>
    public enum ModerationLabelTypes
    {
        /// <summary>
        /// Nothing found.
        /// </summary>
        None = 0,

        /// <summary>
        /// Explicit nudity found.
        /// </summary>
        [Description("Explicit Nudity")]
        ExplicitNudity = 1,

        /// <summary>
        /// Suggestive content found.
        /// </summary>
        Suggestive = 2,

        /// <summary>
        /// Violence found.
        /// </summary>
        Violence = 4,

        /// <summary>
        /// Visually disturbing content found.
        /// </summary>
        [Description("Visually Disturbing")]
        VisuallyDisturbing = 8,

        /// <summary>
        /// Rude gestures found.
        /// </summary>
        [Description("Rude Gestures")]
        RudeGestures = 16,

        /// <summary>
        /// Drugs and related found.
        /// </summary>
        Drugs = 32,

        /// <summary>
        /// Tobacco and related found.
        /// </summary>
        Tobacco = 64,

        /// <summary>
        /// Alcohol and related found.
        /// </summary>
        Alcohol = 128,

        /// <summary>
        /// Gambling and related found.
        /// </summary>
        Gambling = 256,

        /// <summary>
        /// Hate symbols and related found.
        /// </summary>
        [Description("Hate Symbols")]
        HateSymbols = 512
    }

    /// <summary>
    /// This class defines an image moderation label result.
    /// </summary>
    public class ImageModerationLabel
    {
        /// <summary>
        /// Gets or sets the moderation label type.
        /// </summary>
        public ModerationLabelTypes Type = ModerationLabelTypes.None;

        /// <summary>
        /// Gets or sets the moderation label name.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the confidence of the label found.
        /// </summary>
        public float Confidence { get; set; }
    }
}
