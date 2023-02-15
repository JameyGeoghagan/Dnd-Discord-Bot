using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDDiscordBot
{
    public class DNDMEME
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        public class FixedWidthStill
        {
            public string height { get; set; }
            public string size { get; set; }
            public string url { get; set; }
            public string width { get; set; }
        }

        public class PreviewGif
        {
            public string height { get; set; }
            public string size { get; set; }
            public string url { get; set; }
            public string width { get; set; }
        }

        public class FixedHeightDownsampled
        {
            public string height { get; set; }
            public string size { get; set; }
            public string url { get; set; }
            public string webp { get; set; }
            public string webp_size { get; set; }
            public string width { get; set; }
        }

        public class Preview
        {
            public string height { get; set; }
            public string mp4 { get; set; }
            public string mp4_size { get; set; }
            public string width { get; set; }
        }

        public class FixedHeightSmall
        {
            public string height { get; set; }
            public string mp4 { get; set; }
            public string mp4_size { get; set; }
            public string size { get; set; }
            public string url { get; set; }
            public string webp { get; set; }
            public string webp_size { get; set; }
            public string width { get; set; }
        }

        public class Downsized
        {
            public string height { get; set; }
            public string size { get; set; }
            public string url { get; set; }
            public string width { get; set; }
        }

        public class FixedWidthDownsampled
        {
            public string height { get; set; }
            public string size { get; set; }
            public string url { get; set; }
            public string webp { get; set; }
            public string webp_size { get; set; }
            public string width { get; set; }
        }

        public class FixedWidth
        {
            public string height { get; set; }
            public string mp4 { get; set; }
            public string mp4_size { get; set; }
            public string size { get; set; }
            public string url { get; set; }
            public string webp { get; set; }
            public string webp_size { get; set; }
            public string width { get; set; }
        }

        public class DownsizedStill
        {
            public string height { get; set; }
            public string size { get; set; }
            public string url { get; set; }
            public string width { get; set; }
        }

        public class DownsizedMedium
        {
            public string height { get; set; }
            public string size { get; set; }
            public string url { get; set; }
            public string width { get; set; }
        }

        public class OriginalMp4
        {
            public string height { get; set; }
            public string mp4 { get; set; }
            public string mp4_size { get; set; }
            public string width { get; set; }
        }

        public class DownsizedLarge
        {
            public string height { get; set; }
            public string size { get; set; }
            public string url { get; set; }
            public string width { get; set; }
        }

        public class PreviewWebp
        {
            public string height { get; set; }
            public string size { get; set; }
            public string url { get; set; }
            public string width { get; set; }
        }

        public class Original
        {
            public string frames { get; set; }
            public string hash { get; set; }
            public string height { get; set; }
            public string mp4 { get; set; }
            public string mp4_size { get; set; }
            public string size { get; set; }
            public string url { get; set; }
            public string webp { get; set; }
            public string webp_size { get; set; }
            public string width { get; set; }
        }

        public class OriginalStill
        {
            public string height { get; set; }
            public string size { get; set; }
            public string url { get; set; }
            public string width { get; set; }
        }

        public class FixedHeightSmallStill
        {
            public string height { get; set; }
            public string size { get; set; }
            public string url { get; set; }
            public string width { get; set; }
        }

        public class FixedWidthSmall
        {
            public string height { get; set; }
            public string mp4 { get; set; }
            public string mp4_size { get; set; }
            public string size { get; set; }
            public string url { get; set; }
            public string webp { get; set; }
            public string webp_size { get; set; }
            public string width { get; set; }
        }

        public class Looping
        {
            public string mp4 { get; set; }
            public string mp4_size { get; set; }
        }

        public class DownsizedSmall
        {
            public string height { get; set; }
            public string mp4 { get; set; }
            public string mp4_size { get; set; }
            public string width { get; set; }
        }

        public class FixedWidthSmallStill
        {
            public string height { get; set; }
            public string size { get; set; }
            public string url { get; set; }
            public string width { get; set; }
        }

        public class FixedHeightStill
        {
            public string height { get; set; }
            public string size { get; set; }
            public string url { get; set; }
            public string width { get; set; }
        }

        public class FixedHeight
        {
            public string height { get; set; }
            public string mp4 { get; set; }
            public string mp4_size { get; set; }
            public string size { get; set; }
            public string url { get; set; }
            public string webp { get; set; }
            public string webp_size { get; set; }
            public string width { get; set; }
        }

        public class _480wStill
        {
            public string url { get; set; }
            public string width { get; set; }
            public string height { get; set; }
        }

        public class Images
        {
            public FixedWidthStill fixed_width_still { get; set; }
            public PreviewGif preview_gif { get; set; }
            public FixedHeightDownsampled fixed_height_downsampled { get; set; }
            public Preview preview { get; set; }
            public FixedHeightSmall fixed_height_small { get; set; }
            public Downsized downsized { get; set; }
            public FixedWidthDownsampled fixed_width_downsampled { get; set; }
            public FixedWidth fixed_width { get; set; }
            public DownsizedStill downsized_still { get; set; }
            public DownsizedMedium downsized_medium { get; set; }
            public OriginalMp4 original_mp4 { get; set; }
            public DownsizedLarge downsized_large { get; set; }
            public PreviewWebp preview_webp { get; set; }
            public Original original { get; set; }
            public OriginalStill original_still { get; set; }
            public FixedHeightSmallStill fixed_height_small_still { get; set; }
            public FixedWidthSmall fixed_width_small { get; set; }
            public Looping looping { get; set; }
            public DownsizedSmall downsized_small { get; set; }
            public FixedWidthSmallStill fixed_width_small_still { get; set; }
            public FixedHeightStill fixed_height_still { get; set; }
            public FixedHeight fixed_height { get; set; }
            public _480wStill _480w_still { get; set; }
        }

        public class User
        {
            public string avatar_url { get; set; }
            public string banner_image { get; set; }
            public string banner_url { get; set; }
            public string profile_url { get; set; }
            public string username { get; set; }
            public string display_name { get; set; }
            public string description { get; set; }
            public bool is_verified { get; set; }
            public string website_url { get; set; }
            public string instagram_url { get; set; }
        }

        public class Data
        {
            public string type { get; set; }
            public string id { get; set; }
            public string url { get; set; }
            public string slug { get; set; }
            public string bitly_gif_url { get; set; }
            public string bitly_url { get; set; }
            public string embed_url { get; set; }
            public string username { get; set; }
            public string source { get; set; }
            public string title { get; set; }
            public string rating { get; set; }
            public string content_url { get; set; }
            public string source_tld { get; set; }
            public string source_post_url { get; set; }
            public int is_sticker { get; set; }
            public string import_datetime { get; set; }
            public string trending_datetime { get; set; }
            public Images images { get; set; }
            public User user { get; set; }
        }

        public class Meta
        {
            public string msg { get; set; }
            public int status { get; set; }
            public string response_id { get; set; }
        }

        public class Root
        {
            public Data data { get; set; }
            public Meta meta { get; set; }
        }

    }
}
