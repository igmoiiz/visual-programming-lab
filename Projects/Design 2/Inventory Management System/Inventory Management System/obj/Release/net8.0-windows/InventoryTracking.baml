   M S B A M L   `   `   `  ����   Inventory Management System3    -Inventory_Management_System.InventoryTracking   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml       � Title$  Inventory Tracking��$	��600��$	��800��
�������.��� $��10q� � RowDefinitions �� $
��Auto ��� $��* �.+��� $��Inventory Tracking��$��24(�$
��Bold"�
��� � �$��0,0,0,20q�$��Center=�$��2��� $��1�� � ColumnDefinitions �� $	��250 ��� $��* �.+��� $��0��$��	0,10,20,0q�.+��� $��Select Product:���� -   $��ProductComboBox��$��0,0,0,10q��� $��Stock Levels by Location:��$
��Bold"�$��0,10,0,5q��� -   $��LocationStockListView��$��0,0,0,10q� �� View �� .P��� $��Location�� �� Width$	 100�� �� DisplayMemberBinding �� *LocationName+�� $��Quantity��$ 80�� �� *
Quantity+�� $��Batch/Serial Tracking:��$
��Bold"�$��0,10,0,5q��� -   $��BatchSerialListView�� �� .P��� $��Batch Number��$	 100�� �� *BatchNumber+�� $��Serial Number��$	 100�� �� *SerialNumber+�� $��Quantity��$ 80�� �� *
Quantity+�� $��1��$��	10,54,0,0q�.+��� $��Recent Stock Movements:��$
��Bold"�$��0,0,0,5q��� -   $��StockMovementListView�� �� .P��� $
��Date��$	 120�� �� *MovementDate+�� $��Product��$	 150�� �� *ProductName+�� $��Movement Type��$	 100�� �� *MovementType+�� $��Quantity��$ 80�� �� *
Quantity+�� $��Description��$	 200�� �� *Description+