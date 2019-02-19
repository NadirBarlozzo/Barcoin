-- phpMyAdmin SQL Dump
-- version 4.7.4
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Creato il: Feb 19, 2019 alle 15:13
-- Versione del server: 10.1.29-MariaDB
-- Versione PHP: 7.2.0

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `barcoinv2`
--

-- --------------------------------------------------------

--
-- Struttura della tabella `block`
--

CREATE TABLE `block` (
  `id` int(11) NOT NULL,
  `poolid` int(11) NOT NULL,
  `signature` char(64) NOT NULL,
  `hash` char(64) NOT NULL,
  `previoushash` char(64) DEFAULT NULL,
  `timestamp` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dump dei dati per la tabella `block`
--

INSERT INTO `block` (`id`, `poolid`, `signature`, `hash`, `previoushash`, `timestamp`) VALUES
(6, 16, 'FR0NayLPy5ebTZZb7xPtCrHdYRFgV+fXBSEc7Uvq0JYqlm+xz8Ykp4vkuwxtqDml', 'QLcRwZ++XdhCrlCZZ067qMANIPaSP0HDmUWHhfCJKQw=', '', '2019-02-06 09:18:58'),
(7, 17, 'qOQdnCmnNmHd14gy8KTo6IkvEsLLTajSc3BBPaNUQ5XjvAoocuthrFU5Tr8h14rf', 'xlrim0RQrdZ0v/s0TAoeTnNRKRI/7eUE6mYfNaSUBMs=', 'QLcRwZ++XdhCrlCZZ067qMANIPaSP0HDmUWHhfCJKQw=', '2019-02-06 09:22:09');

-- --------------------------------------------------------

--
-- Struttura della tabella `pool`
--

CREATE TABLE `pool` (
  `id` int(11) NOT NULL,
  `timestamp` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dump dei dati per la tabella `pool`
--

INSERT INTO `pool` (`id`, `timestamp`) VALUES
(16, '2019-02-06 09:18:57'),
(17, '2019-02-06 09:22:09');

-- --------------------------------------------------------

--
-- Struttura della tabella `transaction`
--

CREATE TABLE `transaction` (
  `id` int(11) NOT NULL,
  `poolid` int(11) NOT NULL,
  `senderid` int(11) NOT NULL,
  `recipientid` int(11) NOT NULL,
  `amount` float NOT NULL,
  `status` enum('pending','rejected','confirmed','') NOT NULL DEFAULT 'pending',
  `timestamp` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dump dei dati per la tabella `transaction`
--

INSERT INTO `transaction` (`id`, `poolid`, `senderid`, `recipientid`, `amount`, `status`, `timestamp`) VALUES
(10, 16, 1, 2, 5, 'confirmed', '2019-02-06 09:18:57'),
(11, 17, 2, 1, 10.2345, 'confirmed', '2019-02-06 09:22:09');

-- --------------------------------------------------------

--
-- Struttura della tabella `user`
--

CREATE TABLE `user` (
  `id` int(11) NOT NULL,
  `username` varchar(20) NOT NULL,
  `firstname` varchar(30) NOT NULL,
  `lastname` varchar(30) NOT NULL,
  `password` char(44) CHARACTER SET utf8 COLLATE utf8_swedish_ci NOT NULL,
  `salt` char(44) CHARACTER SET utf8 COLLATE utf8_swedish_ci NOT NULL,
  `address` char(32) NOT NULL,
  `timestamp` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dump dei dati per la tabella `user`
--

INSERT INTO `user` (`id`, `username`, `firstname`, `lastname`, `password`, `salt`, `address`, `timestamp`) VALUES
(1, 'barnad', 'Nadir', 'Barlozzo', 'X+uvHVj4DGygAVgWdKWimmG96DHrM29H/lkf2nCzAaM=', 'DDtf+PxtwWProLUgzw/hXDY1j79QDpVwR4v8vP8EB2g=', '98841f32fabf48788e10e494d1b88d21', '2019-01-30 07:36:20'),
(2, 'KING7up', 'Igor', 'Fontanini', 'O13/UvWAr0MdL1R+WYELOqHGvD859giqFNpnbbrSqLg=', 'Ybeocsx2hkVPJe9LUYRIlooe69wa+3EHO1BhAfkWHrs=', 'ecd6377e28eb4afab6238b7bbb6bad44', '2019-02-04 09:35:55');

--
-- Indici per le tabelle scaricate
--

--
-- Indici per le tabelle `block`
--
ALTER TABLE `block`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `hash` (`hash`),
  ADD UNIQUE KEY `poolid` (`poolid`) USING BTREE,
  ADD KEY `signature` (`signature`) USING BTREE,
  ADD KEY `previoushash` (`previoushash`);

--
-- Indici per le tabelle `pool`
--
ALTER TABLE `pool`
  ADD PRIMARY KEY (`id`);

--
-- Indici per le tabelle `transaction`
--
ALTER TABLE `transaction`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `poolid` (`poolid`),
  ADD KEY `senderid` (`senderid`) USING BTREE,
  ADD KEY `recipientid` (`recipientid`) USING BTREE;

--
-- Indici per le tabelle `user`
--
ALTER TABLE `user`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `username` (`username`),
  ADD UNIQUE KEY `address` (`address`);

--
-- AUTO_INCREMENT per le tabelle scaricate
--

--
-- AUTO_INCREMENT per la tabella `block`
--
ALTER TABLE `block`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT per la tabella `pool`
--
ALTER TABLE `pool`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=18;

--
-- AUTO_INCREMENT per la tabella `transaction`
--
ALTER TABLE `transaction`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;

--
-- AUTO_INCREMENT per la tabella `user`
--
ALTER TABLE `user`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- Limiti per le tabelle scaricate
--

--
-- Limiti per la tabella `block`
--
ALTER TABLE `block`
  ADD CONSTRAINT `block_ibfk_1` FOREIGN KEY (`poolid`) REFERENCES `pool` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Limiti per la tabella `transaction`
--
ALTER TABLE `transaction`
  ADD CONSTRAINT `transaction_ibfk_2` FOREIGN KEY (`senderid`) REFERENCES `user` (`id`),
  ADD CONSTRAINT `transaction_ibfk_3` FOREIGN KEY (`recipientid`) REFERENCES `user` (`id`),
  ADD CONSTRAINT `transaction_ibfk_4` FOREIGN KEY (`poolid`) REFERENCES `pool` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
