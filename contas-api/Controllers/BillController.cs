using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using contas_api_model.Entity;
using contas_api_model.Interfaces;
using contas_api_model.Model;

namespace bills_api.Controllers
{
    [Route("bill")]
    public class BillController : MyController
    {
        private IBillRepository _billRepository;
        public BillController(IBillRepository billRepository)
        {
            _billRepository = billRepository;
        }

        [Route("save")]
        public async Task<RestResponse<Bill>> Save([FromHeader] string authorization, [FromBody] Bill bill)
        {
            RestResponse<Bill> restResponse = null;
            try
            {
                await _billRepository.Save(bill);
                restResponse = this.GetRestResponseOk<Bill>(null, null, authorization);
            }
            catch(Exception e)
            {
                restResponse = this.GetRestResponseError<Bill>(authorization);
            }

            return restResponse;
        }
        
        [Route("list-by-user")]
        public async Task<RestResponse<List<Bill>>> Save([FromHeader] string authorization, DateTime? initialData, DateTime? finalDate, int? statusBill)
        {
            RestResponse<List<Bill>> restResponse = null;
            int userId = this.GetIdFromToken(authorization);
            try
            {
                List<Bill> list = await _billRepository.ListByUser(userId, initialData, finalDate, statusBill);
                restResponse = this.GetRestResponseOk<List<Bill>>(list, null, authorization);
            }
            catch(Exception e)
            {
                restResponse = this.GetRestResponseError<List<Bill>>(authorization);
            }

            return restResponse;
        }
        
        [Route("find/{id}")]
        public async Task<RestResponse<Bill>> Find([FromHeader] string authorization, int id)
        {
            RestResponse<Bill> restResponse = null;
            try
            {
                Bill bill = await _billRepository.Find(id);
                restResponse = this.GetRestResponseOk<Bill>(bill, null, authorization);
            }
            catch(Exception e)
            {
                restResponse = this.GetRestResponseError<Bill>(authorization);
            }

            return restResponse;
        }
    }
}
