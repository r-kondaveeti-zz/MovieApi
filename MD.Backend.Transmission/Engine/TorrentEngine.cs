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

        public (bool, string) ModifyStatus(Guid id)
        {
            try
            {
                Db.Torrent torrent = _dbContext.Torrents.Find(id);
                if (torrent is null) return (false, "Torrent Not Found");
                torrent.Status = 6;

                _dbContext.SaveChanges();

                return (true, "Torrent Updated");
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return (false, ex.Message);
            }
        }

        public (bool, string) StopAndRemoveTorrent(Guid id)
        {
            try
            {
                Db.Torrent torrent = _dbContext.Torrents.Find(id);
                if (torrent is null) return (false, "Torrent Not Found");
                _dbContext.Torrents.Remove(torrent);

                _dbContext.SaveChanges();

                return (true, "Torrent Deleted");

            } catch(Exception ex)
            {
                Console.WriteLine(ex.Message);

                return (false, ex.Message);
            }

        }
    }
}
