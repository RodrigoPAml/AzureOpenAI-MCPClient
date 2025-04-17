using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    partial class ChatForm
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
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel2 = new TableLayoutPanel();
            tableLayoutPanel4 = new TableLayoutPanel();
            groupBox1 = new GroupBox();
            textBoxDeploymentName = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            textBoxEndpoint = new TextBox();
            textBoxKey = new TextBox();
            groupBox2 = new GroupBox();
            textBoxArgs = new TextBox();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            textBoxCommand = new TextBox();
            textBoxName = new TextBox();
            groupBox3 = new GroupBox();
            chatBox = new RichTextBox();
            tableLayoutPanel3 = new TableLayoutPanel();
            textBoxText = new TextBox();
            tableLayoutPanel5 = new TableLayoutPanel();
            btnReset = new Button();
            btnSend = new Button();
            btnApply = new Button();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            tableLayoutPanel5.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 0);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel3, 0, 1);
            tableLayoutPanel1.Location = new Point(12, 12);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 114F));
            tableLayoutPanel1.Size = new Size(940, 640);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 187F));
            tableLayoutPanel2.Controls.Add(tableLayoutPanel4, 1, 0);
            tableLayoutPanel2.Controls.Add(groupBox3, 0, 0);
            tableLayoutPanel2.Location = new Point(3, 3);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(934, 520);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel4.ColumnCount = 1;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel4.Controls.Add(groupBox1, 0, 0);
            tableLayoutPanel4.Controls.Add(groupBox2, 0, 1);
            tableLayoutPanel4.Location = new Point(750, 3);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 2;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.Size = new Size(181, 514);
            tableLayoutPanel4.TabIndex = 0;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(textBoxDeploymentName);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(textBoxEndpoint);
            groupBox1.Controls.Add(textBoxKey);
            groupBox1.Location = new Point(3, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(175, 251);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Azure OpenAI Config";
            // 
            // textBoxDeploymentName
            // 
            textBoxDeploymentName.Location = new Point(13, 176);
            textBoxDeploymentName.Name = "textBoxDeploymentName";
            textBoxDeploymentName.Size = new Size(154, 23);
            textBoxDeploymentName.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(14, 154);
            label3.Name = "label3";
            label3.Size = new Size(107, 15);
            label3.TabIndex = 4;
            label3.Text = "Deployment Name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(14, 92);
            label2.Name = "label2";
            label2.Size = new Size(55, 15);
            label2.TabIndex = 3;
            label2.Text = "Endpoint";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(15, 33);
            label1.Name = "label1";
            label1.Size = new Size(47, 15);
            label1.TabIndex = 2;
            label1.Text = "API Key";
            // 
            // textBoxEndpoint
            // 
            textBoxEndpoint.Location = new Point(12, 112);
            textBoxEndpoint.Name = "textBoxEndpoint";
            textBoxEndpoint.Size = new Size(154, 23);
            textBoxEndpoint.TabIndex = 1;
            // 
            // textBoxKey
            // 
            textBoxKey.Location = new Point(12, 53);
            textBoxKey.Name = "textBoxKey";
            textBoxKey.Size = new Size(154, 23);
            textBoxKey.TabIndex = 0;
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox2.Controls.Add(textBoxArgs);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(textBoxCommand);
            groupBox2.Controls.Add(textBoxName);
            groupBox2.Location = new Point(3, 260);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(175, 251);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "MCP Server Config (stdio)";
            // 
            // textBoxArgs
            // 
            textBoxArgs.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBoxArgs.Location = new Point(11, 175);
            textBoxArgs.Multiline = true;
            textBoxArgs.Name = "textBoxArgs";
            textBoxArgs.Size = new Size(154, 70);
            textBoxArgs.TabIndex = 11;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 157);
            label4.Name = "label4";
            label4.Size = new Size(124, 15);
            label4.TabIndex = 10;
            label4.Text = "Arguments (each line)";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(14, 97);
            label5.Name = "label5";
            label5.Size = new Size(64, 15);
            label5.TabIndex = 9;
            label5.Text = "Command";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(14, 34);
            label6.Name = "label6";
            label6.Size = new Size(39, 15);
            label6.TabIndex = 8;
            label6.Text = "Name";
            // 
            // textBoxCommand
            // 
            textBoxCommand.Location = new Point(12, 115);
            textBoxCommand.Name = "textBoxCommand";
            textBoxCommand.Size = new Size(154, 23);
            textBoxCommand.TabIndex = 7;
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(11, 52);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(154, 23);
            textBoxName.TabIndex = 6;
            // 
            // groupBox3
            // 
            groupBox3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox3.Controls.Add(chatBox);
            groupBox3.Location = new Point(3, 3);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(741, 514);
            groupBox3.TabIndex = 1;
            groupBox3.TabStop = false;
            groupBox3.Text = "Chat";
            // 
            // chatBox
            // 
            chatBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            chatBox.ForeColor = SystemColors.WindowText;
            chatBox.Location = new Point(6, 22);
            chatBox.Name = "chatBox";
            chatBox.ReadOnly = true;
            chatBox.Size = new Size(729, 486);
            chatBox.TabIndex = 0;
            chatBox.Text = "";
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel3.ColumnCount = 2;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 109F));
            tableLayoutPanel3.Controls.Add(textBoxText, 0, 0);
            tableLayoutPanel3.Controls.Add(tableLayoutPanel5, 1, 0);
            tableLayoutPanel3.Location = new Point(3, 529);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 1;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.Size = new Size(934, 108);
            tableLayoutPanel3.TabIndex = 1;
            // 
            // textBoxText
            // 
            textBoxText.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBoxText.Enabled = false;
            textBoxText.Location = new Point(3, 3);
            textBoxText.Multiline = true;
            textBoxText.Name = "textBoxText";
            textBoxText.PlaceholderText = "Type your message";
            textBoxText.Size = new Size(819, 102);
            textBoxText.TabIndex = 0;
            textBoxText.KeyDown += textBox_KeyDown;
            // 
            // tableLayoutPanel5
            // 
            tableLayoutPanel5.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel5.ColumnCount = 1;
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel5.Controls.Add(btnReset, 0, 1);
            tableLayoutPanel5.Controls.Add(btnSend, 0, 2);
            tableLayoutPanel5.Controls.Add(btnApply, 0, 0);
            tableLayoutPanel5.Location = new Point(828, 3);
            tableLayoutPanel5.Name = "tableLayoutPanel5";
            tableLayoutPanel5.RowCount = 3;
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel5.Size = new Size(103, 102);
            tableLayoutPanel5.TabIndex = 1;
            // 
            // btnReset
            // 
            btnReset.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnReset.Enabled = false;
            btnReset.Location = new Point(3, 36);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(97, 27);
            btnReset.TabIndex = 2;
            btnReset.Text = "Reset";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += btnReset_Click;
            // 
            // btnSend
            // 
            btnSend.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnSend.Enabled = false;
            btnSend.Location = new Point(3, 69);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(97, 30);
            btnSend.TabIndex = 0;
            btnSend.Text = "Send";
            btnSend.UseVisualStyleBackColor = true;
            btnSend.Click += buttonSend_Click;
            // 
            // btnApply
            // 
            btnApply.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnApply.Location = new Point(3, 3);
            btnApply.Name = "btnApply";
            btnApply.Size = new Size(97, 27);
            btnApply.TabIndex = 1;
            btnApply.Text = "Apply Configs";
            btnApply.UseVisualStyleBackColor = true;
            btnApply.Click += btnApply_Click;
            // 
            // ChatForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(964, 664);
            Controls.Add(tableLayoutPanel1);
            Name = "ChatForm";
            Text = "MCP Client Azure OpenAI";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel4.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            tableLayoutPanel5.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private TableLayoutPanel tableLayoutPanel3;
        private TextBox textBoxText;
        private TableLayoutPanel tableLayoutPanel4;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private RichTextBox chatBox;
        private TextBox textBoxEndpoint;
        private TextBox textBoxKey;
        private Label label2;
        private Label label1;
        private TextBox textBoxDeploymentName;
        private Label label3;
        private TextBox textBoxArgs;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox textBoxCommand;
        private TextBox textBoxName;
        private TableLayoutPanel tableLayoutPanel5;
        private Button btnSend;
        private Button btnApply;
        private Button btnReset;
    }
}
