   M S B A M L   `   `   `  ����I  EMinh_WPF_C2_B1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:Minh_WPF_C2_B1Minh_WPF_C2_B1  5          Minh_WPF_C2_B1.ucUser   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:Minh_WPF_C2_B1     5        � 	Resources  5      ,   &Minh_WPF_C2_B1.StatusToStringConverter   statusToStringConverter��%   &	          5	   
   6(   5
      .��5      �  � RowDefinitions 5   
   �� 5      $��35 �6   �� 5      $��30 �6   �� 5      $	��565 �6   .+�5   
   �� $��0��6   .+�5      �� 
�������$��Center=�5      .��68   Manage User5      5      �� 5   
   $��1��6   $
��Left=�5      .+�5      �� -   5        $��btnAdd��5       
����� �$	��Add��5      $��50��5      $��30��5      $��10,0,0,0q�5      5!      5"      &   System.Windows.Controls.DataGrid  5#   
   -   5        $��dtgUser��5#      $	��210��5$      $
��Left=�5%      $��
10,10,0,10q�5&      $	��Top=�5'      $	��410��5(      $��2��5)         	RowHeight$ 30Q�5*         ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ 65 5+         AutoGenerateColumns .     
IsReadOnly .  �� DisplayMemberPath$ UserName��5.         Columns 5/      0  *System.Windows.Controls.DataGridTextColumn  50      ,  &System.Windows.Controls.DataGridColumn   Header$ 	UserName ��6%   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 51   %   �� *
UserName+
 �� UpdateSourceTrigger$
 PropertyChanged=�  52      $ Password��6%   	 53   %   �� *
Password+$
 PropertyChanged=�  54      $
 Role��6%      Width$ 40 55   %   	 56   %   �� *Role+  57      $ Status��6%   	 58   &   �� *Status+ �� 	Converter# [  4  .System.Windows.Controls.DataGridTemplateColumn  59      $
 Edit��6)      
IsReadOnly . $ 50 5;   )      CellTemplate 5<      �� 5=      .R�5>      �� $��btnEdit��5?   %   -   5        $
��Edit��5>   %   
����� �5A   %   5B      5D        5F      $
 Lock��6)    . $ 50 5H   )    5I      �� 5J      .R�5K      �� $��	btnDelete��5L   %   -   5        $
��Lock��5K   %   
����� �5N   %   5O      5Q        5S      $ UnLock��6)    . $ 50 5U   )    5V      �� 5W      .R�5X      �� $��	btnUnLock��5Y   %   -   5        $��UnLock��5X   %   
����� �5[   %   5\      5^      5a      5b      5c      