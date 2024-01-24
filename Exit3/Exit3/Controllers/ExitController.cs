using Exit3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Exit3.Controllers
{
    public class ExitController : Controller
    {
        Kullanici kullaniciDetaylar;

        ExitDbConnection context = new ExitDbConnection();
        public IActionResult Home()
        {
            return View();
        }

        public async Task<IActionResult> Post(int resimId, int kullaniciId, Begeni begeni)
        {
            Console.WriteLine("ResimID " + resimId);
            begeni = await context.Begeniler.FirstOrDefaultAsync(b => b.ResimId == resimId);
            if (begeni == null)
            {
                // İlgili resmin beğeni bilgisi bulunamazsa, yeni bir beğeni nesnesi oluştur
                begeni = new Begeni { ResimId = resimId, BegeniSayisi = 0, BegenmemeSayisi = 0 };
            }
            Console.WriteLine("Begni " + begeni.BegeniSayisi);

            var begeniList = await context.Begeniler
            .Where(b => b.ResimId == resimId)
            .ToListAsync();

            // Retrieve comments (yorumlar) for the specified image
            var yorumList = await context.Yorumlar
                .Where(y => y.ResimId == resimId)
                .ToListAsync();

            var resim = await context.Resimler
            .Include(r => r.ResimDetaylari)
            .FirstOrDefaultAsync(r => r.ResimId == resimId);

            var resimDetay = resim?.ResimDetaylari; // ?. kullanarak null kontrolü yapılır

            if (resimDetay != null)
            {
                // ResimDetaylari tablosundan gelen bilgiler
                var resimDetayId = resimDetay.ResimDetaylariId;
                var resimAciklama = resimDetay.ResimAciklama;

                // Diğer resim detayı bilgileri burada...
            }
            if (begeniList != null)
            {
                foreach (var begeni1 in begeniList)
                {
                    Console.WriteLine("Like : " + begeni1.BegeniSayisi + "Dislike : " + begeni1.BegenmemeSayisi);
                }
            }
            else
            {
                Console.WriteLine("Girmedi begeni listesine");
            }
            if (yorumList != null)
            {
                foreach (var yorum in yorumList)
                {
                    Console.WriteLine("yorum : " + yorum.Yorum);
                }
            }
            else
            {
                Console.WriteLine("Girmedi begeni listesine");
            }

            // Retrieve the user (kullanici) for the specified user id
            var kullanici = await context.Kullanicilar
                .FirstOrDefaultAsync(k => k.KullaniciId == kullaniciId);

            Debug.WriteLine($"begeniList: {begeniList}");
            Debug.WriteLine($"yorumList: {yorumList}");

            foreach (var yorum in yorumList)
            {
                Console.WriteLine("Yorum : " + yorum.YorumId);
            }
            // Store the image and user in ViewBag to pass them to the view
            ViewBag.Resim = resim;
            ViewBag.Begeni = begeni;
            ViewBag.ResimDetay = resimDetay;
            ViewBag.Kullanici = kullanici;
            ViewBag.BegeniList = begeniList;
            ViewBag.YorumList = yorumList;

            Console.WriteLine("Resim Id : " + resimId + " Kullanici Id : " + kullaniciId);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Post(Yorumlar yorum1, string likeButton, string dislikeButton,int resimId,int kullaniciId)
        {
            var existingBegeni = await context.Begeniler.FirstOrDefaultAsync(b => b.ResimId == resimId);

            if (existingBegeni != null)
            {
                // Kayıt zaten mevcut, güncelleme yapabilirsiniz
                // Beğeni bilgisini güncelle
                context.Begeniler.Update(existingBegeni);
            }
            else
            {
                // Kayıt yoksa, yeni bir kayıt ekleyebilirsiniz
                var newBegeni = new Begeni { ResimId = resimId, BegeniSayisi = 0, BegenmemeSayisi = 0 };
                existingBegeni = newBegeni;
                context.Begeniler.Add(newBegeni);
            }

            // Durum 1: Beğenme sayısı olursa, yorum olmazsa
            if (!string.IsNullOrEmpty(likeButton) && string.IsNullOrEmpty(yorum1?.Yorum))
            {
                Console.WriteLine("İlk if");
                existingBegeni.BegeniSayisi++;
            }
            // Durum 2: Yorum olursa, beğenme olmazsa
            else if (!string.IsNullOrEmpty(yorum1?.Yorum) && string.IsNullOrEmpty(likeButton) && string.IsNullOrEmpty(dislikeButton))
            {
                Console.WriteLine("İkinci if");
                yorum1.ResimId = resimId;
                Console.WriteLine(yorum1.Yorum);

                // Yorumu ekleyin
                context.Yorumlar.Add(yorum1);
            }
            // Beğenmeme sayısı olursa, yorum olmazsa
            if (!string.IsNullOrEmpty(dislikeButton) && string.IsNullOrEmpty(yorum1?.Yorum))
            {
                Console.WriteLine("Dördüncü if");
                existingBegeni.BegenmemeSayisi++;
            }

            // Değişiklikleri kaydedin
            await context.SaveChangesAsync();

            // Sonuçları yazdır
            Console.WriteLine("Begeni Sayisi : " + existingBegeni.BegeniSayisi);
            Console.WriteLine("Begenmeme Sayisi : " + existingBegeni.BegenmemeSayisi);

            return RedirectToAction("Post", new { resimId = resimId, kullaniciId = kullaniciId }); // veya istediğiniz başka bir aksiyon
        }

        public IActionResult Explore(int kullaniciId)
        {
            var model = context.Kullanicilar
        .Include(k => k.Paylasimlar)
        .ThenInclude(p => p.Resim)
        .ThenInclude(r => r.ResimDetaylari)
        .ThenInclude(rd => rd.Etiket)
        .Where(k => k.Paylasimlar.Any()) // Sadece paylaşım yapmış kullanıcıları al
        .ToList();

            ViewBag.Kullanicilar = model;

            return View();
        }
        public IActionResult Profile(int kullaniciId)
        {
            Console.WriteLine("Buraya Kullanıcı İd gelecek : " + kullaniciId);

            var kullaniciAdi = context.Kullanicilar
        .Where(k => k.KullaniciId == kullaniciId)
        .Select(k => k.KullaniciAdi)
        .FirstOrDefault();

            // Kullanıcı adını ViewBag'e ekle
            ViewBag.KullaniciAdi = kullaniciAdi;

            var model = context.Kullanicilar
    .Where(k => k.KullaniciId == kullaniciId)
    .SelectMany(k => k.Paylasimlar)
    .Select(p => new
    {
        KullaniciId = p.Kullanici.KullaniciId,
        KullaniciAdi = p.Kullanici.KullaniciAdi,
        ResimId = p.Resim.ResimId,
        ResimUrl = p.Resim.ResimUrl,
        ResimDetaylariId = p.Resim.ResimDetaylari.ResimDetaylariId,
        ResimAciklama = p.Resim.ResimDetaylari.ResimAciklama,
        ResimDate = p.Resim.ResimDetaylari.ResimDate,
        EtiketId = p.Resim.ResimDetaylari.Etiket.EtiketId,
        EtiketName = p.Resim.ResimDetaylari.Etiket.EtiketName
    })
    .ToList();

            int gonderiSayisi = 0;
            List<string> resimUrls = new List<string>();
            foreach (var item in model)
            {
                gonderiSayisi++;
                ViewBag.KullaniciAdi = item.KullaniciAdi;
                ViewBag.GonderiSayisi = gonderiSayisi; 
                var kullaniciId1 = item.KullaniciId;
                var resimId = item.ResimId;
                var resimUrl =item.ResimUrl;
                resimUrls.Add(resimUrl);
                var resimDetaylariId = item.ResimDetaylariId;
                var resimAciklama = item.ResimAciklama;
                var resimDate = item.ResimDate;
                var etiketId = item.EtiketId;
                var etiketName = item.EtiketName;
                ViewBag.ResimUrls = resimUrls;
                Debug.WriteLine($"KullaniciId: {kullaniciId1}, KullaniciAdi: {kullaniciAdi}, ResimId: {resimId}, ResimUrl: {resimUrl}, ResimDetaylariId: {resimDetaylariId}, ResimAciklama: {resimAciklama}, ResimDate: {resimDate}, EtiketId: {etiketId}, EtiketName: {etiketName}");
            }
            return View(model);
        }

        public IActionResult ProfileEdit(int kullaniciId)
        {
            Console.WriteLine("Buraya Kullanıcı İd gelecek : " + kullaniciId);

            var kullaniciAdi = context.Kullanicilar
.Where(k => k.KullaniciId == kullaniciId)
.Select(k => k.KullaniciAdi)
.FirstOrDefault();
            var Adi= context.Kullanicilar
.Where(k => k.KullaniciId == kullaniciId)
.Select(k => k.Adi)
.FirstOrDefault();

            // Kullanıcı adını ViewBag'e ekle
            ViewBag.KullaniciAdi = kullaniciAdi;
            ViewBag.Adi = Adi;

            return View();
        }

        [HttpPost]
        public IActionResult UpdateUsername(string oldname, string newUsername , int kullaniciId)
        {
            // Kullanıcı adını güncelleme işlemleri burada yapılır
            // context.Kullanicilar nesnesini kullanarak veritabanında güncelleme yapabilirsiniz

            // Örneğin:
            Console.WriteLine("kullanicis değiştirme id : " + kullaniciId);
            var user = context.Kullanicilar.SingleOrDefault(k => k.KullaniciAdi == oldname);
            Console.WriteLine("Profile edit if dışı");
            if (user != null)
            {
                Console.WriteLine("Profile edit if dışı");
                user.KullaniciAdi = newUsername;
                 context.SaveChanges();
            }

            return RedirectToAction("ProfileEdit", new { kullaniciId = kullaniciId });
        }
        [HttpPost]
        public IActionResult Name(string oldname, string newname , int kullaniciId)
        {
            // Kullanıcı adını güncelleme işlemleri burada yapılır
            // context.Kullanicilar nesnesini kullanarak veritabanında güncelleme yapabilirsiniz

            // Örneğin:
            Console.WriteLine("isim değiştirme id : " + kullaniciId);
            var user = context.Kullanicilar.SingleOrDefault(k => k.Adi == oldname);
            Console.WriteLine("Profile edit name if dışı");
            if (user != null)
            {
                Console.WriteLine("Profile edit name if dışı");
                user.KullaniciAdi = newname;
                context.SaveChanges();
            }

            return RedirectToAction("ProfileEdit", new { kullaniciId = kullaniciId });
        }

        public IActionResult PostPaylasma()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Home(Kullanici kullanici, string kullaniciAdi, int Sifre)
        {
            kullanici.Soyadi = "Kara";
            // Örnek bir işlem (konsola yazdırma):
            Console.WriteLine($"Eklendi: {kullanici.Adi}, {kullanici.KullaniciAdi}, {kullanici.DogumTarih}, {kullanici.Cinsiyet}, {kullanici.Mail}, {kullanici.Sifre}");

            // Veritabanına ekleme işlemi
            await context.AddAsync(kullanici);
            await context.SaveChangesAsync();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> PostPaylasma(ResimEkleme resimEkleme, ResimDetaylari resimDetaylari, Etiket etiket, Paylasim paylasim, int kullaniciId)
        {
            Resim resim = new Resim();

            if (resimEkleme.ResimUrl != null)
            {
                var extension = Path.GetExtension(resimEkleme.ResimUrl.FileName);
                var newİmage = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/resimler/", newİmage);
                var stream = new FileStream(location, FileMode.Create);
                resimEkleme.ResimUrl.CopyTo(stream);
                resim.ResimUrl = newİmage;
            }

            Console.WriteLine("Resim URLSİ : " + resim.ResimUrl + "Etiket Id" + etiket.EtiketId);

            resimDetaylari.EtiketId = etiket.EtiketId;
            resimDetaylari.ResimDate = DateTime.Now;

            context.Add(resimDetaylari);
            context.SaveChanges();

            // Kaydedilen ResimDetaylari'nin ID'sini al
            int resimDetaylariId = resimDetaylari.ResimDetaylariId;

            // Resim'i kaydet
            resim.ResimDetaylariId = resimDetaylariId;
            context.Add(resim);
            context.SaveChanges();

            //paylasim.KullaniciId = kullaniciDetaylar.KullaniciId;
            paylasim.KullaniciId = kullaniciId;
            paylasim.ResimId = resim.ResimId;

            context.Add(paylasim);
            context.SaveChanges();

            return RedirectToAction("Profile");
        }
    }
}
