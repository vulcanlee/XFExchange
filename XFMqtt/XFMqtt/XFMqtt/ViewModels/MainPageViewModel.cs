using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace XFMqtt.ViewModels
{
    public class MainPageViewModel : BindableBase, INavigationAware
    {
        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }


        #region SendingMessage
        private string _SendingMessage="";
        /// <summary>
        /// SendingMessage
        /// </summary>
        public string SendingMessage
        {
            get { return this._SendingMessage; }
            set { this.SetProperty(ref this._SendingMessage, value); }
        }
        #endregion


        #region UserID
        private string _UserID = "";
        /// <summary>
        /// UserID
        /// </summary>
        public string UserID
        {
            get { return this._UserID; }
            set { this.SetProperty(ref this._UserID, value); }
        }
        #endregion


        #region SendingUserID
        private string _SendingUserID = "";
        /// <summary>
        /// SendingUserID
        /// </summary>
        public string SendingUserID
        {
            get { return this._SendingUserID; }
            set { this.SetProperty(ref this._SendingUserID, value); }
        }
        #endregion


        public DelegateCommand SendingCommand { get; set; }

        private readonly IEventAggregator _eventAggregator;

        public MainPageViewModel(IEventAggregator eventAggregator)
        {

            _eventAggregator = eventAggregator;

            _eventAggregator.GetEvent<ReceiveMessageEvent>().Subscribe(x =>
            {
                if(x.To == UserID)
                {
                    Title = $"接收到的訊息:{x.Content}";
                }
            });
            
            SendingCommand = new DelegateCommand(() =>
            {
                _eventAggregator.GetEvent<SendMessageEvent>().Publish(new MessageType
                {
                    Content = SendingMessage,
                    To = SendingUserID
                });
            });
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey("title"))
                Title = (string)parameters["title"] + " and Prism";
        }
    }
}
