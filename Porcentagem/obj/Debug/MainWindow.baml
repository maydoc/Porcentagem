   M S B A M L   `   `   `  ����F  BPorcentagem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:PorcentagemPorcentagem  5   	       Porcentagem.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:Porcentagem     5   	   _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	   	     � Title$  Porcentagem��5   	   $	��336��6   $	��400��6*      MaterialDesignBody#���   5
   	   $��Regular"�5   	   $��13(�5   	   &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	    � 
ResizeMode$ CanMinimize=�6;   .��5      � .+�5   
   �� .  (MaterialDesignThemes.Wpf.ColorZoneAssist   Mode$ PrimaryDark=�6    " MaterialDesignFilledTabControl#��[ 6G    �� SelectedIndex$ 1��6   .@�5      �� ��5      � 5      .+�5      ��  �� Orientation$ 
Horizontal=�6%   .+�5      � .+�5   "   '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ ArrowUpThick=�6:   
�������$��15��6a   $��15��6l   $��	-3 -5 0 0q�6x     5   "   $ ArrowDownThick=�6:   
�������$��15��6c   $��15��6n   $��3 3 0 0q�6z   5      �� 5      $��
Diferença��6(   $��SemiBold"�69   
�������$��Center=�6b   $��14(�6}   $��5 0 0 0q�6�   5      5      .��5!      �� $��
10 20 10 0q�6   .+�5"      �� $ 
Horizontal=�6!   $��Center=�6:   .+�5#      �� -   5        $��TB_ValorIncial��5#   �    ! MaterialDesignOutlinedTextBox#��[ 6"   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Valor Inicial��6Y   $	��135��6�   $
��10 0q�6�   .  (MaterialDesignThemes.Wpf.TextFieldAssist	   
PrefixText$	 R$��6�   5$   �   �� 5%      -   5        $��TB_ValorFinal��5%   �   #��[ 6"   $ Valor Final��6Y   $	��135��6�   $
��10 0q�6�   $	 R$��6�   5&   D   5'      �� 5(      -   5        $��BT_Calcular��5(   �   $��Calcular��6     PrimaryHueDarkBrush#���  60   
�������$��20 20 20 20q�6v   6�   �� 5)      $��	Resultado��6    $��Center=�61   $��18(�6N   $��SemiBold"�6\   #  MaterialDesignThemes.Wpf.Card  5*      $��10q�6*   
   UniformCornerRadius$
 15Q�66   .��5+      � $��10q�6   .+�5,      �� .+�5-   "   �� $ 
Horizontal=�6-   $��Center=�6F   .+�5.   &   � .+�5/   *     -   5        $��ArrowUp��5/   �   $ ArrowUpThick=�6B   $��25��6V   $��25��6a   
��� � �$y�	Collapsed=�6�   6�     50   *   -   5        $��	ArrowDown��50   �   $ ArrowDownThick=�6B   $��25��6X   $��25��6c   
���  ��$y�	Collapsed=�6�   6�   51   '   �� 52   &   -   5        $��ValorRS��52   �   $	��5 0q�60   $��R$ 0,00��6=   $��20(�6L   $��SemiBold"�6Z   $��Center=�6p   
���   �6�   53   #   �� 54   "   -   5        $��ValorPorcentagem��54   z   $��0,00%��6,   $��Center=�69   $��16(�6V   $��SemiBold"�6d   6z   55      56      57      58      59      �� 5;      {�. ��5<      � 5=      .+�5>      �� $ 
Horizontal=�6%   .+�5?        $ History=�66   
�������$��20��6X   $��20��6c   �� 5@      $��
Histórico��6(   $��SemiBold"�69   
�������$��Center=�6b   $��14(�6}   $��5 0 0 0q�6�   5A      5B      .��5D      � .+�5F      �� $��Stretch=�6#   $
��Auto=�6A   .��5G      � .+�5H      �� -   5        $��ListHistoryCards��5H   5   $��20q�6)   65   �� 5I      $ ��Não há nenhum histórico��6(   $��Center=�6G   $��Center=�6b   $��18(�6   $��SemiBold"�6�   5J      5K      �� 5L      -	   5        $��ButtonDeleteHistory��5M   W   +  %MaterialDesignThemes.Wpf.ShadowAssist   ShadowDepth$ Depth2=�5L   U   $��Right=�6�   $��Bottom=�5M      $��15q�68   
�������$y�Visible=�6r   ��5L      0  *MaterialDesignThemes.Wpf.PackIconExtension     Kind$ Delete=�   Size$ 20X���5N      �� 5O       �� 
TargetType" ��6$    * &MaterialDesignFloatingActionMiniButton �� BasedOn# [ 6A    �� Triggers 5P   "   P� 5Q   &    P� Property � y� P� Value$ Visible=�6D   5b   '   5d      5f      5g      5h      5i      5j      5k      