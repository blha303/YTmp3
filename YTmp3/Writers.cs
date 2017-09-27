using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace YTmp3
{
    class Writers
    {
        // Console.Write pipe to textbox
        public class TextBoxWriter : TextWriter
        {
            private TextBox textbox;
            public TextBoxWriter(TextBox textbox)
            {
                this.textbox = textbox;
            }

            public override void Write(char value)
            {
                Write(value.ToString());
            }

            public override void Write(string value)
            {
                textbox.Invoke(new MethodInvoker(delegate { textbox.AppendText(value); }));
            }

            public override Encoding Encoding {
                get { return Encoding.ASCII; }
            }
        }
    }
}
