using System;
using Transmission.API.RPC;
using Transmission.API.RPC.Entity;

namespace MD.Backend.Transmission.ILogic
{
    public interface ITorrentLogic
    {
        //Add Torrent (and start downloading)
        NewTorrentInfo AddTorrent(string url);

        //Remove Torrent (user may delete the one which doesn't respond)
        void RemoveTorrent(Db.Torrent torrent);

        //Start Torrent
        void StartTorrent(object[] ids);

        //Stop Torrent
        void StopTorrent(object[] ids);

        //Torrent Status
        int? TorrentStatus(int[] ids);

        //Download Speed (for the torrents that have torrent status -- downloading)
        (int? rateDownload, int? eta, double? percentDone) TorrentStats(int[] ids);

    }
}
