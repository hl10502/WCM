# WCM

WCM是V2V转换器的客户端工具，可以将VMware的虚拟机离线转换到XenServer主机上。WCM转换虚拟机不会删除或更改现有的VMware环境。

目前版本V2.0。

## 项目结构

* ConversionClientLib：转换客户端的公共类库
* WCM：Controls、Dialogs与Wizards等页面
* WinServer：连接XenServer的XAPI


## 版本变更

V2.0

* XAPI升级
* 支持XenServer6.1/6.2/6.5/7.0
* 支持ESXi 5.0.0/5.1.0/5.5.0/6.0.0，vSphere 4.0/4.1，vCenter Server 4.0/4.1
* 支持常见操作系统
* UI优化


V1.0

* 初始版本
* 支持中文
* 离线转换VMware虚拟机到XenServer


