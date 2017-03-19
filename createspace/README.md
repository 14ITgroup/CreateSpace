# CreateSpace

网站主体

[TOC]
## 一、维护相关

### 1.邮件
本网站后台邮件发送使用中国海洋大学学生邮箱itstudio@stu.ouc.edu.cn
密码:Itdn2016
host:mail.stu.ouc.edu.cn

## 二、目录或文件说明
| 名字 | 类型 | 说明 |
| :------- | :--------- | :------ |
| confirm.aspx | 页面 | 提交页面 |
| Index.aspx | 页面 | 主页面，时间节点选择 |
| admin | 文件夹 | 后台管理页面 |

## 三、数据库部分介绍

### 1.数据库表

|表名|表功能|
|:------|:------|
|admins|管理员|
|applications|使用申请|
|usercontact|邮件联系人|

### 2.数据库详细介绍

#### 1) admins

|列名|数据类型|作用|
|:----|:----|:----|
|id|int|唯一标识|
|account|nvarchar(50)|用户名|
|password|nvarchar(200)|密码|
|email|nvarchar(100)|电子邮件，找回密码|
|nickname|nvarchar(50)|昵称，其实并不打算用到|

#### 2) applications

|列名|数据类型|作用|
|:----|:----|:----|
|id|int|唯一标识|
|email|nvarchar(100)|邮箱，为了确认邮件|
|stuname|nvarchar(50)|申请人姓名|
|state|int|状态(拒绝，同意，未处理)|
|title|nvarchar(100)|申请标题|
|body|nvarchar(max)|申请主体|
|mobile|nvarchar(20)|手机号，方便核实|
|deal|bit|处理状态|
|apptime|int|申请时间-时间戳形式|
|createtime|datetime|创建时间|

#### 3) usercontact

|列名|数据类型|作用|
|:----|:----|:----|
|id|int|主键,唯一标识|
|usname|nvarchar(50)|联系人名|
|usemail|nvarchar(200)|联系人邮箱|
|usclass|int|联系人权限|

