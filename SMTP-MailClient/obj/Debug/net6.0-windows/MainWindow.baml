   M S B A M L   `   `   `  ����J  FSMTP-MailClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:SMTP_MailClientSMTP_MailClient  5   	        SMTP_MailClient.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:SMTP_MailClient     5   	     � Title$  
MainWindow��5   	   $	��650��6   $
��1000��6)   .��5	      ]� .+�5
   
   ]� $��Right=�6   $��10q�6+   $	��300��67   .+�5      �� $	��Top=�6    �� TextAlignment$ Center=�6-   $��20(�6D   Date:6Y   �� 5      -   5         ��Name$ msgDateTxtBlock��5   8   $	��300��6   $
��Wrap=�6$   $	��Top=�6Q   $ Center=�6f   $��15(�6}   
20.03.20236�   �� 5      $	��Top=�6   $ Center=�6-   $��20(�6D   From:6Y   �� 5      -   5        $��msgFromTxtBlock��5   8   $	��300��6   $
��Wrap=�6$   $	��Top=�6O   $ Center=�6d   $��15(�6{   dasdasd@gmail.com6�   �� 5      $	��Top=�6   $ Center=�6-   $��20(�6D   
Subject:6\   �� 5      -   5        $ msgSubjectTxtBlock��5   8   $	��300��6   $
��Wrap=�6$   $	��Top=�6T   $ Center=�6i   $��15(�6�   Important subject6�   �� 5      $	��Top=�6   $ Center=�6-   $��20(�6D   Text:6Y   �� 5      -   5         ��Name$ msgTextTxtBlock��5       �� 
IsReadOnly$
 True��6/   $��15(�6A   $	��300��6O    �� TextWrapping$
 Wrap=�6[   .��6o   ><Lordasdasemsdasddsadasasdadsadsdasdsfhgfghfghfghgfhffghfadas6�   5      ]� 5   
   $
��Left=�6   .+�5      �� $��Center=�6    �� Orientation$ 
Horizontal=�66   $	��Top=�6O   .+�5      �� -   5        $��10q�5      $	��200��6=   $��50��6I   .��6U   
SHOW ALL6_   �� 5      -   5        $��10q�5      $	��200��6C   $��50��6O   .��6[   DELETE6c   5      �� 5      -   5         ��Name$
 list��5   L   $��10q�6@   6L   5      5      5      