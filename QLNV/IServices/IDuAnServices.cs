using QLNV.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNV.IServices
{
    public interface IDuAnServices
    {
        void ThemDuAn(DuAn d);
        void SuaDuAn(int duanID);
    }
}
