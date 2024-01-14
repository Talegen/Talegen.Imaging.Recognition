namespace Talegen.Imaging.Moderation
{
    using System.Collections.Generic;

    /// <summary>
    /// This class defines a set 
    /// </summary>
    public class ImageModerationSettings
    {
        public List<ImageModerationThreshold> Thresholds { get; set; } = new List<ImageModerationThreshold>();
    }
}
