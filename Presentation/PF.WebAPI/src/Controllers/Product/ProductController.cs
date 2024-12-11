using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using PF.Application.src.Abstraction;
using PF.Application.src.Abstraction.Dto;
using PF.WebAPI.Controllers.Base;

namespace PF.WebAPI.Controllers;

public class ProductController(IProductService service, IStringLocalizer localizer) : BaseController
{
    [HttpGet]
    public async Task<IActionResult> Get()
        => ApiResult(await service.GetListAsync());

    [HttpGet("paged/{page:int}/{size:int}")]
    public async Task<IActionResult> Get([FromRoute] int page, [FromRoute] int size)
        => ApiResult(await service.GetPagedListAsync(page, size));

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get(Guid id)
        => ApiResult(await service.GetFirstOrDefaultAsync(x => x.Id == id));
    
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ProductDto dto)
        => ApiResult(await service.CreateAsync(dto));
    
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] ProductDto dto)
        => ApiResult(await service.UpdateAsync(dto));
    
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
        => ApiResult(await service.DeleteAsync(id));
}