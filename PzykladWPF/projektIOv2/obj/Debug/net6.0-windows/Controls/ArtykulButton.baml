   M S B A M L   `   `   `  ����F  BprojektIOv2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:projektIOv2projektIOv2  5          projektIOv2.ArtykulButton   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      +localclr-namespace:projektIOv2     5        � 	Resources  5	      %   projektIOv2.VisibilityConverter   VisibilityConverter  FocusVisual �� Property �� Value �� StrokeDashArray J� SnapsToDevicePixels  Button.Static.Background �� Color  Button.Static.Border  Button.MouseOver.Background  Button.MouseOver.Border  Button.Pressed.Background  Button.Pressed.Border  Button.Disabled.Background 	 Button.Disabled.Border 
 Button.Disabled.Foreground  ResetButton �� 
TargetType �� 
TargetType ��Name	 ��Name
 �� Triggers P� Property P� Value �� 
TargetName��%�  &	        &	      &	 �     &	 �     &	     &	 5    &	 Z    &	     &	 �    &		 �    &	
 �    &	     7  7  7  7  7  7  7 	 7 
   5
   
   6$   �� 5   
   .�5      ��  � �� 5      �� 5      .R�5      �� $��2q�6$   $	 1 2R�6/   #��� ��6E   $
 true��6�   $��1��6�   5      5      5      �� 5   
   $ Transparent��6;   �� 5   
   $ Transparent��67   �� 5   
   $ Transparent��6>   �� 5   
   $ Transparent��6:   �� 5   
   $ Transparent��6<   �� 5   
   $ Transparent��68   �� 5   
   $ Transparent��6=   �� 5   
   $ Transparent��69   �� 5    
   $ Transparent��6=   �� 5!   
   " ��6$   .�5"      ��  �@�Cursor$
 Hand��6'   �� 5#       �@�FocusVisualStyle8   61   �� 5$       � ��
 ���� 6+   �� 5%       � ��
 ���� 6,   �� 5&       � ��
 ���� 6+   �� 5'       � ��$ 1q�60   �� 5(       � ��$
 Left=�6;   �� 5)       � ��$	 Top=�69   �� 5*       � ��$ 0q�6(   �� 5+       � �� 5,      �� 5-      " ��6&   .R�5.      �� $ border��6!   #��z��61   #��z��6[   #��z��6�   $
 true��6�   ._�5/      �� $	 contentPresenter��6/   $|�False��6I   #��z��6[   #��z��6�   $
��True��6�   # z 6�   #��z��6  50      
 51      P� 52       �@��IsDefaulted$
 true��6D   . �53   "   �� $ border��6@   # � ��6T    � ��54      P� 55       �@J�IsMouseOver$
 true��6=   . �56   "   �� $ border��6?   8   � ��6S   �� 57   "   $ border��6@   8   � ��6T   58      P� 59       � ��$
 true��6;   . �5:   "   �� $ border��6?   8   � ��6S   �� 5;   "   $ border��6@   8   � ��6T   5<      P� 5=       � {�$ false��6;   . �5>   "   �� $ border��6?   8   � ��6S   �� 5?   "   $ border��6@   8   � ��6T   �� 5@   "   $ contentPresenter��6K   8   � ��6i   5A      5C      5E      5F      5G      .��5H      �  � ColumnDefinitions 5I   
   �� 5J      $��7* �6   �� 5K      $��6* �6    � RowDefinitions 5M   
   �� 5N      $
��auto �6   �� 5O      $
��auto �6   �� 5P      $
��auto �6   .+�5R   
   �� -   5         ��Name$ d1��5R   c     ArtykulButton.st1#���  6*   $��0��6V   ��6   �� *YEAR+y�6o   ��  �� Path$
 YEAR� �� 	Converter# [  �� 5S   
   -   5        $��d2��5S   c   $��1��6*     ArtykulButton.st2#���  67   ��6   �� *HOUR+y�6m   �� $
 HOUR�# [  �� 5U   
   -   5        #��[ 5U      $��2��66   $
��Left=�6C   y�6_   �� $ Naglowek�# [  .��5V      ��  �� Orientation$ 
Horizontal=�6   .+�5W      ��   ArtykulButton.kreska#���  6   �� 5X      -   5        $��n1��5X   C   $��2��66    " ArtykulButton.naglowekartykulu#���  6N   ��6   �� *
Naglowek+6N   5Z      5[      5]      5^      