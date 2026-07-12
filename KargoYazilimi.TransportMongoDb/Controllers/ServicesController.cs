using Microsoft.AspNetCore.Mvc;
using NuGet.Packaging.Signing;

namespace KargoYazilimi.TransportMongoDb.Controllers
{
    public class ServicesController : Controller
    {
        [HttpGet("/hizmetlerimiz/konteyner-tasimaciligi")]
        public async Task<IActionResult> ContainerShipping()
        {
            return View();
        }

        [HttpGet("/hizmetlerimiz/dokme-yuk-tasimaciligi")]
        public async Task<IActionResult> BulkCargoTransportation()
        {
            return View();
        }

        [HttpGet("/hizmetlerimiz/ro-ro-tasimaciligi")]
        public async Task<IActionResult> RoRoTransportation()
        {
            return View();
        }

        [HttpGet("/hizmetlerimiz/break-bulk-tasimaciligi")]
        public async Task<IActionResult> BreakBulkTransportation()
        {
            return View();
        }

        [HttpGet("/hizmetlerimiz/proje-kargo-tasimaciligi")]
        public async Task<IActionResult> ProjectCargoTransportation()
        {
            return View();
        }

        [HttpGet("/hizmetlerimiz/genel-kargo")]
        public async Task<IActionResult> GeneralCargo()
        {
            return View();
        }

        [HttpGet("/hizmetlerimiz/express-tasimacilik")]
        public async Task<IActionResult> ExpressTransportation()
        {
            return View();
        }

        [HttpGet("/hizmetlerimiz/tehlikeli-madde-tasimaciligi")]
        public async Task<IActionResult> DangerousGoodsTransportation()
        {
            return View();
        }

        [HttpGet("/hizmetlerimiz/gabari-disi-kargo")]
        public async Task<IActionResult> OversizedCargo()
        {
            return View();
        }

        [HttpGet("/hizmetlerimiz/bozulabilir-gida-tasimaciligi")]
        public async Task<IActionResult> PerishableFoodTransportation()
        {
            return View();
        }

        [HttpGet("/hizmetlerimiz/kara-yolu-tasimaciligi")]
        public async Task<IActionResult> RoadTransport()
        {
            return View();
        }

        [HttpGet("/hizmetlerimiz/demir-yolu-tasimaciligi")]
        public async Task<IActionResult> RailwayTransportation()
        {
            return View();
        }

        [HttpGet("/hizmetlerimiz/intermodal-tasimaciligi")]
        public async Task<IActionResult> IntermodalTransportation()
        {
            return View();
        }

        [HttpGet("/hizmetlerimiz/parsiyel-tasimaciligi")]
        public async Task<IActionResult> PartialLoadTransportation()
        {
            return View();
        }

        [HttpGet("/hizmetlerimiz/ozel-tasimaciligi")]
        public async Task<IActionResult> SpecialTransportation()
        {
            return View();
        }

        [HttpGet("/hizmetlerimiz/demir-yolu-hizmetleri")]
        public async Task<IActionResult> RailwayTerminalServices()
        {
            return View();
        }

        [HttpGet("/hizmetlerimiz/demiryolu-forwarder-hizmetleri")]
        public async Task<IActionResult> RailwayForwarderServices()
        {
            return View();
        }

        [HttpGet("/hizmetlerimiz/demiryolu-lojistik-danismanligi")]
        public async Task<IActionResult> RailwayLogisticsConsulting()
        {
            return View();
        }

        [HttpGet("/hizmetlerimiz/depolama-hizmeleri")]
        public async Task<IActionResult> StorageServices()
        {
            return View();
        }

        [HttpGet("/hizmetlerimiz/dagitim-merkezi-operasyonlari")]
        public async Task<IActionResult> DistributionCenterOperations()
        {
            return View();
        }

        [HttpGet("/hizmetlerimiz/e-ticaret-lojistik-hizmetleri")]
        public async Task<IActionResult> EcommerceLogisticsServices()
        {
            return View();
        }

        [HttpGet("/hizmetlerimiz/tersine-lojistik")]
        public async Task<IActionResult> ReverseLogistics()
        {
            return View();
        }

        [HttpGet("/hizmetlerimiz/stok-yönetimi")]
        public async Task<IActionResult> StockManagement()
        {
            return View();
        }

    }
}
