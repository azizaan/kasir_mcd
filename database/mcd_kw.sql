/*
 Navicat Premium Data Transfer

 Source Server         : tutorial_db
 Source Server Type    : MySQL
 Source Server Version : 100424 (10.4.24-MariaDB)
 Source Host           : localhost:3306
 Source Schema         : mcd_kw

 Target Server Type    : MySQL
 Target Server Version : 100424 (10.4.24-MariaDB)
 File Encoding         : 65001

 Date: 28/11/2023 09:25:42
*/

SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------
-- Table structure for drinks_dessert
-- ----------------------------
DROP TABLE IF EXISTS `drinks_dessert`;
CREATE TABLE `drinks_dessert`  (
  `id` int NOT NULL AUTO_INCREMENT,
  `harga` bigint NULL DEFAULT NULL,
  `nama` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 7 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of drinks_dessert
-- ----------------------------
INSERT INTO `drinks_dessert` VALUES (1, 9500, 'ColaCola');
INSERT INTO `drinks_dessert` VALUES (2, 9500, 'Fanta');
INSERT INTO `drinks_dessert` VALUES (3, 10000, 'MacFlurry');
INSERT INTO `drinks_dessert` VALUES (4, 9500, 'Pepsi');
INSERT INTO `drinks_dessert` VALUES (5, 12000, 'AppleFizz');
INSERT INTO `drinks_dessert` VALUES (6, 14500, 'SakuraFizz');

-- ----------------------------
-- Table structure for fast_meal
-- ----------------------------
DROP TABLE IF EXISTS `fast_meal`;
CREATE TABLE `fast_meal`  (
  `id` int NOT NULL AUTO_INCREMENT,
  `harga` bigint NULL DEFAULT NULL,
  `nama` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 13 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of fast_meal
-- ----------------------------
INSERT INTO `fast_meal` VALUES (1, 17500, 'FriedFries');
INSERT INTO `fast_meal` VALUES (2, 37000, 'BigMac');
INSERT INTO `fast_meal` VALUES (3, 11000, 'Bubur');
INSERT INTO `fast_meal` VALUES (4, 16500, 'Sandwich');
INSERT INTO `fast_meal` VALUES (5, 33000, 'ChickenNugget');
INSERT INTO `fast_meal` VALUES (6, 11000, 'FishSnackWrap');

-- ----------------------------
-- Table structure for orders
-- ----------------------------
DROP TABLE IF EXISTS `orders`;
CREATE TABLE `orders`  (
  `id` int NOT NULL AUTO_INCREMENT,
  `pesanan` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `timestamp` timestamp NULL DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 11 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of orders
-- ----------------------------
INSERT INTO `orders` VALUES (1, '\n		RESTAURANT MEKDI KAWE SUPER\n			2023-11-20 14:48:47\n		***********************************\n	French Fries:		Rp17.500\n	Burger:		Rp74.000\n', '2023-11-20 14:51:53');
INSERT INTO `orders` VALUES (2, '\n		RESTAURANT MEKDI KAWE SUPER\n			2023-11-20 14:52:44\n		***********************************\n	French Fries:		Rp17.500\n	Burger:		Rp74.000\n', '2023-11-20 14:53:07');
INSERT INTO `orders` VALUES (3, '\n		RESTAURANT MEKDI KAWE SUPER\n			2023-11-20 14:52:44\n		***********************************\n	French Fries:		Rp17.500\n	Burger:		Rp74.000\n', '2023-11-20 14:53:14');
INSERT INTO `orders` VALUES (4, '\n		RESTAURANT MEKDI KAWE SUPER\n			2023-11-20 14:52:54\n		***********************************\n	Bubur:			Rp11.000\n', '2023-11-20 14:53:17');
INSERT INTO `orders` VALUES (6, '\n		RESTAURANT MEKDI KAWE SUPER\n			2023-11-20 15:03:18\n		***********************************\n	French Fries:		Rp35.000\n', '2023-11-20 15:03:28');
INSERT INTO `orders` VALUES (7, '\n		RESTAURANT MEKDI KAWE SUPER\n			2023-11-20 15:19:50\n		***********************************\n	French Fries:		Rp35.000\n	Burger:		Rp37.000\n	Cola-Cola:		Rp9.500\n	Mac Flurry:		Rp10.000\n', '2023-11-20 15:19:58');
INSERT INTO `orders` VALUES (8, '\n		RESTAURANT MEKDI KAWE SUPER\n			2023-11-21 10:22:05\n		***********************************\n	French Fries:		Rp17.500\nTotal Items:						7\n', '2023-11-21 10:22:06');

-- ----------------------------
-- Table structure for users
-- ----------------------------
DROP TABLE IF EXISTS `users`;
CREATE TABLE `users`  (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(150) CHARACTER SET latin1 COLLATE latin1_swedish_ci NOT NULL,
  `username` varchar(25) CHARACTER SET latin1 COLLATE latin1_swedish_ci NOT NULL,
  `username_verified_at` timestamp NULL DEFAULT NULL,
  `password` varchar(255) CHARACTER SET latin1 COLLATE latin1_swedish_ci NOT NULL,
  `level` varchar(15) CHARACTER SET latin1 COLLATE latin1_swedish_ci NOT NULL,
  `created_at` timestamp NULL DEFAULT current_timestamp,
  `updated_at` timestamp NULL DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`) USING BTREE,
  UNIQUE INDEX `users_email_unique`(`username` ASC) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 3 CHARACTER SET = latin1 COLLATE = latin1_swedish_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of users
-- ----------------------------
INSERT INTO `users` VALUES (1, 'Admin', 'admin', '2023-03-11 17:00:00', 'admin', 'admin', '2023-03-12 10:17:27', '2023-11-20 15:08:30');
INSERT INTO `users` VALUES (2, 'Kasir', 'kasir', '2023-11-24 14:29:12', 'kasir', 'kasir', '2023-11-24 14:30:26', '2023-11-24 14:30:57');

SET FOREIGN_KEY_CHECKS = 1;
