using AForge.Imaging;
using AForge.Video.DirectShow;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Robovator.src
{
    public interface IProcModule
    {
        void encoderTick();

        void setCamera(VideoCaptureDevice device);

        void start();

        void stop();
    }
}
