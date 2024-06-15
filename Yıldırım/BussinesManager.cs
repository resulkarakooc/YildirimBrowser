using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Yıldırım
{
    public class BussinesManager : IBusssinesService
    {
        private Form1 form1; // Form1 sınıfından bir nesne

        // Form1 nesnesini alacak bir constructor tanımlayabilirsiniz
        public BussinesManager(Form1 form)
        {
            form1 = form;
        }

        public void NewTab()
        {
            Button buton = new Button();
            buton.Height = 50;
            buton.Width = 100;
            buton.Top = 0;
            buton.Left = 200;
            buton.Text = "Yeni Sekme";

            // form1 nesnesinin Controls koleksiyonuna butonu ekleyin
            form1.Controls.Add(buton);
        }
    }

}
