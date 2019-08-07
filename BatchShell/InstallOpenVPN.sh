## 一、安装openvpn
yum -y install epel-release
yum -y install openvpn easy-rsa iptables openssl ca-certificates

cp -r /usr/share/easy-rsa/ /etc/openvpn/easy-rsa
cd /etc/openvpn/easy-rsa/
\rm 3 3.0
cd 3.0.3/
find / -type f -name "vars.example" | xargs -i cp {} . && mv vars.example vars

## 二、生成CA证书
./easyrsa init-pki
./easyrsa build-ca nopass

## 三、创建服务端证书
### 1.创建服务端证书
./easyrsa gen-req server nopass
### 2.签约服务端证书(yes)
./easyrsa sign server server
### 3.创建 Diffie-Hellman
./easyrsa gen-dh

### 4.创建 crl.pem
./easyrsa gen-crl

### 5.整理证书
cd /etc/openvpn
cp easy-rsa/3.0.3/pki/dh.pem .
cp easy-rsa/3.0.3/pki/ca.crt .
cp easy-rsa/3.0.3/pki/issued/server.crt .
cp easy-rsa/3.0.3/pki/private/server.key .
cp easy-rsa/3.0.3/pki/crl.pem .
chown nobody:nobody /etc/openvpn/crl.pem


## 四、创建客户端证书
### 1.复制文件
cp -r /usr/share/easy-rsa/ /etc/openvpn/client
cd /etc/openvpn/client/easy-rsa/
\rm 3 3.0 
cd 3.0.3/
find / -type f -name "vars.example" | xargs -i cp {} . && mv vars.example vars

### 2.生成客户端证书
./easyrsa init-pki
./easyrsa gen-req client nopass

### 3.签约客户端证书
cd /etc/openvpn/easy-rsa/3.0.3/
./easyrsa import-req /etc/openvpn/client/easy-rsa/3.0.3/pki/reqs/client.req client
./easyrsa sign client client # (yes)

### 4.整理证书
cd /etc/openvpn/client
cp /etc/openvpn/easy-rsa/3.0.3/pki/ca.crt .
cp /etc/openvpn/easy-rsa/3.0.3/pki/issued/client.crt .
cp /etc/openvpn/client/easy-rsa/3.0.3/pki/private/client.key .

## 五、配置文件
### 1.服务器配置文件
vim /etc/openvpn/server.conf
########################### 配置信息 ###########################

port 1194
proto tcp
dev tun
 
ca /etc/openvpn/ca.crt
cert /etc/openvpn/server.crt
key /etc/openvpn/server.key
dh /etc/openvpn/dh.pem
crl-verify /etc/openvpn/crl.pem

ifconfig-pool-persist /etc/openvpn/ipp.txt
 
server 10.8.0.0 255.255.255.0
push "route 10.8.0.0 255.255.255.0"
push "redirect-gateway def1 bypass-dhcp"
push "dhcp-option DNS 114.114.114.114"
push "dhcp-option DNS 8.8.8.8"
client-to-client
 
keepalive 20 120
comp-lzo
 
user openvpn
group openvpn
 
persist-key
persist-tun
status      openvpn-status.log
log-append  openvpn.log
verb 1
mute 20
########################### 配置信息 ###########################

### 2.客户端配置文件
vim /etc/openvpn/client/client.ovpn
########################### 配置信息 ###########################
client
remote 58.246.52.42 8294
proto tcp
dev tun
comp-lzo
ca ca.crt
cert client.crt
key client.key
route-delay 2
route-method exe
redirect-gateway def1
dhcp-option DNS  210.22.84.3
dhcp-option DNS 8.8.8.8
dhcp-option DNS 8.8.4.4
dhcp-option DNS 4.2.2.1
verb 3
########################### 配置信息 ###########################

## 六、启动OpenVPN和端口转发
### 1.启动OpenVPN    
systemctl start openvpn@server
 
### 2.安装iptables
yum -y install iptables iptables-services
 
### 3.添加策略
vim /etc/sysconfig/iptables  
########################### 配置信息 ###########################
-A INPUT -p tcp -m state --state NEW -m tcp --dport 22 -j ACCEPT
添加：-A INPUT -p tcp -m state --state NEW -m tcp --dport 1194 -j ACCEPT
########################### 配置信息 ###########################

### 4.开启端口
systemctl restart iptables.service
iptables -F
iptables -t nat -A POSTROUTING -s 10.8.0.0/24  -j MASQUERADE

### 5.开启转发
vim /etc/sysctl.conf
########################### 配置信息 ###########################
net.ipv4.ip_forward = 1
########################### 配置信息 ###########################
sysctl -p

## 七、开机启动
chmod +x /etc/rc.d/rc.local

### 添加启动脚本
vim /etc/rc.d/rc.local
########################### 配置信息 ###########################
## OpenVPN
systemctl restart openvpn@server
systemctl restart iptables.service
iptables -F
iptables -t nat -A POSTROUTING -s 10.8.0.0/24  -j MASQUERADE
sysctl -p
########################### 配置信息 ###########################




## 客户端配置来设置是否全走 VPN
########################### 配置信息 ###########################
client
remote 58.246.52.42 8294
proto tcp
dev tun
comp-lzo
ca ca.crt
cert client.crt
key client.key
route-delay 2
route-method exe

#redirect-gateway def1
#dhcp-option DNS  210.22.84.3
#dhcp-option DNS 8.8.8.8
#dhcp-option DNS 8.8.4.4
#dhcp-option DNS 4.2.2.1
route 0.0.0.0 0.0.0.0 net_gateway

verb 3

########################### 配置信息 ###########################


########################### 配置信息 ###########################

port 1194
proto tcp
dev tun
 
ca /etc/openvpn/ca.crt
cert /etc/openvpn/server.crt
key /etc/openvpn/server.key
dh /etc/openvpn/dh.pem
crl-verify /etc/openvpn/crl.pem

ifconfig-pool-persist /etc/openvpn/ipp.txt
 
server 10.8.0.0 255.255.255.0
push "route 10.8.0.0 255.255.255.0"
push "route 192.168.1.0 255.255.255.0 vpn_gateway"
push "route 0.0.0.0 0.0.0.0 net_gateway"

#push "redirect-gateway def1 bypass-dhcp"
#push "dhcp-option DNS 114.114.114.114"
#push "dhcp-option DNS 8.8.8.8"


client-to-client
 
keepalive 20 120
comp-lzo
 
user openvpn
group openvpn
 
persist-key
persist-tun
status      openvpn-status.log
log-append  openvpn.log
verb 1
mute 20


########################### 配置信息 ###########################