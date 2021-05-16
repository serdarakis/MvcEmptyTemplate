# State Management Uygulaması

Temel bir state yönetimi API uygulamasıdır. **_Task yaratma, State yaratma, Flow yaratma_** ve **Task durumunu güncelleme, durumunu görüntüleme ve bir Task için t zamanındaki durumuna döndürülebilme** işlemleri yapmaktadır.

## Hikaye

Diyelim ki 4 adet state yaratıyoruz. Bunlar `StateA`, `StateB`, `StateC` ve `StateD` olsun. Ve bir adet `Task` yaratıyoruz. Bunun da ismi `Task1` olsun.

| StateA | StateB | StateC | StateD |
| ------ | ------ | ------ | ------ |
| Task1  |        |        |

Ve sonra da `Task1`in izleyeceği yolu belirlemek için `Flow` yaratıyoruz. Yani yukaridaki tablonun `Flow` açıklaması şu şekilde:
Sırası ile `StateA` <--> `StateB` <--> `StateC` <--> `StateD` yapabilir. Fakat `StateA`'dan `StateC`'ye geçemez. Ama flow'u bu şekilde de düzenleyebilirdik;

| StateA | StateC | StateB | StateD |
| ------ | ------ | ------ | ------ |
| Task1  |        |        |

**Task1** artık `StateA`'dan `StateC`'ye geçebilir. Fakat `StateA`'dan `StateB`ye **geçemez.**

---

| StateA | StateB         | StateC | StateD |
| ------ | -------------- | ------ | ------ |
|        | <--- Task1 --> |        |

**Task1** bulunduğu state'ten **bir önceki** state'e dönebilir ve **bir sonraki** state'e geçebilir.
yani;
**Task1** artık `StateB`'den `StateC`'ye geçebilir ve `StateB`'den `StateA`'ya geçebilir. `StateB`'den `StateD`'ye geçemez.

---

Farklı bir `Flow` yaratıp onun içerisinde de farklı tasklar yürütebilirim.

| StateA | StateC | StateD | StateB |
| ------ | ------ | ------ | ------ |
| Task1  |        |        |        |
| Task2  |        |        |        |

| StateX | StateY | StateZ | StateQ |
| ------ | ------ | ------ | ------ |
| Task3  |        |        |        |
| Task4  |        |        |        |

---

Bir `Task` herhangi bir t anındaki durumuna geri döndürülebilir olmalıdır.

---

### Teknik Açıklama

Uygulama üzerindeki `Task`, `State`, `Flow` nesneleri `CREATE`, `READ`, `UPDATE`, `DELETE` ve diğer işlemleri için API çağrıları kullanılacaktır.

[Restful Methods](https://restfulapi.net/http-methods/)

### Teknik gereksinimler

**Teknolojiler**

- Platform: .NET Core 2 ve üstü
- IoC Kütüphanesi: Herhangi bir IoC container kullanılabilir.
- ORM Kütüphanesi: Herhangi bir kütüphane kullanılabilir.
- Database: Herhangi bir database.
- API( ve kullanılan diğer toollar)  docker üzerinde run edilebilir.

**Dependency Injection**

- ApiController sınıfları da dahil olmak üzere tüm sınıflar Dependency Injenction ile sağlanmalıdır.

**Repository Pattern**

- Servis katmanı ile veri erişim katmanı ayrıştırılmalıdır.

### İpucu

- Clean code güzel hazırlanmış bir pazar kahvaltısı gibidir.
- Unit test yazmak hava biraz kapalı olsa bile yanına şemsiyesini alan bir insanın tutumu gibidir.
- Bir entitynin durumuna event-centric yaklaşmak güzel bir bakış açısıdır.
- Swagger yararlı bir API doc tooludur.


### Teslim

- Bu repository'i fork edip, kendi Github hesabınız üzerinden geliştirmeyi yapınız. 
- İlk comitinizi `Initial Commit` mesajıyla gönderiniz ve tüm projeyi max 4 gün içinde bitirmeniz beklenmektedir.
- Projeyi tamamladığınızda reponun adresini erdem@proceedlabs.com adresine `Backend Developer - State Management Challange` başlığı ile yollayınız.
