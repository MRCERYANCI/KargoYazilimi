using KargoYazilimi.TransportMongoDb.Dtos.AdminDtos;
using KargoYazilimi.TransportMongoDb.Services.AdminServices;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

// %100 Ücretsiz ve Lisanssız Grafik Kütüphanesi
using SkiaSharp;

namespace KargoYazilimi.TransportMongoDb.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILoginService _loginService;

        public AccountController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            // Eğer kullanıcı zaten giriş yapmışsa direkt panele yönlendir
            if (User.Identity != null && User.Identity.IsAuthenticated)
            {
                return RedirectToAction("SliderList", "Slider");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDto loginDto, string captchaCode)
        {
            // 1. CAPTCHA KONTROLÜ
            var savedCaptcha = HttpContext.Session.GetString("CaptchaCode");

            if (string.IsNullOrEmpty(captchaCode) || string.IsNullOrEmpty(savedCaptcha) ||
                !string.Equals(captchaCode, savedCaptcha, StringComparison.OrdinalIgnoreCase))
            {
                ViewBag.Error = "Güvenlik kodunu hatalı girdiniz!";
                return View(); // Hatalıysa giriş işlemine hiç başlama
            }

            // Güvenlik için kullanılmış kodu sil (Tek kullanımlık olsun)
            HttpContext.Session.Remove("CaptchaCode");

            // 2. Servise git ve kullanıcıyı doğrula
            var admin = await _loginService.CheckUserAsync(loginDto);

            if (admin != null)
            {
                // 3. Kimlik Kartını Oluştur (Claims)
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, admin.Username),
                    new Claim(ClaimTypes.Email, admin.Email),
                    new Claim(ClaimTypes.Role, admin.Role),
                    new Claim("FullName", admin.Name + " " + admin.Surname),
                    new Claim("ImageUrl", admin.ImageUrl ?? "/images/default-user.png"),
                    new Claim("AdminId", admin.AdminId)
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                // 4. Çerez Ayarları
                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = loginDto.RememberMe, // "Beni Hatırla" seçildiyse çerez kalıcı olur
                    ExpiresUtc = DateTimeOffset.UtcNow.AddDays(7) // 7 gün geçerli olsun
                };

                // 5. Giriş Yap (Çerezi Tarayıcıya Gönder)
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity), authProperties);

                // Giriş başarılı, dashboard'a uçur
                return RedirectToAction("SliderList", "Slider");
            }

            // Hata varsa mesajı bas
            ViewBag.Error = "Kullanıcı adı veya şifre hatalı!";
            return View();
        }

        [Route("Logout")]
        public async Task<IActionResult> Logout()
        {
            // Çerezi sil ve çıkış yap
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }

        // --- GELİŞMİŞ ANTI-BOT CAPTCHA ÜRETİM METODU (SkiaSharp) ---
        [HttpGet]
        [Route("Account/GetCaptchaImage")]
        public IActionResult GetCaptchaImage()
        {
            // 1. Rastgele Kod Üret (Karışan karakterleri çıkardık)
            const string chars = "ABCDEFGHJKLMNPQRSTUVWXYZ23456789";
            var random = new Random();
            var captchaCode = new string(Enumerable.Repeat(chars, 5).Select(s => s[random.Next(s.Length)]).ToArray());

            HttpContext.Session.SetString("CaptchaCode", captchaCode);

            // 2. Resim Ayarları
            int width = 130;
            int height = 50;

            using var surface = SKSurface.Create(new SKImageInfo(width, height));
            var canvas = surface.Canvas;

            // Arkaplan rengi
            canvas.Clear(SKColor.Parse("#F4F4F4"));

            // 3. GÜRÜLTÜ (NOISE) EKLEME - Botların kenar bulmasını zorlaştırır
            using var noisePaint = new SKPaint { Color = SKColors.Gray, IsAntialias = true };
            for (int i = 0; i < 150; i++)
            {
                float x = random.Next(0, width);
                float y = random.Next(0, height);
                canvas.DrawCircle(x, y, random.Next(1, 3), noisePaint); // Rastgele boyutta noktalar
            }

            // 4. KAVİSLİ ÇİZGİLER (Bezier Curves) - Harfleri böler
            using var curvePaint = new SKPaint
            {
                Color = SKColors.DarkGray,
                Style = SKPaintStyle.Stroke,
                StrokeWidth = 2,
                IsAntialias = true
            };

            using var path = new SKPath();
            path.MoveTo(0, random.Next(10, height - 10)); // Başlangıç
            path.CubicTo(
                random.Next(20, width / 2), random.Next(0, height), // Kontrol noktası 1
                random.Next(width / 2, width - 20), random.Next(0, height), // Kontrol noktası 2
                width, random.Next(10, height - 10)); // Bitiş

            canvas.DrawPath(path, curvePaint);

            // 5. HARFLERİ ÇİZME (Tek tek döndürerek ve boyutlarını hafif değiştirerek)
            using var textPaint = new SKPaint
            {
                Color = SKColor.Parse("#C42026"), // Kırmızımtırak renk
                IsAntialias = true,
                Typeface = SKTypeface.FromFamilyName("Courier New", SKFontStyleWeight.Bold, SKFontStyleWidth.Normal, SKFontStyleSlant.Upright)
            };

            float startX = 15f; // İlk harfin X konumu

            foreach (char c in captchaCode)
            {
                // Her harf için rastgele boyut (22 ile 28 arası)
                textPaint.TextSize = random.Next(22, 28);

                // Her harf için rastgele Y konumu (aşağı yukarı kaysın)
                float y = random.Next(30, 40);

                // Her harf için rastgele dönüş açısı (-25 ile +25 derece arası)
                float angle = random.Next(-25, 25);

                canvas.Save(); // Tuvalin mevcut durumunu kaydet
                canvas.Translate(startX, y); // Harfin basılacağı noktaya git
                canvas.RotateDegrees(angle); // Tuvali o noktada hafifçe döndür

                // Harfi çiz (X ve Y 0, çünkü zaten o noktaya Translate ile gittik)
                canvas.DrawText(c.ToString(), 0, 0, textPaint);

                canvas.Restore(); // Tuvali düzelt (diğer harf etkilenmesin)

                // Bir sonraki harf için X konumunu ileri al
                startX += textPaint.MeasureText(c.ToString()) + random.Next(2, 6);
            }

            // Resmi dışa aktar
            using var image = surface.Snapshot();
            using var data = image.Encode(SKEncodedImageFormat.Png, 100);
            using var ms = new MemoryStream();
            data.SaveTo(ms);

            return File(ms.ToArray(), "image/png");
        }

    }
}