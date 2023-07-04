using QLNV.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNV.Entities
{
    public class NhanVien
    {
        public int NhanVienID { get; set; }
        [Required]
        [MaxLength(20)]
        public string HoTen { get; set; }
        [NotMapped]
        public DateTime NgaySinh { get; set; }

        public string SDT { get; set; }
        public string DiaChi { get; set; }
        public string Email { get; set; }
        public int HeSoLuong { get; set; }
        public IEnumerable<PhanCong> PhanCong { get; set; }
        public NhanVien()
        {
            HoTen = InputHelper.InputName(Res.inHoten, Res.Err, 0, 20);
            NgaySinh = InputHelper.InputDT(Res.inNgaySinh, Res.Err, new DateTime(1970, 1,1), new DateTime(2000, 12, 31));
            SDT = InputHelper.PhoneNumBer(Res.inSDT, Res.Err);
            DiaChi = InputHelper.InputSTR(Res.inDiaChi, Res.Err, 0, 50);
            Email = InputHelper.Email(Res.inEmail, Res.Err);
            HeSoLuong = InputHelper.InputINT(Res.inHSLuong, Res.Err);
        }
    }
}
