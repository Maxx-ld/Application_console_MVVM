using System;
using System.Collections.Generic;
using System.Text;

namespace Console_app.Models; // Namespace de fichier : tout le fichier appartient à ce namespace

// Le Modèle : Logique métier pure
public class StringConverter
{
    // Vérifie bien que le nom est exactement : ConvertToUpperCase
    public string ConvertToUpperCase(string? input)
    {
        return input?.ToUpper() ?? string.Empty;
    }
}