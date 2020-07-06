using System;
using System.Collections.Generic;

namespace MD.Backend.Transmission.IEngine
{
    public interface ITorrentEngine
    {
        IList<Db.Torrent> GetTorrents();

        //Add Torrent
        void AddTorrent(Db.Torrent torrent);

        //Remove Torrent
        (bool, string) StopAndRemoveTorrent(Guid id);

        (bool, string) ModifyStatus(Guid id);

    }
}
