-- phpMyAdmin SQL Dump
-- version 4.8.5
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: May 27, 2020 at 07:45 AM
-- Server version: 10.1.38-MariaDB
-- PHP Version: 7.3.2

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `db_goc`
--

-- --------------------------------------------------------

--
-- Table structure for table `billing_partial`
--

CREATE TABLE `billing_partial` (
  `id` int(11) NOT NULL,
  `or_no` varchar(255) DEFAULT NULL,
  `stud_no` varchar(255) DEFAULT NULL,
  `lrn_no` varchar(25) DEFAULT NULL,
  `full_name` varchar(255) DEFAULT NULL,
  `DP` varchar(255) DEFAULT NULL,
  `1p` varchar(255) DEFAULT NULL,
  `2p` varchar(255) DEFAULT NULL,
  `3p` varchar(255) DEFAULT NULL,
  `4p` varchar(255) DEFAULT NULL,
  `5p` varchar(255) DEFAULT NULL,
  `6p` varchar(255) DEFAULT NULL,
  `7p` varchar(255) DEFAULT NULL,
  `8p` varchar(255) DEFAULT NULL,
  `9p` varchar(255) DEFAULT NULL,
  `10p` varchar(255) DEFAULT NULL,
  `balance` varchar(255) DEFAULT NULL,
  `enrollment_status` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `books`
--

CREATE TABLE `books` (
  `id` int(11) NOT NULL,
  `book_name` varchar(255) DEFAULT NULL,
  `anount` varchar(255) DEFAULT NULL,
  `level` varchar(255) DEFAULT NULL,
  `sy` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `book_item`
--

CREATE TABLE `book_item` (
  `id` int(11) NOT NULL,
  `book_id` varchar(255) DEFAULT NULL,
  `title` varchar(255) DEFAULT NULL,
  `grade_level` varchar(255) DEFAULT NULL,
  `price` varchar(255) DEFAULT NULL,
  `strand` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `book_item`
--

INSERT INTO `book_item` (`id`, `book_id`, `title`, `grade_level`, `price`, `strand`) VALUES
(1, 'BK-0001', 'Science', '11', '250', 'STEM'),
(6, 'BK-0002', 'AP', '11', '232', 'STEM'),
(7, 'BK-0003', 'Math', '11', '344', 'STEM');

-- --------------------------------------------------------

--
-- Table structure for table `book_stock`
--

CREATE TABLE `book_stock` (
  `id` int(11) NOT NULL,
  `book_id` varchar(255) DEFAULT NULL,
  `title` varchar(255) DEFAULT NULL,
  `stock` varchar(255) DEFAULT NULL,
  `sold` varchar(255) DEFAULT NULL,
  `remaning_stock` varchar(255) DEFAULT NULL,
  `date_delivered` varchar(255) DEFAULT NULL,
  `sy` varchar(20) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `book_stock`
--

INSERT INTO `book_stock` (`id`, `book_id`, `title`, `stock`, `sold`, `remaning_stock`, `date_delivered`, `sy`) VALUES
(2, 'BK-0001', 'AP', '500', '0', '500', 'April 09, 2020', '2020 - 2021'),
(3, 'BK-0002', 'EPP', '90', '0', '90', 'April 30, 2020', '2020 - 2021');

-- --------------------------------------------------------

--
-- Table structure for table `department`
--

CREATE TABLE `department` (
  `id` int(11) NOT NULL,
  `department_name` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `department`
--

INSERT INTO `department` (`id`, `department_name`) VALUES
(1, 'Pre Elementary'),
(2, 'Elementary');

-- --------------------------------------------------------

--
-- Table structure for table `discount`
--

CREATE TABLE `discount` (
  `id` int(11) NOT NULL,
  `discount_name` varchar(255) DEFAULT NULL,
  `amount` varchar(255) DEFAULT NULL,
  `percentage` varchar(255) DEFAULT NULL,
  `status` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `discount`
--

INSERT INTO `discount` (`id`, `discount_name`, `amount`, `percentage`, `status`) VALUES
(120, 'Valedictorian', '1000', '0', 'Active'),
(121, 'Sibling Discount', '0', '5', 'Active'),
(122, 'Fullpayment', '0', '10', 'Active');

-- --------------------------------------------------------

--
-- Table structure for table `down_payment`
--

CREATE TABLE `down_payment` (
  `id` int(11) NOT NULL,
  `dp_name` varchar(255) DEFAULT NULL,
  `dept` varchar(255) DEFAULT NULL,
  `grade_level` varchar(255) DEFAULT NULL,
  `amount` varchar(255) DEFAULT NULL,
  `monthly` varchar(255) DEFAULT NULL,
  `status` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `down_payment`
--

INSERT INTO `down_payment` (`id`, `dp_name`, `dept`, `grade_level`, `amount`, `monthly`, `status`) VALUES
(2, 'New DP', 'Pre Elementary', 'Nursery', '66000', '1600', 'Active');

-- --------------------------------------------------------

--
-- Table structure for table `enrolled_students`
--

CREATE TABLE `enrolled_students` (
  `id` int(11) NOT NULL,
  `stud_no` varchar(255) NOT NULL,
  `full_name` varchar(255) NOT NULL,
  `grade_level` varchar(255) NOT NULL,
  `section` varchar(255) NOT NULL,
  `semester` varchar(255) NOT NULL,
  `term` varchar(255) NOT NULL,
  `dept` varchar(255) NOT NULL,
  `sy_enrolled` varchar(255) NOT NULL,
  `date_enrolled` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `grade_level`
--

CREATE TABLE `grade_level` (
  `id` int(11) NOT NULL,
  `level` varchar(255) DEFAULT NULL,
  `descp` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `grade_level`
--

INSERT INTO `grade_level` (`id`, `level`, `descp`) VALUES
(1, 'Nursery', '0'),
(2, 'Preparatory', '0'),
(3, 'Kinder', '0'),
(4, 'Grade 1', '0'),
(5, 'Grade 2', '0'),
(6, 'Grade 3', '0'),
(7, 'Grade 4', '0'),
(8, 'Grade 5', '0'),
(9, 'Grade 6', '0');

-- --------------------------------------------------------

--
-- Table structure for table `miscfee`
--

CREATE TABLE `miscfee` (
  `id` int(11) NOT NULL,
  `miscfee_name` varchar(255) DEFAULT NULL,
  `amount` varchar(255) DEFAULT NULL,
  `description` varchar(50) DEFAULT NULL,
  `status` varchar(255) DEFAULT NULL,
  `dept` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `miscfee`
--

INSERT INTO `miscfee` (`id`, `miscfee_name`, `amount`, `description`, `status`, `dept`) VALUES
(113, 'Reservation Fee', '1000', NULL, 'ACTIVE', 'SHS'),
(114, 'Guidance Fee', '500', NULL, 'ACTIVE', 'SHS'),
(115, 'Library Fee', '600', NULL, 'ACTIVE', 'SHS'),
(116, 'Medical / Dental Fee', '500', NULL, 'ACTIVE', 'SHS'),
(117, 'Audio-Visual Fee', '500', NULL, 'ACTIVE', 'SHS'),
(118, 'Athletic/ Sports Fee', '300', NULL, 'ACTIVE', 'SHS'),
(119, 'Insurance Fee', '100', NULL, 'ACTIVE', 'SHS'),
(120, 'ID Fee', '150', NULL, 'ACTIVE', 'SHS'),
(121, 'School Publication Fee', '200', NULL, 'ACTIVE', 'SHS'),
(122, 'Handbook', '150', NULL, 'ACTIVE', 'SHS');

-- --------------------------------------------------------

--
-- Table structure for table `otherfee`
--

CREATE TABLE `otherfee` (
  `id` int(11) NOT NULL,
  `otherfee_name` varchar(255) DEFAULT NULL,
  `amount` varchar(255) DEFAULT NULL,
  `status` varchar(255) DEFAULT NULL,
  `dept` varchar(255) DEFAULT NULL,
  `lab_fee` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `otherfee`
--

INSERT INTO `otherfee` (`id`, `otherfee_name`, `amount`, `status`, `dept`, `lab_fee`) VALUES
(1, 'Computer Laboratory/ Internet Fee', '2500.00', 'Active', 'Active', 0),
(2, 'Testing Materials', '500.00', 'Active', 'Active', 0),
(3, 'Laboratory Fee (Chemistry & Physics)', '1000.00', 'Active', 'Active', 1);

-- --------------------------------------------------------

--
-- Table structure for table `payment_log`
--

CREATE TABLE `payment_log` (
  `id` int(11) NOT NULL,
  `stud_no` varchar(255) DEFAULT NULL,
  `lrn_no` varchar(255) DEFAULT NULL,
  `or_no` varchar(255) DEFAULT NULL,
  `amount_given` varchar(255) DEFAULT NULL,
  `payment_no` varchar(255) DEFAULT NULL,
  `payment_date` timestamp NULL DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `reservation`
--

CREATE TABLE `reservation` (
  `id` int(11) NOT NULL,
  `reservation_name` varchar(255) DEFAULT NULL,
  `amount` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `room`
--

CREATE TABLE `room` (
  `id` int(11) NOT NULL,
  `room_name` varchar(255) DEFAULT NULL,
  `location` varchar(255) DEFAULT NULL,
  `capacity` varchar(11) DEFAULT NULL,
  `room_ceiling` varchar(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `section`
--

CREATE TABLE `section` (
  `id` int(11) NOT NULL,
  `section_name` varchar(255) DEFAULT NULL,
  `section_desc` varchar(255) DEFAULT NULL,
  `dept` varchar(255) DEFAULT NULL,
  `room_assign` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `strand`
--

CREATE TABLE `strand` (
  `id` int(11) NOT NULL,
  `strand_name` varchar(50) DEFAULT NULL,
  `lab_fee` varchar(5) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `strand`
--

INSERT INTO `strand` (`id`, `strand_name`, `lab_fee`) VALUES
(741, 'STEM', '1'),
(742, 'TVL - ICT', '1'),
(743, 'TVL - HE', '1'),
(744, 'ABM', '0'),
(745, 'HUMSS', '0');

-- --------------------------------------------------------

--
-- Table structure for table `student_profile`
--

CREATE TABLE `student_profile` (
  `id` int(11) NOT NULL,
  `reg_no` varchar(50) DEFAULT NULL,
  `stud_no` varchar(50) DEFAULT NULL,
  `lrn` varchar(20) DEFAULT NULL,
  `last_name` varchar(225) DEFAULT NULL,
  `first_name` varchar(225) DEFAULT NULL,
  `middle_name` varchar(225) DEFAULT NULL,
  `grade_level` varchar(50) DEFAULT NULL,
  `department` varchar(50) DEFAULT NULL,
  `section` varchar(50) DEFAULT NULL,
  `track` varchar(50) DEFAULT NULL,
  `strand` varchar(50) DEFAULT NULL,
  `voucher_type` varchar(50) DEFAULT NULL,
  `student_type` varchar(50) DEFAULT NULL,
  `semester` varchar(255) DEFAULT NULL,
  `date_of_birth` varchar(50) DEFAULT NULL,
  `place_of_birth` varchar(225) DEFAULT NULL,
  `religion` varchar(225) DEFAULT NULL,
  `nationality` varchar(225) DEFAULT NULL,
  `sex` varchar(20) DEFAULT NULL,
  `address` varchar(225) DEFAULT NULL,
  `mother_name` varchar(50) DEFAULT NULL,
  `mother_contact` varchar(50) DEFAULT NULL,
  `mother_work` varchar(50) DEFAULT NULL,
  `father_name` varchar(50) DEFAULT NULL,
  `father_contact` varchar(50) DEFAULT NULL,
  `father_work` varchar(50) DEFAULT NULL,
  `cperson_name` varchar(50) DEFAULT NULL,
  `cperson_address` varchar(255) DEFAULT NULL,
  `cperson_contact` varchar(50) DEFAULT NULL,
  `cperson_relationship` varchar(50) DEFAULT NULL,
  `previous_school` varchar(100) DEFAULT NULL,
  `previous_school_address` varchar(100) DEFAULT NULL,
  `psa` varchar(5) DEFAULT NULL,
  `psa_copy` varchar(5) DEFAULT NULL,
  `med_certificate` varchar(5) DEFAULT NULL,
  `report_card` varchar(5) DEFAULT NULL,
  `form_137` varchar(5) DEFAULT NULL,
  `good_moral` varchar(5) DEFAULT NULL,
  `entrance_exam` varchar(50) DEFAULT NULL,
  `ncae` varchar(5) DEFAULT NULL,
  `esc_voucher` varchar(11) DEFAULT NULL,
  `mop` varchar(20) DEFAULT NULL,
  `enrollee_status` varchar(100) DEFAULT NULL,
  `date_of_enrollment` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `student_profile`
--

INSERT INTO `student_profile` (`id`, `reg_no`, `stud_no`, `lrn`, `last_name`, `first_name`, `middle_name`, `grade_level`, `department`, `section`, `track`, `strand`, `voucher_type`, `student_type`, `semester`, `date_of_birth`, `place_of_birth`, `religion`, `nationality`, `sex`, `address`, `mother_name`, `mother_contact`, `mother_work`, `father_name`, `father_contact`, `father_work`, `cperson_name`, `cperson_address`, `cperson_contact`, `cperson_relationship`, `previous_school`, `previous_school_address`, `psa`, `psa_copy`, `med_certificate`, `report_card`, `form_137`, `good_moral`, `entrance_exam`, `ncae`, `esc_voucher`, `mop`, `enrollee_status`, `date_of_enrollment`) VALUES
(1, '0001', '20-0001', '234242342342', 'Dasd', 'Efraim', 'Das', '11', 'Senior High', 'NA', 'Academic', 'STEM', 'Public Voucher', 'New Student', '1st Semester', 'May 21, 2020', 'Das', 'Das', 'Das', 'Female', 'Asd', 'N A', 'N A', 'N A', 'N A', 'N A', 'N A', 'N A', 'N A', 'N A', 'N A', 'das', 'Das', '0', '1', '0', '0', '0', '0', '0', '0', '0', 'NA', 'NA', '2020-05-21 13:33:59'),
(2, '0002', '00-0000', '344234234234', 'Wer', 'Erwr', 'Wrwerwer', '11', 'Senior High', 'NA', 'Academic', 'STEM', 'Public Voucher', 'New Student', '1st Semester', 'May 22, 2020', 'Wr', 'Rwe', 'Rwer', 'Female', 'Rwer', 'N A', 'N A', 'N A', 'N A', 'N A', 'N A', 'N A', 'N A', 'N A', 'N A', 'rwerwe', 'Rwe', '0', '1', '0', '1', '0', '0', '0', '0', '0', 'NA', 'NA', '2020-05-22 02:49:22');

-- --------------------------------------------------------

--
-- Table structure for table `subject`
--

CREATE TABLE `subject` (
  `id` int(11) NOT NULL,
  `subject_code` varchar(255) DEFAULT NULL,
  `subject_desc` varchar(255) DEFAULT NULL,
  `semester` varchar(255) DEFAULT NULL,
  `level` varchar(255) DEFAULT NULL,
  `dept` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `sy`
--

CREATE TABLE `sy` (
  `id` int(11) NOT NULL,
  `start` varchar(255) DEFAULT NULL,
  `end` varchar(255) DEFAULT NULL,
  `semester` varchar(255) DEFAULT NULL,
  `quarter` varchar(255) DEFAULT NULL,
  `status` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `sy`
--

INSERT INTO `sy` (`id`, `start`, `end`, `semester`, `quarter`, `status`) VALUES
(111, '2020', '2021', '1st Semester', '1st Quarter', 'Active');

-- --------------------------------------------------------

--
-- Table structure for table `teacher`
--

CREATE TABLE `teacher` (
  `id` int(11) NOT NULL,
  `fname` varchar(255) DEFAULT NULL,
  `lname` varchar(255) DEFAULT NULL,
  `mname` varchar(255) DEFAULT NULL,
  `specialization` varchar(255) DEFAULT NULL,
  `adviser_of` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `teacher`
--

INSERT INTO `teacher` (`id`, `fname`, `lname`, `mname`, `specialization`, `adviser_of`) VALUES
(109, 'fnam', 'mi', 'last', 'speci', 'Inactive');

-- --------------------------------------------------------

--
-- Table structure for table `trans_book_fee`
--

CREATE TABLE `trans_book_fee` (
  `id` int(11) NOT NULL,
  `reg_no` varchar(50) DEFAULT NULL,
  `or_no` varchar(50) DEFAULT NULL,
  `book_id` varchar(50) DEFAULT NULL,
  `order_status` varchar(50) DEFAULT NULL,
  `order_date` datetime DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `trans_book_fee`
--

INSERT INTO `trans_book_fee` (`id`, `reg_no`, `or_no`, `book_id`, `order_status`, `order_date`) VALUES
(745, '0002', '#', 'BK-0001', 'ok', '2020-05-22 15:41:24'),
(746, '0002', '#', 'BK-0002', 'Order', '2020-05-22 15:41:26'),
(747, '0002', '#', 'BK-0003', 'Order', '2020-05-22 15:41:28');

-- --------------------------------------------------------

--
-- Table structure for table `trans_book_unif_fee`
--

CREATE TABLE `trans_book_unif_fee` (
  `id` int(11) NOT NULL,
  `lrn` varchar(50) DEFAULT NULL,
  `or_no` varchar(50) DEFAULT NULL,
  `isOrderBook` varchar(50) DEFAULT NULL,
  `book_order` varchar(50) DEFAULT NULL,
  `unif_desc` varchar(50) DEFAULT NULL,
  `unif_qty` varchar(50) DEFAULT NULL,
  `unif_size` varchar(50) DEFAULT NULL,
  `pay_date` datetime DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `trans_unif_fee`
--

CREATE TABLE `trans_unif_fee` (
  `id` int(11) NOT NULL,
  `reg_no` varchar(50) DEFAULT NULL,
  `or_no` varchar(50) DEFAULT NULL,
  `lrn` varchar(50) DEFAULT NULL,
  `unif_code` varchar(50) DEFAULT NULL,
  `unif_qty` varchar(50) DEFAULT NULL,
  `unif_size` varchar(50) DEFAULT NULL,
  `order_status` varchar(15) DEFAULT NULL,
  `order_date` datetime DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `trans_unif_fee`
--

INSERT INTO `trans_unif_fee` (`id`, `reg_no`, `or_no`, `lrn`, `unif_code`, `unif_qty`, `unif_size`, `order_status`, `order_date`) VALUES
(1, '0001', '0000', '234242342342', 'UNIF-0001', '3', 'XS', NULL, '2020-05-21 21:33:26'),
(2, '0002', '0000', '344234234234', 'UNIF-0001', '3', 'XS', NULL, '2020-05-22 12:26:28'),
(3, '0002', '0000', '344234234234', 'UNIF-0003', '3', 'XS', NULL, '2020-05-22 15:34:33');

-- --------------------------------------------------------

--
-- Table structure for table `tuition`
--

CREATE TABLE `tuition` (
  `id` int(11) NOT NULL,
  `tuition_name` varchar(255) DEFAULT NULL,
  `amount` varchar(255) DEFAULT NULL,
  `grade_level` varchar(255) DEFAULT NULL,
  `status` varchar(255) DEFAULT NULL,
  `dept` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `tuition`
--

INSERT INTO `tuition` (`id`, `tuition_name`, `amount`, `grade_level`, `status`, `dept`) VALUES
(117, 'SHS - Tuition Fee', '21000', 'SHS', 'Active', 'SHS');

-- --------------------------------------------------------

--
-- Table structure for table `unif_item`
--

CREATE TABLE `unif_item` (
  `id` int(11) NOT NULL,
  `unif_code` varchar(255) DEFAULT NULL,
  `item_name` varchar(255) DEFAULT NULL,
  `price` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `unif_item`
--

INSERT INTO `unif_item` (`id`, `unif_code`, `item_name`, `price`) VALUES
(3, 'UNIF-0001', 'Polo', '350'),
(4, 'UNIF-0002', 'Skirt', '300'),
(5, 'UNIF-0003', 'Short', '250'),
(6, 'UNIF-0004', 'Scarf', '50'),
(7, 'UNIF-0005', 'Sando', '100'),
(8, 'UNIF-0006', 'Salawal', '50');

-- --------------------------------------------------------

--
-- Table structure for table `unif_stock`
--

CREATE TABLE `unif_stock` (
  `id` int(11) NOT NULL,
  `unif_code` varchar(255) DEFAULT NULL,
  `item_name` varchar(255) DEFAULT NULL,
  `stock` varchar(255) DEFAULT NULL,
  `sold` varchar(255) DEFAULT NULL,
  `remaning_stock` varchar(255) DEFAULT NULL,
  `date_delivered` varchar(255) DEFAULT NULL,
  `sy` varchar(15) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `unif_stock`
--

INSERT INTO `unif_stock` (`id`, `unif_code`, `item_name`, `stock`, `sold`, `remaning_stock`, `date_delivered`, `sy`) VALUES
(6, 'UNIF-0006', 'Salawal', '500', '0', '500', 'March 01, 2020', '2020 - 2021'),
(7, 'UNIF-0003', 'Short', '50', '0', '50', 'May 06, 2020', '2020 - 2021');

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `id` int(11) NOT NULL,
  `username` varchar(255) DEFAULT NULL,
  `password` varchar(255) DEFAULT NULL,
  `user_type` varchar(255) DEFAULT NULL,
  `fname` varchar(255) DEFAULT NULL,
  `lname` varchar(255) DEFAULT NULL,
  `mname` varchar(255) DEFAULT NULL,
  `emp_id` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `voucher`
--

CREATE TABLE `voucher` (
  `id` int(11) NOT NULL,
  `voucher_from` varchar(255) DEFAULT NULL,
  `voucher_amount` double(7,2) DEFAULT '0.00',
  `dp_Amount` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `voucher`
--

INSERT INTO `voucher` (`id`, `voucher_from`, `voucher_amount`, `dp_Amount`) VALUES
(3, 'Public Voucher', 17500.00, '3000'),
(4, 'Private Voucher', 14000.00, '3000'),
(5, 'Non - Voucher', 0.00, '10000.00');

-- --------------------------------------------------------

--
-- Table structure for table `z_ctr`
--

CREATE TABLE `z_ctr` (
  `id` int(5) NOT NULL,
  `ctr` varchar(5) DEFAULT NULL,
  `ctr_goc_no` int(11) DEFAULT NULL,
  `ctr_book` int(11) DEFAULT NULL,
  `ctr_unif` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `z_ctr`
--

INSERT INTO `z_ctr` (`id`, `ctr`, `ctr_goc_no`, `ctr_book`, `ctr_unif`) VALUES
(1, '2', 1, 3, 0);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `billing_partial`
--
ALTER TABLE `billing_partial`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `books`
--
ALTER TABLE `books`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `book_item`
--
ALTER TABLE `book_item`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `book_id` (`book_id`);

--
-- Indexes for table `book_stock`
--
ALTER TABLE `book_stock`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `book_id` (`book_id`);

--
-- Indexes for table `department`
--
ALTER TABLE `department`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `discount`
--
ALTER TABLE `discount`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `down_payment`
--
ALTER TABLE `down_payment`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `enrolled_students`
--
ALTER TABLE `enrolled_students`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `grade_level`
--
ALTER TABLE `grade_level`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `miscfee`
--
ALTER TABLE `miscfee`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `otherfee`
--
ALTER TABLE `otherfee`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `payment_log`
--
ALTER TABLE `payment_log`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `or_no` (`or_no`);

--
-- Indexes for table `reservation`
--
ALTER TABLE `reservation`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `room`
--
ALTER TABLE `room`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `section`
--
ALTER TABLE `section`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `strand`
--
ALTER TABLE `strand`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `student_profile`
--
ALTER TABLE `student_profile`
  ADD PRIMARY KEY (`id`) USING BTREE,
  ADD UNIQUE KEY `lrn` (`lrn`);

--
-- Indexes for table `subject`
--
ALTER TABLE `subject`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `sy`
--
ALTER TABLE `sy`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `teacher`
--
ALTER TABLE `teacher`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `trans_book_fee`
--
ALTER TABLE `trans_book_fee`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `trans_book_unif_fee`
--
ALTER TABLE `trans_book_unif_fee`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `trans_unif_fee`
--
ALTER TABLE `trans_unif_fee`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `tuition`
--
ALTER TABLE `tuition`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `unif_item`
--
ALTER TABLE `unif_item`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `unif_code` (`unif_code`);

--
-- Indexes for table `unif_stock`
--
ALTER TABLE `unif_stock`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `unif_code` (`unif_code`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `voucher`
--
ALTER TABLE `voucher`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `voucher_from` (`voucher_from`);

--
-- Indexes for table `z_ctr`
--
ALTER TABLE `z_ctr`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `billing_partial`
--
ALTER TABLE `billing_partial`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `books`
--
ALTER TABLE `books`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `book_item`
--
ALTER TABLE `book_item`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT for table `book_stock`
--
ALTER TABLE `book_stock`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `department`
--
ALTER TABLE `department`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `discount`
--
ALTER TABLE `discount`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=123;

--
-- AUTO_INCREMENT for table `down_payment`
--
ALTER TABLE `down_payment`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `enrolled_students`
--
ALTER TABLE `enrolled_students`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `grade_level`
--
ALTER TABLE `grade_level`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- AUTO_INCREMENT for table `miscfee`
--
ALTER TABLE `miscfee`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=123;

--
-- AUTO_INCREMENT for table `otherfee`
--
ALTER TABLE `otherfee`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `payment_log`
--
ALTER TABLE `payment_log`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `reservation`
--
ALTER TABLE `reservation`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `room`
--
ALTER TABLE `room`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `section`
--
ALTER TABLE `section`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `strand`
--
ALTER TABLE `strand`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=746;

--
-- AUTO_INCREMENT for table `student_profile`
--
ALTER TABLE `student_profile`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `subject`
--
ALTER TABLE `subject`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `sy`
--
ALTER TABLE `sy`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=112;

--
-- AUTO_INCREMENT for table `teacher`
--
ALTER TABLE `teacher`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=110;

--
-- AUTO_INCREMENT for table `trans_book_fee`
--
ALTER TABLE `trans_book_fee`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=748;

--
-- AUTO_INCREMENT for table `trans_book_unif_fee`
--
ALTER TABLE `trans_book_unif_fee`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `trans_unif_fee`
--
ALTER TABLE `trans_unif_fee`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `tuition`
--
ALTER TABLE `tuition`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=118;

--
-- AUTO_INCREMENT for table `unif_item`
--
ALTER TABLE `unif_item`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- AUTO_INCREMENT for table `unif_stock`
--
ALTER TABLE `unif_stock`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `voucher`
--
ALTER TABLE `voucher`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT for table `z_ctr`
--
ALTER TABLE `z_ctr`
  MODIFY `id` int(5) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
