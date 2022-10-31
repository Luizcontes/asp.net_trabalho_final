using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using asp.net_trabalho_final.Models;
using System.Text.Encodings.Web;

namespace asp.net_trabalho_final.Controllers;

public class ClienteController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public ClienteController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IActionResult Index()
    {
        List<Cliente> clientes = new();

        try{
            using (var dbContext = new MyLocalDbContext())
            {
                clientes = dbContext.Clientes.ToList();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return BadRequest();
        }

        return View(clientes);
    }

    
    [HttpGet]
    public IActionResult Cliente(int Id, string Nome, string Morada, string CodigoPostal, string Localidade, string Telefone, string Email, long Nif, float Saldo, DateTime Data)
    {
        Models.Cliente cliente = new Models.Cliente()
        {
            Id = Id,
            Nome = Nome,
            Morada = Morada,
            CodigoPostal = CodigoPostal,
            Localidade = Localidade,
            Telefone = Telefone,
            Email = Email,
            Nif = Nif,
            Saldo = Saldo,
            Data = Data
        };

        return View(cliente);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}