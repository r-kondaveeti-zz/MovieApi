using System;
using System.Collections.Generic;
using Transmission.API.RPC;
using Transmission.API.RPC.Entity;

namespace MD.Backend.Transmission.ILogic
{
    public interface ITorrentLogic
    {
        //Add Torrent (and start downloading)
        NewTorrentInfo AddTorrent(string url);

        //Remove Torrent (user may delete the one which doesn't respond)
        (bool, string) StopAndRemoveTorrent(Guid torrentId, int movieId);

        //Start Torrent
        void StartTorrent(object[] ids);

        //Stop Torrent
        (bool, string) StopTorrent(Guid torrentId, int movieId);

        //Torrent Status
        int? TorrentStatus(int[] ids);

        //Download Speed (for the torrents that have torrent status -- downloading)
        (int? rateDownload, int? eta, double? percentDone, int? status) TorrentStats(int[] ids);

        //Gets all the torrents from the db
        IList<Db.Torrent> GetTorrents();

    }
}
