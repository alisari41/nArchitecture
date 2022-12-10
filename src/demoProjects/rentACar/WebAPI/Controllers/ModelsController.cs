using Application.Features.Models.Queries.GetListModel;
using Core.Application.Requests;
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
    }
}
