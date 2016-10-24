# ShoppingListApi

## Setting up the Database

I used Code First to generate a local database, so in order to run it you just need to open the solution and it should create the first migration to you.

If the local database is not created automatically, just open the Package Manager Console, change the Default Project to DAL and run the following command:
Update-Database -StartUpProjectName "ShoppingListApi" -Force -Verbose

## Accessing the API

There're two Controllers, one to access and change the Items in the Shopping List and another to access the Products.
The API works with two possible routes:
 - api/controller/id/
 - api/controller/action/
 
The Product controller has:
 - Get: return all products (is possible to pass skip and take parameters for pagination);
 - GetById: return one product
 
The ShoppingList controller has:
 - Get: returns all items (is possible to pass skip and take parameters for pagination);
 - GetById: return one item
 - Insert: receives an item, creates a new register on the database and returns the same item with the Id;
 - Update: receives an item, updates the register on the database and returns a bool;
 - Delete: receives an id, deletes the register on the database and returns a bool;
 - GetByCustomer: returns all items from a customer (is possible to pass skip and take parameters for pagination);
 - GetByProduct: returns all items from a product (is possible to pass skip and take parameters for pagination);
 
