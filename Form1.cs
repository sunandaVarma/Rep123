using SmartManagerWindows;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TFS.Reporting;

namespace SampleTests
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                BurnReport rep = ClientApplication.Manager.RunTest();
            }
            catch (Exception ex)
            {
                using (System.IO.StreamWriter sr = new System.IO.StreamWriter(new System.IO.FileStream("c:\\abc.txt", System.IO.FileMode.OpenOrCreate)))
                {
                    sr.WriteLine(ex.Message);
                    sr.WriteLine(ex.StackTrace);
                    if (ex.InnerException != null)
                    {
                        sr.WriteLine(ex.InnerException.Message);
                    }
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
    }
}
