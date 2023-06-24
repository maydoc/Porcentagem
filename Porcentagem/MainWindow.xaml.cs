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
                double.Parse(TB_ValorInicial.Text);
                double.Parse(TB_ValorFinal.Text);
            }
            catch (Exception) {
                return;
            }

            int upOrdown = -1;

            if (TB_ValorInicial.Text == string.Empty || TB_ValorFinal.Text == string.Empty) {
                return;
            }
            if (double.Parse(TB_ValorInicial.Text) < double.Parse(TB_ValorFinal.Text)) {
                upOrdown = 1;
                ArrowUp.Visibility = Visibility.Visible;
                ArrowDown.Visibility = Visibility.Collapsed;
                ValorRS.Foreground = Brushes.Green;
                ValorPorcentagem.Foreground = Brushes.Green;
                ValorRS.Text = (double.Parse(TB_ValorFinal.Text) - double.Parse(TB_ValorInicial.Text)).ToString("C2");
                ValorPorcentagem.Text = (((double.Parse(TB_ValorFinal.Text) - double.Parse(TB_ValorInicial.Text)) / double.Parse(TB_ValorInicial.Text) * 100)).ToString("N2") + " %";
            }
            else if (double.Parse(TB_ValorInicial.Text) > double.Parse(TB_ValorFinal.Text)) {
                upOrdown = 0;
                ArrowDown.Visibility = Visibility.Visible;
                ArrowUp.Visibility = Visibility.Collapsed;
                ValorRS.Foreground = Brushes.Red;
                ValorPorcentagem.Foreground = Brushes.Red;
                ValorRS.Text = (double.Parse(TB_ValorFinal.Text) - double.Parse(TB_ValorInicial.Text)).ToString("C2");
                ValorPorcentagem.Text = (((double.Parse(TB_ValorFinal.Text) - double.Parse(TB_ValorInicial.Text)) / double.Parse(TB_ValorInicial.Text) * 100)).ToString("N2") + " %";
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
            cardHistory.V_Inicial.Text = TB_ValorInicial.Text;
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
            if(ListHistoryCards.Children.Count == 0) {
                Text_EmptyHistoryc.Visibility = Visibility.Hidden;
            }
            ListHistoryCards.Children.Add(cardHistory);
        }

        private void TB_ValorInicial_GotFocus(object sender, RoutedEventArgs e) {
            if (TB_ValorInicial.Text == "") {
                TB_ValorInicial.Text = "0,00";
                TB_ValorInicial.SelectionStart = TB_ValorInicial.Text.Length;
            }
        }

        private void TB_ValorInicial_LostFocus(object sender, RoutedEventArgs e) {
            if (TB_ValorInicial.Text == "0,00") {
                TB_ValorInicial.Text = "";
            }
        }
        int index1 = 0;
        private void TB_ValorInicial_PreviewTextInput(object sender, TextCompositionEventArgs e) {
            try {
                int.Parse(e.Text);
            }
            catch (Exception) {
                e.Handled = true;
                return;
            }
            if (e.Text == "0" && TB_ValorInicial.Text == "0,00") {
                e.Handled = true;
                return;
            }
            else {
                string raiz = TB_ValorInicial.Text;
                if (TB_ValorInicial.SelectionLength == TB_ValorInicial.Text.Length) {
                    TB_ValorInicial.Text = "0,00";
                    raiz = "0,00";
                }
                if (raiz.Length == 4) {
                    if (raiz == "0,00" && e.Text != "0") {
                        TB_ValorInicial.Text = raiz.Substring(0, 3) + e.Text;
                    }
                    else if (raiz[0] == '0' && raiz[2] == '0') {
                        TB_ValorInicial.Text = raiz.Substring(0, 2) + raiz[3] + e.Text; 
                    }
                    else if (raiz[0] == '0' && raiz[2] != '0') {
                        TB_ValorInicial.Text = raiz[2] + "," + raiz[3] + e.Text;
                    }
                    else {
                        var virgula = raiz.IndexOf(',');
                        var text_limp = raiz.Replace(",", "");
                        var text_cc = text_limp.Insert(virgula + 1, ",");
                        TB_ValorInicial.Text = text_cc + e.Text;
                    }
                }
                else if (raiz.Length > 4 && raiz.Length < 6) {
                    var virgula = raiz.IndexOf(',');
                    var text_limp = raiz.Replace(",", "");
                    var text_cc = text_limp.Insert(virgula + 1, ",");
                    TB_ValorInicial.Text = text_cc + e.Text;
                }
                else if (raiz.Length == 6) {
                    var virgula = raiz.IndexOf(',');
                    var text_limp = raiz.Replace(",", "");
                    var text_cc = text_limp.Insert(virgula + 1, ",");
                    text_cc = text_cc.Insert(1, ".");
                    TB_ValorInicial.Text = text_cc + e.Text;
                }
                else if (raiz.Length > 6 && raiz.Length < 10) {
                    var virgula = raiz.IndexOf(',');
                    var ponto = raiz.IndexOf('.');
                    var text_limp = raiz.Replace(",", "");
                    text_limp = text_limp.Replace(".", "");
                    var text_cc = text_limp.Insert(virgula, ",");
                    text_cc = text_cc.Insert(ponto + 1, ".");
                    TB_ValorInicial.Text = text_cc + e.Text;
                }
                else if (raiz.Length == 10) {
                    var virgula = raiz.IndexOf(',');
                    var ponto = raiz.IndexOf('.');
                    var text_limp = raiz.Replace(",", "");
                    text_limp = text_limp.Replace(".", "");
                    var text_cc = text_limp.Insert(virgula, ",");
                    text_cc = text_cc.Insert(ponto + 1, ".");
                    text_cc = text_cc.Insert(1, ".");
                    TB_ValorInicial.Text = text_cc + e.Text;
                }
            }
            e.Handled = true;
            TB_ValorInicial.SelectionStart = TB_ValorInicial.Text.Length;
        }
        private void TB_ValorInicial_PreviewKeyDown(object sender, KeyEventArgs e) {
            if (e.Key == Key.Back) {
                if (TB_ValorInicial.SelectionLength == TB_ValorInicial.Text.Length) {
                    TB_ValorInicial.Text = "0,00";
                    TB_ValorInicial.SelectionStart = TB_ValorInicial.Text.Length;
                    e.Handled = true;
                    return;
                }
                if (TB_ValorInicial.Text.Length == 4) {
                    index1 = 0;
                    TB_ValorInicial.Text = TB_ValorInicial.Text.Insert(0, "0");
                }
                var virgula = TB_ValorInicial.Text.IndexOf(',');
                var ponto1 = TB_ValorInicial.Text.IndexOf('.');
                int count_p = TB_ValorInicial.Text.Count(f => f == '.');
                if (count_p > 1) {
                    ponto1 = TB_ValorInicial.Text.IndexOf('.', 2);
                }
                string sub = TB_ValorInicial.Text.Replace(",", "");
                if (ponto1 != -1) {
                    sub = sub.Replace(".", "");
                }
                string sub_re = sub.Substring(0, sub.Length - 1);
                sub_re = sub_re.Insert(sub_re.Length - 2, ",");
                if (ponto1 != -1 && count_p > 1 && sub_re.Length > 6) {
                    sub_re = sub_re.Insert(ponto1 - 2, ".");
                }
                else if (ponto1 != -1 && sub_re.Length > 6) {
                    sub_re = sub_re.Insert(ponto1 - 1, ".");
                }

                TB_ValorInicial.Text = sub_re;
                TB_ValorInicial.SelectionStart = TB_ValorInicial.Text.Length;
                e.Handled = true;
            }
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

        private void ButtonDeleteHistory_Click(object sender, RoutedEventArgs e) {
            ListHistoryCards.Children.Clear();
            Text_EmptyHistoryc.Visibility = Visibility.Visible;
        }

        private void TB_ValorFinal_PreviewTextInput(object sender, TextCompositionEventArgs e) {
            try {
                int.Parse(e.Text);
            }
            catch (Exception) {
                e.Handled = true;
                return;
            }

            if (e.Text == "0" && TB_ValorFinal.Text == "0,00") {
                e.Handled = true;
                return;
            }
            else {
                string raiz = TB_ValorFinal.Text;
                if (TB_ValorFinal.SelectionLength == TB_ValorFinal.Text.Length) {
                    TB_ValorFinal.Text = "0,00";
                    raiz = "0,00";
                }
                if (raiz.Length == 4) {
                    if (raiz == "0,00" && e.Text != "0") {
                        TB_ValorFinal.Text = raiz.Substring(0, 3) + e.Text;
                    }
                    else if (raiz[0] == '0' && raiz[2] == '0') {
                        TB_ValorFinal.Text = raiz.Substring(0, 2) + raiz[3] + e.Text;
                    }
                    else if (raiz[0] == '0' && raiz[2] != '0') {
                        TB_ValorFinal.Text = raiz[2] + "," + raiz[3] + e.Text;
                    }
                    else {
                        var virgula = raiz.IndexOf(',');
                        var text_limp = raiz.Replace(",", "");
                        var text_cc = text_limp.Insert(virgula + 1, ",");
                        TB_ValorFinal.Text = text_cc + e.Text;
                    }
                }
                else if (raiz.Length > 4 && raiz.Length < 6) {
                    var virgula = raiz.IndexOf(',');
                    var text_limp = raiz.Replace(",", "");
                    var text_cc = text_limp.Insert(virgula + 1, ",");
                    TB_ValorFinal.Text = text_cc + e.Text;
                }
                else if (raiz.Length == 6) {
                    var virgula = raiz.IndexOf(',');
                    var text_limp = raiz.Replace(",", "");
                    var text_cc = text_limp.Insert(virgula + 1, ",");
                    text_cc = text_cc.Insert(1, ".");
                    TB_ValorFinal.Text = text_cc + e.Text;
                }
                else if (raiz.Length > 6 && raiz.Length < 10) {
                    var virgula = raiz.IndexOf(',');
                    var ponto = raiz.IndexOf('.');
                    var text_limp = raiz.Replace(",", "");
                    text_limp = text_limp.Replace(".", "");
                    var text_cc = text_limp.Insert(virgula, ",");
                    text_cc = text_cc.Insert(ponto + 1, ".");
                    TB_ValorFinal.Text = text_cc + e.Text;
                }
                else if (raiz.Length == 10) {
                    var virgula = raiz.IndexOf(',');
                    var ponto = raiz.IndexOf('.');
                    var text_limp = raiz.Replace(",", "");
                    text_limp = text_limp.Replace(".", "");
                    var text_cc = text_limp.Insert(virgula, ",");
                    text_cc = text_cc.Insert(ponto + 1, ".");
                    text_cc = text_cc.Insert(1, ".");
                    TB_ValorFinal.Text = text_cc + e.Text;
                }
            }
            e.Handled = true;
            TB_ValorFinal.SelectionStart = TB_ValorFinal.Text.Length;
        }

        private void TB_ValorFinal_PreviewKeyDown(object sender, KeyEventArgs e) {
            if (e.Key == Key.Back) {
                if (TB_ValorFinal.SelectionLength == TB_ValorFinal.Text.Length) {
                    TB_ValorFinal.Text = "0,00";
                    TB_ValorFinal.SelectionStart = TB_ValorFinal.Text.Length;
                    e.Handled = true;
                    return;
                }
                if (TB_ValorFinal.Text.Length == 4) {
                    index1 = 0;
                    TB_ValorFinal.Text = TB_ValorFinal.Text.Insert(0, "0");
                }
                var virgula = TB_ValorFinal.Text.IndexOf(',');
                var ponto1 = TB_ValorFinal.Text.IndexOf('.');
                int count_p = TB_ValorFinal.Text.Count(f => f == '.');
                if (count_p > 1) {
                    ponto1 = TB_ValorFinal.Text.IndexOf('.', 2);
                }
                string sub = TB_ValorFinal.Text.Replace(",", "");
                if (ponto1 != -1) {
                    sub = sub.Replace(".", "");
                }
                string sub_re = sub.Substring(0, sub.Length - 1);
                sub_re = sub_re.Insert(sub_re.Length - 2, ",");
                if (ponto1 != -1 && count_p > 1 && sub_re.Length > 6) {
                    sub_re = sub_re.Insert(ponto1 - 2, ".");
                }
                else if (ponto1 != -1 && sub_re.Length > 6) {
                    sub_re = sub_re.Insert(ponto1 - 1, ".");
                }

                TB_ValorFinal.Text = sub_re;
                TB_ValorFinal.SelectionStart = TB_ValorFinal.Text.Length;
                e.Handled = true;
            }
        }
    }
}
