   M S B A M L   `   `   `  ���� I  EBarcoin.Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:Barcoin.Client.ViewBarcoin.Client.View  C&clr-namespace:Barcoin.Client.ViewModelBarcoin.Client.ViewModel  "    Barcoin.Client.View.MainView   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     3local!clr-namespace:Barcoin.Client.View     <	viewmodel&clr-namespace:Barcoin.Client.ViewModel       � DataContext  ��    Locator �� Source# [   �� Path$
 Main� � 	Resources  �� DataType1   +Barcoin.Client.ViewModel.DashboardViewModel'   !Barcoin.Client.View.DashboardView.   (Barcoin.Client.ViewModel.DetailViewModel$   Barcoin.Client.View.DetailView3   -Barcoin.Client.ViewModel.AddCreditorViewModel!   Barcoin.Client.View.AddView-   'Barcoin.Client.ViewModel.AboutViewModel#   Barcoin.Client.View.AboutView �� 
TargetType �� Property �� Value �� 
TargetType  LogoLink  AddLink  	AboutLink��%,  (��       *, +)(��      *, +)(�� $     *, +)(�� 6     *, +)'�� H     &	      &	 �     &	 �     �� "  .R�  �� "  .R�  �� "  .R�  �� "  .R�  �� " ��.���  � �� �� " ��.R��� #��z���� ���� *Logo+�� ���� *Add+�� ���� *About+.��� 
�������	 � RowDefinitions	 �� $
��0.2* ��� $��* �.+�� $��0��$��0��
 � ColumnDefinitions
 �� $
��0.2* ��� $��1* ��� $
��0.2* ��� $
��0.2* �.+��� #��[  � ToolTip$ 	Dashboard��
������ $��0q�$��0��$��64��$��64������ $ DashboardCommand��� $��1�� �� TextAlignment$
 Left=�$��Center=�
���   �$��40(�$��
Montserrat)�$��	0,43,0,28q�	Barcoin�� $��2��#��[ $ About Barcoin��
������ $��0q�$��64��$��64������ $ AboutCommand��� $��3��#��[ $ Add a new credit line��
������ $��0q�$��64��$��64������ $ 
AddCommand��� $��1��$��20q����� $ CurrentViewModel�