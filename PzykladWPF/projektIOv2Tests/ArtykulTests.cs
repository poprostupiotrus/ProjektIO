using NUnit.Framework;
using projektIOv2;

namespace projektIOv2Tests
{
    public class ArtykulTests
    {
        [Test]
        public void CompareTo_CzyDatyRowne()
        {
            var a1 = new Artykul() { Data = DateTime.MaxValue, Tresc = "abcd" };
            var a2 = new Artykul() { Data = DateTime.MaxValue, Tresc = "abcd" };

            int result = a1.CompareTo(a2);
            Assert.That(result, Is.EqualTo(0));
        }
        [Test]
        public void CompareTo_CzData1PozniejszaNizData2()
        {
            var a1 = new Artykul() { Data = DateTime.MaxValue, Tresc = "abcd" };
            var a2 = new Artykul() { Data = DateTime.MinValue, Tresc = "abcd" };

            int result = a1.CompareTo(a2);

            Assert.That(result, Is.EqualTo(1));
        }
        [Test]
        public void CompareTo_CzyData1WczesniejszaNizData2()
        {
            var a1 = new Artykul() { Data = DateTime.MinValue, Tresc = "abcd" };
            var a2 = new Artykul() { Data = DateTime.MaxValue, Tresc = "abcd" };

            int result = a1.CompareTo(a2);

            Assert.That(result, Is.EqualTo(-1));

        }
        //Positive
        [Test]
        public void isPositive_WartosciNieUjemne()
        {
            var a1 = new Artykul
            {
                bard = new Dictionary<string, double> { { "ALIOR", 1.0 }, { "DINOPL", 6.7 } },
                gpt = new Dictionary<string, double> { { "ALIOR", 3.0 }, { "DINOPL", 0 } }
            };
            bool result = a1.isPositive(new List<string> { "ALIOR", "DINOPL" });

            Assert.That(result, Is.True);
        }
        [Test]
        public void isPositive_JakasWartoscUjemna()
        {

            var artykul = new Artykul
            {
                bard = new Dictionary<string, double> { { "ALIOR", 1.0 }, { "DINOPL", -2.0 } },
                gpt = new Dictionary<string, double> { { "ALIOR", 3.0 }, { "DINOPL", 4.0 } }
            };


            bool result = artykul.isPositive(new List<string> { "ALIOR", "DINOPL" });


            Assert.That(result, Is.False);
        }

        //Negative
        [Test]
        public void isNegative_WartosciUjemne()
        {

            var artykul = new Artykul
            {
                bard = new Dictionary<string, double> { { "ALIOR", -1.0 }, { "DINOPL", -2.0 } },
                gpt = new Dictionary<string, double> { { "ALIOR", -3.0 }, { "DINOPL", -4.0 } }
            };


            bool result = artykul.isNegative(new List<string> { "ALIOR", "DINOPL" });


            Assert.That(result, Is.True);
        }

        [Test]
        public void isNegative_WartosciDodatnie()
        {

            var artykul = new Artykul
            {
                bard = new Dictionary<string, double> { { "ALIOR", 11.0 }, { "DINOPL", 1.0 } },
                gpt = new Dictionary<string, double> { { "ALIOR", 3.0 }, { "DINOPL", 14.0 } }
            };


            bool result = artykul.isNegative(new List<string> { "ALIOR", "DINOPL" });

            Assert.That(result, Is.True);

        }
        [Test]
        public void isNegative_WartosciMieszane()
        {

            var artykul = new Artykul
            {
                bard = new Dictionary<string, double> { { "ALIOR", 11.0 }, { "DINOPL", -1.0 } },
                gpt = new Dictionary<string, double> { { "ALIOR", -3.0 }, { "DINOPL", 0 } }
            };


            bool result = artykul.isNegative(new List<string> { "ALIOR", "DINOPL" });

            Assert.That(result, Is.True);

        }


    }
}
