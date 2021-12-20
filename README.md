# TexasHoldEm
Having fun with c# .Net Poker. Simple game simulation

shufle based on shufle presented here:
https://www.geeksforgeeks.org/shuffle-a-deck-of-cards-3/

nuget library, will use in future to create some GUI
https://www.nuget.org/packages/Terminal.Gui/

TODO's:
klasa gra?
klasa układ?: lista na 7kart?
gra:
rundy: FLOP, TURN, RIVER
uproszczona wersja bezl icytacji


sprawdzanie układów jest największym problemem:
gracz może zarazem mieć parę, zarówno kolor czy coś takiego

klasa układ:
sprawdzCzyPoker
sprwadzCzyKolor

co jeśli dwa takie same układy?
karty zapisane w tablicy
jesli masz pare 2ek to jak odróżnić od pary króli

Description:
zacznijcie pisać coś w rodzaju programu do gry poker texas holdem

-6ciu uczestników
każdy dostaje po 2karty od 2 do asa (52 karty w talii)

następnie wykładane są 3 karty wspólne 
(flop)
potem jedna (turn)
i na koniec jedna (river)

na koniec program ma w stanie określić sam który z graczy ma najśilniejszy układ
pomijamy kwestie licytacji itd (wersja mocno uproszczona), cos jak prezentacja rozdania

np.
gracz 1 - 5 8
gracz 2 - A 10
...
gracz 6 - 7 7
następuje wyłożenie 3 kart wspólnych (flop) np.
5 2 A
potem jednej (turn)
5 2 A K
na koniec jeszcze jednej (river)
5 2 A K 8
na tym etapie program ma wskazać który z graczy ma najsilniejszy układ (kto wygrał)
nie uwzględniamy kolorów kart
powinniśmy uwzględnić że jeżeli jakaś karta została już wyłożona to jest o jedną mniej w puli


nie starajcie się tego zrobić szybko, 
najważniejsze jest przyswajanie wiedzy którą dostajecie na szkoleniach, 
to jest zadanie opcjonalne nad którym warto się pogłowić gdyż prezentuje ciekawe zagadnienia
