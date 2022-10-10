/*
 Navicat Premium Data Transfer

 Source Server         : localhost_3306
 Source Server Type    : MySQL
 Source Server Version : 50731
 Source Host           : localhost:3306
 Source Schema         : lismain

 Target Server Type    : MySQL
 Target Server Version : 50731
 File Encoding         : 65001

 Date: 10/10/2022 15:03:55
*/

SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------
-- Table structure for pattype
-- ----------------------------
DROP TABLE IF EXISTS `pattype`;
CREATE TABLE `pattype`  (
  `ID` int(10) UNSIGNED NOT NULL AUTO_INCREMENT,
  `PatTypeID` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL COMMENT '病人来源代码',
  `PatTypeName` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL COMMENT '病人来源名称',
  `PatTypeNamePy` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL COMMENT '病人来源简称',
  PRIMARY KEY (`ID`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = DYNAMIC;

SET FOREIGN_KEY_CHECKS = 1;
