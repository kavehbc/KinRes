
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Windows.Forms;

using Microsoft.Kinect.Toolkit;
using System.Windows.Threading;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;
using System.Windows.Navigation;
using System.Text;
using System.Linq;
using System.ComponentModel;

using Microsoft.Kinect;
using System;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

using Excel = Microsoft.Office.Interop.Excel;


namespace KinectRespiratory
{



    public partial class Form1 : Form
    {
        //    private KinectSensorChooser _chooser;
        private Bitmap _bitmap = null;

        DispatcherTimer dt = new DispatcherTimer();
        DispatcherTimer dt2 = new DispatcherTimer();
        DispatcherTimer dtDuration = new DispatcherTimer();
        ArrayList imgSequence = new ArrayList();
        ArrayList timeStampSequence = new ArrayList();
        // private int framePerSecond = 0;                // save the color somewhere
        private bool iKnowDaColor = true;    // this will be set to true when we know the color
        bool showDigram = false;
        int minDuration = 0;
        //int ImageIndex = 0;
        private Rectangle mRect;
        private ArrayList timeStamps = new ArrayList();
        private ushort[] dip = null;
        private byte[] dip1 = null; // for display
                                    //       DepthImagePixel[] dip;
        short[,] _pixelDataFrame = new short[424, 512];
        private double firstValue = 0;
        private DateTime firstTimeValue;//= DateTime.Now;
        double slope = 0;
        bool mouseDown = false;
        private double[] stdAmplitude;
        private double[] stdCycle;

        double LastIPeakTime = 0;
        double LastXPeakTime = 0;
        double LastPeakTime = 0;
        double LastIPeak = 0;
        double LastXPeak = 0;
        double LastPeak = 0;
        int LastPeakIndex = 0;
        double CurrentAmplitude = 0;
        string FolderPath = "";

        KinectSensor _sensor;
        MultiSourceFrameReader _reader;

        private FrameDescription depthFrameDescription = null;
        private WriteableBitmap depthBitmap = null;
        /// <summary>
        /// Map depth range to byte range
        /// </summary>
        private const int MapDepthToByte = 8000 / 256; // What is this ?


        public Form1()
        {
            InitializeComponent();

            //txtFramePerSecond.Text
            Settings frmSet = new Settings();

            dt2.Interval = new TimeSpan(0, 0, 0, 0, 1000 / Convert.ToInt32(frmSet.getFPS));
            dt2.Tick += new EventHandler(dt2_Tick);
            dt2.Start(); //to start record
           
            
        }

        private void SetTimer()
        {
            Settings frmSet = new Settings();
            dt2.Stop();
            dt2.Interval = new TimeSpan(0, 0, 0, 0, 1000 / Convert.ToInt32(frmSet.getFPS));
            dt2.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //_chooser = new KinectSensorChooser();
            //_chooser.KinectChanged += ChooserSensorChanged;
            //_chooser.Start();

            video.Width = 512;
            video.Height = 424;
            chart1.Left = video.Left + video.Width + video.Left;
            chart1.Height = video.Height;

            Form1 frmForm1 = new Form1();
            chart1.Width = frmForm1.Width - video.Width - (video.Left * 4);
            //System.Windows.Forms.MessageBox.Show(video.Width.ToString() + " - " + video.Height.ToString());

            btnShowDigram.Enabled = true;
            btnStopDiagram.Enabled = false;
            btnRestetdigram.Enabled = false;

            _sensor = KinectSensor.GetDefault();

            if (_sensor != null)
            {
                _sensor.Open();

                depthFrameDescription = _sensor.DepthFrameSource.FrameDescription;
                this.depthBitmap = new WriteableBitmap(this.depthFrameDescription.Width, this.depthFrameDescription.Height, 96.0, 96.0, PixelFormats.Gray8, null);

                _reader = _sensor.OpenMultiSourceFrameReader(FrameSourceTypes.Color | FrameSourceTypes.Depth | FrameSourceTypes.Infrared | FrameSourceTypes.Body);
                _reader.MultiSourceFrameArrived += Reader_MultiSourceFrameArrived;
            }
        }

        void Reader_MultiSourceFrameArrived(object sender, MultiSourceFrameArrivedEventArgs e)
        {
            var reference = e.FrameReference.AcquireFrame();

            // Depth
            using (var frame = reference.DepthFrameReference.AcquireFrame())
            {
                bool depthFrameProcessed = false;
                if (frame != null)
                {
                    _bitmap = frame.ToBitmap();
                    video.Image = _bitmap;
                    dip = new ushort[depthFrameDescription.Width * depthFrameDescription.Height];
                    dip1 = new byte[depthFrameDescription.Width * depthFrameDescription.Height];

                    if (dip != null && frame != null)
                    //  frame.CopyDepthImagePixelDataTo(dip);
                    {
                        using (Microsoft.Kinect.KinectBuffer depthBuffer = frame.LockImageBuffer())
                        {
                            // verify data and write the color data to the display bitmap
                            if (((this.depthFrameDescription.Width * this.depthFrameDescription.Height) == (depthBuffer.Size / this.depthFrameDescription.BytesPerPixel)) &&
                                (this.depthFrameDescription.Width == this.depthBitmap.PixelWidth) && (this.depthFrameDescription.Height == this.depthBitmap.PixelHeight))
                            {
                                // Note: In order to see the full range of depth (including the less reliable far field depth)
                                // we are setting maxDepth to the extreme potential depth threshold
                                ushort maxDepth = ushort.MaxValue;

                                // If you wish to filter by reliable depth distance, uncomment the following line:
                                //maxDepth = frame.DepthMaxReliableDistance;

                                this.ProcessDepthFrameData(depthBuffer.UnderlyingBuffer, depthBuffer.Size, frame.DepthMinReliableDistance, maxDepth);
                                depthFrameProcessed = true;
                            }
                        }
                    }

                    if (depthFrameProcessed)
                    {
                        this.RenderDepthPixels();
                    }


                }
            }
        }

        /// <summary>
        /// Renders color pixels into the writeableBitmap.
        /// </summary>
        private void RenderDepthPixels()
        {
            this.depthBitmap.WritePixels(
                new Int32Rect(0, 0, this.depthBitmap.PixelWidth, this.depthBitmap.PixelHeight),
                this.dip1,
                this.depthBitmap.PixelWidth,
                0);
        }


        /// <summary>
        /// Directly accesses the underlying image buffer of the DepthFrame to 
        /// create a displayable bitmap.
        /// This function requires the /unsafe compiler option as we make use of direct
        /// access to the native memory pointed to by the depthFrameData pointer.
        /// </summary>
        /// <param name="depthFrameData">Pointer to the DepthFrame image data</param>
        /// <param name="depthFrameDataSize">Size of the DepthFrame image data</param>
        /// <param name="minDepth">The minimum reliable depth value for the frame</param>
        /// <param name="maxDepth">The maximum reliable depth value for the frame</param>
        private unsafe void ProcessDepthFrameData(IntPtr depthFrameData, uint depthFrameDataSize, ushort minDepth, ushort maxDepth)
        {
            // depth frame data is a 16 bit value
            ushort* frameData = (ushort*)depthFrameData;

            // convert depth to a visual representation
            for (int i = 0; i < (int)(depthFrameDataSize / this.depthFrameDescription.BytesPerPixel); ++i)
            {
                // Get the depth for this pixel
                ushort depth = frameData[i];

                // To convert to a byte, we're mapping the depth value to the byte range.
                // Values outside the reliable depth range are mapped to 0 (black).
                this.dip[i] = (ushort)(depth >= minDepth && depth <= maxDepth ? depth : 0);
                this.dip1[i] = (byte)(depth >= minDepth && depth <= maxDepth ? (depth / MapDepthToByte) : 0);
            }
        }


        //void ChooserSensorChanged(object sender, KinectChangedEventArgs e)
        //{
        //    var old = e.OldSensor;
        //    StopKinect(old);

        //    var newsensor = e.NewSensor;
        //    if (newsensor == null)
        //    {
        //        return;
        //    }

        //    newsensor.SkeletonStream.Enable();
        //    newsensor.ColorStream.Enable(ColorImageFormat.RgbResolution640x480Fps30);
        //    newsensor.DepthStream.Enable(DepthImageFormat.Resolution640x480Fps30);
        //    newsensor.AllFramesReady += SensorAllFramesReady;

        //    try
        //    {
        //        newsensor.Start();
        //       // rtbMessages.Text = "Kinect Started" + "\r";
        //    }
        //    catch (System.IO.IOException)
        //    {
        //       // rtbMessages.Text = "Kinect Not Started" + "\r";
        //        //maybe another app is using Kinect
        //        _chooser.TryResolveConflict();
        //    }
        //}

        //private void StopKinect(KinectSensor sensor)
        //{
        //    if (sensor != null)
        //    {
        //        if (sensor.IsRunning)
        //        {
        //            sensor.Stop();
        //            sensor.AudioSource.Stop();
        //        }
        //    }
        //}

        //void SensorAllFramesReady(object sender, AllFramesReadyEventArgs e)
        //{
        //    SensorDepthFrameReady(e);
        //    video.Image = _bitmap;

        //}



        //void SensorDepthFrameReady(AllFramesReadyEventArgs e)
        //{
        //    // if the window is displayed, show the depth buffer image
        //    if (WindowState != FormWindowState.Minimized)
        //    {
        //        using (var frame = e.OpenDepthImageFrame())
        //        {
        //            _bitmap = CreateBitMapFromDepthFrame(frame);
        //            dip = new DepthImagePixel[307200];

        //            if (dip != null && frame != null)
        //                frame.CopyDepthImagePixelDataTo(dip);                    
        //        }                                
        //    }
        //}

        // private Bitmap CreateBitMapFromDepthFrame(DepthImageFrame frame)
        //{
        //    if (frame != null)
        //    {
        //        short[] _pixelData;
        //        var bitmapImage = new Bitmap(frame.Width, frame.Height, PixelFormat.Format16bppRgb565);
        //        var g = Graphics.FromImage(bitmapImage);
        //        g.Clear(Color.FromArgb(0, 34, 68));

        //        //Copy the depth frame data onto the bitmap 
        //        _pixelData = new short[frame.PixelDataLength];

        //        frame.CopyPixelDataTo(_pixelData);             

        //       // frame.CopyDepthImagePixelDataTo(
        //        BitmapData bmapdata = bitmapImage.LockBits(new Rectangle(0, 0, frame.Width,
        //         frame.Height), ImageLockMode.WriteOnly, bitmapImage.PixelFormat);
        //        IntPtr ptr = bmapdata.Scan0;
        //        Marshal.Copy(_pixelData, 0, ptr, frame.Width * frame.Height);
        //        bitmapImage.UnlockBits(bmapdata);

        //        return bitmapImage;
        //    }
        //    return null;
        //}



        private void dt_Tick(object sender, EventArgs e)
        {
            Bitmap img = _bitmap;
            String dateTimeStr = DateTime.Now.ToString("hh.mm.ss.ffffff");

            if (img != null)
            {
                using (FileStream fs = new FileStream(FolderPath + "\\image.dat", FileMode.Append))
                {
                    using (BinaryWriter bw = new BinaryWriter(fs))
                    {
                        for (int i = 0; i < 512 * 424; i++)
                        {
                            bw.Write(dip[i]);
                        }
                    }
                }

                using (StreamWriter file2 = new StreamWriter(FolderPath + "\\timeStamp.txt", true))
                {
                    file2.WriteLine(dateTimeStr);
                    //timeStamps.Add(dateTimeStr);
                }
            }
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            if (DialogResult.OK == fbd.ShowDialog())
            {
                Settings frmSet = new Settings();

                btnSave.Enabled = false;
                FolderPath = fbd.SelectedPath;
                string path = fbd.SelectedPath + "\\image.dat";
                string timeStamp = fbd.SelectedPath + "\\timeStamp.txt";

                File.Delete(path);
                File.Delete(timeStamp);

                imgSequence = new ArrayList();
                timeStampSequence = new ArrayList();
                dt.Interval = new TimeSpan(0, 0, 0, 0, 1000 / Convert.ToInt32(frmSet.getFPS));
                dt.Tick += new EventHandler(dt_Tick);
                dt.Start(); //to start recording

                minDuration = Convert.ToInt16(frmSet.getRecordingDuration);
                dtDuration.Interval = new TimeSpan(0, 1, 0);  //every min
                dtDuration.Tick += new EventHandler(dtDuration_Tick);
                dtDuration.Start();

                btnStop.Enabled = true;
            }
        }

        void dtDuration_Tick(object sender, EventArgs e)
        {
            minDuration--;

            if (minDuration == 0)
                btnStop_Click(sender, null);
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            btnStop.Enabled = false;
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
            dtDuration.Stop();
            dt.Stop();

            System.Windows.Forms.MessageBox.Show("Recording has been stopped", "Info");

            btnSave.Enabled = true;
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
        }

        private void butbrowse_Click(object sender, EventArgs e)
        {

        }

        void dt2_Tick(object sender, EventArgs e)
        {
            Settings frmSet = new Settings();
            string strLog = "";
            object[] objLog = new object[8];

            if (video.Image != null && showDigram == true)
            {
                double sum = 0;

                for (int i = (int)xtop.Value; i < (int)xBottom.Value; i++)
                    for (int j = (int)yTop.Value; j < (int)yBottom.Value; j++)
                    {
                        if (dip[i + 512 * j] > 0)
                            sum += dip[i + 512 * j];
                    }

                double avg = sum / (((int)xtop.Value - (int)xBottom.Value) * ((int)yTop.Value - (int)yBottom.Value));
                avg = avg - firstValue;
                double NewYValue = avg;



                TimeSpan timeAxis = DateTime.Now - firstTimeValue;
                double framePerSecond = timeAxis.TotalMilliseconds / 1000;
                double chartSecond;

                objLog[0] = framePerSecond.ToString();
                objLog[1] = NewYValue.ToString();

                strLog = framePerSecond.ToString();
                strLog += "," + NewYValue.ToString();

                if (framePerSecond > 60)
                {
                    double tempTime = (int)framePerSecond / 60;
                    chartSecond = framePerSecond - (tempTime * 60);
                }
                else
                    chartSecond = framePerSecond;

                if (chart1.Series[0].Points.Count > 0)
                {
                    double preXValue = chart1.Series[0].Points[chart1.Series[0].Points.Count - 1].XValue;
                    double preYValue = chart1.Series[0].Points[chart1.Series[0].Points.Count - 1].YValues[0];

                    double preY2Value;
                    double preY3Value;
                    if (chart1.Series[0].Points.Count > 2)
                        preY2Value = chart1.Series[0].Points[chart1.Series[0].Points.Count - 2].YValues[0];
                    else
                        preY2Value = 0;

                    if (chart1.Series[0].Points.Count > 3)
                        preY3Value = chart1.Series[0].Points[chart1.Series[0].Points.Count - 3].YValues[0];
                    else
                        preY3Value = 0;

                    //Moving Average algothim as a Low-Pass Filter
                    if (preY2Value == 0)
                        NewYValue = (preYValue + avg) / 2;
                    else if (preY3Value == 0)
                        NewYValue = (preYValue + preY2Value + avg) / 3;
                    else
                        NewYValue = (preYValue + preY2Value + preY3Value + avg) / 4;

                    double newSlope = (NewYValue - preYValue);// / (framePerSecond - preXValue);

                    objLog[2] = newSlope.ToString();
                    strLog += "," + newSlope.ToString();

                    if (newSlope == 0)
                        newSlope = slope;

                    //newSlope * slope < 0
                    // if the first deviation changes the sign, then there is a peak.
                    //(Math.Abs(newSlope) + Math.Abs(slope)) != Math.Abs(newSlope + slope)
                    if ((Math.Sign(newSlope) != Math.Sign(slope)))
                    {
                        chart1.Series[1].Points.Add(new System.Windows.Forms.DataVisualization.Charting.DataPoint(preXValue, preYValue));
                        bool IXPeak;
                        if (Math.Sign(newSlope) < 0)
                        {
                            IXPeak = true; //Inhale Peak
                            objLog[5] = Math.Abs(LastIPeakTime - framePerSecond);
                        }
                        else
                        {
                            IXPeak = false; //Exhale Peak
                            objLog[6] = Math.Abs(LastXPeakTime - framePerSecond);
                        }


                        objLog[3] = true;
                        strLog += "," + IXPeak.ToString();

                        CurrentAmplitude = Math.Abs(LastIPeak - LastXPeak);
                        objLog[4] = CurrentAmplitude;

                        //Peak Error Variability
                        objLog[7] = Math.Abs(LastPeakTime - framePerSecond);
                        bool blnPeakValidation = true;

                        if ((double)objLog[7] < frmSet.getErrorTime) //0.300
                        {
                            //There is an error
                            if (IXPeak)
                            {
                                //Inhale Peak - Concave Up
                                if (preYValue >= LastPeak)
                                {
                                    //The new peak is not correct
                                    blnPeakValidation = false;
                                }
                                else
                                {
                                    blnPeakValidation = true;
                                }
                            }
                            else
                            {
                                //Exhale Peak - Concave Down
                                if (preYValue <= LastPeak)
                                {
                                    //The new peak is not correct
                                    blnPeakValidation = false;
                                }
                                else
                                {
                                    blnPeakValidation = true;
                                }

                            }
                            if (blnPeakValidation)
                            {
                                int LastPeakIndex2 = FindLastPeakIndex(2);
                                LastIPeakTime = FindLastPeak(2, 0, 0);
                                LastXPeakTime = FindLastPeak(2, 1, 0);
                                LastIPeak = FindLastPeak(2, 0, 1);
                                LastXPeak = FindLastPeak(2, 1, 1);
                                double LastSlope = FindLastPeak(2, -1, 2);

                                DataGridViewCell cell = dataGridView1.Rows[LastPeakIndex].Cells[3];
                                dataGridView1.CurrentCell = cell;
                                dataGridView1.BeginEdit(true);
                                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)dataGridView1.Rows[LastPeakIndex].Cells[3];
                                cell.Value = chk.FalseValue;
                                dataGridView1.Rows[LastPeakIndex].Cells[4].Value = null;
                                dataGridView1.Rows[LastPeakIndex].Cells[5].Value = null;
                                dataGridView1.Rows[LastPeakIndex].Cells[6].Value = null;
                                dataGridView1.Rows[LastPeakIndex].Cells[7].Value = null;
                                dataGridView1.EndEdit();

                                //Remove the last marked peak
                                chart1.Series[1].Points.RemoveAt(chart1.Series[1].Points.Count - 1);

                                if (chart1.Series[1].Points.Count > 1)
                                {
                                    LastPeakTime = Convert.ToDouble(dataGridView1.Rows[LastPeakIndex2].Cells[0].Value);
                                    LastPeak = Convert.ToDouble(dataGridView1.Rows[LastPeakIndex2].Cells[1].Value);
                                }

                                objLog[7] = Math.Abs(LastPeakTime - framePerSecond);

                                if (Math.Sign(LastSlope) != Math.Sign(newSlope))
                                {
                                    //The new peak is the real peak
                                    if (Math.Sign(newSlope) < 0)
                                    {
                                        objLog[5] = Math.Abs(LastIPeakTime - framePerSecond);
                                        LastIPeakTime = framePerSecond;
                                        LastIPeak = preYValue;
                                    }
                                    else
                                    {
                                        objLog[6] = Math.Abs(LastXPeakTime - framePerSecond);
                                        LastXPeakTime = framePerSecond;
                                        LastXPeak = preYValue;
                                    }

                                    CurrentAmplitude = Math.Abs(LastIPeak - LastXPeak);
                                    objLog[4] = CurrentAmplitude;

                                    LastPeak = preYValue;
                                    LastPeakTime = framePerSecond;
                                }
                                else
                                {
                                    //The new peak is also not a peak
                                    objLog[3] = false;
                                    objLog[4] = null;
                                    objLog[5] = null;
                                    objLog[6] = null;
                                    objLog[7] = null;
                                }

                            }
                            else
                            {
                                objLog[3] = false;
                                objLog[4] = null;
                                objLog[5] = null;
                                objLog[6] = null;
                                objLog[7] = null;
                            }
                        }
                        else
                        {
                            if (IXPeak)
                            {
                                LastIPeakTime = framePerSecond;
                                LastIPeak = preYValue;
                            }
                            else
                            {
                                LastXPeakTime = framePerSecond;
                                LastXPeak = preYValue;
                            }

                            LastPeak = preYValue;
                            LastPeakTime = framePerSecond;
                        }
                    }
                    else
                    {
                        objLog[3] = null;
                        objLog[4] = null;
                        objLog[5] = null;
                        objLog[6] = null;
                        objLog[7] = null;
                        strLog += ",";
                    }

                    slope = newSlope;


                }
                else
                {
                    objLog[2] = null;
                    objLog[3] = null;
                    objLog[4] = null;
                    objLog[5] = null;
                    strLog += ",,";
                }

                //Reset the first value when the body moves...
                if (NewYValue >= 20 || NewYValue <= -20)
                    RedrawAxes(false);

                DateTime dateTimeStr = DateTime.Now;
                timeStamps.Add(dateTimeStr);
                chart1.Series[0].Points.Add(new System.Windows.Forms.DataVisualization.Charting.DataPoint(chartSecond, NewYValue));
                //framePerSecond++;

                if ((int)(chart1.Series[1].Points.Count) / 2 >= (int)frmSet.getMinimumCycles)
                {
                    tsslAmp.Text = "Amplitude: " + Amplitude().ToString();
                    tsslAmpStd.Text = "Amplitude StdDev: " + Math.Round(Extend.StandardDeviation(stdAmplitude), 4).ToString();
                    tsslCycle.Text = "Cycles: " + CyclePeriod().ToString();
                    tsslCycleStd.Text = "Cycle StdDev: " + Math.Round(Extend.StandardDeviation(stdCycle), 4).ToString();
                }

                dataGridView1.Rows.Add(objLog);
                dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.RowCount - 1;

                if (objLog[3] != null)
                    if ((bool)objLog[3] == true)
                        LastPeakIndex = dataGridView1.Rows.Count - 1;

                tsslRecords.Text = dataGridView1.RowCount.ToString() + " records.";
                //txtLog.AppendText(strLog + "\r\n");
            }
        }

        private int FindLastPeakIndex(int intLevel)
        {
            int counter = 0;
            for (int i = dataGridView1.Rows.Count - 1; i >= 0; i--)
            {
                if (Convert.ToBoolean(dataGridView1.Rows[i].Cells[3].Value) == true)
                {
                    counter++;
                    if (counter == intLevel)
                    {
                        return i;
                    }
                }
            }
            return 0;

        }

        private double FindLastPeak(int intLevel, int intIX, int ColumnIndex)
        {
            //Type = 0 : Time
            //Type = 1 : Y Value
            int counter = 0;
            int intColumnIndex = 5;
            if (intIX > -1)
                intColumnIndex += intIX;

            for (int i = dataGridView1.Rows.Count - 1; i >= 0; i--)
            {
                if (Convert.ToBoolean(dataGridView1.Rows[i].Cells[3].Value) == true)
                    if (intIX > -1 && dataGridView1.Rows[i].Cells[intColumnIndex].Value != null)
                    {
                        counter++;
                        if (counter == intLevel)
                        {
                            return Convert.ToDouble(dataGridView1.Rows[i].Cells[ColumnIndex].Value);
                        }
                    }
                    else if (intIX == -1)
                    {
                        counter++;
                        if (counter == intLevel)
                        {
                            return Convert.ToDouble(dataGridView1.Rows[i].Cells[ColumnIndex].Value);
                        }
                    }
            }
            return 0;

        }

        private double Amplitude()
        {
            double sumAmplitude = 0;
            int count = 0;

            stdAmplitude = new double[chart1.Series[1].Points.Count];


            for (int i = 0; i + 1 < chart1.Series[1].Points.Count; i++, count++)
            {


                double a1 = chart1.Series[1].Points[i].YValues[0];
                double a2 = chart1.Series[1].Points[i + 1].YValues[0];

                sumAmplitude += Math.Abs(a1 - a2);

                stdAmplitude[i] = Math.Abs(a1 - a2);

            }


            // Extend.StandardDeviation(arr);
            return Math.Round(sumAmplitude / count, 4);
        }

        private String CyclePeriod()
        {
            int count = 0;
            //System.TimeSpan sumDifferent = new TimeSpan();

            double sumDifferent = 0;
            stdCycle = new double[chart1.Series[1].Points.Count];

            for (int i = 0; i + 2 < chart1.Series[1].Points.Count; i++, count++)
            {
                double a1 = chart1.Series[1].Points[i].XValue; //(DateTime)timeStamps[i];
                double a2 = chart1.Series[1].Points[i + 2].XValue;//timeStamps[i + 2];

                sumDifferent += (a2 - a1);

                stdCycle[i] = (a2 - a1);
            }

            return Convert.ToString(Math.Round(sumDifferent / count, 4));

        }

        private double getStandardDeviation(List<double> doubleList)
        {
            double average = doubleList.Average();
            double sumOfDerivation = 0;
            foreach (double value in doubleList)
            {
                sumOfDerivation += (value) * (value);
            }
            double sumOfDerivationAverage = sumOfDerivation / (doubleList.Count - 1);
            return Math.Sqrt(sumOfDerivationAverage - (average * average));
        }

        private void btnShowDigram_Click(object sender, EventArgs e)
        {
            btnShowDigram.Enabled = false;
            btnStopDiagram.Enabled = true;
            btnRestetdigram.Enabled = false;

            tsslTimeStamp.Text = "Time Stamp: " + DateTime.Now;
            SetTimer();
            showDigram = true;
            RedrawAxes(true);
        }

        private void RedrawAxes(bool TimeReset)
        {
            if (video.Image != null && showDigram == true)
            {
                double sum = 0;

                for (int i = (int)xtop.Value; i < (int)xBottom.Value; i++)
                    for (int j = (int)yTop.Value; j < (int)yBottom.Value; j++)
                    {
                        if (dip[i + 512 * j] > 0)
                            sum += dip[i + 512 * j]; //_pixelDataFrame[i, j];
                    }

                firstValue = Math.Round(sum / (((int)xtop.Value - (int)xBottom.Value) * ((int)yTop.Value - (int)yBottom.Value)));
                if (TimeReset)
                    firstTimeValue = DateTime.Now;
            }
        }

        private void btnStopDiagram_Click(object sender, EventArgs e)
        {
            btnShowDigram.Enabled = true;
            btnStopDiagram.Enabled = false;
            btnRestetdigram.Enabled = true;

            showDigram = false;
        }

        //initiate rectangle with mouse down event
        private void video_MouseDown1(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            mRect = new Rectangle(e.X, e.Y, 0, 0);
            mouseDown = true;
            this.Invalidate();
        }

        //check if mouse is down and being draged, then draw rectangle
        private void video_MouseMove1(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mRect = new Rectangle(mRect.Left, mRect.Top, e.X - mRect.Left >= 640 ? 640 : e.X - mRect.Left, e.Y - mRect.Top >= 480 ? 480 : e.Y - mRect.Top); //
                this.Invalidate();
            }
        }

        //draw the rectangle on paint event
        private void video_Paint1(object sender, PaintEventArgs e)
        {
            //Draw a rectangle with 2pixel wide line
            using (System.Drawing.Pen pen = new System.Drawing.Pen(System.Drawing.Color.Red, 2))
            {
                e.Graphics.DrawRectangle(pen, mRect);
                if (iKnowDaColor)
                {
                    e.Graphics.DrawRectangle(pen, Convert.ToInt16(xtop.Value), Convert.ToInt16(yTop.Value), Convert.ToInt16(xBottom.Value - xtop.Value), Convert.ToInt16(yBottom.Value - yTop.Value));
                }
            }
        }

        private void btnRestetdigram_Click(object sender, EventArgs e)
        {

            btnShowDigram.Enabled = true;
            btnStopDiagram.Enabled = false;
            btnRestetdigram.Enabled = false;

            chart1.ResetAutoValues();
            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();
            // framePerSecond = 0;
            chart1.Update();

            dataGridView1.Rows.Clear();
            RedrawAxes(true);
        }

        private void video_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            xtop.Value = mRect.Left;
            yTop.Value = mRect.Top;
            yBottom.Value = mRect.Bottom > 480 ? 480 : mRect.Bottom; //
            xBottom.Value = mRect.Right > 640 ? 640 : mRect.Right; //
            mouseDown = false;
        }

        private void xtop_ValueChanged(object sender, EventArgs e)
        {
            ChangeRecet();
        }

        private void yTop_ValueChanged(object sender, EventArgs e)
        {
            ChangeRecet();
        }

        private void xBottom_ValueChanged(object sender, EventArgs e)
        {
            ChangeRecet();
        }

        private void yBottom_ValueChanged(object sender, EventArgs e)
        {
            ChangeRecet();
        }

        private void ChangeRecet()
        {
            if (mouseDown == false)
                mRect = new Rectangle(Convert.ToInt16(xtop.Value), Convert.ToInt16(yTop.Value), Convert.ToInt16(xBottom.Value - xtop.Value), Convert.ToInt16(yBottom.Value - yTop.Value));
        }

        private void copyAlltoClipboard()
        {
            dataGridView1.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            dataGridView1.MultiSelect = true;
            dataGridView1.SelectAll();
            System.Windows.Forms.DataObject dataObj = dataGridView1.GetClipboardContent();
            if (dataObj != null)
                System.Windows.Forms.Clipboard.SetDataObject(dataObj);
        }


        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                System.Windows.Forms.MessageBox.Show("Exception Occurred while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }


        private void saveDiagramAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "PNG (*.png)|*.png|JPEG (*.jpg)|*.jpg";
            sfd.RestoreDirectory = true;
            //sfd.InitialDirectory = FolderPath;
            sfd.FileName = "chart";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                if (sfd.FilterIndex == 0)
                    chart1.SaveImage(sfd.FileName, ImageFormat.Png);
                else
                    chart1.SaveImage(sfd.FileName, ImageFormat.Jpeg);

                System.Windows.MessageBox.Show("Chart image has been seved successfully.", "Save Chart", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Documents (*.xls)|*.xls";
            sfd.RestoreDirectory = true;
            //sfd.InitialDirectory = FolderPath;
            sfd.FileName = "respiratory_data.xls";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                copyAlltoClipboard();
                object misValue = System.Reflection.Missing.Value;
                Excel.Application xlexcel = new Excel.Application();

                xlexcel.DisplayAlerts = false; // Without this you will get two confirm overwrite prompts
                Excel.Workbook xlWorkBook = xlexcel.Workbooks.Add(misValue);
                Excel.Worksheet xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

                // Format column D as text before pasting results, this was required for my data
                //Excel.Range rng = xlWorkSheet.get_Range("D:D").Cells;
                //rng.NumberFormat = "@";

                // Paste clipboard results to worksheet range
                Excel.Range CR = (Excel.Range)xlWorkSheet.Cells[1, 1];
                CR.Select();
                xlWorkSheet.PasteSpecial(CR, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);

                // For some reason column A is always blank in the worksheet. ¯\_(ツ)_/¯
                // Delete blank column A and select cell A1
                Excel.Range delRng = xlWorkSheet.get_Range("A:A").Cells;
                delRng.Delete(Type.Missing);
                xlWorkSheet.get_Range("A1").Select();

                // Save the excel file under the captured location from the SaveFileDialog

                xlWorkBook.SaveAs(sfd.FileName, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                xlexcel.DisplayAlerts = true;
                xlWorkBook.Close(true, misValue, misValue);
                xlexcel.Quit();

                releaseObject(xlWorkSheet);
                releaseObject(xlWorkBook);
                releaseObject(xlexcel);

                // Clear Clipboard and DataGridView selection
                System.Windows.Forms.Clipboard.Clear();
                dataGridView1.ClearSelection();

                // Open the newly saved excel file
                if (File.Exists(sfd.FileName))
                    System.Diagnostics.Process.Start(sfd.FileName);
            }
        }

        private void saveDepthImageAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "JPEG (*.jpg)|*.jpg";
            sfd.RestoreDirectory = true;
            //sfd.InitialDirectory = FolderPath;
            sfd.FileName = "video_shot.jpg";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                video.Image.Save(sfd.FileName, ImageFormat.Jpeg);
                System.Windows.MessageBox.Show("Chart image has been seved successfully in JPEG format.", "Save Chart", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void peaksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            peaksToolStripMenuItem.Checked = !peaksToolStripMenuItem.Checked;
            chart1.Series[1].IsVisibleInLegend = peaksToolStripMenuItem.Checked;
            chart1.Series[1].Enabled = peaksToolStripMenuItem.Checked;

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (System.Windows.Forms.MessageBox.Show("Are you sure you want to exit?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About frm = new About();
            frm.ShowDialog();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            Settings frmSet = new Settings();
            frmSet.ShowDialog();
        }

        private void depthToolStripMenuItem_Click(object sender, EventArgs e)
        {
            depthToolStripMenuItem.Checked = !depthToolStripMenuItem.Checked;
            chart1.Series[0].IsVisibleInLegend = depthToolStripMenuItem.Checked;
            chart1.Series[0].Enabled = depthToolStripMenuItem.Checked;
        }

        private void showLegendsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showLegendsToolStripMenuItem.Checked = !showLegendsToolStripMenuItem.Checked;
            chart1.Legends[0].Enabled = showLegendsToolStripMenuItem.Checked;
        }
    }

    public static class Extend
    {
        public static double StandardDeviation(this IEnumerable<double> values)
        {
            double avg = values.Average();
            return Math.Sqrt(values.Average(v => Math.Pow(v - avg, 2)));
        }
    }
}
