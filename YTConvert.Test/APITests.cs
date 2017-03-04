using System;
using NUnit.Framework;

namespace YTConvert.Test
{
    [TestFixture]
    public class APITests
    {
        Host host;
        const string baseAdddr = "http://localhost:8000/";

        [OneTimeSetUp]
        private void Setup()
        {
            host = new Host(baseAdddr);
            host.Start();
        }
        [Test]
        public void ConvertTest()
        {

        }
    }
}
