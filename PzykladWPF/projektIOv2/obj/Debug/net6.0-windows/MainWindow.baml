   M S B A M L   `   `   `  ����F  BprojektIOv2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:projektIOv2.ControlsprojektIOv2.Controls  5   	   )clr-namespace:projektIOv2projektIOv2  5   	       projektIOv2.MainWindow   5   	   +ctls"clr-namespace:projektIOv2.Controls  W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:projektIOv2     5   	   Ictls19http://schemas.microsoft.com/netfx/2009/xaml/presentation    61   -   5        $
��home��5      $	��650��5	   	   $
��1000��5
   	     � Title$  
MainWindow��5   	   $	��650��6   $
��1000��6)    � WindowStartupLocation$ CenterScreen=�5   	    � WindowStyle$
 None=�6.   
������  � AllowsTransparency$
 True��5   "    � 
ResizeMode$ CanResizeWithGrip=�5   	   .��5      ��    PrimaryBackgroundColor#���   6    �� CornerRadius$ 8��5      ._�5   
   �  � ColumnDefinitions 5      �� 5      $
��Auto �6#   �� 5      $��* �6#   .+�5      �� $��0��6     SecundaryBackgroundColor#���  5      $ 8 0 0 8��5      ._�5       � -   5         �Name$ GridNav��5       $��60��6(    � RowDefinitions 5!      �� 5"      $��60 �6(   �� 5#      $��* �6(   .+�5&      � $��0��6   .+�5'      �� $��14 0 0 0q�5(      $��32��5)      $��24��6*   $
��Left=�5*      5.      �� 50      $��WIG20��6      PrimaryTextColor#���  51       $
��Bold"�52       $��16(�53       $��Center=�54       $
��Left=�55       $��60 0 0 0q�56       57      �� 5:      $��1��6!   $��
-1 40 0 20q�6.   .+�5;      �� -   5        	 ��Name$	 btnHome��5;   !     PopupButtonStyle#���  62   .��5<      #   projektIOv2.Controls.MenuItem  
   
IsSelected$

 True��6,      	GroupName$ MenuItem��6>     PrimaryBlueColor   IndicatorBrush# �  6S     home   Icon# �  6�      	IconWidth$ 16��6�      Text$ 	Notowania��6�   $��Center=�6�   5=      �� 5>      -   5        $	 btnDashboard��5>   !   #���  67   .��5?        $ MenuItem��6,   # �  6A     	dashboard# �  6u   $ 16��6�   $ 	Artykuły��6�   $��Center=�6�   5@      �� 5D      -   5        $	 
btnSetting��5D   !   #���  65   .��5E        $ MenuItem��6,   # �  6A     settings# �  6u   $ 16��6�   $ 
Ustawienia��6�   $��Center=�6�   5F      5G      � 5K      -   5         �Name$ Popup��5K       � AllowsTransparency$
 True��6,    � HorizontalOffset$ 0��6G    � VerticalOffset$ 10��6\   .��5L      $   projektIOv2.Controls.UserPopup  -   5          Name$ Header��5L   )   #���  69   5M      5P      5Q      � 5S      $��1��6    5T      �� 5U      $��60 �6$   �� 5V      $��* �6$   .+�5Y      d� -   5         d�Name$ Tg_Btn��5Y      $��1��6/   $��Center=�6?     iToggleButtonStyle#���  6Z   $
��Left=�6�   $��0q�6�   
������ $��
10,15,0,15q�6�   $��30��6�   $��30��6�    � Triggers 5Z      :� 5[       :� RoutedEvent$ ToggleButton.Unchecked��6'   .[�5\      �� .��5]   "   �� -	   5         ��Name$ HideStackPanel��5]   -   .��5^   &   W�  �� 
TargetName$ GridNav��66    �� TargetProperty$ Width�6V    g� 	BeginTime	 0:0:06x    W� From 2106�   	 W� To 606�    g� Duration$ 0:0:0.5D�6�   5_   '   5`   #   5a      5b      :� 5c      $ ToggleButton.Checked��6'   .[�5d      �� .��5e   "   �� -
   5        $ ShowStackPanel��5e   -   .��5f   &   W� $ GridNav��66   $ Width�6V   	 0:0:06x    606�    2106�   $ 0:0:0.5D�6�   5g   '   5h   #   5i      5j      5l      �� 5o      $��0��6   $��Right=�6*   $	��Top=�6F   $��0,5,10,0q�6^   $��30��6p    �� Orientation$ 
Horizontal=�6|   $��RightToLeft=�6�   $��2��6�   .+�5p      �� -   5        $	 btnClose��5p       	 IconButtonsStyle#��[	 6/    	
 close#��� 
 6Y   
  � Tag$  IsCloseButton��6�   �� 5q      -   5        $	 
btnRestore��5q      $	��5,0q�61   ��5r      �� 5s      ! �� 
TargetType"! ��6$   " �� BasedOn#" [	 6A   .�5t   "   �� # �� Property# � ��  maximize$ �� Value#$ �  6<   % �� Triggers% 5u   "   �� 5v   &   & �� Binding& 62   �� ' �� ElementName$
' home��( �� Path$( WindowState�) �� Value) 	Maximized6i   .a�5w   *   �� # � ��  restore#$ �  6D   5x   '   5z      5|      �� 5}      -   5        $	 btnMinimize��5}      #��� 	 62     minimize#���  6]   6�   5~       � 5�      -   5        $��
fContainer��5�      $��1��5�      $��20q�5�      *  � NavigationUIVisibility$* Hidden=�5�      5�      5�      5�      5�      5�      