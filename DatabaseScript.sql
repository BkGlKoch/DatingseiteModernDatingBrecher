create Database modernDating;
use modernDating;
create table user(
idUser int primary key not null auto_increment,
nachname varchar(30),
vorname varchar(30),
geburtsdatum date,
geschlecht varchar(20),
beschreibung varchar(200),
username varchar(30),
password varchar(30) CHARACTER SET 'utf8mb4' COLLATE 'utf8mb4_0900_as_cs',
tinders int,
profilbild LONGBLOB
);



create table matches(
idMatch int primary key not null auto_increment,
idUser1 int,
FOREIGN KEY (idUser1) REFERENCES user(idUser),
idUSer2 int,
FOREIGN KEY (idUser2) REFERENCES user(idUser)
);


