   M S B A M L   `   `   `  ����H  DMahApps.Metro, Version=1.6.5.1, Culture=neutral, PublicKeyToken=nullV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5      fCclr-namespace:MahApps.Metro.Controls.Dialogs;assembly=MahApps.MetroMahApps.Metro.Controls.Dialogs  5       Barcoin.Client#   Barcoin.Client.View.LoginView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5      VDialogCclr-namespace:MahApps.Metro.Controls.Dialogs;assembly=MahApps.Metro     5       
  global#��[  5
        � DataContext  5	      ��   Locator �� Source# [  �� Path$ Login�8   2MahApps.Metro.Controls.Dialogs.DialogParticipation   Register 5      ��  J� InputBindings 5      �� 5   
   
 �� Key$ Return��6i    �� Command 6   �� $ LoginCommand� �� CommandParameter 6;   ��  �� ElementName$
 pass��6i   .��5      � $��Center=�6   $��
0 30 0 180q�6(   $	��500��6<   	 � RowDefinitions	 5   
   �� 5      $	��.7* �6   �� 5      $	��.4* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $��40(�6!   
 �� TextAlignment$
 Center=�6/   $��Login��6F   $	��300��6S   �� 5   
   $��1��6   
����� �6!   �� 5   
   $��	0,10,0,10q�6>   $��2��6Q   $��35��6^   $	��280��6j   $
��Bold"�6v   *   $MahApps.Metro.Controls.TextBoxHelper   	Watermark$ Insert username��6�   ��6   �� $ Username� �� Mode$ TwoWay=�6�   G� 5   
   -   5        $
��pass��5      $��	0,10,0,10q�6"    G� PasswordChar$ *��65   $��3��6F   $��35��6S   $	��280��6_   $
��Bold"�6k   $ Insert password��6}   �� 5   
   $��6��6   $��50��6   $	��280��6*   
���  ��$��2q�6H   y�6\   �� $ ErrorVisibility�._�5       � ���	#20FF0000.+�5!      �� $��5q�68   $��WrapWithOverflow=�6C   $��Center=�6c   $
 Center=�6~   ��6   �� $ Error�6�   5"      5#      �� 5$   
   $��7��6   $��10q�6   $��30��6*   $	��130��66   $
��Left=�6B   $��Sign in��6]   ��6o   �� $ LoginCommand���6�   �� $
 pass��6�   �� 5%   
   $��7��6   $��10q�6   $��30��6*   $	��130��66   $��Right=�6B   $��Register��6^   ��6q   �� $ GotoRegisterCommand�6�   5&      5'      