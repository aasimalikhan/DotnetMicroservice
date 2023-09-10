﻿namespace Mango.Services.AuthAPI.Models.Dto
{
    //to provide consistent response for all requests
    public class ResponseDto
    {
        public object? Result { get; set; }
        public bool IsSuccess { get; set; } = true;
        public string Message { get; set; } = "";
    }
}
