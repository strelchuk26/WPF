   M S B A M L   `   `   `  ����D  @SMTP-Mail, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:SMTP_Mail	SMTP_Mail  5   	       SMTP_Mail.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:SMTP_Mail     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      ]� .+�5
   
   � $	��Top=�6    � ColumnDefinitions 5      �� 5      $
��Auto �6#   �� 5      $��* �6#    � RowDefinitions 5      �� 5      $��40 �6    �� 5      $��40 �6    �� 5      $��40 �6    .+�5      �� $��Center=�6   $��0��66   $��0��6F   .��6S   To:6X   �� 5      -   5        $��toTxtBox��5      $��5q�6&   $��Center=�61   $��1��6S   $��0��6c   6r   �� 5      $��Center=�6   $��0��66   $��1��6F   .��6S   
Subject:6]   �� 5      -   5        $��subjectTxtBox��5      $��5q�6+   $��Center=�66   $��1��6X   $��1��6h   6w   �� 5      $��Center=�6   $��0��66   $��2��6F   .��6S   	Priority:6^   �� 5      -   5        $��priorityCmbBox��5      $��2��6-   $��1��6:   $��5q�6J   .@�5      �� .��6   Low5      �� 5       .��6   Normal5"      �� 5#      .��6   High5%      5&      5'      �� 5(   
   $	��Top=�6    �� TextAlignment$ Center=�6)   $
��Bold"�6@   $��32(�6R   Text6f   �� 5)   
   -   5        $��Bottom=�5)   &   $��8q�6>   $��20(�6J   $
��Bold"�6X   .��6j   Send6p   �� 5*   
   -   5        $��
bodyTxtBox��5*      $��5q�6$    �� TextWrapping$
 Wrap=�6/    �� AcceptsReturn$
 True��6C   6Z   5+      5,      