using System;
using System.Windows.Forms;
using System.Threading;

namespace mingrisoft_3_
{
    public partial class threadTest : Form
    {
        public threadTest()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }
        private void ThreadTest_Load(object sender, EventArgs e)
        {
            //进度条线程演示
            t1 = new Thread(new ThreadStart(Pro1));
            t1.Start();
            t2 = new Thread(new ThreadStart(Pro2));
            t2.Start();
        }
        #region 幂的线程运算演示

        Thread myThread = null;//声明引用

        private void BtnCal_Click(object sender, EventArgs e)
        {

            int a2 = Convert.ToInt32(tB21.Text.Trim());
            int b2 = Convert.ToInt32(tB22.Text.Trim());

            tB23.Text = Math.Pow(a2, b2).ToString();
            myThread = new Thread(new ThreadStart(SetAddFile));
            myThread.IsBackground = true;  //设置为后台进程，关闭时自动关闭
            myThread.Start();
            
            int a3 = Convert.ToInt32(tB31.Text.Trim());
            int b3 = Convert.ToInt32(tB32.Text.Trim());
            tB33.Text = Math.Pow(a3,b3).ToString();

        }
        public delegate void AddFile();  //定义托管线程
        //设置托管线程
        public void SetAddFile()
        {
            this.Invoke(new AddFile(RunAddFile));//对指定的线程进行托管
        }
        public void RunAddFile()
        {
            int a1 = Convert.ToInt32(tB11.Text.Trim());
            int b1 = Convert.ToInt32(tB12.Text.Trim());

            tB13.Text = Math.Pow(a1, b1).ToString();
            Thread.Sleep(0);//持起主线程
            myThread.Abort();//执行线程
        }

        #endregion

        #region 进度条线程演示

        Thread t1, t2;
        void Pro1()
        {
            int count = 0;
            while(true)
            {
                progressBar1.PerformStep();
                count += progressBar1.Step;
                Thread.Sleep(100);
                if(count == 20)
                {
                    t2.IsBackground = true;
                    t2.Join(1000);
                }
            }
        }


        void Pro2()
        {
            int count = 0;
            while(true)
            {
                progressBar2.PerformStep();
                count += progressBar1.Step;
                Thread.Sleep(100);
                if(count == 50)
                {
                    t1.IsBackground = true;
                    t1.Join(1000);
                }
            }
        }
        #endregion
    }
}
