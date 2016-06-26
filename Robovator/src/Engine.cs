using AForge.Video.DirectShow;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;

namespace Robovator.src
{
    public class Engine
    {
        public delegate void DeviceNewFrame(Bitmap bmp, String deviceName);
        public event DeviceNewFrame OnDeviceNewFrame;

        private static Engine engine = null;

        private FilterInfoCollection captureDevice; // Cameras
        private List<IProcModule> arrProcModule = new List<IProcModule>();
        private delegate void LineRecevidEvent(string command);
        private SerialPort encoderSerialPort = null;

        private Engine()
        {
            init();
        }

        public List<IProcModule> Modules
        {
            get { return this.arrProcModule; }
        }

        public void setPort(SerialPort encoderSerialPort)
        {
            this.encoderSerialPort = encoderSerialPort;
        }

        private void init()
        {
            captureDevice = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            // read device names from config file
            Dictionary<String, String> arrDeviceNamePath = new Dictionary<string, string>();

            int i = 1;
            foreach (FilterInfo Device in captureDevice)
            {
                arrDeviceNamePath.Add(Device.Name + i, Device.MonikerString);
                i++;
            }

            foreach (KeyValuePair<String, String> deviceName in arrDeviceNamePath)
            {
                try
                {
                    VideoCaptureDevice tmpVideoCaptureDevice = new VideoCaptureDevice(deviceName.Value);
                    if (tmpVideoCaptureDevice != null)
                    {
                        ProcModule tmpDevice = new ProcModule(deviceName.Key, deviceName.Value);
                        tmpDevice.setCamera(tmpVideoCaptureDevice);
                        tmpDevice.onNewFrame += (System.Drawing.Bitmap bmp) =>
                        {
                            if (OnDeviceNewFrame != null)
                                OnDeviceNewFrame(bmp, deviceName.Key);
                        };
                        tmpDevice.onNewArr += tmpDevice_onNewArr;
                        arrProcModule.Add(tmpDevice);
                    }
                    else
                    {
                        // error, device not found
                    }
                }
                catch (Exception ex)
                {

                }
            }
        }

        void tmpDevice_onNewArr(int id, byte[] data)
        {
            
        }

        public List<String> getDeviceNames()
        {
            List<String> retVal = new List<string>();
            foreach (FilterInfo Device in captureDevice)
                retVal.Add(Device.Name);
            return retVal;
        }

        Timer t = null;
        public void start()
        {
            /////////////////////////////////////////////
            t = new Timer((obj) =>
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback((obj2) =>
                {
                    foreach (IProcModule module in arrProcModule)
                        module.encoderTick();
                }));
            }, null, 1000, 200);
            /////////////////////////////////////////////

            if (!encoderSerialPort.IsOpen)
                encoderSerialPort.Open();
            else
                encoderSerialPort.DataReceived += encoderSerialPort_DataReceived;

            foreach (IProcModule module in arrProcModule)
                module.start();
        }

        void encoderSerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {

            String encoderData = encoderSerialPort.ReadLine();
            if (!String.IsNullOrEmpty(encoderData))
            {
                encoderData = encoderData.Trim('\r', '\n', '\t').ToLower();
                switch (encoderData)
                {
                    case "1":
                        {
                            /////////////////////////////////////////////
                            //ThreadPool.QueueUserWorkItem(new WaitCallback((obj) =>
                            //{
                            //    foreach (IProcModule module in arrProcModule)
                            //        module.encoderTick();
                            //}));
                            /////////////////////////////////////////////
                            break;
                        }

                    default:
                        { throw new ArgumentException("Encoder data not valid!"); }
                }
            }
        }

        public void stop()
        {
            foreach (IProcModule module in arrProcModule)
                module.stop();
        }

        public static Engine getInstance()
        {
            if (engine == null)
                engine = new Engine();
            return engine;
        }
    }
}
