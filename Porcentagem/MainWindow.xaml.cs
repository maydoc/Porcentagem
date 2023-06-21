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

namespace Porcentagem {
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        private void BT_Calcular_Click(object sender, RoutedEventArgs e) {
            try {
                double.Parse(TB_ValorIncial.Text);
                double.Parse(TB_ValorFinal.Text);
            }
            catch (Exception) {
                return;
            }

            int upOrdown = -1;

            if (TB_ValorIncial.Text == string.Empty || TB_ValorFinal.Text == string.Empty) {
                return;
            }
            if (double.Parse(TB_ValorIncial.Text) < double.Parse(TB_ValorFinal.Text)) {
                upOrdown = 1;
                ArrowUp.Visibility = Visibility.Visible;
                ArrowDown.Visibility = Visibility.Collapsed;
                ValorRS.Foreground = Brushes.Green;
                ValorPorcentagem.Foreground = Brushes.Green;
                ValorRS.Text = (double.Parse(TB_ValorFinal.Text) - double.Parse(TB_ValorIncial.Text)).ToString("C2");
                ValorPorcentagem.Text = (((double.Parse(TB_ValorFinal.Text) - double.Parse(TB_ValorIncial.Text)) / double.Parse(TB_ValorIncial.Text) * 100)).ToString("N2") + " %";
            }
            else if (double.Parse(TB_ValorIncial.Text) > double.Parse(TB_ValorFinal.Text)) {
                upOrdown = 0;
                ArrowDown.Visibility = Visibility.Visible;
                ArrowUp.Visibility = Visibility.Collapsed;
                ValorRS.Foreground = Brushes.Red;
                ValorPorcentagem.Foreground = Brushes.Red;
                ValorRS.Text = (double.Parse(TB_ValorFinal.Text) - double.Parse(TB_ValorIncial.Text)).ToString("C2");
                ValorPorcentagem.Text = (((double.Parse(TB_ValorFinal.Text) - double.Parse(TB_ValorIncial.Text)) / double.Parse(TB_ValorIncial.Text) * 100)).ToString("N2") + " %";
            }
            else {
                ArrowDown.Visibility = Visibility.Collapsed;
                ArrowUp.Visibility = Visibility.Collapsed;
                ValorRS.Foreground = Brushes.Black;
                ValorRS.Text = "R$ 0,00";
                ValorPorcentagem.Foreground = Brushes.Black;
                ValorPorcentagem.Text = "0,00 %";
            }
            CardHistory cardHistory = new CardHistory();
            cardHistory.V_Inicial.Text = TB_ValorIncial.Text;
            cardHistory.V_Final.Text = TB_ValorFinal.Text;
            cardHistory.V_Diferenca.Text = ValorRS.Text;
            cardHistory.V_Porcentagem.Text = ValorPorcentagem.Text;
            cardHistory.Margin = new Thickness(5);
            switch (upOrdown) {
                case 1:
                    cardHistory.ArrowUp.Visibility = Visibility.Visible;
                    cardHistory.V_Diferenca.Foreground = Brushes.Green;
                    cardHistory.V_Porcentagem.Foreground = Brushes.Green;
                    break;
                case 0:
                    cardHistory.ArrowDown.Visibility = Visibility.Visible;
                    cardHistory.V_Diferenca.Foreground = Brushes.Red;
                    cardHistory.V_Porcentagem.Foreground = Brushes.Red;
                    break;
                default:
                    break;
            }
            ListHistoryCards.Children.Add(cardHistory);
        }

        private void TB_ValorIncial_GotFocus(object sender, RoutedEventArgs e) {
            if (TB_ValorIncial.Text == "") {
                TB_ValorIncial.Text = "0,00";
                TB_ValorIncial.SelectionStart = TB_ValorIncial.Text.Length;
            }
        }

        private void TB_ValorIncial_LostFocus(object sender, RoutedEventArgs e) {
            if (TB_ValorIncial.Text == "0,00") {
                TB_ValorIncial.Text = "";
            }
        }
        int index1 = 0;
        private void TB_ValorIncial_PreviewTextInput(object sender, TextCompositionEventArgs e) {
            //if (e.Text == "0" && TB_ValorIncial.Text == "0,00") {
            //    e.Handled = true;
            //    return;
            //}
            //if (e.Text != "0" && TB_ValorIncial.Text == "0,00") {
            //    TB_ValorIncial.Text = TB_ValorIncial.Text.Substring(0, 3) + e.Text;
            //    e.Handled = true;
            //    TB_ValorIncial.SelectionStart = TB_ValorIncial.Text.Length;
            //    index1++;
            //    return;
            //}
            //if (index1 < 3) {
            //    TB_ValorIncial.Text = TB_ValorIncial.Text[2] + "," + TB_ValorIncial.Text[3] + e.Text;
            //    e.Handled = true;
            //    TB_ValorIncial.SelectionStart = TB_ValorIncial.Text.Length;
            //    index1++;
            //    return;
            //}
            //if (TB_ValorIncial.Text.Length == 6) {
            //    var virgula = TB_ValorIncial.Text.IndexOf(',');
            //    var text_limp = TB_ValorIncial.Text.Replace(",", "");
            //    var text_cc = text_limp.Insert(virgula + 1, ",");
            //    text_cc = text_cc.Insert(1, ".");
            //    TB_ValorIncial.Text = text_cc + e.Text;
            //    e.Handled = true;
            //    TB_ValorIncial.SelectionStart = TB_ValorIncial.Text.Length;
            //}
            //else if (TB_ValorIncial.Text.Length > 6 && TB_ValorIncial.Text.Length < 10) {
            //    var virgula = TB_ValorIncial.Text.IndexOf(',');
            //    var ponto = TB_ValorIncial.Text.IndexOf('.');
            //    var text_limp = TB_ValorIncial.Text.Replace(",", "");
            //    text_limp = text_limp.Replace(".", "");
            //    var text_cc = text_limp.Insert(virgula, ",");
            //    text_cc = text_cc.Insert(ponto + 1, ".");
            //    TB_ValorIncial.Text = text_cc + e.Text;
            //    e.Handled = true;
            //    TB_ValorIncial.SelectionStart = TB_ValorIncial.Text.Length;
            //}
            //else if (TB_ValorIncial.Text.Length == 10) {
            //    var virgula = TB_ValorIncial.Text.IndexOf(',');
            //    var ponto = TB_ValorIncial.Text.IndexOf('.');
            //    var text_limp = TB_ValorIncial.Text.Replace(",", "");
            //    text_limp = text_limp.Replace(".", "");
            //    var text_cc = text_limp.Insert(virgula, ",");
            //    text_cc = text_cc.Insert(ponto + 1, ".");
            //    text_cc = text_cc.Insert(1, ".");
            //    TB_ValorIncial.Text = text_cc + e.Text;
            //    e.Handled = true;
            //    TB_ValorIncial.SelectionStart = TB_ValorIncial.Text.Length;
            //}
            //else if (TB_ValorIncial.Text.Length < 6) {
            //    var virgula = TB_ValorIncial.Text.IndexOf(',');
            //    var text_limp = TB_ValorIncial.Text.Replace(",", "");
            //    var text_cc = text_limp.Insert(virgula + 1, ",");
            //    TB_ValorIncial.Text = text_cc + e.Text;
            //    e.Handled = true;
            //    TB_ValorIncial.SelectionStart = TB_ValorIncial.Text.Length;
            //}
            //else {
            //    e.Handled = true;
            //    TB_ValorIncial.SelectionStart = TB_ValorIncial.Text.Length;
            //}
        }
        private void TB_ValorIncial_PreviewKeyDown(object sender, KeyEventArgs e) {
            //if (e.Key == Key.Back) {
            //    if (TB_ValorIncial.Text.Length == 4) {
            //        index1 = 0;
            //        TB_ValorIncial.Text = TB_ValorIncial.Text.Insert(0, "0");
            //    }
            //    var virgula = TB_ValorIncial.Text.IndexOf(',');
            //    var ponto1 = TB_ValorIncial.Text.IndexOf('.');
            //    int count_p = TB_ValorIncial.Text.Count(f => f == '.');
            //    if (count_p > 1) {
            //        ponto1 = TB_ValorIncial.Text.IndexOf('.', 2);
            //    }
            //    string sub = TB_ValorIncial.Text.Replace(",", "");
            //    if (ponto1 != -1) {
            //        sub = sub.Replace(".", "");
            //    }
            //    string sub_re = sub.Substring(0, sub.Length - 1);
            //    sub_re = sub_re.Insert(sub_re.Length - 2, ",");
            //    if (ponto1 != -1 && count_p > 1 && sub_re.Length > 6) {
            //        sub_re = sub_re.Insert(ponto1 - 2, ".");
            //    }
            //    else if (ponto1 != -1 && sub_re.Length > 6) {
            //        sub_re = sub_re.Insert(ponto1 - 1, ".");
            //    }

            //    TB_ValorIncial.Text = sub_re;
            //    TB_ValorIncial.SelectionStart = TB_ValorIncial.Text.Length;
            //    index1 -= 1;
            //    e.Handled = true;
            //}
        }

        private void TB_ValorFinal_GotFocus(object sender, RoutedEventArgs e) {
            if (TB_ValorFinal.Text == "") {
                TB_ValorFinal.Text = "0,00";
            }
        }

        private void TB_ValorFinal_LostFocus(object sender, RoutedEventArgs e) {
            if (TB_ValorFinal.Text == "0,00") {
                TB_ValorFinal.Text = "";
            }
        }

    }
}
