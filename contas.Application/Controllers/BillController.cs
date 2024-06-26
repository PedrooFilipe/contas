﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using contas_api_model.Entity;
using contas_api_model.Model;
using contas_api_model.Interfaces.Service;

namespace bills_api.Controllers
{
    [Route("bill")]
    public class BillController : MyController
    {
        private IBillService _billService;

        public BillController(IBillService billSercice)
        {
            _billService = billSercice;
        }

        [Route("save"), HttpPost]
        public async Task<RestResponse<Bill>> Save([FromHeader] string authorization, [FromBody] Bill bill)
        {
            RestResponse<Bill> restResponse = null;
            try
            {
                await _billService.SaveAsync(bill);
                restResponse = this.GetRestResponseOk<Bill>(null, null, authorization);
            }
            catch(Exception e)
            {
                restResponse = this.GetRestResponseError<Bill>(authorization);
            }

            return restResponse;
        }
        
        [Route("list-by-user"), HttpGet]
        public async Task<RestResponse<List<Bill>>> ListByUser([FromHeader] string authorization, DateTime? initialData, DateTime? finalDate, int? statusBill)
        {
            RestResponse<List<Bill>> restResponse = null;
            int userId = this.GetIdFromToken(authorization);
            try
            {
                List<Bill> list = await _billService.ListByUserAsync(userId, initialData, finalDate, statusBill);
                restResponse = this.GetRestResponseOk<List<Bill>>(list, null, authorization);
            }
            catch(Exception e)
            {
                restResponse = this.GetRestResponseError<List<Bill>>(authorization);
            }

            return restResponse;
        }
        
        [Route("find/{id}"), HttpGet]
        public async Task<RestResponse<Bill>> Find([FromHeader] string authorization, int id)
        {
            RestResponse<Bill> restResponse = null;
            try
            {
                Bill bill = await _billService.FindAsync(id);
                restResponse = this.GetRestResponseOk<Bill>(bill, null, authorization);
            }
            catch(Exception e)
            {
                restResponse = this.GetRestResponseError<Bill>(authorization);
            }

            return restResponse;
        }
        
        [Route("update/{id}"), HttpPut]
        public async Task<RestResponse<Bill>> Update([FromHeader] string authorization, int id)
        {
            RestResponse<Bill> restResponse = null;
            try
            {
                restResponse = this.GetRestResponseOk<Bill>(null, null, authorization);
            }
            catch(Exception e)
            {
                restResponse = this.GetRestResponseError<Bill>(authorization);
            }

            return restResponse;
        }
        
        [Route("confirm-payment/{id}"), HttpPut]
        public async Task<RestResponse<Bill>> ConfirmPayment([FromHeader] string authorization, int id)
        {
            RestResponse<Bill> restResponse = null;
            try
            {

                restResponse = this.GetRestResponseOk<Bill>(null, null, authorization);
            }
            catch(Exception e)
            {
                restResponse = this.GetRestResponseError<Bill>(authorization);
            }

            return restResponse;
        }


    }
}
