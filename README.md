# Zadanie 2

* Stwórz projekt WebApi i przełóż aplikację **FizzBuzz**. 
Logika **FizzBuzz** powinna serwować
fukcjonalność przez **REST**’a. 
Dobór metod **REST - POST/GET/PATCH** etc. 
powinien być zgodny z zasadami restful.
np. ***GET** /fizzbuzz&number=5.*

*  Jako drugi kontroler stwórz operacje na
zasobie “pokój konferencyjny”. 
Tzn:	
	* Dodawanie pokojów
	* Usuwanie pokojów
	* Edytowanie pokoju


* Stwórz drugi projekt WebApi w tej samej solucji, 
który *odpytuje* ten pierwszy o FizzBuzz
zwracając jego wartości.

Aplikacje można rozbudować o: 
* middleware, 
* logging 
* logowanie, 
* in memory database, 
* SQL database, 
* Dependency Injection.