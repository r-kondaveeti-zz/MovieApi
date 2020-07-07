using System;
using Microsoft.AspNetCore.Mvc;


namespace MD.Backend.Transmission.Controllers
{
    [ApiController]
    [Route("api/torrent/")]
    public class TorrentController: ControllerBase
    {
        private readonly ILogic.ITorrentLogic _torrentLogic;

        public TorrentController(ILogic.ITorrentLogic torrentLogic)
        {
            _torrentLogic = torrentLogic;
        }

        [HttpPut]
        public IActionResult AddTorrent([FromBody] RequestModels.AddTorrent torrent)
        {    
            var decodedUrl = System.Text.Encoding.UTF8.GetString(System.Convert.FromBase64String(torrent.TorrentUrlBase64));
            var newTorrent = _torrentLogic.AddTorrent(decodedUrl);

            if (newTorrent is null) return BadRequest();

            return Ok(new ResponseModels.OperationStatus { IsSuccessful = true, Message = "Torrent Added to Downloads"});
        }

        [HttpPost]
        public IActionResult StopTorrent([FromBody] RequestModels.StopTorrent stopTorrent)
        {
            Guid torrentId;

            if (Guid.TryParse(stopTorrent.TorrentId, out torrentId) && stopTorrent.MovieId != 0)
            {
                (bool isSuccessful, string message) = _torrentLogic.StopTorrent(torrentId, stopTorrent.MovieId);
                if (isSuccessful) { return Ok(new ResponseModels.OperationStatus { IsSuccessful = isSuccessful, Message = message }); }
                return BadRequest(new ResponseModels.OperationStatus { IsSuccessful = isSuccessful, Message = message });
            }

            return BadRequest();
        }

        [HttpGet]
        public IActionResult GetTorrents()
        {
            var torrents =  _torrentLogic.GetTorrents();
            if (torrents is null) return BadRequest();

            return Ok(torrents);
        }

        [HttpPost("stats")]
        public IActionResult GetTorrentStats([FromBody] RequestModels.GetTorrentStats torrentStats)
        {
            ResponseModels.TorrentStats response = new ResponseModels.TorrentStats();
            (response.RateDownload, response.ETA, response.PercentageDone, response.Status) = _torrentLogic.TorrentStats(new int[] { torrentStats.MovieId });

            if (response.RateDownload is null || response.Status is null) return BadRequest();

            return Ok(response);
        }

        [HttpDelete]
        public IActionResult StopAndRemoveTorrent([FromBody] RequestModels.RemoveTorrent torrent)
        {
            Guid torrentId;

            if (Guid.TryParse(torrent.TorrentId, out torrentId) && torrent.MovieId != 0)
            {
               (bool isSuccessful, string message) = _torrentLogic.StopAndRemoveTorrent(torrentId, torrent.MovieId);
                if(isSuccessful) { return Ok(new ResponseModels.OperationStatus { IsSuccessful = isSuccessful, Message = message }); }
                return BadRequest(new ResponseModels.OperationStatus { IsSuccessful = isSuccessful, Message = message });
            }

            return BadRequest();
        }
    }
}
