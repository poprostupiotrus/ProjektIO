using NUnit.Framework;
using projektIOv2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projektIOv2Tests
{
    public class DaneSpolekTests
    {
        [Test]
        public void ZnajdzSpolkePoNazwie_NazwaIstnieje()
        {
            var daneSpolek = new DaneSpolek();
            string existingName = "ALIOR";


            var result = daneSpolek.ZnajdzSpolkePoNazwie(existingName);


            Assert.That(result, Is.InstanceOf(typeof(Spolka)));
            Assert.That(result.Nazwa, Is.EqualTo(existingName));
            Assert.That(result, Is.Not.Null);
        }
        [Test]
        public void ZnajdzSpolkePoNazwie_NazwaNieIstnieje()
        {
            var daneSpolek = new DaneSpolek();
            string nonExistingName = "ALLLLIOR";

            var result = daneSpolek.ZnajdzSpolkePoNazwie(nonExistingName);

            Assert.That(result, Is.Null);
        }



    }
}
