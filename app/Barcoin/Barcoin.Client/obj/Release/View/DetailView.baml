   M S B A M L   `   `   `  ���� U  QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf   Barcoin.Client$   Barcoin.Client.View.DetailView   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     Dlvc4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf       � DataContext  ��    Locator �� Source# [   �� Path$ Detail� J� InputBindings �� 
 �� Key$ p�� �� Command �� *PrintCommand+�� $ e�� �� *ExportCommand+.��� $��20q� � ColumnDefinitions �� $��* ��� $��* � � RowDefinitions �� $
��0.2* ��� $
��0.2* ��� $
��0.3* ��� $��* �.+��� $��20(�$��
Montserrat)����� $ SelectedCreditor.DiemRate� �� StringFormat$ Diem Rate: {0}d/y���� $��1��$��20(�$��
Montserrat)����� $* $SelectedCreditor.DefaultInterestRate�$! Default Interest Rate: {0}%��� $��2�� �� $��* ��� $��* � �� $��* ��� $��* �.+�(  "System.Windows.Controls.DatePicker  $��Center=�$
��Left=�$	��150��$��25��	   SelectedDate	 �� $ NewDate��� $��1��  PlaceHolder#��[ 

 � Tag$
 Principal e.g 80��$��20��$	��150��$
��Left=����� $ NewPrincipal� �� Mode$ TwoWay=��� $��0��$��1��#��[ $
 Interest Rate e.g 6��$��20��$	��150��$
��Left=����� $ NewInterestRate�$ TwoWay=��� $��1��$��1��$��20��$	��120��$
��Left=����� $ AddTransactionCommand�.��Add Transaction&   System.Windows.Controls.DataGrid  -     Name$ dg��$��3��$��2��   AutoGenerateColumns .  
������ $��20(�$��
Montserrat)�   
IsReadOnly . $
��Left=�$��Center=����� $ BalanceData�$ TwoWay=�   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$
 Date��   Width5  /System.Windows.Controls.DataGridLengthConverter$ * 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� $ Transaction.RawDate�$ 
yyyy/MM/dd��  $ 	Principal��$ *  �� $ Transaction.Principal�$ {0} CHF��  $ Interest Rate��$ *  �� $ Transaction.InterestRate�$
 {0}%��  $ Principal Balance��$ *  �� $ PrincipalBalance�$ {0} CHF��  $ Accrued Interest��$ *  �� $ AccruedInterest�$ {0} CHF��  $ Interest Balance��$ *  �� $ InterestBalance�$ {0} CHF��  $ Principal Paid��$ *  �� $ PrincipalPaid�$ {0} CHF��  $ Interest Paid��$ *  �� $ InterestPaid�$ {0} CHF��  $ 
Total Owed��$ *  �� $ 	TotalOwed�$ {0} CHF��#   LiveCharts.Wpf.CartesianChart  $��1��$��3��&    LiveCharts.Wpf.Charts.Base.Chart   LegendLocation$ Right=�   Series �� $ 	GraphData�   AxisY 	   LiveCharts.Wpf.Axis	   	  Title$ Balance��   AxisX 	  $
 Date�� 	  Labels �� *Dates+