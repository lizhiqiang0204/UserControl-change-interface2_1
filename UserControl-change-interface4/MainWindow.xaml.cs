using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void UIElement_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            var sample = (SampleVm)((Border)sender).DataContext;//Border属于ItemsControl的其中一员，所以(Border)sender).DataContext 是MainWindowVeiwModel类成员Items数组中的其中一类（即SampleVm）
            var hvm = (MainWindowVeiwModel)DataContext;//MainWindow的数据上下文指定MainWindowVeiwModel类
            hvm.Content = (UserControl)Activator.CreateInstance(sample.Content);//主页面MainWindow.xaml中的内容呈现器ContentPresenter指向选中Items数组中的UserControl句柄。
            hvm.Items[hvm.SelectId].BackColor = new SolidColorBrush(Colors.Transparent);//把上一次选中的背景色改成透明色
            hvm.Items[sample.Id].BackColor = new SolidColorBrush(Colors.Gray);//把这次选中的背景色改成灰色
            hvm.SelectId = sample.Id;//已选择的ID改成本次选中的ID

        }
    }
}
