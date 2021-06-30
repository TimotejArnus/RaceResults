create table competitor(
id int primary key,
name varchar(50),
division varchar(50),
state varchar(50),
contry varchar(50),
profession varchar(50),
age_catagory varchar(50)
);

create table RezultatTekme(
id int primary key,
genderRank int,
divRank int,
overallRank int,
bib int,
points varchar(45),
swim time,
t1 time,
bike time,
t2 time,
run time,
overall time,
comments varchar(45),

constraint RezultatTekme_competitor foreign key(id) references competitor(id),
constraint RezultatTekme_Race foreign key(id) references Race(id)

);

create table Race(
id int primary key,
naziv varchar(45),
vrsta varchar(45),
swimDistance varchar(45),
bikeDistance varchar(45),
runDostance varchar(45)
);

// testiraj ........		.....		.....

/*

CREATE TABLE IF NOT EXISTS `Age_Category` (
  `id` INT NOT NULL Primary key AUTOINCREMENT,
  `age` INT NULL,
  `division` VARCHAR(45) NULL
);

CREATE TABLE IF NOT EXISTS competitor (
  `id` INT NOT NULL PRIMARY KEY,
  `name` VARCHAR(45) NULL,
  `division` VARCHAR(45) NULL,
  `state` VARCHAR(45) NULL,
  `contry` VARCHAR(45) NULL,
  `profession` VARCHAR(45) NULL,
  `Age_Category_idTekmovalec` INT NOT NULL,  
    FOREIGN KEY (`id`)
    REFERENCES Age_Category (`idTekmovalec`)
);


CREATE TABLE IF NOT EXISTS Race (
  `id` INT NOT NULL PRIMARY KEY AUTOINCREMENT,
  `vrsta` VARCHAR(45) NULL,
  `swimDistance` TINYINT NULL,
  `bikeDistance` TINYINT NULL,
  `runDistance` TINYINT NULL
);


CREATE TABLE IF NOT EXISTS RezultatTekme (
  `id` INT NOT NULL PRIMARY KEY AUTOINCREMENT,    
  `genderRank` INT NULL,
  `divRank` INT NULL,
  `overallRank` INT NULL,
  `bib` INT NULL,
  `points` VARCHAR(45) NULL,
  `swim` TIME NULL,
  `t1` TIME NULL,
  `bike` TIME NULL,
  `t2` TIME NULL,
  `run` TIME NULL,
  `overall` TIME NULL,
  `comment` VARCHAR(45) NULL, 
  
    FOREIGN KEY (`id`)
    REFERENCES competitor(`id`)
    
  
    FOREIGN KEY (`id`)
    REFERENCES Race(`id`)
   )
;