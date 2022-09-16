﻿using School.Application.Wrappers;
using System.Net;
using System.Runtime.InteropServices;
using System.Text.Json;

namespace School.Api.Middlewares
{
    public class ErrorHandlerMiddleware
    {

        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";
                
                var responseModel = new Response<string>() {
                    Succeded = false,
                    Message = error.Message,
                };

                switch (error)
                {
                    case Application.Exceptions.ApiException e:
                        //custom application error   
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;
                    case Application.Exceptions.ValidationException e:
                        //custom application error   
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        responseModel.Errors = e.Errors;
                        break;
                    case KeyNotFoundException e:
                        //notfound error   
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;
                    default:
                        //unhandled error   
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }

                var result = JsonSerializer.Serialize(responseModel);
                await response.WriteAsync(result);
            }
        }
    }
}
