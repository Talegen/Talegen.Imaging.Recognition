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
        public float MinimumConfidenceThreshold { get; set; } = 50F;
    }
}
