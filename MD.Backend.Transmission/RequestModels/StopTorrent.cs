using System;
namespace MD.Backend.Transmission.RequestModels
{
    public class StopTorrent
    {
        public string TorrentId { get; set; }

        public int MovieId { get; set; }
    }
}
