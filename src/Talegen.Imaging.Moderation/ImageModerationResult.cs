/*
 * Talegen ASP.net Image Recognition Library
 * (c) Copyright Talegen, LLC.
 * 
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 * http://www.apache.org/licenses/LICENSE-2.0
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
*/
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