   M S B A M L   `   `   `  ����L  HMathFightFrontEnd, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:MathFightFrontEnd.ViewsMathFightFrontEnd.Views  5   	   K*clr-namespace:MathFightFrontEnd.ViewModelsMathFightFrontEnd.ViewModels  5   	   I)clr-namespace:MathFightFrontEnd.ConverterMathFightFrontEnd.Converter  5   	   "    MathFightFrontEnd.MainWindow   5   	   /Views%clr-namespace:MathFightFrontEnd.Views  \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @	ViewModel*clr-namespace:MathFightFrontEnd.ViewModels     5   	   @
converters)clr-namespace:MathFightFrontEnd.Converter     5   	     � Title$!  Math Fight (Blueberry team)��5   	   $	��350��6-   $	��525��6:    � 
ResizeMode$ NoResize=�6F    � WindowStartupLocation$ CenterScreen=�5   	    � WindowState$ 	Maximized=�6.    � DataContext 5      /   )MathFightFrontEnd.ViewModels.AppViewModel  5	   
    � 	Resources 5       �� DataType=   7MathFightFrontEnd.ViewModels.LoginRegisterFormViewModel3   -MathFightFrontEnd.Views.LoginRegisterFormView4   .MathFightFrontEnd.ViewModels.MainMenuViewModel*   $MathFightFrontEnd.Views.MainMenuView<   6MathFightFrontEnd.ViewModels.SingleplayerGameViewModel2   ,MathFightFrontEnd.Views.SingleplayerGameView;   5MathFightFrontEnd.ViewModels.MultiplayerGameViewModel1	   +MathFightFrontEnd.Views.MultiplayerGameView;
   5MathFightFrontEnd.ViewModels.PlayMultiplayerViewModel1   +MathFightFrontEnd.Views.MultiplayerPlayView5   /MathFightFrontEnd.ViewModels.HighscoreViewModel+   %MathFightFrontEnd.Views.HighscoreView4   .MathFightFrontEnd.ViewModels.SettingsViewModel*   $MathFightFrontEnd.Views.SettingsView<   6MathFightFrontEnd.ViewModels.ChooseDifficultyViewModel2   ,MathFightFrontEnd.Views.ChooseDifficultyView;   5MathFightFrontEnd.Converter.BoolToVisibilityConverter   boolToVisibilityConverter��%u  (��       5      *, +)(�� 2     5      *, +)(�� d     5      *, +)(�� �     5      *, +)(�� �     5      *,
 +)(�� �     5      *, +)(�� ,    5      *, +)(�� ^    5!      *, +)&	  �    �� 5   
   "  6   .R�5        5      �� 5   
   "  6   .R�5        5      �� 5   
   "  6   .R�5        5      �� 5   
   "  6   .R�5      	  5      �� 5   
   " 
 6   .R�5        5      �� 5   
   "  6   .R�5        5      �� 5   
   "  6   .R�5        5       �� 5!   
   "  6   .R�5"        5#        5$   
   6/   5%      .��5&      � .+�5(   
   ]� .+�5)      ]� -   5        $��HeaderContainer��5)   -   $	��Top=�6   ���#0D2620.+�5+      ��  �� Orientation$ 
Horizontal=�6   $
��Left=�5,      y�5-      ��  �� Path$ LoggedInUser�	 �� 	Converter#	 [  .+�5.      �� ��6#   �� *
ViewModels+��5/      �� 50      .R�51   "   �� $ 
Horizontal=�6-   52      ��54      �� 55      .R�56   "   �� $��5q�59   )   $��5q�5:   )   $��Century Gothic)�5;   )   
�������$��Center=�5=   )   ��56   )   �� *Name+��57   )   �� $! DataContext.ChangeViewModel�
 �� RelativeSource
 ��  �� AncestorType" ���58   )   �� ��5>   &   �� 5?   *    �� Color$ 	#FF67869C��6:   5A   #   5B      5D      �� 5E      $��5q�5F      $��5q�5G      $��Century Gothic)�5H      
�������$��Center=�5J      ��5E      �� *Logout+��5K      �� 5L      $ 	#FF67869C��6.   .��5M   -   Logout5O      5P      �� 5Q       �� TextAlignment$ Right=�5R      ���#0D2620
������� �� Padding$ 5q�5U      
Username: �� 5W      $
��Bold"�6    ��62   �� *
Username+5X      5Y      ]� 5Z      ���#26997E��.  $	��Top=�6C   .+�5[      �� $ 5q�5\      $��Center=�5]      $
��Left=�5^      
�������$��Segoe WP Black)�5_   (   $��48(�6D   	MathFight5a      �� 5b      $ 5q�5c      $��Segoe WP Light)�5d      $��10(�5e      
�������$��Bottom=�5g      $��Right=�5h      �� 5i      $�(v 1.0)��6   5j      5k      �� 5l      $��Bottom=�6   ��5m      �� *CurrentViewModel+5o      5p      5q      