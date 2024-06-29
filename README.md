# MVC Blog Uygulaması

## Genel Bakış

MVC Blog Uygulaması, ASP.NET MVC kullanılarak oluşturulmuş web tabanlı bir blog platformudur. Kullanıcıların blog yazılarını oluşturmasına, düzenlemesine, silmesine ve görüntülemesine olanak tanır. Uygulama ayrıca kullanıcı kimlik doğrulaması ve rol tabanlı erişim kontrolü de destekler.

## Özellikler

- Kullanıcı kimlik doğrulama ve yetkilendirme
- Blog yazıları için CRUD işlemleri
- Rol tabanlı erişim kontrolü
- Kullanıcı dostu arayüz ve duyarlı tasarım
- Blog yazıları için arama fonksiyonu

## Teknolojiler ve Araçlar

- **ASP.NET MVC**
- **Entity Framework**
- **SQL Server**
- **Bootstrap**


## Gereksinimler

- Visual Studio 2019 veya daha yeni bir sürüm
- .NET Core SDK 3.1 veya daha yeni bir sürüm
- SQL Server 2016 veya daha yeni bir sürüm

## Kurulum

1. **Depoyu klonlayın**
   ```sh
   git clone https://github.com/kullanıcıadınız/mvc-blog-app.git
   cd mvc-blog-app
2. **Projeyi Visual Studio'da açın**
  - vcBlogApp.sln çözüm dosyasını Visual Studio'da açın.

3. **NuGet paketlerini geri yükleyin**
  -Visual Studio'da Çözüm Gezgini'nde çözüme sağ tıklayın ve "NuGet Paketlerini Geri Yükle" seçeneğini seçin.

4. **Veritabanı bağlantı dizesini güncelleyin**
  -appsettings.json dosyasındaki DefaultConnection dizesini SQL Server bağlantı bilgilerinizle güncelleyin:

"ConnectionStrings": {
  "DefaultConnection": "Server=sunucunuz;Database=veritabanınız;User Id=kullanıcıadınız;Password=şifreniz;"
}
5. **Migrations (göçleri) uygulayın**
  -Visual Studio'da Paket Yöneticisi Konsolu'nu açın ve aşağıdaki komutları çalıştırarak göçleri uygulayın ve veritabanını oluşturun:

6. **Update-Database**
  -Uygulamayı çalıştırın
  -F5 tuşuna basarak veya Visual Studio'daki "Çalıştır" düğmesine tıklayarak uygulamayı başlatın.

## Kullanım
  -Yeni bir kullanıcı kaydedin veya mevcut bir hesapla giriş yapın.
  -"Post Oluştur" sayfasına giderek yeni bir blog yazısı oluşturun.
  -Ana sayfada tüm blog yazılarını görüntüleyin.
  -"Yazılarım" sayfasından yazılarınızı düzenleyin veya silin.
  **Klasör Yapısı**
  -Controllers: HTTP isteklerini işlemek ve yanıtları döndürmekten sorumlu denetleyici sınıfları içerir.
 - Models: Uygulamanın verilerini temsil eden model sınıflarını içerir.
  -Views: Uygulamanın görünümleri (HTML şablonları) için dosyaları içerir.
  -wwwroot: CSS, JavaScript ve resimler gibi statik dosyaları içerir.
 

