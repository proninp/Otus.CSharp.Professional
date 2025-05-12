-- Добавление нового продукта
insert into Products (ProductName, Description, Price, QuantityOnStock)
values ('Xiaomi G34 WQ', 'Xiaomi 34" Монитор G34 WQ / NEW версия C34WQBA-RG', 26000.00, 2);

-- Обновление цены продукта
update Products
set Price = 25998.00
where ProductID = 1;

-- Выбор всех заказов определенного пользователя
select OrderID
       , UserID
       , OrderDate
       , Status
from Orders
where UserID = 1;

-- Расчет общей стоимости заказа
select sum(TotalCost) as TotalCost
from OrderDetails
where OrderID = 1;

-- Подсчет количества товаров на складе
select sum(QuantityInStock) as TotalStock
from Products;

-- Получение 5 самых дорогих товаров
select ProductID
       , ProductName
       , Description
       , Price
       , QuantityOnStock
from Products
order by Price desc
limit 5;

-- Список товаров с низким запасом (менее 5 штук)
select * from Products
where QuantityInStock < 5;