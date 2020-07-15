using System;
using System.Collections.Generic;
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
            _client = new Client("http://192.168.86.31:9091/transmission/rpc", "SyfjYX7Tt7n8kG1R6vZdBe7yvozTOcb1y5WvCF0sjLqoQuGs", "admin", "admin");
            _torrentEngine = torrentEngine;
        }

        public NewTorrentInfo AddTorrent(string url)
        {
            if (String.IsNullOrWhiteSpace(url)) return null;

            var newTorrent = new NewTorrent();
            newTorrent.Filename = url;
            var info = _client.TorrentAdd(newTorrent);
            
            Db.Torrent torrent = new Db.Torrent();
            torrent.Id = new Guid(); torrent.MovieId = info.ID;
            torrent.MovieName = info.Name; torrent.Status = 4;
            torrent.AddedOn = DateTime.Now;

            _torrentEngine.AddTorrent(torrent);
            
            return info;
        }

        public IList<Db.Torrent> GetTorrents()
        {
           return _torrentEngine.GetTorrents();
        }

        public (bool, string) StopAndRemoveTorrent(Guid torrentId, int movieId)
        {
            _client.TorrentRemove(new int[] { movieId }, true);

            return _torrentEngine.StopAndRemoveTorrent(torrentId);
        }

        /*
         * Not Used
         */
        public void StartTorrent(object[] ids)
        {
            _client.TorrentStartNow(ids);
        }

        public (bool, string) StopTorrent(Guid torrentId, int movieId)
        {
            _client.TorrentStop(new Object[] { movieId });

            return _torrentEngine.ModifyStatus(torrentId);
        }

        public List<ResponseModels.TorrentStats> TorrentStats(int[] ids)
        {
            List<ResponseModels.TorrentStats> list = new List<ResponseModels.TorrentStats>();
            
            string[] fields = { "name", "rateDownload", "eta", "status", "percentDone", "files" };
            var response = _client.TorrentGet(fields, ids);
            if (response is null) return null;

            var torrents = response.Torrents;

            if (torrents is null || torrents.Length == 0) return null;

            foreach(var torrent in torrents)
            {
                ResponseModels.TorrentStats torrentStats = new ResponseModels.TorrentStats
                {
                    Name = torrent.Name,
                    ETA = torrent.ETA,
                    RateDownload = torrent.RateDownload,
                    Status = torrent.Status,
                    PercentageDone = torrent.PercentDone,
                    directory = torrent.Files.Length != 0 ? torrent.Files[0]: null 
                };

                list.Add(torrentStats);
            }

            return list;
        }

        /*
         * Not Used
         */
        public int? TorrentStatus(int[] ids)
        {
            string[] field = { "status" };
            var response = _client.TorrentGet(field, ids);

            var torrents = response?.Torrents;

            if (torrents is null || torrents.Length == 0) return null;

            return torrents[0].Status;
        }
    }
}
