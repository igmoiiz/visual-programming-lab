   M S B A M L   `   `   `  ����  Inventory Management System/    )Inventory_Management_System.ReorderAlerts   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Reorder Alerts��5   	   $	��600��6    $	��800��6-   ���#D2B48C.��5      � .+�5   
   �� $��20q�6   .+�5      �� $��Reorder Alerts��6   $��24(�6.   $
��Bold"�6<   
��� � �$��0,0,0,20q�6a   �� 5	      $��Low Stock Alerts��6   $��18(�60   $
��Bold"�6>   
��� � �$��0,10,0,5q�6c   &   System.Windows.Controls.DataGrid  5
      -   5          Name$ LowStockDataGrid��5
         AutoGenerateColumns$ False��61   $	��200��6M   $��0,0,0,20q�6Z      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Product Name��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6X   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6?   �� *Name+6X     5      $ Current Quantity��6)   $ * 6`    6C   �� *
Quantity+6`     5      $ Minimum Level��6)   $ * 6]    6@   �� *
MinLevel+6]     5      $ Supplier��6)   $ * 6\    6;   �� *SupplierName+6\   5      �� 5      $��Reorder Suggestions��6   $��18(�63   $
��Bold"�6A   
��� � �$��0,10,0,5q�6f   �� 5      -   5         ��Name$ ReorderSuggestionsListBox��5      $	��150��69   $��0,0,0,20q�6F   
�������6X   �� 5      -   5        $��Generate Reorder Report��5      
��� � �
�������$	��200��6�   $��0,0,0,10q�6�   �� 5      -   5         ��Name$ StatusTextBlock��5      
��� � �$��0,20,0,0q�6D   5      5      5      