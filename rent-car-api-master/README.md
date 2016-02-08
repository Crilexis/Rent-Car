### Proposed Exercise: ###

The company BestCar Rental Services needs to provide a webapi with basic rental operations. A REST service must to be created based in the list of requirements below.

### Paths: ###

**Summary**
Return a list of all cars provided by company, this object can used as mock.

**[GET]** /cars

**Parameters**

N/A

**Responses**

200 - List of all company cars

---------------------------------

**Summary**
Return a list of all registered reservations.

**[GET]** /reservations

**Parameters**

N/A

**Responses**

200 - List of all registered reservations

---------------------------------

**Summary**
Makes new book with Car, Drive and Booking information.

**[POST]** /book

**Parameters**

Book - Located in body

**Responses**

200 - Book created

400 - Book cannot be empty (when book object is not informed)

404 - Selected car is not available (when informed car is not in company list) 

---------------------------------

**Summary**
Cancel an already created reservation.

**[DELETE]** /book/{bookReferenceNumber}/cancel

**Parameters**

bookReferenceNumber - Located in route

**Responses**

200 - Reservation has been canceled

400 - Book reference number is not valid (when there's no book with this reference)

---------------------------------

### Stack ###

* Microsoft ASPNet 5
* WebApi 2.1
* C# 6

### Aditional Information ###

* Kestrel must be used as host service
* Repository data can be stored in memory
* Must be created a unit test for api controller
* Set api default route as http://[ip]:[port]/ e.g localhost:80/book
* Dependency Injection must be used to fill api controller dependencies
* Json objects must to be Camel Case
* Json enumerables must to be handled as string
* Abstractions layer must be used as reference domain
