﻿using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        IPaymentService _paymentService;

        public PaymentsController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        

        [HttpGet("add")]
        public IActionResult Add(Payment card)
        {
            
            var result = _paymentService.PaymentAdd(card);
            return Ok(result);
        }
    }
}
