   M S B A M L   `   `   `  ����F  BCourseWork3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:CourseWork3CourseWork3  5   	   7 clr-namespace:CourseWork3.ModelsCourseWork3.Models  61       CourseWork3.ServerSide   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:CourseWork3     5   	   3models clr-namespace:CourseWork3.Models     61     � Left$  0��5   	   
 � Top$ 0��6    � Title$ 
ServerSide��5	   	   $��539.5��6   $��1154.5��6+    � WindowStartupLocation$ Manual=�6:   .��5      � $
��Left=�6   $
��1152��6&   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ Users��5         CanUserAddRows .     AutoGenerateColumns .  $	��356��6{   $��	0,143,0,0q�6�   $	��Top=�6�   $��14(�6�   ��6"   �� *NewUserLogins+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6%   -   5        Id��	   CanUserResize	 .  
   
IsReadOnly
 .    CanUserReorder .     CanUserSort .     Width5  /System.Windows.Controls.DataGridLengthConverter$ 25 5   �   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6>   ��  �� Path$ Id�   HeaderStyle 5      �� 5       �� 
TargetType=  7System.Windows.Controls.Primitives.DataGridColumnHeader"  6    .�5      ��  �� Property � �� �� Value$ Center=�5      5         ElementStyle 5      �� 5      " ��6    .�5      ��  �@��TextAlignment$ Center=�6>   5      5        5      $ 
First Name��6%   -   5        	FirstName��$	 200 5   j   	 .  
 .  .   .   6L   �� $
 Name� 5      �� 5      "  6    .�5       ��  � ��$ Center=�6K   5!       5#      �� 5$      " ��6    .�5%      ��  �@��TextAlignment$ Center=�6>   5&      5(        5)      $ 	Last Name��6%   -   5        LastName��$	 200 5)   k   	 .  
 .  .   .   6J   �� $ Surname� 5*      �� 5+      "  6    .�5,      ��  � ��$ Center=�6K   5-       5/      �� 50      " ��6    .�51      ��  �@��TextAlignment$ Center=�6>   52      54        55      $	 Job��6%   -   5        Job��$	 200 55   \   	 .  
 .  .   .   6?   �� $	 Job� 56      �� 57      "  6    .�58      ��  � ��$ Center=�6K   59       5;      �� 5<      " ��6    .�5=      ��  �@��TextAlignment$ Center=�6>   5>      5@      4  .System.Windows.Controls.DataGridCheckBoxColumn  5A      $ 
Checked in��6)   -   5        	CheckedIn��	 .   .   .   5A   Q   �� $ 	CheckedIn� 5B      �� 5C      " ��6    .�5D      ��  � ��$ Center=�6B   �� 5E       � ��$ Center=�6D   �� 5F       � {� .  6:    �� Triggers 5G      �� 5H   "    �� Binding 6.   �� $ 	CheckedIn� �� Value 16Q   .a�5I   &   ��  �@d�	IsChecked$
 TrueY�6B   5J   #   �� 5K   "    6.   �� $ 	CheckedIn� 06Q   .a�5L   &   ��  �@d�	IsChecked$ FalseY�6B   5M   #   5O      5Q        5R      $ Checked out��6)   -   5        
CheckedOut��	 .   .   .   5S      �� 5T      " ��6    .�5U      ��  � ��$ Center=�6B   �� 5V       � ��$ Center=�6D   �� 5W       � {� .  6:    5Y      �� 5Z   "    6.   �� $ 	CheckedIn� 06Q   .a�5[   &   ��  �@d�	IsChecked$
 TrueY�6B   5\   #   �� 5]   "    6.   �� $ 	CheckedIn� 16Q   .a�5^   &   ��  �@d�	IsChecked$ FalseY�6B   5_   #   5a      5c        5e      $
 Code��6%   -   5        Code��$ 45 5e   _   	 .  
 .  .   .   6A   �� $
 Code� 5f      �� 5g      "  6    .�5h      ��  � ��$ Center=�6K   5i       5k      �� 5l      " ��6    .�5m      ��  �@��TextAlignment$ Center=�6>   5n      5q        5r      $ Date entered(dd.mm.yyyy)��6%   -	   5        Date��$	 175 5r   s   	 .  
 .  .   .   6U   �� $
 Date� 5s      �� 5t      "  6    .�5u      ��  � ��$ Center=�6K   5v       5x      �� 5y      " ��6    .�5z      ��  �@��TextAlignment$ Center=�6>   5{      5~        5      $ Time entered(24h)��6%   -
   5        Time��	 .  
 .  .   .   5   N   �� $
 Time� 5�      �� 5�      "  6    .�5�      ��  � ��$ Center=�6K   5�       5�      �� 5�      " ��6    .�5�      ��  �@��TextAlignment$ Center=�6>   5�      5�      5�      �� 5�   
   -   5         ��Name$ 	addJobBox��5�      $
��Left=�6%   $��21��6@   $��	36,49,0,0q�6L    �� TextWrapping$
 Wrap=�6_   $	��Top=�6t   $	��170��6�   �� 5�   
   -   5         ��Name$ addJob��5�      $��Add Job��6!   $
��Left=�63   $��22��6N   $��	74,75,0,0q�6Z   $	��Top=�6m   $��84��6�   6�   �� 5�   
   -   5         ��Name$ JobBox2��5�      $��Center=�6$   $��21��6A   $��211,49,751,0q�6M   $	��Top=�6c   $	��170��6{    �� SelectedIndex$ -1��6�   .@�5�      �� {�.   �� 
IsSelected . .��6?   Select a job6M   5�      �� 5�   
   -   5        $��Reset Users��5�      $
��Left=�6'   $��25��6B   $��
993,45,0,0q�6N   $	��Top=�6b   $��90��6z   6�   �� 5�   
   -   5        $��Reset New Jobs��5�      $
��Left=�6*   $��25��6E   $��
993,74,0,0q�6Q   $	��Top=�6e   $��90��6}   6�   �� 5�   
   -   5        $ 
Statistics��5�      $��
Statistics��6%   $
��Left=�6:   $��27��6U   $��
585,46,0,0q�6a   $	��Top=�6u   $��88��6�   6�   5�      5�      