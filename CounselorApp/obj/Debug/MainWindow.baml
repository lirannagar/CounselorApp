   M S B A M L   `   `   `  ����G  CCounselorApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:CounselorAppCounselorApp  5   	       CounselorApp.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   X TXceed.Wpf.Toolkit, Version=3.5.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5   	   :d2http://schemas.microsoft.com/expression/blend/2008  5   	   Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5   	   &localclr-namespace:CounselorApp  5   	     � WindowStartupLocation$  CenterScreen=�5	   	    � Title$ Log In ��5
   	   $��289.2��6   $��224.2��6(   .��5      � $��
0,0,0,-2.6q�6    � ColumnDefinitions 5   
   �� 5      �� 5      $��3* �6   .+�5   
   �� -   5         ��Name$ userNameLabel��5      $��
User name:��6'   $
��Left=�6<   $��	10,50,0,0q�6W   $	��Top=�6j   $��82��6�   $��2��6�   (  "Xceed.Wpf.Toolkit.WatermarkTextBox  5   
   -   5          Name$ UserNameText��5          	Watermark$ Type username��66   $
��Left=�6P   $��28��6k   $��	14,73,0,0q�6w    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $	��175��6�   $��2��6�   �� 5   
   -   5        $ passwordLabel��5      $��	Password:��6'   $
��Left=�6;   $��
12,101,0,0q�6V   $	��Top=�6j   $��2��6�   ,  &Xceed.Wpf.Toolkit.WatermarkPasswordBox  5   
   -   5          Name$ PasswordText��5   $   $ Type password��6:   $
��Left=�6T   $��
14,124,0,0q�6o   $	��Top=�6�   $	��175��6�   $��29��6�   $��2��6�   �� 5   
   -   5         ��Name$ LogInButton��5      $��Log In��6&   $
��Left=�67   $��9.6,208,0,0q�6R   $	��Top=�6g   $��75��6   $��1��6�   6�   �� 5   
   -   5        	 ��Name$	 RoleComboBox��5      $
��Left=�6)   $��
14,158,0,0q�6D   $	��Top=�6X   $	��175��6p   $��2��6|   .@�5      �� 
 �� 
IsSelected
 . $��Choose role��6-   �� 5      $��Regular User��6   �� 5      $��Security adviser��6   �� 5      $��Master��6   5      �� 5   
   -   5        $ 
ErrorLebal��5      $�� ��6$   $
��Left=�6/   $��	37,19,0,0q�6J   $	��Top=�6]   $��2��6u   $	��133��6�   $��9(�6�   $
��Bold"�6�   $y�	Collapsed=�6�   
���  ��6�   5      5      