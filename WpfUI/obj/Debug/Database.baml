   M S B A M L   `   `   `  ����@  <WpfUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:WpfUIWpfUI  5   	       WpfUI.Database   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:WpfUI     5   	   $��14(�5      $��Segoe UI Light)�6(     � Title$
  Baza��5   	    � WindowState$ 	Maximized=�6    � Icon$ logo.png��6.   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $��20 �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $��20 �6    � RowDefinitions 5   
   �� 5      $��20 �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $��20 �6   .+�5!   
   &   System.Windows.Controls.DataGrid  -   5        $��dg_Baza��5!         AutoGenerateColumns .  $��1��6>   $��1��6N   $��5��6[   $
��Left=�6o   $��0,0,0,42.333q�5"         Columns 5#      0  *System.Windows.Controls.DataGridTextColumn  5$      ,  &System.Windows.Controls.DataGridColumn   Header$ Nazwisko��6B   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *
Nazwisko+6B     5%      $ Imię��6>    6%   �� *Imię+6>     5&      $ Adres e-mail��6@    6%   �� *e-mail+6@     5'      $ Nr telefonu��6J    6%   �� *[Numer telefonu]+6J     5(      $ Opłata wpisowa��6J    6%   �� *[Opłata Wpisowa]+6J     5)      $ 	Wrzesień��6B    6%   �� *	Wrzesień+6B     5*      $ Październik��6E    6%   �� *Październik+6E     5+      $ Listopad��6B    6%   �� *
Listopad+6B     5,      $ 	Grudzień��6B    6%   �� *	Grudzień+6B     5-      $ Styczeń��6B    6%   �� *
Styczeń+6B     5.      $
 Luty��6?    6%   �� *Luty+6?     5/      $ Marzec��6@    6%   �� *Marzec+6@     50      $ 	Kwiecień��6B    6%   �� *	Kwiecień+6B     51      $	 Maj��6>    6%   �� *Maj+6>     52      $ Czerwiec��6B    6%   �� *
Czerwiec+6B   55      �� 57   
   -   5        	 ��Name$	 addPersonIntoBase��57      $��Dodaj płatnika��6,   $��1��6E   $��2��58      $��1��6   $��10, 10, 10, 10q�62   6J   �� 59   
   -   5        $	 deletePersonFromBase��59      $��Usuń płatnika��6/   $��2��6G   $��2��5:      $��1��6   $��10, 10, 10, 10q�62   5;      5<      