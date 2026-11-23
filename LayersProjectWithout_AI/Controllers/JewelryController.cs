using Microsoft.AspNetCore.Mvc;
using ibll;
using Microsoft.AspNetCore.Http.HttpResults;


namespace LayersProjectWithout_AI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JewelryController : Controller
    {
        private readonly IJewelry _jewelrybll;

        public JewelryController(IJewelry jewelrybll)
        {
            _jewelrybll = jewelrybll;
        }

        [HttpGet]
        public  async Task<ActionResult<List<dto.Jewelrydto>>> GetAllJewelry()
        {
            var list= await _jewelrybll.GetAllJewelryAsync();
            return Ok(list);
        }

        [HttpGet("{jewelryCode}")]
        public async Task<ActionResult<dto.Jewelrydto>> GetJewelryById(int jewelryCode)
        {
            var blljewelry = await _jewelrybll.GetJewelryByIdAsync(jewelryCode);
            if (blljewelry == null)
                return NotFound();
            return Ok(blljewelry);
        }

        [HttpPost]
        public async Task<ActionResult> AddJewelry(dto.Jewelrydto jewelry)
        {
            await _jewelrybll.AddJewelryAsync(jewelry);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> UpdateJewelry(dto.Jewelrydto jewelry)
        {
            await _jewelrybll.UpdateJewelryAsync(jewelry);
            return Ok();
        }

        [HttpDelete("{jewelryCode}")]
        public async Task<ActionResult> DeleteJewelry(int jewelryCode)
        {
            await _jewelrybll.DeleteJewelryAsync(jewelryCode);
            return Ok();
        }



    }
}
