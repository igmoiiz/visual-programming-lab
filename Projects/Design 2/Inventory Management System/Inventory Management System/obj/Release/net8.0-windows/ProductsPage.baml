   M S B A M L   `   `   `  ����   Inventory Management System.    (Inventory_Management_System.ProductsPage   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml       � Title$  Products Management��$	��450��$	��600��
�������.��� $��10q� � RowDefinitions �� $
��Auto ��� $��* �.+��� $��Product Management��$��24(�$
��Bold"�
��� � �$��0,0,0,20q�$��Center=�$��2��� $��1�� � ColumnDefinitions �� $	��200 ��� $��* �.+��� $��0��$��
0,52,338,0q�$��2��.+��� $��Product Name:���� -   $��ProductNameTextBox��$��0,0,0,10q��� $
��SKU:���� -   $��
SKUTextBox��$��0,0,0,10q��� $��	Category:���� -   $��CategoryTextBox��$��0,0,0,10q��� $��	Quantity:���� -   $��ProductQuantityTextBox��$��0,0,0,10q��� $��Unit Price:���� -   $��UnitPriceTextBox��$��0,0,0,10q��� $��Barcode:���� -   $��BarcodeTextBox��$��0,0,0,10q�� $��0,10,0,0q� �� $��* ��� $��* ��� $��* �.+��� -   $	��Add��
��� � �
�������$��5q�$��0���� -   $
��Edit��
����  �
�������$��5q�$��1���� -	   $��Delete��
���  ��
�������$��5q�$��2���� -
   $��ProductListView��$��1��$��	47,52,0,0q� �� View �� .P��� $��ID�� �� Width$ 50�� �� DisplayMemberBinding �� *Id+�� $
��Name��$	 150�� �� *Name+�� $	��SKU��$	 100�� �� *SKU+�� $��Category��$	 100�� �� *
Category+�� $��Quantity��$ 80�� �� *
Quantity+�� $��
Unit Price��$ 80�� �� *	UnitPrice+�� $��Barcode��$	 100�� �� *	Barcode+