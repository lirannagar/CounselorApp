   M S B A M L   `   `   `  ����G  CCounselorApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:CounselorApp.AdministratorCounselorApp.Administrator  5   	   -    'CounselorApp.Administrator.AddNewAdvice   5   	   X TXceed.Wpf.Toolkit, Version=3.5.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   :local(clr-namespace:CounselorApp.Administrator     5   	     � WindowStartupLocation$  CenterScreen=�5	   	    � Title$ Add New Security Advice��5
   	   $��540.93��6)   $��558.4��69   .��5      � .+�5   
   �� -   5         ��Name$ AddNameLabel��5      $��Name:��6(   $
��Left=�68   $��	20,48,0,0q�6S   $	��Top=�6f   �� 5   
   -   5        $ 	BodyLabel��5      $��Body:��6%   $
��Left=�65   $��	20,90,0,0q�6P   $	��Top=�6c   �� 5   
   -   5        $ WebServerProtectedLabel��5      $��Web Server Protected:��63   $
��Left=�6S   $��
20,450,0,0q�6n   $	��Top=�6�   �� 5   
   -   5        $ WebServerVulnerableLabel��5      $��Vulnerable Web Server:��64   $
��Left=�6U   $��
20,426,0,0q�6p   $	��Top=�6�   (  "Xceed.Wpf.Toolkit.WatermarkTextBox  5   
   -   5          Name$ NameTextBox��5          	Watermark$ Name Attack��65   $
��Left=�6M   $��	70,52,0,0q�6h   $	��Top=�6{   $	��154��6�   �� 5   
   -   5         ��Name$ VulnerableWebTextBox��5      $
��Left=�60   $��160,433,0,0q�6K   $	��Top=�6`   $	��218��6x   �� 5   
   -   5        $ ProtectedWebTextBox��5      $
��Left=�6/   $��160,457,0,0q�6J   $	��Top=�6_   $	��218��6w   �� 5   
   -   5         ��Name$ UploadVulnerableWebButton��5      $��Browse File��64   $
��Left=�6J   $��383,432,0,0q�6e   $	��Top=�6z   $��78��6�   6�   �� 5   
   -	   5        $ UploadProtectedWebButton��5      $��Browse File��63   $
��Left=�6I   $��383,456,0,0q�6d   $	��Top=�6y   $��78��6�   6�   �� 5   
   -
   5        $ 
UploadFile��5      $��Upload��6%   $
��Left=�66   $��160,480,0,0q�6Q   $	��Top=�6f   $	��301��6~   6�   �� 5   
   -   5         ��Name$ BodyTextBox��5      $
��Left=�6+   $	��304��6F   $��	70,90,0,0q�6S   $	��Top=�6f   $	��391��6~   . �5      /� .T�5      J� .*�6   .*�5      �� $� ��6   5      5      5      �� 5   
   -   5        $ LebalSourceAdvice��5      $��Source Advice:��6+   $
��Left=�6D   $��
21,399,0,0q�6_   $	��Top=�6s     5   
   -   5        $ SourceAdviceTextBox��5       $
��Left=�6>   $��23��6Y   $��161,405,0,0q�6e    �� TextWrapping$
 Wrap=�6z   $ 
URL Source��6�   $	��Top=�6�   $	��216��6�   �� 5    
   -   5        $ 
BackButton��5       $
��Back��6%   $
��Left=�64   $��	25,10,0,0q�6O   $	��Top=�6b   $��75��6z   6�   �� 5!   
   -   5        $ 
logInLebal��5!      $�� ��6$   $
��Left=�6/   $��
460,10,0,0q�6J   $	��Top=�6^   $��76��6v   $��9(�6�   $
��Bold"�6�   
��� � �6�   �� 5$   
   -   5        $ ErrorMSG��5$      $�� ��6"   $
��Left=�6-   $��
197,19,0,0q�6H   $	��Top=�6\   $	��133��6t   $��9(�6�   $
��Bold"�6�   $y�	Collapsed=�6�   
���  ��6�   5&      5'      