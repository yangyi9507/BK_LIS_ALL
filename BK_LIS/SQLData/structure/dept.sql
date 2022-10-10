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

 Date: 10/10/2022 15:03:31
*/

SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------
-- Table structure for dept
-- ----------------------------
DROP TABLE IF EXISTS `dept`;
CREATE TABLE `dept`  (
  `id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT,
  `DeptID` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL COMMENT '科室ID',
  `DeptName` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL COMMENT '科室名称',
  `DeptNamePy` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL COMMENT '科室名称简拼',
  `DeptMemo` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL COMMENT '科室备注',
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 8 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = DYNAMIC;

SET FOREIGN_KEY_CHECKS = 1;
