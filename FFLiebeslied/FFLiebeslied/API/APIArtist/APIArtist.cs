using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FFLiebeslied.API
{
    public class Header
    {
        public int status_code { get; set; }
        public double execute_time { get; set; }
    }

    public class ArtistNameTranslation
    {
        public string language { get; set; }
        public string translation { get; set; }
    }

    public class ArtistNameTranslationList
    {
        public ArtistNameTranslation artist_name_translation { get; set; }
    }

    public class ArtistAliasList
    {
        public string artist_alias { get; set; }
    }

    public class ArtistCredits
    {
        public List<object> artist_list { get; set; }
    }

    public class Artist
    {
        public int artist_id { get; set; }
        public string artist_name { get; set; }
        public List<ArtistNameTranslationList> artist_name_translation_list { get; set; }
        public string artist_comment { get; set; }
        public string artist_country { get; set; }
        public List<ArtistAliasList> artist_alias_list { get; set; }
        public int artist_rating { get; set; }
        public string artist_twitter_url { get; set; }
        public ArtistCredits artist_credits { get; set; }
        public int restricted { get; set; }
        public DateTime updated_time { get; set; }
    }

    public class Body
    {
        public Artist artist { get; set; }
    }

    public class Message
    {
        public Header header { get; set; }
        public Body body { get; set; }
    }

    public class RootObject
    {
        public Message message { get; set; }
    }
}