create table Courses
( Id  int identity primary key,
  Name varchar(30) not null,
  Fee int default 0 not null,
  Duration int default 40 not null,
  Prereq  varchar(50)
)