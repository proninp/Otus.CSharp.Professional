-- Таблица "Products" (Продукты):
create table Products (
    ProductID bigserial primary key,
    ProductName varchar(100) not null,
    Description text,
    Price numeric(10, 2) not null default 0.0,
    QuantityOnStock int not null default 0 check (QuantityOnStock >= 0)
);

-- Таблица "Users" (Пользователи):
create table Users (
    UserID  bigserial primary key,
    UserName varchar(150) not null,
    Email varchar(254) unique check(email ~* '^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$'),
    RegistrationDate date not null default current_date
);


-- Таблица "Orders" (Заказы)
create table Orders (
    OrderID bigserial primary key,
    UserID bigint not null references Users(UserID) on delete restrict,
    OrderDate date not null default current_date,
    Status int not null
);


-- Таблица "OrderDetails" (Детали заказа)
create table OrderDetails (
    OrderDetailID bigserial primary key,
    OrderID bigint not null references Orders(OrderID) on delete cascade,
    ProductID bigint not null references Products(ProductID) on delete restrict,
    Quantity int not null default 0 check(Quantity >= 0),
    TotalCost numeric(10, 2) not null default 0.0
);