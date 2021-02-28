namespace ExamPaperAsort
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnScanImagFolder = new System.Windows.Forms.Button();
            this.textBoxScanImageFolder = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnAnswerImageFolder = new System.Windows.Forms.Button();
            this.textBoxAnswerImageFolder = new System.Windows.Forms.TextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.textBoxTimeLeft = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxProgress = new System.Windows.Forms.TextBox();
            this.textBoxStatus = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnExamImageFolderChange = new System.Windows.Forms.Button();
            this.textBoxExamImageFolder = new System.Windows.Forms.TextBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxExamImageHeight = new System.Windows.Forms.TextBox();
            this.textBoxExamImageWidth = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxExamImageCount = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnScanImagFolder);
            this.groupBox1.Controls.Add(this.textBoxScanImageFolder);
            this.groupBox1.Location = new System.Drawing.Point(19, 80);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(681, 56);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "스캔이미지 폴더";
            // 
            // btnScanImagFolder
            // 
            this.btnScanImagFolder.Location = new System.Drawing.Point(600, 21);
            this.btnScanImagFolder.Name = "btnScanImagFolder";
            this.btnScanImagFolder.Size = new System.Drawing.Size(75, 23);
            this.btnScanImagFolder.TabIndex = 1;
            this.btnScanImagFolder.Text = "변경";
            this.btnScanImagFolder.UseVisualStyleBackColor = true;
            this.btnScanImagFolder.Click += new System.EventHandler(this.btnScanImagFolder_Click);
            // 
            // textBoxScanImageFolder
            // 
            this.textBoxScanImageFolder.Enabled = false;
            this.textBoxScanImageFolder.Location = new System.Drawing.Point(7, 21);
            this.textBoxScanImageFolder.Name = "textBoxScanImageFolder";
            this.textBoxScanImageFolder.Size = new System.Drawing.Size(587, 21);
            this.textBoxScanImageFolder.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnAnswerImageFolder);
            this.groupBox2.Controls.Add(this.textBoxAnswerImageFolder);
            this.groupBox2.Location = new System.Drawing.Point(19, 142);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(681, 56);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "분류 답안지 이미지 폴더";
            // 
            // btnAnswerImageFolder
            // 
            this.btnAnswerImageFolder.Location = new System.Drawing.Point(600, 21);
            this.btnAnswerImageFolder.Name = "btnAnswerImageFolder";
            this.btnAnswerImageFolder.Size = new System.Drawing.Size(75, 23);
            this.btnAnswerImageFolder.TabIndex = 1;
            this.btnAnswerImageFolder.Text = "변경";
            this.btnAnswerImageFolder.UseVisualStyleBackColor = true;
            this.btnAnswerImageFolder.Click += new System.EventHandler(this.btnAnswerImageFolder_Click);
            // 
            // textBoxAnswerImageFolder
            // 
            this.textBoxAnswerImageFolder.Enabled = false;
            this.textBoxAnswerImageFolder.Location = new System.Drawing.Point(7, 21);
            this.textBoxAnswerImageFolder.Name = "textBoxAnswerImageFolder";
            this.textBoxAnswerImageFolder.Size = new System.Drawing.Size(587, 21);
            this.textBoxAnswerImageFolder.TabIndex = 0;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(710, 21);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(200, 46);
            this.btnStart.TabIndex = 5;
            this.btnStart.Text = "시작";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.textBoxTimeLeft);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.textBoxProgress);
            this.groupBox4.Controls.Add(this.textBoxStatus);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Location = new System.Drawing.Point(19, 198);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(681, 359);
            this.groupBox4.TabIndex = 11;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "진행 상황";
            // 
            // textBoxTimeLeft
            // 
            this.textBoxTimeLeft.Location = new System.Drawing.Point(552, 18);
            this.textBoxTimeLeft.Name = "textBoxTimeLeft";
            this.textBoxTimeLeft.Size = new System.Drawing.Size(123, 21);
            this.textBoxTimeLeft.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(449, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "남은 예상 시간 : ";
            // 
            // textBoxProgress
            // 
            this.textBoxProgress.Location = new System.Drawing.Point(82, 16);
            this.textBoxProgress.Name = "textBoxProgress";
            this.textBoxProgress.Size = new System.Drawing.Size(264, 21);
            this.textBoxProgress.TabIndex = 3;
            // 
            // textBoxStatus
            // 
            this.textBoxStatus.Location = new System.Drawing.Point(7, 58);
            this.textBoxStatus.Multiline = true;
            this.textBoxStatus.Name = "textBoxStatus";
            this.textBoxStatus.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxStatus.Size = new System.Drawing.Size(668, 280);
            this.textBoxStatus.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "진행 상황 : ";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnExamImageFolderChange);
            this.groupBox3.Controls.Add(this.textBoxExamImageFolder);
            this.groupBox3.Location = new System.Drawing.Point(19, 18);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(681, 56);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "문제지 폴더";
            // 
            // btnExamImageFolderChange
            // 
            this.btnExamImageFolderChange.Location = new System.Drawing.Point(600, 21);
            this.btnExamImageFolderChange.Name = "btnExamImageFolderChange";
            this.btnExamImageFolderChange.Size = new System.Drawing.Size(75, 23);
            this.btnExamImageFolderChange.TabIndex = 1;
            this.btnExamImageFolderChange.Text = "변경";
            this.btnExamImageFolderChange.UseVisualStyleBackColor = true;
            this.btnExamImageFolderChange.Click += new System.EventHandler(this.btnExamImageFolderChange_Click);
            // 
            // textBoxExamImageFolder
            // 
            this.textBoxExamImageFolder.Enabled = false;
            this.textBoxExamImageFolder.Location = new System.Drawing.Point(7, 21);
            this.textBoxExamImageFolder.Name = "textBoxExamImageFolder";
            this.textBoxExamImageFolder.Size = new System.Drawing.Size(587, 21);
            this.textBoxExamImageFolder.TabIndex = 0;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label5);
            this.groupBox6.Controls.Add(this.textBoxExamImageHeight);
            this.groupBox6.Controls.Add(this.textBoxExamImageWidth);
            this.groupBox6.Controls.Add(this.label4);
            this.groupBox6.Controls.Add(this.textBoxExamImageCount);
            this.groupBox6.Controls.Add(this.label1);
            this.groupBox6.Location = new System.Drawing.Point(710, 80);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(200, 112);
            this.groupBox6.TabIndex = 2;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "문제지 정보";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(36, 83);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 12);
            this.label5.TabIndex = 5;
            this.label5.Text = "HEIGHT";
            // 
            // textBoxExamImageHeight
            // 
            this.textBoxExamImageHeight.Enabled = false;
            this.textBoxExamImageHeight.Location = new System.Drawing.Point(91, 80);
            this.textBoxExamImageHeight.Name = "textBoxExamImageHeight";
            this.textBoxExamImageHeight.Size = new System.Drawing.Size(100, 21);
            this.textBoxExamImageHeight.TabIndex = 4;
            // 
            // textBoxExamImageWidth
            // 
            this.textBoxExamImageWidth.Enabled = false;
            this.textBoxExamImageWidth.Location = new System.Drawing.Point(91, 53);
            this.textBoxExamImageWidth.Name = "textBoxExamImageWidth";
            this.textBoxExamImageWidth.Size = new System.Drawing.Size(100, 21);
            this.textBoxExamImageWidth.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(43, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "WIDTH";
            // 
            // textBoxExamImageCount
            // 
            this.textBoxExamImageCount.Enabled = false;
            this.textBoxExamImageCount.Location = new System.Drawing.Point(92, 26);
            this.textBoxExamImageCount.Name = "textBoxExamImageCount";
            this.textBoxExamImageCount.Size = new System.Drawing.Size(100, 21);
            this.textBoxExamImageCount.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "페이지 수";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(921, 569);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "답안 이미지 분류 프로그램";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnScanImagFolder;
        private System.Windows.Forms.TextBox textBoxScanImageFolder;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnAnswerImageFolder;
        private System.Windows.Forms.TextBox textBoxAnswerImageFolder;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox textBoxTimeLeft;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxProgress;
        private System.Windows.Forms.TextBox textBoxStatus;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnExamImageFolderChange;
        private System.Windows.Forms.TextBox textBoxExamImageFolder;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxExamImageHeight;
        private System.Windows.Forms.TextBox textBoxExamImageWidth;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxExamImageCount;
        private System.Windows.Forms.Label label1;
    }
}

