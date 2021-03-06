﻿using System;
using System.Windows.Forms;

namespace Mafia2Tool
{
    public partial class NewObjectForm : Form
    {
        public int type = -1;
        public object[] data;
        public Control control;

        public NewObjectForm(bool nameEnabled)
        {
            InitializeComponent();
            Localise();

           textBox1.Enabled = nameEnabled;
        }

        private void Localise()
        {
            buttonCancel.Text = Language.GetString("$CANCEL");
            buttonContinue.Text = Language.GetString("$CONTINUE");
            Text = Language.GetString("$NEWOBJFORM_TITLE");
        }

        public void LoadOption(Control desiredControl)
        {
            control = desiredControl;
            panel1.Controls.Add(control);          
        }

        public void SetLabel(string text)
        {
            label.Text = text;
        }

        public string GetInputText()
        {
            return textBox1.Text;
        }

        public void OnButtonClickContinue(object sender, EventArgs e)
        {
            type = 1;
            Close();
        }

        public void OnButtonClickCancel(object sender, EventArgs e)
        {
            type = -1;
            Close();
        }
    }
}
