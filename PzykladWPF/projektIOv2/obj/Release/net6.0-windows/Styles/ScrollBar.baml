   M S B A M L   `   `   `  ���� W  SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089   FocusVisual  �� Property �� Value �� StrokeDashArray J� SnapsToDevicePixels  RepeatButtonTransparent �� 
TargetType �� 
TargetType  ScrollBarButton ��Name  ScrollBar.Static.Background  ScrollBar.Static.Border ��Name �� Triggers	 P� Property
 P� Value �� 
TargetName " ScrollBar.MouseOver.Background  ScrollBar.MouseOver.Border   ScrollBar.Pressed.Background  ScrollBar.Pressed.Border !	 ScrollBar.Disabled.Background 
 ScrollBar.Disabled.Border  ScrollBarThumbVertical ��Name  ScrollBar.Static.Thumb �� RadiusX �� RadiusY  ScrollBar.MouseOver.Thumb  ScrollBar.Pressed.Thumb  ScrollBarThumbHorizontal �Name � RowDefinitions ��Name �� LineUpCommand J� IsMouseOver F�Name  ScrollBar.Static.Glyph �� Stretch ]�Name ]� DecreaseRepeatButton �� PageUpCommand ]� IncreaseRepeatButton �� PageDownCommand ]� Thumb �� LineDownCommand ^� 
Conditions �� Binding �� ElementName  �� Value  ScrollBar.Pressed.Glyph  ScrollBar.MouseOver.Glyph  ScrollBar.Disabled.Glyph! �� Triggers" � ColumnDefinitions# �� LineLeftCommand$ �� PageLeftCommand% �� PageRightCommand& �� LineRightCommand�� F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      :x,http://schemas.microsoft.com/winfx/2006/xaml      %  &	        &	 R     &	     &	 �    &	 \    '�� �    �� .���   � �� �� .R��� $��2q�$	 1 2R�#��� ��$
 true��$��2���� " ��.���   �@�OverridesDefaultStyle$
 true����   � ��
 ���� ��   � |�$ false����   � ��$ false����   � �� �� " ��.R��� #��z��#��z��#��z���� " ��.���   �@�FocusVisualStyle# �   ��   � ��$ 1q���   � ��$ Center=���   � ��$ Center=���   � ��$ 1q���   � |�$ false����   � ��$ false����   � �� �� " ��.R��� $ border��#���  #���  $��1q�$
 true��._��� $ contentPresenter��$|�False��#��z��#��z��# z #��z�� P� 	 �@J�IsMouseOver$

 true��. ��� $ border��# �    � ���� $ border��# �    � ��P� 	 � ��$

 true��. ��� $ border��# �    � ���� $ border��# �    � ��P� 	 � {�$
 false��. ��� $ contentPresenter��  �@J�Opacity$
 0.56Q��� $ border��# � 	   � ���� $ border��# � 
   � ���� " n�.���   �@�OverridesDefaultStyle$
 true����   � ��$ false����   � �� �� " n�.R��� $ 	rectangle��#���  $
 True��$��2��$ 3��$ 3�� P� 	 �@J�IsMouseOver$

 true��. ��� $ 	rectangle��# �    � ���� $ 	rectangle��  � ��$ 5��P� 	 �@n�
IsDragging$

 true��. ��� $ 	rectangle��# �    � ���� $ 	rectangle��  � ��$ 5���� " n�.���   �@�OverridesDefaultStyle$
 true����   � ��$ false����   � �� �� " n�.R��� $ 	rectangle��#���  #��z��$
 True��#��z�� P� 	 �@J�IsMouseOver$

 true��. ��� $ 	rectangle��# �    � ��P� 	 �@n�
IsDragging$

 true��. ��� $ 	rectangle��# �    � ���� " ��.���   �@��IsPressAndHoldEnabled$ false����   �@��IsFlicksEnabled$ false����   � ��# �  ��   � ��# �  ��   � ��
 ���� ��   � ��$	 1,0q���   � ��# � r���   � ��# � r���   � �� �� " ��.R�� $ Bg��$
 true�� �� #��� q��� $��0.00001* ��� #��� q�.+��� #��z��#��z��#��z��$��1���� $ PART_LineUpButton��#��Z #{�z #���  .��F� $ ArrowTop�������     	= �     	= ��[ ��[ �    ��[ �g5 �%& �g5 �%& ��g5 �%& ��j ��[ ��j ��[ ���j ��[ ��j  	= ��j  	= ���j  	= �g5  � �g5  � ��g5  �  	=  	= 	#���  $��3,4,3,3q�$ Uniform=�]� $ 
PART_Track��$
��true��#{�z $��1�� �� #��Z #���   �� #��Z #���   n� #���  �� $ PART_LineDownButton��#��Z #{�z $��2��#���  .��F� $ ArrowBottom�������    �%& �    �%&  �  � �     � �g5  	= �g5  	= ��g5  	= ��j  � ��j  � ���j  � ��j �%& ��j �%& ���j �%& �g5 ��[ �g5 ��[ ��g5 ��[ �%& �%& 	#���  $��3,4,3,3q�$ Uniform=� ^�  ��  �� *IsMouseOver+$ PART_LineDownButton��  true��  �� *	IsPressed+$ PART_LineDownButton��  true.0��� $ ArrowBottom��# �    � ��^�  ��  �� *IsMouseOver+$ PART_LineUpButton��  true��  �� *	IsPressed+$ PART_LineUpButton��  true.0��� $ ArrowTop��# �    � ��^�  ��  �� *IsMouseOver+$ PART_LineDownButton��  true��  �� *	IsPressed+$ PART_LineDownButton��	  false.0��� $ ArrowBottom��# �    � ��^�  ��  �� *IsMouseOver+$ PART_LineUpButton��  true��  �� *	IsPressed+$ PART_LineUpButton��	  false.0��� $ ArrowTop��# �    � ��P� 	 � {�$
 false��. ��� $ ArrowTop��# �    � ���� $ ArrowBottom��# �    � ��! P� 	 �@��Orientation$
 
Horizontal=�. ���   � ��$
 Auto����   � ��$ 0����   � ��# � ����   � ��# � ����   � ��$	 0,1q���   � �� �� " ��.R�� $ Bg��$
 true��" �� #��� ���� $��0.00001* ��� #��� ��.+��� #��z��#��z��#��z��$��1���� $ PART_LineLeftButton��#��Z# #{�z #���  .��F� $ 	ArrowLeft���������0 ��j ���0 ��j @KL ��j @KL ��j �@KL ��j P� �g5 P� �g5 �P� �g5 @KL @KL �@KL     ��0 ��0 ���0     �g5 �g5 �    �g5 ��0 ��j ��0 ��j 	#���  $��3q�$ Uniform=�]� $ 
PART_Track��$��1��#{�z  �� #��Z$ #���   �� #��Z% #���   n� #���  �� $ PART_LineRightButton��#��Z& $��2��#{�z #���  .��F� $ 
ArrowRight�������P� ��j �P� ��j ��j ��j �    ��j ��0 �g5 ��0 �g5 ���0 �g5 �        P� P� �P�     @KL �g5 @KL �g5 �@KL �g5 P� ��j P� ��j 	#���  $��3q�$ Uniform=� ^�  ��  �� *IsMouseOver+$ PART_LineRightButton��  true��  �� *	IsPressed+$ PART_LineRightButton��  true.0��� $ 
ArrowRight��# �    � ��^�  ��  �� *IsMouseOver+$ PART_LineLeftButton��  true��  �� *	IsPressed+$ PART_LineLeftButton��  true.0��� $ 	ArrowLeft��# �    � ��^�  ��  �� *IsMouseOver+$ PART_LineRightButton��  true��  �� *	IsPressed+$ PART_LineRightButton��	  false.0��� $ 
ArrowRight��# �    � ��^�  ��  �� *IsMouseOver+$ PART_LineLeftButton��  true��  �� *	IsPressed+$ PART_LineLeftButton��	  false.0��� $ 	ArrowLeft��# �    � ��P� 	 � {�$
 false��. ��� $ 	ArrowLeft��# �    � ���� $ 
ArrowRight��# �    � ��