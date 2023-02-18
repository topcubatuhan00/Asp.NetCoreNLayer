﻿using Core.DTos;
using Microsoft.AspNetCore.Mvc;

namespace NLayerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomBaseController : ControllerBase
    {
        [NonAction]
        public IActionResult CreateActionResult<T>(CustomResponseDto<T> customResponseDto)
        {
            if (customResponseDto.StatusCode == 204)
                return new ObjectResult(null)
                {
                    StatusCode = customResponseDto.StatusCode,

                };
            return new ObjectResult(customResponseDto)
            {
                StatusCode = customResponseDto.StatusCode,
            };
        }
    }
}
