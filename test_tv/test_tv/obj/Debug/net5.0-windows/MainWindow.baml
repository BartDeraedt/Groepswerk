   M S B A M L   `   `   `  ����B  >test_tv, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:test_tvtest_tv  5   	       test_tv.MainWindow   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:test_tv     5   	     � Title$  
MainWindow��5   	   $	��500��6   $	��800��6)    � 	Resources 5	         BoolToVisConverter  FocusVisual �� Property �� Value �� StrokeDashArray J� SnapsToDevicePixels  Button.Static.Background �� Color  Button.Static.Border  Button.MouseOver.Background  Button.MouseOver.Border  Button.Pressed.Background  Button.Pressed.Border  Button.Disabled.Background 	 Button.Disabled.Border 
 Button.Disabled.Foreground  ButtonStyle1 �� 
TargetType �� 
TargetType	 ��Name
 ��Name �� Triggers P� Property P� Value �� 
TargetName��%|  &	        &	      &	 �     &	 �     &	     &	 /    &	 R    &	 u    &	 �    &		 �    &	
 �    &	     7  7  7  �� 5
   
   6'   �� 5   
   .�5      ��  � �� 5      �� 5      .R�5      �� $��2q�6$   $	 1 2R�6/   $
 true��6E   $��1��6`   #��� ��6t   5      5      5      �� 5   
   $ 	#FFDDDDDD��6;   �� 5   
   $ 	#FF707070��67   �� 5   
   $ 	#FFBEE6FD��6>   �� 5   
   $ 	#FF3C7FB1��6:   �� 5   
   $ 	#FFC4E5F6��6<   �� 5   
   $ 	#FF2C628B��68   �� 5   
   $ 	#FFF4F4F4��6=   �� 5   
   $ 	#FFADB2B5��69   �� 5   
   $ 	#FF838383��6=   �� 5   
   " ��6%   .�5      ��  �@�FocusVisualStyle8   61   �� 5       � ��8  6+   �� 5        � ��8  6,   �� 5!       � ��# � ��6+   �� 5"       � ��$ 1q�60   �� 5#       � ��$ Center=�6;   �� 5$       � ��$ Center=�69   �� 5%       � ��$ 1q�6(   �� 5&       � �� 5'      �� 5(      " ��6&   .R�5)      �� $	 border��6!   #��z��61   #��z��6[   #��z��6�   $
 true��6�   ._�5*      �� $
 contentPresenter��6/   $|�False��6I   #��z��6[   #��z��6�   $
��True��6�   # z 6�   #��z��6  5+       5,      P� 5-       �@��IsDefaulted$
 true��6=   . �5.   "   �� $ border��6@   # � ��6T    � ��5/      51      53      54      55      .��56      � .+�57   
   �� $��/images/tv.jpg��6   $
��Fill=�6)   �� 58   
   -   5         ��Name$ txtblockChannelnr��58      $
��Left=�6/   $��
625,66,0,0q�6J   $y�	Collapsed=�6�   $
��Wrap=�6�   $	��Top=�6�   $��25��6�   $��80��6�   ��6^   �� *	Channel+ �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 59   
   -   5         ��Name$ 
lblChannel��59      $
��Ch: ��6%   $
��Left=�64   $��
594,62,0,0q�6O   $	��Top=�6c   $y�	Collapsed=�6{   �� 5:   
   -   5        $ 	lblSource��5:      $
��Left=�6d   $��
594,62,0,0q�6   $	��Top=�6�   $y�	Collapsed=�6�   ��6$   �� *Source+$ PropertyChanged=�6�   �� 5;   
   -   5         ��Name$ btnPower��5;      #��[ 6#   $��POWER��6I   $
��Left=�6Y   ���	#FFDDDDDD$��
66,412,0,0q�6�   $	��Top=�6�   $��20��6�   $��44��6�   �� 5<   
   -   5        $ txtblockVolume��5<      $
��Left=�6,   $��
625,96,0,0q�6G   $
��Wrap=�6�   $	��Top=�6�   $��25��6  $��80��6  ��6[   �� *Volume+$ PropertyChanged=�y�6�   �� *Power+ �� 	Converter# [  6  �� 5=   
   -   5        $ 	lblVolume��5=      $��Vol: ��6$   $
��Left=�65   $��
594,91,0,0q�6P   $	��Top=�6d   y�6|   �� *Power+# [  �� 5>   
   -   5        $ btnVolup��5>      $��+��6#   $
��Left=�6/   $��129,416,0,0q�6J   $	��Top=�6_   6w   �� 5?   
   -   5        $ 
btnVoldown��5?      $��-��6%   $
��Left=�61   $��129,436,0,0q�6L   $	��Top=�6a   $��12��6�   �� 5@   
   $
��Left=�6   $��127,405,0,0q�6/   $	��VOL��6D   $
��Wrap=�6O   $	��Top=�6c   $��8(�6{   �� 5A   
   -	   5        $ 	btnProgup��5A      $��^��6$   $
��Left=�60   $��149,416,0,0q�6K   $	��Top=�6`   6x   �� 5B   
   -
   5        $ btnProgdown��5B      $��v��6&   $
��Left=�62   $��149,436,0,0q�6M   $	��Top=�6b   $��12��6�   �� 5C   
   $
��Left=�6   $��147,405,0,0q�6/   $
��PROG��6D   $
��Wrap=�6P   $	��Top=�6d   $��8(�6|   �� 5D   
   -   5        $ 	btnSource��5D      $��SOURCE��6$   $
��Left=�65   ���	#FFDDDDDD$��
66,437,0,0q�6g   $	��Top=�6{   $��44��6�   $��11(�6�   �� 5E   
   -   5        $ btnSettings��5E      $��SETTINGS��6&   $
��Left=�69   ���	#FFDDDDDD$��
13,437,0,0q�6k   $	��Top=�6   $��48��6�   $��10(�6�   $��19��6�   �� 5F   
   $��0,10,437,184q�6   ��5G      �� 5H      .�5I      ��  � y�$ Hidden=�6;    �� Triggers 5J      ^� 5K       ^� 
Conditions 5L      �� 5M   "    �� Binding 6,   ��  �� Path$ Power� �� Value true6K   �� 5N   "    6,   �� $ Settings� true6N   .0�5P      ��  � y�$ Visible=�6C   5Q      5S      .+�5U      �� -   5         ��Name$ txtStartupchannel��5U       �� 	MaxLength$ 3��61   $
��Left=�6?   $��225,126,0,0q�6Z   $��2q�6�    �� TextWrapping$
 Wrap=�6�   $	��Top=�6  $��43��6  ��6o   �� *Startupchannel+$ PropertyChanged=�6  �� 5V      -   5        $ labstartupchannel��5V      $��StartupChannel��6/   $
��Left=�6H   $��129,121,0,0q�6c   $	��Top=�6x   �� 5W      -   5         ��Name$ 	ChkboxUse��5W      $��Use startup settings��6*   $
��Left=�6I   $��143,109,0,0q�6d   $	��Top=�6y    d� 	IsChecked 6�   �� *UseStartupsettings+$ PropertyChanged=��� 5X      -   5        $ labstartupvolume��5X      $��StartupVolume��6/   $
��Left=�6I   $��129,147,0,0q�6d   $	��Top=�6y   �� 5Y      -   5        $ txtStartupvolume��5Y      $ 2��60   $
��Left=�6>   $��225,150,0,0q�6Y   $��2q�6�   $
 Wrap=�6�   $	��Top=�6  $��43��6  ��6n   �� *Startupvolume+$ PropertyChanged=�6  �� 5Z      -   5         ��Name$ ComboboxSource��5Z      $
��Left=�60   $��225,175,0,0q�6�   $	��Top=�6�   $��71��6�    �� Text 6L   �� *Startupsource+$ PropertyChanged=�.@�5[      �� $��TV��6   �� 5\      $��HDMI1��6   �� 5]      $��HDMI2��6   5^      �� 5_      -   5        $ labstartupsource��5_      $��StartupSource��6.   $
��Left=�6H   $��129,171,0,0q�6c   $	��Top=�6x   5`      5a      5b      