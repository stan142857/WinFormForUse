using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mingrisoft_3_
{
    public partial class geneTest : Form
    {
        public geneTest()
        {
            InitializeComponent();
        }

        private void geneTest_Load(object sender, EventArgs e)
        {
            //泛型数据填充
            Person p1 = new Person("张二", 31);
            Person p2 = new Person("张六", 49);
            Person p3 = new Person("张三", 33);
            List<Person> persons = new List<Person>{p1,p2,p3};
            lblinfo.Text = "数据填充完成!";
            Persons personCol = new Persons{p1,p2,p3};
            BtnDo.Text = personCol.GetAllNames();

            //按照默认规则对集合进行排序,通过不带参数的Sort方法对集合进行排序 - 通过数字
            //persons.Sort();
            //用 1 号比较器，Compare方法，对集合进行排序 - 通过名称
            //persons.Sort(NameComparer.Default);
            //用 2 号比较器，通过内置的泛型委托System.Comparison<T>，对集合排序 - 名称
            System.Comparison<Person> NameComparison = new System.Comparison<Person>(PersonComparison.Name);
            persons.Sort(NameComparison);
            //输出所有人姓名
            foreach (Person p in persons)
            {
                textBox1.Text += p.Name+" ";
            }
            //用 3 号搜索器 - 输出所有中年人姓名
            System.Predicate<Person> MidAgePredicate = new System.Predicate<Person>(PersonPredicate.MidAge);
            List<Person> MidAgePersons = persons.FindAll(MidAgePredicate);
            foreach(Person p in MidAgePersons)
            {
                textBox2.Text += p.Name + " ";
            }
        }

        private void BtnWpf_Click(object sender, EventArgs e)
        {
            var r = new Random();

            var values = new Dictionary<string, double>();

            values["MX"] = r.Next(0, 100);
            values["CA"] = r.Next(0, 100);
            values["US"] = r.Next(0, 100);
            values["IN"] = r.Next(0, 100);
            values["CN"] = r.Next(0, 100);
            values["JP"] = r.Next(0, 100);
            values["BR"] = r.Next(0, 100);
            values["DE"] = r.Next(0, 100);
            values["FR"] = r.Next(0, 100);
            values["GB"] = r.Next(0, 100);

            var lang = new Dictionary<string, string>();
            lang["MX"] = "México"; // change the language if necessary
            
        }

        private void BtnDo_Click(object sender, EventArgs e)
        {

        }
    }
    #region 定义Person类，使用接口，调用默认规则
    class Person :IComparable<Person>
    {
        private string _name;
        private int _age;
        public Person(string Name,int Age)
        {
            this._name = Name;
            this._age = Age;
        }
        public string Name
        {
            get { return _name; }
        }
        public int Age
        {
            get { return _age; }
        }
        //实现接口 - 年龄排序 - IComparable
        public int CompareTo(Person p)
        {
            return this.Age - p.Age;
        }
    }
    //定义Persons集合类 - 通过继承来进行扩展
    class Persons : List<Person>
    {
        public string GetAllNames()
        {
            if (this.Count == 0)
                return "";
            string val = "";
            foreach(Person p in this)
            {
                val += p.Name + ",";
            }
            return val.Substring(0,val.Length-1);
        }
    }
    #endregion

    #region 1号比较器-排序-定义比较规则，Compare方法中定义
    //使用泛型接口
    class NameComparer : IComparer<Person>
    {
        //存放排序器实例
        public static NameComparer Default = new NameComparer();
        //按姓名比较
        public int Compare(Person x, Person y)
        {
            return System.Collections.Comparer.Default.Compare(x.Name, y.Name);
        }
    }
    #endregion

    #region 2号比较器 - 排序 - 通过委托 -- 更趋向此种方法
    class PersonComparison
    {
        public static int Name(Person P1,Person p2)
        {
            return System.Collections.Comparer.Default.Compare(P1.Name, p2.Name);
        }
    }
    #endregion

    #region 3号搜索器 泛型集合的搜索
    class PersonPredicate
    {
        public static bool MidAge(Person p)
        {
            //通过内置的泛型委托System.Predicate<T>对集合进行搜索：
            if (p.Age >= 40)
                return true;
            else
                return false;
        }
    }
    #endregion
}
