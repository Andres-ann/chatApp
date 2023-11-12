namespace Client
{
    partial class ChatForm
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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.lblUser = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 20;
            this.listBox1.Location = new System.Drawing.Point(25, 77);
            this.listBox1.Name = "listBox1";
            this.listBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.listBox1.Size = new System.Drawing.Size(490, 384);
            this.listBox1.TabIndex = 0;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUser.Location = new System.Drawing.Point(156, 184);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(64, 20);
            this.lblUser.TabIndex = 1;
            this.lblUser.Text = "Usuario";
            // 
            // btnConnect
            // 
            this.btnConnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConnect.Location = new System.Drawing.Point(238, 255);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(78, 31);
            this.btnConnect.TabIndex = 3;
            this.btnConnect.Text = "Conectar";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // txtUser
            // 
            this.txtUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUser.Location = new System.Drawing.Point(153, 216);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(257, 29);
            this.txtUser.TabIndex = 4;
            // 
            // txtMessage
            // 
            this.txtMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMessage.Location = new System.Drawing.Point(25, 486);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(406, 29);
            this.txtMessage.TabIndex = 5;
            // 
            // btnSend
            // 
            this.btnSend.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSend.Location = new System.Drawing.Point(437, 487);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(78, 29);
            this.btnSend.TabIndex = 6;
            this.btnSend.Text = "Enviar";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnDisconnect.Enabled = false;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Location = new System.Drawing.Point(25, 532);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(87, 28);
            this.btnDisconnect.TabIndex = 7;
            this.btnDisconnect.Text = "Desconectar";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // ChatForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 563);
            this.Controls.Add(this.btnDisconnect);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.listBox1);
            this.Name = "ChatForm";
            this.Text = "ChatForm";
            this.Load += new System.EventHandler(this.ChatForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnDisconnect;
    }
}