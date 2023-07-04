using QLNV.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNV.IServices
{
    public interface INhanVienServices
    {
        void ThemNhanVien(NhanVien n);
        void XoaNhanVien(int nhanvienID);
        void TinhLuongNhanVien();
    }
}
