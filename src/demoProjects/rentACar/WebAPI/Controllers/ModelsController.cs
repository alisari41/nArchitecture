using Application.Features.Models.Queries.GetListModel;
using Application.Features.Models.Queries.GetListModelByDynamic;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelsController : BaseController
    {
        [HttpGet("get-list")]
        public async Task<ActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListModelQuery getLisModelQuery = new() { PageRequest = pageRequest }; // Bu yeni kullanımdır eski hali aşağıdaki gibidir.
                                                                                      // GetListBrandQuery getListBrandQuery = new GetListBrandQuery();
                                                                                      // getListBrandQuery.PageRequest = pageRequest;

            var result = await Mediator.Send(getLisModelQuery);
            return Ok(result);
        }

        [HttpPost("GetList/ByDynamic")]
        public async Task<ActionResult> GetListByDinamic([FromQuery] PageRequest pageRequest, [FromBody] Dynamic dynamic) // Dynamic olduğu için HttpPost kullanıldı
        {
            GetListModelByDynamicQuery getLisModelByDinamicQuery = new() { PageRequest = pageRequest, Dynamic =dynamic};

            var result = await Mediator.Send(getLisModelByDinamicQuery);
            return Ok(result);
        }
    }
}
