   M S B A M L   `   `   `  ����   Inventory Management System9    3Inventory_Management_System.PurchaseOrderManagement   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Aav2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006       � Title$  Purchase Order Management��$	��600��$	��800��
�������.��� $��10q� � RowDefinitions �� $
��Auto ��� $��* �.+��� $��Purchase Order Management��$��24(�$
��Bold"�
��� � �$��Center=�$��2��$	��544��$	��Top=�� $��1�� � ColumnDefinitions �� $	��250 ��� $��* �.+��� $��0��$��	0,38,10,0q�.+��� $��Select Supplier:���� -    ��Name$ SupplierComboBox��$��0,0,0,10q��� $��Order Status:���� -   $ OrderStatusComboBox��$��0,0,0,10q�.@��� $��Pending���� $��	Completed���� $��	Cancelled���� $��Total Amount:���� -    ��Name$ TotalAmountTextBox�� �� 
IsReadOnly$
 True��$��0,0,0,10q��� $��	Products:��$
��Bold"�$��0,10,0,5q��� -    ��Name$ ProductListView��$��0,0,0,10q� �� View �� .P��� $��
Product ID�� �� Width$	 100��	 �� DisplayMemberBinding	 �� *	ProductID+�� $��Product Name��$	 150��	 �� *Name+�� $��
Unit Price��$ 80��	 �� *	UnitPrice+�� $��	Quantity:���� -   $ QuantityTextBox��$��0,0,0,10q��� -   $��Add Product��
��� � �
�������$	��100��$��0,10,0,0q��� -   $��Create Purchase Order��
����  �
�������$	��150��$��0,10,0,0q��� $��1��$��	10,50,0,0q�.+��� $��Recent Purchase Orders:��$
��Bold"�$��0,0,0,5q��� -   $ PurchaseOrderListView�� �� .P��� $��Order ID��$	 100��	 �� *PurchaseOrderID+�� $��Supplier��$	 150��	 �� *SupplierName+�� $��
Order Date��$	 120��	 �� *	OrderDate+�� $��Status��$	 100��	 �� *Status+�� $��Total Amount��$	 100��	 �� *TotalAmount+