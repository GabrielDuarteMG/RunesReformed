   M S B A M L   `   `   `  ����  RunesReformed2.1"    RunesReformed2._1.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$  
MainWindow��5   	   $��269.8��6   $��364.85��6+    � AllowsTransparency .  � WindowStyle$
 None=�5   #   ��5      �� 5   
    �� Opacity$ 0Q�6    �� Color$ White��6&    � 	Resources 5
         ComboBoxToggleButton �� 
TargetType � ColumnDefinitions ��Name	 �� CornerRadius
 F�Name �� EndPoint �� 
StartPoint � Color � Offset  ComboBoxTextBox �� 
TargetType �� Property �� Value �� 	ClickMode d� 	IsChecked �� Path �� Mode �� RelativeSource J� IsHitTestVisible �� SelectionBoxItem �� SelectionBoxItemTemplate ��Name �� 
IsReadOnly �� 
IsReadOnly �� SelectionBrush �� IsDropDownOpen � AllowsTransparency  J� SnapsToDevicePixels! � ActualWidth" �� MaxDropDownHeight# K� IsItemsHost-  'System.Windows.Input.KeyboardNavigation$   DirectionalNavigation% �� Triggers& P� Property' P� Value( �� 
TargetName) P� 
SourceName* �� Triggers+ �� Padding  SelectedCheckboxColor  UnselectedCheckboxColor, �Name- � Points��%T  &	        &	 �    '�� K    7   7  '�� �    &	 "    &	 E    '�� c    7  7  7  �� 5   
   " d�67   .R�5      �  5      �� 5      �� 5      $��20 �6'   .+�5      �� $ Border��5      $��2��5      $	 0��5      ���	#FF10171F���	#FFC89F48$��1q�5      �� 5      $��0��5      $	 0��5      $��1q�5      ���	#FF10171F
������ $��0,0,1,0q�5      F� 5      $
 Arrow��5       $��1��5!      $��Center=�5"      $��Center=�5#      =����        �    �� � 	= ��[ � z �� � z     � 	=  	= 	��5&      �� 5'      $ 0.5,1&�6.   $ 0.5,0&�6?   .��5(      � $ 	#FFD3AA4A��6+   $ 0.566Q�6=   � 5)      $ 	#FF938156��6+   $ 1Q�6=   � 5*      $ 	#FF9F8953��6+   $ 0.096Q�6=   5+      5-      5.      5=      �� 5?   
   " ��62   .R�5@      �� $ PART_ContentHost��6   |�.  #��z��6A   5A      �� 5C   
   " ��6*   .�5D      ��  �@J�SnapsToDevicePixels . 64   �� 5E       �@�OverridesDefaultStyle . 66   �� 5F       � ��$
 Auto=�6K   �� 5G       � ��$
 Auto=�6I   �� 5H       � �� . 6>   �� 5I       � ��$	 120��6)   �� 5J       � ��$ 20��6*   �� 5K       � �� �#9B96886+   �� 5L       � �� 5M      �� 5N      " ��6&   .R�5O      � .+�5P      d� $��ToggleButton��5Q      8��  $��2��5S      |�.  $ Press=�5V       5U      �� $ IsDropDownOpen�$ TwoWay=� �� *TemplatedParent+5W      �� 5X      $��ContentSite��6/    .  #��z 6\   #��z 5Y      #��z��5Z      $��3,3,23,3q�5[      $��Center=�5\      $
��Left=�5]      �� 5^      $ PART_EditableTextBox��6&   8�� $
��Left=�5a      $��Center=�5b      $��3,3,23,3q�5c      |�. ���	#FF10171F
��� � �$y�Hidden=�5g      # z 5h      ���	#FFC89F48��5_      Z�  5h   _   Z� � 5i      $��Popup��5j      $��Bottom=�5k      #��z 5l       . |�.  $��Slide=�5o      .��5q   "   � $��DropDown��6'     . #��z! 5s      #��z" 5t      .+�5u   &   �� $ DropDownBorder��5v   !   ���	#FF010A13$��1q�5y   !   ���	#FFC89F485z   !   �� 5{   &   $��4,6,4,6q�63     . .��5|   *   �� # . $$ 	Contained=�6H   5}   '   5~   #   5      5�      % 5�      P� 5�      & �@��HasItems' .  . �5�   "   �� $( DropDownBorder��6)    � ��$ 95��6Z   5�      P� 5�      & � {�' .  . �5�   "   ��  � �� �	#FF10171F6?   5�      P� 5�      & �@��
IsGrouping' . . �5�   "   ��  � �� .  6R   5�      P� 5�      $) Popup��6&   & �@�AllowsTransparency' . . �5�   "   �� $( DropDownBorder��6)    �@��CornerRadius$ 0��6]   �� 5�   "   $( DropDownBorder��6)    � ��$ 0,2,0,0q�6W   5�      P� 5�      & �@��
IsEditable' . . �5�   "   ��  � �� .  6>   �� 5�   "   $( PART_EditableTextBox��6)    � y�$ Visible=�6a   �� 5�   "   $( ContentSite��6)    � y�$ Hidden=�6X   5�      5�      5�      * 5�      5�      �� 5�   
   " ��6.   .�5�      ��  �@J�SnapsToDevicePixels . 64   �� 5�       � �� �	#FFC9BB8E6+   �� 5�       �@�OverridesDefaultStyle . 66   �� 5�       � �� 5�      �� 5�      " ��6&   .R�5�      �� $��Border��6!   $+ 2q�5�        . ._�5�      �� 5�      % 5�      P� 5�      & �@��IsHighlighted' . . �5�   "   �� $( Border��6)    � �� �	#FF10171F6S   5�      P� 5�      & � {�' .  . �5�   "   ��  � �� �	#FFC9BB8E6?   5�      5�      5�      5�      �� 5�   
   $ 	#FFC89F48��68   �� 5�   
   $
 Gray��6:   �� 5�   
   " ��6   .�5�      ��  � ��$ 1q�60   �� 5�       � �� 5�      �� 5�      " ��6&   .R�5�      �� $ border��6!   $��2q�61   
�������$��0,0,0.4,-2.4q�6X   ._�5�      �  5�   "   �� 5�   &   $��* �67   �� 5�   &   $
��Auto �67   .+�5�   "   �� $��0��63   #��z��6C   #��z��6�   ��. #  z  6�   #��z��6   � 5�   "   $, 	checkPoly��6*   - �    6n 6n 6n$��0��6k   $��24��6   $��24��6�   $	��Top=�5�   *   $��Right=�6B   8��  ��5�   Y   Z� 5�   ^   F� 5�   "   
�������"���Ѐ�[ ��[ �@T� @T� � $� �� 	$��2��6Q   $��
0, 1, 1, 0q�6e   $	��Top=�5�   '   $��Right=�6?   5�      5�      % 5�      P� 5�      & � ��' . . �5�   "   ��  � ��$ 4,0,0,0q�6<   5�      P� 5�      & � {�' .  . �5�   "   �� # � ��6?    � ��5�      P� 5�      & �@d�	IsChecked$
' TrueY�6;   . �5�   "   �� $( 	checkPoly��69   8   � ��6P   �� 5�   "   $( border��6@   8   � ��6T   5�      P� 5�      & �@J�IsMouseCaptureWithin' . . �5�   "   �� $( border��6@    6T   Z�  � ��5�      5�      5�      5�      5�      .��5�      � . � RowDefinitions. 5�   
   �� 5�      $	��53* �6   �� 5�      .+�5�   
   �� $
��Left=�6   $	��235��6/   $��
0,0,-0.2,0q�6<   $	��Top=�6P   $	��365��6h   ��5�      �� 5�      $ 0.5,1&�6&   $ 0.5,0&�67   .��5�      � $ 	#FF030F18��6#   $ 0Q�65   � 5�      $ 	#FF06222E��6#   $ 1Q�65   5�      5�      �� 5�   
   $
��Left=�6   $	��300��6+   $��-35,-65,-0.2,0q�68   $	��Top=�6P   $	��400��6h   $��Magic-PNG-Picture.png��6t   / J� Opacity$	/ 0.2Q�6�   $
��None=�6�   �� 5�   
   -   5        0 ��Name$0 
AddPageBTN��5�      $��Add Page��6$   $
��Left=�67   $��31��6R   $��
15,150,0,0q�6^   $	��Top=�6r   $	��115��6�   ���	#FFBEB188$��7,5,5,5q�6�   ���	#FFC89F48$��2q�6�   $��Segoe UI Emoji)�6�   $��Center=�6  $
��Bold"�6+  1 � Cursor$
1 Hand��6=  ��5�      �� 5�      $ 0.5,1&�6&   $ 0.5,0&�67   .��5�      � $ 	#FF1E2328��6#   $ 0.499Q�65   � 5�      $ 	#FF282D31��6#   $ 1Q�65   � 5�      $ 	#FF2C333A��6#   � 5�      $ 	#FF20252A��6#   $ 0.192Q�65   5�      5�      �� 5�   
   -   5        2 ��Name$2 ChampionSelectList��5�      $��85,50,9.8,179.8q�6Y   3 J� RenderTransformOrigin$3 0.5,0.5&�6�   $
1 Hand��6�   ��6/   �� $ ChampionList�z�5�      V� 5�      .~�5�      �� �� 5�      4 �� AngleX$4 -0.955Q�6$   �� 5�      T� 5�      5 T� X$5 -0.25Q�6)   5�      .@�5      �� -   5        $��ChampionDefault��5      .��62   Select the Champion6G   5     �� 5  
   -   5        $0 
SetPageBTN��5     $��Set Page��6$   $
��Left=�67   $��31��6R   $��240,150,0,0q�6^   $	��Top=�6s   $	��115��6�   ���	#FFBEB188$��7,5,5,5q�6�   ���	#FFC89F48$��2q�6�   $��Segoe UI Emoji)�6�   $��Center=�6  $
��Bold"�6,  $
1 Hand��6>  ��5     �� 5     $ 0.5,1&�6&   $ 0.5,0&�67   .��5     � $ 	#FF1E2328��6#   $ 0.499Q�65   � 5     $ 	#FF282D31��6#   $ 1Q�65   � 5     $ 	#FF2C333A��6#   � 5     $ 	#FF20252A��6#   $ 0.192Q�65   5	     5     �� 5  
   -   5        $2 RunesSelectList��5     $��85,100,9.8,129.8q�6,   $
1 Hand��6F   .@�5     �� -   5        $��RuneDefault��5     .��6.   Select your Rune6@   5     �� 5  
   -   5        $
��Left=�5     $	��Top=�6+   $��35��6C   $��
0,0,-0.2,0q�6O   $	��365��6c   $��	0,1,0,0.5q�6o   ���	#FFB6B6B6��5     �� 5     $ 0.5,1&�6&   $ 0.5,0&�67   .��5     � $ 	#FFC89F48��6#   $ 0.003Q�65   � 5     $ 	#FF939393��6#   $ 0.987Q�65   5     .��5     �� $��RunesReformed��6   ���	#FFC89F486,   5     �� 5  
   -	   5        $0 CloseBTN��5     $
��𝗫��6"   $
��Left=�6/   $��335,2,-0.2,0q�6J   $	��Top=�6`   ���	#FF79786F$��14(�6�   $��Segoe UI Light)�6�   $��30��6�   $��Center=�6�   $��33��6�   $
1 Hand��6�   6>  �� 5  
   -
   5        6 ��Name$6 DeletePageCB��5     $��Delete Current Page��6)   $
��Left=�6H   $��24��6c   $��
15,191,0,0q�6o   $	��Top=�6�   $	��125��6�   ���	#FFC89F48���	#FFBEB188$��10(�6�   $
1 Hand��6D  ��6�   Z� 6D  �� 5  
   -   5        $0 AboutLBL��5     $
��💬��6"   $
��Left=�6/   $��28��6J   $��330,199,0,0q�6V   $	��Top=�6k   $��25��6�   $��1q�6�   ���	#FFCDBE91$
��Bold"�6�   $��9(�6�   $��Center=�6�   $
1 Hand��6=  ��5     �� 5     $ 0.5,1&�6&   $ 0.5,0&�67   .��5     � $ 	#FF171B20��6#   $ 0.494Q�65   � 5     $ 	#FF212326��6#   $ 1Q�65   � 5      $ 	#FF1F2326��6#   5!     ��5#     �� 5$     $ 0.5,1&�6&   $ 0.5,0&�67   .��5%     � $ 	#FFD0A75C��6#   $ 0Q�65   � 5&     $ 	#FF886E40��6#   $ 1Q�65   5'     5)     �� 5*  
   -   5        7 ��Name$7 ChampionImage��5*     $
��Left=�6'   $��60��6B   $��	15,50,0,0q�6N   $	��Top=�6a   $��65��6y   $��DVdPUOUX0AArfyv.jpg��6�   $
��Fill=�6�   5,     5-     