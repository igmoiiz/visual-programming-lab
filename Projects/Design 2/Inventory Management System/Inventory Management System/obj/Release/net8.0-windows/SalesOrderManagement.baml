   M S B A M L   `   `   `  ����   Inventory Management System6    0Inventory_Management_System.SalesOrderManagement   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml       � Title$  Sales Order Management��$	��600��$	��800��
�������.��� $��10q� � RowDefinitions �� $
��Auto ��� $��* �.+��� $��Sales Order Management��$��24(�$
��Bold"�
��� � �$��0,0,0,20q�$��Center=�$��2��� $��1�� � ColumnDefinitions �� $	��250 ��� $��* �.+��� $��0��$��	0,10,20,0q�.+��� $��Customer Name:���� -   $��CustomerNameTextBox��$��0,0,0,10q��� $��Order Status:���� -   $��OrderStatusComboBox��$��0,0,0,10q�.@��� $��Pending���� $��Shipped���� $��	Cancelled���� $��Total Amount:���� -   $��TotalAmountTextBox�� �� 
IsReadOnly$
 True��$��0,0,0,10q��� $��	Products:��$
��Bold"�$��0,10,0,5q��� -   $��ProductListView��$��0,0,0,10q� �� View �� .P��� $��
Product ID�� �� Width$	 100�� �� DisplayMemberBinding �� *	ProductID+�� $��Product Name��$	 150�� �� *Name+�� $��
Unit Price��$ 80�� �� *	UnitPrice+�� $��	Quantity:���� -   $��QuantityTextBox��$��0,0,0,10q��� -   $��Add Product��
��� � �
�������$	��100��$��0,10,0,0q��� -   $��Create Sales Order��
����  �
�������$	��150��$��0,10,0,0q��� $��1��$��	10,10,0,0q�.+��� $��Recent Sales Orders:��$
��Bold"�$��0,0,0,5q��� -   $��SalesOrderListView�� �� .P��� $��Order ID��$	 100�� �� *SalesOrderID+�� $��Customer��$	 150�� �� *CustomerName+�� $��
Order Date��$	 120�� �� *	OrderDate+�� $��Status��$	 100�� �� *Status+�� $��Total Amount��$	 100�� �� *TotalAmount+