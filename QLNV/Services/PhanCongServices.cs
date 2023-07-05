using QLNV.Entities;
using QLNV.Helper;
using QLNV.IServices;

namespace QLNV.Services
{
    public class PhanCongServices : IPhanCongServices
    {
        private readonly AppDbConText dbContext;

        public PhanCongServices()
        {
            this.dbContext = new AppDbConText();
        }
        public DuAn CheckDuAn(int duanID)
        {
            return dbContext.DuAn.FirstOrDefault(x => x.DuAnID == duanID);
        }
        public NhanVien CheckNhanVien(int nhanvienID)
        {
            return dbContext.NhanVien.FirstOrDefault(x => x.NhanVienID == nhanvienID);
        }
        public void PhanCongDuAn(PhanCong p)
        {
            using (var trans = dbContext.Database.BeginTransaction())
            {
                try
                {
                    if (!InputHelper.CheckPhanCongRule(p))
                    {
                        Console.WriteLine(Res.Err);
                        return;
                    }
                    var nv = CheckNhanVien(p.NhanVienID);
                    var da = CheckDuAn(p.DuAnID);
                    if (nv == null)
                    {
                        Console.WriteLine($"Nhan vien {p.NhanVienID} " + Res.KhongTonTai);
                        return;
                    }
                    if (da == null)
                    {
                        Console.WriteLine($"Du an {p.DuAnID} " + Res.KhongTonTai);
                        return;
                    }

                    dbContext.Add(p);
                    dbContext.SaveChanges();
                    Console.WriteLine(Res.ThanhCong);
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
