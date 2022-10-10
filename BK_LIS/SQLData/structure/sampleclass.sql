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

 Date: 10/10/2022 15:04:14
*/

SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------
-- Table structure for sampleclass
-- ----------------------------
DROP TABLE IF EXISTS `sampleclass`;
CREATE TABLE `sampleclass`  (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `ClassCode` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '样本大类编码',
  `Classname` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '样本大类名称',
  PRIMARY KEY (`ID`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 5 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

SET FOREIGN_KEY_CHECKS = 1;
