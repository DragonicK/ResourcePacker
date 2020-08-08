using System;
using System.Windows.Forms;

namespace ResourcePacker {
    public class InputBoxDialog : Form {
        public string Input { get; set; } = string.Empty;
        public string Caption { get; set; } = string.Empty;
        public string Response { get; set; } = string.Empty;

        private Button ButtonOK;
        private TextBox TextInput;
        private Button ButtonCancel;
        private Label LabelTitle;

        private System.ComponentModel.Container components = null;

        public InputBoxDialog() {
            InitializeComponent();

            Load += InputBoxDialog_Load;

            ButtonOK.Click += ButtonOK_Click;
            ButtonCancel.Click += ButtonCancel_Click;
            TextInput.KeyDown += TextInput_KeyDown;
        }

        private void TextInput_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                ButtonOK_Click(null, null);
            }         
        }

        private void InputBoxDialog_Load(object sender, EventArgs e) {
            TextInput.Text = Input;
            LabelTitle.Text = Caption;

            TextInput.SelectionStart = 0;
            TextInput.SelectionLength = TextInput.Text.Length;
            TextInput.Focus();
        }

        #region Dispose

        protected override void Dispose(bool disposing) {
            if (disposing) {
                if (components != null) {
                    components.Dispose();
                }
            }

            base.Dispose(disposing);
        }

        #endregion

        private void ButtonOK_Click(object sender, EventArgs e) {
            Response = TextInput.Text;
            Close();
        }

        private void ButtonCancel_Click(object sender, EventArgs e) {
            Response = string.Empty;
            Close();            
        }

        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InputBoxDialog));
            this.ButtonOK = new System.Windows.Forms.Button();
            this.TextInput = new System.Windows.Forms.TextBox();
            this.ButtonCancel = new System.Windows.Forms.Button();
            this.LabelTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ButtonOK
            // 
            this.ButtonOK.Location = new System.Drawing.Point(357, 12);
            this.ButtonOK.Name = "ButtonOK";
            this.ButtonOK.Size = new System.Drawing.Size(75, 23);
            this.ButtonOK.TabIndex = 2;
            this.ButtonOK.Text = "OK";
            this.ButtonOK.UseVisualStyleBackColor = true;
            // 
            // TextInput
            // 
            this.TextInput.Location = new System.Drawing.Point(12, 90);
            this.TextInput.Name = "TextInput";
            this.TextInput.Size = new System.Drawing.Size(420, 22);
            this.TextInput.TabIndex = 1;
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonCancel.Location = new System.Drawing.Point(357, 41);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(75, 23);
            this.ButtonCancel.TabIndex = 3;
            this.ButtonCancel.Text = "Cancel";
            this.ButtonCancel.UseVisualStyleBackColor = true;
            // 
            // LabelTitle
            // 
            this.LabelTitle.Location = new System.Drawing.Point(12, 16);
            this.LabelTitle.Name = "LabelTitle";
            this.LabelTitle.Size = new System.Drawing.Size(339, 48);
            this.LabelTitle.TabIndex = 3;
            this.LabelTitle.Text = "label1";
            // 
            // InputBoxDialog
            // 
            this.ClientSize = new System.Drawing.Size(444, 125);
            this.Controls.Add(this.LabelTitle);
            this.Controls.Add(this.ButtonCancel);
            this.Controls.Add(this.TextInput);
            this.Controls.Add(this.ButtonOK);
            this.Font = new System.Drawing.Font("Consolas", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InputBoxDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Resource Packer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}