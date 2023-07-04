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
            throw new NotImplementedException();
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
