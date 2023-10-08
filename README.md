# VeterinerMVC
.Net Mvc yapısı kullanılarak hazırlanmış bir veteriner hasta takip projesidir. 
Veteriner hekim öncelikle sisteme kayıt olur ve giriş yapar. Daha sonra sisteme hastalarını ekler. Veteriner hekim sistem içerisinde hastaların adına randevu oluşturabilir, hastaya ait tedavi ekleyebilir ve aşı tarihi bilgisini kaydedebilir. Eklenen bilgiler üzerinde ilerleyen zamanlarda silme ve güncelleme işlemleri yapabilir.
Projeye ait veriler Microsoft SQL Server üzerinde tutulmuş olup proje tasarımı Visual Studio üzerinden yapılmıştır. Microsoft SQL Server Management Studio’da HastaTakip isimli bir veri tabanı oluşturulmuş, bu veri tabanı içerisinde sistemden kaydettiğimiz verileri tutan tablolar oluşturulmuştur. Bu tablolar Profil, Hayvan, Musteri, Randevular, TedaviEkle ve Asitakvimi şeklindedir. Oluşturulan tablolar arasındaki ilişkiyi sağlamak için Database Diagrams oluşturularak tablolar birbirlerine uygun bir şekilde bağlanmıştır.

Kullanılan veritabanı diyagramı : 


![database](https://github.com/acelyanoguz/VeterinerMVC/blob/main/screenshots/databaseDiagram.png)


Veteriner hasta takip sisteminde bizi ilk olarak aşağıdaki kullanıcı giriş sayfası karşılamaktadır. Sisteme kayıtlı olan veterinerler kullanıcı giriş sayfası kısmından sisteme giriş yapabilmektedir. Eğer veteriner sisteme kayıtlı değilse üye ol butonuna tıklayarak kayıt sayfasına yönlendirilir, bu sayfadan sisteme kaydolabilmektedir. Sisteme üye girişi yapılmadan sistem özelliklerine erişilemez.

![giris](https://github.com/acelyanoguz/VeterinerMVC/blob/main/screenshots/kullaniciGiris.PNG)

Kullanıcımız olan veteriner, sisteme giriş yaptığında aşağıda görseli bulunan Ana Sayfaya yönlendirilir. Ana sayfada üst kısımda hasta kaydının yapıldığı hasta ekle ve hasta bilgilerinin görüntülendiği hasta kartı menüleri bulunmaktadır. Sol tarafta kullanıcıya kolaylık olması açısından hasta ekleme sayfasına yönlendiren bir menü daha eklenmiştir. Buna ek olarak kayıtlı hastaların görüntülendiği ve listelendiği hastalar menüsü bulunmaktadır. Ayrıca hayvan hakları ile ilgili olan haytap sitesine yönlendiren bir menünün yanı sıra Türk veteriner hekimleri birliği sayfasına yönlendiren bir menü de bulunmaktadır. Sağ üst köşede giriş yapan kullanıcının adı görüntülenmektedir. Yanında ise çıkış yap butonu bulunmaktadır.
Veteriner hekimi ana sayfada her kullanıcının kendisine ait olan hastaların randevularını gösteren bir takvim karşılamaktadır. Giriş yapan kullanıcının adına kayıtlı olan hastalar, bu hastalara ait tedavi, randevu, aşı bilgisi ve kullanıcı takvimi o kullanıcıya ait olacak şekilde her kullanıcının sisteminde farklı olarak gelmektedir. Veteriner hekim bu takvimden randevularını takip edebilmektedir. 
Takvim randevu bilgilerini veri tabanından çekmektedir. Veteriner seçtiği hastası için sisteme yeni bir randevu eklediğinde ya da randevu silme-güncelleme işlemini yaptığında bu bilgiler veri tabanına kaydedilir. Takvimimiz ise bu bilgileri veri tabanından çekerek veterinerin ana sayfasına yansıtır. Böylelikle veteriner hekim randevularının tamamını tek bir ekran üzerinden takip edebilecektir.

![anasayfa](https://github.com/acelyanoguz/VeterinerMVC/blob/main/screenshots/anasayfa.PNG)


Kullanıcı hastası ile ilgili bir işlem yapmak istediğinde hastalar menüsünden işlem yapmak istediği hastayı seçer. Bu seçim ile birlikte kullanıcı seçilen hastanın bilgilerinin olduğu hasta kartına yönlendirilir. Hasta kartında hayvana ait olan cinsiyet, ırk, yaş, tür gibi bilgiler bulunmaktadır. Hasta seçimiyle birlikte yukarıda randevu, tedavi ve aşı takvimi menüleri etkin hale gelir. Bu menüler, seçilen hastaya ait randevu, aşı ve tedavi bilgilerinin eklenip, listelenebilmesi için hasta seçimi yapıldığında aktif hale gelecek şekilde ayarlanmıştır. Menülerin bu şekilde ayarlanmasıyla sistemde yapılan işlemlerin hastaya özel olması, sistemin daha düzenli olması ve veteriner hekime kullanış kolaylığı sağlanması amaçlanmıştır. İlgili görsellere aşağıda yer verilmiştir.

![hastaSecim](https://github.com/acelyanoguz/VeterinerMVC/blob/main/screenshots/hastaSecimEkrani.PNG)

![Hasta](https://github.com/acelyanoguz/VeterinerMVC/blob/main/screenshots/secilenHastayaAitHastaKarti.PNG)


Projenin çalışır halinin görsellerine [screenshots](https://github.com/acelyanoguz/VeterinerMVC/tree/main/screenshots) isimli klasör'den erişebilirsiniz.


