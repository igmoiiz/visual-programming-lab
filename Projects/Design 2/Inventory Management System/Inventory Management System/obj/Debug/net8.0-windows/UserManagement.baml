   M S B A M L   `   `   `  ����  Inventory Management System0    *Inventory_Management_System.UserManagement   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  User  Management��5   	   $	��600��6"   $	��800��6/   ���#D2B48C.��5      � .+�5   
   �� $��20q�6   .+�5      �� $��User  Management��6   $��24(�60   $
��Bold"�6>   ���#8B4513$��0,0,0,20q�6e   �� 5	      $��Add / Edit User��6   $��18(�6/   $
��Bold"�6=   ���#8B4513$��0,10,0,5q�6d   �� 5
       �� Orientation$ Vertical=�6   $��0,0,0,20q�60   .+�5      �� $��	Username:��6   �� 5      -   5         ��Name$ UsernameTextBox��5      $	��300��63   $��0,0,0,10q�6?   �� 5      $��	Password:��6   G� 5      -   5         G�Name$ PasswordBox��5      $	��300��63   $��0,0,0,10q�6?   �� 5      $��Role:��6   �� 5      -   5         ��Name$ RoleComboBox��5      $	��300��61   $��0,0,0,10q�6=   .@�5      �� $��Admin��6#   �� 5      $��Manager��6#   �� 5      $��Staff��6#   5      �� 5      $ 
Horizontal=�6   $
��Left=�66   .+�5      �� -   5        $��Add User��5      ���#8B4513
�������$	��100��6n   $��0,0,10,0q�6z   �� 5      -   5        $��Update User��5      
���   �
�������$	��100��6r   $��0,0,10,0q�6~   �� 5      -   5        $��Delete User��5      
���  ��
�������$	��100��6p   5      5      �� 5      $��
User  List��6   $��18(�6*   $
��Bold"�68   ���#8B4513$��0,10,0,5q�6_   &   System.Windows.Controls.DataGrid  5       -   5          Name$ UserDataGrid��5          AutoGenerateColumns$ False��6-   $	��200��6I   $��0,0,0,20q�6V      SelectionMode$ Single=�6h      SelectionUnit$ FullRow=�6   	   Columns	 5!      0  *System.Windows.Controls.DataGridTextColumn  5"      ,  &System.Windows.Controls.DataGridColumn
   Header$
 Username��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6X   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6;   �� *
Username+6X     5#      $

 Role��6)   $ * 6P    67   �� *Role+6P     5$      $
 
Created At��6)   $ * 6[    6=   �� *	CreatedAt+6[   5&      �� 5(      $��
Audit Logs��6   $��18(�6*   $
��Bold"�68   ���#8B4513$��0,10,0,5q�6_     5)      -   5        $ AuditLogDataGrid��5)      $ False��61   $	��200��6M   $��0,0,0,20q�6Z   	 5*        5+      $
 Action��6)   $ * 6T    69   �� *Action+6T     5,      $
 Table Affected��6)   $ * 6c    6A   �� *TableAffected+6c     5-      $
 Action Time��6)   $ * 6]    6>   �� *
ActionTime+6]   5/      50      51      52      