using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FFLiebeslied.API
{
    public class ApiSong
    {
        public class Header
        {
            public int status_code { get; set; }
            public double execute_time { get; set; }
            public int available { get; set; }
        }

        public class MusicGenre
        {
            public int music_genre_id { get; set; }
            public int music_genre_parent_id { get; set; }
            public string music_genre_name { get; set; }
            public string music_genre_name_extended { get; set; }
            public string music_genre_vanity { get; set; }
        }

        public class MusicGenreList
        {
            public MusicGenre music_genre { get; set; }
        }

        public class PrimaryGenres
        {
            public List<MusicGenreList> music_genre_list { get; set; }
        }

        public class Track
        {
            public int track_id { get; set; }
            public string track_name { get; set; }
            public List<object> track_name_translation_list { get; set; }
            public int track_rating { get; set; }
            public int commontrack_id { get; set; }
            public int instrumental { get; set; }
            public int @explicit { get; set; }
            public int has_lyrics { get; set; }
            public int has_subtitles { get; set; }
            public int has_richsync { get; set; }
            public int num_favourite { get; set; }
            public int album_id { get; set; }
            public string album_name { get; set; }
            public int artist_id { get; set; }
            public string artist_name { get; set; }
            public string track_share_url { get; set; }
            public string track_edit_url { get; set; }
            public int restricted { get; set; }
            public DateTime updated_time { get; set; }
            public PrimaryGenres primary_genres { get; set; }
        }

        public class TrackList
        {
            public Track track { get; set; }
        }

        public class Body
        {
            public List<TrackList> track_list { get; set; }
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

    public class ApiArtist
    {
        public class Header
        {
            public int status_code { get; set; }
            public double execute_time { get; set; }
            public int available { get; set; }
        }

        public class ArtistCredits
        {
            public List<object> artist_list { get; set; }
        }

        public class Artist
        {
            public int artist_id { get; set; }
            public string artist_name { get; set; }
            public List<object> artist_name_translation_list { get; set; }
            public string artist_comment { get; set; }
            public string artist_country { get; set; }
            public List<object> artist_alias_list { get; set; }
            public int artist_rating { get; set; }
            public string artist_twitter_url { get; set; }
            public ArtistCredits artist_credits { get; set; }
            public int restricted { get; set; }
            public DateTime updated_time { get; set; }
        }

        public class ArtistList
        {
            public Artist artist { get; set; }
        }

        public class Body
        {
            public List<ArtistList> artist_list { get; set; }
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

    public class ApiLyrics
    {

        public class Header
        {
            public int status_code { get; set; }
            public double execute_time { get; set; }
        }

        public class Lyrics
        {
            public int lyrics_id { get; set; }
            public int @explicit { get; set; }
            public string lyrics_body { get; set; }
            public string script_tracking_url { get; set; }
            public string pixel_tracking_url { get; set; }
            public string lyrics_copyright { get; set; }
            public DateTime updated_time { get; set; }
        }

        public class Body
        {
            public Lyrics lyrics { get; set; }
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
}