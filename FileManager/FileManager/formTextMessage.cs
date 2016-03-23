using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FileManager {
    public partial class formTextMessage : Form {
        private readonly string _formTitle;
        private readonly bool _lockMessage;
        private string _formMessage;

        public string FormMessage {
            get {
                return _formMessage;
            }
        }

        public formTextMessage(string formTitle, string formMessage, bool lockMessage=false) {
            InitializeComponent();

            _formTitle = formTitle;
            _formMessage = formMessage;
            _lockMessage = lockMessage;
        }

        private void formTextMessage_Load(object sender, EventArgs e) {
            this.Text = _formTitle;
            this.txtMessage.Text = _formMessage;
            this.txtMessage.ReadOnly = _lockMessage;

            this.txtMessage.Select(0, 0);
        }

        private void btnOK_Click(object sender, EventArgs e) {
            _formMessage = txtMessage.Text;
        }
    }
}
