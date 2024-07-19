using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using server.Data;
using server.Dtos.Stock;
using server.Interfaces;
using server.Mappers;
using Newtonsoft.Json;
using server.Helpers;
using Microsoft.AspNetCore.Authorization;

namespace server.Controllers
{
    [Route("api/stock")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly IStockRepository _stockRepo;
        private readonly IMailService _mailService;
        public StockController(ApplicationDBContext context, IStockRepository stockRepo, IMailService mailService)
        {
            _stockRepo = stockRepo;
            _context = context;
            _mailService = mailService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] QueryObject query)
        {

            var stocks = await _stockRepo.GetAllAsync(query);
            var stockDto = stocks.Select(s => s.ToStockDto());

            var result = new
            {
                page = query.PageNumber,
                per_page = query.PageSize,
                data = stockDto
            };
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        [Authorize]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var token = HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            Console.WriteLine($"Token: {token}");
            var stocks = await _stockRepo.GetByIdAsync(id);
            if (stocks == null)
            {
                return NotFound();
            }


            return Ok(stocks.ToStockDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateStockRequestDto stockDto)
        {

            var stockModel = stockDto.ToStockFromCreateDTO();
            Console.WriteLine("cuongdeptrai");
            Console.WriteLine($"Received CreateStockRequestDto: {JsonConvert.SerializeObject(stockDto, Formatting.Indented)}");
            if (stockDto.CompanyName == "")
            {
                return BadRequest();
            }
            await _stockRepo.CreateAsync(stockModel);

            return CreatedAtAction(nameof(GetById), new { id = stockModel.Id }, stockModel.ToStockDto());
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateStockRequestDto updateDto)
        {

            var stockModel = await _stockRepo.UpdateAsync(id, updateDto);

            if (stockModel == null)
            {
                return NotFound();
            }

            return Ok(stockModel.ToStockDto());
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {

            var stockModel = await _stockRepo.DeleteAsync(id);

            if (stockModel == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPost("send")]
        public async Task<IActionResult> SendEmail([FromBody] EmailDto emailDto)
        {
            await _mailService.SendEmailAsync(emailDto.ToEmail, emailDto.Subject, emailDto.Body);
            return Ok("Email sent successfully!");
        }


    }
}

public class EmailDto
{
    public string ToEmail { get; set; }
    public string Subject { get; set; }
    public string Body { get; set; }
}