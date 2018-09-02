using InsurranceLogic.DataAccess.EFDataBaseConecction;
using InsurranceLogic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsurranceLogic.ModelAdapter
{
    interface IAdapter
    {
        DTO adapt(DBO dbo);
        DBO adapt(DTO dto);
    }
}
