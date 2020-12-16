-- CREATE TABLE profiles (
--   id VARCHAR(255) NOT NULL,
--   name VARCHAR(255) NOT NULL,
--   email VARCHAR(255) NOT NULL,
--   picture VARCHAR(255) NOT NULL,
--   PRIMARY KEY (id)
-- )

-- CREATE TABLE contractors (
--   id INT AUTO_INCREMENT NOT NULL,
--   name VARCHAR(80) NOT NULL,
--   wage INT NOT NULL,
--   contractorId VARCHAR(255) NOT NULL,
--   PRIMARY KEY(id),
--   FOREIGN KEY(contractorId)
--   REFERENCES profiles(id)
--   ON DELETE CASCADE
-- )
CREATE TABLE jobs (
  id INT AUTO_INCREMENT NOT NULL,
  title VARCHAR(255) NOT NULL,
  location VARCHAR(255) NOT NULL,
  budget INT NOT NULL,
  PRIMARY KEY (id)
)
