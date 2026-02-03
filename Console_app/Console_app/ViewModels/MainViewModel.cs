using System;
using System.Collections.Generic;
using System.Text;

using Console_app.Models;

namespace Console_app.ViewModels;

public class MainViewModel
{
    // Propriétés privées (Encapsulation)
    private readonly StringConverter _converter;
    private const int MaxLength = 8; // On évite les "chiffres magiques" dans le code

    // Propriétés publiques (Interface pour la Vue)
    public string? InputText { get; set; }
    public string ResultText { get; private set; } = string.Empty;
    public string ErrorMessage { get; private set; } = string.Empty;

    public MainViewModel()
    {
        _converter = new StringConverter();
    }

    /// <summary>
    /// Exécute la logique métier si les règles de validation sont respectées.
    /// </summary>
    public bool ProcessConversion()
    {
        if (Validate())
        {
            ResultText = _converter.ConvertToUpperCase(InputText);
            ErrorMessage = string.Empty;
            return true;
        }
        return false;
    }

    // Méthode de validation privée (Interne au ViewModel)
    private bool Validate()
    {
        if (string.IsNullOrWhiteSpace(InputText))
        {
            ErrorMessage = "La saisie ne peut pas être vide.";
            return false;
        }

        if (InputText.Length > MaxLength)
        {
            ErrorMessage = $"La saisie dépasse la limite autorisée de {MaxLength} caractères.";
            return false;
        }

        return true;
    }
}