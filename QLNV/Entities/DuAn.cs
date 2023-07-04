using QLNV.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNV.Entities
{
    public class DuAn
    {
        public int DuAnID { get; set; }
        [MaxLength(10)]
        public string TenDuAn { get; set; }
        public string MoTa { get; set; }
        public string GhiChu { get; set; }
        public IEnumerable<PhanCong> PhanCong { get; set; }
        public DuAn()
        {
            TenDuAn = InputHelper.InputSTR(Res.inTenDuAn, Res.Err, 0, 10);
            MoTa = InputHelper.InputSTR(Res.inMota, Res.Err, 0, 20);
            GhiChu = InputHelper.InputSTR(Res.inGhiChu, Res.Err, 0, 20);
        }
        public void CapNhatDuAn()
        {
            TenDuAn = InputHelper.InputSTR(Res.inTenDuAn, Res.Err, 0, 10);
            MoTa = InputHelper.InputSTR(Res.inMota, Res.Err, 0, 20);
            GhiChu = InputHelper.InputSTR(Res.inGhiChu, Res.Err, 0, 20);
        }
    }
}
