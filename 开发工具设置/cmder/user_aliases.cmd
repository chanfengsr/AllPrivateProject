;= @echo off
;= rem Call DOSKEY and use this file as the macrofile
;= %SystemRoot%\system32\doskey /listsize=1000 /macrofile=%0%
;= rem In batch mode, jump to the end of the file
;= goto:eof
;= Add aliases below here

;= VSCode 打开
;= CRLF, 编码 gb2312

;=Path 环境变量
;=C:\Program Files\wkhtmltopdf\bin
;=D:\Software\ExtractProgram\ffmpeg\bin
;=D:\Software\ExtractProgram\EditPlus3\x64
;=D:\Software\ExtractProgram\Beyond Compare

;=新建环境变量
;=Project
;=WorkProject
;=Software



e.          = explorer .
gl          = git log --oneline --all --graph --decorate  $*
ls          = ls --show-control-chars -F --color $*
clear       = cls
history     = cat "%CMDER_ROOT%\config\.history"
unalias     = alias /d $1
vi          = vim $*
cmderr      = cd /d "%CMDER_ROOT%"

initPath    = echo cmd /k "%ConEmuDir%\..\init.bat"  -new_console:d:R:\
dns         = echo 210.22.70.3 & echo 210.22.84.3
re          = echo "/* 注释行 */:    ^/\*.*\*/$" & echo "空白行      :    ^\s*$"
edit        = EditPlus /n
bcomp       = "%Software%\ExtractProgram\Beyond Compare\BCompare.exe"
vps         = ssh root@45.77.22.199
inet        = inetcpl.cpl
ncpa        = ncpa.cpl
sysdm       = sysdm.cpl

;= 先要切成管理员模式运行
host        = notepad %windir%\System32\drivers\etc\hosts & echo explorer %windir%\System32\drivers\etc

bcomp0      = echo 1 > 1.txt & echo 2 > 2.txt
bcomp1      = "%Software%\ExtractProgram\Beyond Compare\BCompare.exe" 1.txt 2.txt
config      = EditPlus "%CMDER_ROOT%\config\user_aliases.cmd"
wx          = "C:\Program Files (x86)\Tencent\WeChat\WeChat.exe"
qq          = "D:\Program Files (x86)\Tencent\TIM\Bin\QQScLauncher.exe"
wxqq        = "C:\Program Files (x86)\Tencent\WeChat\WeChat.exe" & "D:\Program Files (x86)\Tencent\TIM\Bin\QQScLauncher.exe"
sb          = "C:\Program Files (x86)\Tencent\WeChat\WeChat.exe" & "D:\Program Files (x86)\Tencent\TIM\Bin\QQScLauncher.exe" & "C:\Program Files (x86)\Microsoft Office\root\Office16\OUTLOOK.EXE"
music       = "C:\Program Files (x86)\Netease\CloudMusic\cloudmusic.exe"
skype       = "C:\Program Files (x86)\Microsoft\Skype for Desktop\Skype.exe"
ie          = "C:\Program Files\Internet Explorer\iexplore.exe"
repOutlook  = "C:\Program Files (x86)\Microsoft Office\root\Office16\OUTLOOK.EXE /safe"
gitExt      = "C:\Program Files (x86)\GitExtensions\GitExtensions.exe"
msu         = "%Software%\ExtractProgram\MiaoSS妙速\MiaoSS妙速.exe" & choice /t 15 /d y /n > nul & %Project%\AllPrivateProject\BatchShell\ClearProxy.bat
Dism        = "%Software%\ExtractProgram\Dism\Dism++x64.exe"
dict        = "%AppData%\..\Local\youdao\dict\Application\YoudaoDict.exe"
vs          = "C:\Program Files (x86)\Microsoft Visual Studio 10.0\Common7\IDE\devenv.exe"
pyc         = pycharm64.exe
st          = shutdown -s -t 60
st0         = shutdown -s -t 0
sta         = shutdown -a
startSQL    = net start MSSQLSERVER

syncConfig  = copy /y %CMDER_ROOT%\config\user_aliases.cmd "%Project%\AllPrivateProject\开发工具设置\cmder\"
compConfig  = "%Software%\ExtractProgram\Beyond Compare\BCompare.exe" "%CMDER_ROOT%\config\user_aliases.cmd" "%Project%\AllPrivateProject\开发工具设置\cmder\user_aliases.cmd"

.build      = dotnet build --runtime win-x64 & cd .\bin\Debug\netcoreapp2.1\win-x64
.play       = dotnet new console --name play & code .\play
playPy      = md playPy & echo print('play') > .\playPy\play.py & code .\playPy\
gtFile      = explorer %OneDrive%\同步资料\极客时间
gtInit      = md HTML & md PDF & md 音频 & echo List > List.txt & type "%OneDrive%\同步资料\极客时间\1.txt"
clrProxy    = %Project%\AllPrivateProject\BatchShell\ClearProxy.bat
clrBC       = del /q %AppData%\BCompare\*.* & del /q "%AppData%\Scooter Software\Beyond Compare 4\*.*"
kIDM        = taskkill /im IDMan.exe /f
JQB         = dotnet run -p %Project%\AllPrivateProject\DoNetCore\JQB
kl          = %Project%\AllPrivateProject\Python\MyScraping\venv\Scripts\activate.bat & python %Project%\AllPrivateProject\Python\MyScraping\Play\ScrapWeibo.py & deactivate & cls
bDown       = dotnet run -p %Project%\AllPrivateProject\DoNetCore\bDown & ffmpegCvtFlv.bat

one         = explorer %onedrive%
soft        = explorer %software%
proj        = explorer %WorkProject%
gitAll      = explorer %Project%\AllPrivateProject
leetcode    = explorer %Project%\AllPrivateProject\Python\LeetCodeTraining\题库

;= For Work
axNote      = notepad "%WorkProject%\AX\AX Note.txt"

ske         = explorer %WorkProject%\SKE
son         = explorer %WorkProject%\AX\Sonepar
bin         = explorer %WorkProject%\AX\BIN
quant       = explorer %WorkProject%\AX\QUANT
mzk         = explorer %WorkProject%\AX\Mazak\AXProject
hoya        = explorer %WorkProject%\AX\HOYA
dan         = explorer %WorkProject%\AX\DANCN
kit         = explorer %WorkProject%\AX\大连京瓷

gitSAG      = explorer %Project%\SAGGitHub\SAG
sql         = "D:\Program Files (x86)\Microsoft SQL Server\140\Tools\Binn\ManagementStudio\Ssms.exe"

rm30        = mstsc /v:192.168.1.30
rm70        = mstsc /v:192.168.1.70
rm71        = mstsc /v:192.168.1.71
rm82        = mstsc /v:192.168.1.82
rmSonUAT    = mstsc /v:172.20.3.64
rmSonSTG    = mstsc /v:172.20.3.11
rmSKE       = mstsc /v:q204h49620.51mypc.cn:55066
rmMzk       = mstsc /v:mazak-dev01.eastus.cloudapp.azure.com

ssh98       = ssh -p 9822 root@58.246.52.42

pwd         = type "%Project%\AllPrivateProject\Info\pwdList.txt"
skePwd      = type "%Project%\AllPrivateProject\Info\ske.txt"
ffHelp      = echo TS 转 MP4 & echo ffmpeg -y -i r:\1.ts -vcodec copy -acodec copy -vbsf h264_mp4toannexb r:\1.mp4 & echo flv 转 MP4 & echo ffmpeg -i 1.flv -vcodec copy -acodec copy 1.mp4 & echo m4a 转 aac mp3 & echo ffmpeg -i input.m4a -acodec copy output.aac & echo ffmpeg -i input.m4a -codec:a libmp3lame -qscale:a 2 output.mp3 & echo 合并 flv & echo ffmpeg -i "concat:1.flv|2.flv|3.flv|4.flv" -c copy all.flv & echo for %a in ("*") do ffmpeg -i "%a" -vcodec copy -acodec copy "r:\mp4\%~na.mp4" & echo mkv 转 MP4 & echo ffmpeg -i 1.mkv -c:v copy -c:a opus -strict experimental 1.mp4
mdHelp      = code %Project%\AllPrivateProject\Markdown\