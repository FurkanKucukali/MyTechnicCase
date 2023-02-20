using Microsoft.AspNetCore.Mvc;
using MyTechnic_Case.Core.Models;
using MyTechnic_Case.Core.Services;

namespace MyTechnic_Case.Web.Controllers
{
	public class TeamController : BaseProcess<Team, ITeamService>
	{
		private readonly ITeamService _teamService;

		public TeamController(ITeamService teamService)
			: base(teamService)
		{
			_teamService = teamService;
		}
	}
}

