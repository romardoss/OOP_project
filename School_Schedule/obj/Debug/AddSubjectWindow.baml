   M S B A M L   `   `   `  ????  School_Schedule&     School_Schedule.AddSubjectWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -   5          ? Title$  
New Lesson??5   	   $	??450??6   $	??800??6)    ? 	Resources 5
       ?? 
TargetType ?? Property ?? Value(  "System.Windows.Controls.DatePicker??%!  '??       '?? ?     '?? ?    '?? `    '  ?    '?? ?    ?? 5   
   " ??6   .?5      ??  ? ??
 ?????6+   ?? 5       ? ??$
 Bold"?6+   ?? 5       ?@??TextAlignment$ Center=?6.   ?? 5       ? ??$ Center=?62   ?? 5       ? ??$ 20(?6)   5      ?? 5   
   " ??6   .?5      ??  ? ??$ Center=?62   ?? 5       ? ??$	 120??6&   ?? 5       ? ?? ?#7e685a6+   ?? 5       ? ??$ Medium"?6+   ?? 5       ? ??$ 14(?6)   ?? 5       ? ??$ 0q?60   5      ?? 5   
   " ??6   .?5      ??  ? ??$ 60??6&   ?? 5       ?@??TextWrapping$ NoWrap=?6-   ?? 5       ? ??$ Center=?62   ?? 5       ? ??
 ?????6+   ?? 5       ? ?? ?#add2746+   ?? 5        ? ??$ Medium"?6+   ?? 5!       ? ??$ 14(?6)   ?? 5"       ? ??$ 0q?60   5#      ?? 5$   
   " ??6   .?5%      ??  ? ??$ Center=?62   ?? 5&       ? ??$ Center=?64   5'      ?? 5(   
   "  6   .?5)      ??  ? ??$ Center=?62   ?? 5*       ? ??$ Center=?64   ?? 5+       ? ??$ 0q?60   ?? 5,       ? ??$ 25??6'   ?? 5-       ? ??$	 100??6&   5.      ?? 5/   
   " ??6   .?50      ??  ? ??$ Center=?62   ?? 51       ? ??$ Center=?64   ?? 52       ? ??
 ?????6+   ?? 53       ? ?? ?#add2746+   ?? 54       ? ??$
 Bold"?6+   ?? 55       ? ??$ 14(?6)   ?? 56       ? ??$ 0q?60   57      58      .??59      ? ???#afd274.+?5:   
   ?? ???#7e685a$	??400??6'   $	??450??64   ?? 5;   
   $??28(?6   $??	0,0,0,200q?6"   ?? 66   $?Add new lesson??6:   6S   ?? 5<   
   $??0,0,200,100q?6   ?? 6*   $?Subject:??6.   6A   ?? 5=   
   $??
0,0,200,20q?6   ?? 6)   $?Teacher:??6-   6@   ?? 5>   
   $??
0,50,220,0q?6   ?? 6)   $?Time:??6-   6=   ?? 5?   
   $??	0,50,70,0q?6   ?? 6(   $
?from??6,   6;   ?? 5@   
   $??
169,50,0,0q?6   ?? 6)   $?to??6-   6:   ?? 5A   
   -   5         ??Name$ ChoseSubject??5A      $??100,0,0,100q?6)   ?? 5B   
   -   5        $ ChoseTeacher??5B      $??
100,0,0,20q?6)   ?? 5C   
   -   5         ??Name$ AddNewSubjectButton??5C      $??22??6.   $??28??6:   $??+??6E   $??Center=?6Q   $??14(?5D      $??270,0,0,100q?6   64   ?? 5E   
   -   5        $ AddNewTeacherButton??5E      $??22??6.   $??28??6:   $??+??6E   $??Center=?6Q   $??14(?5F      $??
270,0,0,20q?6   63   ?? 5G   
   -   5         ??Name$ 	StartTime??5G      $
??8:30??6%   $??	50,55,0,0q?61   ?? 5H   
   -   5        $ EndTime??5H      $
??9:15??6#   $??
260,55,0,0q?6/   ?? 5I   
   $??0,110,150,0q?6   ?? 6*   $?Day of week:??6.   6E   ?? 5J   
   -   5        $ ChoseDayOfWeek??5J      $??100,115,0,0q?6+   ?? 5K   
   $??0,170,120,0q?6   ?? 6*   $?One-time lesson??6.   6H   ?? 5L   
   -	   5         ??Name$ CheckBox??5L      $??
80,175,0,0q?6%   6T     5M   
   -
   5        	  Name$	 DateOfLesson??5M      $??0,230,175,0q?6+   {?.  6@   ?? 5N   
   -   5        $ CancelButton??5N      $??Cancel??6'   $	??100??68   $??25??6D   $??0,300,172,0q?6P   6e   ?? 5O   
   -   5        $ AcceptButton??5O      $??Accept??6'   $	??100??68   $??25??6D   $??220,300,0,0q?6P   6e   5Q      5R      