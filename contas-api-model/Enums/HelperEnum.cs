using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace contas_api_model.Enums
{
    public class HelperEnum
    {
        public enum FormaPagamentoEnum
        {
            [Description("À VISTA")]
            A_VISTA = 1,
            [Description("PARCELADO")]
            PARCELADO = 2
        }

    }
}
