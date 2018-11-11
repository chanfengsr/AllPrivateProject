;= @echo off
;= rem Call DOSKEY and use this file as the macrofile
;= %SystemRoot%\system32\doskey /listsize=1000 /macrofile=%0%
;= rem In batch mode, jump to the end of the file
;= goto:eof
;= Add aliases below here
e.=explorer .
gl=git log --oneline --all --graph --decorate  $*
ls=ls --show-control-chars -F --color $*
clear=cls
history=cat "%CMDER_ROOT%\config\.history"
unalias=alias /d $1
vi=vim $*
cmderr=cd /d "%CMDER_ROOT%"

initPath=echo cmd /k "%ConEmuDir%\..\init.bat"  -new_console:d:R:\
pwd=echo VPS:fdhg9901314 & echo BIN:K4BWB2+R & echo Sonepar:P@ssword01 & echo SAG:Chanfengsr026!
edit=EditPlus /n
bcomp="%Software%\ExtractProgram\Beyond Compare\BCompare.exe"
vps=ssh root@45.77.22.199
inet=inetcpl.cpl
ncpa=ncpa.cpl
sysdm=sysdm.cpl

bcomp0=echo 1 > 1.txt & echo 2 > 2.txt
bcomp1="%Software%\ExtractProgram\Beyond Compare\BCompare.exe" 1.txt 2.txt
config=EditPlus "%CMDER_ROOT%\config\user_aliases.cmd"
wx="C:\Program Files (x86)\Tencent\WeChat\WeChat.exe"
qq="C:\Program Files (x86)\Tencent\TIM\Bin\QQScLauncher.exe"
music="C:\Program Files (x86)\Netease\CloudMusic\cloudmusic.exe"
skype="C:\Program Files (x86)\Microsoft\Skype for Desktop\Skype.exe"
ie="C:\Program Files\Internet Explorer\iexplore.exe"
repOutlook="C:\Program Files\Microsoft Office\Office16\OUTLOOK.EXE /safe"
gitExt="C:\Program Files (x86)\GitExtensions\GitExtensions.exe"
miaosu="%Software%\ExtractProgram\MiaoSS√ÓÀŸ\MiaoSS√ÓÀŸ.exe"

proj=explorer %Project%
allGit=explorer %Project%\AllInGitHub
son=explorer %Project%\AX\Sonepar
bin=explorer %Project%\AX\BIN
quant=explorer %Project%\AX\QUANT
maz=explorer %Project%\AX\Mazak
hoya=explorer %Project%\AX\HOYA
dan=explorer %Project%\AX\DAN

.build=dotnet build --runtime win-x64
pGeekTime=cd /d "%Project%\AllInGitHub\DoNetCore\geekTime"
gt1="%Project%\AllInGitHub\DoNetCore\geekTime\bin\Debug\netcoreapp2.1\win-x64\geekTime.exe"