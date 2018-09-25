using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Plugin.Messaging;
using Xamarin.Forms;

namespace XamarinMessDLT
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        void OnSMSButtonClicked(object sender, EventArgs e)
        {
            var sms = CrossMessaging.Current.SmsMessenger;

            if(sms.CanSendSms)
                sms.SendSms("+1 8509339186", "Testing Xamarin MessDLT Application");

        }

        void OnPhoneButtonClicked(object sender, EventArgs e)
        {
            var phoneDial = CrossMessaging.Current.PhoneDialer;

            if(phoneDial.CanMakePhoneCall)
                phoneDial.MakePhoneCall("+1 8509339186", "Matthew D. Miller");
        }

        void OnEmailButtonClicked(object sender, EventArgs e)
        {
            var sendEmail = CrossMessaging.Current.EmailMessenger;

            if(sendEmail.CanSendEmail)
                sendEmail.SendEmail("sysnom@gmail.com", "Testing Xamarin MessDLT application");


            // TODO iOS and Andriod
            // Have the ability to manually set up phone calls
            // email messages,and text messages

            //Construct HTML email
            // var email = new EmailMessageBuilder()
            //.To("to.plugins@xamarin.com
            //.Subject ("Xamarin Messaging Plugin")
            //.BodyAsHtml("Welcome Message from <a>Xam.Messaging.Plugin</a>
            //.Build();

        }
    }
}
