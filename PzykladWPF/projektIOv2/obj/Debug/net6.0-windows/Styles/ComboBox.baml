   M S B A M L   `   `   `  ����b  ^PresentationFramework.Aero2, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35hKclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.Aero2Microsoft.Windows.Themes  5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089   FocusVisual  �� Property �� Value �� StrokeDashArray J� SnapsToDevicePixels �� RadiusX �� RadiusY  ComboBoxToggleButton �� 
TargetType �� 
TargetType ��Name  ComboBox.Static.Background  ComboBox.Static.Border	 �� CornerRadius
 F�Name �� Triggers ^� 
Conditions �� Binding �� RelativeSource �� Value �� AncestorType �� 
TargetName ! ComboBox.MouseOver.Background  ComboBox.MouseOver.Border  ComboBoxEditableTemplate �Name � ColumnDefinitions �Name � AllowsTransparency5    /Microsoft.Windows.Themes.SystemDropShadowChrome   Name    Color �� MaxDropDownHeight �� ElementName ��Name �� ClearTypeHint ��Name ��Name ��Name-  'System.Windows.Input.KeyboardNavigation   DirectionalNavigation  d�Name! d� 	IsChecked" �� Mode  TextBox.Static.Background# ��Name$ �� 
IsReadOnly% P� Property& P� Value' P� 
SourceName( ]� 
Conditions) �� Property  ComboBoxTemplate 	 ComboBox.List.Background* ��Name#+ �� SelectionBoxItemStringFormat, �� ContentStringFormat- �� SelectionBoxItemTemplate. �� SelectionBoxItem/ J� IsHitTestVisible 
 TextBox.Static.Foreground0 �� Triggers1 �� Padding  PrimaryBlueColor�� 5      F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     :x,http://schemas.microsoft.com/winfx/2006/xaml     5      UthemeKclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.Aero2  5      %a  &	        &	 �     &	 �    7  7  &	 �    7  '�� �    7   7  7  7  7  '�� `    �� 5      .�5      ��   � �� 5      �� 5	      .R�5
      �� $��2q�6   $	 1 2R�6   #��� ��62   $
 true��6y   $��1��6�   $ 20��6�   $ 20��6�   5      5      5      �� 5      " d�6&   .�5      ��   �@�OverridesDefaultStyle$
 true��6,   �� 5        � ��$ false��6    �� 5        � |�$ false��6    �� 5        �@��	ClickMode$ Press=�6    �� 5        � �� 5      �� 5      " d�6   .R�5      �� $ templateRoot��6   #���  6$   #���  6^   #��z��6�   $
 true��6�   $	 10��6�   ._�5      �� $ splitBorder��6   
������ $��1q�6>   $��Right=�6R   $��0q�6n   $
 true��6y   #��� r�6�   ._�5   	   F� $
 arrow��6   F����        ���( ��( јaQ     јaQ P����̰( � �    P����        #��z��6~   $��Center=�6�   $��0,0,5,0q�6�   $��Center=�6�   5   	   5       5      ^� 5$       5%   	   �� 5&   
    6   �� *IsMouseOver+ �� *Self+ true6Z   �� 5'   
    6   �� *
IsEditable+ �� " ��	 false6s   .0�5)   	   �� $ templateRoot��6&   # �  6@     � ���� 5*   	   $ templateRoot��6'   # �  6A     � ��5+   	   5a      5c      5d      �� 5e      " ��64   .R�5f      � $ templateRoot��6	   $
 true��6    5g      �� 5h      $��* �6   �� 5i      #��� r�6   $��0 �6j   .+�5k      � $ 
PART_Popup��6   $
 true��6   $��2��69   $��Bottom=�6�   #��� .�6�   ��6M   �� *IsDropDownOpen+ �� *TemplatedParent+.��5l         $ shadow��6#   $ Transparent��63   #��z 6�   ��6G   �� *ActualWidth+$ templateRoot��._�5m      �� $ dropDownBorder��6   #��� ��6&   #��� ��6l   $��1q�6�   ._�5n      �� $ DropDownScrollViewer��6   .��5o   	   � $
 grid��6   $ Enabled=�6   .+�5p   
   �� $ canvas��6   $
��Left=�6!   $��0��6<   $	��Top=�6G   $��0��6_   .+�5q      �� $ 
opaqueRect��6   $ 20��6�   $ 20��6�   ��6)   �� *
Background+$ dropDownBorder����6a   �� *ActualHeight+$ dropDownBorder����6�   �� *ActualWidth+$ dropDownBorder��6�   5r      �� 5s   
   $ ItemsPresenter��6   $ 	Contained=�61   # z 6f   5t   
   5u   	   5v      5w      5y      d� 5z      $  toggleButton��6   #��z��6(   #��z��6R   #��z��6~   $��2��6�   8��  ! 6�   �� *IsDropDownOpen+$" TwoWay=� �� *TemplatedParent+6)  �� 5{      $ border��6   8�� #��z��6T   $	 20��6   ._�5|      �� $# PART_EditableTextBox��6   #��z��6,   #��z��6�   #��z��6�   $ 6v   �� *
IsReadOnly+ �� *TemplatedParent+6�   5}      5~       5      P� 5�      % � {�$& false��6"   . �5�      �� $ border��6      �@J�Opacity$
 0.56Q�64   5�      P� 5�      % �@J�IsKeyboardFocusWithin$
& true��6.   . �5�      ��   � ��
 �   �6#   5�      P� 5�      $' 
PART_Popup��6&   % �@�HasDropShadow$
& true��6>   . �5�      �� $ shadow��6     � ��$ 0,0,5,5q�63   �� 5�      $ shadow��6     �@  Color$ transparent��62   5�      P� 5�      % �@��HasItems$& false��6!   . �5�      �� $ dropDownBorder��6     � ��$ 95��6;   5�      ]� 5�      ( 5�      �� 5�      ) �@��
IsGrouping$
 true��6'   �� 5�      ") �@%�IsVirtualizingWhenGrouping$ false��6I   ./�5�      ��   � ��$ false��66   5�      P� 5�      $' DropDownScrollViewer��66   % � ��$& false��6X   . �5�      �� $ 
opaqueRect��6#    6;   �� *VerticalOffset+$ DropDownScrollViewer��  �@��Top�� 5�      $ 
opaqueRect��6$    6<   �� *HorizontalOffset+$ DropDownScrollViewer��  �@��Left5�      5�      �� 5�      " ��6,   .R�5�      � $ templateRoot��6	   $
 true��6    5�      �� 5�      $��* �6   �� 5�      #��� r�6   $��0 �6j   .+�5�      � $ 
PART_Popup��6   $
 true��6   $��2��69   $��1q�6�   $��Bottom=�6�   #��� .�6�   ��6M   �� *IsDropDownOpen+$" TwoWay=� �� *TemplatedParent+.��5�         $ shadow��6#   $ Transparent��63   #��z 6�   ��6G   �� *ActualWidth+$ templateRoot��._�5�      �� $ dropDownBorder��6   #��� ��6&   #��� ��6l   $��0q�6�   $	 20��6�   ._�5�      �� $ DropDownScrollViewer��6   .��5�   	   � $
 grid��6   $ Enabled=�6   .+�5�   
   �� $ canvas��6   $
��Left=�6!   $��0��6<   $	��Top=�6G   $��0��6_   .+�5�      �� $ 
opaqueRect��6   #��� 	 6)   $ 5��6�   $ 5��6�   ��6[   �� *ActualHeight+$ dropDownBorder����6�   �� *ActualWidth+$ dropDownBorder��6�   5�      �� 5�   
   $ ItemsPresenter��6   $ 	Contained=�61   # z 6f   5�   
   5�   	   5�      5�      5�      d� 5�      $  toggleButton��6   #��z��6(   #��z��6R   #��z��6~   $��2��6�   8��  ! 6�   �� *IsDropDownOpen+$" TwoWay=� �� *TemplatedParent+6)  �� 5�      $* contentPresenter��6   #, z+ 60   #��z- 6u   #��z. 6�   #��z��6�   #��z��6   $/ false��6c  #��z��6|  # z 6�  #��z��6�  5�       5�      P� 5�      $' 
PART_Popup��6&   % �@�HasDropShadow$
& true��6>   . �5�      �� $ shadow��6     � ��$ 0q�63   �� 5�      $ shadow��6     �@  Color$ transparent��62   5�      P� 5�      % �@��HasItems$& false��6!   . �5�      �� $ dropDownBorder��6     � ��$ 95��6;   5�      ]� 5�      ( 5�      �� 5�      ) �@��
IsGrouping$
 true��6'   �� 5�      ") �@%�IsVirtualizingWhenGrouping$ false��6I   ./�5�      ��   � ��$ false��66   5�      P� 5�      $' DropDownScrollViewer��66   % � ��$& false��6X   . �5�      �� $ 
opaqueRect��6#    6;   �� *VerticalOffset+$ DropDownScrollViewer��  �@��Top�� 5�      $ 
opaqueRect��6$    6<   �� *HorizontalOffset+$ DropDownScrollViewer��  �@��Left5�      5�      �� 5�      " ��6	   .�5�      ��   �@�FocusVisualStyle8   6'   �� 5�        � ��8  6!   �� 5�        � ��8  6"   �� 5�        � ��# � ��6!   �� 5�        � ��$ 2q�6&   �� 5�        � ��$
 Auto=�6A   �� 5�        � ��$
 Auto=�6?   �� 5�        � ��$ 10q�6   �� 5�        � ��$
 true��64   �� 5�        �@��PanningMode$
 Both=�6/   �� 5�        �@��IsFlicksEnabled$ False��6-   �� 5�        � ��8  6   �� 5�   
     � ��# � 
 6'   0 5�      P� 5�      % �@��
IsEditable$
& true��6#   . �5�      ��   � ��$ false��6"   �� 5�        � ��$ 10q�6    �� 5�        � ��8  6!   5�      5�      �� 5�      " ��6'   .�5�      ��   �@J�SnapsToDevicePixels$
 true��6*   �� 5�        �@�OverridesDefaultStyle$
 true��6,   �� 5�        � ��
 �   �6!   �� 5�        � �� 5�      �� 5�      " ��6   .R�5�      �� $ Border��6   $1 10q�6   $
 true��6+   
������ $��1q�6_   $	 5��6s   ._�5�      �� 5�       5�      P� 5�      % �@��
IsSelected$
& True��68   . �5�      �� $ Border��6%   # � 	 6O     � ��5�   	   P� 5�      % �@J�IsKeyboardFocused$
& True��6-   . �5�   	   �� $ Border��6   # �  6:     � ���� 5�      # � 	 6;     � ��5�   	   5�      5�      5�      5�      