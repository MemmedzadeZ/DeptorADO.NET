// See https://aka.ms/new-console-template for more information



using DeptorADO.NET.Configurations;
using DeptorADO.NET.Contexts;
using DeptorADO.NET.Models;
using System.Diagnostics.Metrics;


List<Deptor> db = new List<Deptor>();   

//2) rhyta.com ve ya dayrep.com domenlerinde emaili olan borclulari cixartmag

var Task2 = db.Where(d => d.Email.EndsWith("rhyta.com") || d.Email.EndsWith("dayrep.com"))
    .ToList();

//	4) Borcu 5000 - den cox olmayan borclularic cixartmag

var Task4 = db.Where(d => d.Debt <= 5000);

//	5) Butov adi 18 simvoldan cox olan ve telefon nomresinde 2 ve ya 2-den cox 7 reqemi olan borclulari cixartmaq

var Task5 = db.Where(d => d.FullName.Length > 18 && (d.Phone.Contains('2') || d.Phone.Contains('7')));

//	7) Qishda anadan olan borclulari cixardmaq

var Task7 = db.Where(d => d.BirthDay.Month == 12 || (d.BirthDay.Month >= 1 && d.BirthDay.Month <= 2));

//	8) Borcu, umumi borclarin orta borcunnan cox olan borclulari cixarmaq ve evvel familyaya gore sonra ise meblegin azalmagina gore sortirovka etmek

var Task8 = db.Where(d => d.Debt > db.Average(x => x.Debt)).OrderBy(d => d.FullName).ThenByDescending(d => d.Debt);

//	9) Telefon nomresinde 8 olmayan borclularin yalniz familyasin, yashin ve umumi borcun meblegin cixarmaq

var Task9 = db.Where(d => d.Phone.Contains('8')).Select(d => new { d.FullName, Age = DateTime.Now.Year - d.BirthDay.Year, d.Debt });


//	13)borclulardan en coxu hansi ilde dogulubsa hemin ili cixartmaq

var Task13 = db.GroupBy(d => d.Address.Split(' ')[d.Address.Split(' ').Length - 1]);

//	14)Borcu en boyuk olan 5 borclunun siyahisini cixartmaq

var Task14 = db.OrderByDescending(d => d.Debt).Take(5);


//	15)Butun borcu olanlarin borcunu cemleyib umumi borcu cixartmaq

var Task15 = db.Sum(d => d.Debt);


//	16)2ci dunya muharibesin gormush borclularin siyahisi cixartmaq

var Task16 = db.Where(d => d.BirthDay.Year < 1941);

//	18)Nomresinde tekrar reqemler olmayan borclularin ve onlarin borcunun meblegin cixartmaq

var Task18 = db.Where(d => d.Phone.Distinct().Count() == d.Phone.Length && d.Debt > 0);


//	19)Tesevvur edek ki, butun borclari olanlar bugunden etibaren her ay 500 azn pul odeyecekler. Oz ad gunune kimi borcun oduyub qurtara bilenlerin siyahisin cixartmaq

var Task19 = db.Where(d => DateTime.Now < d.BirthDay.AddYears(50) && d.Debt > 0 && (DateTime.Now.Year - d.BirthDay.Year) % 5 == 0);

//	20)Adindaki ve familyasindaki herflerden "smile" sozunu yaza bileceyimiz borclularin siyahisini cixartmaq


var Task20 = db.Where(d => (d.FullName.ToLower().Count(c => "smile".Contains(c)) == 5)
    && (d.FullName.ToLower().Distinct().Count() == 5)
    && (d.FullName.ToLower().All(c => "smile".Contains(c)))
    );



