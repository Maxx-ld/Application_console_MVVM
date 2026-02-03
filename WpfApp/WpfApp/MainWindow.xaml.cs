using System.Windows;
using Console_app.ViewModels; // - On appelle ton travail de la V1

namespace WpfApp;

public partial class MainWindow : Window
{
    // On crée une instance unique de ton ViewModel pour toute la fenêtre
    private readonly MainViewModel _viewModel = new(); //

    public MainWindow()
    {
        InitializeComponent();
    }

    // Cette méthode est appelée lors du clic sur le bouton "CONVERTIR"
    private void OnConvertClick(object sender, RoutedEventArgs e)
    {
        // 1. On envoie le texte tapé dans la Box au ViewModel
        _viewModel.InputText = InputBox.Text; //

        // 2. On lance la vérification et la conversion
        if (_viewModel.ProcessConversion()) //
        {
            // Si c'est OK : On affiche le résultat et on efface les erreurs
            ResultBox.Text = _viewModel.ResultText;
            ErrorLabel.Text = "";
        }
        else
        {
            // Si c'est KO : On vide le résultat et on affiche l'erreur
            ResultBox.Text = "";
            ErrorLabel.Text = _viewModel.ErrorMessage;
        }
    }
}