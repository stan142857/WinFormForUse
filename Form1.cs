using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NPlot;

namespace mingrisoft_3_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CodeImage(CheckCode());
        }
        #region 选取某文件并查看属性
        private void button1_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog()==DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName;
                FileInfo info = new FileInfo(textBox1.Text);
                string strName = info.Name;
                string strFullName = info.FullName;
                string strCreateTime = info.CreationTime.ToLongDateString();
                long strSize = info.Length;
                string strReadOnly = info.IsReadOnly.ToString();
                string strShow = string.Format("文件名：{0}\n文件路径：{1}\n文件创建时间：{2}\n文件大小：{3}\n" +
                    "文件是否只读：{4}",strName,strFullName,strCreateTime,strSize,strReadOnly);
                MessageBox.Show(strShow);
            }
        }
        #endregion
        #region 读取以及写入文本文件
        FileMode filem = FileMode.Open;//声明一个filemode对象来记录打开的方式
        private void button2_Click(object sender, EventArgs e)
        {
            string path = textBox1.Text;//获取打开文件的路径
            try
            {
                using (FileStream fs = File.Open(path, filem))//以指定的方式打开文件
                {
                    if (filem != FileMode.Truncate)//如果在打开文件后不清空文件
                    {
                        byte[] info = new UTF8Encoding(true).GetBytes(textBox2.Text);//将要添加的内容转换成字节
                        fs.Write(info, 0, info.Length);//向文件中写入内容
                    }
                }
                using (FileStream fs = File.Open(path, FileMode.Open))//以读写方式打开文件
                {
                    byte[] b = new byte[1024];//定义一个字节数组
                    UTF8Encoding temp = new UTF8Encoding(true);//实现一个UTF8编码
                    string pp = "";
                    while (fs.Read(b, 0, b.Length) > 0)//读取文本内容
                    {
                        pp += temp.GetString(b);//累加读取的结果
                    }
                    MessageBox.Show(pp);//显示文本中的内容
                }
            }
            catch
            {
                if (MessageBox.Show("该文件不存在，是否创建文件？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    FileStream fs = File.Open(path, FileMode.CreateNew);//在制定的路径下创建文件
                    fs.Dispose();//释放流
                }
            }

        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton1.Checked==true)
            {
                filem = FileMode.Open;
            }
            if(radioButton2.Checked==true)
            {
                filem = FileMode.Append;
            }
            if(radioButton3.Checked==true)
            {
                filem = FileMode.Truncate;
            }
            if(radioButton4.Checked==true)
            {
                filem = FileMode.Create;
            }
            //if (((RadioButton)sender).Checked == true)
            //{
            //    switch (Convert.ToInt32(((RadioButton)sender).Tag.ToString()))
            //    {
            //        case 0: filem = FileMode.Open; break;//以读/写方式打开文件
            //        case 1: filem = FileMode.Append; break;//追加方式打开
            //        case 2: filem = FileMode.Truncate; break;//打开文件后清空
            //        case 3: filem = FileMode.Create; break;//覆盖方式打开
            //    }
            //}
        }
        #endregion

        private void button3_Click(object sender, EventArgs e)
        {
            CodeImage(CheckCode());
        }
        /// <summary>
        /// 生成验证码
        /// </summary>
        private string CheckCode()
        {
            int number;
            char code;
            string checkCode = string.Empty;
            Random random = new Random();
            for (int i = 0; i < 4; i++)
            {
                number = random.Next();
                if (number % 2 == 0)
                    code = (char)('0' + (char)(number % 10));
                else
                    code = (char)('A' + (char)(number % 26));
                checkCode += " " + code.ToString();
            }
            return checkCode;
        }
        /// <summary>
        /// 绘制验证码图形
        /// </summary>
        private void CodeImage(string checkCode)
        {
            if (checkCode == null || checkCode.Trim() == string.Empty)
                return;
            Bitmap image = new Bitmap((int)Math.Ceiling((checkCode.Length * 8.5)), 21);
            Graphics g = Graphics.FromImage(image);//创建随机生成器
            try
            {
                Random random = new Random();
                g.Clear(Color.White);
                for (int i = 0; i < 3; i++)
                {
                    int x1 = random.Next(image.Width);
                    int x2 = random.Next(image.Width);
                    int y1 = random.Next(image.Height);
                    int y2 = random.Next(image.Height);
                    g.DrawLine(new Pen(Color.Black), x1, y1, x2, y2);
                }
                Font font = new Font("Arial", 12, (FontStyle.Bold));
                g.DrawString(checkCode, font, new SolidBrush(Color.Red), 2, 2);
                for (int i = 0; i < 150; i++)
                {
                    int x = random.Next(image.Width);
                    int y = random.Next(image.Height);
                    image.SetPixel(x, y, Color.FromArgb(random.Next()));
                }
                //画图片的边框线
                g.DrawRectangle(new Pen(Color.Silver), 0, 0, image.Width - 1, image.Height - 1);
                /*
                 * 添加pictureBox1控件
                 * */
                this.pictureBox1.Width = image.Width;
                this.pictureBox1.Height = image.Height;
                this.pictureBox1.BackgroundImage = image;
                
            }
            catch { }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            plot.Clear();   //对象名称为plot
            // --- Grid Code ---
            Grid mygrid = new Grid();
            mygrid.HorizontalGridType = Grid.GridType.None;
            mygrid.VerticalGridType = Grid.GridType.Fine;
            plot.Add(mygrid);
            plot.Title = "K-line";
            //普通线
            StepPlot line = new StepPlot();
            line.Pen = new Pen(Color.Red, 1);
            line.OrdinateData = new double[] { 0, 1, 0, 1, 1, 0.5,1,1,1 };
            line.HideVerticalSegments = false;
            plot.Add(line);
            plot.Refresh();
            //蜡烛图
            int[] opens = { 1, 2, 1, 2, 1, 3 };     //开始数目
            double[] closes = { 2, 2, 2, 1, 2, 1 }; //结束数目
            float[] lows = { 1, 1, 1, 1, 1, 1 };    //最高
            System.Int64[] highs = { 3, 2, 3, 3, 3, 4 }; //最低
            int[] times = { 0, 1, 2, 3, 4, 5 };      //时间
            CandlePlot cp = new CandlePlot();
            cp.CloseData = closes;
            cp.OpenData = opens;
            cp.LowData = lows;
            cp.HighData = highs;
            cp.AbscissaData = times;
            plot2.Title = "蜡烛图";
            this.plot2.Add(cp);
            //水平+垂直 线
            plot3.Add(mygrid);
            HorizontalLine line3 = new HorizontalLine(10);//水平线
            VerticalLine line4 = new VerticalLine(10);//垂直线
            line3.LengthScale = 2.89f;
            line4.LengthScale = 0.89f;

            plot3.Title = "水平+垂直 线";

            plot3.Add(line3, 10);
            plot3.Add(line4,1);



            return;
        }
    }
}
