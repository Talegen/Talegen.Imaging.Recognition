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
