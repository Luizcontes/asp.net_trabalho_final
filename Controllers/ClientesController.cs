using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using asp.net_trabalho_final.Models;

namespace asp.net_trabalho_final.Controllers;

public class ClientesController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {

        List<Cliente> clientes = new();

        try
        {
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
    public IActionResult Detalhes(int id)
    {

        Cliente cliente = null;

        try
        {
            using (var dbContext = new MyLocalDbContext())
            {
                cliente = dbContext.Clientes.Where(c => c.Id == id).Single();
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.ToString());
        }

        return View(cliente);
    }

    [HttpGet]
    public IActionResult Adicionar()
    {
        return View();
    }

    [HttpPost, ActionName("Adiciona")]
    public async Task<IActionResult> Adiciona(Cliente cliente)
    {

        cliente.Data = DateTime.Now;

        try
        {
            using (var dbContext = new MyLocalDbContext())
            {
                await dbContext.Clientes.AddAsync(cliente);
                await dbContext.SaveChangesAsync();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
        }

        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Eliminar(int id)
    {
        Cliente cliente;

        try
        {
            using (var dbContext = new MyLocalDbContext())
            {
                cliente = dbContext.Clientes.Where(c => c.Id == id).Single();
                dbContext.Clientes.Remove(cliente);
                await dbContext.SaveChangesAsync();
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.ToString());
        }

        return RedirectToAction("Index");
    }

    public IActionResult Atualizar(int id)
    {
        Cliente cliente = null;

        try
        {
            using (var dbContext = new MyLocalDbContext())
            {
                cliente = dbContext.Clientes.Where(c => c.Id == id).Single();
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.ToString());
        }

        return View(cliente);
    }

    [HttpPost, ActionName("Atualiza")]
    public async Task<IActionResult> Atualiza(int id, Cliente cliente)
    {

        Cliente clienteTmp;

        try
        {
            using (var dbContext = new MyLocalDbContext())
            {
                clienteTmp = dbContext.Clientes.Where(c => c.Id == id).Single();

                clienteTmp.Nome = cliente.Nome;
                clienteTmp.Morada = cliente.Morada;
                clienteTmp.CodigoPostal = cliente.CodigoPostal;
                clienteTmp.Localidade = cliente.Localidade;
                clienteTmp.Telefone = cliente.Telefone;
                clienteTmp.Email = cliente.Email;
                clienteTmp.Nif = cliente.Nif;
                clienteTmp.Saldo = cliente.Saldo;
                clienteTmp.Data = cliente.Data;

                dbContext.Clientes.Update(clienteTmp);
                await dbContext.SaveChangesAsync();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
        }

        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Movimentos(string Id)
    {
        Console.WriteLine(Id);
        return View();
    }

    [HttpPost, ActionName("Movimento")]
    public async Task<IActionResult> Movimento(int Id, Movimento movimento)
    {
        movimento.Data = DateTime.Now;
        // movimento.Id = int.Parse(Request.Query["id"]);

        Console.WriteLine(Id);

        try
        {
            using (var dbContext = new MyLocalDbContext())
            {
                await dbContext.Movimento.AddAsync(movimento);
                await dbContext.SaveChangesAsync();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
        }

        return RedirectToAction("Registros", new { id = movimento.Id });
    }

    [HttpGet]
    public IActionResult Registros(int id)
    {

        List<Movimento> movimentos = new();

        try
        {
            using (var dbContext = new MyLocalDbContext())
            {
                movimentos = dbContext.Movimento.ToList();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return BadRequest();
        }

        return View(movimentos);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}