using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CreateUserWithConsole.Models;

namespace CreateUserWithConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("¡Welcome to create user!");
            Console.WriteLine("Please wait");
            using (Models.bdsoftEntities database = new Models.bdsoftEntities())
            {
                try
                {
                    Models.Usuario oUser = new Models.Usuario()
                    {
                        Nombre = "Usuario",
                        Apellido = "de Prueba",
                        Cargo = "Administrador",
                        RolDeAcceso = "Admin",
                        UserName = "prueba",
                        Password = Encriptation.GetSHA256("prueba"),
                        Observacion = "Usuario de prueba generado por consola"
                    };
                    database.Usuarios.Add(oUser);
                    database.SaveChanges();
                    Console.WriteLine("User created successfully");
                    Console.WriteLine("Keypress enter for exit");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error" + ex.Message);
                }
            }
            Console.ReadKey();
        }
    }
}
