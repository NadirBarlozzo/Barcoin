   M S B A M L   `   `   `  ����H  DMahApps.Metro, Version=1.6.5.1, Culture=neutral, PublicKeyToken=nullV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5      fCclr-namespace:MahApps.Metro.Controls.Dialogs;assembly=MahApps.MetroMahApps.Metro.Controls.Dialogs  5       Barcoin.Client&    Barcoin.Client.View.RegisterView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5      VDialogCclr-namespace:MahApps.Metro.Controls.Dialogs;assembly=MahApps.Metro     5       
  global#��[  5
        � DataContext  5	      ��   Locator �� Source# [  �� Path$ Register�8   2MahApps.Metro.Controls.Dialogs.DialogParticipation   Register 5      ��  J� InputBindings 5      �� 5   
   
 �� Key$ Return��6l    �� Command 6   �� $ RegisterCommand� �� CommandParameter 6>   ��  �� ElementName$
 pass��6l   .��5      � $��Center=�6   $��
0 30 0 180q�6(   $	��500��6<   	 � RowDefinitions	 5   
   �� 5      $	��.7* �6   �� 5      $	��.4* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $��40(�6!   
 �� TextAlignment$
 Center=�6/   $��Register��6F   $	��300��6V   �� 5   
   $��1��6   
����� �6!   �� 5   
   $��2��6?   $��35��6L   $	��280��6X   $
��Bold"�6d   *   $MahApps.Metro.Controls.TextBoxHelper   	Watermark$ Insert firstname��6v   ��6   �� $ 	Firstname� �� Mode$ TwoWay=�6v   �� 5   
   $��3��6>   $��35��6K   $	��280��6W   $
��Bold"�6c   $ Insert lastname��6u   ��6   �� $ Lastname�$ TwoWay=�6u   �� 5   
   $��4��6>   $��35��6K   $	��280��6W   $
��Bold"�6c   $ Insert username��6u   ��6   �� $ Username�$ TwoWay=�6u   G� 5    
   -   5        $
��pass��5        G� PasswordChar$ *��6"   $��5��63   $��35��6@   $	��280��6L   $
��Bold"�6X   $ Insert password��6j   �� 5!   
   $��6��6   $��50��6   $	��280��6*   
���  ��$��2q�6H   y�6\   �� $ ErrorVisibility�._�5"      � ���	#20FF0000.+�5#      �� $��5q�68   $��WrapWithOverflow=�6C   $��Center=�6c   $
 Center=�6~   ��6   �� $ Error�6�   5$      5%      �� 5&   
   $��7��6   $��10q�6   $��30��6*   $	��130��66   $
��Left=�6B   $��Sign up��6]   ��6o   �� $ RegisterCommand���6�   �� $
 pass��6�   �� 5'   
   $��7��6   $��10q�6   $��30��6*   $	��130��66   $��Right=�6B   $��Login��6^   ��6n   �� $ GotoLoginCommand�6�   5(      5)      