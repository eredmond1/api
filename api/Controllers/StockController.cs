using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Comment.Stock;
using api.Interface;
using api.Mappers;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Route("api/stock")]
    [ApiController]
    public class StockController: ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly IStockRepositiory _stockrepo;
        public StockController(ApplicationDBContext context, IStockRepositiory stockRepo)
        {
            _stockrepo = stockRepo;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var stocks = await _stockrepo.GetAllAsync();
            var stocksDto = stocks.Select(s => s.ToStockDto());
            return Ok(stocksDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var stock = await _stockrepo.GetByIdAsync(id);
            if(stock == null)
            {return NotFound();}
            return Ok(stock.ToStockDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateStockRequestDto stockDto)
        {
            var stockModel = stockDto.ToStockFromCreateDTO();
            await _stockrepo.CreateAsync(stockModel);
            return CreatedAtAction(nameof(GetById), new {id = stockModel.ID}, stockModel.ToStockDto());
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateStockRequestDto updateDto)
        {
            var stockModel = await _stockrepo.UpdateAsync(id, updateDto);
            if(stockModel == null)
            {
                return NotFound();
            }
            return Ok(stockModel.ToStockDto());
        }
        
        [HttpDelete]
        [Route("{id}")]
        //remove is not an acync function 
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var stockModel = await _stockrepo.DeleteAsync(id);

            if (stockModel == null)
            {
                return NotFound();
            }
            return NoContent();
        }

    }
}