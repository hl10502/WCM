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


## WCM分析

[V2V转换器（一）——XenServer Conversion Manager](http://www.hl10502.com/2017/02/28/v2v-1/)

[V2V转换器（二）——XenServer Conversion Manager Virtual Appliance虚拟机配置](http://www.hl10502.com/2017/02/28/v2v-2/)

[V2V转换器（三）——XenServer Conversion Manager Virtual Appliance转换服务convsvc配置](http://www.hl10502.com/2017/02/28/v2v-3/)

[V2V转换器（四）——XenServer Conversion Manager Virtual Appliance虚拟机网络修改](http://www.hl10502.com/2017/02/28/v2v-4/)

[V2V转换器（五）——ERROR Credentials for user 'root' are invalid on http://169.254.0.1](http://www.hl10502.com/2017/02/28/v2v-5/)

[V2V转换器（六）——Unable to Boot VMware SCSI Disk](http://www.hl10502.com/2017/03/07/v2v-6/)

[V2V转换器（七）——V2V服务端分析之convsvc](http://www.hl10502.com/2017/03/07/v2v-7/)

[V2V转换器（八）——V2V服务端分析之Converter](http://www.hl10502.com/2017/03/08/v2v-8/)



