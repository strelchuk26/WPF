   M S B A M L   `   `   `  ����A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:ClientClient  5   	   =#clr-namespace:Client.CustomControlsClient.CustomControls  5   	       Client.RegisterWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:Client     5   	   _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   8customcontrols#clr-namespace:Client.CustomControls  5   	      MaterialDesignBody#���   5
   	   $��Regular"�5   	   $��13(�5   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignFont#���  5   	    � Title$ Register��5   	   $	��600��6   $	��500��6'    � WindowStartupLocation$ CenterScreen=�5   	    � WindowStyle$
 None=�5   	    � AllowsTransparency$
 True��5   	   
������  � 
ResizeMode$ NoResize=�5   	   .��5      �� -   5         �� CornerRadius$ 20��5      $��5q�6   ��5   
   �� 5       �� Color$ #AA00FF��6   ��5   
   �� 5      	 �� 
StartPoint$
	 0, 0&�6"   
 �� EndPoint$

 1, 1&�64   .��5      �  � Color$ #9C27B0��6    � Offset$ 0Q�6/   � 5      $ #4A148C��6   $
 0.95Q�6/   5      ._�5    
   �� $��30q�6   .+�5!      �� $��REGISTER��6   $��
Montserrat)�5"      #���   5#      $��45(�5$      $��Light"�5%       �� TextAlignment$ Center=�5&      $��0 0 0 0q�5'      �� 5)      $��Username��6   #���  5*      #���   5+      $��30(�5,      $��
UltraLight"�5-      $��0 30 0 0q�5.      �� 50      -   5         ��Name$ userNameTxtBox��50      #���  52      #���   53      
�������$��
0, 0, 0, 1q�55      $
��Bold"�56      $��15(�57      $��0 10 0 0q�58      ��51      �� *
Username+ �� Mode$ OneWayToSource=� �� UpdateSourceTrigger$ PropertyChanged=�58      �� 5:      $��Password��6   #���  5;      #���   5<      $��30(�5=      $��
UltraLight"�5>      $��0 30 0 0q�5?      /   )Client.CustomControls.BindablePasswordBox  5A      $��30��5B   1   $��0 10 0 0q�5C   1      Password 5A   1   �� *
Password+$ OneWayToSource=�$ PropertyChanged=�5C   1   �� 5E      $��Email��6   #���  5F      #���   5G      $��30(�5H      $��
UltraLight"�5I      $��0 30 0 0q�5J      �� 5L      -   5        $ emailTxtBox��5L      #���  5N      #���   5O      
�������$��
0, 0, 0, 1q�5Q      $
��Bold"�5R      $��15(�5S      $��0 10 0 0q�5T      ��5M      �� *Email+$ OneWayToSource=�$ PropertyChanged=�5T      ]� 5V      $��0 60 0 0q�6   $��False��6*   .+�5W      �� $��ENTER��6   #���  5X      $��Light"�5Y      $	��275��5Z      $��70��5[      $��30(�5\      $
��Left=�5]       �� 	IsDefault$
 True��5^      ��5_      �� *RegisterCommand+�� 5a      $��CLOSE��6   #���  5b      $��Light"�5c      $	��130��5d      $��70��5e      $��20(�5f      $��Right=�5g       �� IsCancel$
 True��5h      ��5i      �� *CloseCommand+5j      5k      5l      5m      