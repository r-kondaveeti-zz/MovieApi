using System;
namespace MD.Backend.Transmission.Db
{
    public class Torrent
    {
        public Guid Id { get; set; }

        public string MovieName { get; set; }

        public int Status { get; set; }

        public DateTime AddedOn { get; set; }

        public int MovieId { get; set; }
    }
}
