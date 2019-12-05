using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrontStage.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
		private readonly IMemberService memberService;

		public MemberController(IMemberService memberService)
		{
			this.memberService = memberService;
		}

		public string GetName()
		{
			return memberService.GetName(1) + " ZZ";
		}
    }
}