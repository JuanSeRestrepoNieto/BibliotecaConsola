namespace Biblioteca.Common;

public static class Logger
{
  public static void Log(string message)
  {
    Console.WriteLine(message);
  }

  public static void Info(string message)
  {
    Console.WriteLine($"ℹ️  {message}");
  }

  public static void Success(string message)
  {
    Console.WriteLine($"✅ {message}");
    Pause();
  }

  public static void Error(string message)
  {
    Console.WriteLine($"❌ {message}");
    Pause();
  }

  public static void Warning(string message)
  {
    Console.WriteLine($"⚠️  {message}");
  }

  public static void Pause()
  {
    Console.WriteLine();
    Console.Write("Presione cualquier tecla para continuar...");
    Console.ReadKey();
  }
}