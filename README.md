# Carousel

### 介绍
UGUI扩展库

### 软件架构
走马灯控件


### 安装教程

1.打开unitypackageManager

2.点击+号，url添加

3.输入连接引入

### 使用教程
第一种：在content节点下添加好要展示的图片即可

第二种：动态使用组件add方法添加

####属性Props：
Name ：AddImage
Type ：Texture
Description ： 增加图片

Name ：AutomaticRolling
Type ：boolean
Description ： 是否开启自动播放（默认开启）

Name ：CarouselScrollTime
Type ：float
Description ： 自动播放的播放时间间隔（默认为2秒）

Name ：SpecifyTheImage
Type ：int
Description ： 指定跳转到第几张图片

####方法Method：
Name ：Next
Description ： 下一张图片

Name ：Prev
Description ： 上一张图片

Name ：RestDate
Description ： 重新刷新到第一张图片

####事件Event：
Name ：onImageAddValueChanged
Type ：Texture
Description ： 增加图片响应事件

Name ：onAutomaticValueChanged
Type ：bool
Description ： 注册布尔类型响应事件

Name ：onAutomaticTime
Type ：float
Description ： 注册Float类型响应事件

Name ：onSpecifyTheImage
Type ：int
Description ： 指定图片响应事件