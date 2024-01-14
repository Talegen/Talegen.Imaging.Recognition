namespace Talegen.Imaging.Moderation
{
    using System.Threading.Tasks;

    /// <summary>
    /// This interface definies the minimum contract for implementing an image moderation service.
    /// </summary>
    public interface IImageModerationService
    {
        /// <summary>
        /// This method is used to evalute an image using defined service settings.
        /// </summary>
        /// <returns>Returns a new <see cref="ImageModerationResult"/> with findings.</returns>
        Task<ImageModerationResult> EvaluateAsync();

        /// <summary>
        /// This method is used to evalute the image contents passed in byte form.
        /// </summary>
        /// <param name="imageContents">Contains the bytes to evaluate.</param>
        /// <returns>Returns a new <see cref="ImageModerationResult"/> with findings.</returns>
        Task<ImageModerationResult> EvaluateAsync(byte[] imageContents);
    }
}
