   M S B A M L   `   `   `  ����  Plateso2"    Plateso2.Modules.GDocsWindow   5   	   W SPresentationCore, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      8x,http://schemas.microsoft.com/winfx/2006/xaml    5        � Title$  Google Documents��5      $	��750��6   $	��550��6+    � AllowsTransparency .  � WindowStyle$
 None=�6Q    � WindowStartupLocation$ CenterScreen=�6z   ��6d   Z� .��5      � -   5        $��gridRoot��5      .+�5   
   ��  �� CornerRadius$ 15��6      TopBorderBrush#���   6#   � 5	   
   -   5        $��
gridLayout��5	   "   $��	0,9.3,0,0q�6    � RowDefinitions 5
      �� 5      $��0.12* �6    �� 5      $��0.88* �6    .+�5      � -   5        $��gridTop��5       $��0��6     gradient_top#���  6/    5      �� 5      $
��0.4* �6$   �� 5      $
��0.6* �6$   .+�5      �� -   5        $��stackTopButtons��5      $��0,0,10,0q�60    �� Orientation$ 
Horizontal=�6B   $��RightToLeft=�6[   $��0��6w   .+�5      �� -   5        $��butExit��5        button_common#���  6(   ��5      �� 5      $��15��6    $��15��6,   $,��&pack://application:,,,/Images/exit.png��67   5      �� 5      ��6   ��  �� Path$ Width�  TextBlockWidth �� Source# [ 	 �� Mode$	 OneWay=��� 5      -   5        $��butMinimize��5      #���  60   .��5      �� $��15��6    $��15��6,   $0��*pack://application:,,,/Images/minimize.png��67   5      5       �� 5"      $��Google Documents��6   $��Center=�60   $��Center=�6K   $��1��6h   $��20(�6u   5#      � 5&      -   5        $��
gridMiddle��5&       $��1��6   
 � ColumnDefinitions
 5(      �� 5)      $��0.15* �6'   �� 5*      $
��0.7* �6'   �� 5+      $��0.15* �6'    5.      �� 5/      $��0.10* �6$   �� 50      $��0.10* �6$   �� 51      $��0.05* �6$   �� 52      $��0.65* �6$   �� 53      $
��0.1* �6$   .+�56      �� $��1��6   $��0��6-   $��0,10,0,0q�6:   .+�57      �� $��Google account :��6    �� 58      -   5        $��
tbUsername��58   O   $��5q�6     style_textb#���  6)   6O   59      �� 5;      $��1��6   $��1��6-   $��0q�6:   .+�5<      �� $��
Password :��6    G� 5=      -	   5        $��
tbPassword��5=   W   $��5q�6"     style_passwordb#���  6-   6W   5>      �� 5@      $��1��6   $��2��6-   $��Center=�6:   $��Center=�6U   $ 
Horizontal=�6r   $
��Auto��6�   $
��Auto��6�   .+�5A      �� -
   5        $��butLogin��5A      $��Login��6-     style_button#���  6T   $��60��6{   �� 5C      ��6    �� $ Width�  WidthBetweetTopButtons# [ �� 5E      -   5        $��	butLogout��5E      $��Logout��6.   #���  6W   $��60��6~   5F      �� 5H      -   5        $��lbDocuments��5H      $��1��6-   $��3��6=    �� SelectionMode$ Extended=�6J   $��0,10,0,0q�6c    J� 	AllowDrop . 6�   �� 5J      $��1��6   $��4��6-   $ 
Horizontal=�6:   $��Center=�6S   $��Center=�6n   $
��Auto��6�   $
��Auto��6�   .+�5L      �� -   5        $��butDownload��5L      $��Center=�60   $��Center=�6K   $��Download��5M   7   #���  6J   �� 5O      ��6    �� $ Width�$	 OneWay=�# [ �� 5Q      -   5        $��	butDelete��5Q      $��Center=�6.   $��Center=�6I   $��Delete��6f   #���  5R      6D   5T      5V      5X      5[      5\      