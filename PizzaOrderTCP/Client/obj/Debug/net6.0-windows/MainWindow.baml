   M S B A M L   `   `   `  ����A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:ClientClient  5   	       Client.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:Client     5   	     � Title$  
MainWindow��5      $	��700��6   $	��600��6'   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $��2* �6   �� 5      $��3* �6    � RowDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      .+�5   
   �� $��Center=�6   $��40(�6/   $��2��6=    �� TextAlignment$ Center=�6Q   Order Pizza6u   �� 5   
   $��10q�6   $��Center=�6    $��30(�6;   $��1��6I   
Full Name:6b   �� 5   
   $��10q�6   $��Center=�6    $��30(�6;   $��2��6I   Phone:6^   �� 5   
   $��10q�6   $��Center=�6    $��30(�6;   $��3��6I   
Address:6`   �� 5   
   $��10q�6   $��Center=�6    $��30(�6;   $��4��6I   Pizza:6^   �� 5   
   -   5         ��Name$ fullNameTxtBox��5      $��1��6*   $��1��6:   $��10q�6G   $��Center=�6S   $��50��6u   $��20(�6�   �� 5   
   -   5        $ phoneTxtBox��5      $��1��6'   $��2��67   $��10q�6D   $��Center=�6P   $��50��6r   $��20(�6~   �� 5   
   -   5        $ addressTxtBox��5      $��1��6)   $��3��69   $��10q�6F   $��Center=�6R   $��50��6t   $��20(�6�   A� 5   
   $��4��6   $��1��6#    A� Columns$ 2��63   .+�5      �� -   5        $ 	pizzaName��5      $��10q�6)   $��Center=�65   $��50��6W   $��20(�6c   �� 5       -   5        $ 
pizzaCount��5       $��10q�6*   $��Center=�66   $��50��6X   $��20(�6d   5!      �� 5"   
   -   5        $��2��5"   *   $��5��6>   $��20(�6K   $
��Bold"�6Y   $	��300��6k   $��20q�6w   .��6�   ORDER6�   5#      5$      