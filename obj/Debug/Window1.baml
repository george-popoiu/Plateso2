   M S B A M L   `   `   `  ����  Plateso2    Plateso2.Window1   5   	   W SPresentationCore, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      8x,http://schemas.microsoft.com/winfx/2006/xaml    5      -   5          � Title$  Plateso��5      $	��700��6   $
��1000��6"    � Icon$3 -pack://application:,,,/Images/LogoPlateso.png��6F    � WindowStartupLocation$ CenterScreen=�6{    � AllowsTransparency .  � WindowStyle$
 None=�6�   $	��550��6�   $	��600��6�   ��6�   Z� .��5      � -   5        $��gridRoot��5      .+�5   
   �� ���#CFCECF �� CornerRadius$ 15��6&   � 5
   
   -   5        $��
gridLayout��5
      $��	0,9.3,0,0q�6!    � RowDefinitions 5      �� 5      $��0.16* �6    �� 5      $��0.84* �6    .+�5      � -   5        $��gridTop��5         gradient_top#��[  6"   $��0��6    5      �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   �� 5      .+�5      �� -   5        $��stackWindowStateButtons��5   q   $��0��6   $��0,0,10,0q�6*    �� Orientation$ 
Horizontal=�6<   $��RightToLeft=�6U   .+�5      �� -   5        $��
buttonExit��5        button_common#��[ 6/     template_button#��[ 6o   $��23��6�   $��23��6�   $��1q�6�   $��Center=�6�   $��Center=�6�   $��0,0,0,0q�6  ��5      �� 5      $��15��6$   $��15��60   $,��&pack://application:,,,/Images/exit.png��6;   5      �� 5      ��6    ��  �� Path$ Width�	 �� Mode$	 OneWay=�  TextBlockWidth
 �� Source#
 [ �� 5!      -   5        $��buttonMaximize��5!      #���  6P   #���  6x   $��23��6�   $��23��6�   $��1q�6�   $��Center=�6�   $��Center=�6�   $��0,0,0,0q�6  ��5"      �� 5#      $��15��6$   $��15��60   $0��*pack://application:,,,/Images/maximize.png��6;   5%      �� 5'      ��6    �� $ Width�$	 OneWay=�#
 [ �� 5)      -   5        $��buttonMinimize��5)      #��[ 63   #��[ 6Z   $��23��6�   $��23��6�   $��1q�6�   $��Center=�6�   $��Center=�6�   $��0,0,0,0q�6  ��5*      �� 5+      $��15��6$   $��15��60   $0��*pack://application:,,,/Images/minimize.png��6;   5-      5.      �� 50      -	   5        $��textblockTitle��50      $��Plateso��62   $��1��6A   $	��Top=�6N   $��Center=�6f   $��25(�6�   $��Normal"�6�   $��0,0,0,2q�6�   �� 52      -
   5        $��svTopButtons��52      $��2��63   $��Stretch=�6@   $��Stretch=�6\   $
��Auto=�6z   $
��Auto=�6�   .��54      �� -   5        $��stackTopButtons��54   !   $ 
Horizontal=�68   $��LeftToRight=�6Q   $��40,0,0,0q�6m   .+�55      �� -   5        $��
buttonHome��55   !     style_MainButtons#���  63   #���  6_    � ToolTip$
 Home��6�   .��56      �� $-��'pack://application:,,,/Images/home2.png��6`   ��6$   �� $ Height���6C   �� $ Width�6`   57      �� 59      ��6$   �� $ Width�$	 OneWay=�  WidthBetweetTopButtons#
 [ �� 5;      -   5        $��buttonUpload��5;   !   #��[ 65   #��[ 6`   $ Upload documents��6�   ��5<      �� 5=   "   $2��,pack://application:,,,/Images/doc_upload.png��6d   ��6(   �� $ Height���6G   �� $ Width�6d   5?      �� 5A      ��6$   �� $ Width�$	 OneWay=�#
 [ �� 5C      -   5        $��buttonDownload��5C   !   $ Download documents��67   #���  6T   #���  6�   ��5D      �� 5E   "   $4��.pack://application:,,,/Images/doc_download.png��6d   ��6(   �� $ Height���6G   �� $ Width�6d   5G      �� 5I      ��6$   �� $ Width�$	 OneWay=�#
 [ �� 5K      -   5        $��buttonDelete��5K   !   $ Delete��65   #���  6F   #���  6r   .��5L      �� $3��-pack://application:,,,/Images/doc_delete2.png��6`   ��6$   �� $ Height���6C   �� $ Width�6`   5M      �� 5O      ��6$   �� $ Width�$	 OneWay=�#
 [ �� 5Q      -   5        $��butGDocs��5Q   !   $ Google Documents��61   #���  6L   ��5R      �� 5S   "   $3��-pack://application:,,,/Images/google_docs.png��6d   ��6(   �� $ Height���6G   �� $ Width�6d   5U      �� 5W      ��6$   �� $ Width�$	 OneWay=�#
 [ �� 5Y      -   5        $��butPatternSearch��5Y   f   $ Pattern search��6!   #���  6:   ��5Z      �� 5[   "   $6��0pack://application:,,,/Images/pattern_search.png��6d   ��6(   �� $ Height���6G   �� $ Width�6d   5]      �� 5_      ��6$   �� $ Width�$	 OneWay=�#
 [ �� 5a      -   5        $��butEditDistance��5a   M   #���  6!    5b      �� 5d   "   Minimum edit distance�� 5e   <   �� 5f   &   $
��Bold"�60   Tip :6I   97 The edit distance between two strings of characters is�� 5g   &   <:the number of operations required to transform one of them�� 5h   a   into the other.5j   #   ��5n      �� 5o   "   $5��/pack://application:,,,/Images/edit_distance.png��6d   ��6(   �� $ Height���6G   �� $ Width�6d   5q      �� 5s      ��6$   �� $ Width�$	 OneWay=�#
 [ �� 5u      -   5        $��butComparison��5u   M   #���  6!   $ Compare documents��6~   .��5v      �� $2��,pack://application:,,,/Images/comparison.png��6`   ��6$   �� $ Height���6C   �� $ Width�6`   5w      5y      5{      5|      � 5�      -   5        $��gridMiddleRoot��5�       $��1��6    � ColumnDefinitions 5�      �� 5�      $
��0.2* �6'   �� 5�      $
��0.8* �6'   .+�5�      R� -   5        $��tvRoot��5�      $��0��6)     TreeViewBackgroundBrush#���  69   
������ $��0q�6�   .@�5�      Q� -   5        $��tvDocuments��5�   #   $��	Documents��66    Q� 
IsExpanded . $��0,10,5,5q�6[   Q� 5�      -   5        $��	tvResults��5�   #   $��Results��64    . $��0,5,5,5q�6W   5�      � 5�      -   5        $��gridContentHost��5�   '   $��1��6     gridContentHost_Background#���  6>   .+�5�      �� -   5        $��textCentral��5�   f   $��Center=�6    $��Center=�6;   $��60(�6X   $
��Wrap=�6y    �� TextAlignment$ Center=�6�   	Welcome5�      �� 5�      -   5        $��svTextViewer��5�   �   $y�Hidden=�6#   $
��Auto=�67   $��Disabled=�6Z   $��Stretch=�6�   $��Stretch=�6�     MainWindowCentralBackground#���  6�   5�      5�      �� 5�      $��0��6   $��Stretch=�6/   $��Right=�6K   $��2��6g   
������ 6q   5�      �� 5�      $��0��6   $��Bottom=�6(   $��Stretch=�6C   $��2��6a   $��0,0,0,-2q�6l    J� Opacity$ 0Q�6~   5�      n� 5�   
   -   5        $��topThumb��5�      $��2��6     � Cursor$ SizeNS��6+   $��5,0,5,-2q�6;   $	��Top=�6M   $��Stretch=�6e   $ 0Q�6�   6�   n� 5�   
   -   5        $��buttomThumb��5�      $��5��6#   $ 0Q�6.   $ SizeNS��6:   $��0,0,0,-3q�6J   $��Bottom=�6\   $��Stretch=�6w   6�   n� 5�   
   -   5        $��	leftThumb��5�      $��5��6!   $ 0Q�6+   $��Stretch=�67   $
��Left=�6S   $��-3,0,0,0q�6n   $ SizeWE��6�   6�   n� 5�   
   -   5        $��
rightThumb��5�      $��5��6"   $ 0Q�6,   $��Stretch=�68   $��Right=�6T   $��0,5,-3,0q�6p   $ SizeWE��6�   6�   5�      5�      