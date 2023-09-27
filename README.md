# RiseAssessment
-Proje API ve Web olacak şekilde oluşturuldu ve ilgili frameworkler eklendi.

-API Project
-Db modelleri oluşturuldu, dbContext implementasyonu gerçekleştirildi ve miggration gerçekleştirildi.
-BitcoinValueUpdater backgroundService'i, BackgroundService'den implement edilerek bitcoin verilerini bir apiden çekip dbye kayıt edecek service hazırlandı. 
-Database işlemlerinin gerçekleştirilmesi için Access katmanı oluşturuldu ve Business işlemleri için Store katmanı oluşturuldu.
-DI için StartUp.cs eklemeleri gerçekleştirildi.
-Mapping işlemleri için Extension sınıflar oluşturuldu.
-Authentication işlemleri için BasicAuthentication kullanıldı ve Startup.cs de implementasyon gerçekleştirildi.
-API projesinin endpointleri tamamlandı. Crypto endpointi için Authorize aktifleştirildi.

-WEB Project
-ViewModeller oluşturuldu.
-API projesi ile haberleşmesi için CryptoApiService ve UserApiService oluşturuldu.
-DI için StartUp.cs eklemeleri gerçekleştirildi.
-API endpointleri appsettings.json kaydedildi.
-Login olduktan sonra üretilecek token için static olarak TokenHelper oluşturuldu.
-Frontend Login ve Register ekranları geliştirildi.
-Frontend Btc datalarını listelemek için chart.js kullanıldı ve Günlük-Haftalık-Aylık filtreleme geliştirmesi yapıldı.
-Proje dockerize edilip tüm solution için docker-compose hazırlandı.
