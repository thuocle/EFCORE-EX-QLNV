using QLNV.IServices;
using QLNV.Services;
using QLNV.Entities;
using QLNV.Helper;

void Main()
{
    INhanVienServices nhanVienServices = new NhanVienServices();
    IDuAnServices duAnServices = new DuAnServices();
    /* nhanVienServices.ThemNhanVien(new NhanVien(inputType.Them));*/
    /*Console.WriteLine("Nhap nv muon xoa:");
    int id = int.Parse(Console.ReadLine());
    nhanVienServices.XoaNhanVien(id);*/
    /*duAnServices.ThemDuAn(new DuAn(inputType.Them));*/
    /*Console.WriteLine("Nhap du an muon update:");
    int id = int.Parse(Console.ReadLine());*/
   /* duAnServices.SuaDuAn(id);*/
   IPhanCongServices phanCongServices = new PhanCongServices();
    /* phanCongServices.PhanCongDuAn(new PhanCong(inputType.Them));*/
    nhanVienServices.TinhLuongNhanVien();
}
Main();