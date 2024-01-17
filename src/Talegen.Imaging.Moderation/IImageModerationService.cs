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
    using System.IO;
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

        /// <summary>
        /// This method is used to evalute the image contents passed in memory stream.
        /// </summary>
        /// <param name="memoryStream">Contains a memory stream of bytes to evaluate.</param>
        /// <returns>Returns a new <see cref="ImageModerationResult"/> with findings.</returns>
        Task<ImageModerationResult> EvaluateAsync(MemoryStream memoryStream);
    }
}
