cd /etc/yum.repos.d/
wget http://mirrors.aliyun.com/repo/Centos-7.repo
mv CentOs-Base.repo CentOs-Base.repo.bak
mv Centos-7.repo CentOs-Base.repo
yum clean all
yum makecache
yum update
