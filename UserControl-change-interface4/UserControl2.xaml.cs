using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UserControl_change_interface4
{
    /// <summary>
    /// UserControl2.xaml 的交互逻辑
    /// </summary>
    public partial class UserControl2 : UserControl
    {
        public static event EventHandler<PropertyChangedEventArgs> StaticPropertyChanged;//静态事件处理属性更改

        public static int i = 0;
        private static string _myStr = "0";
        public static string myStr //Label 标签内容绑定到这个myStr字符串
        {
            get { return _myStr; }
            set
            {
                _myStr = value;
                StaticPropertyChanged?.Invoke(null, new PropertyChangedEventArgs(nameof(myStr)));//异步更新属性
            }
        }

        public UserControl2()
        {
            InitializeComponent();
            DataContext = this;//设置绑定数据的上下文为UserControl2类
        }
        //累加按键处理事件
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            i++;//按一下数值累加一次
            myStr = i.ToString();//把累加完后的数值转换成字符串赋给标签内容值（立刻更新标签内容）
        }

        private void btn_Clear_Click(object sender, RoutedEventArgs e)
        {
            UserControl2.i = 0;//把累加计数值清空设为0
            UserControl2.myStr = "0";//立刻更新标签内容

            UserControl1.i = 0;//同时把用户界面1里的累加值清空
            UserControl1.myStr = "0";//立刻更新用户界面1的标签内容
        }
    }
}
