   M S B A M L   `   `   `  ����@  <PLWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:PLWPFPLWPF  5   	       PLWPF.UpdateChildWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:PLWPF     5   	     � Title$  UpdateChildWindow��5   	   $	��350��6#   $	��525��60   $��20(�6<   .��5	      � -   5         �Name$ grid1��5	      $��3q�6    � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $��3q�6   $��0��6)   $��	Child ID:��69   �� 5   
   -   5         ��Name$ childIDComboBox��5      $��0��6|   $��3q�6�   $��1��6�   ��6\   �� *	ChildID+6�   �� 5   
   $��1��6   $��3q�6   $��0��6)   $��Child Name:��69   �� 5   
   -   5         ��Name$ childNameTextBox��5      $��1��6�   $��3q�6�   $��1��6�   ��6-   �� *	ChildName+ �� Mode$ TwoWay=� �� NotifyOnValidationError .  �� ValidatesOnExceptions . 6�   �� 5   
   $��2��6   $��3q�6   $��0��6)   $��Date Of Birth:��69   (  "System.Windows.Controls.DatePicker  5   
   -   5        	  Name$	 dateOfBirthDatePicker��5      $��2��6�   $��3q�6�   $��1��6�   
   SelectedDate
 64   �� *DateOfBirth+$ TwoWay=� .  . 6�   �� 5   
   $��3��6   $��3q�6   $��0��6)   $��Is Spacial Needs:��69   �� 5   
   -   5         ��Name$ isSpacialNeedsCheckBox��5      $��3��63   $��3q�6@   $��1��6�   $�� ��6�    d� 	IsChecked 6K   �� *IsSpacialNeeds+$ TwoWay=� .  . 6�   �� 5   
   $��4��6   $��3q�6   $��0��6)   $��
Mother ID:��69   �� 5   
   -   5        $ motherIDTextBox��5      $��4��6�   $��3q�6�   $��1��6�   ��6,   �� *
MotherID+$ TwoWay=� .  . 6�   �� 5    
   -   5        $��
UpdateChid��5       $��Update��6$   $��1��65   $��3q�6F   $��5��6Q   6^   5!      5"      