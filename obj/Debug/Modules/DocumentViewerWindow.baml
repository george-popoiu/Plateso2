   M S B A M L   `   `   `  ����  Plateso2+    %Plateso2.Modules.DocumentViewerWindow   5   	   W SPresentationCore, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      8x,http://schemas.microsoft.com/winfx/2006/xaml    5        � Title$  Document Viewer��5      $	��550��6   $	��500��6*    � AllowsTransparency .  � WindowStyle$
 None=�6P    � WindowStartupLocation$ CenterOwner=�6y   $	��400��6�   $	��500��6�   ��6c   Z� .��5      � -   5        $��gridRoot��5      .+�5   
   ��  �� CornerRadius$ 15��6      TopBorderBrush#���   6#   � 5	   
   -   5        $��
gridLayout��5	   "   $��	0,9.3,0,0q�6    � RowDefinitions 5      �� 5      $��0.12* �6    �� 5      $��0.88* �6    .+�5      � -   5        $��gridTop��5       $��0��6     gradient_top#���  6/    5      �� 5      $
��0.4* �6$   �� 5      $
��0.6* �6$   .+�5      �� -   5        $��stackTopButtons��5      $��0,0,10,0q�64    �� Orientation$ 
Horizontal=�6F   $��RightToLeft=�6_   $��0��6{   .+�5      �� -   5        $��butExit��5        button_common#���  6,   .��5      �� $��15��6    $��15��6,   $,��&pack://application:,,,/Images/exit.png��67   5      �� 5      ��6    ��  �� Path$ Width�  TextBlockWidth �� Source# [ 	 �� Mode$	 OneWay=��� 5      -   5        $��butMinimize��5      #���  60   .��5      �� $��15��6    $��15��6,   $0��*pack://application:,,,/Images/minimize.png��67   5      5       �� 5"      -   5        $��
textbTitle��5"   *   $��20(�6   $��1��6<   $��Center=�6I   $��Center=�6d   5$      �� 5'      -   5        $��svTextViewer��5'   (   $��10q�6   $
��Auto=�6<   $��Disabled=�6_   
�������$��1��6�   $��Stretch=�6�   $��Stretch=�6�   5)      n� 5+   
   -	   5        $��thTop��5+      $	��Top=�6   $��Stretch=�65   $��5��6S   $��
10,-3,10,0q�6^   
 J� Opacity$
 0Q�6r    � Cursor$ SizeNS��6�   n� 5,   
   -
   5        $��thBottom��5,      $��Bottom=�6    $��Stretch=�6;   $��5��6Y   $��
10,0,10,-3q�6d   $
 0Q�6x   $ SizeNS��6�   n� 5-   
   -   5        $��thLeft��5-      $��Stretch=�6   $
��Left=�6:   $��5��6U   $��
-3,10,0,10q�6_   $
 0Q�6s   $ SizeWE��6   6�   n� 5.   
   -   5        $��thRight��5.      $��Stretch=�6   $��Right=�6;   $��5��6W   $��
0,10,-3,10q�6a   $
 0Q�6u   $ SizeWE��6�   6�   50      51      