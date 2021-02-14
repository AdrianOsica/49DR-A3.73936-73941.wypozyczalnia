-- phpMyAdmin SQL Dump
-- version 5.0.4
-- https://www.phpmyadmin.net/
--
-- Host: localhost
-- Generation Time: Feb 14, 2021 at 05:11 PM
-- Server version: 10.3.27-MariaDB-0+deb10u1
-- PHP Version: 7.3.19-1~deb10u1

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `salon`
--

-- --------------------------------------------------------

--
-- Table structure for table `buy`
--

CREATE TABLE `buy` (
  `id` int(11) NOT NULL,
  `id_car` text COLLATE utf8_polish_ci NOT NULL,
  `name_buyer` text COLLATE utf8_polish_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;

--
-- Dumping data for table `buy`
--

INSERT INTO `buy` (`id`, `id_car`, `name_buyer`) VALUES
(1, '2', 'Jan Kowal'),
(2, '4', 'df');

-- --------------------------------------------------------

--
-- Table structure for table `car`
--

CREATE TABLE `car` (
  `id` int(11) NOT NULL,
  `producent` text COLLATE utf8_polish_ci NOT NULL,
  `model` text COLLATE utf8_polish_ci NOT NULL,
  `rok` text COLLATE utf8_polish_ci NOT NULL,
  `przebieg` text COLLATE utf8_polish_ci NOT NULL,
  `Cena_kupna` text COLLATE utf8_polish_ci NOT NULL,
  `Cena_wynajmu` text COLLATE utf8_polish_ci NOT NULL,
  `status` text COLLATE utf8_polish_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;

--
-- Dumping data for table `car`
--

INSERT INTO `car` (`id`, `producent`, `model`, `rok`, `przebieg`, `Cena_kupna`, `Cena_wynajmu`, `status`) VALUES
(1, 'Seat', 'Ibiza 6j', '2016', '140000', '20000', '600', 'wynajety'),
(2, 'Dacia', 'Duster', '2013', '12000', '15000', '500', 'wynajety'),
(3, 'BMW', 'e39', '2001', '300000', '10000', '200', 'wynajety'),
(4, 'Seat', 'Leon', '2015', '35000', '50000', '300', 'sprzedany');

-- --------------------------------------------------------

--
-- Table structure for table `rent`
--

CREATE TABLE `rent` (
  `id` int(11) NOT NULL,
  `id_car` int(11) NOT NULL,
  `name_buyer` text COLLATE utf8_polish_ci NOT NULL,
  `do_kiedy` text COLLATE utf8_polish_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;

--
-- Dumping data for table `rent`
--

INSERT INTO `rent` (`id`, `id_car`, `name_buyer`, `do_kiedy`) VALUES
(1, 2, 'Juzek', '14.04.2021 15:00:46'),
(2, 2, 'Ads', '14.04.2021 15:03:40'),
(3, 3, 'dsf', '14.04.2021 15:05:47'),
(4, 1, 'Jan', '14.05.2021 15:13:02');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `buy`
--
ALTER TABLE `buy`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `car`
--
ALTER TABLE `car`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `rent`
--
ALTER TABLE `rent`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `buy`
--
ALTER TABLE `buy`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `car`
--
ALTER TABLE `car`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `rent`
--
ALTER TABLE `rent`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
