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

 Date: 10/10/2022 15:04:19
*/

SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------
-- Table structure for sampleinfo
-- ----------------------------
DROP TABLE IF EXISTS `sampleinfo`;
CREATE TABLE `sampleinfo`  (
  `ID` int(10) UNSIGNED NOT NULL AUTO_INCREMENT,
  `SampleID` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL COMMENT '标本编码',
  `SampleName` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL COMMENT '标本名称',
  `SampleNamePy` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL COMMENT '标本名称简称',
  PRIMARY KEY (`ID`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = DYNAMIC;

SET FOREIGN_KEY_CHECKS = 1;
