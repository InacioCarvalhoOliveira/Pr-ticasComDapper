-- Powered By SQLServer

create database blog;
use blog;
create table [Usuario](

    [Id]    int not null identity(1,1), -- increment 1 by one 
    [Name]  nvarchar(80) not null, -- nvarchar accept special caracteres 
    [Email] varchar(200) not null,
    [PasswordHash] varchar(255) not null,
    [Bio] text not null,
    [Image] varchar(200) not null,
    [Slug] varchar(50) not null, -- url segment

    constraint [PK_User] primary key([Id]),
    constraint [UQ_User_Email] unique([Email]), -- UQ means unique 
    constraint [UQ_User_Slug]  unique([Slug])
)
create nonclustered index [IX_User_Email] on [User]([Email]),
create nonclustered index [IX_User_Slug]  on [User]([Slug]),

select * from Usuario;