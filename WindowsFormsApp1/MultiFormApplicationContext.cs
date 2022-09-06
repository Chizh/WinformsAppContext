namespace WindowsFormsApp1
{
    using System;
    using System.Threading;
    using System.Windows.Forms;

    public class MultiFormApplicationContext
        : ApplicationContext
    {
        public MultiFormApplicationContext()
        {
            var form1 = new Form1();
            form1.Show();
            
            var form2 = new Form1();
            form2.Show();

            form2.Closed += (sender, args) =>
            {
                this.ExitThread();
            };

            new Thread(() =>
            {
                while (true)
                {
                    Thread.Sleep(
                        timeout: TimeSpan.FromSeconds(0.5));

                    form1.UpdateText();
                    form2.UpdateText();
                }
            }).Start();
        }
    }
}