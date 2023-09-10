using AutoMapper;
using Mango.Services.PracticeCouponAPI.Data;
using Mango.Services.PracticeCouponAPI.Models.Dto;
using Mango.Services.PracticeCouponAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using System.Diagnostics.Eventing.Reader;

namespace Mango.Services.PracticeCouponAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ShoeAPIController : ControllerBase
	{
		private readonly AppDbContext _db;
		private ResponseDto _response;
		private IMapper _mapper;

		public ShoeAPIController(AppDbContext db, IMapper mapper)
		{
			_db = db;
			_mapper = mapper;
			_response = new ResponseDto();
		}

		[HttpGet]
		public ResponseDto Get()
		{
			try
			{
				IEnumerable<Shoe> objList = _db.Shoes.ToList();
				_response.Result = _mapper.Map<IEnumerable<ShoeDto>>(objList);
			}
			catch(Exception ex)
			{
				_response.IsSuccess = false;
				_response.Message = ex.Message;
			}
			return _response;
		}

		[HttpGet]
		//[Route("{id:int}")]
		public ResponseDto Get(int id)
		{
			try
			{
				Shoe obj = _db.Shoes.First(u => u.ShoeId == id);
				_response.Result = _mapper.Map<ShoeDto>(obj);
			}
			catch (Exception ex)
			{
				_response.IsSuccess = false;
				_response.Message = ex.Message;
			}
			return _response;
		}

		[HttpPost]
		public ResponseDto Post([FromBody] ShoeDto shoeDto) 
		{ 
			try
			{
				Shoe obj = _mapper.Map<Shoe>(shoeDto);
				_db.Shoes.Add(obj);
				_db.SaveChanges();
				_response.Result = _mapper.Map<ShoeDto>(obj);
			}
			catch (Exception ex)
			{
				_response.IsSuccess = false;
				_response.Message = ex.Message;
			}
			return _response;
		}

		[HttpPut]
		public ResponseDto Put([FromBody] ShoeDto shoeDto)
		{
			try
			{
				Shoe obj = _mapper.Map<Shoe>(shoeDto);
				_db.Shoes.Update(obj);
				_db.SaveChanges();
				_response.Result = _mapper.Map<ShoeDto>(obj);
			}
			catch (Exception ex)
			{
				_response.IsSuccess = false;
				_response.Message = ex.Message;
			}
			return _response;
		}

		[HttpDelete]
		//[Route("{id:int}")]
		public ResponseDto Delete(int id)
		{
			try
			{
				Shoe obj = _db.Shoes.First(u => u.ShoeId == id);
				_db.Shoes.Remove(obj);
				_db.SaveChanges();
				_response.Result = obj;
			}
			catch (Exception ex)
			{
				_response.IsSuccess = false;
				_response.Message = ex.Message;
			}
			return _response;
		}
	}
}
