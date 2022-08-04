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

});

IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);


builder.Services.AddScoped<IRepresentanteRepository, RepresentanteRepository>();
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IGerenteRepository, GerenteRepository>();
builder.Services.AddScoped<IFornecedorRepository, FornecedorRepository>();
builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
