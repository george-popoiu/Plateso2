   M S B A M L   `   `   `  ����  Plateso2*    $Plateso2.Modules.PatternSearchWindow   5   	   W SPresentationCore, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      8x,http://schemas.microsoft.com/winfx/2006/xaml    5      -   5          � Title$  Pattern Search��5      $	��600��63   $	��550��6@    � AllowsTransparency .  � WindowStartupLocation$ CenterScreen=�6f    � WindowStyle$
 None=�6�   ��6�   Z� .��5      � -   5        $��gridRoot��5      .+�5   
   ��  �� CornerRadius$ 15��6      TopBorderBrush#���   6#   � 5	   
   -   5        $��
gridLayout��5	   "   $��	0,9.3,0,0q�6    � RowDefinitions 5      �� 5      $��0.12* �6    �� 5      $��0.88* �6    .+�5      � -   5        $��gridTop��5       $��0��6     gradient_top#���  6/    5      �� 5      $
��0.4* �6$   �� 5      $
��0.6* �6$   .+�5      �� -   5        $��stackTopButtons��5      $��0,0,10,0q�64    �� Orientation$ 
Horizontal=�6F   $��RightToLeft=�6_   $��0��6{   .+�5      �� -   5        $��butExit��5        button_common#���  6,   ��5      �� 5      $��15��6$   $��15��60   $,��&pack://application:,,,/Images/exit.png��6;   5      �� 5       ��6    ��  �� Path$ Width�  TextBlockWidth �� Source# [ 	 �� Mode$	 OneWay=��� 5"      -   5        $��butMinimize��5"      #���  60   .��5#      �� $��15��6    $��15��6,   $0��*pack://application:,,,/Images/minimize.png��67   5$      5&      �� 5(      $��1��6   $��Pattern Search��6)   $��Center=�6?   $��Center=�6Z   $��20(�6w   5*      � 5-      -   5        $��
gridMiddle��5-       $��1��6   
 � ColumnDefinitions
 5.      �� 5/      $��0.15* �6'   �� 50      $
��0.7* �6'   �� 51      $��0.15* �6'    54      �� 55      $
��Auto �6$   �� 56      $
��0.9* �6$   �� 57      $
��0.1* �6$   .+�5:      ]� $��1��6   $��0��6,   ��.  .+�5;      �� $��	Pattern :��6    $	��Top=�61   $��0,5,0,0q�6F   �� 5<      -	   5        $��	tbPattern��5<      $	��Top=�6/   $��5q�6D     style_textb#��[ 6O    �� AcceptsReturn .  �� 
AcceptsTab . $	��Top=�6�   " �� VerticalScrollBarVisibility$
 Auto=�6�   $ �� HorizontalScrollBarVisibility$
 Auto=�6�   $	��100��6  5=      �� 5?      -
   5        $��lbDocuments��5?      $��5q�6-   $��1��68   $��1��6H    �� SelectionMode$ Extended=�6U   �� 5A      -   5        $��	butSearch��5A      $��Search��6*   $��1��6;   $��2��6K   $��Center=�6X   $��Center=�6s   #���  6�   $
��Auto��6�   5C      5E      5G      5H      