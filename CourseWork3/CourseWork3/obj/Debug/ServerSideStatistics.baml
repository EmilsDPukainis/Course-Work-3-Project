   M S B A M L   `   `   `  ����F  BCourseWork3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:CourseWork3CourseWork3  5   	   7 clr-namespace:CourseWork3.ModelsCourseWork3.Models  61   &     CourseWork3.ServerSideStatistics   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:CourseWork3     5   	   3models clr-namespace:CourseWork3.Models     61     � Title$  ServerSideStatistics��5   	   $	��360��6&   $��623.5��63   .��5      � .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ StatisticGrid2��5      $	��255��6+   $��172,43,68,0q�68   $	��Top=�6M      CanUserAddRows .     AutoGenerateColumns .  ��6�   �� *
UserData+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$
 Date��6%   -   5        Date��   CanUserResize .     
IsReadOnly .    CanUserReorder .  	   CanUserSort	 .  
   Width5  /System.Windows.Controls.DataGridLengthConverter$
 90 5   �   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6A   ��  �� Path$
 Date�   HeaderStyle 5      �� 5       �� 
TargetType=  7System.Windows.Controls.Primitives.DataGridColumnHeader"  6    .�5      ��  �� Property � �� �� Value$ Center=�6K   5         ElementStyle 5      �� 5      " ��6    .�5      ��  �@��TextAlignment$ Center=�6>   5      5        5      $ Entered��6%   -   5        TimeEntered�� .   .  .  	 .   5   6   �� $ TimeEntered� 5      �� 5      "  6    .�5      ��  � ��$ Center=�6K   5       5       �� 5!      " ��6    .�5"      ��  �@��TextAlignment$ Center=�6>   5#      5%        5&      $ 
TimeExited��6%   -   5        
TimeExited�� .   .  .  	 .   5&   9   �� $ 
TimeExited� 5'      �� 5(      "  6    .�5)      ��  � ��$ Center=�6K   5*       5,      �� 5-      " ��6    .�5.      ��  �@��TextAlignment$ Center=�6>   5/      51        52      $ Total hours��6%   -   5        
TotalHours�� .   .  .  	 .   52   :   �� $ 
TotalHours� 53      �� 54      "  6    .�55      ��  � ��$ Center=�6K   56       58      �� 59      " ��6    .�5:      ��  �@��TextAlignment$ Center=�6>   5;      5=        5>      $ Status��6%   -   5        
Status�� .   .  .  	 .  $
 80 5>   �    6E   �� $ Status� 5?      �� 5@      "  6    .�5A      ��  � ��$ Center=�6K   5B       5D      �� 5E      " ��6    .�5F      ��  �@��TextAlignment$ Center=�6>   5G      5I      5K        5L   
   -   5        $ StatisticGrid1��5L       .   .  $
��Left=�6   $	��309��6�   $��0,10,0,0q�6�   $	��Top=�6�   ��6+   �� *
UserData+ 5M      4  .System.Windows.Controls.DataGridTemplateColumn  5N      $ Select a Name��6)   $	
 110 6@    5O      �� 5P      "  6    .�5Q      ��  � ��$ Center=�6K   5R         CellTemplate 5T      �� 5U      .R�5V      �� -   5        $��Center=�5V   %   $��Center=�6I   ��5W   %   �� *
FullName+6B   5X      5Z      5\      �� 5]   
   $��Worktime��6   $
��Left=�6#   $��25��6>   $��
183,18,0,0q�6J   $��Center=�5^      $��Center=�64   $	��Top=�6V   $	��358��6n   5_      5`      