**Hur du använder API:et**

**Interest**
* **Get** api/Interest/Interests - Hämtar alla intressen som finns lagrade i databasen.
  

**Link**
* **Get** api/Link/Links - Hämtar alla länkar som finns lagrade i databasen.

  
  

**Person**
* **Get** api/Person/GetAllPersons - Hämtar alla personer som finns lagrade i databasen


* **Get** api/Person/GetInterest/{id} - Hämtar alla intressen som finns lagrade för den person var PersonId du skickar in.

* **Get** api/Person/GetLinksForPerson/{id}  - Hämtar alla länkar som finns lagrade för den person vars PersonId du skickar in.

* **Post** api/Person/AddNewInterestForPerson/{personId}/{interestId}  - Lägger till ett nytt intresse för en person genom att skicka med personId och interestId.

* **Post** api/Person/AddNewLinkForPerson/{personId}/{interestId}  - Lägger till en ny länk för en persons intresse. Skicka in personId och InterestId för att välja vilket intresse länken ska lagras på. Skriv sedan in URL:en i Request body.
