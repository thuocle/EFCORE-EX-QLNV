using QLNV.Entities;
using QLNV.Helper;
using QLNV.IServices;

namespace QLNV.Services
{
    internal class NhanVienServices : INhanVienServices
    {
        private readonly AppDbConText dbContext;

        public NhanVienServices()
        {
            this.dbContext = new AppDbConText();
        }
        public NhanVien CheckNhanVien(int nhanvienID)
        {
            return dbContext.NhanVien.FirstOrDefault(x => x.NhanVienID == nhanvienID);
        }
        public void ThemNhanVien(NhanVien n)
        {
            using (var trans = dbContext.Database.BeginTransaction())
            {
                try
                {
                    if (!InputHelper.CheckNhanVienRule(n))
                    {
                        Console.WriteLine(Res.Err);
                    }
                    if (CheckNhanVien(n.NhanVienID) != null)
                    {
                        Console.WriteLine($"Nhan vien {n.NhanVienID}" + Res.DaTonTai);
                        return;
                    }
                    else
                    {
                        dbContext.Add(n);
                        dbContext.SaveChanges();
                        Console.WriteLine(Res.ThanhCong);
                    }
                    trans.Commit();
                }
                catch (Exception)
                {
                    trans.Rollback();
                    throw;
                }
            }
        }

        public void TinhLuongNhanVien()
        {
            var query = from nv in dbContext.NhanVien
                        join pc in dbContext.PhanCong
                            on nv.NhanVienID equals pc.NhanVienID
                        join da in dbContext.DuAn
                            on pc.DuAnID equals da.DuAnID
                        group new { nv, pc, da }
                            by new { nv.NhanVienID, nv.HoTen, nv.HeSoLuong }
                               into gLuong
                        select new
                        {
                            Ten = gLuong.Key.HoTen,
                            HSL = gLuong.Key.HeSoLuong,
                            TongGio = gLuong.Sum(x => x.pc != null ? x.pc.SoGioLam : 0)
                        };
            foreach (var item in query)
            {
                Console.WriteLine($"{item.Ten} - Tong Luong = {item.TongGio * 15 * item.HSL}");
            }


        }

        public void XoaNhanVien(int nhanvienID)
        {
            using (var trans = dbContext.Database.BeginTransaction())
            {
                try
                {
                    var nv = CheckNhanVien(nhanvienID);
                    if (nv != null)
                    {
                        dbContext.Remove(nv);
                        dbContext.SaveChanges();
                        Console.WriteLine(Res.ThanhCong);
                    }
                    else
                    {
                        Console.WriteLine($"Nhan vien {nv.NhanVienID} " + Res.KhongTonTai);
                    }
                    trans.Commit();
                }
                catch (Exception)
                {
                    trans.Rollback();
                    throw;
                }
            }
        }
    }
}
