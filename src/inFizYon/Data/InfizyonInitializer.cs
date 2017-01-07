using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.DependencyInjection;
using inFizYon.Ontology;
using inFizYon.AcademyModels;
using inFizYon.ciqModels;

namespace inFizYon.Data
{
    public static class AcademyInitializer {
        public static void inFizYonInitializeAcademy(inFizYonAcademyContext academycontext) {
            academycontext.Database.EnsureCreated();
            // Look for any students.
            if (academycontext.students.Any())
            { return;   // DB has been seeded
            }

            //var students = new PartyReal[]
            //{
            //new PartyReal{ciqPrname="Carson",ciqPrsurname="Alexander",ciqPrssec="20152017901"},
            //new PartyReal{ciqPrname="Meredith",ciqPrsurname="Alonso",ciqPrssec="20152017902"},
            //new PartyReal{ciqPrname="Arturo",ciqPrsurname="Anand",ciqPrssec="20152017903"},
            //new PartyReal{ciqPrname="Gytis",ciqPrsurname="Barzdukas",ciqPrssec="20152017904"},
            //new PartyReal{ciqPrname="Yan",ciqPrsurname="Li",ciqPrssec="20152017905"},
            //new PartyReal{ciqPrname="Peggy",ciqPrsurname="Justice",ciqPrssec="20152017906"},
            //new PartyReal{ciqPrname="Laura",ciqPrsurname="Norman",ciqPrssec="20152017907"},
            //new PartyReal{ciqPrname="Nino",ciqPrsurname="Olivetto",ciqPrssec="20152017908"}
            //};
            //foreach (PartyReal s in students)
            //{
            //    academycontext.students.Add(s);
            //}
            //academycontext.SaveChanges();

            var courses = new Course[]
            {
            new Course{courseID=1050,title="Chemistry",credits=3,},
            new Course{courseID=4022,title="Microeconomics",credits=3,},
            new Course{courseID=4041,title="Macroeconomics",credits=3,},
            new Course{courseID=1045,title="Calculus",credits=4,},
            new Course{courseID=3141,title="Trigonometry",credits=4,},
            new Course{courseID=2021,title="Composition",credits=3,},
            };
            foreach (Course c in courses)
            {
                academycontext.courses.Add(c);
            }
            academycontext.SaveChanges();

            var enrollments = new Enrollment[]
            {
            new Enrollment{studentID=1,courseID=1050,grade=Grade.A},
            new Enrollment{studentID=1,courseID=4022,grade=Grade.C},
            new Enrollment{studentID=1,courseID=4041,grade=Grade.B},
            new Enrollment{studentID=2,courseID=1045,grade=Grade.B},
            new Enrollment{studentID=2,courseID=3141,grade=Grade.F},
            new Enrollment{studentID=2,courseID=2021,grade=Grade.F},
            new Enrollment{studentID=3,courseID=1050},
            new Enrollment{studentID=3,courseID=4022,grade=Grade.F},
            };
            foreach (Enrollment e in enrollments)
            {
                academycontext.enrollments.Add(e);
            }
            academycontext.SaveChanges();

        }
    }

    public static class InfizyonInitializer {
        public static void inFizYonInitializeCore(inFizYonDbContext infizyoncontext) {
            infizyoncontext.Database.EnsureCreated();
            // Look for any phrases.
            if (infizyoncontext.phraseSet.Any())
            { return;   // DB has been seeded 
            }

            var labels = new Label[]
            { new Label{labelID="00 00 00", origin = Label.metaData.MasterFormat, phrases = new List<Phrase>() },
            };

            foreach (Label c in labels)
            { infizyoncontext.labelSet.Add(c);
            }

            var phrases = new Phrase[]
            {
                new Phrase{phrsENtxt = "Test datum", phrsTRtxt = "Test satırı", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "Carson", phrsTRtxt = "Carson", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "Alexander", phrsTRtxt = "İskender", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "Peggy", phrsTRtxt = "Peggy", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "Justice", phrsTRtxt = "Adalet", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "Laura", phrsTRtxt = "Laura", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "Norman", phrsTRtxt = "Norman", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "Istanbul Finance Centre - Atasehir", phrsTRtxt = "İstanbul Finans Merkezi - Ataşehir", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "SECTIONFORMAT CHECKLIST", phrsTRtxt = "ŞARTNAME BÖLÜM ŞABLONU", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "LEED CREDITS", phrsTRtxt = "LEED KREDİLERİ", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "Possible LEED credits are available through this section:", phrsTRtxt = "Bu bölüm için uygulanabilir LEED kredilerini listeleyiniz.", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "Information on recycled content.", phrsTRtxt = "Bu bölüm kapsamında kullanılacak geri dönüşebilir malzemeleri tanımlayınız", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "Information about carbon footprint and resource savings.", phrsTRtxt = "Yapılan imalatın karbon ayak izi, enerji etkinlik önlemleri, kaynak tasarrufu, suyun etkin kullanımı gibi konularla ilgili bilgi veriniz, ihtiyaçları tanımlayınız.", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "LEED credits and confirmation of alternative recycled material content according to performance, project and weather conditions.", phrsTRtxt = "LEED kredilerinin hangi durumda uygulanabileceğini açıklayınız. Alternatif malzemeler, geri dönüştürülmüş malzemelerin kullanımı, bunlar ile ilgili limitler, vb. bilgileri performans, proje gerekleri ve iklim koşullarına bağlı olarak irdeleyiniz.", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "GENERAL", phrsTRtxt = "GENEL", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "Include administrative and procedural requirements specific to the section.", phrsTRtxt = "Bu bölümde anlatılan imalata özgü idari şartları, işlem sırasını ve şartları içerir.", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "SUMMARY", phrsTRtxt = "ÖZET", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "A short statement designed to elaborate upon the Section title and permit the reader to quickly assess section content. Related requirements specified elsewhere are also listed. This Article is not intended to “scope” the section or imply trade jurisdiction; its use is highly recommended", phrsTRtxt = "Bu bölümde anlatılan imalatın içerik ve kapsamının anlaşılmasını sağlayacak kısa ve genel tanımlamalar yapılır. Başka dokümanlarda yer verilen şartlar burada da kısaca listelenir. Bu bölümün amacı imalat kapsamını belirmek ya da ticari bir yönlendirme yapmak değildir; bu maddenin mutlaka kullanılması tavsiye edilir.", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "Work Results", phrsTRtxt = "İmalat Çıktıları", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "The result of the products and their installation; work or operations, and the effort required to install or execute the work. The Article should include a brief description, or a list of what is Left behind when the work is complete. This Article should not list procedures, process, preparatory work, accessories, individual components, secondary products, or final adjusting and cleaning.", phrsTRtxt = "Ürünlerin ve bunların kurulması neticesinde ulaşılan sonuç ile işin gerçekleştirilmesi için gösterilmesi gerekli çaba, çalışma süreci, iş ve işlemleri anlatın. Bu madde, iş tamamlandığında ortaya ne çıkacağını anlatmalıdır. Bu madde işlem sırası ve detaylarını, süreçleri, hazırlık çalışmalarını, aksesuarları, özel bileşenleri, ikincil ürünleri, son ayarlamaları ve temizlik işlerini içermemelidir.", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "Related work specified in other sections", phrsTRtxt = "Diğer Bölümlerde Tanımlanan Bağlantılı İmalatlar", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "List other sections dealing with work specified in this section. Listing should be limited to other sections with specific information that the reader might expect to find in this section and to those actually referenced within the text of this section. For example, if hardware for aluminum entrances is specified in the aluminum entrance section, a cross-reference would be appropriate in the finish hardware section.", phrsTRtxt = "Bu bölümde tanımlanan işler ile doğrudan ilgisi olan diğer bölümleri listeleyiniz. Listeleme, okuyucunun bu bölüm içinde bulmayı tahmin edeceği fakat başka bir bölümün içeriği olan özel bilgiler ya da bu bölüm metni içinde atıfta bulunulan diğer bölümler ile sınırlandırılmalıdır.", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "Use and content of this Article is optional and does not affect project scope or application of the section. Neither its use nor exclusion substitute for the duty to coordinate the work. Hardware for aluminum entrances is specified in the aluminum entrance section, a cross-reference would be appropriate in the finish hardware section.", phrsTRtxt = "Bu maddenin kullanımı isteğe bağlıdır, içeriği değişebilir ve bunlar proje kapsamını veya bölümün uygulamasını etkilemez. Kullanılması ya kullanılmamasının işin koordinasyon görevi ile bir bağlantısı yoktur. Örneğin, Alüminyum girişlerin mekanizmaları “Aluminyum girişler” ile ilgili bölümde tanımlanır. Bu durumda varsa eğer, “bitirme donatıları” bölümüne bir referans verilebilir.", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "ADMINISTRATIVE REQUIREMENTS", phrsTRtxt = "YÖNETİMSEL GEREKLİLİKLER", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "Coordination", phrsTRtxt = "Koordinasyon", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "Describe requirements for special coordination specific to this section’s work results and related work. Take care not to duplicate provisions of Section 01 31 00 or to assume responsibility for project coordination", phrsTRtxt = "Bu Bölüme özel iş sonuçları ve bağlantılı işlerin koordinasyonu için gereken ihtiyaçları tanımlayınız. Bölüm 01 31 00’ın içeriğini tekrarlamamaya ve proje koordinasyonu sorumluluğunu üstlenmemeye özen gösteriniz.", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "Coordinate statements with Section 01 10 00- Project Management and Coordination.", phrsTRtxt = "Bölüm 01 10 00 ile içeriklerin birbirine uyumlu olmasına dikkat ediniz.", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "Commissioning Administration: Describe administrative requirements for commissioning. Refer to Part 3 and Part 4 for activities related to commissioning.", phrsTRtxt = "Kabul yönetimi: Kabul için gerekli idari gereklilikleri tanımlayınız. 3. ve 4.  Kısımdaki kabul ile ilgili maddelere referans veriniz.", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "Coordinate with Section 01 75 00- Starting and Adjusting, Section 01 79 00- Demonstration and Training, and Section 01 09 00- Commissioning.", phrsTRtxt = "Bölüm 01 75 00 (Devreye alma ve ayarlar), Bölüm 01 79 00 (Tatbikat ve Eğitim) ve Bölüm 01 90 00 (Kabul İşlemleri) ile içeriklerin birbirine uyumlu olmasına dikkat ediniz.", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "SUBMITTAL REQUIREMENTS", phrsTRtxt = "TESLİM EDİLMESİ GEREKEN BELGELER", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "Include requests for data to be furnished either before (quality assurance), during (quality control), or after construction (contract closeout).", phrsTRtxt = "Yapılacak imalatlar için; imalat öncesi (kalite güvencesi), sırası (kalite kontrol) ve sonrasında (sözleşme kapanışı) onaya sunacağı belgeleri içerir.", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "Specify administrative requirements, e.g., schedule, basic number of copies, and distribution in Section 01 3300- Submittal Procedures. Do not repeat those requirements here.", phrsTRtxt = "İdari talepleri (zamanlama, kaç kopya olacağı, dağıtım vb.)  Bölüm 01 33 00’de (Teslim işlemleri) belirtiniz. Bu talepleri burada tekrarlamayınız.", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "Submittals for Review", phrsTRtxt = "Kontrol Amaçlı Ara Teslimler", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "Include submittals that require active review by NE.", phrsTRtxt = "Kontrol mühendisi tarafından incelenmesi istenen teslim belgeleri", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "Product Data", phrsTRtxt = "Ürün Bilgileri", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "Describe specific types of product data to be submitted for review.", phrsTRtxt = "Kontrol amacı ile teslim edilmesi gereken özel ürünleri tarif ediniz.", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "Shop Drawings", phrsTRtxt = "İmalat Çizimleri", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "Describe specific types of shop drawings to be submitted for review and the information 264 to be included, as well as any special requirements or limitations not included in Division 01.", phrsTRtxt = "Kontrol amacı ile teslim edilmesi gereken özel imalat çizimlerini, gerekli diğer bilgileri ve Division 01’e dâhil edilmeyen tüm özel ihtiyaç ve sınırlamaları tarif ediniz.", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "Samples", phrsTRtxt = "Numune", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "Describe specific types of samples to be submitted for review. Also refer to Part 3, Field Samples, and Mockups for coordination.", phrsTRtxt = "Kontrol amacı ile teslim edilmesi gereken özel numuneleri tarif ediniz. Ayrıca, koordinasyon için Kısım 3’e (Alan Numuneleri ve Modelleri) bakınız", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "Deferred Design Submittals", phrsTRtxt = "Sonradan teslim edilecek dokümanlar", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "Deferred Design Submittals are submittals for Design-Build or Performance type Work. Results requiring design completion, detailing, structural, or other engineering calculations, and similar design efforts to be provided by the Contractor following the  initial permit review for the overall project.", phrsTRtxt = "Tasarım ve yapım süreçlerinin birlikte gerçekleştiği ya da Performansa bağlı işlerde teslim edilen belgelerdir. İmalatın yapılmasına izin vermek için gerekli olan ancak ilgili hesap ve dokümanları daha sonra da hazırlanabilecek proje hesap ve as-built çizimleridir.", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "These submittals are typically reviewed by the for compliance with codes or other statutory requirements, as well as compliance with the Contract Documents, before Execution, and after the start of construction, but may be reviewed by other entities, when used for Performance Verification type submittals reviewed by the A/E or Owner.", phrsTRtxt = "Bu dokümanlar genellikle ilgili yönetmelik, standart ve sözleşme hükümlerine uygunluk açısından uygulamaya geçilmeden önce kontrol edilir. Fakat işin mahiyetine bağlı olarak (örneğin hakedişe konu edilebilmesi için) daha sonra da işverenin sorumlu mimar / mühendisince ayrıca kontrol edilmesi ve performans testlerine tabi tutulması gerekebilir.", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "Use this Article to describe the specific types of submittals required, the information to be included, engineering or other credentials of the preparer as well as any special requirements of the reviewing entity, and any limitations specific to the work results that are not specified in Division 01 Sections.", phrsTRtxt = "Bu maddeyi, bir imalatın gerektiği gibi gerçekleştiğinden emin olmak için hazırlanması – sağlanması gereken mühendis ya da uzman görüşü ile kontrol teşkilatının gerekliği gördüğü diğer özel istekleri betimlemek için ve yalnızca, ilgili bilgi ve dokümantasyon gereği 01 numaralı Ciltte tanımlanmadığında kullanınız.", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "Do not contradict or duplicate general administrative procedures for deferred design submittals, which should be included in the Division 01 Section.", phrsTRtxt = "01. Ciltte yer verilen ve genel olarak sonradan teslim edilecek belge ve dokümanları anlatan kısım ile tekrar olmasından ya da çelişki oluşturmaktan kaçınınız.", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "Example: Structural systems such as roof trusses, structural attachments of equipment, food service hood exhaust systems, alarm systems, and fire suppression systems.", phrsTRtxt = "Örnekler: Performans bazlı zaman kısıtlı ilerleyen projelerde Betonarme kalıpların as-built tespit ve çizimleri, Çeşitli ekipmanların taşıyıcı strüktüre bağlantıları, Yangın alarmları, sprinkler sistemi, vb. bu imalatlar ile ilgili uygulamayı müteakip düzenlenmesi gereken dokümanlar mevcut olup, bunların ya imalat esnasında sahada yapılan tespitler üzerinden ya da imalat tamamlandıktan sonra yapılacak performans testlerine bağlı olarak hazırlanması ve teslim edilmesi gereklidir.", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "Submittals for Information", phrsTRtxt = "Bilgi amaçlı teslimatlar", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "Include requests for certain types of documentary data and affirmations of the manufacturer 290 or contractor. These quality assurance and quality control submittals should follow the submittal process, but may not require review or approval. Instructions may contain 292 requirements which are specified in Division 01. ", phrsTRtxt = "Malzeme üreticisi veya müteahhitten talep edilen bildirimler ve belgeli bilgilerin açıklamalarıdır. Bu kalite güvence ve kalite kontrol belgeleri belge teslim sürecini takip etmelidir, fakat inceleme ya da onay gerekli değildir. Talimatlar Division 01’deki gereksinimleri içerebilir. ", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "Procedural requirements of these items should be addressed in Section 01 40 00- Quality Requirements.", phrsTRtxt = "Bu item’lerin uygulama yöntemleri Bölüm 01 40 00’de ele alınmalıdır.", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "Certificates", phrsTRtxt = "Sertifikalar", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "Include statements to certify compliance with certain requirements. Size and tolerance variations of units which exceed standard tested units may require additional certificates. Include statements to certify compliance with product specified requirements", phrsTRtxt = "İmalatın niteliğine uygun ifadeler içermelidir. Standart testlerde belirlenen boyut ve tolerans değişimlerini aşan birimler için ek sertifika gereksinimleri oluşabilir. Ürünlerin çevresel şartlara uygunluk doğrulamaları da bu bölümde yer alır.", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "Design Data", phrsTRtxt = "Tasarım Bilgisi", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "When required for information only, list requirements for submittal of Contractor-produced design data such as structural or other calculations justifying a Contractor design.", phrsTRtxt = "(Yalnızca bilgi amaçlı talep edildiğinde) Yüklenici tarafından hazırlanmış, yüklenicinin tasarımına esas oluşturan strüktürel ve diğer hesapları içeren tasarım verileri ile ilgili teslim edilmesi gerekenleri listeleyiniz.", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "Test Reports", phrsTRtxt = "Test Raporları", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "List requirements for submittal of independent test report data indicating product performance of a Contractor design", phrsTRtxt = "Yüklenicinin tasarımı ya da ürün performansına ait bağımsız test rapor verileri ile ilgili teslim edilmesi gerekenleri listeleyiniz.", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "Manufacturer Instructions", phrsTRtxt = "Üretici Talimatları", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "List requirements for submittal of Manufacturer Instructions for installation, maintenance or operation of products", phrsTRtxt = "Üreticinin kurulum, bakım ve işletme talimatları ile ilgili teslim edilmesi gerekenleri listeleyiniz.", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "Manufacturer Reports", phrsTRtxt = "Üretici Saha Raporları", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "List requirements for submittal of Manufacturer Representative report data justifying product performance or a Contractor design, describing installation observation or other purposes.", phrsTRtxt = "Ürün performansı ya da yüklenici tasarımına ait kurulum gibi konuları tanımlayan üretici temsilcisi raporu verileri ile ilgili teslim edilmesi gerekenleri listeleyiniz.", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "Qualification Statements", phrsTRtxt = "Yeterlik Açıklamaları", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "List statements of qualifications for contractor-employed designers (for parts not designed by an architect/engineer or consultant), manufacturers, fabricators, welders, installers, and applicators of products and completed work.", phrsTRtxt = "Ürünlerin ve diğer işlerin yapılması için yüklenici için çalışacak tasarımcılar (mimar/mühendis ya da danışman tarafından tasarlanmamış parçalar için), üreticiler, imalatçılar, kaynakçılar, montajcılar ve uygulayıcılar ile ilgili istenilen nitelikleri listeleyiniz.", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "Source Quality Control Reports", phrsTRtxt = "Kalite Kontrol Onayları", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "List requirements for submittal of Source Quality Control report data justifying product 8 quality, performance, describing fabrication observation or other purposes. State requirements for procedures and methods for verifying performance or compliance with specified criteria before the item leaves the shop.", phrsTRtxt = "Ürün kalite performansını belgeleyen kalite kontrol verilerine ait, üretim ve diğer detayları içeren teslim edilmesi gereken belgeleri listeleyiniz. Ürün ya da işin teslim alınması esnasında; istenen kriterlere uyum veya performans doğrulama için kullanılacak yöntem ve metotları tanımlarınız", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "Sustainable Design Reports", phrsTRtxt = "Sürdürülebilir Tasarım Raporları", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "Special report requirements and instructions justifying product content, origin, or other attributes, for projectSet requiring special sustainability provisions, to meet LEEDTM, requirements, or other sustainable goals.", phrsTRtxt = "LEED ya da benzeri özel sürdürülebilirlik şartları gerektiren projeler için hazırlanması gereken; ürün kapsamı, kökeni ve diğer özelliklerine ait özel rapor ve talimatları içerir.", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "Commissioning Reports", phrsTRtxt = "Kabul Raporları", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "Submittals for Project Record", phrsTRtxt = "Proje Kayıt Belgeleri", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "List requirements for Project Record submittals that are specific to this Section. However, they should not control the means; methods, or techniques of the Contractor unless specified to do; Coordinate provisions with Section 01 78 00- closeout Submittals.", phrsTRtxt = "Bu bölüme özel proje kayıt belgelerini listeleyin. Aksi belirtilmedikçe, bu belgelerin yüklenicinin yöntem, metot ve tekniklerini kapsamamasına dikkat ediniz. Bölüm 01 78 00 - Bitirme Onayları (Teslim Belgeleri) ile içeriklerin birbirine uyumlu olmasına dikkat ediniz.", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "Bonds", phrsTRtxt = "Teminatlar", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "Include provisions for bonds provided by the Contractor to ensure performance of specified post-construction activities. List special provisions for extended or limited warranties, including those coordinated with requirements of other sections.", phrsTRtxt = "İnşaat bitiminden sonraki süreçteki hizmetlerin performansından emin olabilmek için uygulanacak provizyon ücretlerini tanımlayınız. Limitli ve uzatılmış garantiler için ne tür özel teminatlar talep edileceğini listeleyiniz. Diğer bölümlerde tanımlanan teminatlar ile koordinasyon sağlamaya yönelik ifadelere de yer veriniz. ", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "Warranties", phrsTRtxt = "Garanti Belgeleri", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "Include special provisions for extended or limited warranties, including requirements for products or work included in other sections.", phrsTRtxt = "Garanti şartları ve ne tür garanti belgeleri sunulması gerektiğini açıklayınız. Diğer bölümlerdeki ürün ve ya da işler ile koordinasyon sağlamaya yönelik ifadelere de yer veriniz. Nereye kadar – hangi işlerde teminat kesintisi yapılacak? Hangi işlerde ya da hangi seviyedeki kusurdan sonra değiştirme – yıkım – yeniden yapım talep edilecek?", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "Maintenance Contracts", phrsTRtxt = "Bakım Sözleşmeleri", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "Include provisions for maintenance service. Service agreements, involved with new construction, if not paid in advance, should be separate from the construction agreement to avoid delay of the final payment and holding the contract open for extended periods. Types of maintenance work are specified in Part 4.", phrsTRtxt = "Bakım hizmetleri koşulları açıklanır. Servis anlaşmaları, kesin hesapta sorun çıkmaması ve sözleşmenin devam eden süreçte açık kalmaması için; eğer avansta ödeme kapsamına alınmadıysa inşaat sözleşmesinden bağımsız tutulmalıdır. Bakım çalışmaları çeşitleri Kısım 4’te detaylandırılmıştır.", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "Coordinate with Section 01 7819- Maintenance Contracts.", phrsTRtxt = "Bölüm  01 78 19- Bakım Sözleşmeleri ile koordine ediniz.", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "Operation and Maintenance Data", phrsTRtxt = "Kullanım ve Bakım Talimatı", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "Include requirements for Operation and Maintenance data for Owner’s use in facility operations, maintenance and re-commissioning, if required. May include drawings, product manuals, specially written procedural guides, standard or customized software backups, sequences of operations, parts lists, contact information for suppliers and service agents, etc.", phrsTRtxt = "Kullanıcı için gerekli kullanım ve bakım talimatlarına ne şekilde ulaşılacağını anlatınız. Gerektiğinde bu madde altında ayrıntılı olarak açıklayınız. Bu referans ve dokümanlar, çizimleri – projeleri, ürün kullanım kılavuzlarını, teçhizat – donanım üzerindeki kullanım – emniyet talimatlarını, bakım – kontrol – testler – (yeniden) kabul gereklerini – ihtiyaçlarını içerebilir. Paket muhteviyatı, yazılım, yazılım yedekleri ve yedek alma prosedürü, iş – işlem sırası, (yedek) parça listeleri, tedarikçilerin iletişim - irtibat bilgileri, bakım hizmetinden sorumlu kuruluşların listesi gibi bilgiler eklenebilir.   ", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "Coordinate with Section 01 7823- Operation and Maintenance Data.", phrsTRtxt = "Bölüm  01 78 23 - İşletme ve Bakım Verileri ile koordine ediniz.", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "Record Documentation", phrsTRtxt = "Kayıt Dokümanları", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "Include requirements for various types of Record Documentation as appropriate to the work results of the section. May include copies of final approved shop drawings, coordination drawings, record specifications, record submittals and samples, record copies of software, including custom analysis.", phrsTRtxt = "Yapılan işin sonucu ile ilgili kayıt dokümanlarına yönelik beklenti ve ihtiyaçları listeleyiniz. Örneğin “Yapıldığı gibi (as-built)” projeler, onaylanmış malzeme uygulama (shop drawing) paftaları, anahtar planlar, kesit ve görünüşler, koordinasyon çizimleri, mühendislik – mimari süperpoze çalışmaları, BIM modeli, numuneler, test ve muayene sonuçları, gerekli yazılımlar ve yedekleri, özel analizler vb. ", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "Coordinate with Section 01 7839- Project Record Documents.", phrsTRtxt = "Bölüm  01 78 39 – Proje Kayıt Dokümanları ile koordine ediniz.", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "Sustainable Design Documentation", phrsTRtxt = "Sürdürülebilir Tasarım Dokümanları", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "Include requirements for Sustainable Design Documentation generated by the Contractor during construction.", phrsTRtxt = "Yüklenici tarafından sürdürülebilir tasarım amaçlı hazırlanması gerekli dokümanları burada betimleyiniz.", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "Commissioning Documentation", phrsTRtxt = "Kabul Dokümantasyonu", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "Include requirements for Commissioning Documentation generated by the Contractor or Commissioning Authority during construction.", phrsTRtxt = "Yüklenici hakedişlerine taban teşkil etmek üzere Kısmi kabul – Tam kabul ve garanti sürecini başlatmak üzere Geçici kabul - Nihai kabul için istenen dokümantasyonu burada tanımlayınız. Hangi dokümanın yüklenici tarafından hangi dokümanın kabul komisyonu (otoritesi) tarafından hazırlanması gerektiğini belirtiniz. ", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "Coordinate with Section 01 91 00 - Commissioning.", phrsTRtxt = "Bölüm  01 91 00 – Kabul Prosedürleri ile koordine ediniz.", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "REFERENCES", phrsTRtxt = "REFERANSLAR", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "Abbreviations and Acronyms", phrsTRtxt = "Kısaltma ve Akronimler", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "List the full name of abbreviated terms used in this Section.", phrsTRtxt = "Bu bölümde kullanılan kısaltmaların açılımlarını listeleyiniz", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "Definitions", phrsTRtxt = "Tanımlar", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "Define unusual terms used in this Section which are not explained in the Contract Documents or terms that are used in unique ways not included in standard references.", phrsTRtxt = "Sözleşme içeriğinde açıklanmayan ve referans gösterilen standartlarda yer almayan olağandışı tanımlar yer alır.", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "Reference Standards", phrsTRtxt = "Referans gösterilen standartlar:", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "List full title and designation of reference standards included elsewhere in this section. This Article does not require compliance with standards, but is merely a listing of those used. If compliance with standards is required, insert statements in the appropriate place in the Section. Review cited standards carefully to determine that conflicting requirements are not specified.", phrsTRtxt = "Referans gösterilen standartlar, isimleri ve varsa kodları ile birlikte listelenir. Bu madde standartlar ile uyumluluk gerektirmez, yalnızca kullanılmış olanların bir listesidir. Standartlar ile uygunluk aranması durumunda Bölümün uygun bir yerinde bunu belirtiniz. Çelişen talepleri tespit etmek için işaret edilen standartları dikkatle inceleyiniz.", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "Comply with the recommendations of the issuing organizations for referencing a particular standard. Include standards such as those of TSE and applicable regulations", phrsTRtxt = "Bir standardı referans gösterirken standardı yayınlayan kurumun önerilerine uyunuz. TSE gibi yürürlükte bulunan standartları kullanınız.", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "The general requirements indicated in Section 01 42 00- References may establish the edition date of standards not otherwise indicated. Division 01 may include full names and addresses of the organizations whose standards are referenced throughout the entire project manual.", phrsTRtxt = "01 42 00 (referanslar) bölümünde aksi belirtilmediği sürece en son yayınlanan standartları dikkate alınız. Division 01’de standartları referans alınmış kurumların adları ve adresleri listelenebilir.", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "PRODUCTS", phrsTRtxt = "ÜRÜNLER", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "Include information about systems, materials, manufactured units, equipment, components, and accessories; include proportioning, fabrication, finishing, and other requirements that must be accomplished prior to installation or incorporation. This Part may also include products for which installation is specified under other Sections. This Part may also include software used in control systems.", phrsTRtxt = "Sistemler, malzeme, imalatlar, donanım, bileşenler ve aksesuarlar ile ilgili bilgi verin. Montaj ya da birleşim öncesi gözetilmesi gereken oranlar, imalat süreci ve diğer gereksinimler ile ilgili hususları dâhil edin. Bu kısımda montajı ile ilgili ölçütler diğer bölümlerde tanımlanmış imalatlara da yer verilebilir. Bu bölüm, ilgili imalatla ilişkin kontrol sistemleri ve otomasyon için gerekli yazılımları da içerebilir.", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "Product characteristics may be specified using any of several specifying methods, including:", phrsTRtxt = "Ürün karakteristikleri değişik yöntemler ile örneğin aşağıdaki metotlardan biri ile tanımlanabilir (aynı anda birden fazla yöntemi kullanmamaya özen gösteriniz)", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "Performance Specifying Method: Specify the end result without unnecessarily prescribing the method for achieving the end result; include criteria for determining success, such as test methods; the criteria by which the performance will be judged, and the method by which it can be verified.", phrsTRtxt = "Performans tanımlama: Sonuca ulaşmak için kullanılması gereken metodu betimlemekten kaçınmak sureti ile sadece sonuç ürünü anlatın. İşin Kabul edilebilmesi için öngörülen başarı kriterlerini, örneğin; performansın değerlendirilmesi için gerekli test metotları ve bunların sağlaması ile ilgili metodu betimleyiniz.", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "Reference Standard Specifying Method:", phrsTRtxt = "Referans standart belirtme metodu:", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "Require compliance with an established reference standards explicitly identified; the text of the standard should not be included in the section", phrsTRtxt = "Burada TSE, ASTM vb. Standartlar değil, konu ile ilgili bir kurumun bir standart uygulama kılavuzu varsa buna yapılacak atıf – uygunluk tariflenmektedir. Ilgili kılavuz / dokümanı referans gösteriniz, kopyala yapıştır yapmayınız.", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "Descriptive Specifying Method: Describe what is necessary in words. Specify properties of materials without using proprietary properties. Different characteristics may be specified by different methods. Do not use more than one specifying method for a particular characteristic, due to the potential for conflict or contradiction. Some categories of characteristics that are commonly specified include:", phrsTRtxt = "İşi tarif etmek: Gerekenleri kelime kelime anlatınız. Malzemelerin özelliklerini, imalata ait özellikleri tanımlamaktan kaçınarak veriniz. Farklı karakteristikler farklı metotlarla tanımlanabilir fakat belli bir karakteristiği farklı metotlar ile tanımlamaktan kaçınınız. Bu çelişkili ifadeler ve karışıklığa sebebiyet verebilir. Genellikle yer verilen bazı karakteristikler aşağıdakilerdir (tam liste için OmniClass Tablo 49’dan faydalanınız)", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "Regulatory requirements, such as those mandated by building codes.", phrsTRtxt = "Yönetmelik ve mevzuat gerekleri", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "Shape, size, and mass (weight).", phrsTRtxt = "Şekil, boyut ve kütle (ağırlık) bilgileri", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "Composition and appearance.", phrsTRtxt = "Kompozisyon ve görünüm", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "Operational Characteristics, including compatibility with other systems. (Example: EMS/BAS). Durability, strength, and compatibility with other materials.", phrsTRtxt = "(birlikte) Çalışma karakteristikleri (diğer sistemler ile uyumluluk). Sağlamlık, Dayanıklılık ve diğer malzemeler ile uyumlu olma (reaksiyon vb. Etkileşime girmeme)", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "Temperature-, heat-, and fire-related characteristics.", phrsTRtxt = "Sıcaklık, ısı ve yangın ile ilgili özellikler.", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "Energy and electrical characteristics, inputs, and outputs.", phrsTRtxt = "Enerji ve elektrik ile ilgili özellikler (anma gücü, güç çıkışı, vb.).", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "Acoustical characteristics.", phrsTRtxt = "Akustik nitelikler", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "Installation-related characteristics, such as ability to pass through existing openings of limited size.", phrsTRtxt = "Montaj ile ilgili gereksinimler (örneğin, kısıtlı açıklıklardan geçme – geçirilebilme, vs.)", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "RELATED PRODUCTS", phrsTRtxt = "Bağlantılı Imalatlar", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "List products supplied by other sources. Describe products to be furnished by the Owner that are to be installed as part of this Work Result. Include existing products that must be reinstalled, modified, matched, or connected to.", phrsTRtxt = "Diğer kaynaklardan temin edilen ürünleri listeleyiniz. Bu iş kaleminin bir parçası olarak müşteri tarafından hazır edilmesi gereken ürünler hakkında verilen bilgilere referans verin. Bu esnada, tekrar monte edilmesi, değişiklik yapılması (modifikasyon), uyması ya da bağlantı kurulması gereken mevcut ürün ve bileşenleri dâhil edin.", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "Products procured by but, not installed by the contractor", phrsTRtxt = "Yüklenici Tarafından Sağlanan Fakat Kurulumu Yapılmayan İmalatlar", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "Products procured by the client and installed by the contractor", phrsTRtxt = "Mal Sahibi Tarafından Sağlanan, Yüklenici Tarafından Kurulumu Yapılan İmalatlar", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "New Products: List new products to be furnished or supplied by Owner.", phrsTRtxt = "Yeni ürünler: Müşteri tarafından sağlanacak – hazır edilecek yeni ürünleri listeleyiniz.", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "List characteristics in sufficient detail for the installer to determine the extent of the work and requirements for connection, coordination, or compatibility with other products. If general provisions relating to Owner-furnished products are included elsewhere, such as in Division 01, it is appropriate to reference those provisions here.", phrsTRtxt = "Bu paragrafta tanımlanacak özellikler, işi üstlenenin, iş kapsamını ve gereklerini tam olarak anlamasına yardımcı olacak düzeyde olmalıdır. Bu bağlamda nasıl bir koordinasyon sağlanması gerektiği, ne tür bağlantıların yapılacağı, ve diğer ürünler ile uyumluluk konuları açıkça tanımlanmalıdır. Eğer mal-sahibi, müşteri – işveren tarafından sağlanan ürünler ile ilgili şartlar ayrı bir yerde tanımlanıyorsa, bu bölüme referans veriniz.", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "SOURCE", phrsTRtxt = "KAYNAKLAR", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "Include statements related to how the Contractor should choose among the indicated sources. Reference any other provisions that affect this issue.", phrsTRtxt = "Tanımlanan kaynakları Yüklenicinin hangi yöntemle ve ne şekilde seçmesi gerektiği ile ilgili bilgi veriniz. Bu konudaki diğer hükümlere referans veriniz.", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "Product Options", phrsTRtxt = "Ürün opsiyonları (seçenekleri)", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "Substitution Limitations", phrsTRtxt = "Alternatifler ile ilgili kısıtlamalar.", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "Source Qualifications", phrsTRtxt = "Kaynak – tedarik zinciri nitelikleri, gerekleri", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "Source quality control", phrsTRtxt = "Kaynak (Malzeme, Bileşen, Ekipman, Parça, vb.) kalite kontrolü", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "Source Testing and Inspections Agency Qualifications", phrsTRtxt = "Tedarikçi nitelikleri (sertifika ve belgeler)", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "Source Testing and Inspections", phrsTRtxt = "Test, gözlem ve muayene yöntemleri", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "DESCRIPTION/PERFORMANCE", phrsTRtxt = "TANIM / PERFORMANS GEREKLERI", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "[SYSTEM] / [ASSEMBLIES] / [MANUFACTURED UNITS] / [FABRICATED UNITS] / [EQUIPMENT] / [COMPONENTS]", phrsTRtxt = "SISTEM / BAĞLANTILAR / yerinde imalatlar / atölye – fabrika imalatları / EKIPMAN / BILEŞENLER", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "Assembly/ Fabrication", phrsTRtxt = "İmalat ve Montaj detayı", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "[Manufacturing/Fabrication] Tolerances", phrsTRtxt = "Toleranslar", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "Finishes", phrsTRtxt = "Bitirmeler (Yüzey işlemleri)", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "MATERIALS", phrsTRtxt = "Malzemeler", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "Extra Stock", phrsTRtxt = "Ek stok ihtiyacı", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "Maintenance Materials and Spare Parts", phrsTRtxt = "Bakım malzemeleri ve yedek parçalar", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "Tools", phrsTRtxt = "Araç - gereç", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "MIXES", phrsTRtxt = "Karışımlar", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "ACCESSORIES", phrsTRtxt = "Donatılar (AksesuarLAR)", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "DELIVERY, STORAGE AND HANDLING", phrsTRtxt = "TESLIMAT, SAKLAMA VE TAŞINMA KOŞULLARI", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "Delivery Requirements", phrsTRtxt = "Teslimat gereksinimleri", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "Packing, Shipping, Handiing, and Unloading", phrsTRtxt = "Paketleme, nakliye, yükleme, indirme - boşaltma", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "Acceptance at Site", phrsTRtxt = "Sahada Kabul işlemleri (süreci)", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "Storage and Protection", phrsTRtxt = "Saklama – istifleme ve koruma", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "EXECUTION", phrsTRtxt = "UYGULAMA", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "INSTALLERS", phrsTRtxt = "Montaj ekibi", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "Installer Qualifications", phrsTRtxt = "Montaj ekibi (taşeronu) aranan nitelikleri", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "EXAMINATION", phrsTRtxt = "MUAYENE", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "SITE CONDITIONS", phrsTRtxt = "SAHA KOŞULLARI", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "Existing Site Conditions", phrsTRtxt = "Mevcut saha koşulları", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "Environmental Limitations", phrsTRtxt = "Çevresel kısıtlar", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "PREPARATION", phrsTRtxt = "HAZIRLIK", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "Protection of Surroundings", phrsTRtxt = "Çevre güvenliği", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "Surface Preparation", phrsTRtxt = "Yüzey hazırlığı", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "Demolition/Removal", phrsTRtxt = "Çöplerin uzaklaştırılması", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "FIELD SAMPLES/MOCKUPS", phrsTRtxt = "MALZEME ÖRNEKLERI / MODELLER", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "LOCATION SCHEDULES", phrsTRtxt = "MAHAL LISTESI VE ANAHTAR PLANLAR", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "INSTALLATION / APPLICATION / ERECTION / PLACEMENT", phrsTRtxt = "HER TÜRLÜ INŞAAT VE MONTAJ IŞI BU KISIMDA ANLATILACAKTIR.", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "REPAIR / RESTORATION / REINSTALLATION", phrsTRtxt = "TAMİR / RESTORASYON / YENİDEN MONTAJ", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "[ACTIVITY]", phrsTRtxt = "[EYLEM-İŞLEM]", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "[Special Techniques]", phrsTRtxt = "[Özel teknikler]", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "İnterface with Other Work", phrsTRtxt = "Diğer işler ile bağıntı ve ilişki", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "İnstallation Sequences", phrsTRtxt = "Montaj sırası", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "[Installation] Tolerances", phrsTRtxt = "[Montaj] Toleransları", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "Adjusting", phrsTRtxt = "Ayarlar", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "CONSTRUCTION WASTE MANAGEMENT", phrsTRtxt = "INŞAAT ATIK YÖNETIMI", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "Packaging Waste Management and Disposal", phrsTRtxt = "Çöplerin toplanması paketlenmesi ve atılması", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "SYSTEMS INTEGRATION", phrsTRtxt = "SISTEMIN BÜTÜNLEŞTIRILMESI", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "Sequence of Operation", phrsTRtxt = "İşlem sırası", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "SYSTEMS STARTUP", phrsTRtxt = "SISTEMIN BAŞLATILMASI", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "Site Quality Control", phrsTRtxt = "Kalite kontrolü", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "Settings, adjustments", phrsTRtxt = "Ayarlar, ayarlamalar", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "Site Testing and İnspections Agency Qualifıcations", phrsTRtxt = "Saha testleri ile görevlendirilecek kurum nitelikleri", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "Site Testing and İnspections", phrsTRtxt = "Saha testleri ve gözlemler", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "Manufacturer Services", phrsTRtxt = "Üretici tarafından sağlanması beklenen hizmetler", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "CLOSEOUT ACTIVITIES", phrsTRtxt = "TAMAMLAMA IŞLEMLERI", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "Cleaning", phrsTRtxt = "Temizlik", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "Protection", phrsTRtxt = "Koruma", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "Demonstration", phrsTRtxt = "Sunum, fonksiyonları tanıtma", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "Training", phrsTRtxt = "Kullanıcı eğitimi", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "UTILIZATION", phrsTRtxt = "IŞLETMEYE ALMA (Bu bölüm fm – tesis yönetimi için gerekli bilgileri içerir, sadece 4.1 ile sınırlı tutalabilir)", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "COMMISSIONING", phrsTRtxt = "Kabul işlemleri", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "OPERATION AND USE", phrsTRtxt = "Çalıştırma ve Kullanma", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "Operational and Use Requirements", phrsTRtxt = "İşletme ve kullanım için gerekler", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "Operation and Use İnstructions", phrsTRtxt = "İşletme ve kullanım kılavuzu", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "PROVISIONING", phrsTRtxt = "DEVREYE ALMA ", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "MAINTENANCE", phrsTRtxt = "BAKIM", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "Maintenance Schedules", phrsTRtxt = "Bakım cetveli", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "Maintenance Service", phrsTRtxt = "Bakım hizmeti", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "Preventative Maintenance", phrsTRtxt = "Koruyucu bakım", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "Routine Maintenance", phrsTRtxt = "Rutin bakım", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "General Maintenance", phrsTRtxt = "Genel bakım", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "ONGOING VERIFICATIONS", phrsTRtxt = "Kalite ve performans takibi", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "Warranty and Correction Period Inspections", phrsTRtxt = "Garanti ve düzeltme süreci gözlemleri", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "Regulatory Inspections", phrsTRtxt = "Düzenli muayeneler", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "Deferred Testing and Inspections", phrsTRtxt = "Gecikmeli testler (belli bir süreden sonra yapılması gereken) ve gözlemler", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "Periodic Verifications", phrsTRtxt = "Periyodik kontrol", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "EVALUATION AND ASSESSMENT", phrsTRtxt = "ÖLÇME VE DEĞERLENDIRME", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "REPAIRS", phrsTRtxt = "TAMIR, ONARIMLAR", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "FACILITY INFORMATION MANAGEMENT", phrsTRtxt = "TESIS BILGI YÖNETIMI", phrsReliance =100, phrsComp =100},
                new Phrase{phrsENtxt = "Record Documents Maintenance Reports", phrsTRtxt = "Bakım raporları ve dokümantasyon", phrsReliance =100, phrsComp =100}
            };

            foreach (Phrase p in phrases)
            { infizyoncontext.phraseSet.Add(p);
            }

            var people = new PartyReal[]
            {
            new PartyReal{ciqPrname = phrases.Single(s => s.phrsENtxt == "Carson").phrsID, ciqPrsurname = phrases.Single(s => s.phrsENtxt == "Alexander").phrsID, ciqPrssec="20152017901"},
            new PartyReal{ciqPrname = phrases.Single(s => s.phrsENtxt == "Laura").phrsID, ciqPrsurname = phrases.Single(s => s.phrsENtxt == "Norman").phrsID, ciqPrssec="20152017902"},
            new PartyReal{ciqPrname = phrases.Single(s => s.phrsENtxt == "Peggy").phrsID, ciqPrsurname = phrases.Single(s => s.phrsENtxt == "Justice").phrsID, ciqPrssec="20152017903"},
            };
            foreach (PartyReal p in people)
            {
                infizyoncontext.peopleSet.Add(p);
            }
            infizyoncontext.SaveChanges();

            //Insert sample MasterFormat Section
            var MFSections = new InMF[]
            { new InMF{ secNr="00 00 00", sectionID = phrases.Single(s => s.phrsTRtxt == "Test satırı").phrsID}
            };

            foreach (InMF m in MFSections)
            { infizyoncontext.inMFSet.Add(m);
            }
            infizyoncontext.SaveChanges();

            //Insert default Project
            var inProjects = new InProject[]
            { new InProject{ prjCode = "IFC_HGYO", prjPlace = phrases.Single(n => n.phrsENtxt == "Istanbul Finance Centre - Atasehir").phrsID,  prjID = phrases.Single(n => n.phrsTRtxt == "İstanbul Finans Merkezi - Ataşehir").phrsID}
            };

            foreach(InProject p in inProjects)
            { infizyoncontext.projectSet.Add(p);
            }
            infizyoncontext.SaveChanges();

            ////Insert/initialize default Package
            //var newPackage = new List<Package>
            //{
            //    new Package{},
            //};

            //foreach (Package pa in newPackage)
            //{
            //    infizyoncontext.packageSet.Add(pa);
            //}
            //infizyoncontext.SaveChanges();

            //Insert default Comment
            var hasComment = new Comment[]
            { new Comment{ commentTxt="Default comment", commented = phrases.Single(c => c.phrsENtxt == "Test datum")}
            };

            foreach (Comment t in hasComment)
            { infizyoncontext.commentSet.Add(t);
            }

            infizyoncontext.SaveChanges();
        }
    }
    public static class M3PInitializer
    {

    }

}