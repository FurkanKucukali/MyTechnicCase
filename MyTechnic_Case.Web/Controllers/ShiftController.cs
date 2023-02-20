using Microsoft.AspNetCore.Mvc;
using MyTechnic_Case.Core.Models;
using MyTechnic_Case.Core.Services;

namespace MyTechnic_Case.Web.Controllers
{
	public class ShiftController : BaseProcess<Shift, IShiftService>
	{
		private readonly IShiftService _shiftService;

		public ShiftController(IShiftService shiftService)
			: base(shiftService)
		{
			_shiftService = shiftService;
		}
	}
}
