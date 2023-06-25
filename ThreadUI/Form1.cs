namespace ThreadUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label2.Text = Thread.CurrentThread.ManagedThreadId.ToString();
            Thread thread = new Thread(() =>
            {
                label3.Text = Thread.CurrentThread.ManagedThreadId.ToString();
                for (int i = 0; i < 10000; i++)
                {
                    label1.Text = i.ToString();
                    Thread.Sleep(100);
                }
            });
            thread.IsBackground = true;
            thread.Start();
        }
    }
}