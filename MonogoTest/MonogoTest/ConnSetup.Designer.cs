namespace MonogoTest
{
    partial class ConnSetup
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtServer = new System.Windows.Forms.TextBox();
            this.txtDb = new System.Windows.Forms.TextBox();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.chkIntSec = new System.Windows.Forms.CheckBox();
            this.btnTestConn = new System.Windows.Forms.Button();
            this.btnSetConn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtServer
            // 
            this.txtServer.Location = new System.Drawing.Point(108, 66);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(100, 20);
            this.txtServer.TabIndex = 0;
            this.txtServer.Text = "localhost\\SQL2012";
            // 
            // txtDb
            // 
            this.txtDb.Location = new System.Drawing.Point(108, 93);
            this.txtDb.Name = "txtDb";
            this.txtDb.Size = new System.Drawing.Size(100, 20);
            this.txtDb.TabIndex = 1;
            this.txtDb.Text = "MonogoTEST";
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(108, 145);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(100, 20);
            this.txtUser.TabIndex = 2;
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(108, 172);
            this.txtPass.Name = "txtPass";
            this.txtPass.Size = new System.Drawing.Size(100, 20);
            this.txtPass.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Server";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "DBName";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(49, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "User";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(40, 172);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Pass";
            // 
            // chkIntSec
            // 
            this.chkIntSec.AutoSize = true;
            this.chkIntSec.Location = new System.Drawing.Point(108, 122);
            this.chkIntSec.Name = "chkIntSec";
            this.chkIntSec.Size = new System.Drawing.Size(113, 17);
            this.chkIntSec.TabIndex = 8;
            this.chkIntSec.Text = "Integrated security";
            this.chkIntSec.UseVisualStyleBackColor = true;
            this.chkIntSec.CheckedChanged += new System.EventHandler(this.ChkIntSec_CheckedChanged);
            // 
            // btnTestConn
            // 
            this.btnTestConn.Location = new System.Drawing.Point(108, 198);
            this.btnTestConn.Name = "btnTestConn";
            this.btnTestConn.Size = new System.Drawing.Size(100, 23);
            this.btnTestConn.TabIndex = 9;
            this.btnTestConn.Text = "Test connection";
            this.btnTestConn.UseVisualStyleBackColor = true;
            this.btnTestConn.Click += new System.EventHandler(this.BtnTestConn_Click);
            // 
            // btnSetConn
            // 
            this.btnSetConn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSetConn.Location = new System.Drawing.Point(108, 244);
            this.btnSetConn.Name = "btnSetConn";
            this.btnSetConn.Size = new System.Drawing.Size(100, 23);
            this.btnSetConn.TabIndex = 10;
            this.btnSetConn.Text = "Set connection";
            this.btnSetConn.UseVisualStyleBackColor = true;
            this.btnSetConn.Click += new System.EventHandler(this.BtnSetConn_Click);
            // 
            // ConnSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(235, 282);
            this.Controls.Add(this.btnSetConn);
            this.Controls.Add(this.btnTestConn);
            this.Controls.Add(this.chkIntSec);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPass);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.txtDb);
            this.Controls.Add(this.txtServer);
            this.Name = "ConnSetup";
            this.Text = "ConnSetup";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtServer;
        private System.Windows.Forms.TextBox txtDb;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkIntSec;
        private System.Windows.Forms.Button btnTestConn;
        private System.Windows.Forms.Button btnSetConn;
    }
}