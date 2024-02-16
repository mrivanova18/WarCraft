using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WarCraft.Core.Contracts;
using WarCraft.Models.Statistic;

namespace WarCraft.Controllers
{
    public class StatisticsController : Controller
    {
        private readonly IStatisticsService statisticsService;
        public StatisticsController(IStatisticsService statisticsService)
        {
            this.statisticsService = statisticsService;
        }

        // GET: StatisticsController
        public ActionResult Index()
        {
            StatisticVM statistics = new StatisticVM();
            statistics.CountClients = statisticsService.CountClients();
            statistics.CountProducts = statisticsService.CountProducts();
            statistics.CountOrders = statisticsService.CountOrders();
            statistics.SumOrders = statisticsService.SumOrders();

            return View(statistics);
        }
    }
}
