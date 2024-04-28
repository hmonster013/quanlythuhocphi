using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.XuLyHocPhi;
using api.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class XuLyHocPhiRepository : IXuLyHocPhiRepository
    {
        private readonly ApplicationDBContext _context;

        public XuLyHocPhiRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<HocPhiDto?> GetDataBySVandHK(string maSinhVien, int hocKy)
        {
            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@MASV", maSinhVien),
                new SqlParameter("@HOCKY", hocKy)
            };

            var result = new HocPhiDto();

            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "sp_XULYHOCPHI_select_byhocky";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddRange(parameters.ToArray());

                await _context.Database.OpenConnectionAsync();

                using (var reader = await command.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        result.MASV = reader["MASV"].ToString();
                        result.TONGHOCPHI = Convert.ToDouble(reader["HOCPHI"]);
                        result.TONGDADONG = Convert.ToDouble(reader["DADONG"]);
                        result.TONGCHUADONG = Convert.ToDouble(reader["CHUADONG"]);
                    }
                    else
                    {
                        return null;
                    }
                }

                return result;
            }
        }

        public async Task<HocPhiDto> GetDataTongHocPhiOfSV(string maSinhVien)
        {
            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@MASV", maSinhVien)
            };

            var result = new HocPhiDto();

            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "sp_XULYHOCPHI_sum_all";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddRange(parameters.ToArray());

                await _context.Database.OpenConnectionAsync();

                using (var reader = await command.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        result.MASV = reader["MASV"].ToString();
                        result.TONGHOCPHI = Convert.ToDouble(reader["TONGHOCPHI"]);
                        result.TONGDADONG = Convert.ToDouble(reader["TONGDADONG"]);
                        result.TONGCHUADONG = Convert.ToDouble(reader["TONGCHUADONG"]);
                    }
                }
            }

            return result;
        }
    }
}