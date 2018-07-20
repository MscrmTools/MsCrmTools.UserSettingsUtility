using System;
using System.Drawing;
using System.Windows.Forms;

namespace MsCrmTools.UserSettingsUtility.AppCode
{
    class DialogueBoxManager
    {


       public static DialogResult DialogBox(string title, string promptText, string button1Label = "OK", string button2Label = "Cancel", string button3Label = null )
        {
            Form form = new Form();
            Label label = new Label();
            Button button1 = new Button();
            Button button2 = new Button();
            Button button3 = new Button();

            int buttonStartPos = 228; //Standard two button position

            if (button3Label != null)
                buttonStartPos = 228 - 81;
            else
            {
                button3.Visible = false;
                button3.Enabled = false;
            }


            form.Text = title;

            // Label
            label.Text = promptText;
            label.SetBounds(9, 20, 372, 13);
            label.Font = new Font("Microsoft Tai Le", 10, FontStyle.Regular);

            button1.Text = button1Label;
            button2.Text = button2Label;
            button3.Text = button3Label ?? string.Empty;
            button1.DialogResult = DialogResult.Yes;
            button2.DialogResult = DialogResult.Ignore;
            button3.DialogResult = DialogResult.Abort;


            button1.SetBounds(buttonStartPos, 72, 75, 23);
            button2.SetBounds(buttonStartPos + 81, 72, 75, 23);
            button3.SetBounds(buttonStartPos + (2 * 81), 72, 75, 23);

            label.AutoSize = true;
            button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button3.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new Size(396, 107);
            form.Controls.AddRange(new Control[] { label, button1, button2 });
            if (button3Label != null)
                form.Controls.Add(button3);

            form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = button1;
            form.CancelButton = button2;

            DialogResult dialogResult = form.ShowDialog();            
            return dialogResult;
        }

    }
}
