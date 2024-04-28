using api.Controllers;
using api.Data;
using api.Interface;
using api.Interfaces;
using api.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDBContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<INguoiDungRepository, NguoiDungRepository>();
builder.Services.AddScoped<IChuyenNganhRepository, ChuyenNganhRepository>();
builder.Services.AddScoped<ICTDangKyRepository, CTDangKyRepository>();
builder.Services.AddScoped<ICTChuyenNganhRepository, CTChuyenNganhRepository>();
builder.Services.AddScoped<ICTPhieuThuRepository, CTPhieuThuRepository>();
builder.Services.AddScoped<IDangKyRepository, DangKyRepository>();
builder.Services.AddScoped<IGiangVienRepository, GiangVienRepository>();
builder.Services.AddScoped<IKhoaRepository, KhoaRepository>();
builder.Services.AddScoped<ILopHocPhanRepository, LopHocPhanRepository>();
builder.Services.AddScoped<ILopRepository, LopRepository>();
builder.Services.AddScoped<IMonHocRepository, MonHocRepository>();
builder.Services.AddScoped<IPhieuThuRepository, PhieuThuRepository>();
builder.Services.AddScoped<ISinhVienRepository, SinhVienRepository>();
builder.Services.AddScoped<IChuongTrinhHocRepository, ChuongTrinhHocRepository>();
builder.Services.AddScoped<IXuLyHocPhiRepository, XuLyHocPhiRepository>();
builder.Services.AddScoped<IXuLyDangKyRepository, XuLyDangKyRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();
