   M S B A M L   `   `   `  ����E  AAsciiImage, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:AsciiImage
AsciiImage  5   	   9!clr-namespace:AsciiImage.ControlsAsciiImage.Controls  60       AsciiImage.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:AsciiImage     5   	   6controls!clr-namespace:AsciiImage.Controls     60   -   5          J� 	AllowDrop  . $
��1200��5   	   $	��600��6    � AllowsTransparency .  � WindowStyle$
 None=�5	   #    � WindowStartupLocation$ CenterScreen=�66    � Title$ 
MainWindow��5
   	    � 	Resources 5         style_border_1 �� 
TargetType �� Property �� Value	 �� Triggers
 P� Property P� Value  style_border_2��%�  &	        &	 �     �� 5   
   " ��6'   .�5      ��  � �� �#3333336+   	 5      P� 5      
 �@J�IsMouseOver .  . �5      ��  � �� 63   Z� 6F   5      5      �� 5   
   " ��6'   .�5      ��  � �� �	#FF4D4D4D6+   �� 5       �@��CornerRadius$ 0��6-   	 5      P� 5      
 �@J�IsMouseOver . . �5      ��  � �� �#3333336E   5      5      5      ��5      �� 5   
   6   .��5"      �� ���	#FF4D4D4D$��1q�6&   ���	#FF1F1F1F._�5#   
   � .+�5$      �� -   5         ��Name$ labell��5$      $��
Drop image��6$   
�������$��48(�6L   $��Center=�6Z   $��Center=�6~   6�      AsciiImage.Controls.DGrid  5%      $	��Top=�6   $��25��65      Alpha$ 1Q�6C   .+�5&      ��  �� Orientation$ 
Horizontal=�6   $
��Left=�66   .+�5'      �� -   5        $ name_program��5'      
�������$��name program��6F   6_   5(      �� 5)      $ 
Horizontal=�6   $��Right=�68   $	��Top=�6T   .+�5-      �� -   5         ��Name$ minim��5-      #��[  6,   $��35��6T   $��25��6_   $��Stretch=�6k   ._�5.         AsciiImage.Controls.DFIcon     IconID$	 ��6*   $��11(�6<   $��Center=�5/   *   $��Center=�50   *   ���	#FF999999$��Stretch=�51   *   $��Stretch=�6H   $��0,0,0,0q�52   *   54      �� 55      -   5        $ maxim��55      #��[  6,   $��35��6T   $��25��6_   $��Stretch=�6k   ._�56        $	 ��6*   $��11(�6<   $��Center=�57   *   $��Center=�58   *   ���	#FF999999$��Stretch=�59   *   $��Stretch=�6H   $��0,0,0,0q�5:   *   5<      �� 5=      -   5        $ closeim��5=      #��[  6.   $��35��6V   $��25��6a   $��Stretch=�6m   ._�5>        $	 ��6*   $��14(�6<   $��Center=�5?   *   $��Center=�5@   *   ���	#FF999999$��Stretch=�5A   *   $��Stretch=�6H   $��0,0,0,0q�5B   *   5D      5E      5G      � 5H      $��	0,30,0,30q�6    � ColumnDefinitions 5I      �� 5J      $��2* �6'   �� 5K      $��2* �6'   .+�5M      �� -   5         ��Name$ image_a_��5M       �� StretchDirection$
 Both=�6*   $��Uniform=�6B   6V   �� 5N      -   5        $ image_d_��5N      $
 Both=�6*   $��Uniform=�6B   $��1��6T   6f   5P      �� 5Q      -	   5        $ border_resize��5Q      $��10��6,   $��10��67   $��Right=�6C   $��Bottom=�6_   $��	0,0,-1,-1q�6z   ���	#02FFFFFF6�   �� 5R      -
   5        $ save_to_txt��5R      #��[  6*   $��25��6S   $��Bottom=�6_   $
��Left=�6z   ._�5S      �� $��Save to text��6   $��14(�6/   $��Center=�5T   *   $��Center=�5U   *   ���	#FF999999$��Stretch=�5V   *   $��Stretch=�6H   $��0,0,0,0q�5W   *   $��5,0,5,0q�6<   5Y      5Z      5[      5\      