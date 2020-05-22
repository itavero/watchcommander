using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace WatchCommander.ApiClient.Models.Radarr
{
    public class Movie
    {
        [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get; set; }

        [JsonProperty("alternativeTitles", NullValueHandling = NullValueHandling.Ignore)]
        public List<AlternativeTitle> AlternativeTitles { get; set; }

        [JsonProperty("secondaryYearSourceId", NullValueHandling = NullValueHandling.Ignore)]
        public long? SecondaryYearSourceId { get; set; }

        [JsonProperty("sortTitle", NullValueHandling = NullValueHandling.Ignore)]
        public string SortTitle { get; set; }

        [JsonProperty("sizeOnDisk", NullValueHandling = NullValueHandling.Ignore)]
        public long? SizeOnDisk { get; set; }

        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get; set; }

        [JsonProperty("overview", NullValueHandling = NullValueHandling.Ignore)]
        public string Overview { get; set; }

        [JsonProperty("inCinemas", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? InCinemas { get; set; }

        [JsonProperty("physicalRelease", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? PhysicalRelease { get; set; }

        [JsonProperty("physicalReleaseNote", NullValueHandling = NullValueHandling.Ignore)]
        public string PhysicalReleaseNote { get; set; }

        [JsonProperty("images", NullValueHandling = NullValueHandling.Ignore)]
        public List<Image> Images { get; set; }

        [JsonProperty("website", NullValueHandling = NullValueHandling.Ignore)]
        public string Website { get; set; }

        [JsonProperty("downloaded", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Downloaded { get; set; }

        [JsonProperty("year", NullValueHandling = NullValueHandling.Ignore)]
        public int? Year { get; set; }

        [JsonProperty("hasFile", NullValueHandling = NullValueHandling.Ignore)]
        public bool? HasFile { get; set; }

        [JsonProperty("youTubeTrailerId", NullValueHandling = NullValueHandling.Ignore)]
        public string YouTubeTrailerId { get; set; }

        [JsonProperty("studio", NullValueHandling = NullValueHandling.Ignore)]
        public string Studio { get; set; }

        [JsonProperty("path", NullValueHandling = NullValueHandling.Ignore)]
        public string Path { get; set; }

        [JsonProperty("profileId", NullValueHandling = NullValueHandling.Ignore)]
        public long? ProfileId { get; set; }

        [JsonProperty("pathState", NullValueHandling = NullValueHandling.Ignore)]
        public string PathState { get; set; }

        [JsonProperty("monitored", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Monitored { get; set; }

        [JsonProperty("minimumAvailability", NullValueHandling = NullValueHandling.Ignore)]
        public string MinimumAvailability { get; set; }

        [JsonProperty("isAvailable", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsAvailable { get; set; }

        [JsonProperty("folderName", NullValueHandling = NullValueHandling.Ignore)]
        public string FolderName { get; set; }

        [JsonProperty("runtime", NullValueHandling = NullValueHandling.Ignore)]
        public long? Runtime { get; set; }

        [JsonProperty("lastInfoSync", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? LastInfoSync { get; set; }

        [JsonProperty("cleanTitle", NullValueHandling = NullValueHandling.Ignore)]
        public string CleanTitle { get; set; }

        [JsonProperty("imdbId", NullValueHandling = NullValueHandling.Ignore)]
        public string ImdbId { get; set; }

        [JsonProperty("tmdbId", NullValueHandling = NullValueHandling.Ignore)]
        public long? TmdbId { get; set; }

        [JsonProperty("titleSlug", NullValueHandling = NullValueHandling.Ignore)]
        public string TitleSlug { get; set; }

        [JsonProperty("genres", NullValueHandling = NullValueHandling.Ignore)]
        public List<object> Genres { get; set; }

        [JsonProperty("tags", NullValueHandling = NullValueHandling.Ignore)]
        public List<object> Tags { get; set; }

        [JsonProperty("added", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? Added { get; set; }

        [JsonProperty("ratings", NullValueHandling = NullValueHandling.Ignore)]
        public Ratings Ratings { get; set; }

        [JsonProperty("movieFile", NullValueHandling = NullValueHandling.Ignore)]
        public MovieFile MovieFile { get; set; }

        [JsonProperty("qualityProfileId", NullValueHandling = NullValueHandling.Ignore)]
        public int? QualityProfileId { get; set; }

        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public int Id { get; set; }

        [JsonProperty("secondaryYear", NullValueHandling = NullValueHandling.Ignore)]
        public int? SecondaryYear { get; set; }
    }

    public class AlternativeTitle
    {
        [JsonProperty("sourceType", NullValueHandling = NullValueHandling.Ignore)]
        public string SourceType { get; set; }

        [JsonProperty("movieId", NullValueHandling = NullValueHandling.Ignore)]
        public long? MovieId { get; set; }

        [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get; set; }

        [JsonProperty("sourceId", NullValueHandling = NullValueHandling.Ignore)]
        public long? SourceId { get; set; }

        [JsonProperty("votes", NullValueHandling = NullValueHandling.Ignore)]
        public long? Votes { get; set; }

        [JsonProperty("voteCount", NullValueHandling = NullValueHandling.Ignore)]
        public long? VoteCount { get; set; }

        [JsonProperty("language", NullValueHandling = NullValueHandling.Ignore)]
        public string Language { get; set; }

        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public long? Id { get; set; }
    }

    public class Image
    {
        [JsonProperty("coverType", NullValueHandling = NullValueHandling.Ignore)]
        public string CoverType { get; set; }

        [JsonProperty("url", NullValueHandling = NullValueHandling.Ignore)]
        public string Url { get; set; }
    }

    public class MovieFile
    {
        [JsonProperty("movieId", NullValueHandling = NullValueHandling.Ignore)]
        public long? MovieId { get; set; }

        [JsonProperty("relativePath", NullValueHandling = NullValueHandling.Ignore)]
        public string RelativePath { get; set; }

        [JsonProperty("size", NullValueHandling = NullValueHandling.Ignore)]
        public long? Size { get; set; }

        [JsonProperty("dateAdded", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? DateAdded { get; set; }

        [JsonProperty("sceneName", NullValueHandling = NullValueHandling.Ignore)]
        public string SceneName { get; set; }

        [JsonProperty("releaseGroup", NullValueHandling = NullValueHandling.Ignore)]
        public string ReleaseGroup { get; set; }

        [JsonProperty("quality", NullValueHandling = NullValueHandling.Ignore)]
        public MovieFileQuality Quality { get; set; }

        [JsonProperty("edition", NullValueHandling = NullValueHandling.Ignore)]
        public string Edition { get; set; }

        [JsonProperty("mediaInfo", NullValueHandling = NullValueHandling.Ignore)]
        public MediaInfo MediaInfo { get; set; }

        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public long? Id { get; set; }
    }

    public class MediaInfo
    {
        [JsonProperty("containerFormat", NullValueHandling = NullValueHandling.Ignore)]
        public string ContainerFormat { get; set; }

        [JsonProperty("videoFormat", NullValueHandling = NullValueHandling.Ignore)]
        public string VideoFormat { get; set; }

        [JsonProperty("videoCodecID", NullValueHandling = NullValueHandling.Ignore)]
        public string VideoCodecId { get; set; }

        [JsonProperty("videoProfile", NullValueHandling = NullValueHandling.Ignore)]
        public string VideoProfile { get; set; }

        [JsonProperty("videoCodecLibrary", NullValueHandling = NullValueHandling.Ignore)]
        public string VideoCodecLibrary { get; set; }

        [JsonProperty("videoBitrate", NullValueHandling = NullValueHandling.Ignore)]
        public long? VideoBitrate { get; set; }

        [JsonProperty("videoBitDepth", NullValueHandling = NullValueHandling.Ignore)]
        public long? VideoBitDepth { get; set; }

        [JsonProperty("videoMultiViewCount", NullValueHandling = NullValueHandling.Ignore)]
        public long? VideoMultiViewCount { get; set; }

        [JsonProperty("videoColourPrimaries", NullValueHandling = NullValueHandling.Ignore)]
        public string VideoColourPrimaries { get; set; }

        [JsonProperty("videoTransferCharacteristics", NullValueHandling = NullValueHandling.Ignore)]
        public string VideoTransferCharacteristics { get; set; }

        [JsonProperty("width", NullValueHandling = NullValueHandling.Ignore)]
        public long? Width { get; set; }

        [JsonProperty("height", NullValueHandling = NullValueHandling.Ignore)]
        public long? Height { get; set; }

        [JsonProperty("audioFormat", NullValueHandling = NullValueHandling.Ignore)]
        public string AudioFormat { get; set; }

        [JsonProperty("audioCodecID", NullValueHandling = NullValueHandling.Ignore)]
        public string AudioCodecId { get; set; }

        [JsonProperty("audioCodecLibrary", NullValueHandling = NullValueHandling.Ignore)]
        public string AudioCodecLibrary { get; set; }

        [JsonProperty("audioAdditionalFeatures", NullValueHandling = NullValueHandling.Ignore)]
        public string AudioAdditionalFeatures { get; set; }

        [JsonProperty("audioBitrate", NullValueHandling = NullValueHandling.Ignore)]
        public long? AudioBitrate { get; set; }

        [JsonProperty("runTime", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? RunTime { get; set; }

        [JsonProperty("audioStreamCount", NullValueHandling = NullValueHandling.Ignore)]
        public long? AudioStreamCount { get; set; }

        [JsonProperty("audioChannels", NullValueHandling = NullValueHandling.Ignore)]
        public long? AudioChannels { get; set; }

        [JsonProperty("audioChannelPositions", NullValueHandling = NullValueHandling.Ignore)]
        public string AudioChannelPositions { get; set; }

        [JsonProperty("audioChannelPositionsText", NullValueHandling = NullValueHandling.Ignore)]
        public string AudioChannelPositionsText { get; set; }

        [JsonProperty("audioProfile", NullValueHandling = NullValueHandling.Ignore)]
        public string AudioProfile { get; set; }

        [JsonProperty("videoFps", NullValueHandling = NullValueHandling.Ignore)]
        public double? VideoFps { get; set; }

        [JsonProperty("audioLanguages", NullValueHandling = NullValueHandling.Ignore)]
        public string AudioLanguages { get; set; }

        [JsonProperty("subtitles", NullValueHandling = NullValueHandling.Ignore)]
        public string Subtitles { get; set; }

        [JsonProperty("scanType", NullValueHandling = NullValueHandling.Ignore)]
        public string ScanType { get; set; }

        [JsonProperty("schemaRevision", NullValueHandling = NullValueHandling.Ignore)]
        public long? SchemaRevision { get; set; }
    }

    public class MovieFileQuality
    {
        [JsonProperty("quality", NullValueHandling = NullValueHandling.Ignore)]
        public QualityQuality Quality { get; set; }

        [JsonProperty("customFormats", NullValueHandling = NullValueHandling.Ignore)]
        public List<object> CustomFormats { get; set; }

        [JsonProperty("revision", NullValueHandling = NullValueHandling.Ignore)]
        public Revision Revision { get; set; }

        [JsonProperty("hardcodedSubs", NullValueHandling = NullValueHandling.Ignore)]
        public string HardcodedSubs { get; set; }
    }

    public class QualityQuality
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public long? Id { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("source", NullValueHandling = NullValueHandling.Ignore)]
        public string Source { get; set; }

        [JsonProperty("resolution", NullValueHandling = NullValueHandling.Ignore)]
        public string Resolution { get; set; }

        [JsonProperty("modifier", NullValueHandling = NullValueHandling.Ignore)]
        public string Modifier { get; set; }
    }

    public class Revision
    {
        [JsonProperty("version", NullValueHandling = NullValueHandling.Ignore)]
        public long? Version { get; set; }

        [JsonProperty("real", NullValueHandling = NullValueHandling.Ignore)]
        public long? Real { get; set; }
    }

    public class Ratings
    {
        [JsonProperty("votes", NullValueHandling = NullValueHandling.Ignore)]
        public long? Votes { get; set; }

        [JsonProperty("value", NullValueHandling = NullValueHandling.Ignore)]
        public double? Value { get; set; }
    }
}