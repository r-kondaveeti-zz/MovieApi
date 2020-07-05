using System;
using System.Collections.Generic;
using System.Linq;

namespace MD.Backend.Transmission.Engine
{
    public class TorrentEngine : IEngine.ITorrentEngine
    {
        private Db.TorrentDbContext _dbContext;

        public TorrentEngine(Db.TorrentDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddTorrent(Db.Torrent torrent)
        {
            try
            {
                _dbContext.Torrents.Add(torrent);
                _dbContext.SaveChanges();
            } catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public IList<Db.Torrent> GetTorrents()
        {
            return _dbContext.Torrents.ToList();
        }

        public void StopAndRemoveTorrent(Db.Torrent torrent)
        {
            try
            {
                _dbContext.Torrents.Remove(torrent);
                _dbContext.SaveChanges();
            } catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
