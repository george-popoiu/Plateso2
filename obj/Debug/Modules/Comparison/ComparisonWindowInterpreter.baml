   M S B A M L   `   `   `  ����  Plateso2=    7Plateso2.Modules.Comparison.ComparisonWindowInterpreter   5   	   W SPresentationCore, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      8x,http://schemas.microsoft.com/winfx/2006/xaml    5        � Title$  
Comparison��5      $	��700��6   $	��800��6%   $	��700��61   $	��600��6@    � AllowsTransparency .  � WindowStyle$
 None=�6j    � WindowStartupLocation$ CenterScreen=�6}   ��6�   Z� .��5      � -   5        $��gridRoot��5      .+�5   
   ��  �� CornerRadius$ 15��6      TopBorderBrush#���   6#   � 5	   
   -   5        $��
gridLayout��5	   "   $��	0,9.3,0,0q�6    � RowDefinitions 5      �� 5      $��0.12* �6    �� 5      $��0.88* �6    .+�5      � -   5        $��gridTop��5       $��0��6     gradient_top#���  6/    5      �� 5      $
��0.4* �6$   �� 5      $
��0.6* �6$   .+�5      �� -   5        $��stackTopButtons��5      $��0,0,10,0q�64    �� Orientation$ 
Horizontal=�6F   $��RightToLeft=�6_   $��0��6{   .+�5      �� -   5        $��butExit��5        button_common#���  6,   .��5      �� $��15��6    $��15��6,   $,��&pack://application:,,,/Images/exit.png��67   5      �� 5      ��6    ��  �� Path$ Width�  TextBlockWidth �� Source# [ 	 �� Mode$	 OneWay=��� 5      -   5        $��buttonMaximize��5      #���  6P     template_button#���  6x   $��23��6�   $��23��6�   $��1q�6�   $��Center=�6�   $��Center=�6�   $��0,0,0,0q�6  ��5      �� 5      $��15��6$   $��15��60   $0��*pack://application:,,,/Images/maximize.png��6;   5!      �� 5"      ��6    �� $ Width�# [ $	 OneWay=��� 5#      -   5        $��butMinimize��5#      #���  60   .��5$      �� $��15��6    $��15��6,   $0��*pack://application:,,,/Images/minimize.png��67   5%      5&      �� 5(      -   5        $��	textTitle��5(   �   $��1��6   $��Center=�6)   $��Center=�6D   $��20(�6a   $��
Comparison��6o   6�   5*      � 5-      -	   5        $��
gridMiddle��5-       $��1��6   
 � ColumnDefinitions
 5/      �� 50      �� 51      .+�54      � -
   5        $��grid1��54   '   $��0��6     gridContentHost_Background#���  64   .+�55      �� $��Center=�6    $��Center=�6;   $"��Document no longer available��6X   
���  ��6|   �� 56      -   5        $��svTextViewer1��56   #   $��Disabled=�68   $y�Hidden=�6a   
�������$
��Auto=�6�   57      � 59      -   5        $��grid2��59      $��1��6$   #���  64   .+�5:      �� $��Center=�6    $��Center=�6;   $"��Document no longer available��6X   
���  ��6|   �� 5;      -   5        $��svTextViewer2��5;   #   $
��Auto=�68   $��Disabled=�6[   $y�Hidden=�6�   
�������6�   5<      �� 5>      $��2��6   $��Stretch=�6)     TreeViewBackgroundBrush#���  6E   $��0��6|   $��Right=�6�   5@      5B      n� 5D   
   -   5        $��topThumb��5D      $��5��6    $	��Top=�6+   $��Stretch=�6C   $��5,-3,5,0q�6a    J� Opacity$ 0Q�6s    � Cursor$ SizeNS��6   6�   n� 5E   
   -   5        $��bottomThumb��5E      $��5��6#   $��Bottom=�6.   $��Stretch=�6I   $��5,0,5,-3q�6g   $ 0Q�6y   $ SizeNS��6�   6�   n� 5F   
   -   5        $��	leftThumb��5F      $��5��6!   $��Stretch=�6+   $
��Left=�6G   $��-3,5,0,5q�6b   $ 0Q�6t   $ SizeWE��6�   6�   n� 5G   
   -   5        $��
rightThumb��5G      $��5��6"   $��Stretch=�6,   $��Right=�6H   $��0,5,-3,5q�6d   $ 0Q�6v   $ SizeWE��6�   6�   5I      5J      