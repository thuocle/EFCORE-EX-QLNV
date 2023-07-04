using QLNV.Entities;
using QLNV.Helper;
using QLNV.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace QLNV.Services
{
    public class DuAnServices : IDuAnServices
    {
        private readonly AppDbConText dbContext;

        public DuAnServices()
        {
            this.dbContext = new AppDbConText();
        }
        public void SuaDuAn(int duanID)
        {
           using(var trans = dbContext.Database.BeginTransaction())
            {
                try
                {
                    var da = CheckDuAn(duanID);
                    if (da != null)
                    {
                        da.CapNhatDuAn();
                        dbContext.Update(da);
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
        public DuAn CheckDuAn(int duanID)
        {
            return dbContext.DuAn.FirstOrDefault(x => x.DuAnID == duanID);
        }
        public void ThemDuAn(DuAn d)
        {
            using (var trans = dbContext.Database.BeginTransaction())
            {
                try
                {
                    if (!InputHelper.CheckDuAnRule(d))
                    {
                        Console.WriteLine(Res.Err);
                        return;
                    }
                    if (CheckDuAn(d.DuAnID) != null)
                    {
                        Console.WriteLine("Du an" + Res.DaTonTai);
                        return;
                    }
                    else
                    {
                        dbContext.Add(d);
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
    }
}
