using Console_app.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

// Initialisation du ViewModel une seule fois
var viewModel = new MainViewModel();
bool continuer = true;

Console.WriteLine("=== CONVERTISSEUR PRO MVVM (.NET 10) ===");

do
{
    Console.WriteLine("\n--- Nouvelle conversion ---");
    Console.Write("Veuillez saisir votre texte (1-8 chars) : ");

    // Récupération de la saisie
    viewModel.InputText = Console.ReadLine();

    // Traitement
    if (viewModel.ProcessConversion())
    {
        Console.WriteLine($"Résultat : {viewModel.ResultText}");
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(viewModel.ErrorMessage);
        Console.ResetColor();
    }

    // --- LOGIQUE DE RELANCE ---
    Console.WriteLine("\nAppuyez sur 'R' pour Recommencer ou n'importe quelle autre touche pour Quitter.");

    // On lit la touche enfoncée sans l'afficher (true)
    var touche = Console.ReadKey(true).Key;

    if (touche != ConsoleKey.R)
    {
        continuer = false;
    }

} while (continuer);

Console.WriteLine("Merci d'avoir utilisé l'application. Fermeture...");