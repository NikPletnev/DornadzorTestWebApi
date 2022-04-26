using AutoMapper;
using DornadzorTestWebApi.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DornadzorTestWebApi.API.Controllers
{
    public abstract class BaseController<T, U, I> : Controller 
    {
        protected readonly IService<T> _service;
        protected readonly IMapper _mapper;

        public BaseController(IMapper mapper, IService<T> service)
        {
            _mapper = mapper;
            _service = service;
        }

        public async Task<ActionResult<List<T>>> GetAll()
        {
            var result = _mapper.Map<List<T>>(await _service.GetAll());
            return Ok(result);
        }

    }
}
