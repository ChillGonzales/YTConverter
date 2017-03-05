using System;
using NUnit.Framework;
using System.Net.Http;
using System.Net.Http.Formatting;

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
            JsonMediaTypeFormatter jtf = new JsonMediaTypeFormatter();
            var res = client.PostAsync<string>(baseAdddr + "api/convert", testURL, jtf).Result;
            Assert.IsTrue(res.IsSuccessStatusCode);
        }
    }
}
