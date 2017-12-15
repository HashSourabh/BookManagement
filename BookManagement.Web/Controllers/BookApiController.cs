using BookManagment.Domain.Entities;
using BookManagment.Domain.ViewModels;
using BookManagment.Services.Services;
using BookManagment.Services.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BookManagment.Web.Controllers
{
  
    [RoutePrefix("api/v1")]
    public class BookApiController : ApiController
    {
        // GET api/<controller>
        CustomMessage CMessage = new CustomMessage();
        private IBookService _BookService = new BookService();
        public BookApiController()
        {
         

        }
     
        // GET api/<controller>/5
     
        [HttpGet]
        [Route("GetAll")]
        public IList<BooksViewModel> GetAll()
        {
            return _BookService.GetAll();
        }

        // GET api/<controller>/5
        [HttpGet]
        [Route("GetById/{BookId}")]
        public Book GetById(string BookId)
        {
            return _BookService.GetById(BookId);
        }
        // delete api/<controller>/5
        [HttpDelete]
        [Route("Delete/{BookId}")]
        public IHttpActionResult Delete(string BookId)
        {
            var result = _BookService.Delete(BookId);
            if (result)
            {
                CMessage.status = true;
                CMessage.message = "Record deleted successfully.";
            }
            else
            {
                CMessage.status = false;
            }
            return Json(CMessage);
        }
        [HttpPost]
        [Route("Create")]
        public IHttpActionResult Create([FromBody]Book Book)
        {
            var result = _BookService.Create(Book);
            if (result)
            {
                CMessage.status = true;
                CMessage.message = "Record saved successfully.";
            }
            else
            {
                CMessage.status = false;
            }
            return Json(CMessage);
        }
        [HttpPatch]
        [Route("Update")]
        public IHttpActionResult Update([FromBody]Book Book)
        {
            var result = _BookService.Update(Book);
            if (result)
            {
                CMessage.status = true;
                CMessage.message = "Record updated successfully.";
            }
            else
            {
                CMessage.status = false;
            }
            return Json(CMessage);
        }
    }
}