# ?? Flappy Bird - C# Windows Forms Oyunu

Bu proje, klasik Flappy Bird oyununun C# Windows Forms kullanýlarak geliþtirilmiþ tam özellikli bir versiyonudur. Oyun, orijinal Flappy Bird deneyimini korurken, ek özellikler ve Türkçe dil desteði ile geliþtirilmiþtir.

## ?? Ýçindekiler
- [Özellikler](#özellikler)
- [Teknolojiler](#teknolojiler)
- [Kurulum](#kurulum)
- [Oynanýþ](#oynanýþ)
- [Proje Yapýsý](#proje-yapýsý)
- [Geliþtirme Süreci](#geliþtirme-süreci)
- [Teknik Detaylar](#teknik-detaylar)
- [Katkýda Bulunma](#katkýda-bulunma)

## ?? Özellikler

### ? Oyun Mekaniði
- **Fizik Tabanlý Hareket**: Gerçekçi gravity ve zýplama mekaniði
- **Yumuþak Kontroller**: Responsive ve kullanýcý dostu kontrol sistemi
- **Çoklu Boru Sistemi**: Dinamik olarak oluþturulan 3 çift boru
- **Akýllý Zorluk**: Skor arttýkça artan oyun hýzý
- **Çarpýþma Efektleri**: Görsel ve iþitsel feedback sistemi

### ?? Görsel Özellikler
- **Kuþ Animasyonu**: Kanat çýrpma animasyonu
- **Çarpýþma Efektleri**: Titreme ve renk deðiþimi
- **Temiz UI**: Modern ve anlaþýlýr kullanýcý arayüzü
- **Türkçe Dil Desteði**: Tam Türkçe oyun metinleri

### ?? Teknik Özellikler
- **Sabit Pencere Boyutu**: Yeniden boyutlandýrma korumasý
- **Optimized Performance**: 20ms timer ile smooth gameplay
- **Memory Efficient**: Dinamik nesne yönetimi
- **Exception Handling**: Hata korumalý ses sistemi

## ??? Teknolojiler

### Ana Framework
- **.NET Framework 4.7.2**: Ana geliþtirme framework'ü
- **Windows Forms**: GUI framework'ü
- **C# 7.3**: Programlama dili

### Kullanýlan Sýnýflar ve Bileþenler
```csharp
// Ana Sýnýflar
- Form (Ana oyun penceresi)
- PictureBox (Kuþ ve boru görselleri)
- Timer (Oyun döngüsü ve animasyonlar)
- Label (Skor ve talimatlar)

// Koleksiyonlar
- List<PictureBox> (Dinamik boru yönetimi)
- Rectangle (Çarpýþma kontrolü)

// Grafik ve Medya
- System.Drawing (Görsel iþlemler)
- System.Media.SystemSounds (Ses efektleri)
- Resources (Oyun varlýklarý)
```

### Oyun Döngüsü Bileþenleri
- **gameTimer**: Ana oyun döngüsü (20ms interval)
- **Flying_timer1**: Kuþ animasyonu (200ms interval)
- **KeyDown Events**: Keyboard input handling
- **Mouse Click Events**: Mouse input handling

## ?? Kurulum

### Gereksinimler
- Windows 10/11
- .NET Framework 4.7.2 veya üzeri
- Visual Studio 2019/2022 (geliþtirme için)

### Kurulum Adýmlarý
1. **Projeyi Ýndirin**
   ```bash
   git clone [repository-url]
   cd FlappyBird
   ```

2. **Visual Studio'da Açýn**
   - `FlappyBird.sln` dosyasýný çift týklayýn
   - Veya Visual Studio > File > Open > Project/Solution

3. **Build ve Çalýþtýrýn**
   - `Ctrl + F5` ile derleyin ve çalýþtýrýn
   - Veya Build > Build Solution > Debug > Start Without Debugging

## ?? Oynanýþ

### Kontroller
| Tuþ/Aksiyon | Fonksiyon |
|-------------|-----------|
| **SPACE** | Kuþu zýplatýr / Oyunu yeniden baþlatýr |
| **Mouse Click** | Kuþu zýplatýr / Oyunu yeniden baþlatýr |

### Oyun Kurallarý
1. **Amaç**: Kuþu borularýn arasýndan geçirerek en yüksek skoru elde edin
2. **Hareket**: Kuþ sürekli düþer, SPACE ile yukarý zýplar
3. **Engeller**: Üst ve alt borulara çarpmayýn
4. **Sýnýrlar**: Ekranýn üst ve alt sýnýrlarýna çarpmayýn
5. **Skor**: Her boru çiftini geçtiðinizde +1 puan
6. **Zorluk**: Her 15 puanda oyun hýzý artar

### Oyun Mekaniði Detaylarý
- **Baþlangýç Gravity**: 4 (yumuþak düþüþ)
- **Maksimum Gravity**: 10
- **Zýplama Kuvveti**: -10 (yukarý doðru)
- **Boru Hýzý**: 4'ten 7'ye kadar artar
- **Boru Aralýðý**: 220 pixel (geçilebilir)
- **Çarpýþma Efekti**: 0.6 saniye titreme ve renk deðiþimi

## ?? Proje Yapýsý

```
FlappyBird/
??? ?? Form1.cs                 # Ana oyun logic'i
??? ?? Form1.Designer.cs        # UI tasarým kodu
??? ?? Form1.resx              # Form kaynaklarý
??? ?? Program.cs               # Uygulama giriþ noktasý
??? ?? Properties/
?   ??? ?? AssemblyInfo.cs      # Assembly bilgileri
?   ??? ?? Resources.Designer.cs # Kaynak dosyasý yönetimi
?   ??? ?? Resources.resx       # Kaynak tanýmlarý
?   ??? ?? Settings.Designer.cs # Uygulama ayarlarý
??? ?? Resources/               # Oyun varlýklarý
?   ??? ??? Flappy_Bird_1.png    # Kuþ sprite 1
?   ??? ??? Flappy_Bird_2.png    # Kuþ sprite 2
?   ??? ??? PipeHead.png         # Boru baþý
?   ??? ??? PipeBody.png         # Boru gövdesi
??? ?? README.md               # Bu dosya
```

## ?? Geliþtirme Süreci

### Faz 1: Temel Oyun Mekaniði
- [x] Kuþ hareketi ve gravity sistemi
- [x] Temel zýplama mekaniði
- [x] Kuþ animasyonu (kanat çýrpma)

### Faz 2: Boru Sistemi
- [x] Dinamik boru oluþturma
- [x] Boru hareketi ve yeniden konumlandýrma
- [x] Çarpýþma kontrolü

### Faz 3: Oyun Mekaniði
- [x] Skor sistemi
- [x] Game over logic'i
- [x] Yeniden baþlatma

### Faz 4: Ýyileþtirmeler
- [x] Türkçe dil desteði
- [x] Oynanýþ kolaylaþtýrmalarý
- [x] Çoklu boru sistemi
- [x] Sabit pencere boyutu

### Faz 5: Görsel Efektler
- [x] Çarpýþma efektleri
- [x] Ses efektleri
- [x] Titreme animasyonu
- [x] Renk deðiþimi efektleri

## ?? Teknik Detaylar

### Ana Sýnýflar ve Fonksiyonlar

#### Form1.cs - Ana Oyun Sýnýfý
```csharp
public partial class Form1 : Form
{
    // Temel oyun deðiþkenleri
    int pipeSpeed = 4;           // Boru hareket hýzý
    int gravity = 6;             // Gravity kuvveti
    int score = 0;               // Oyuncu skoru
    bool gameOver = false;       // Oyun durumu
    List<PictureBox> pipes;      // Dinamik boru listesi
    
    // Çarpýþma efekti deðiþkenleri
    bool crashEffect = false;     // Efekt durumu
    int crashEffectTimer = 0;     // Efekt zamanlayýcýsý
}
```

#### Kritik Fonksiyonlar
- **`setupPipes()`**: Dinamik boru sistemini baþlatýr
- **`resetGame()`**: Oyunu sýfýrlar ve yeniden baþlatýr
- **`jump()`**: Kuþun zýplama mekaniði
- **`gameTimer_Tick()`**: Ana oyun döngüsü (60 FPS)
- **`startCrashEffect()`**: Çarpýþma efektini baþlatýr
- **`finalizeGameOver()`**: Oyun bitiþini tamamlar

### Algoritma Detaylarý

#### Çarpýþma Kontrolü
```csharp
Rectangle birdRect = new Rectangle(
    FlappyBirdpictureBox1.Left + 5, 
    FlappyBirdpictureBox1.Top + 5, 
    FlappyBirdpictureBox1.Width - 10, 
    FlappyBirdpictureBox1.Height - 10
);
```
- 10 pixel tolerans ile daha adil çarpýþma
- Rectangle intersection kullanýmý

#### Boru Pozisyonlama
```csharp
int minHeight = 180; // Minimum geçiþ yüksekliði
int maxHeight = 350; // Maksimum geçiþ yüksekliði
int pipeHeight = rand.Next(minHeight, maxHeight);
```
- Garantili geçilebilir aralýklar
- 220 pixel geçiþ boþluðu

### Performance Optimizasyonlarý
- **Timer Intervals**: 20ms ana döngü, 200ms animasyon
- **Memory Management**: Dinamik liste kullanýmý
- **Efficient Collision**: Rectangle intersection
- **Resource Management**: Shared PictureBox kullanýmý

## ?? Kullanýlan Varlýklar

### Görsel Varlýklar
- **Flappy_Bird_1.png**: Kuþ sprite (kanat yukarý)
- **Flappy_Bird_2.png**: Kuþ sprite (kanat aþaðý)
- **PipeHead.png**: Boru baþý (üst ve alt için)
- **PipeBody.png**: Boru gövdesi (kullanýma hazýr)

### Ses Efektleri
- **System.Media.SystemSounds.Hand**: Çarpýþma sesi
- Platform native ses kullanýmý

### Renkler ve Tema
- **Arka Plan**: Sky Blue (`RGB(153, 217, 234)`)
- **Zemin**: Saddle Brown
- **UI Text**: Beyaz ve Sarý
- **Çarpýþma Efekti**: Kýrmýzý yanýp sönme

## ?? Gelecek Geliþtirmeler

### Planlanan Özellikler
- [ ] High Score kaydetme sistemi
- [ ] Farklý kuþ karakterleri
- [ ] Ek ses efektleri ve müzik
- [ ] Power-up'lar ve bonuslar
- [ ] Farklý zorluk seviyeleri
- [ ] Achievement sistemi

### Teknik Ýyileþtirmeler
- [ ] Settings dosyasý ile özelleþtirme
- [ ] Database entegrasyonu
- [ ] Network leaderboard
- [ ] Better graphics ve animasyonlar

## ?? Katkýda Bulunma

### Geliþtirme Ortamý Kurulumu
1. Visual Studio 2019+ yükleyin
2. .NET Framework 4.7.2 SDK'sýný kurun
3. Projeyi clone edin
4. Dependencies'leri restore edin

### Katký Yönergeleri
1. Fork edin
2. Feature branch oluþturun (`git checkout -b feature/AmazingFeature`)
3. Deðiþikliklerinizi commit edin (`git commit -m 'Add some AmazingFeature'`)
4. Branch'e push edin (`git push origin feature/AmazingFeature`)
5. Pull Request oluþturun

## ?? Proje Ýstatistikleri

- **Toplam Kod Satýrý**: ~400 satýr C#
- **Sýnýf Sayýsý**: 1 ana sýnýf (Form1)
- **Method Sayýsý**: 12 ana method
- **Varlýk Sayýsý**: 4 görsel varlýk
- **Geliþtirme Süresi**: ~8 iterasyon
- **Platform**: Windows (.NET Framework)

## ?? Lisans

Bu proje eðitim amaçlý geliþtirilmiþtir. Ticari olmayan kullaným için serbesttir.

## ????? Geliþtirici Notlarý

### Öðrenilen Konular
- Windows Forms ile oyun geliþtirme
- Timer tabanlý game loop
- Collision detection algoritmalarý
- Resource management
- Event-driven programming
- UI/UX design prensipleri

### Karþýlaþýlan Zorluklar ve Çözümler
1. **Çarpýþma Toleransý**: Hitbox küçültme ile çözüldü
2. **Boru Spawn Logic**: Min/Max sýnýrlar ile kontrol edildi
3. **Performance**: Timer interval optimizasyonu
4. **Çarpýþma Efektleri**: State management ile yönetildi

---

?? **Ýyi Oyunlar!** ??

*Bu oyun, klasik Flappy Bird deneyimini modern C# teknolojileri ile yeniden yaratma amacýyla geliþtirilmiþtir.*