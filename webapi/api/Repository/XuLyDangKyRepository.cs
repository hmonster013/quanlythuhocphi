using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.XuLyDangKy;
using api.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class XuLyDangKyRepository : IXuLyDangKyRepository
    {
        private readonly ApplicationDBContext _context;

        public XuLyDangKyRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<List<LopHocPhanQueryDto>> GetDataLHPChuaDK(int maDangKy, string maSinhVien, int hocKy)
        {
            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@MADK", maDangKy),
                new SqlParameter("@MASV", maSinhVien),
                new SqlParameter("@HOCKY", hocKy)
            };

            var result = new List<LopHocPhanQueryDto>();

            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "sp_XULYDANGKY_select_chuadk";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddRange(parameters.ToArray());

                await _context.Database.OpenConnectionAsync();

                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var lhp = new LopHocPhanQueryDto
                        {
                            MALHP = Convert.ToInt32(reader["MALHP"]),
                            MAMH = reader["MAMH"].ToString(),
                            TENMH = reader["TENMH"].ToString(),
                            FULLNAME = reader["FULLNAME"].ToString(),
                            SOTINCHI = Convert.ToInt32(reader["SOTINCHI"]),
                            NIENKHOA = reader["NIENKHOA"].ToString(),
                            HOCKY = Convert.ToInt32(reader["HOCKY"]),
                            HUYLOP = Convert.ToBoolean(reader["HUYLOP"])
                        };
                        result.Add(lhp);
                    }
                }

                return result;
            }
        }

        public async Task<List<LopHocPhanQueryDto>> GetDataLHPDaDK(int maDangKy, string maSinhVien, int hocKy)
        {
            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@MADK", maDangKy),
                new SqlParameter("@MASV", maSinhVien),
                new SqlParameter("@HOCKY", hocKy)
            };

            var result = new List<LopHocPhanQueryDto>();

            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "sp_XULYDANGKY_select_masv";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddRange(parameters.ToArray());

                await _context.Database.OpenConnectionAsync();

                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var lhp = new LopHocPhanQueryDto
                        {
                            MALHP = Convert.ToInt32(reader["MALHP"]),
                            MAMH = reader["MAMH"].ToString(),
                            TENMH = reader["TENMH"].ToString(),
                            FULLNAME = reader["FULLNAME"].ToString(),
                            SOTINCHI = Convert.ToInt32(reader["SOTINCHI"]),
                            NIENKHOA = reader["NIENKHOA"].ToString(),
                            HOCKY = Convert.ToInt32(reader["HOCKY"]),
                            HUYLOP = Convert.ToBoolean(reader["HUYLOP"])
                        };
                        result.Add(lhp);
                    }
                }

                return result;
            }
        }
    }
}