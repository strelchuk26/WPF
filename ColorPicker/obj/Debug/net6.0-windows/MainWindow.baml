   M S B A M L   `   `   `  ����F  BColorPicker, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:ColorPickerColorPicker  5   	       ColorPicker.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:ColorPicker     5   	     � Title$  
MainWindow��5	   	   $	��450��6   $	��700��6)   .��5
      �  � RowDefinitions 5   
   �� 5      $��4* �6   �� 5      $��1* �6   �� 5      $��4* �6   .+�5   
   �  � ColumnDefinitions 5      �� 5      $��1* �6#   �� 5      $��4* �6#   �� 5      $��1* �6#   �� 5      $��2* �6#    5      �� 5      �� 5      �� 5      �� 5      .+�5      �� $��Center=�6   $��Center=�68   $��20(�6Z   $��0��6h   .��6u   A:6y   �� 5      $��Center=�6   $��Center=�68   $��20(�6Z   $��1��6h   .��6u   R:6y   �� 5      $��Center=�6   $��Center=�68   $��20(�6Z   $��2��6h   .��6u   G:6y   �� 5       $��Center=�6   $��Center=�68   $��20(�6Z   $��3��6h   .��6u   B:6y   �� 5!      -   5         ��Name$ alphaSlider��5!   >    � Minimum$ 0Q�6S    � Maximum$	 100Q�6_    �� TickFrequency$ 1Q�6m    �� IsSnapToTickEnabled$
 True��6   $��Center=�6�   $��10q�6�   $��1��6�   $��0��6�    � Value 6   �� 	 �� Path$	 CustomColor.Alpha�6�   �� 5"      -   5        $ 	redSlider��5"   <   $ 0Q�6O   $	 255Q�6[   $ 1Q�6i   $
 True��6{   $��Center=�6�   $��10q�6�   $��1��6�   $��1��6�    6   �� $	 CustomColor.Red�6�   �� 5#      -   5        $ greenSlider��5#   >   $ 0Q�6S   $	 255Q�6_   $ 1Q�6m   $
 True��6   $��Center=�6�   $��10q�6�   $��1��6�   $��2��6�    6   �� $	 CustomColor.Green�6�   �� 5$      -   5        $ 
blueSlider��5$   =   $ 0Q�6Q   $	 255Q�6]   $ 1Q�6k   $
 True��6}   $��Center=�6�   $��10q�6�   $��1��6�   $��3��6�    6   �� $	 CustomColor.Blue�6�   �� 5%      $��20(�6K   $��Center=�6Y   
 �� TextAlignment$
 Center=�6{   $��10q�6�   $��2��6�   $��0��6�   ��6   ��  �� ElementName$ alphaSlider��$	 Value�6�   �� 5&      $��20(�6I   $��Center=�6W   $
 Center=�6y   $��10q�6�   $��2��6�   $��1��6�   ��6   �� $ 	redSlider��$	 Value�6�   �� 5'      $��20(�6K   $��Center=�6Y   $
 Center=�6{   $��10q�6�   $��2��6�   $��2��6�   ��6   �� $ greenSlider��$	 Value�6�   �� 5(      $��20(�6J   $��Center=�6X   $
 Center=�6z   $��10q�6�   $��2��6�   $��3��6�   ��6   �� $ 
blueSlider��$	 Value�6�   �� 5)      $��10q�6   $��4��6!   $��3��62   ��5*      �� 5+       �� Color 6&   �� $	 CustomColor.Color�5-      5.      �� 5/   
   $��1��6    �� Orientation$ 
Horizontal=�6"   $��Center=�6;   .+�50      �� -   5         ��Name$ addBtn��50   =   ���#55C5FF
�������$	��100��6a   $��10q�6m   .��6y   ADD6~   �� 51      -   5        $ 	removeBtn��51   =   ���#55C5FF
�������$	��100��6g   $��10q�6s   .��6   REMOVE6�   52      �� 53   
   $��2��6w   $��
10 0 10 10q�6�   ��6   �� $	 Colors� �� SelectedItem 66   �� $	 SelectedColor� �� Mode$ OneWayToSource=�6�   54      55      