   M S B A M L   `   `   `  ����   Barcoin.Client!    Barcoin.Client.View.AddView   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008       � DataContext  ��    Locator �� Source# [   �� Path$	 Add�.��� $��20q� � RowDefinitions �� $
��0.1* ��� $��* �.+���  �� TextAlignment$
 Left=�$��Center=�
���   �$��25(�$��
Montserrat)�New credit line� $��1�� �� $��* ��� $��* ��� $��* ��� $��* ��� $��* ��� $��* ��� $��* �.+��� $��1��  PlaceHolder#��[ 
 � Tag$ Creditor Name e.g Nadir��$��20��$	��250��$
��Left=����� $
 Name� �� Mode$ TwoWay=�.���� $��2��#��[ $# Creditor Surname e.g Barlozzo��$��20��$	��250��$
��Left=����� $ Surname�$ TwoWay=��� $��3��#��[ $ Description e.g Azienda��$��20��$	��250��$
��Left=����� $ Description�$ TwoWay=��� $��4��#��[ $ Diem Rate e.g 365��$��20��$	��250��$
��Left=����� $ DiemRate�$ TwoWay=��� $��5��#��[ $! Default Interest Rate e.g 6��$��20��$	��250��$
��Left=����� $ DefaultInterestRate�$ TwoWay=��� $��6��$��20��$	��100��$
��Left=����� $ AddCreditorCommand�.��Create