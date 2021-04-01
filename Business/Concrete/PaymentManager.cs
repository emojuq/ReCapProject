using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class PaymentManager : IPaymentService
    {
        public IResult PaymentAdd(Payment card)
        {
            return card.Number != "741852963" ? (IResult)new ErrorResult("Ödeme İşlemi Hatalı") : new SuccessResult("Ödeme işlemi Başarılı");
        }
    }
}
