namespace Talegen.Imaging.Moderation.Aws
{
    using System.Runtime.Serialization;
    using System.Xml.Serialization;
    using Amazon;
    using Newtonsoft.Json;

    /// <summary>
    /// This class contains AWS moderation connection settings.
    /// </summary>
    public class AwsImageModerationConnectionSettings
    {
        /// <summary>
        /// Contains the default region system name.
        /// </summary>
        public const string DefaultRegion = "us-east-1";

        /// <summary>
        /// Gets or sets the region system name to use service.
        /// </summary>
        public string Region { get; set; } = DefaultRegion;

        /// <summary>
        /// Gets or sets the access key
        /// </summary>
        public string AccessKey { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the access secret.
        /// </summary>
        public string Secret { get; set; } = string.Empty;

        /// <summary>
        /// Gets the region endpoint based on the region system name specified.
        /// </summary>
        /// <remarks>Defaults to "us-east-1" if no region was specified or is null.</remarks>
        [IgnoreDataMember]
        [XmlIgnore]
        [JsonIgnore]
        public RegionEndpoint RegionEndpoint => RegionEndpoint.GetBySystemName(string.IsNullOrWhiteSpace(this.Region) ? this.Region : DefaultRegion);
    }
}
