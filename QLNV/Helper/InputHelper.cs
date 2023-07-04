using QLNV.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace QLNV.Helper
{
    public class InputHelper
    {
        #region KiemTraKhiNhap
        public static string PhoneNumBer(string msg, string err)
        {
            bool check;
            string ret;
            do
            {
                Console.WriteLine(msg);
                ret = Console.ReadLine();
                check = IsPhoneNumber(ret);
                if (!check) Console.WriteLine(err);
            } while (!check);
            return ret;
        }
        public static string Email(string msg, string err)
        {
            bool check;
            string ret;
            do
            {
                Console.WriteLine(msg);
                ret = Console.ReadLine();
                check = IsEmail(ret);
                if (!check) Console.WriteLine(err);
            } while (!check);
            return ret;
        }
        public static bool IsPhoneNumber(string number)
        {
            return Regex.Match(number, @"^([0-9]{9})$").Success;
        }
        public static bool IsEmail(string email)
        {
            return Regex.Match(email, @"^[^\s@]+@[^\s@]+\.[^\s@]+$").Success;
        }
        public static bool IsMoreTwoWord(string str)
        {
            return str.Split(' ').Length > 2;
        }
        public static int InputINT(string msg, string err, int min = 0)
        {
            bool check;
            int ret;
            do
            {
                Console.WriteLine(msg);
                check = int.TryParse(Console.ReadLine(), out ret);
                check = check && ret > min;
                if (!check) Console.WriteLine(err);
            } while (!check);
            return ret;
        }
        public static string InputSTR(string msg, string err, int min = 0, int max = int.MaxValue)
        {
            bool check;
            string ret;
            do
            {
                Console.WriteLine(msg);
                ret = Console.ReadLine();
                check = ret.Length > min && ret.Length < max;
                if (!check) Console.WriteLine(err);
            } while (!check);
            return ret;
        }
        public static string InputName(string msg, string err, int min = 0, int max = int.MaxValue)
        {
            bool check;
            string ret;
            do
            {
                Console.WriteLine(msg);
                ret = Console.ReadLine();
                check = ret.Length > min && ret.Length < max && IsMoreTwoWord(ret);
                if (!check) Console.WriteLine(err);
            } while (!check);
            return ret;
        }
        public static DateTime InputDT(string msg, string err, DateTime min, DateTime max)
        {
            bool check;
            DateTime ret;
            do
            {
                Console.WriteLine(msg);
                check = DateTime.TryParse(Console.ReadLine(), out ret);
                check = check && ret > min && ret < max;
                if (!check) Console.WriteLine(err);
            } while (!check);
            return ret;
        }
        #endregion
        #region KiemTraKhiCRUD
        public static bool CheckNhanVienRule(NhanVien nv)
        {
           return nv.HoTen.Length <= 20 && nv.HoTen.Split(' ').Length > 2 && nv.NgaySinh.Year >= 1970 && nv.NgaySinh.Year <= 2000;
        }
        public static bool CheckPhanCongRule(PhanCong p)
        {
            return p.SoGioLam > 0 && p.SoGioLam % 1 == 0;
        }
        public static bool CheckDuAnRule(DuAn d)
        {
            return d.TenDuAn.Length <= 10;
        }
        #endregion
    }
}
