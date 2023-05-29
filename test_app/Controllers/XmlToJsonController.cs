using System.Net.Http;
using System.Xml;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

[ApiController]
[Route("api/[controller]")]
public class XmlToJsonController : ControllerBase
{
    private readonly IHttpClientFactory _httpClientFactory;

    public XmlToJsonController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var url = "https://www.nationallottery.co.za/xmlfeed/dailylotto.xml";

        using (var client = _httpClientFactory.CreateClient())
        {
            var response = await client.GetAsync(url);
            if (!response.IsSuccessStatusCode)
            {
                return BadRequest("Unable to retrieve the XML data from the specified URL.");
            }

            var xmlContent = await response.Content.ReadAsStringAsync();

            try
            {
                var xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(xmlContent);

                var json = JsonConvert.SerializeXmlNode(xmlDoc);

                return Ok(json);
            }
            catch (XmlException)
            {
                return BadRequest("The XML data is invalid.");
            }
        }
    }
    [HttpGet("{type}")]
    public async Task<IActionResult> Get(string type)
    {
        var url = "https://www.nationallottery.co.za/xmlfeed/"+ type + ".xml";

        using (var client = _httpClientFactory.CreateClient())
        {
            var response = await client.GetAsync(url);
            if (!response.IsSuccessStatusCode)
            {
                return BadRequest("Unable to retrieve the XML data from the specified URL.");
            }

            var xmlContent = await response.Content.ReadAsStringAsync();

            try
            {
                var xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(xmlContent);

                var json = JsonConvert.SerializeXmlNode(xmlDoc);

                return Ok(json);
            }
            catch (XmlException)
            {
                return BadRequest("The XML data is invalid.");
            }
        }
    }
}