using System;
using System.Data.SQLite;
using System.Globalization;

namespace SQLDemo
{
    internal class Program
    {

        static void Main()
        {
            Console.WriteLine("1. Display Database\n" +
                              "2. Insert Travel\n" +
                              "3. Delete Travel\n" +
                              "4. Display Travel:\n" +
                              "5. Update Travel:\n" +
                              "0. Exit program");

            int i;

            do
            {
                i = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("\n");

                if (i == 1)
                {
                    SQLiteConnection sQLiteConnection = CreateConnection();
                    ReadData(sQLiteConnection);
                    Console.WriteLine("\nThe average cost of the travels are:\n" + AverageCost(sQLiteConnection));
                }
                else if (i == 2)
                {
                    Console.WriteLine("\nInserting Data\n");

                    SQLiteConnection sQLiteConnection = CreateConnection();
                    CreateTable(sQLiteConnection);
                    InsertData(sQLiteConnection);
                }
                else if (i == 3)
                {
                    Console.WriteLine("\nDelete Travel:\n");
                    int id = Convert.ToInt32(Console.ReadLine());

                    SQLiteConnection sQLiteConnection = CreateConnection();
                    DeletePlaces(sQLiteConnection, id);
                }
                else if (i == 4)
                {
                    Console.WriteLine("\nDisplay travel to:\n");
                    string place = Convert.ToString(Console.ReadLine());

                    SQLiteConnection sQLiteConnection = CreateConnection();
                    ReadDataPlaces(sQLiteConnection, place);
                }
                else if (i == 5)
                {
                    Console.WriteLine("\nUpdate travel:\n");
                    int id = Convert.ToInt32(Console.ReadLine());

                    SQLiteConnection sQLiteConnection = CreateConnection();

                }
                else if (i == 0)
                {
                    Console.WriteLine("Exiting the program.");
                }
                else
                {
                    Console.WriteLine("Wrong option.");
                }

                Console.WriteLine("\nNext option: ");

            } while (i != 0);

        }

        static SQLiteConnection CreateConnection()
        {
            SQLiteConnection sqlite_conn;
            sqlite_conn = new SQLiteConnection("Data Source=database.db; Version = 3; New = True; Compress = True; ");

            try
            {
                sqlite_conn.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Database not found");
            }

            return sqlite_conn;
        }

        static void CreateTable(SQLiteConnection connection)
        {
            SQLiteCommand sqlCommand;

            string strCosts = "CREATE TABLE if not exists Costs(id INTEGER PRIMARY KEY AUTOINCREMENT, cost DOUBLE, place_id INT)";
            string strPlaces = "CREATE TABLE if not exists Places(id INTEGER PRIMARY KEY AUTOINCREMENT, place VERCGAR(20), date VARCHAR(20))";

            sqlCommand = connection.CreateCommand();

            sqlCommand.CommandText = strCosts;
            sqlCommand.ExecuteNonQuery();

            sqlCommand.CommandText = strPlaces;
            sqlCommand.ExecuteNonQuery();

            connection.Close();
        }
        static void InsertData(SQLiteConnection conn)
        {
            Console.Write("Enter the place: ");
            string place = Console.ReadLine();

            Console.Write("Enter the date: ");
            string date1 = Console.ReadLine();

            Console.Write("Enter the cost: ");
            NumberFormatInfo provider = new NumberFormatInfo
            {
                NumberDecimalSeparator = "."
            };
            double cost = Convert.ToDouble(Console.ReadLine(), provider);

            SQLiteCommand sqlite_cmd;

            conn.Open();

            sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = "INSERT INTO Places(place, date) VALUES('" + place + "','" + date1 + "' ); ";
            sqlite_cmd.ExecuteNonQuery();

            SQLiteDataReader sqlite_datareader;

            sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = "SELECT * FROM Places ";
            sqlite_datareader = sqlite_cmd.ExecuteReader();

            int place_id = 0;
            while (sqlite_datareader.Read())
            {
                place_id = (int)sqlite_datareader.GetInt64(0);
            }

            sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = "INSERT INTO Costs(cost, place_id) VALUES(" + cost + "," + place_id + " ); ";
            sqlite_cmd.ExecuteNonQuery();

            conn.Close();
        }
        static void ReadData(SQLiteConnection conn)
        {
            SQLiteDataReader sqlite_datareader;
            SQLiteCommand sqlite_cmd;

            sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = "SELECT places.id, places.place, places.date, costs.cost FROM Places, Costs WHERE places.id = costs.place_id";
            sqlite_datareader = sqlite_cmd.ExecuteReader();

            while (sqlite_datareader.Read())
            {
                int col0 = (int)sqlite_datareader.GetInt64(0);
                string col1 = sqlite_datareader.GetString(1);
                string col2 = sqlite_datareader.GetString(2);
                double col3 = sqlite_datareader.GetDouble(3);

                Console.WriteLine("{0} {1} {2} {3}", col0, col1, col2, col3);
            }
            conn.Close();
        }
        static void ReadDataPlaces(SQLiteConnection conn, string place)
        {
            SQLiteDataReader sqlite_datareader;
            SQLiteCommand sqlite_cmd;

            sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = "SELECT places.place, places.date, costs.cost FROM Places, Costs WHERE places.id = costs.place_id and " + "'" + place + "' = places.place;";

            sqlite_datareader = sqlite_cmd.ExecuteReader();
            while (sqlite_datareader.Read())
            {
                string col1 = sqlite_datareader.GetString(0);
                string col2 = sqlite_datareader.GetString(1);
                double col0 = sqlite_datareader.GetDouble(2);

                Console.WriteLine("{0} {1} {2}", col0, col1, col2);
            }

            conn.Close();
        }

        static void DeletePlaces(SQLiteConnection conn, int id)
        {
            SQLiteCommand sqlite_cmd;
            sqlite_cmd = conn.CreateCommand();

            SQLiteCommand sqlite_cmd_2;
            sqlite_cmd_2 = conn.CreateCommand();

            sqlite_cmd.CommandText = "Delete FROM Places WHERE places.id = " + id + " ;";
            sqlite_cmd_2.CommandText = "Delete FROM Costs WHERE costs.place_id = " + id + " ;";

            sqlite_cmd.ExecuteNonQuery();
            sqlite_cmd_2.ExecuteNonQuery();

            conn.Close();
        }

        static double AverageCost(SQLiteConnection conn)
        {
            SQLiteDataReader sqlite_datareader;
            SQLiteCommand sqlite_cmd;
            conn.Open();

            sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = "SELECT costs.cost FROM Costs, Places WHERE places.id = costs.place_id";
            sqlite_datareader = sqlite_cmd.ExecuteReader();

            double total = 0, count = 0;

            while (sqlite_datareader.Read())
            {
                double cost = sqlite_datareader.GetDouble(0);

                total += cost;
                count++;
            }

            conn.Close();
        
            return total / count;
        }
    }
}
       