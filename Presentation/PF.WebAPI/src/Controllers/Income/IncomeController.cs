using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PF.Application.Abstraction.Income;
using PF.Application.Abstraction.Income.Dto;
using PF.WebAPI.Controllers.Base;

namespace PF.WebAPI.Controllers.Income;

public class IncomeController(IIncomeService service) : BaseController
{
    [HttpGet("user/{userId:guid}")]
    public async Task<IActionResult> GetByUser(Guid userId)
        => ApiResult(await service.GetListAsync(x => x.UserId == userId.ToString(), includeProperties: i => i.Include(x => x.User)));
    
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get(Guid id)
        => ApiResult(await service.GetFirstOrDefaultAsync(x => x.Id == id, includeProperties: i => i.Include(x => x.User)));

    [HttpPost]
    public async Task<IActionResult> Create(IncomeDto expense)
        => ApiResult(await service.CreateAsync(expense));
    
    [HttpPut]
    public async Task<IActionResult> Update(IncomeDto expense)
        => ApiResult(await service.UpdateAsync(expense));
    
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
        => ApiResult(await service.DeleteAsync(id));
    
}