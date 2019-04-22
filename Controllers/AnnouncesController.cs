using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SeedStorm.Core.Entities;

namespace SeedStorm.Core.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/announces")]
    [ApiController]
    public class AnnouncesController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<AuthenticationController> _logger;

        public AnnouncesController(IConfiguration configuration, ILogger<AuthenticationController> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }

        /// <summary>
        /// Get the latest announcements
        /// </summary>
        [HttpGet("announcements")]
        public ActionResult<Announce[]> Announcements()
        {
            return new List<Announce>()
            {
                new Announce
                {
                    Image = "https://coinsprices.net/public/images/coins_icons/strat_.png",
                    Title = "Deploy the Stratis Full Node",
                    Description = "Docker Store and Docker Cloud are now part of Docker Hub, providing a single experience for finding, storing and sharing container images.",
                    ActionButton = "Deploy the Stratis Full Node",
                    PublishDate = DateTime.Now
                },
                new Announce
                {
                    Image = "https://steemitimages.com/DQmXEjToKV2AYR4sbfn4AfcT5YrkH9DQB26dwzPVpGqAM7E/Purple_ldsp.png",
                    Title = "See the new PIVX Masternode",
                    Description = "Docker Store and Docker Cloud are now part of Docker Hub, providing a single experience for finding, storing and sharing container images.",
                    ActionButton = "Deploy a PIVX Masternode",
                    PublishDate = DateTime.Now
                }
            }.ToArray();
        }


        /// <summary>
        /// Get the latest news
        /// </summary>
        [HttpGet("news")]
        public ActionResult<News> News()
        {
            return new News()
            {
                //Title = "Join us at DockerCon, the #1 container industry conference, in San Francisco Apr 29 – May 2.",
                Title = "SeedStorm.io | The Blockchain Hosting Platform for everybody.",
                Link = "http://perdu.com"
            };
        }
    }
}