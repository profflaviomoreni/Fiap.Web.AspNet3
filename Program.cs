using AutoMapper;
using Fiap.Web.AspNet3.Data;
using Fiap.Web.AspNet3.Models;
using Fiap.Web.AspNet3.Repository;
using Fiap.Web.AspNet3.Repository.Interface;
using Fiap.Web.AspNet3.ViewModel;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSession();

var connectionString = builder.Configuration.GetConnectionString("databaseUrl");
builder.Services.AddDbContext<DataContext>(options => 
    options.UseSqlServer(connectionString).EnableSensitiveDataLogging(true)
);

var mapperConfig = new AutoMapper.MapperConfiguration( c =>
{
    c.AllowNullCollections = true;

    //Login <> Usuario
    c.CreateMap<UsuarioModel, LoginViewModel>();
    c.CreateMap<LoginViewModel, UsuarioModel>();

    //Representante
    c.CreateMap<RepresentanteModel, RepresentanteViewModel>();
    c.CreateMap<RepresentanteViewModel, RepresentanteModel>();
            //.ForMember( r => r.Clientes, opt => opt.Ignore())
            //.ForMember( r => r.Token, opt => opt.Ignore()).ReverseMap();
    //c.CreateMap<IList<RepresentanteViewModel>, IList<RepresentanteModel>>();


    //Cliente
    c.CreateMap<ClienteModel, ClienteViewModel>();
    c.CreateMap<ClienteViewModel, ClienteModel>();
    //c.CreateMap<IList<ClienteModel>, IList<ClienteViewModel>>();
    //c.CreateMap<IList<ClienteViewModel>, IList<ClienteModel>>();

    //Loja
    c.CreateMap<LojaModel, LojaViewModel>();
    c.CreateMap<LojaViewModel, LojaModel>();

    //Produto
    c.CreateMap<ProdutoViewModel, ProdutoModel>()
        .ForMember(p => p.ProdutosLojas, op => op.Ignore());
    c.CreateMap<ProdutoModel, ProdutoViewModel>();

});

IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);


builder.Services.AddScoped<IRepresentanteRepository, RepresentanteRepository>();
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IGerenteRepository, GerenteRepository>();
builder.Services.AddScoped<IFornecedorRepository, FornecedorRepository>();
builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<ILojaRepository, LojaRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseSession();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
