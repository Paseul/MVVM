   M S B A M L   `   `   `  ���� ?  ;MVVM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:MVVM.ViewModelMVVM.ViewModel      MVVM.View.AmpVoltage   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     .localclr-namespace:MVVM.ViewModel       � Title$  
AmpVoltage��$	��420��$	��260�� � WindowStartupLocation$ CenterScreen=� � DataContext ��    Locator �� Source# [   �� Path$ 
AmpVoltage� � 	Resources )  #MVVM.ViewModel.BoolGrayRedConverter  BoolGrayRedConverter)  #MVVM.ViewModel.BoolLimeRedConverter  BoolLimeRedConverter��%   &	       &	          .��� 
�������.+��� $	��PA1��$
��Left=�$	��Top=�$	��125��$
��Bold"�$��	10,22,0,0q�$��18(�$��24����Z� �� $	��PA2��$
��Left=�$	��Top=�$	��125��$
��Bold"�$��	10,62,0,0q�$��18(�$��24����Z� �� $	��PA3��$
��Left=�$	��Top=�$	��125��$
��Bold"�$��
10,101,0,0q�$��18(�$��24����Z� �� $��PA4-1��$
��Left=�$	��Top=�$	��125��$
��Bold"�$��
10,144,0,0q�$��18(�$��24����Z� �� $��PA4-2��$
��Left=�$	��Top=�$	��125��$
��Bold"�$��
10,184,0,0q�$��18(�$��24����Z� �� $��PA4-3��$
��Left=�$	��Top=�$	��125��$
��Bold"�$��
10,221,0,0q�$��18(�$��24����Z� �� $��PA4-4��$
��Left=�$	��Top=�$	��125��$
��Bold"�$��
10,260,0,0q�$��18(�$��24�� J� RenderTransformOrigin$ 0.483,0.153&���Z� �� $��PA4-5��$
��Left=�$	��Top=�$	��125��$
��Bold"�$��
10,300,0,0q�$��18(�$��24����Z� �� $��PA4-6��$
��Left=�$	��Top=�$	��125��$
��Bold"�$��
10,339,0,0q�$��18(�$��24����Z� �� -    ��Name$ pa1VoltageLow��$	��Low��$
��Left=�$	��Top=�$��56��$
��Bold"�$��
112,26,0,0q����� *Pa1VoltageLow+ �� 	Converter# [ ��Z� 	 J� Effect	 3  -System.Windows.Media.Effects.DropShadowEffect  
   
BlurRadius$
 10Q�   ShadowDepth$ 5Q��� -   $ pa2VoltageLow��$	��Low��$
��Left=�$	��Top=�$��56��$
��Bold"�$��
112,66,0,0q����� *Pa2VoltageLow+# [ ��Z� 	   $
 10Q�$ 5Q��� -   $ pa3VoltageLow��$	��Low��$
��Left=�$	��Top=�$��56��$
��Bold"�$��112,106,0,0q����� *Pa3VoltageLow+# [ ��Z� 	   $
 10Q�$ 5Q��� -   $ pa4_1VoltageLow��$	��Low��$
��Left=�$	��Top=�$��56��$
��Bold"�$��112,148,0,0q����� *Pa4_1VoltageLow+# [ ��Z� 	   $
 10Q�$ 5Q��� -   $ pa4_2VoltageLow��$	��Low��$
��Left=�$	��Top=�$��56��$
��Bold"�$��112,188,0,0q����� *Pa4_2VoltageLow+# [ ��Z� 	   $
 10Q�$ 5Q��� -   $ pa4_3VoltageLow��$	��Low��$
��Left=�$	��Top=�$��56��$
��Bold"�$��112,225,0,0q����� *Pa4_3VoltageLow+# [ ��Z� 	   $
 10Q�$ 5Q��� -   $ pa4_4VoltageLow��$	��Low��$
��Left=�$	��Top=�$��56��$
��Bold"�$��112,265,0,0q����� *Pa4_4VoltageLow+# [ ��Z� 	   $
 10Q�$ 5Q��� -   $ pa4_5VoltageLow��$	��Low��$
��Left=�$	��Top=�$��56��$
��Bold"�$��112,304,0,0q����� *Pa4_5VoltageLow+# [ ��Z� 	   $
 10Q�$ 5Q��� -	   $ pa4_6VoltageLow��$	��Low��$
��Left=�$	��Top=�$��56��$
��Bold"�$��112,344,0,0q����� *Pa4_6VoltageLow+# [ ��Z� 	   $
 10Q�$ 5Q��� -
   $ pa1VoltageHigh��$
��High��$
��Left=�$	��Top=�$��56��$
��Bold"�$��
173,26,0,0q����� *Pa1VoltageHigh+# [ ��Z� 	   $
 10Q�$ 5Q��� -   $ pa2VoltageHigh��$
��High��$
��Left=�$	��Top=�$��56��$
��Bold"�$��
173,66,0,0q����� *Pa2VoltageHigh+# [ ��Z� 	   $
 10Q�$ 5Q��� -   $ pa3VoltageHigh��$
��High��$
��Left=�$	��Top=�$��56��$
��Bold"�$��173,106,0,0q����� *Pa3VoltageHigh+# [ ��Z� 	   $
 10Q�$ 5Q��� -   $ pa4_1VoltageHigh��$
��High��$
��Left=�$	��Top=�$��56��$
��Bold"�$��173,148,0,0q����� *Pa4_1VoltageHigh+# [ ��Z� 	   $
 10Q�$ 5Q��� -   $ pa4_2VoltageHigh��$
��High��$
��Left=�$	��Top=�$��56��$
��Bold"�$��173,188,0,0q����� *Pa4_2VoltageHigh+# [ ��Z� 	   $
 10Q�$ 5Q��� -   $ pa4_3VoltageHigh��$
��High��$
��Left=�$	��Top=�$��56��$
��Bold"�$��173,225,0,0q����� *Pa4_3VoltageHigh+# [ ��Z� 	   $
 10Q�$ 5Q��� -   $ pa4_4VoltageHigh��$
��High��$
��Left=�$	��Top=�$��56��$
��Bold"�$��173,265,0,0q����� *Pa4_4VoltageHigh+# [ ��Z� 	   $
 10Q�$ 5Q��� -   $ pa4_5VoltageHigh��$
��High��$
��Left=�$	��Top=�$��56��$
��Bold"�$��173,304,0,0q����� *Pa4_5VoltageHigh+# [ ��Z� 	   $
 10Q�$ 5Q��� -   $ pa4_6VoltageHigh��$
��High��$
��Left=�$	��Top=�$��56��$
��Bold"�$��173,344,0,0q����� *Pa4_6VoltageHigh+# [ ��Z� 	   $
 10Q�$ 5Q�