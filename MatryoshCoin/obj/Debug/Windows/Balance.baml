   M S B A M L   `   `   `  ����G  CMatryoshCoin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:MatryoshCoin.WindowsMatryoshCoin.Windows  5   	   "    MatryoshCoin.Windows.Balance   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   _ [MaterialDesignThemes.Wpf, Version=4.2.1.2, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   .local"clr-namespace:MatryoshCoin.Windows  5   	     � Title$  Balance��5	   	   $	��450��6   $	��800��6&   .��5
      � .+�5   
   �� $	��400��6   $��10q�6    
�������$��Center=�6?    �� Padding$	 100q�6Z   $	��500��6h    J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         
BlurRadius$ 30Q�6#      Color$ 	LightGray��63      ShadowDepth$ 0Q�6F   ._�5      �� $��Center=�6   .+�5      �� $!��MatryoshCoin Кошелек��6   $��	Underline{�68   
����+��$��30(�6m   $��Center=�6{   $
��Bold"�6�   $��109,0,108.6,0q�6�   �� 5      -   5         ��Name$ Account��5      $��Ваш ID: ��6-   
����+��$��25(�6U   $
��Left=�6c   $
��Bold"�6~   $��5q�6�   �� 5      -   5        $ BalanceInfo��5      $��Ваш баланс: ��61   
����+��$��25(�6]   $
��Left=�6k   $
��Bold"�6�   $��5q�6�   �� 5      -   5         ��Name$ Refresh��5   ,   $��Обновить��6   $��5q�6=   
����+��6a   �� 5      -   5        $ GoBack��5   I   $L��FВернуться на страницу выбора действий��6   $��5q�6Y   
����+��6}   5      5      5      5      