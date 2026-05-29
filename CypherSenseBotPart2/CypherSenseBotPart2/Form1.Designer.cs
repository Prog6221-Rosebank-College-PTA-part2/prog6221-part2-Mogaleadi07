namespace CypherSenseBotPart2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            richTextBox1 = new RichTextBox();
            textBox1 = new TextBox();
            sendButton = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.DarkCyan;
            label1.Font = new Font("Elephant", 15.7499981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(258, 9);
            label1.Name = "label1";
            label1.Size = new Size(259, 27);
            label1.TabIndex = 0;
            label1.Text = "CYPHERSENSEBOT";
            // 
            // richTextBox1
            // 
            richTextBox1.BackColor = SystemColors.ControlText;
            richTextBox1.Location = new Point(61, 58);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.ReadOnly = true;
            richTextBox1.Size = new Size(672, 298);
            richTextBox1.TabIndex = 1;
            richTextBox1.Text = "";
            // 
            // textBox1
            // 
            textBox1.BackColor = SystemColors.ActiveCaptionText;
            textBox1.ForeColor = SystemColors.Control;
            textBox1.Location = new Point(61, 381);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(173, 23);
            textBox1.TabIndex = 2;
            // 
            // sendButton
            // 
            sendButton.BackColor = Color.DarkRed;
            sendButton.ForeColor = Color.Black;
            sendButton.Location = new Point(636, 381);
            sendButton.Name = "sendButton";
            sendButton.Size = new Size(75, 23);
            sendButton.TabIndex = 3;
            sendButton.Text = "SEND";
            sendButton.UseVisualStyleBackColor = false;
            sendButton.Click += sendButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DimGray;
            ClientSize = new Size(800, 450);
            Controls.Add(sendButton);
            Controls.Add(textBox1);
            Controls.Add(richTextBox1);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private RichTextBox richTextBox1;
        private TextBox textBox1;
        private Button sendButton;
    }
}
