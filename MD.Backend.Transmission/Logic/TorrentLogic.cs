using System;
using Transmission.API.RPC;
using Transmission.API.RPC.Entity;

namespace MD.Backend.Transmission.Logic
{
    public class TorrentLogic: ILogic.ITorrentLogic
    {
        private readonly Client _client;
        private readonly IEngine.ITorrentEngine _torrentEngine;

        public TorrentLogic(IEngine.ITorrentEngine torrentEngine)
        {
            _client = new Client("http://localhost:9091/transmission/rpc", "Zt27a7zHJmfi6FNiNjM1EqQ3bAIbmcTetHuQzFjqflw6gd6J", "admin", "admin");
            _torrentEngine = torrentEngine;
        }

        public NewTorrentInfo AddTorrent(string url)
        {
            if (String.IsNullOrWhiteSpace(url)) return null;

            var newTorrent = new NewTorrent();
            newTorrent.Filename = url;
            var info = _client.TorrentAdd(newTorrent);

            //Db Code - Start
            Db.Torrent torrent = new Db.Torrent();
            torrent.Id = new Guid(); torrent.MovieId = info.ID;
            torrent.MovieName = info.Name; torrent.Status = 4;

            _torrentEngine.AddTorrent(torrent);
            //Db Code - End

            return info;
        }

        public void RemoveTorrent(Db.Torrent torrent)
        {
            _client.TorrentRemove(new int[] { torrent.MovieId }, true);

            _torrentEngine.StopAndRemoveTorrent(torrent);

        }

        public void StartTorrent(object[] ids)
        {
            _client.TorrentStartNow(ids);
        }

        public void StopTorrent(object[] ids)
        {
            _client.TorrentStop(ids);
        }

        public (int? rateDownload, int? eta, double? percentDone) TorrentStats(int[] ids)
        {
            string[] fields = { "rateDownload", "eta", "percentDone" };
            var response = _client.TorrentGet(fields, ids);
            if (response is null) return (null, null, null);

            var torrents = response.Torrents;

            if (torrents is null || torrents.Length == 0) return (null, null, null);

            return (torrents[0].RateDownload, torrents[0].ETA, torrents[0].PercentDone);
        }

        public int? TorrentStatus(int[] ids)
        {
            string[] field = { "status" };
            var response = _client.TorrentGet(field, ids);
            if (response is null) return null;

            var torrents = response.Torrents;

            if (torrents is null || torrents.Length == 0) return null;

            return torrents[0].Status;
        }
    }
}
