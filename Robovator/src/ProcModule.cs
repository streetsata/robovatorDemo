using AForge;
using AForge.Imaging;
using AForge.Imaging.Filters;
using AForge.Video;
using AForge.Video.DirectShow;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading;
using Robovator.src;
using Robovator;

namespace Robovator.src
{
    public class FilterProp
    {
        public volatile float filterYmin = 0;
        public volatile float filterYmax = 1000;
        public volatile float filterCbmin = -500;
        public volatile float filterCbmax = 500;
        public volatile float filterCrmin = -500;
        public volatile float filterCrmax = 500;

       
    }

    public class ProcModule : IProcModule
    {

        private byte[] arr = new byte[240];
        private FilterProp filterProp = new FilterProp();
        private Rectangle[] rects;
        private int objectCount = 0;
        private int totalObjectCount = 0;
        private VideoCaptureDevice finalFrame = null;
        private String deviceName = null;
        private String devicePath = null;
        private Grayscale grayscaleFilter = new Grayscale(0.2125, 0.7154, 0.0721);
        private BlobCounter blobCounter = new BlobCounter();
        public delegate void OnNewFrame(Bitmap bmp);
        public event OnNewFrame onNewFrame;
        private volatile int encoderCount = 0;

        public int EncoderCount
        {
            get { return encoderCount; }
            set { encoderCount = value; }
        }
        private int distanceToTheMechanism = 0;
        private int delayBeforeTheObject = 0;
        private int delayAfterTheObject = 0;
        private int unionObject = 0;
        private int frequencyResponse = 1;
        private volatile Queue<Byte> quObj = new Queue<Byte>();
        private int blobCounterMinWidth = 0;
        private int blobCounterMinHeight = 0;
        private Size resolution = Size.Empty;
        private int camFPS = -1;

        public byte[] Arr { get { return arr; } set { arr = value; } }
        public int ObjectCount { get { return objectCount; } }
        public int TotalObjectCount { get { return totalObjectCount; } }
        public int UnionObject { get { return unionObject; } set { unionObject = value; } }
        public Queue<Byte> QuObj { get { return quObj; } set { quObj = value; } }
        public FilterProp FilterSettings { get { return filterProp; } set { filterProp = value; } }
        public int CamFPS { get { return camFPS; } }
        public Size Resolution { get { return resolution; } }
        public int FrequencyResponse { get { return frequencyResponse; } set { frequencyResponse = value; } }
        public ProcModule(String deviceName, String devicePath) { this.deviceName = deviceName; this.devicePath = devicePath; }
        public int BlobCounterMinWidth { get { return blobCounterMinWidth; } set { blobCounterMinWidth = value; } }
        public int BlobCounterMinHeight { get { return blobCounterMinHeight; } set { blobCounterMinHeight = value; } }
        public String DeviceName { get { return this.deviceName; } }

        public void setCamera(VideoCaptureDevice device)
        {
            this.finalFrame = device;
            this.finalFrame.NewFrame += workDevice_NewFrame;
            finalFrame.VideoResolution = finalFrame.VideoCapabilities[6];
            this.resolution = new Size(finalFrame.VideoResolution.FrameSize.Width, finalFrame.VideoResolution.FrameSize.Height);
            this.camFPS = finalFrame.VideoCapabilities[6].AverageFrameRate;
        }

        void workDevice_NewFrame(object sender, AForge.Video.NewFrameEventArgs eventArgs)
        {
            if (encoderCount >= frequencyResponse)
            {
                encoderCount = 0;
                if (this.onNewFrame != null)
                {
                    Bitmap frameFilter = (Bitmap)eventArgs.Frame.Clone();

                    UnmanagedImage grayImage = workFilter(ref frameFilter);

                    Rectangle[] rects = workBlobs(grayImage, ref frameFilter);

                    ThreadPool.QueueUserWorkItem(new WaitCallback((obj) =>
                    {
                        this.onNewFrame(frameFilter);
                    }));
                }
            }
        }

        private UnmanagedImage workFilter(ref Bitmap frameFilter)
        {
            // create filter
            YCbCrFiltering filter = new YCbCrFiltering();
            // set color ranges to keep
            filter.Y = new Range(filterProp.filterYmin, filterProp.filterYmax);
            filter.Cb = new Range(filterProp.filterCbmin, filterProp.filterCbmax);
            filter.Cr = new Range(filterProp.filterCrmin, filterProp.filterCrmax);
            //// apply the filter
            filter.ApplyInPlace(frameFilter);

            BitmapData objectsData = frameFilter.LockBits(new Rectangle(0, 0,
                frameFilter.Width, frameFilter.Height), ImageLockMode.ReadOnly, frameFilter.PixelFormat);
            UnmanagedImage grayImage = grayscaleFilter.Apply(new UnmanagedImage(objectsData));
            frameFilter.UnlockBits(objectsData);

            return grayImage;
        }

        private Rectangle[] workBlobs(UnmanagedImage grayImage, ref Bitmap frameFilter)
        {
            blobCounter.MinWidth = blobCounterMinWidth;
            blobCounter.MinHeight = blobCounterMinHeight;
            blobCounter.FilterBlobs = true;
            blobCounter.ObjectsOrder = ObjectsOrder.YX;
            blobCounter.ProcessImage(grayImage);
            rects = blobCounter.GetObjectsRectangles();

            if (rects.Length > 0)
            {
                for (int i = 0; i < arr.Length; i++)
                    arr[i] = 0;

                for (int i = 0; i < rects.Length; i++)
                    for (int j = 0; j < arr.Length; j++)
                        if (j >= rects[i].Y && j <= rects[i].Y + rects[i].Height)
                            arr[j] = 1;

                for (int i = 0; i < arr.Length - unionObject; i++)
                    if (unionObject > 0)
                        for (int j = 1; j <= unionObject - 1; j++)

                            if (arr[i] == 1 && arr[i + j] == 1 && arr[i + j - 1] == 0)
                                for (int k = 1; k < unionObject; k++)
                                    arr[i + k] = 1;


            }
            else
            {
                if (arr.Length > 0 && arr != null)
                    for (int i = 0; i < arr.Length; i++)
                        arr[i] = 0;
            }

            foreach (Rectangle recs in rects)
                if (rects.Length > 0)
                {
                    foreach (Rectangle objectRect in rects)
                    {
                        Graphics g = Graphics.FromImage(frameFilter);
                        using (Pen pen = new Pen(Color.FromArgb(160, 255, 160), 1))
                        {
                            g.DrawRectangle(pen, objectRect);
                        }
                        g.Dispose();
                    }
                    objectCount = blobCounter.ObjectsCount;
                }

            totalObjectCount += objectCount;

            return rects;
        }

        public void encoderTick()
        {
            encoderCount++;
        }

        public void start()
        {
            if (finalFrame != null && finalFrame.IsRunning == true)
            {
                finalFrame.SignalToStop();
                finalFrame.WaitForStop();
            }
            else
            {
                finalFrame.VideoResolution = finalFrame.VideoCapabilities[6];
                finalFrame.NewFrame += workDevice_NewFrame;
                finalFrame.Start();
            }
            finalFrame.Start();
        }

        public void stop()
        {
            if (finalFrame != null && finalFrame.IsRunning == true)
            {
                finalFrame.NewFrame -= new NewFrameEventHandler(workDevice_NewFrame);
                finalFrame.SignalToStop();
                finalFrame.WaitForStop();
            }
        }
    }
}
