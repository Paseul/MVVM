   M S B A M L   `   `   `  ���� ?  ;MVVM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:MVVM.ViewModelMVVM.ViewModel      MVVM.View.TopView   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     .localclr-namespace:MVVM.ViewModel     c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  b ^GalaSoft.MvvmLight.Platform, Version=5.4.1.0, Culture=neutral, PublicKeyToken=5f873c45e98af8a1-Custom http://www.galasoft.ch/mvvmlight    � DataContext  �� *Top+   Locator �� Source# [   � 	Resources   NormalBrush �� EndPoint �� 
StartPoint � Color � Offset  redNormalBrush  PressedBrush  redPressedBrush  NormalBorderBrush  redNormalBorderBrush  BorderBrush  redBorderBrush 	 PressedBorderBrush 
 redPressedBorderBrush  SimpleButton �� 
TargetType �� BasedOn	 �� Property
 �� Value �� 
TargetType �Name ��Name �� Padding �� Triggers P� Property P� Value �� 
TargetName  	RedButton  TextBoxStyle1 ��Name J� SnapsToDevicePixels��%  &	       &	 P     &	 �     &	 $    &	 �    &	 �    &	 H    &	 �    &		 �    &	
 8    &	 �    7  7  7  7 	 &	 �    7  7  7  7 
 &	 �    �� $	 0,1&�$	 0,0&�.��� $
 #FFF��$	 0.0Q�� $
 #CCC��$	 1.0Q��� $	 0,1&�$	 0,0&�.��� $
 #F00��$	 0.0Q�� $
 #C00��$	 1.0Q��� $	 0,1&�$	 0,0&�.��� $
 #BBB��$	 0.0Q�� $
 #EEE��$	 0.1Q�� $
 #EEE��$	 0.9Q�� $
 #FFF��$	 1.0Q��� $	 0,1&�$	 0,0&�.��� $
 #B00��$	 0.0Q�� $
 #E00��$	 0.1Q�� $
 #E00��$	 0.9Q�� $
 #F00��$	 1.0Q��� $	 0,1&�$	 0,0&�.��� $
 #CCC��$	 0.0Q�� $
 #444��$	 1.0Q��� $	 0,1&�$	 0,0&�.��� $
 #C00��$	 0.0Q�� $
 #400��$	 1.0Q��� $	 0,1&�$	 0,0&�.��� $
 #CCC��$	 0.0Q�� $
 #444��$	 1.0Q��� $	 0,1&�$	 0,0&�.��� $
 #C00��$	 0.0Q�� $
 #400��$	 1.0Q��� $	 0,1&�$	 0,0&�.��� $
 #444��$	 0.0Q�� $
 #888��$	 1.0Q��� $	 0,1&�$	 0,0&�.��� $
 #400��$	 0.0Q�� $
 #800��$	 1.0Q��� " �� Z� .��� 	 � ��8
   �� 	 � ��8
  �� 	 � ��
 �� " ��.R�� $
 Grid��.+��� $ Border��#��z��#��z��#��z��# z���� #��z��#��z��#��z����.  P�  � �� . . ��� 8
  $ Border��	 � ���� 8
  $ Border��	 � ���� " �� Z� .��� 	 � ��8
   �� 	 � ��8
  �� 	 � ��
 �� " ��.R�� $
 Grid��.+��� $ Border��#��z��#��z��#��z��# z���� #��z��#��z��#��z����.  P�  � �� . . ��� 8
  $ Border��	 � ���� 8
  $ Border��	 � ���� " ��.��� 	 � ��
 �� " ��.R�� .+��� $ PART_ContentHost��# z $��2,2,1,1q��� ���	#FFBAB7B7$��0,0,1,1q�$��1,1,0,0q��� 
���   �$��1,1,0,0q�$
��Auto��.��� .+��� 
�������$��1q�._�� .+��� $
��Left=�$��	19,10,0,0q�$
��Wrap=�$��Laser Power (kW)��$	��Top=�$��24(�$
��Bold"��� $
��Left=�$��	19,47,0,0q� �� TextWrapping$
 Wrap=� �� TextAlignment$ Right=�$	��Top=�$	��141��$	��332�����	#FFD4D4D4$	��120(�$
��Bold"�#��[ {�.  ���� *Pd7+�� $
��Left=�$��
377,10,0,0q�$
��Wrap=�$��Coolant Temperature (℃)��$	��Top=�$��24(�$
��Bold"��� $
��Left=�$��
377,47,0,0q�$
 Wrap=�$ Right=�$	��Top=�$	��141��$	��332�����	#FFD4D4D4$	��120(�$
��Bold"�#��[ {�.  ���� *
PaTemp13+�� $
��Left=�$��
726,29,0,0q�$
��Wrap=�$��SEED Humidity (%)��$	��Top=�$��14(�$
��Bold"��� $
��Left=�$��
729,48,0,0q�$
 Wrap=�$ Right=�$	��Top=�$��60��$	��120�����	#FFD4D4D4$��48(�$
��Bold"�#��[ {�.  ���� *	SeedHumid+�� $
��Left=�$��733,109,0,0q�$
��Wrap=�$��PA Humidity (%)��$	��Top=�$��14(�$
��Bold"��� $
��Left=�$��729,128,0,0q�$
 Wrap=�$ Right=�$	��Top=�$��60��$	��120�����	#FFD4D4D4$��48(�$
��Bold"�#��[ {�.  ���� *	PaHumid+�� $
��STOP��$��1002,47,76,10q�$��24(�$
��Bold"�#��[ .  (System.Windows.Interactivity.Interaction   Triggers /  )System.Windows.Interactivity.EventTrigger     	EventName$ Click��.  (System.Windows.Interactivity.TriggerBase   Actions. /  )GalaSoft.MvvmLight.Command.EventToCommand     Command �� *OnClickCommand+�� $��RESET��$��870,128,208,10q�$��24(�$
��Bold"�#��[    $ Click��.    �� *OnResetCommand+�� -   $
��SAVE��$��870,47,208,91q�$��24(�$
��Bold"�#��[    $ Click��.    �� *OnClickCommand+