   M S B A M L   `   `   `  ����A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:ClientClient  5   	   =#clr-namespace:Client.CustomControlsClient.CustomControls  5   	       Client.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:Client     5   	   _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   ,uc#clr-namespace:Client.CustomControls  5   	     � WindowStartupLocation$  CenterScreen=�5
   	      MaterialDesignBody#���   5   	   $��Regular"�5   	   $��13(�5   	   &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	    � Title$ 	Messanger��5   	   $	��600��6   $	��900��6(    � 	Resources 5        PinkNeonOutline �� 
TargetType �� Property �� Value  RoundedButtonStyle ��Name	 �� CornerRadius��%�  &	       &	 �     �� 5   
   " ��6(   .�5      ��  � ��$ 3q�60   �� 5       � �� �#AA00FF6,   �� 5       �@��CornerRadius$ 20��6-   5      �� 5   
   " ��6+   .�5      ��  � �� 5      �� 5      .R�5      �� $ border��6!   ���#9C27B0$	 20��5   !   ._�5!      �� $
��SEND��6(   #���   5"   (   $��Center=�5#   (   $��Center=�5$   (   $��20(�5%   (   $��Black"�5&   (   5'      5-      5/      50      51      .��52      �� ._�53   
   � 
 � ColumnDefinitions
 54      �� 55      $��3* �6#   �� 56      $��1* �6#   .+�58      �� $��1��6   $	 20, 0, 0, 20��59      ��5:      �� 5;       �� 
StartPoint$
 0, 0&�6*    �� EndPoint$
 1, 1&�6<   .��5<      �  � Color$ #9C27B0��6'    � Offset$ 0Q�67   � 5=      $ #4A148C��6'   $
 0.95Q�67   5>      ._�5@      ]� $��10q�6   .+�5A      ��  �� TextAlignment$ Center=�6    $��
Montserrat)�5B       #���   5C       $��30(�5D       $��Light"�5E       $	��Top=�5F       	MEMBERS5H      �� 5I      #��[ 6    �� Padding$ 5q�5J      ._�5K      �� ��6"   �� *ChatMembers+5L      5M      5N      ]� 5O      $��10q�6   .+�5P      ]� $��Bottom=�6   .+�5Q      �� $
��SEND��6   $��Right=�5R      $��20(�5S      $
��Bold"�5T      $��10 0 0 0q�5U      $	��100��5V      $��40��5W       �� 	IsDefault$
 True��5X      ��5Y      �� *SendMessage+�� 5Z      #��[ 6   ._�5[      �� $��40��5\   "   $��0q�5]   "   #���  5^   "   #���   5_   "   $��25(�5`   "   $
��Bold"�5a   "   $��5 5 0 0q�5b   "   ��5[   "   �� *CurrentMessage+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�5b   "   5c      5d      �� 5f      $
��0 10q�6   #��[ 5g      ._�5h      �� ��6   �� *
Messages+5i      5j      5k      5l      5m      