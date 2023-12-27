-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Dec 27, 2023 at 08:11 AM
-- Server version: 10.4.28-MariaDB
-- PHP Version: 8.2.4

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `csharp`
--

-- --------------------------------------------------------

--
-- Table structure for table `account`
--

CREATE TABLE `account` (
  `USERNAME` varchar(50) NOT NULL,
  `MAKH` varchar(10) NOT NULL,
  `PASSWORD` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `account`
--

INSERT INTO `account` (`USERNAME`, `MAKH`, `PASSWORD`) VALUES
('thithanhcong', 'KH01', 'thithanhcong');

-- --------------------------------------------------------

--
-- Table structure for table `cthd`
--

CREATE TABLE `cthd` (
  `MAHD` varchar(10) NOT NULL,
  `MAMA` varchar(10) NOT NULL,
  `MAK` varchar(50) DEFAULT NULL,
  `SL` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `cthd`
--

INSERT INTO `cthd` (`MAHD`, `MAMA`, `MAK`, `SL`) VALUES
('6TuZUe0OY', 'MA01', NULL, 3),
('6TuZUe0OY', 'MA02', NULL, 1),
('HD01', 'MA01', NULL, 2),
('HD01', 'MA02', NULL, 1),
('HD02', 'MA03', NULL, 3),
('HD03', 'MA01', NULL, 1),
('HD03', 'MA02', NULL, 2),
('HD03', 'MA03', NULL, 4),
('P9i1GwCXy', 'MA01', NULL, 2),
('pQjDSionC', 'MA01', NULL, 10);

-- --------------------------------------------------------

--
-- Table structure for table `hoadon`
--

CREATE TABLE `hoadon` (
  `MAHD` varchar(10) NOT NULL,
  `MAKH` varchar(10) NOT NULL,
  `THT` decimal(10,2) NOT NULL,
  `NGAYHD` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `hoadon`
--

INSERT INTO `hoadon` (`MAHD`, `MAKH`, `THT`, `NGAYHD`) VALUES
('6TuZUe0OY', 'KH01', 90000.00, '2023-12-26'),
('HD01', 'KH01', 50000.00, '2023-12-06'),
('HD02', 'KH02', 70000.00, '2023-12-07'),
('HD03', 'KH03', 90000.00, '2023-12-08'),
('meS7lw0gc', 'KH01', 0.00, '2023-12-26'),
('P9i1GwCXy', 'KH01', 40000.00, '2023-12-26'),
('pQjDSionC', 'KH01', 200000.00, '2023-12-27'),
('yOntH7FYb', 'KH01', 40000.00, '2023-12-26');

-- --------------------------------------------------------

--
-- Table structure for table `khachhang`
--

CREATE TABLE `khachhang` (
  `MAKH` varchar(10) NOT NULL,
  `HO` varchar(50) NOT NULL,
  `TEN` varchar(50) NOT NULL,
  `NGAYSINH` date NOT NULL,
  `DIACHI` varchar(255) NOT NULL,
  `SDT` varchar(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `khachhang`
--

INSERT INTO `khachhang` (`MAKH`, `HO`, `TEN`, `NGAYSINH`, `DIACHI`, `SDT`) VALUES
('KH01', 'Nguyễn', 'Văn A', '1990-01-01', 'TP. Hồ Chí Minh', '0901234567'),
('KH02', 'Trần', 'Thị B', '1991-02-02', 'Hà Nội', '0912345678'),
('KH03', 'Lê', 'Văn C', '1992-03-03', 'Đà Nẵng', '0923456789');

-- --------------------------------------------------------

--
-- Table structure for table `monan`
--

CREATE TABLE `monan` (
  `MAMA` varchar(10) NOT NULL,
  `TENMA` varchar(255) NOT NULL,
  `DONGIA` decimal(10,2) NOT NULL,
  `LOAIMA` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `monan`
--

INSERT INTO `monan` (`MAMA`, `TENMA`, `DONGIA`, `LOAIMA`) VALUES
('MA01', 'Bánh mì', 20000.00, 'Ăn sáng'),
('MA02', 'Cơm tấm', 30000.00, 'Ăn trưa'),
('MA03', 'Phở', 40000.00, 'Ăn tối');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `account`
--
ALTER TABLE `account`
  ADD PRIMARY KEY (`USERNAME`),
  ADD KEY `MAKH` (`MAKH`);

--
-- Indexes for table `cthd`
--
ALTER TABLE `cthd`
  ADD PRIMARY KEY (`MAHD`,`MAMA`),
  ADD KEY `MAMA` (`MAMA`);

--
-- Indexes for table `hoadon`
--
ALTER TABLE `hoadon`
  ADD PRIMARY KEY (`MAHD`),
  ADD KEY `MAKH` (`MAKH`);

--
-- Indexes for table `khachhang`
--
ALTER TABLE `khachhang`
  ADD PRIMARY KEY (`MAKH`);

--
-- Indexes for table `monan`
--
ALTER TABLE `monan`
  ADD PRIMARY KEY (`MAMA`);

--
-- Constraints for dumped tables
--

--
-- Constraints for table `account`
--
ALTER TABLE `account`
  ADD CONSTRAINT `account_ibfk_1` FOREIGN KEY (`MAKH`) REFERENCES `khachhang` (`MAKH`) ON DELETE CASCADE;

--
-- Constraints for table `cthd`
--
ALTER TABLE `cthd`
  ADD CONSTRAINT `cthd_ibfk_1` FOREIGN KEY (`MAHD`) REFERENCES `hoadon` (`MAHD`) ON DELETE CASCADE,
  ADD CONSTRAINT `cthd_ibfk_2` FOREIGN KEY (`MAMA`) REFERENCES `monan` (`MAMA`) ON DELETE CASCADE;

--
-- Constraints for table `hoadon`
--
ALTER TABLE `hoadon`
  ADD CONSTRAINT `hoadon_ibfk_1` FOREIGN KEY (`MAKH`) REFERENCES `khachhang` (`MAKH`) ON DELETE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
