using System;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace mingrisoft_3_
{
    public partial class ImgCompare : Form
    {
        /// <summary>
        /// 删除相同图片方式
        /// </summary>
        ///进入文件夹，读取图片文件，计算其base64值，写入csv，
        ///文件路径+图片名称+base64值，对比所有base64值，将相同项取出，找出文件并删除
        public ImgCompare()
        {
            InitializeComponent();
        }


        #region btn - 选择文件夹
        /// <summary>
        /// 获取路径
        /// </summary>
        private void btnReadFloder_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                TBFloderPath.Text = folderBrowserDialog1.SelectedPath;
            }
        }
        /// <summary>
        /// 将图片转移保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveFolder_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                TBFloderPath.Text = folderBrowserDialog1.SelectedPath;
            }
        }
        private void btnCompareFloder_Click(object sender, EventArgs e)
        {

        }
        //保存记录
        private void btnSaveRecord_Click(object sender, EventArgs e)
        {
            rTBInfo.Text = "";//重置富文本控件
            
            FileStream fs = new FileStream("D:\\imgRead.txt", FileMode.Append);
            StreamWriter sw = new StreamWriter(fs);
            string write = "";
            string[] endsWith = { ".png", ".jpg", ".jpeg", ".bmp" };
            folderBrowserDialog1.Description = "请选择文件路径";
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                TBFloderPath.Text = folderBrowserDialog1.SelectedPath;                    //path
                string[] filesAll = Directory.GetFiles(folderBrowserDialog1.SelectedPath);//所有子目录
                string[] filesFolder = Directory.GetDirectories(folderBrowserDialog1.SelectedPath);//所有文件夹子目录
                foreach (string item in filesAll)
                {
                    //判断图片
                    for (int i = 0; i < endsWith.Length; i++)
                    {
                        if (item.EndsWith(endsWith[i]))
                        {
                            //如果是图片
                            FileStream fileStream = File.OpenRead(item);
                            int fileLength = 0;
                            fileLength = (int)fileStream.Length;
                            byte[] image = new Byte[fileLength];
                            fileStream.Read(image, 0, fileLength);
                            System.Drawing.Image result = System.Drawing.Image.FromStream(fileStream);
                            string bb64 = Hash(ByteToBase64(result));
                            write = item + "," + bb64;
                            rTBInfo.Text = rTBInfo.Text + "" + write + "\n";

                            sw.WriteLine(item + "," + bb64);
                        }
                    }
                }
            }
        }

        private void btnDelectThisFile_Click(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            rTBInfo.Clear();
            Thread thread = new Thread(new ThreadStart(ThreadDeleteJSON));
            thread.Start();
            
            //getFiles(TBFloderPath.Text,1);
        }
        void ThreadDeleteJSON()
        {
            rTBInfo.SelectionStart = rTBInfo.TextLength;
            rTBInfo.ScrollToCaret();
            int jsonDele = 0,picCount=0;
            //循环删除 json
            string[] sonForFolder= { "" };
            string[] sonForGoal = { "" };
            string[] endsWith = { ".png", ".jpg", ".jpeg", ".bmp",",JPG" };
            DirectoryInfo di;//,diMoveto;
            try
            {
                sonForFolder = Directory.GetDirectories(@TBFloderPath.Text.ToString());
                foreach (string item in sonForFolder)
                {
                    sonForGoal = Directory.GetFiles(item);
                    rTBInfo.Text = rTBInfo.Text + "\n进入文件夹 : " + item + ", 子目录长 : " + sonForGoal.Length;
                    if (sonForGoal.Length == 0)
                    {
                        di = new DirectoryInfo(item);
                        di.Delete(true);
                        rTBInfo.Text = rTBInfo.Text + "\n删除文件夹 : " + item;
                    }
                    foreach (string ite in sonForGoal)
                    {
                        rTBInfo.Text = rTBInfo.Text + "\n判断文件 : " + ite;
                        if (ite.EndsWith(".json"))
                        {
                            File.Delete(@ite);
                            rTBInfo.Text = rTBInfo.Text + "\n删除文件 : " + ite;
                            LblTip.Text = ite;
                            jsonDele++;
                        }
                        else// if(ite.EndsWith(".jpg"))
                        {
                            picCount++;
                            //记录已经查找好的图片数目并转移到新文件夹
                            //获取文件名
                            //使用dimoveto对象
                            /*
                            string[] iteName = @ite.Split('\\');
                            LblTip.Text = iteName[iteName.Length - 1];
                            diMoveto = new DirectoryInfo(@ite);
                            try
                            {
                                diMoveto.MoveTo(@TBAddName.Text.ToString() + "\\" + iteName[iteName.Length - 1]);
                            }
                            catch (Exception)
                            {
                                diMoveto.MoveTo(@TBAddName.Text.ToString() + "\\重复"+picCount+"" + iteName[iteName.Length - 1]);
                            }
                            rTBInfo.Text = rTBInfo.Text + "\n转移文件 : " + ite;
                            */
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
                //LblTip.Text = "失败，请重新选择文件夹";
            }
            LblTip.Text = "找出图片:" + picCount + ", 找出json文件：" + jsonDele + "个";
        }

        //使用递归获取照片，返回地址与加密值
        public void getFiles(string pathGet,int i)
        {
            string path = @pathGet;

            string [] SonForFilesAll = { "" };
            string [] SonForFolder = { "" };
            string[] endsWith = { ".png", ".jpg", ".jpeg", ".bmp" };
            rTBInfo.Text = rTBInfo.Text + "\nBEGIN：" + i + " "+path;
            try
            {
                SonForFilesAll = Directory.GetFiles(path);
                rTBInfo.Text = rTBInfo.Text + "\n进展try：" + i + " " + SonForFilesAll.Length;
            }
            catch (Exception)
            {
                //不是文件夹
                foreach(string item in endsWith)
                {
                    if (path.EndsWith(".json"))
                    {
                        File.Delete(path);
                    }else if (path.EndsWith(item))
                    {
                        rTBInfo.Text = rTBInfo.Text + "\n图片ei：" + item;
                    }
                    rTBInfo.Text = rTBInfo.Text + "\ncatch：" + i + " " + path;
                }
            }
            finally
            {
                if(SonForFilesAll.Length <= 0)
                {
                    DirectoryInfo di = new DirectoryInfo(path);
                    di.Delete(true);
                }else
                {
                    foreach (string item in SonForFilesAll)
                    {
                        rTBInfo.Text = rTBInfo.Text + "\n进展：" + item;
                        getFiles(item, i + 1);
                    }
                }
            }
            
        }
        //将BB64再次加密转换
        public string Hash(string data)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(data);
            byte[] hash = SHA256Managed.Create().ComputeHash(bytes);

            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                builder.Append(hash[i].ToString("X2"));
            }

            return builder.ToString();
        }
        #endregion

        #region btn - 两张图片对比
        private void btnCompare_Click(object sender, EventArgs e)
        {
            if (btnAddPic1.Image == null || btnAddPic2.Image == null)
            {
                MessageBox.Show("无图片");
            }
            else
            {
                string str1 = ByteToBase64(btnAddPic1.Image);
                string str2 = ByteToBase64(btnAddPic2.Image);
                MessageBox.Show(str1 == str2 ? "相同图片" : "不同图片");
            }
        }
        #endregion
        
        #region  base64计算图片值
        public string ByteToBase64(Image ImgByte)
        {
            string base64buffer = string.Empty;

            try
            {
                if (ImgByte != null)
                {
                    byte[] bytes = ImgToByte(ImgByte);
                    base64buffer = Convert.ToBase64String(bytes);
                }
            }
            catch (Exception)
            { }
            return base64buffer;
        }
        //将图片转换为字节流
        public byte[] ImgToByte(Image image)
        {
            MemoryStream mstream = new MemoryStream();
            image.Save(mstream, System.Drawing.Imaging.ImageFormat.Bmp);
            byte[] byData = new Byte[mstream.Length];
            mstream.Position = 0;
            mstream.Read(byData, 0, byData.Length); mstream.Close();
            return byData;
        }
        #endregion

    }
}
