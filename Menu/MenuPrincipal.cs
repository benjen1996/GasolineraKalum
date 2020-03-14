using static GasolineraKalum.Util.Printer;
using static System.Console;
using System;
using GasolineraKalum.Controllers;
using GasolineraKalum.Entities;

namespace GasolineraKalum.Menu
{
    public class MenuPrincipal
    {
        private GasolineraController controller = new GasolineraController();

        public void MostrarMenu()
        {
            try
            {
                int opcion = 0;
                do
                {
                    Clear();

                    WriteLine("Administracion de bombas");
                    WriteLine("1. Agregar");
                    WriteLine("2. Eliminar");
                    WriteLine("3. Buscar");
                    WriteLine("4. Listar");
                    WriteLine("5. Modificar");
                    WriteLine("0. Salir");
                    WriteLine("Ingrese una opcion  ==> ");
                    string respuesta = ReadLine();
                    opcion = Convert.ToByte(respuesta);
                    //una posible excepcion que escriban una cadena
                    switch (opcion)
                    {
                        case 1:
                            agregarTipoBomba();
                            break;
                        case 2:
                            eliminar();

                            break;
                        case 3:
                            buscar();
                            break;
                        case 4:
                            listarBombas();
                            break;
                        case 5:
                            modificar();
                            break;
                        case 0:
                            break;
                        default:
                            WriteTitle("No existe la opcion");
                            break;

                    }

                } while (opcion != 0);
            }
            catch (Exception e)
            {
                WriteLine(e.Message);
            }
        }
        private void agregarTipoBomba()  // se crea private porque sera utilizada dentro de la clase
        {
            WriteTitle("Tipo de Bomba");
            WriteLine("1. Super");
            WriteLine("2. Regular");
            WriteLine("3. Diesel");
            WriteLine("0. Salir");
            WriteLine("Seleccione una opcion ==>");
            string respuesta = ReadLine();
            if (respuesta.Equals("1"))
            {
                Bomba super = new Super();
                AgregarElemento(super);
            }
            else if (respuesta.Equals("2"))
            {
                Bomba regular = new Regular();
                AgregarElemento(regular);
            }
            else if (respuesta.Equals("3"))
            {
                Bomba diesel = new Diesel();
                AgregarElemento(diesel);
            }
        }
        private void AgregarElemento(Bomba elemento)
        {
            //estos son las 3 variables que tienen esto en comun
            WriteLine("Ingrese un precio");
            elemento.Precio = Convert.ToDouble(ReadLine());
            WriteLine("Ingrese una medida");
            elemento.Medida = ReadLine();
            WriteLine("Ingrese una capacidad");
            elemento.Capacidad = Convert.ToInt16(ReadLine());

            if (elemento.GetType() == typeof(Super))
            {
                WriteLine("Ingrese numero de aditivo");
                ((Super)elemento).Aditivo = Convert.ToInt16(ReadLine());
            }
            else if (elemento.GetType() == typeof(Diesel))
            {
                WriteLine("Ingrese Formula");
                ((Diesel)elemento).Formula = ReadLine();
            }
            controller.agregar(elemento);
        }

        private void listarBombas()
        {
            controller.listar();
            PresionarEnter();
        }
        private void eliminar()
        {
            controller.listar();
            WriteLine("Ingrese el ID a Eliminar");
            string id = ReadLine();
            Object elemento = buscar(id);
            if (elemento != null)
            {
                WriteLine("Esta Seguro de Eliminar (S/N)");
                string respuesta = ReadLine();
                if (respuesta.Equals("s"))
                {
                    controller.eliminar(elemento);
                    WriteLine("Registro Elminado!!!");
                    ReadKey();
                }
            }
        }
        private Object buscar(string id)
        {

            return controller.buscar(id);
        }

        public void buscar()
        {
            WriteLine("Ingrese el ID a buscar");
            string id = ReadLine();
            object elemento = controller.buscar(id);
            if (elemento != null)
            {
                WriteLine(elemento);
            }
            else
            {
                WriteLine("No existen registros");
            }
            ReadKey();
        }
        public void modificar()
        {
            controller.listar();
            WriteLine("Ingrese el ID");
            string id = ReadLine();
            Object elemento = buscar(id);
            if (elemento != null)
            {
                ((Bomba)elemento).Capacidad = 2020;
                WriteLine("Registro Modificado");

            }
            else
            {
                WriteLine("No Existen Registros");
            }
            ReadKey();
        }
    }





}