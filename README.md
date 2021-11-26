# Rent A Car Project


<p><a href="https://docs.microsoft.com/en-us/dotnet/csharp/" rel="nofollow"><img src="https://camo.githubusercontent.com/dd433625a6e00049c26f08143705ff9e32d5da44f503f1be133664b11e37e34b/68747470733a2f2f696d672e736869656c64732e696f2f62616467652f432532332d3233393132303f7374796c653d666f722d7468652d6261646765266c6f676f3d632d7368617270266c6f676f436f6c6f723d7768697465" alt="C-Sharp" data-canonical-src="https://img.shields.io/badge/C%23-239120?style=for-the-badge&amp;logo=c-sharp&amp;logoColor=white" style="max-width:100%;"></a>
<a href="https://dotnet.microsoft.com/apps/aspnet" rel="nofollow"><img src="https://camo.githubusercontent.com/d2eedef86b5c7700ce36b271700d22a225ed80deb882f1bc627b0b1d3543dd3f/68747470733a2f2f696d672e736869656c64732e696f2f62616467652f4153502e4e45542d3543324439313f7374796c653d666f722d7468652d6261646765266c6f676f3d2e6e6574266c6f676f436f6c6f723d7768697465" alt="Asp-net" data-canonical-src="https://img.shields.io/badge/ASP.NET-5C2D91?style=for-the-badge&amp;logo=.net&amp;logoColor=white" style="max-width:100%;"></a>
<a href="https://www.microsoft.com/en-us/sql-server/sql-server-2019?rtc=2" rel="nofollow"><img src="https://camo.githubusercontent.com/4c4e18333e9f48e9f6f4190e08dee3957c75b531a2bb78e9bfe33cbdcf99cdd4/68747470733a2f2f696d672e736869656c64732e696f2f62616467652f4d5353514c2d3030343838303f7374796c653d666f722d7468652d6261646765266c6f676f3d6d6963726f736f66742d73716c2d736572766572266c6f676f436f6c6f723d7768697465" alt="MSSQL" data-canonical-src="https://img.shields.io/badge/MSSQL-004880?style=for-the-badge&amp;logo=microsoft-sql-server&amp;logoColor=white" style="max-width:100%;"></a>
<a href="https://docs.microsoft.com/en-us/ef/" rel="nofollow"><img src="https://camo.githubusercontent.com/1d5fe1015065a89592443eb419d5974655ffbe17c2d9a1e51c73bd0ad9a357ba/68747470733a2f2f696d672e736869656c64732e696f2f62616467652f456e746974792532304672616d65776f726b2d3030343838303f7374796c653d666f722d7468652d6261646765266c6f676f3d6e75676574266c6f676f436f6c6f723d7768697465" alt="Entity-Framework" data-canonical-src="https://img.shields.io/badge/Entity%20Framework-004880?style=for-the-badge&amp;logo=nuget&amp;logoColor=white" style="max-width:100%;"></a>
<a href="https://autofac.org/" rel="nofollow"><img src="https://camo.githubusercontent.com/660a4e0e53571f8f593a56df74573cb8f09777268a87305057363a9b38a3dd59/68747470733a2f2f696d672e736869656c64732e696f2f62616467652f4175746f6661632d3030343838303f7374796c653d666f722d7468652d6261646765266c6f676f3d6e75676574266c6f676f436f6c6f723d7768697465" alt="Autofac" data-canonical-src="https://img.shields.io/badge/Autofac-004880?style=for-the-badge&amp;logo=nuget&amp;logoColor=white" style="max-width:100%;"></a>
<a href="https://fluentvalidation.net/" rel="nofollow"><img src="https://camo.githubusercontent.com/6deba73d71845daec484b10b754dc0c648cdd13fb24480c38e52becf608f215f/68747470733a2f2f696d672e736869656c64732e696f2f62616467652f466c75656e7425323056616c69646174696f6e2d3030343838303f7374796c653d666f722d7468652d6261646765266c6f676f3d6e75676574266c6f676f436f6c6f723d7768697465" alt="Fluent-Validation" data-canonical-src="https://img.shields.io/badge/Fluent%20Validation-004880?style=for-the-badge&amp;logo=nuget&amp;logoColor=white" style="max-width:100%;"></a></p>

# Katmanlar
* ### Proje Business, DataAccess, Entities, ConsoleUI, Core, WebAPI olmak üzere 6 katmandan oluşmaktadır.

## Solution Explorer
![Solution Explorer](https://user-images.githubusercontent.com/66443194/143624386-61666ca8-2fd3-4b3d-b4a0-077a87c20e65.PNG)

# Business Katmanı
Business katmanında iş kodları yer alır.
Bu katmanda abstract(interface) ve concrete(class) klasörleri olmak üzere 2 ana klasörden oluşmaktadır. <br/>
![Business](https://user-images.githubusercontent.com/66443194/143625311-f7116d47-cfcf-45c6-82f7-0d356b708cc0.PNG)

# Business Katmanı Klasörleri
Abstract, Business, Business Aspects, Concrete, Constants, DependencyResolvers, Autofac, ValidationRules Klasörleri
![BusinessLayer](https://user-images.githubusercontent.com/66443194/143625323-21e06956-b0b2-40d0-a443-4d5f8a8b1da5.PNG) <br/>


# Core Katmanı
Bir framework katmanı olan Core Katmanı'nda DataAccess, Entities, Utilities olmak üzere 3 adet klasör bulunmaktadır.DataAccess klasörü DataAccess Katmanı ile ilgili nesneleri, Entities klasörü Entities katmanı ile ilgili nesneleri tutmak için oluşturulmuştur. Core katmanının .Net Core ile hiçbir bağlantısı yoktur.Oluşturulan core katmanında ortak kodlar tutulur. Core katmanı ile, kurumsal bir yapıda, alt yapı ekibi ilgilenir.
![CoreLayer](https://user-images.githubusercontent.com/66443194/143625313-73ced31f-f07d-42c8-995f-121a82178617.PNG) <br/>
![CoreAspect](https://user-images.githubusercontent.com/66443194/143625316-790db374-7bce-4aba-a2b9-700087ffad12.PNG) <br/>
![CoreUtilities](https://user-images.githubusercontent.com/66443194/143625318-ce8e90a4-fb64-4a25-915f-d06836231ca2.PNG) <br/>


# Data Access Katmanı
Veritabanı CRUD işlemleri gerçekleştirmek için oluşturulan Data Access Katmanı'nda Abstract ve Concrete olmak üzere iki adet klasör bulunmaktadır.Abstract klasörü soyut nesneleri, Concrete klasörü ise somut nesneleri tutmak için oluşturulmuştur. <br/>
![DataAccessLayer](https://user-images.githubusercontent.com/66443194/143625319-889044a4-1c60-49b2-b5f9-bc6294a18de3.PNG) <br/>


## Entities Katmanı

Veritabanı nesneleri için oluşturulmuş Entities Katmanı'nda Abstract ve Concrete olmak üzere iki adet klasör bulunmaktadır.Abstract klasörü soyut nesneleri, Concrete klasörü somut nesneleri tutmak için oluşturulmuştur. <br/>
![EntitiesLayer](https://user-images.githubusercontent.com/66443194/143625321-4a9a3b41-7ed3-4c32-8a41-71b0dbcb6f00.PNG)  <br/>

## UIConsole Katmanı
Kodların doğru çalıştığını görmek için kullandığımız katman test katmanı da diyebiliriz. <br/><br/>
![UIConsoleLayer](https://user-images.githubusercontent.com/76704724/115159792-8bc22c00-a09d-11eb-8265-31fdeede771c.PNG) <br/>


## WepAPI Katmanı
Tüm kodların birleşip web sayfasına yansıtıldığı katmandır <br/>
![WebApiLayer](https://user-images.githubusercontent.com/66443194/143625322-1c40ee6d-0c75-442a-a7b1-9f2bc36da472.PNG) <br/>

