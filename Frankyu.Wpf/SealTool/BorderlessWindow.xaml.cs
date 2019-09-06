using Mesince.Seal;
using Microsoft.Win32;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interop;

namespace WpfApplication1
{
    /// <summary>
    /// BorderlessWindow.xaml 的交互逻辑
    /// </summary>
    public partial class BorderlessWindow : Window
    {

        private bool mRestoreForDragMove;

        public BorderlessWindow()
        {
            InitializeComponent();
            //添加鼠标左键弹起重置状态缓存变量事件
            MenuPanel.MouseLeftButtonUp += (s, e) => { mRestoreForDragMove = false; };
            MenuPanel.MouseLeftButtonDown += OnMouseLeftButtonDown;
            MenuPanel.MouseMove += OnMouseMove;

            this.Title = "签章生成器";
            CmbType.SelectedIndex = 0;
            this.Icon = Imaging.CreateBitmapSourceFromHIcon(Properties.Resources.stamp.Handle,
                Int32Rect.Empty, System.Windows.Media.Imaging.BitmapSizeOptions.FromEmptyOptions());
        }

        #region 窗体移动

        private void Window_StateChanged(object sender, EventArgs e)
        {
            switch (this.WindowState)
            {
                case WindowState.Maximized:
                    this.MaxWidth = SystemParameters.WorkArea.Width + 16;
                    this.MaxHeight = SystemParameters.WorkArea.Height + 16;
                    this.BorderThickness = new Thickness(5); //最大化后需要调整
                    WindowShadowBorder.Margin = new Thickness(0);
                    break;
                case WindowState.Normal:
                    this.BorderThickness = new Thickness(0);
                    WindowShadowBorder.Margin = new Thickness(10);
                    break;
            }
        }

        private void OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            if (e.ClickCount == 2)
            {
                if (ResizeMode != ResizeMode.CanResize && ResizeMode != ResizeMode.CanResizeWithGrip) return;
                WindowState = WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;
            }
            else
            {
                mRestoreForDragMove = WindowState == WindowState.Maximized;
                DragMove();
            }
        }

        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            if (mRestoreForDragMove)
            {
                mRestoreForDragMove = false;
                WindowState = WindowState.Normal;
                var point = e.MouseDevice.GetPosition(this);
                Left = point.X - MainGrid.ActualWidth * point.X / SystemParameters.WorkArea.Width - WindowShadowBorder.Margin.Left;
                Top = point.Y - MainGrid.ActualHeight * point.Y / SystemParameters.WorkArea.Height - WindowShadowBorder.Margin.Top;
                DragMove();
            }
        }

        #endregion

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnGenerate_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtSealText.Text))
                return;

            int fontSize;
            if (!int.TryParse(txtFontSize.Text, out fontSize))
            {
                fontSize = 80;
            }
            else if (fontSize < 10)
            {
                fontSize = 10;
            }

            SealGrid.Children.Clear();
            var can = CreateCanvas(CmbType.SelectedIndex, fontSize);            
            can.MouseDown += (s, arg) =>
            {
                int index = CmbType.SelectedIndex;
                PreviewWindow window = new PreviewWindow(CreateCanvas(index, fontSize));
                window.ShowDialog();               
            };
            SealGrid.Children.Add(can);
        }

        private Canvas CreateCanvas(int index, int fontSize)
        {
            switch (index)
            {
                //中文章
                case 0:
                    SealCNGenerator cnSeal = new SealCNGenerator();
                    return cnSeal.DrawOnCanvas(txtSealText.Text.Trim(), txtSealType.Text.Trim());

                //英文章
                case 1:
                    SealENGenerator enSeal = new SealENGenerator();
                    return enSeal.DrawOnCanvas(txtSealText.Text.Trim(), txtSealType.Text.Trim());

                //中文签名
                case 2:
                    SignatureCNGenerator cnPersonSeal = new SignatureCNGenerator();
                    return cnPersonSeal.DrawOnCanvas(txtSealText.Text.Trim());

                //英文签名
                case 3:
                    SignatureGenerator signature1 = new SignatureGenerator();
                    return signature1.DrawOnCanvasAutoSize(txtSealText.Text.Trim(), fontSize, SignatureGenerator.FONT_FAMILY_EN);
            }

            return null;
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            SealGrid.Children.Clear();
        }

        private void btnExport_Click(object sender, RoutedEventArgs e)
        {
            if (SealGrid.Children.Count > 0)
            {
                var saveFileDialog = new SaveFileDialog
                {
                    Filter = "Png Image|*.png",
                    Title = "Save File"
                };
                saveFileDialog.ShowDialog();

                if (string.IsNullOrEmpty(saveFileDialog.FileName))
                    return;

                ((Canvas)SealGrid.Children[0]).SaveImage(saveFileDialog.FileName);
            }
        }
    }
}
