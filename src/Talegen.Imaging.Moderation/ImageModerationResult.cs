namespace Talegen.Imaging.Moderation
{
    using System;
    using Talegen.Imaging.Moderation.Extensions;

    /// <summary>
    /// This class defines results from an image moderation call.
    /// </summary>
    public class ImageModerationResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ImageModerationResult"/> class.
        /// </summary>
        /// <param name="evaluationSuccess">Contains an evaluation success status.</param>
        /// <param name="moderationEvaluationResult">Contains the evaluation result.</param>
        /// <param name="message">Contains an optional message.</param>
        /// <param name="exception">Contains an optional exception thrown.</param>
        public ImageModerationResult(bool evaluationSuccess, ImageModerationEvaluationResult? moderationEvaluationResult, string? message = null, Exception? exception = null) 
        { 
            this.EvaluationSuccess = evaluationSuccess;
            this.EvaluationResult = moderationEvaluationResult;
            this.Message = message;
            this.Exception = exception;
        }

        /// <summary>
        /// Gets a value indiciating whether the moderation result was successful. 
        /// </summary>
        public bool EvaluationSuccess { get; private set; }

        /// <summary>
        /// Gets a message returned from the moderation call.
        /// </summary>
        public string? Message { get; private set; }

        /// <summary>
        /// Gets an exception if thrown during moderation call.
        /// </summary>
        public Exception? Exception { get; private set; } 

        /// <summary>
        /// Gets a value indicating the evaluation result.
        /// </summary>
        public ImageModerationEvaluationResult? EvaluationResult { get; private set; }
    }
}