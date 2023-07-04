using QLNV.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNV.Entities
{
    public class PhanCong
    {
        public int PhanCongID { get; set; }
        public int NhanVienID { get; set; }
        public NhanVien NhanVien { get; set; }
        public int DuAnID { get; set; }
        public DuAn DuAn { get; set; }
        public int SoGioLam { get; set; }
        public PhanCong()
        {
            NhanVienID = InputHelper.InputINT(Res.inNhanVienID, Res.Err);
            DuAnID = InputHelper.InputINT(Res.inDuAnID, Res.Err);
            SoGioLam = InputHelper.InputINT(Res.inSoGioLam, Res.Err);
        }
    }
}
