using System;
namespace MD.Backend.Transmission.RequestModels
{
    public class RemoveTorrent
    {
        public string TorrentId { get; set; }

        public int MovieId { get; set; }
    }
}
