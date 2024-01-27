using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ADO.NETCrud
{
    public  class Program
    {


        SqlConnection con;

       public  Program() {

            try
            {
                con = new SqlConnection("data source=DESKTOP-SAH8P7K\\SQLEXPRESS;database=Student;integrated security=true");
                con.Open();
                if (con.State==System.Data.ConnectionState.Open)
                {
                    Console.WriteLine("Connection Established...");
                }
                else
                { 
                    Console.WriteLine("Something went wrong...");    
                }

                Console.ReadKey();
            
            }
            catch(Exception e) {
                Console.WriteLine(e.Message);
            }
               
        }


        public void CreateTable()
        {
            try
            {
                
                SqlCommand cmd = new SqlCommand("CREATE TABLE Student (id INT PRIMARY KEY, first_name VARCHAR(100), last_name VARCHAR(100), Email VARCHAR(100), Mobile BIGINT NOT NULL)", con);

                
                cmd.ExecuteNonQuery();
                Console.WriteLine("Table created successfully...");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Oops, something went wrong...");
            }
           
        }

        public void Insert()
        {
            try
            {
               
                SqlCommand cmd = new SqlCommand("insert into Student(id,first_name,last_name,Email,Mobile)values(111,'Mayur','purushottam','mayur@purushottam.com',9874521046) ", con);

                cmd.ExecuteNonQuery();

                Console.WriteLine("Record Inserted Successfully....");
            }
            catch(Exception e) {

                Console.WriteLine("Something went wrong.."+e.Message);
                    
                    }
        }

        public void Delete()
        {
            try {
                SqlCommand cmd = new SqlCommand("Delete from Student where id=111", con);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Record deleted successfully...");
            }
            catch(Exception e ) 
            {
                Console.WriteLine("Something went wrong.."+e.Message);
              }
       
        }

        public void Update()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("update Student set first_name='shaikh',Email='omar@shaikh.com' where id=101",con);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Record updated successfully...");
            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong"+e.Message);
            }
        
        }

        public void Select()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("Select * from Student",con);
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    Console.WriteLine(rd["id"] + " " + rd["first_name"] + " " + rd["last_name"] + " " + rd["Email"] + " " + rd["Mobile"]);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong" + e.Message);
            }
           
        }

        public static void Main(string[] args)
        {
            Boolean quit = false;
          
            int choice;

            
            Program pg= new Program();
            do
            {
                Console.WriteLine("1\t Create ...");
                Console.WriteLine("2\t Insert ...");
                Console.WriteLine("3\t Delete ...");
                Console.WriteLine("4\t Update ...");
                Console.WriteLine("5\t Select ...");
                Console.WriteLine("0\t Exit ...");

                Console.WriteLine("please enter your choice");

                choice = Convert.ToInt32(Console.ReadLine());

                if(choice==0)
                    quit=true;

                switch (choice)
                {
                    case 1:
                        pg.CreateTable();
                        break;

                    case 2:
                        pg.Insert();
                        break;

                    case 3:
                        pg.Delete();
                        break;

                    case 4:
                        pg.Update(); 
                        break;

                    case 5:
                        pg.Select();
                        break;


                    case 0:
                        quit=true;
                        break;

                    default:
                        Console.WriteLine("invalid choice");
                        break;
                }
            } while (!quit);
            
          pg.con.Close();   
              
        }
    }
}
