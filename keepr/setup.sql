USE keeprtimz;

CREATE TABLE profiles
(
  id VARCHAR(255) NOT NULL,
  email VARCHAR(255) NOT NULL,
  name VARCHAR(255),
  picture VARCHAR(255),
  PRIMARY KEY (id)
);

CREATE TABLE vault
(
  id INT NOT NULL AUTO_INCREMENT,
  creatorId VARCHAR(255) NOT NULL,
  name VARCHAR(255) NOT NULL,
  description VARCHAR(255) NOT NULL,
  isPrivate bit NOT NULL,

  PRIMARY KEY (id),

  FOREIGN KEY (creatorId)
   REFERENCES profiles (id)
   ON DELETE CASCADE
);

CREATE TABLE keep
(
   id INT NOT NULL AUTO_INCREMENT,
   creatorId VARCHAR(255) NOT NULL,
   name VARCHAR(255) NOT NULL,
   description VARCHAR(255) NOT NULL,
   img VARCHAR(255) NOT NULL,
   views INT NOT NULL DEFAULT 0,
   shares INT NOT NULL DEFAULT 0,
   keeps INT NOT NULL DEFAULT 0,

  PRIMARY KEY (id),

  FOREIGN KEY (creatorId)
   REFERENCES profiles(id)
   ON DELETE CASCADE
);

CREATE TABLE vaultkeep
(
  id INT NOT NULL AUTO_INCREMENT,
  creatorId VARCHAR(255) NOT NULL,
  vaultId INT NOT NULL,
  keepId INT NOT NULL,

  PRIMARY KEY (id),

  FOREIGN KEY (creatorId)
   REFERENCES profiles(id)
   ON DELETE CASCADE,

   FOREIGN KEY (vaultId)
    REFERENCES vault(id)
    ON DELETE CASCADE,

  FOREIGN KEY (keepId)
    REFERENCES keep(id)
    ON DELETE CASCADE
);
