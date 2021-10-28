﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestWithAPSNETUdemy.Business;
using RestWithAPSNETUdemy.Data.VO;
using RestWithAPSNETUdemy.Hypermedia.Filters;
using RestWithAPSNETUdemy.Model;

namespace RestWithAPSNETUdemy.Controllers
{
    [ApiController]
    [ApiVersion("1")]
    [Route("/api/[controller]/v{version:apiVersion}")]
    public class BooksController : ControllerBase
    {
        private readonly IBooksBusiness _bookBusiness;
        private readonly ILogger<BooksController> _logger;

        public BooksController(IBooksBusiness bookBusiness, ILogger<BooksController> logger)
        {
            _bookBusiness = bookBusiness;
            _logger = logger;
        }

        [HttpGet]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult ReturnAll()
        {
            return Ok(_bookBusiness.FindAll());
        }

        [HttpGet("{id}")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult ReturnSpecific(long id)
        {
            var book = _bookBusiness.FindById(id);

            if(book == null) return NotFound();

            return Ok(book);
        }

        [HttpPost]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Create([FromBody]BooksVO book)
        {
            if (book == null) return BadRequest();

            return Ok(_bookBusiness.Create(book));
        }

        [HttpPut]
        [TypeFilter(typeof(HyperMediaFilter))]
        public ActionResult Edit([FromBody] BooksVO book)
        {
            if (book == null) return BadRequest();

            return Ok(_bookBusiness.Update(book));
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var book = _bookBusiness.FindById(id);

            if (book == null) return NotFound();

            _bookBusiness.Delete(id);

            return NoContent();
        }
    }
}