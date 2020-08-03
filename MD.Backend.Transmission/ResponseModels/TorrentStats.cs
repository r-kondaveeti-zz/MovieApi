using System;
using Transmission.API.RPC.Entity;

namespace MD.Backend.Transmission.ResponseModels
{
    public class TorrentStats
    {
        public string Name { get; set; }

        public int ETA { get; set; }

        public int RateDownload  { get; set; }

        public double PercentageDone { get; set; }

        public int Status { get; set; }
        
        public string Directory { get; set; }

        public int Id { get; set; }
    }
}
