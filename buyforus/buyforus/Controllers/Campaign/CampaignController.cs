﻿using buyforus.Controllers.Home;
using buyforus.Models;
using buyforus.Services;
using buyforus.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace buyforus.Controllers
{
    public class CampaignController : Controller
    {
        private readonly ICampaignService campaignService;
        private readonly UserManager<User> userManager;

        public CampaignController(ICampaignService campaignService)
        {
            this.campaignService = campaignService;
        }

        [HttpGet("/campaigninfo/{campaignId}")]
        public async Task<IActionResult> CampaignInfo(long campaignId)
        {
            if (campaignId != 0)
            {
                var currentUser = await userManager.GetUserAsync(HttpContext.User);
                var campaign =await campaignService.FindCampaignByIdAsync(campaignId);
                return View(new CampaignViewModel
                    { Campaign = campaign, User = currentUser });
            }

            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
    }
}
