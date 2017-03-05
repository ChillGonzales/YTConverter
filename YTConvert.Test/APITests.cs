using System;
using NUnit.Framework;
using System.Net.Http;

namespace YTConvert.Test
{
    [TestFixture]
    public class APITests
    {
        Host host;
        const string baseAdddr = "http://localhost:8000/";
        const string testURL = "https://www.youtube.com/watch?v=8XPKrR_g7Mw";

        [Test]
        public void ConvertTest()
        {
            host = new Host(baseAdddr);
            host.Start();
            HttpClient client = new HttpClient();
            var res = client.PostAsync(baseAdddr + "api/convert", new StringContent(testURL)).Result;
            Assert.IsTrue(res.IsSuccessStatusCode);
        }
    }
}
