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

            var updateThread = new Thread(() =>
            {
                while (true)
                {
                    Thread.Sleep(
                        timeout: TimeSpan.FromSeconds(0.5));

                    form1.UpdateText();
                    form2.UpdateText();
                }
            });
            
            form2.Closed += (sender, args) =>
                OnCloseAnyForm(
                    threadToAbort: updateThread);

            form1.Closed += (sender, args) =>
                OnCloseAnyForm(
                    threadToAbort: updateThread);
            
            updateThread.Start();
        }

        private void OnCloseAnyForm(
            Thread threadToAbort)
        {
            threadToAbort.Abort();
            this.ExitThread();
        }
    }
}