using DynamicTranslateDemo.DB;
using DynamicTranslateDemo.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace DynamicTranslateDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LookupController : ControllerBase
    {
        private static string[] cultures = [];
        private readonly ILogger<LookupController> _logger;
        private readonly DummyDBContext _dBContext;


        public LookupController(ILogger<LookupController> logger, DummyDBContext dBContext)
        {
            _logger = logger;
            _dBContext = dBContext;

             //cultures = ["ar"];
            cultures = CultureInfo.GetCultures(CultureTypes.AllCultures).Select(x => x.TwoLetterISOLanguageName).ToArray();

            int selectedCulture = Random.Shared.Next(0, cultures.Length);
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(cultures[selectedCulture]);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = await _dBContext.MasterLookups
                                       .Include(x => x.ChildLookups)
                                       .Select(x => new MasterLookupDto
                                       {
                                           Id = x.Id,
                                           Name = x.Name,
                                           ChildLookups = x.ChildLookups
                                            .Select(y => new ChildLookupDto
                                            {
                                                Id = y.Id,
                                                Name = y.Name,
                                            }).ToArray()
                                       }).ToArrayAsync();


            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Post(MasterLookupDto dto)
        {
            (string, string)[] validationMessages = [("key1","dummy text"),
                                                    ("key2","Lookup Name Exists (duplication)"),
                                                    ("key3","you are not permitted to add lookups")];

            int selectedIndex = Random.Shared.Next(0, validationMessages.Length);

            var validationError = new BadResponseDto
            {
                key = validationMessages[selectedIndex].Item1,
                Message = validationMessages[selectedIndex].Item2
            };




            return BadRequest(validationError);
        }
    }
}