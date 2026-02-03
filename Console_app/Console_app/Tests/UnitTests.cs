using Console_app.Models;
using Console_app.ViewModels;

namespace Console_app.Tests;

public class Tester
{
    public static void RunTests()
    {
        Console.WriteLine("\n--- DÉMARRAGE DES TESTS DE RECETTE ---");

        int testsPasses = 0;
        var vm = new MainViewModel();

        // Liste des tests (Saisie, Attendu)
        var casDeTests = new Dictionary<string, string>
        {
            { "maison", "MAISON" },
            { "Corse123", "CORSE123" },
            { "%&ciel", "%&CIEL" },
            { "!*port", "!*PORT" }
        };

        foreach (var test in casDeTests)
        {
            vm.InputText = test.Key;
            vm.ProcessConversion();

            if (vm.ResultText == test.Value)
            {
                Console.WriteLine($"[OK] Saisie: {test.Key} -> {vm.ResultText}");
                testsPasses++;
            }
            else
            {
                Console.WriteLine($"[KO] Saisie: {test.Key} (Attendu: {test.Value}, Reçu: {vm.ResultText})");
            }
        }

        Console.WriteLine($"\nBilan : {testsPasses}/{casDeTests.Count} tests réussis.");
        Console.WriteLine("---------------------------------------\n");
    }
}