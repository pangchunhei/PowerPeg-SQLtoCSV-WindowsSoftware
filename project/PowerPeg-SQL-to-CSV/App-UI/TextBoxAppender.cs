﻿using ChoETL;
using log4net;
using log4net.Appender;
using PowerPeg_SQL_to_CSV.Log;

namespace App_UI
{
    //https://stackoverflow.com/questions/14114614/configuring-log4net-textboxappender-custom-appender-via-xml-file
    /// <summary>
    /// Show the log4net inside the application text box
    /// </summary>
    public class TextBoxAppender : AppenderSkeleton
    {
        private TextBox _textBox;
        public TextBox AppenderTextBox
        {
            get
            {
                return _textBox;
            }
            set
            {
                _textBox = value;
            }
        }
        public string FormName { get; set; }
        public string TextBoxName { get; set; }

        private Control FindControlRecursive(Control root, string textBoxName)
        {
            if (root.Name == textBoxName) return root;
            foreach (Control c in root.Controls)
            {
                Control t = FindControlRecursive(c, textBoxName);
                if (t != null) return t;
            }
            return null;
        }

        protected override void Append(log4net.Core.LoggingEvent loggingEvent)
        {
            if (_textBox == null)
            {
                if (String.IsNullOrEmpty(FormName) ||
                    String.IsNullOrEmpty(TextBoxName))
                    return;

                Form form = Application.OpenForms[FormName];
                if (form == null)
                    return;

                _textBox = (TextBox)FindControlRecursive(form, TextBoxName);
                if (_textBox == null)
                    return;

                form.FormClosing += (s, e) => _textBox = null;
            }
            _textBox.BeginInvoke((MethodInvoker)delegate
            {
                if (_textBox != null)
                {
                    _textBox.AppendText(RenderLoggingEvent(loggingEvent));
                }
            });
        }
    }
}