   M S B A M L   `   `   `  ����A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:ClientClient  5   	       Client.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:Client     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      �  � RowDefinitions 5
   
   �� 5      $��30 �6   �� 5      $��* �6   .+�5   
   ]� $��0��6   .+�5      �� $
��Bold"�6   .��6&   Name:6-   �� 5      -   5         ��Name$ 
nameTxtBox��5      $��16(�6*   $��Center=�68   $	��100��6Z   �� 5      $
��Bold"�6   .��6&   
Message:60   �� 5      -   5        $	��100��5   +   $��Right=�67   
���\\��.��6e   Leave6l   �� 5      -   5        $	��100��5   *   $��Right=�66   
������.��6e   Join6k   �� 5      -   5        $	��100��5   -   $��Right=�69   
����� �.��6f   Send6l   �� 5      -   5        $��	msgTxtBox��5   F   $��16(�6   $��Center=�6$   6Y   5      �� 5   
   -   5        $
��list��5      $��1��6   $��Stretch=�6+   5'      5(      5)      