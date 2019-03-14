@echo off
set RTSP="rtsp://admin:tengke1234@192.168.1.164:554/live1.sdp"
set RTMP="rtmp://video-center-bj.alivecdn.com/AppTest/StreamTest?vhost=live.51tanker.com&auth_key=1529487156-0-0-87af30338eae605654e3fa2ef479136e"
echo 启动直播推流程序CGPushStream.exe
start "" "%~dp0CGPushStream.exe" %RTSP% %RTMP% &
echo 已启动
for /f "delims=, tokens=1,2" %%a in ('tasklist /fo csv /nh') do (
set "%%~a_pid=%%~b"
)
echo [CGPushStream.exe]的PID为: %CGPushStream.exe_pid%