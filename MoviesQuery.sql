create table Movie(
id int not null identity(1,1),
language varchar(100),
location varchar(100),
plot varchar(max),
poster varchar(256),
soundeffects varchar(256),
imdbid varchar(50),
title varchar(100) not null,
listingtype int,
imdbrating float
)
drop table Movie
drop table Stills
drop table Users
drop table booking
drop table MovieStills

create table Stills(id int not null identity(1,1),stillurl varchar(200) not null)
create table MovieStills(id int not null identity(1,1), movieid int,StillId int not null)
create table Users(id int not null identity(1,1), username varchar(50) not null,password varchar(50) not null)
create table booking(id int not null identity(1,1),userid int not null,movieid int not null,location varchar(50) not null,tickets int not null)

insert into Movie(Language,Location,Plot,Poster,SoundEffects,imdbID,Title,listingType,imdbRating) values('English','Delhi','Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of common decency.',
'https://m.media-amazon.com/images/M/MV5BMDFkYTc0MGEtZmNhMC00ZDIzLWFmNTEtODM1ZmRlYWMwMWFmXkEyXkFqcGdeQXVyMTMxODk2OTU@._',
'RX6,SDDS','tt0111161','The Shawshank Redemption',4,9.2)

insert into Movie(Language,Location,Plot,Poster,SoundEffects,imdbID,Title,listingType,imdbRating) values('English','Mumbai','A historian races to find the legendary Templar Treasure before a team of mercenaries.',
'https://m.media-amazon.com/images/M/MV5BMTY3NTc4OTYxMF5BMl5BanBnXkFtZTcwMjk5NzUyMw@@._V1_.jpg_',
'RX6,SDDS','tt0368891','National Treasure',4,6.9)

insert into Movie values('Hindi','Kolkata','A couple from Chandni Chowk aspire to give their daughter the best education and thus be a part of and accepted by the elite of Delhi.',
'https://m.media-amazon.com/images/M/MV5BY2E4NWQ4ZjEtNThlOC00NThjLThmZjgtMWU0MDgzMmYwOGU3XkEyXkFqcGdeQXVyODE5NzE3OTE@._V1_.jpg','RX6,SDDS','tt5764096','Hindi Medium',3,7.9)

insert into Stills(stillURL)values
('https://m.mediaamazon.com/images/M/MV5BNTYxOTYyMzE3NV5BMl5BanBnXkFtZTcwOTMxNDY3Mw@@._V1_UY99_CR24,0,99,99_AL_.jpg'),
('https://m.mediaamazon.com/images/M/MV5BNzAwOTk3MDg5MV5BMl5BanBnXkFtZTcwNjQxNDY3Mw@@._V1_UY99_CR29,0,99,99_AL_.jpg'),
('https://m.media-amazon.com/images/M/MV5BMDFkYTc0MGEtZmNhMC00ZDIzLWFmNTEtODM1ZmRlYWMwMWFmXkEyXkFqcGdeQXVyMTMxODk2OTU@._')

select * from Users

insert into MovieStills values(1,1),(1,2),(1,3)

select * from Stills
update Stills set stillURL='https://m.media-amazon.com/images/M/MV5BNzAwOTk3MDg5MV5BMl5BanBnXkFtZTcwNjQxNDY3Mw@@._V1_UY99_CR29,0,99,99_AL_.jpg' where Id=2
update Stills set stillURL='https://m.media-amazon.com/images/M/MV5BNTYxOTYyMzE3NV5BMl5BanBnXkFtZTcwOTMxNDY3Mw@@._V1_UY99_CR24,0,99,99_AL_.jpg' where Id=1