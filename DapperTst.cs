
using Dapper;
using System.ComponentModel;
using System.Data.SqlClient;

public class DapperTSt
{
    string connectionString = "Data Source=L-IT-0064; Database=DapperTest; Integrated Security=SSPI";

    public void Executescalar()
    {
        using (var connection = new SqlConnection(connectionString))
        {
            var sql = "SELECT Count(*) FROM Orders";
            var books = connection.ExecuteScalar(sql);
            Console.WriteLine($"Total products: {books}");
            // will give an single colum single row like res etc with an count 



        }

        using (var connection = new SqlConnection(connectionString))
        {
            var sql = "SELECT count(*) FROM Orders";
            var res = connection.ExecuteScalar<int>(sql);
            Console.WriteLine($"Total products: {res}");
            // will give an single colum single row like res etc with an count with integer 
        }

    }

    public void Querysingle()
    {

        using (var connection = new SqlConnection(connectionString))
        {
            var sql = "SELECT  * FROM Orders where itemid=1";
            var res = connection.QuerySingle(sql);
            //var res = connection.QuerySingle<AddingNewEventArgs class obj>(sql);

            Console.WriteLine($"Total products: {res}");
            // will give an  single row like res etc with an type 
        }
        using (var connection = new SqlConnection(connectionString))
        {
            var sql = "SELECT  * FROM Orders where itemid=1";
            var res = connection.QuerySingleOrDefault(sql);

            Console.WriteLine($"Total products: {res}");
            // will give an  single row if no rows are matched then it returns default value null
        }
    }

    public void QueryFirst()
    {
        using (var connection = new SqlConnection(connectionString))
        {
            var sql = "SELECT  * FROM Orders order by itemid desc";
            var res = connection.QueryFirst(sql);

            Console.WriteLine($"Total products: {res}");
            // will give first row from dataabse
        }
        using (var connection = new SqlConnection(connectionString))
        {
            var sql = "SELECT  * FROM Orders order by itemid desc";
            var res = connection.QueryFirstOrDefault(sql);

            Console.WriteLine($"Total products: {res}");
            // will give first row from dataabse and will give null if no rows are avaliable
        }

    }

    public void Query()
    {
        using (var SqlConnection = new SqlConnection(connectionString))
        {
            var sql = "SELECT  * FROM Orders order by itemid desc";
            var result = SqlConnection.Query(sql);
            foreach (var item in result)
            {
                Console.WriteLine(item);
                //will get all the rows from data table

            }
        }
    }

    public void Multiple()
    {
        string sql = "SELECT  * FROM Orders order by itemid desc; SELECT  * FROM Orders order by itemid Asc; SELECT  * FROM Orders order by itemid Asc;";
        using (var connection = new SqlConnection(connectionString))
        {
            using (var multi = connection.QueryMultiple(sql))
            {
                var invoice = multi.Read();
                var invoiceItems = multi.Read();
                var invoiceItem = multi.Read();

                foreach (var item in invoice)
                {
                    Console.WriteLine(item);

                }
                foreach (var item in invoiceItems)
                {
                    Console.WriteLine(item);

                }
                foreach (var item in invoiceItem)
                {
                    Console.WriteLine(item);

                }

            }
            // query multipe is used for selecting multiple tables
        }
    }

    public void QuerySpecific()
    {
        string sql = "SELECT  itemid,itemName FROM Orders order by itemid desc;";

        using (var connection = new SqlConnection(connectionString))
        {
            var res = connection.Query(sql);
            foreach (var item in res)
            {
                Console.WriteLine(item);

            }
            // returns all the selected colum names
        }


    }

    public void Executeq()
    {
        string sql = "Insert into Orders values ('check',2,100)";
        using (var connection = new SqlConnection(connectionString))
        {
            var res = connection.Execute(sql);
            Console.WriteLine("done");
           
        }
        // it doesnt return any values 
    }
}