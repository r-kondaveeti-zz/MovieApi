using System;
using Microsoft.AspNetCore.Mvc;

namespace MD.Backend.Transmission.Controllers
{
    [ApiController]
    [Route("torrent/db")]
    public class TorrentDbController : ControllerBase
    {
        private readonly IEngine.ITorrentEngine _torrentEngine;

        public TorrentDbController(IEngine.ITorrentEngine torrentEngine)
        {
            _torrentEngine = torrentEngine;
        }

        //[HttpGet]
        //public string AddTorrent()
        //{
        //    Db.Torrent torrent = new Db.Torrent
        //    {
        //        Id = new Guid(),
        //        MovieName = "Sarigama 121",
        //        Status = 4,
        //        MovieId = 16,
        //        AddedOn = DateTime.Now
        //    };
        //    _torrentEngine.AddTorrent(torrent);

        //    return "reached end-point";
        //}

        [HttpGet]
        public IActionResult GetTorrents()
        {
            return Ok(_torrentEngine.GetTorrents());
        }

        //[HttpGet]
        //public string DeleteTorrent()
        //{
        //    Db.Torrent torrent = new Db.Torrent
        //    {
        //        Id = Guid.Parse("1816202a-089a-45c0-bd09-08d8212d86ac"),
        //        MovieName = "Sarigama 12",
        //        Status = 4,
        //        MovieId = 16,
        //        AddedOn = DateTime.Parse("2020-07-05 16:51:08.6344040")
        //    };
        //    _torrentEngine.StopAndRemoveTorrent(torrent);

        //    return "reached Delete end-point";
        //}
    }
}
