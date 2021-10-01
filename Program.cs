using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConnectionDll;

namespace RestaurantSystem
{
    class Program
    {
        
        static void Main(string[] args)
        {

            //Console.WriteLine("Working on Database Connectivity");
            int choose;
            char co;
            char r, s;
            Connection.CreateConnection();
            //Console.WriteLine("Enter User Name");
            //string username = Console.ReadLine();
            //Console.WriteLine("Enter Password:");
            //string pass = Console.ReadLine();
            //if (Connection.Validate(username, pass) == true)
            //{

           

            Console.WriteLine("\n");

                Console.WriteLine("\t\t\t\t%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%");
                Console.WriteLine("\t\t\t\t*\t\t\t\t\t\t\t\t\t*");
                Console.WriteLine("\t\t\t\t*\t\t\t\t\t\t\t\t\t*");
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("\t\t\t\t@\t\t\t RESTAURANT SYSTEM \t\t\t\t@");
                Console.ResetColor();
                Console.WriteLine("\t\t\t\t*\t\t\t\t\t\t\t\t\t*");
                Console.WriteLine("\t\t\t\t*\t\t\t\t\t\t\t\t\t*");
                Console.WriteLine("\t\t\t\t%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();


                do
                {
                    Console.WriteLine("\t\t\t\t\t\t\t\tHere Are Some Active Restaurants\n");
                    Connection.ActiveRestaurants();
                    Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");
                    //Console.WriteLine("\n");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("\t\t\t\t\t\t\t\t\tMENU");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("\t\t\t\t\t\t\t\t1.Search Restaurant\n\t\t\t\t\t\t\t\t2.Add Restaurant\n\t\t\t\t\t\t\t\t3.Update Restaurant\n\t\t\t\t\t\t\t\t4.Delete Restaurant");
                   
                    Console.ResetColor();

                    Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");
                    Console.WriteLine("\n");
                    Console.WriteLine("\n");
                    Console.WriteLine("Enter Your Choice");
                    choose = Convert.ToInt32(Console.ReadLine());
                    switch (choose)
                    {
                        case 1:

                            do
                            {
                                Console.WriteLine();
                               
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                
                                //Console.WriteLine("\t\t\t\t*************************************************************************");
                                Console.WriteLine("Enter Restaurant Name To Search");
                                string sr = Console.ReadLine();
                                Connection.SearchRestaurant(sr);
                                //Console.WriteLine("\t\t\t\t*************************************************************************");
                                Console.ResetColor();
                                Console.WriteLine("Do you want to contionue press Y or N");
                                co = Convert.ToChar(Console.ReadLine());
                            } while (co != 'N');

                            break;
                        case 2:
                            do
                            {
                                
                                Console.WriteLine("\t\t\t\t*************************************************************************");
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.WriteLine("\t\t\t\t\t\t\t\tEnter The Restaurant Details");
                                Console.ResetColor();
                                Console.WriteLine("\t\t\t\t*************************************************************************");
                                Console.WriteLine("Enter Restaurant Name");
                                string Restnm = Console.ReadLine();
                                Console.WriteLine("Enter Restaurant OpeningTime");
                                string RestOpen = Console.ReadLine();
                                Console.WriteLine("Enter Restaurant ClosingTime");
                                string RestClose = Console.ReadLine();
                                Console.WriteLine("Enter Restaurant Phone Number");
                                string RestPhno = Console.ReadLine();
                                Console.WriteLine("Enter Restaurant Address");
                                string RestAdrr = Console.ReadLine();
                                Console.WriteLine("Enter Restaurant Cuisin");
                                string RestCn = Console.ReadLine();
                                Console.WriteLine("Enter Restaurant Name");
                                string RestSts = Console.ReadLine();
                                Connection.AddRestaurant(Restnm,RestOpen,RestClose,RestPhno,RestAdrr,RestCn,RestSts);
                               
                                Console.WriteLine();
                                Console.WriteLine("Do you want to continue press Y or N");
                                s = Convert.ToChar(Console.ReadLine());
                                


                            } while (s != 'N');


                            break;
                        case 3:
                            do
                            {
                                Console.WriteLine();
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.WriteLine("\t\t\t\t*************************************************************************");
                                Console.WriteLine("\t\t\t\t\t\t\t\tEnter Restaurant Name To Update");
                                Console.WriteLine("Enter Restaurants Name");
                                string oldName = Console.ReadLine();
                                Console.WriteLine("Enter Restaurants New Name");
                                string updName = Console.ReadLine();
                                Connection.UpdateRestaurant(updName, oldName);
                                Console.WriteLine("\t\t\t\t*************************************************************************");
                                Console.ResetColor();
                                Console.WriteLine("Do you want to contionue press Y or N");
                                co = Convert.ToChar(Console.ReadLine());
                            } while (co != 'N');

                            break;
                        case 4:
                            do
                            {
                                Console.WriteLine();
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("\t\t\t\t*************************************************************************");
                                Console.WriteLine("\t\t\t\t\t\t\t\tEnter Restaurant Name To Delete");
                                Console.WriteLine("Enter Restaurant Name");
                                string dlName = Console.ReadLine();
                                Connection.DeleteRestaurant(dlName);
                                Console.WriteLine("\t\t\t\t*************************************************************************");
                                Console.ResetColor();
                                Console.WriteLine("Do you want to contionue press Y or N");
                                co = Convert.ToChar(Console.ReadLine());
                            } while (co != 'N');

                            break;

                        default:
                            Console.WriteLine("Invalid Choice");
                            break;

                    }
                    Console.WriteLine("Do you want to continue enter Y or N");
                    r = Convert.ToChar(Console.ReadLine());

                } while (r != 'N');
            //}
            //else
            //{
            //    Console.WriteLine("Login Failed!!!");
            //}
            Console.ReadLine();
        }
    }
}
