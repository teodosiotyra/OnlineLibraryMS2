-- --------------------------------------------------------
-- Host:                         127.0.0.1
-- Server version:               10.4.32-MariaDB - mariadb.org binary distribution
-- Server OS:                    Win64
-- HeidiSQL Version:             12.17.0.7270
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


-- Dumping database structure for librarydb
CREATE DATABASE IF NOT EXISTS `librarydb` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci */;
USE `librarydb`;

-- Dumping structure for table librarydb.books
CREATE TABLE IF NOT EXISTS `books` (
  `BookID` int(11) NOT NULL AUTO_INCREMENT,
  `Title` varchar(100) DEFAULT NULL,
  `Author` varchar(100) DEFAULT NULL,
  `CategoryID` int(11) DEFAULT NULL,
  `Status` varchar(20) DEFAULT NULL,
  `DateAdded` datetime DEFAULT current_timestamp(),
  PRIMARY KEY (`BookID`),
  KEY `FK_Books_Categories` (`CategoryID`),
  CONSTRAINT `FK_Books_Categories` FOREIGN KEY (`CategoryID`) REFERENCES `categories` (`CategoryID`) ON DELETE SET NULL ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=36 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- Dumping data for table librarydb.books: ~32 rows (approximately)
INSERT INTO `books` (`BookID`, `Title`, `Author`, `CategoryID`, `Status`, `DateAdded`) VALUES
	(1, 'The Great Gatsby', 'F. Scott Fitzgerald', 1, 'Available', '2026-05-15 18:45:55'),
	(2, '1984', 'George Orwell', 2, 'Available', '2026-05-15 18:45:55'),
	(3, 'Harry Potter', 'J.K. Rowling', 3, 'Available', '2026-05-15 18:45:55'),
	(5, 'Atomic Habits', 'James Clear', 4, 'Available', '2026-05-15 18:45:55'),
	(6, 'Rich Dad Poor Dad', 'Robert Kiyosaki', 5, 'Available', '2026-05-15 18:45:55'),
	(7, 'The Alchemist', 'Paulo Coelho', 6, 'Available', '2026-05-15 18:45:55'),
	(9, 'To Kill a Mockingbird', 'Harper Lee', 1, 'Available', '2026-05-16 07:27:12'),
	(10, 'The Catcher in the Rye', 'J.D. Salinger', 1, 'Available', '2026-05-16 07:27:12'),
	(11, 'Pride and Prejudice', 'Jane Austen', 1, 'Available', '2026-05-16 07:27:12'),
	(12, 'Brave New World', 'Aldous Huxley', 2, 'Available', '2026-05-16 07:27:12'),
	(13, 'Fahrenheit 451', 'Ray Bradbury', 2, 'Available', '2026-05-16 07:27:12'),
	(14, 'The Lord of the Rings', 'J.R.R. Tolkien', 3, 'Available', '2026-05-16 07:27:12'),
	(15, 'The Chronicles of Narnia', 'C.S. Lewis', 3, 'Available', '2026-05-16 07:27:12'),
	(16, 'The 7 Habits of Highly Effective People', 'Stephen Covey', 4, 'Available', '2026-05-16 07:27:12'),
	(17, 'Think and Grow Rich', 'Napoleon Hill', 4, 'Available', '2026-05-16 07:27:12'),
	(18, 'The Psychology of Money', 'Morgan Housel', 5, 'Available', '2026-05-16 07:27:12'),
	(19, 'Rich Dad Poor Dad 2', 'Robert Kiyosaki', 5, 'Available', '2026-05-16 07:27:12'),
	(20, 'Into the Wild', 'Jon Krakauer', 6, 'Available', '2026-05-16 07:27:12'),
	(21, 'The Martian', 'Andy Weir', 6, 'Available', '2026-05-16 07:27:12'),
	(22, 'To Kill a Mockingbird', 'Harper Lee', 1, 'Available', '2026-05-16 10:04:27'),
	(23, 'The Catcher in the Rye', 'J.D. Salinger', 1, 'Available', '2026-05-16 10:04:27'),
	(24, 'Pride and Prejudice', 'Jane Austen', 1, 'Available', '2026-05-16 10:04:27'),
	(25, 'Brave New World', 'Aldous Huxley', 2, 'Available', '2026-05-16 10:04:27'),
	(26, 'Fahrenheit 451', 'Ray Bradbury', 2, 'Available', '2026-05-16 10:04:27'),
	(27, 'The Lord of the Rings', 'J.R.R. Tolkien', 3, 'Available', '2026-05-16 10:04:27'),
	(28, 'The Chronicles of Narnia', 'C.S. Lewis', 3, 'Available', '2026-05-16 10:04:27'),
	(29, 'The 7 Habits of Highly Effective People', 'Stephen Covey', 4, 'Available', '2026-05-16 10:04:27'),
	(30, 'Think and Grow Rich', 'Napoleon Hill', 4, 'Available', '2026-05-16 10:04:27'),
	(31, 'The Psychology of Money', 'Morgan Housel', 5, 'Available', '2026-05-16 10:04:27'),
	(32, 'Rich Dad Poor Dad 2', 'Robert Kiyosaki', 5, 'Available', '2026-05-16 10:04:27'),
	(33, 'Into the Wild', 'Jon Krakauer', 6, 'Available', '2026-05-16 10:04:27'),
	(34, 'The Martian', 'Andy Weir', 6, 'Available', '2026-05-16 10:04:27');

-- Dumping structure for table librarydb.borrows
CREATE TABLE IF NOT EXISTS `borrows` (
  `BorrowID` int(11) NOT NULL AUTO_INCREMENT,
  `UserID` int(11) DEFAULT NULL,
  `BookID` int(11) DEFAULT NULL,
  `BorrowDate` datetime DEFAULT current_timestamp(),
  `DueDate` datetime DEFAULT NULL,
  `ReturnDate` datetime DEFAULT NULL,
  `Status` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`BorrowID`),
  KEY `FK_Borrows_Users` (`UserID`),
  KEY `FK_Borrows_Books` (`BookID`),
  CONSTRAINT `FK_Borrows_Books` FOREIGN KEY (`BookID`) REFERENCES `books` (`BookID`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `FK_Borrows_Users` FOREIGN KEY (`UserID`) REFERENCES `users` (`UserID`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- Dumping data for table librarydb.borrows: ~13 rows (approximately)
INSERT INTO `borrows` (`BorrowID`, `UserID`, `BookID`, `BorrowDate`, `DueDate`, `ReturnDate`, `Status`) VALUES
	(1, 1, 5, '2026-05-15 18:46:40', '2026-05-22 18:46:40', '2026-05-15 19:32:55', 'Returned'),
	(2, 1, 1, '2026-05-15 18:48:43', '2026-05-22 18:48:43', '2026-05-15 19:26:06', 'Returned'),
	(3, 8, 1, '2026-05-15 19:25:37', '2026-05-22 19:25:37', '2026-05-16 10:04:27', 'Returned'),
	(4, 8, 7, '2026-05-15 19:29:08', '2026-05-22 19:29:08', '2026-05-15 19:30:12', 'Returned'),
	(5, 15, 1, '2026-05-15 19:40:50', '2026-05-22 19:40:50', '2026-05-15 19:41:45', 'Returned'),
	(6, 16, 1, '2026-05-15 21:34:12', '2026-05-22 21:34:12', '2026-05-15 21:34:46', 'Returned'),
	(7, 17, 1, '2026-05-16 07:43:47', '2026-05-23 07:43:47', '2026-05-16 07:46:27', 'Returned'),
	(8, 17, 1, '2026-05-16 07:46:48', '2026-05-23 07:46:48', '2026-05-16 07:47:31', 'Returned'),
	(9, 17, 2, '2026-05-16 07:46:51', '2026-05-23 07:46:51', '2026-05-16 07:47:27', 'Returned'),
	(10, 17, 3, '2026-05-16 07:46:55', '2026-05-23 07:46:55', '2026-05-16 07:47:23', 'Returned'),
	(11, 17, 1, '2026-05-16 09:41:32', '2026-05-23 09:41:32', '2026-05-16 09:44:54', 'Returned'),
	(12, 17, 3, '2026-05-16 09:41:34', '2026-05-23 09:41:34', '2026-05-16 09:44:50', 'Returned'),
	(13, 17, 11, '2026-05-16 09:41:37', '2026-05-23 09:41:37', '2026-05-16 09:44:46', 'Returned');

-- Dumping structure for table librarydb.categories
CREATE TABLE IF NOT EXISTS `categories` (
  `CategoryID` int(11) NOT NULL AUTO_INCREMENT,
  `CategoryName` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`CategoryID`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- Dumping data for table librarydb.categories: ~6 rows (approximately)
INSERT INTO `categories` (`CategoryID`, `CategoryName`) VALUES
	(1, 'Fiction'),
	(2, 'Dystopian'),
	(3, 'Fantasy'),
	(4, 'Self-help'),
	(5, 'Finance'),
	(6, 'Adventure');

-- Dumping structure for table librarydb.users
CREATE TABLE IF NOT EXISTS `users` (
  `UserID` int(11) NOT NULL AUTO_INCREMENT,
  `Username` varchar(50) NOT NULL,
  `Password` varchar(50) NOT NULL,
  `FullName` varchar(100) NOT NULL,
  `Role` varchar(20) NOT NULL,
  `DateRegistered` datetime DEFAULT current_timestamp(),
  PRIMARY KEY (`UserID`),
  UNIQUE KEY `Username` (`Username`)
) ENGINE=InnoDB AUTO_INCREMENT=22 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- Dumping data for table librarydb.users: ~10 rows (approximately)
INSERT INTO `users` (`UserID`, `Username`, `Password`, `FullName`, `Role`, `DateRegistered`) VALUES
	(1, 'renzo', 'renzo', 'renzo', 'User', '2026-05-02 11:42:08'),
	(4, 'ty', 'ty', 'ty', 'User', '2026-05-15 16:02:25'),
	(7, 'd', 'd', 'd', 'User', '2026-05-15 16:03:00'),
	(8, 'a', 'a', 'a', 'User', '2026-05-15 16:27:59'),
	(9, 'admin', 'admin123', 'System Administrator', 'Admin', '2026-05-15 16:29:59'),
	(11, 'Judea', '123', 'Dey', 'User', '2026-05-15 18:48:21'),
	(14, 'ren', 'ren', 'ren', 'User', '2026-05-15 19:13:54'),
	(15, 'Naith', 'qwerty', 'Naithan', 'User', '2026-05-15 19:40:37'),
	(16, 'Car', '1234', 'Maricar', 'User', '2026-05-15 21:33:48'),
	(17, 'rc', 'rc123', 'RC Jimenez', 'User', '2026-05-16 07:43:20');

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
