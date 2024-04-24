using ASPTrackTracker.ScoreHelpers;
using DataLibrary.Data;
using DataLibrary.Models;

namespace ASPTrackTracker.Comparers
{
    public class ComparableTrackCreator
    {
        private readonly TrackScoresGetter tracksScoresGetter;
        private readonly IUserData userData;
        private readonly IArtistData artistData;
        private readonly IGenreData genreData;
        private readonly IStyleData styleData;

        public ComparableTrackCreator(TrackScoresGetter trackScoresGetter, IUserData userData, IArtistData artistData, IGenreData genreData, IStyleData styleData)
        {
            this.tracksScoresGetter = trackScoresGetter;
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
                var trackScores = await tracksScoresGetter.GetTrackScores(track);

                string name = track.Name;
                string link = track.Link;
                string userName = user.Name;
                string artistName = artist.Name;
                string genreName = genre.Name;
                string styleName = style.Name;

                ComparableTrack comparableTrack = new ComparableTrack(name, link, userName, artistName, genreName, styleName);

                comparableTrack.GetComparableTrackScores(trackScores);

                comparableTracks.Add(comparableTrack);

            }
            //OrderTracks(SelectedStat);
            return comparableTracks;
        }

    }
}
