using Exercise.Business;
using System;

namespace Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                LogManager.Log(Enumerables.LogType.Error, "This is error 1");
                LogManager.Log(Enumerables.LogType.Error, "This is error 2");
                LogManager.Log(Enumerables.LogType.Warning, "This is warning 1");
                LogManager.Log(Enumerables.LogType.Warning, "This is warning 2");
                LogManager.Log(Enumerables.LogType.Message, "This is message 1");
                LogManager.Log(Enumerables.LogType.Message, "This is message 2");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Please press a key");
                Console.ReadKey();
            }
            
        }
    }
}
