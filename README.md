<!DOCTYPE html>
<html lang="tr">
<head>
    <meta charset="UTF-8">
    <style>
        @page {
            size: A4;
            margin: 20mm;
            background-color: #ffffff;
        }
        body {
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
            line-height: 1.6;
            color: #333;
        }
        h1 { color: #0056b3; border-bottom: 2px solid #0056b3; padding-bottom: 10px; }
        h2 { color: #007bff; margin-top: 25px; }
        .tech-stack { background: #f8f9fa; padding: 15px; border-left: 5px solid #007bff; border-radius: 5px; }
        code { background: #eee; padding: 2px 5px; border-radius: 3px; font-family: monospace; }
        .footer { margin-top: 50px; font-size: 0.9em; color: #777; text-align: center; }
    </style>
</head>
<body>

    <h1>Çokkeçeci JET - Lojistik ve Kargo Takip Sistemi</h1>

    <p>Bu proje, lojistik süreçlerini dijitalleştirmek, uçtan uca şeffaflık sağlamak ve müşteri deneyimini optimize etmek için geliştirilmiş bir platformdur.</p>

    <h2>🚀 Proje Özellikleri</h2>
    <ul>
        <li><strong>Anlık Kargo Takibi:</strong> Benzersiz takip numaraları ile kargo hareketlerinin canlı izlenmesi.</li>
        <li><strong>Harita Entegrasyonu:</strong> Traccar GPS verileriyle kargo konumu ve şube bilgilerinin harita üzerinde görüntülenmesi.</li>
        <li><strong>Detaylı Rota Analizi:</strong> Kargolama başlangıcından teslimata kadar tüm süreçlerin dökümü.</li>
        <li><strong>Modern Altyapı:</strong> .NET 6 ile yüksek performanslı ve ölçeklenebilir altyapı.</li>
    </ul>

    <h2>🛠 Kullanılan Teknolojiler</h2>
    <div class="tech-stack">
        <ul>
            <li><strong>Backend:</strong> .NET 6 (ASP.NET Core)</li>
            <li><strong>Frontend:</strong> HTML5, CSS3, JavaScript</li>
            <li><strong>GPS Entegrasyonu:</strong> Traccar API & Leaflet / Google Maps</li>
            <li><strong>Veri Yönetimi:</strong> SQL Server / Entity Framework Core</li>
        </ul>
    </div>

    <h2>🏗️ Kurulum</h2>
    <p>Projeyi yerel ortamınızda çalıştırmak için aşağıdaki adımları izleyebilirsiniz:</p>
    <pre>
git clone https://github.com/kullanici-adiniz/cokkececi-jet.git
cd cokkececi-jet
dotnet restore
dotnet run
    </pre>

    <div class="footer">
        <p>Proje, lojistik sektöründe dijital dönüşüm için geliştirilmiştir.</p>
    </div>

</body>
</html>
