using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace contas_api_model.Model
{
    public class RestResponse<T> where T : class
    {
        public T Data { get; set; }
        public string Message { get; set; }
        public int ResponseCode { get; set; }
        public Pagination Pagination { get; set; }
        
        public string Token { get; set; }
    }
    
    public class Pagination
    {
        public int Current { get; set; }
        public int Total { get; set; }
    }
}
