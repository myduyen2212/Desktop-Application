using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace DAL
{
    public class SanPham_DAL
    {
        private static SanPham_DAL instance;

        public static SanPham_DAL Instance
        {
            get { if (instance == null) instance = new SanPham_DAL(); return instance; }
            private set { instance = value; }
        }

        public SanPham_DAL() { }

        public DataTable LayDSSP()
        {
            string query = "SELECT CN.TenCN, SP.MaSP, TenSP, GiaVon, GiaBan, DonVTinh, KichThuocSP, MauSP, SUM(SoLuongTonKho) AS SoLuongTonKho, TenLSP, TenNCC FROM SanPham SP, TonKho TK, LoaiSanPham LSP, NhaCungCap NCC, ChiNhanh CN WHERE SP.MaSP = TK.MaSP AND SP.MaLSP = LSP.MaLSP AND SP.MaNCC = NCC.MaNCC AND TK.MaCN = CN.MaCN GROUP BY CN.TenCN, SP.MaSP, TenSP, GiaVon, GiaBan, DonVTinh, KichThuocSP, MauSP, TenLSP, TenNCC";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public DataTable LayDSNCC()
        {
            string query = "SELECT * FROM NhaCungCap";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public DataTable LayDSLSP()
        {
            string query = "SELECT * FROM LoaiSanPham";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public DataTable LayDSCN()
        {
            string query = "SELECT * FROM ChiNhanh";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public DataTable TimKiem(string TuKhoa)
        {
            string query = string.Format("SELECT CN.TenCN, SP.MaSP, TenSP, GiaVon, GiaBan, DonVTinh, KichThuocSP, MauSP, SUM(SoLuongTonKho) AS SoLuongTonKho, TenLSP, TenNCC FROM SanPham SP, TonKho TK, LoaiSanPham LSP, NhaCungCap NCC, ChiNhanh CN WHERE SP.MaSP = TK.MaSP AND SP.MaLSP = LSP.MaLSP AND SP.MaNCC = NCC.MaNCC AND TK.MaCN = CN.MaCN AND (SP.MaSP LIKE '%{0}%' OR TenSP LIKE N'%{0}%' OR KichThuocSP LIKE '%{0}%' OR MauSP LIKE N'%{0}%') GROUP BY  CN.TenCN, SP.MaSP, TenSP, GiaVon, GiaBan, DonVTinh, KichThuocSP, MauSP, TenLSP, TenNCC", TuKhoa);
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public DataTable LocNCC(string TuKhoaLoc)
        {
            string query = string.Format("SELECT CN.TenCN, SP.MaSP, TenSP, GiaVon, GiaBan, DonVTinh, KichThuocSP, MauSP, SUM(SoLuongTonKho) AS SoLuongTonKho, TenLSP, TenNCC, CN.TenCN FROM SanPham SP, TonKho TK, LoaiSanPham LSP, NhaCungCap NCC, ChiNhanh CN WHERE SP.MaSP = TK.MaSP AND SP.MaLSP = LSP.MaLSP AND SP.MaNCC = NCC.MaNCC AND TK.MaCN = CN.MaCN AND (SP.MaNCC LIKE '%{0}%') GROUP BY SP.MaSP, TenSP, GiaVon, GiaBan, DonVTinh, KichThuocSP, MauSP, TenLSP, TenNCC", TuKhoaLoc);
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public DataTable LocLSP(string TuKhoaLoc)
        {
            string query = string.Format("SELECT CN.TenCN, SP.MaSP, TenSP, GiaVon, GiaBan, DonVTinh, KichThuocSP, MauSP, SUM(SoLuongTonKho) AS SoLuongTonKho, TenLSP, TenNCC, CN.TenCN FROM SanPham SP, TonKho TK, LoaiSanPham LSP, NhaCungCap NCC, ChiNhanh CN WHERE SP.MaSP = TK.MaSP AND SP.MaLSP = LSP.MaLSP AND SP.MaNCC = NCC.MaNCC AND TK.MaCN = CN.MaCN AND (SP.MaLSP LIKE '%{0}%') GROUP BY SP.MaSP, TenSP, GiaVon, GiaBan, DonVTinh, KichThuocSP, MauSP, TenLSP, TenNCC", TuKhoaLoc);
            return DataProvider.Instance.ExecuteQuery(query);
        }
        
        public bool CheckThem(SanPham_DTO SanPham)
        {
            string query = string.Format("SELECT * FROM SanPham WHERE TenSP = N'{0}' AND KichThuocSP = '{1}' AND MauSP = N'{2}' AND MaNCC = '{3}' AND MaLSP = '{4}'", SanPham.TenSP, SanPham.KichThuocSP, SanPham.MauSP, SanPham.MaNCC, SanPham.MaLSP);
            DataTable result = DataProvider.Instance.ExecuteQuery(query);
            if (result.Rows.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public int TaoSTTMaSP()
        {
            string query = string.Format("SELECT COUNT(*) FROM SanPham");
            object result = DataProvider.Instance.ExecuteScalar(query);
            return Convert.ToInt32(result);
        }

        public bool ThemSP(SanPham_DTO SanPham)
        {
            string query = string.Format("INSERT INTO SanPham (MaSP, TenSP, GiaVon, GiaBan, DonVTinh, KichThuocSP, MauSP, MaLSP, MaNCC) VALUES ('{0}', N'{1}', {2}, {3}, N'{4}', '{5}', N'{6}', '{7}', '{8}')", SanPham.MaSP, SanPham.TenSP, SanPham.GiaVon, SanPham.GiaBan, SanPham.DonViTinh, SanPham.KichThuocSP, SanPham.MauSP, SanPham.MaLSP, SanPham.MaNCC);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool ThemTKSP(SanPham_DTO SanPham, TonKho_DTO TonKho)
        {
            string query = string.Format("INSERT INTO TonKho (MaCN, MaSP, SoLuongTonKho) VALUES ('{0}', '{1}', {2})", TonKho.MaCN, TonKho.MaSP, TonKho.SoLuongTonKho);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool SuaSP(SanPham_DTO SanPham)
        {
            string query = string.Format("UPDATE SanPham SET MaSP = '{0}', TenSP = N'{1}', GiaVon = {2}, GiaBan = {3}, DonVTinh = N'{4}', KichThuocSP = '{5}', MauSP = N'{6}', MaLSP = '{7}', MaNCC = '{8}' WHERE MaSP = '{9}'", SanPham.MaSP, SanPham.TenSP, SanPham.GiaVon, SanPham.GiaBan, SanPham.DonViTinh, SanPham.KichThuocSP, SanPham.MauSP, SanPham.MaLSP, SanPham.MaNCC, SanPham.MaSP);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        
        public bool SuaTKSP(SanPham_DTO SanPham, TonKho_DTO TonKho)
        {
            string query = string.Format("UPDATE TonKho SET MaCN = '{0}', MaSP = N'{1}', SoLuongTonKho = {2} WHERE MaSP = '{3}'", TonKho.MaCN, TonKho.MaSP, TonKho.SoLuongTonKho, SanPham.MaSP);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool CheckXoaCTHD(SanPham_DTO SanPham)
        {
            string query = string.Format("SELECT * FROM ChiTietHD WHERE MaSP = '{0}'", SanPham.MaSP);
            DataTable result = DataProvider.Instance.ExecuteQuery(query);
            if (result.Rows.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool CheckXoaCTPHT(SanPham_DTO SanPham)
        {
            string query = string.Format("SELECT * FROM ChiTietPHT WHERE MaSP = '{0}'", SanPham.MaSP);
            DataTable result = DataProvider.Instance.ExecuteQuery(query);
            if (result.Rows.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
       
        public bool XoaTKSP(SanPham_DTO SanPham)
        {
            string query = string.Format("DELETE TonKho WHERE MaSP = '{0}'", SanPham.MaSP);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool XoaSP(SanPham_DTO SanPham)
        {
            string query = string.Format("DELETE SanPham WHERE MaSP = '{0}'", SanPham.MaSP);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
    }
}
