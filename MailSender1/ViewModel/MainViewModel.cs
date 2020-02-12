using GalaSoft.MvvmLight;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using MailSender.lib.Services;
using MailSender.lib.Entities;
using System.Collections.ObjectModel;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using MailSender.lib.Services.Interfaces;

namespace MailSender1.ViewModel
{
    public class MainViewModel : ViewModelBase
    {

        private readonly IRecipientsManager _RecipientManager;

        private string _Title = "Рассыльщик почты";

        public string Title
        {
            get => _Title;
            set => Set(ref _Title, value);
        }


        private ObservableCollection<Recipient> _Recipients;

        public ObservableCollection<Recipient> Recipients
        {
            get => _Recipients;
            private set => Set(ref _Recipients, value);
        }

        private Recipient _SelectedRecipient;

        public Recipient SelectedRecipient
            {
            get => _SelectedRecipient;
            set => Set(ref _SelectedRecipient, value);
            }

        #region Commands

        public ICommand LoadRecipientsDataCommand { get; }
        public ICommand EditRecipientChangesCommand { get; }

        #endregion

        public MainViewModel(IRecipientsManager RecipientManager)
        {
            
            LoadRecipientsDataCommand = new RelayCommand(LoadRecipientsDataCommandExecuted, CanLoadRecipientsDataCommandExecute);
            EditRecipientChangesCommand = new RelayCommand<Recipient>(OnEditRecipientChangesCommandExecuted, CanEditRecipientChangesCommandExecute);
            _RecipientManager = RecipientManager;
        }

        private bool CanLoadRecipientsDataCommandExecute() => true;
        private void LoadRecipientsDataCommandExecuted()
        {
            Recipients = new ObservableCollection<Recipient>(_RecipientManager.GetAll());
        }

        private bool CanEditRecipientChangesCommandExecute(Recipient recipient) => recipient != null;
        private void OnEditRecipientChangesCommandExecuted(Recipient recipient)
        {
            _RecipientManager.Edit(recipient);
            _RecipientManager.SaveChanges();
        }
    }
}