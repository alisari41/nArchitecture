using Application.Features.Brands.Commands.CreateBrand;
using Application.Features.Brands.Dtos;
using Application.Features.Brands.Models;
using Application.Features.Brands.Queries.GetByIdBrand;
using Application.Features.Brands.Queries.GetListBrand;
using Core.Application.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : BaseController
    {
        // BaseControllerdan inherit edilir.

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateBrandCommand createBrandCommand)
        {
            CreatedBrandDto result = await Mediator.Send(createBrandCommand); // Command'i de Madiator aracığılıyla handler'ını bulması için görevlendiriyoruz.
            return Created("", result);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListBrandQuery getListBrandQuery = new() { PageRequest = pageRequest }; // Bu yeni kullanımdır eski hali aşağıdaki gibidir.
                                                                                       // GetListBrandQuery getListBrandQuery = new GetListBrandQuery();
                                                                                       // getListBrandQuery.PageRequest = pageRequest;

            BrandListModel result = await Mediator.Send(getListBrandQuery);
            return Ok(result);
        }

        [HttpGet("{Id}")] // Id parametresine ihtiyacımız olduğu için yapılıyor. route dan alacağı için FromRoute kullanılır.
        public async Task<IActionResult> GetById([FromRoute] GetByIdBrandQuery getByIdBrandQuery) // Id ile GetByIdBrandQuery Id işlemini mapleme yapacak. Id yazılımları aynı olmak zorunda 
        {
            BrandGetByIdDto result = await Mediator.Send(getByIdBrandQuery);
            return Ok(result);
        }
    }
}
