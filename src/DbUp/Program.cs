namespace DbUp
{
    using System;
    using System.Reflection;

    class Program
    {
        static int Main(string[] args)
        {
            Console.WriteLine("Testing DbUp");

            const string ConnectionString = "Server=localhost;Port=5432;Database=dbMigration;User Id=postgres;Password=postgres;";

            EnsureDatabase.For.PostgresqlDatabase(ConnectionString);

            var upgrader =
                DeployChanges.To
                    .PostgresqlDatabase(ConnectionString)
                    .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
                    .LogToConsole()
                    .Build();

            var result = upgrader.PerformUpgrade();

            if (!result.Successful)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(result.Error);
                Console.ResetColor();
#if DEBUG
                Console.ReadLine();
#endif
                return -1;
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Success!");
            Console.ResetColor();
            Console.WriteLine("0");
            return 0;
        }
    }
}
