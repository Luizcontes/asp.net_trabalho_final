var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();


// using System;
// using System.Globalization;
// using System.Text;
// using asp.net_trabalho_final.Models;
// using System.Data;
// using MySql.Data.MySqlClient;

// namespace asp.net_trabalho_final
// {
//     public class Program
//     {
//         private const string DB_CONNECTION_STRING = "server=localhost;port=3306;database=MyLocalDb;user=teste;password=5noSRIdmm@";

//         static void Main()
//         {


            // CultureInfo.CurrentCulture = new CultureInfo("pt-PT");
            // Console.OutputEncoding = Encoding.Default;

            // MySqlConnection connection = new MySqlConnection(DB_CONNECTION_STRING);

            // try
            // {

            //     Console.WriteLine("A ligar ao servidor...");

            //     connection.Open();

            //     Console.WriteLine("Ligado a BD!");

            //     string _nome = "Luiz";
            //     string _morada = "Rua dos passarinhos";
            //     float _saldo = 2.1F;

            //     // Console.WriteLine(_saldo);

            //     string sqlQuery = $"INSERT INTO MyTable (nome, morada, saldo) VALUES ('{_nome}', '{_morada}', '{_saldo}')";


            //     MySqlCommand command = new MySqlCommand()
            //     {
            //         Connection = connection,
            //         CommandType = CommandType.Text,
            //         CommandText = sqlQuery
            //     };

            //     if (command.ExecuteNonQuery() == 1)
            //     {
            //         Console.WriteLine("Valores inseridos...");
            //     }

            //     connection.Close();


            // }
            // catch (Exception e)
            // {
            //     Console.WriteLine(e.Message);
            // } finally {
            //     Console.WriteLine("Chupar cu e bom!!!");
            // }


//         }

//     }
// }