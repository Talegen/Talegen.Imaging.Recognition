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
