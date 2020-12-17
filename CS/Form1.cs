using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.ComponentModel;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using System.Drawing;

namespace SingleScrollingGridControl
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            myGridView1.OptionsDetail.DetailMode = DevExpress.XtraGrid.Views.Grid.DetailMode.Embedded;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            int master = 20; int child1 = 16;
            BindingList<MyObject> list = new BindingList<MyObject>();
            for (int i = 0; i < master; i++)
            {
                BindingList<Child> childList = new BindingList<Child>();
                for (int j = 0; j < child1; j++)
                {
                    int index = i * child1 + j;
                    Child ch = new Child(index, "Name " + index.ToString());
                    childList.Add(ch);
                }
                MyObject obj = new MyObject(i, "Name " + i.ToString(), childList);
                list.Add(obj);
            }
            myGridControl1.DataSource = list;
        }

    }
    class MyObject
    {
        private BindingList<Child> children;
        private string name;
        private int id;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public MyObject(int i, string n, BindingList<Child> list)
        {
            id = i; name = n;
            Children = list;
        }

        public BindingList<Child> Children
        {
            get { return children; }
            set { children = value; }
        }
    }

    class Child
    {
        private string name;
        private int id;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public Child(int i, string n)
        {
            id = i; name = n;
        }
    }
}
