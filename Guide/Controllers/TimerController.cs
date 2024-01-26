using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Timer.Controllers
{
    public class TimerController : Controller
    {
        private readonly ILogger<TimerController> _logger;
        private DateTime _currentDate { get; set; }

        public TimerController(ILogger<TimerController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public string GetClanWarTimer()
        {
            DateTime currentDate = DateTime.Now;
            DateTime clanWarHour = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 19, 0, 0);
            int daysUntilThursday = (4 - (int)currentDate.DayOfWeek + 7) % 7;
            int daysUntilFriday = (5 - (int)currentDate.DayOfWeek + 7) % 7;
            int daysUntilSaturday = (6 - (int)currentDate.DayOfWeek + 7) % 7;
            int daysUntilSunday = (7 - (int)currentDate.DayOfWeek + 7) % 7;
            List<int> daysUntillCWList = new List<int>()
            {
                daysUntilThursday, daysUntilFriday, daysUntilSaturday, daysUntilSunday,
            };
            int daysUntillCW = daysUntillCWList.Min();
            if (DateTime.Now >= clanWarHour && daysUntillCWList.Min() == 0)
            {
                daysUntillCW = 7;
                foreach (int day in daysUntillCWList)
                {
                    if (day != 0 && day < daysUntillCW)
                    {
                        daysUntillCW = day;
                    }
                }
            }
            return $"{daysUntillCW}:{clanWarHour.Hour - currentDate.Hour}:{clanWarHour.Minute - currentDate.Minute}:{clanWarHour.Second - currentDate.Second}";
        }
    }
}