using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Drawing.Imaging;
using Encoder = System.Drawing.Imaging.Encoder;
using System.Diagnostics;

// todo : operator 가 검증해야 할 내용
// 0. 스캔전에 시험지가 순서대로 되어 있는지 확인
// 1. 시작전에 스캔 폴더내 jpg 파일만 있는지 확인
// 2. 이미지 순서와 파일명 순서가 일치하지 않는 에러가 가장 많이 발생
// 3. 종료후 원 폴더의 파일갯수와 분류된 곳의 파일 갯수가 동일한지 확인 필요

// todo : 1. 남은 예상 시간 보여주기
// todo : 2. 오류난 리스트 보여주기

namespace ExamPaperAsort
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBoxStatus.Text = "주의사항\r\n\r\n" +
                "1. 파일명에서 단어의 구분은 스페이스 대신 언더바 사용할것.\r\n\r\n" +
                "2. 파일확장자 앞 마지막 단어는 숫자로만 되어 있을 것" +
                "\r\n";
        }

        private string getFolderPath()
        {
            OpenFileDialog folderBrowser = new OpenFileDialog();
            folderBrowser.ValidateNames = false;
            folderBrowser.CheckFileExists = false;
            folderBrowser.CheckPathExists = true;
            // Always default to Folder Selection.
            folderBrowser.FileName = "Folder Selection.";
            string folderPath = "";
            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                folderPath = Path.GetDirectoryName(folderBrowser.FileName);
            }
            return folderPath;
        }


        private void btnScanImagFolder_Click(object sender, EventArgs e)
        {
            string folderPath = getFolderPath();
            Properties.Settings.Default.Save();
            textBoxScanImageFolder.Text = folderPath;
        }

        private void btnAnswerImageFolder_Click(object sender, EventArgs e)
        {
            string folderPath = getFolderPath();
            Properties.Settings.Default.Save();
            textBoxAnswerImageFolder.Text = folderPath;
        }

        private void btnExamImageFolderChange_Click(object sender, EventArgs e)
        {
            string folderPath = getFolderPath();
            string[] files = Directory.GetFiles(folderPath, "*.jpg");
            Image image = Image.FromFile(files[0]);

            textBoxExamImageFolder.Text = folderPath;
            textBoxExamImageCount.Text = files.Length.ToString();
            textBoxExamImageWidth.Text = image.Width.ToString();
            textBoxExamImageHeight.Text = image.Height.ToString();

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = false; 

            // -- VALIDATE  -- 
            if (textBoxExamImageFolder.Text == "")
            {
                MessageBox.Show("문제지가 있는 폴더를 지정해 주세요.");
                return;
            }
            if(textBoxScanImageFolder.Text == "")
            {
                MessageBox.Show("스캔된 답안지가 있는 폴더를 지정해 주세요.");
                return;
            }
            if (textBoxAnswerImageFolder.Text == "") 
            {
                MessageBox.Show("분류된 이미지들이 저장될 폴더를 지정해 주세요.");
                return;
            }



            textBoxStatus.Text = "";

            Thread thread = new Thread(new ThreadStart(delegate ()
            {
                assortImages();
            }));
            thread.Start();

            


            //String examImageFolderPath = "C:/snue_scoring/답지스캔_단답형/short_페이지_001.jpg";
            
           
            
        }

        int timeSpendSec = 0;
        private void assortImages()
        {
            DateTime startTime = DateTime.Now;
            String scanImagePath = textBoxScanImageFolder.Text;

            int pageCount = Int32.Parse(textBoxExamImageCount.Text);
            String[] filePathArray = Directory.GetFiles(scanImagePath, "*.jpg");
            Array.Sort(filePathArray, StringComparer.InvariantCulture);

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            for (int i = 0; i < filePathArray.Length; i += pageCount)
            {
                String number = getExamineeNumber(filePathArray[i]);
                if (number != null)
                {
                    resizeAndCopy(i, filePathArray, number);
                    showRemainTime(stopWatch, filePathArray.Length, i, pageCount);
                }
            }

            showCompleteMsg(stopWatch, filePathArray.Length);
            stopWatch.Stop();
        }

        private void showCompleteMsg(Stopwatch stopWatch, int totalCount)
        {
            DateTime endTime = DateTime.Now;
            TimeSpan totalTS = stopWatch.Elapsed;
            string totalTimeStr = Util.getTimeString((int)totalTS.TotalSeconds);
            
            MessageBoxIcon validationIcon = MessageBoxIcon.Information;
            string validationTitle = "";
            string validationMsg = "시험지 이미지 분류가 완료되었습니다.";

            String targetPath = textBoxAnswerImageFolder.Text;
            int assortedFileCount = Directory.GetFiles(targetPath, "*.jpg", SearchOption.AllDirectories).Count();


            if (totalCount != assortedFileCount)
            {
                validationIcon = MessageBoxIcon.Error;
                validationTitle = "Error";
                validationMsg = "원 이미지 갯수: " + totalCount + " 분류된 이미지 갯수: " + assortedFileCount;
            }

            this.Invoke(new Action(delegate ()
            {
                textBoxProgress.ResetText();
                textBoxStatus.AppendText("\r\nEnd...");
                textBoxStatus.AppendText("\r\n" + endTime.ToString());
                textBoxStatus.AppendText("\r\n총 소요시간 : " + totalTimeStr);

                MessageBox.Show(validationMsg, validationTitle, MessageBoxButtons.OK, validationIcon);

                btnStart.Enabled = true;
                //btnImageTest.Enabled = true;
                //btnManualResize.Enabled = true;

            }));
        }

        private void showRemainTime(Stopwatch stopWatch, int totalLength, int index, int pageCount)
        {
            if (timeSpendSec == 0)
            {
                TimeSpan ts = stopWatch.Elapsed;
                timeSpendSec = (int)ts.TotalSeconds;
            }
            else if (timeSpendSec > 0)
            {
                int timeLeftSec = (totalLength - index - pageCount) / pageCount * timeSpendSec;
                string strTimeLeft = Util.getTimeString(timeLeftSec);
                this.Invoke(new Action(delegate ()
                {
                    textBoxTimeLeft.ResetText();
                    textBoxTimeLeft.AppendText(strTimeLeft);
                }));
            }

        }

        private void resizeAndCopy(int startIndex, String[] filePathArray, String number)
        {
            int newWidth = Int32.Parse(textBoxExamImageWidth.Text);
            int newHeight = Int32.Parse(textBoxExamImageHeight.Text);            

            String targetPath = textBoxAnswerImageFolder.Text;
            String paperNoPath = Path.Combine(targetPath, number);
            Directory.CreateDirectory(paperNoPath);
            int pageCount = Int32.Parse(textBoxExamImageCount.Text);
            for (int i=0; i<pageCount; i++)
            {
                int index = startIndex + i;
                String originFilePath = filePathArray[index];
                String originFileName = Path.GetFileName(originFilePath);

                String destFilePath = Path.Combine(paperNoPath, originFileName);

                Bitmap image = new Bitmap(originFilePath);
                Bitmap newImage = new Bitmap(newWidth, newHeight);

                using (Graphics graphics = Graphics.FromImage(newImage))
                {
                    graphics.DrawImage(image, 0, 0, newWidth, newHeight);
                    graphics.Dispose();
                }

                // Get an ImageCodecInfo object that represents the JPEG codec.
                ImageCodecInfo imageCodecInfo = GetEncoderInfo("image/jpeg");

                // Create an Encoder object for the Quality parameter.
                Encoder encoder = Encoder.Quality;

                // Create an EncoderParameters object. 
                EncoderParameters encoderParameters = new EncoderParameters(1);

                // Save the image as a JPEG file with quality level.
                EncoderParameter encoderParameter = new EncoderParameter(Encoder.Quality, 95L);
                encoderParameters.Param[0] = encoderParameter;
                newImage.Save(destFilePath, imageCodecInfo, encoderParameters);

                image.Dispose();
                newImage.Dispose();

            }


        }

        private ImageCodecInfo GetEncoderInfo(String mimeType)
        {
            int j;
            ImageCodecInfo[] encoders;
            encoders = ImageCodecInfo.GetImageEncoders();
            for (j = 0; j < encoders.Length; ++j)
            {
                if (encoders[j].MimeType == mimeType)
                    return encoders[j];
            }
            return null;
        }

        private String getExamineeNumber(String path)
        {
            OMR omr = new OMR();
            String number = omr.getExamineeNumber(path);
            String msg = number == null ? "ERROR 발생" : number;
            this.Invoke(new Action(delegate ()
            {
                textBoxStatus.AppendText("\r\n");
                textBoxStatus.AppendText("file : " + path + "\r\n");
                textBoxStatus.AppendText(msg);
                textBoxStatus.AppendText("\r\n");

            }));

            return number;
        }
        

        

        private void btnManualResize_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void btnImageTest_Click(object sender, EventArgs e)
        {

        }


    }
}
