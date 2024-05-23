using System.Collections.Generic;
using System.IO;
using System.Windows.Input;
using Microsoft.Win32;
using PasswordManagerWPF.Commands.Passwords;
using PasswordManagerWPF.Core;
using PasswordManagerWPF.MVVM.Model;
using PasswordManagerWPF.MVVM.ViewModel.Menu.ImportAndExport.Strategies;
using PasswordManagerWPF.MVVM.ViewModel.Menu.ImportAndExport.Strategy;
using PasswordManagerWPF.MVVM.ViewModel.Menu.Passwords;
using PasswordManagerWPF.Services.Dialog;
using PasswordManagerWPF.Repositories;
using PasswordManagerWPF.Repositories.RepositoryFactory;
using PasswordManagerWPF.Services.Navigation;

namespace PasswordManagerWPF.MVVM.ViewModel.Menu.ImportAndExport
{
    public class ImportExportViewModel : ObservableObject
    {
        private readonly PasswordRepository _passwordRepository;
        private readonly IDialogService _dialogService;
        private INavigationService _navigationService;

        public ICommand ImportPasswordsCommand { get; }
        public ICommand ExportPasswordsCommand { get; }

        public ImportExportViewModel()
        {
            _passwordRepository = RepositoryFactory.GetInstance().GetPasswordRepository();
            _dialogService = new DialogService();
            _navigationService = new CustomNavigationService();

            ImportPasswordsCommand = new RelayCommand(ImportPasswordsCommandExecute);
            ExportPasswordsCommand = new RelayCommand(ExportPasswordsCommandExecute);
        }

        private void ImportPasswordsCommandExecute(object? obj)
        {
            var filePath = OpenFile("JSON files (*.json)|*.json|CSV files (*.csv)|*.csv");
            if (filePath == null) return;

            var strategy = CreateStrategyFromFilePath(filePath);
            var passwords = strategy.ImportPasswords(filePath);
            foreach (var password in passwords)
            {
                new AddPasswordCommand(password).Execute();
            }

            _dialogService.ShowMessage("Passwords imported successfully!", "Success", DialogType.Info);
            _navigationService.NavigateTo(new PasswordsViewModel());
        }

        private void ExportPasswordsCommandExecute(object? obj)
        {
            var filePath = SaveFile("JSON files (*.json)|*.json|CSV files (*.csv)|*.csv");
            if (filePath == null) return;

            var strategy = CreateStrategyFromFilePath(filePath);
            var passwords = _passwordRepository.GetItems();
            strategy.ExportPasswords(filePath, passwords);
            _dialogService.ShowMessage("Passwords exported successfully!", "Success", DialogType.Info);
        }

        private string? OpenFile(string filter)
        {
            var openFileDialog = new OpenFileDialog { Filter = filter };
            return openFileDialog.ShowDialog() == true ? openFileDialog.FileName : null;
        }

        private string? SaveFile(string filter)
        {
            var saveFileDialog = new SaveFileDialog { Filter = filter };
            return saveFileDialog.ShowDialog() == true ? saveFileDialog.FileName : null;
        }

        private IPasswordImportExportStrategy CreateStrategyFromFilePath(string filePath)
        {
            var format = Path.GetExtension(filePath).TrimStart('.').ToLower();
            return PasswordImportExportStrategyFactory.CreateStrategy(GetStrategy(format));
        }

        private PasswordImportExportStrategy GetStrategy(string format)
        {
            return format switch
            {
                "json" => PasswordImportExportStrategy.Json,
                "csv" => PasswordImportExportStrategy.Csv,
                _ => throw new NotSupportedException($"Format {format} is not supported")
            };
        }
    }
}
