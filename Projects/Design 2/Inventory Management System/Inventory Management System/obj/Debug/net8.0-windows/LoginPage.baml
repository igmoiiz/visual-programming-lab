   M S B A M L   `   `   `  ����V  RInventory Management System, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:Inventory_Management_SystemInventory_Management_System  5   >   +    %Inventory_Management_System.LoginPage   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      ;local)clr-namespace:Inventory_Management_System     6>     N� Title$  Login��5       N� 
Background �#D2B48C � 	Resources 5      =   7Inventory_Management_System.LengthToVisibilityConverter   LengthToVisibilityConverter��%   &	          5   
   6,   5      .��5	      � $��20q�6   .+�5
   
   ��  �� CornerRadius$ 10��6   
������� �� Padding$ 20q�66    J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         Color$
 Gray��6#      
BlurRadius$ 10Q�60      ShadowDepth$ 5Q�6@   ._�5      �� .+�5      �� $��Welcome Back!��6   $��24(�61   $
��Bold"�6?   $��0,0,0,20q�6Q   $��Center=�6c   �� 5      .+�5      � .+�5      �� -   5        	 ��Name$	 txtUsername��5   "   $��0,0,0,10q�67   $��40��6I   �� 5      $��Username��6$   
�������$��Center=�6F   $��5,0,0,0q�6a   
 J� IsHitTestVisible$
 False��6r   y�5   $   ��  �� ElementName$ txtUsername�� �� Path$ Text.Length� �� 	Converter# [  5      � 5      .+�5      G� -   5         G�Name$ txtPassword��5   &   $��0,0,0,10q�6;   $��40��6M   �� 5      $��Password��6$   
�������$��Center=�6F   $��5,0,0,0q�6a   $
 False��6r   y�5   $   �� $ txtPassword��$ Password.Length�# [  5      5      �� 5      -   5        $��Login��5      $��0,20,0,0q�6=   $��40��6O   ���#8B4513
�������$
��Bold"�6�   �� 5       $*��$Don't have an account? Click here to��6   $��0,20,0,0q�6H   $��Center=�6Z   �� 5!      -   5        $��Sign Up��5!      
����  � � Cursor$
 Hand��6=   $��Center=�6n   5"      5#      5$      5%      