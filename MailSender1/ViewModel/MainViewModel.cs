using GalaSoft.MvvmLight;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using MailSender.lib.Services;
using MailSender.lib.Entities;
using System.Collections.ObjectModel;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using MailSender.lib.Services.Interfaces;
using MailSender1.Infrastructure.Services.Interfaces;

namespace MailSender1.ViewModel
{
    public class MainViewModel : ViewModelBase
    {

        private readonly IRecipientsManager _RecipientManager;
        private readonly IServerStore _ServerManager;
        private readonly ISenderStore _SenderManager;
        private readonly IMailStore _MailManager;
        private readonly ISenderEditor _SenderEditor;

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

        private ObservableCollection<Sender> _Senders;

        public ObservableCollection<Sender> Senders
        {
            get => _Senders;
            private set => Set(ref _Senders, value);
        }

        private ObservableCollection<Server> _Servers;

        public ObservableCollection<Server> Servers
        {
            get => _Servers;
            private set => Set(ref _Servers, value);
        }

        private ObservableCollection<Mail> _Mails;

        public ObservableCollection<Mail> Mails
        {
            get => _Mails;
            private set => Set(ref _Mails, value);
        }

        private Recipient _SelectedRecipient;

        public Recipient SelectedRecipient
            {
            get => _SelectedRecipient;
            set => Set(ref _SelectedRecipient, value);
            }


        private Sender _SelectedSender;

        public Sender SelectedSender
        {
            get => _SelectedSender;
            set => Set(ref _SelectedSender, value);
        }

        private Server _SelectedServer;

        public Server SelectedServer
        {
            get => _SelectedServer;
            set => Set(ref _SelectedServer, value);
        }

        private Mail _SelectedMail;

        public Mail SelectedMail
        {
            get => _SelectedMail;
            set => Set(ref _SelectedMail, value);
        }

        #region Commands

        public ICommand LoadRecipientsDataCommand { get; }
        public ICommand EditRecipientChangesCommand { get; }
        public ICommand SenderEditCommand { get; }

        #endregion

        public MainViewModel(IRecipientsManager RecipientManager,
            ISenderStore SenderManager,
            IServerStore ServerManager,
            IMailStore MailManager,
            ISenderEditor SenderEditor)
        {
            
            LoadRecipientsDataCommand = new RelayCommand(LoadRecipientsDataCommandExecuted, CanLoadRecipientsDataCommandExecute);
            EditRecipientChangesCommand = new RelayCommand<Recipient>(OnEditRecipientChangesCommandExecuted, CanEditRecipientChangesCommandExecute);
            SenderEditCommand = new RelayCommand<Sender>(OnSenderEditCommandExecuted, CanSenderEditCommandExecute);

            _RecipientManager = RecipientManager;
            _MailManager = MailManager;
            _SenderManager = SenderManager;
            _ServerManager = ServerManager;
            _SenderEditor = SenderEditor;
        }

        private bool CanLoadRecipientsDataCommandExecute() => true;
        private void LoadRecipientsDataCommandExecuted()
        {
            Recipients = new ObservableCollection<Recipient>(_RecipientManager.GetAll());
            Servers = new ObservableCollection<Server>(_ServerManager.GetAll());
            Mails = new ObservableCollection<Mail>(_MailManager.GetAll());
            Senders = new ObservableCollection<Sender>(_SenderManager.GetAll());
        }

        private bool CanEditRecipientChangesCommandExecute(Recipient recipient) => recipient != null;
        private void OnEditRecipientChangesCommandExecuted(Recipient recipient)
        {
            _RecipientManager.Edit(recipient);
            _RecipientManager.SaveChanges();
        }

        private bool CanSenderEditCommandExecute(Sender sender) => sender != null;
        private void OnSenderEditCommandExecuted(Sender sender)
        {
            _SenderEditor.Edit(sender);
        }
    }
}