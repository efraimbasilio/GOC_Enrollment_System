-- phpMyAdmin SQL Dump
-- version 4.8.5
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Mar 29, 2020 at 05:13 PM
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
-- Database: `db_caebs`
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

--
-- Dumping data for table `billing_partial`
--

INSERT INTO `billing_partial` (`id`, `or_no`, `stud_no`, `lrn_no`, `full_name`, `DP`, `1p`, `2p`, `3p`, `4p`, `5p`, `6p`, `7p`, `8p`, `9p`, `10p`, `balance`, `enrollment_status`) VALUES
(1, '1', '1', '1', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(5, '2', '2', '2', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL);

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
(112, 'Fee2', '2000', NULL, NULL, NULL);

-- --------------------------------------------------------

--
-- Table structure for table `otherfee`
--

CREATE TABLE `otherfee` (
  `id` int(11) NOT NULL,
  `otherfee_name` varchar(255) DEFAULT NULL,
  `amount` varchar(255) DEFAULT NULL,
  `status` varchar(255) DEFAULT NULL,
  `dept` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

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
-- Table structure for table `student_profile`
--

CREATE TABLE `student_profile` (
  `id` int(11) NOT NULL,
  `stud_no` varchar(50) DEFAULT NULL,
  `lrn` varchar(20) DEFAULT NULL,
  `last_name` varchar(225) DEFAULT NULL,
  `first_name` varchar(225) DEFAULT NULL,
  `middle_name` varchar(225) DEFAULT NULL,
  `grade_level` varchar(50) DEFAULT NULL,
  `department` varchar(50) DEFAULT NULL,
  `section` varchar(50) DEFAULT NULL,
  `term` varchar(50) DEFAULT NULL,
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
  `pic_child` varchar(5) DEFAULT NULL,
  `pic_guardian` varchar(5) DEFAULT NULL,
  `med_certificate` varchar(5) DEFAULT NULL,
  `report_card` varchar(5) DEFAULT NULL,
  `form_137` varchar(5) DEFAULT NULL,
  `good_moral` varchar(5) DEFAULT NULL,
  `mode_of_payment` varchar(100) DEFAULT NULL,
  `enrollee_status` varchar(100) DEFAULT NULL,
  `date_of_enrollment` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `student_profile`
--

INSERT INTO `student_profile` (`id`, `stud_no`, `lrn`, `last_name`, `first_name`, `middle_name`, `grade_level`, `department`, `section`, `term`, `student_type`, `semester`, `date_of_birth`, `place_of_birth`, `religion`, `nationality`, `sex`, `address`, `mother_name`, `mother_contact`, `mother_work`, `father_name`, `father_contact`, `father_work`, `cperson_name`, `cperson_address`, `cperson_contact`, `cperson_relationship`, `previous_school`, `previous_school_address`, `psa`, `psa_copy`, `pic_child`, `pic_guardian`, `med_certificate`, `report_card`, `form_137`, `good_moral`, `mode_of_payment`, `enrollee_status`, `date_of_enrollment`) VALUES
(1, 'CAEBS-2020-0001', '334', 'dasd', 'das', 'das', 'Nursery', 'Pre Elementary', 'NA', '1st Quarter', 'New Student', '1st Semester', 'March 29, 2020', 'das', 'das', 'das', 'Female', 'das', '', '', '', '', '', '', '', NULL, '', '', 'das', 'das', '1', '', '0', '0', '0', '0', '1', '0', 'Partial', 'NA', '2020-03-29 06:36:43'),
(2, 'CAEBS-2020-0002', '3323', 'asdas', 'das', 'asd', 'Nursery', 'Pre Elementary', 'NA', '1st Quarter', 'New Student', '1st Semester', 'March 29, 2020', 'das', 'dsa', 'das', 'Female', 'dasd', '', '', '', '', '', '', '', '', '', '', 'das', 'das', '1', '', '0', '1', '1', '0', '0', '0', 'Partial', 'NA', '2020-03-29 06:38:20'),
(3, 'CAEBS-2020-0003', '234532', 'ffsdf', 'fsdffds', 'fsd', 'Nursery', 'Pre Elementary', 'NA', '1st Quarter', 'New Student', '1st Semester', 'March 29, 2020', 'fsdf', 'fsd', 'fsd', 'Female', 'fsd', '', '', '', '', '', '', '', '', '', '', 'fsd', 'fds', '1', '', '0', '0', '0', '0', '0', '0', 'Partial', 'NA', '2020-03-29 06:40:03'),
(4, 'CAEBS-2020-0004', '434', 'sdf', 'fsdf', 'fds', 'Nursery', 'Pre Elementary', 'NA', '1st Quarter', 'New Student', '1st Semester', 'March 29, 2020', 'fsd', 'fsd', 'fsd', 'Male', 'fsdf', 'NA', 'NA', 'NA', 'NA', 'NA', 'NA', 'NA', 'NA', 'NA', 'NA', 'fsdf', 'fsd', '1', '', '0', '1', '0', '0', '0', '0', 'Fullpayment', 'NA', '2020-03-29 06:41:36'),
(5, 'CAEBS-2020-0005', '435435', 'ter', 're', 'tre', 'Nursery', 'Pre Elementary', 'NA', '1st Quarter', 'New Student', '1st Semester', 'March 29, 2020', 'ter', 'ter', 'tret', 'Female', 'tert', 'NA', 'NA', 'NA', 'NA', 'NA', 'NA', 'NA', 'NA', 'NA', 'NA', 'tre', 'tre', '1', '', '0', '0', '0', '0', '0', '1', 'Partial', 'NA', '2020-03-29 09:23:58'),
(6, 'CAEBS-2020-0006', '342342344234', 'eqwe', 'eqwe', 'eqw', 'Nursery', 'Pre Elementary', 'NA', '1st Quarter', 'New Student', '1st Semester', 'March 29, 2020', 'eqwe', 'eqw', 'eqw', 'Female', 'eqw', 'NA', 'NA', 'NA', 'NA', 'NA', 'NA', 'NA', 'NA', 'NA', 'NA', 'eqwe', 'eqw', '1', '1', '0', '1', '0', '0', '0', '0', 'Partial', 'NA', '2020-03-29 13:19:54');

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
(115, 'Kinder Tuititon Fee', '21000', 'Kinder', 'Active', 'Pre Elementary'),
(116, 'Grade 1 SY: 19 -20', '24000', 'Grade 1', 'Inactive', 'Elementary');

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

--
-- Indexes for dumped tables
--

--
-- Indexes for table `billing_partial`
--
ALTER TABLE `billing_partial`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `or_no` (`or_no`) USING BTREE,
  ADD UNIQUE KEY `stud_no` (`stud_no`),
  ADD UNIQUE KEY `lrn_no` (`lrn_no`);

--
-- Indexes for table `books`
--
ALTER TABLE `books`
  ADD PRIMARY KEY (`id`);

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
-- Indexes for table `student_profile`
--
ALTER TABLE `student_profile`
  ADD PRIMARY KEY (`id`) USING BTREE,
  ADD UNIQUE KEY `lrn` (`lrn`),
  ADD UNIQUE KEY `stud_no` (`stud_no`);

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
-- Indexes for table `tuition`
--
ALTER TABLE `tuition`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `billing_partial`
--
ALTER TABLE `billing_partial`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT for table `books`
--
ALTER TABLE `books`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

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
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT for table `miscfee`
--
ALTER TABLE `miscfee`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=113;

--
-- AUTO_INCREMENT for table `otherfee`
--
ALTER TABLE `otherfee`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

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
-- AUTO_INCREMENT for table `student_profile`
--
ALTER TABLE `student_profile`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

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
-- AUTO_INCREMENT for table `tuition`
--
ALTER TABLE `tuition`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=117;

--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
