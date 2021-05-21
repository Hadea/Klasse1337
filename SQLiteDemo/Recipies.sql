create table Recipies (
    ID integer primary key autoincrement not null,
    Name varchar(40) unique not null check( length(Name) > 1),
    WaterReq tinyint not null default 0,
    CoffeeReq tinyint not null default 0,
    MilkReq tinyint not null default 0,
    
    constraint ccRecipies_MinUsage check (WaterReq + CoffeeReq + MilkReq > 0),
    constraint cuRecipies_ContainerRequirements unique(WaterReq,CoffeeReq, MilkReq)
);

insert into Recipies (Name, WaterReq, CoffeeReq, MilkReq) values
('Kaffee', 30,10,0),
('Kaffee Weiﬂ', 20,10,10),
('Capuchino', 10,15,20),
('Warme Milch', 0,0,20),
('Tee (Warmes Wasser)', 30,0,0);
