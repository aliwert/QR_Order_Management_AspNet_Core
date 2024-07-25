using Microsoft.AspNetCore.Mvc;
using QRCoder;
using System.Drawing;
using System.Drawing.Imaging;
namespace SignalRWebUI.Controllers
{
    public class QrCodeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(string value)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                QRCodeGenerator createQRCode = new QRCodeGenerator();
                QRCodeGenerator.QRCode squareCode = createQRCode.CreateQrCode(value, QRCodeGenerator.ECCLevel.Q);
                using (Bitmap image = squareCode.GetGraphic(10))
                {
                    image.Save(ms, ImageFormat.Png);
                    ViewBag.QrCodeImage = "data:image/png;base64," + Convert.ToBase64String(ms.ToArray());
                }

            }
            return View();
        }
    }
}
