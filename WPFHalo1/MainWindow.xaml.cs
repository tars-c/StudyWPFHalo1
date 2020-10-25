using System;
using System.Collections.Generic;
using System.Linq;
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

namespace WPFHalo1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    // MainWindow를 Winform 작업하듯이 사용하는 것은 매우 비추! -> 연동이 되지 않아 프로그램 복잡성 증가
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //ViewModel 컨텍스트에 연결 (사용여부: 선택)
            //데이터 바인딩 시 this.DataContext에서 프로퍼티를 찾아낸다.
            this.DataContext = new ViewModel.StudentViewModel();

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
