using System;
using NUnit.Framework;
using System.Net.Http;
using System.Net.Http.Formatting;

namespace YTConvert.Test
{
    [TestFixture]
    public class APITests
    {
        public static Host host;
        public const string baseAddr = "http://localhost:8000/";
        public const string testURL = "https://www.youtube.com/watch?v=8XPKrR_g7Mw";
        AudioStreamRequest asRequest = new AudioStreamRequest() { Extension = "m4a", Filename = "Marth in Smash 4" };

        [Test]
        public void ConvertTest()
        {
            HttpClient client = new HttpClient();
            JsonMediaTypeFormatter jtf = new JsonMediaTypeFormatter();
            var res = client.PostAsync<string>(baseAddr + "api/convert", testURL, jtf).Result;
            Assert.IsTrue(res.IsSuccessStatusCode);
        }
        [Test]
        public void StreamTest()
        {
            HttpClient client = new HttpClient();
            JsonMediaTypeFormatter jtf = new JsonMediaTypeFormatter();
            var res = client.PostAsync<AudioStreamRequest>(baseAddr + "api/stream", asRequest, jtf).Result;
            Assert.IsTrue(res.IsSuccessStatusCode);
        }
    }
    [SetUpFixture]
    public class Config
    {
        [OneTimeSetUp]
        public void Setup()
        {
            APITests.host = new Host(APITests.baseAddr);
            APITests.host.Start();
        }
    }
}
