using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Prism.Unity;
using Microsoft.Practices.Unity;
using uPLibrary.Networking.M2Mqtt;
using System.Net;
using uPLibrary.Networking.M2Mqtt.Messages;
using System.Text;
using Prism.Events;
using Newtonsoft.Json;

namespace XFMqtt.Droid
{
    [Activity(Label = "XFMqtt", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        string MQTT_BROKER_ADDRESS = "192.168.1.104";
        string strValue = "Hello";
        IEventAggregator fooEventAggregator;
        MqttClient client;
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.tabs;
            ToolbarResource = Resource.Layout.toolbar;

            base.OnCreate(bundle);

            MtqqInit();

            global::Xamarin.Forms.Forms.Init(this, bundle);
            var fooApp = new App(new AndroidInitializer());


            fooEventAggregator = fooApp.Container.Resolve<IEventAggregator>();

            fooEventAggregator.GetEvent<SendMessageEvent>().Subscribe(x =>
            {
                var fooValue = JsonConvert.SerializeObject(x);
                client.Publish("/home/temperature", Encoding.UTF8.GetBytes(fooValue), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, false);
            });

            LoadApplication(fooApp);
        }

        private void MtqqInit()
        {
            // create client instance 
            client = new MqttClient(MQTT_BROKER_ADDRESS);

            // register to message received 
            client.MqttMsgPublishReceived += Client_MqttMsgPublishReceived;

            string clientId = Guid.NewGuid().ToString();
            client.Connect(clientId);

            // subscribe to the topic "/home/temperature" with QoS 2 
            client.Subscribe(new string[] { "/home/temperature" }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });

        }

        private void Client_MqttMsgPublishReceived(object sender, uPLibrary.Networking.M2Mqtt.Messages.MqttMsgPublishEventArgs e)
        {
            var fooValue = Encoding.UTF8.GetString(e.Message);
            var fooMessageType = JsonConvert.DeserializeObject<MessageType>(fooValue);
            fooEventAggregator.GetEvent<ReceiveMessageEvent>().Publish(fooMessageType);
        }

        //static void client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        //{
        //    // handle message received 
        //}
    }

    public class AndroidInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IUnityContainer container)
        {

        }
    }
}

