-- Powered By SQLServer

create database blog;
use blog;

create table [User](

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


create table[Role](

    [Id] int not null identity(1,1),
    [Name] varchar(80) not null,
    [Slug] varchar(80) not null, 

    constraint [PK_Role] primary key ([Id]),
    constraint [UQ_Role_Slug] unique([Slug])
)
create nonclustered index [IX_Role_Slug] on [Role] ([Slug])


create table[Category](

    [Id] int not null identity(1,1),
    [Name] varchar(80) not null,
    [Slug] varchar(80) not null, 

    constraint [PK_Category] primary key ([Id]),
    constraint [UQ_Category_Slug] unique([Slug])
)
create nonclustered index [IX_Category_Slug] on [Category] ([Slug])

create table[Post](

    [Id] int not null identity(1,1),
    [CategoryId] int not null,
    [AuthorId] int not null,
    [Title] varchar(160) not null,
    [Summary] varchar(255) not null,
    [Body] text not null,
    [Slug] varchar(80) not null,
    [CreateData] datetime not null default (getdate()),
    [LastUpdate] datetime not null default (getdate()), 

    constraint [PK_Post] primary key ([Id]),
    constraint [FK_Post_Category] foreign key ([CategoryId]) references [Category]([Id]),

)
create nonclustered index [IX_Post_Slug] on [Post] ([Slug])

create table[Tag](

    [Id] int not null identity(1,1),
    [Name] varchar(80) not null,
    [Slug] varchar(80) not null, 

    constraint [PK_Tag] primary key ([Id]),
    constraint [UQ_Tag_Slug] unique([Slug])
)
create nonclustered index [IX_Tag_Slug] on [Tag] ([Slug])

create table [PostTag](
    [PostId] int not null,
    [TagId] int not null,

    constraint PK_PostTag primary key( [PostId], [TagId] )

)