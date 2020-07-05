using System;
using Microsoft.AspNetCore.Mvc;
using Transmission.API.RPC;


namespace MD.Backend.Transmission.Controllers
{
    [ApiController]
    [Route("torrent/")]
    public class TorrentController: ControllerBase
    {
        //private readonly ILogic.ITorrentLogic _torrentLogic;

        //public TorrentController(ILogic.ITorrentLogic torrentLogic)
        //{
        //    _torrentLogic = torrentLogic;
        //}

        //[HttpGet("add/{torrentUrlBase64}")]
        //public IActionResult AddTorrent(string torrentUrlBase64)
        //{
        //    var decodedUrl = System.Text.Encoding.UTF8.GetString(System.Convert.FromBase64String(torrentUrlBase64));
        //    var newTorrent = _torrentLogic.AddTorrent(decodedUrl);

        //    if (newTorrent is null) return BadRequest();

        //    return Ok(newTorrent.HashString);
        //}

        //[HttpGet]
        //public void TorrentStatus()
        //{
        //    _torrentLogic.TorrentStatus(new int[] { 1 });
        //}
    }
}
