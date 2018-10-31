cccc;= @echo off
;= rem Call DOSKEY and use this file as the macrofile
;= %SystemRoot%\system32\doskey /listsize=1000 /macrofile=%0%
;= rem In batch mode, jump to the end of the file
;= goto:eof
;= Add aliases below here
e.=explorer .
gl=git log --oneline --all --graph --decorate  $*
ls=ls --show-control-chars -F --color $*
pwd=echo fdhg9901314
clear=cls
history=cat "%CMDER_ROOT%\config\.history"
unalias=alias /d $1
vi=vim $*
cmderr=cd /d "%CMDER_ROOT%"


edit=EditPlus
bcomp=BCompare
vps=ssh root@45.77.22.199
inet=inetcpl.cpl
ncpa=ncpa.cpl

bcomp0=echo 1 > 1.txt & echo 2 > 2.txt
bcomp1=BCompare 1.txt 2.txt
config=EditPlus "%CMDER_ROOT%\config\user-aliases.cmd"
wx="C:\Program Files (x86)\Tencent\WeChat\WeChat.exe"
qq="C:\Program Files (x86)\Tencent\TIM\Bin\QQScLauncher.exe"
music="C:\Program Files (x86)\Netease\CloudMusic\cloudmusic.exe"
miaosu="D:\Software\ExtractProgram\MiaoSS√ÓÀŸ\MiaoSS√ÓÀŸ.exe"
skype="C:\Program Files (x86)\Microsoft\Skype for Desktop\Skype.exe"
ie="C:\Program Files\Internet Explorer\iexplore.exe"
outlook="C:\Program Files\Microsoft Office\Office16\OUTLOOK.EXE /safe"

proj=explorer D:\Project
son=explorer D:\Project\AX\Sonepar
bin=explorer D:\Project\AX\BIN
quant=explorer D:\Project\AX\QUANT
maz=explorer D:\Project\AX\Mazak
hoya=explorer D:\Project\AX\HOYA
dan=explorer D:\Project\AX\DAN

.build=dotnet build --runtime win-x64


