using ASPTrackTracker.ScoreHelpers;
using DataLibrary.BL;
using DataLibrary.Data;
using DataLibrary.Models;

namespace ASPTrackTracker.Comparers
{
    public class ComparablesCreator
    {
        private readonly ScoresManager scoresManager;
        private readonly IUserData userData;
        private readonly IArtistData artistData;
        private readonly IGenreData genreData;
        private readonly IStyleData styleData;

        public ComparablesCreator(ScoresManager scoresManager, IUserData userData, IArtistData artistData, IGenreData genreData, IStyleData styleData)
        {
            this.scoresManager = scoresManager;
            this.userData = userData;
            this.artistData = artistData;
            this.genreData = genreData;
            this.styleData = styleData;
        }

        public async Task<List<ComparableTrack>> CreateComparableTracks(List<TrackModel> filteredTracks)
        {
            List<ComparableTrack> comparableTracks = new List<ComparableTrack>();

            foreach (var track in filteredTracks)
            {

                var user = await userData.GetById<UserModel>(track.UserId);
                var artist = await artistData.GetById<ArtistModel>(track.ArtistId);
                var genre = await genreData.GetById<GenreModel>(track.GenreId);
                var style = await styleData.GetById<StyleModel>(track.StyleId);

                var trackScores = await scoresManager.GetTrackScores(track);

                string name = track.Name;
                string link = track.Link;
                string userName = user.Name;
                string artistName = artist.Name;
                string genreName = genre.Name;
                string styleName = style.Name;

                ComparableTrack comparableTrack = new ComparableTrack(name, link, userName, artistName, genreName, styleName);

                scoresManager.SetComparableTrackScores(comparableTrack, trackScores);

                comparableTracks.Add(comparableTrack);
            }
            //OrderTracks(SelectedStat);
            return comparableTracks;
        }

        public async Task<List<ComparableArtist>> CreateComparableArtists(List<ArtistModel> filteredArtists)
        {
            List<ComparableArtist> comparableArtists = new List<ComparableArtist>();

            foreach (var artist in filteredArtists)
            {
                var genre = await genreData.GetById<GenreModel>(artist.GenreId);

                string name = artist.Name;
                string genreName = genre.Name;

                var artistScores = await scoresManager.GetArtistScores(artist);


                ComparableArtist comparableArtist = new ComparableArtist(name, genreName);

                scoresManager.SetComparableArtistScores(comparableArtist, artistScores);

                comparableArtists.Add(comparableArtist);

            }
            //OrderTracks(SelectedStat);
            return comparableArtists;
        }

    }
}
