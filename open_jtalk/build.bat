@echo off
setlocal
set param="-Dcharset=utf_8"
rem set param="-Dcharset=utf_8" "-DBIN_INSTALL_PREFIX=c:/open_jtalk" "-DDATA_INSTALL_PREFIX=c:/open_jtalk"
set VER=2019
rem download & decompression
bash prepare>NUL
if "%errorlevel%"=="-1" ( 
    if not exist voice\ (
        echo WSL���C���X�g�[������Ă���ƁAbash parepare�ŕK�v�ȃA�[�J�C�u�̃_�E�����[�h�ƓW�J�������ōs���܂��B
        goto :exit
    )
)
:arch_top
if "%1"=="x86" (
    set ARCH=x86
    set BATNAME=vcvars32
    goto :arch_skip
)
if "%1"=="x64" (
    set ARCH=x64
    set BATNAME=vcvars64
    if %PROCESSOR_ARCHITECTURE% == x86 set BATNAME=vcvarsx86_amd64
    goto :arch_skip
)
if %PROCESSOR_ARCHITECTURE% == x86 (
    set ARCH=x86
    set BATNAME=vcvars32
) else (
    set ARCH=x64
    set BATNAME=vcvars64
)
:arch_skip

rem ****************************************
rem call vcvars.bat
rem ****************************************
if %PROCESSOR_ARCHITECTURE% == x86 set ProgramFiles(x86)=C:\Program Files
set INSTANCENAME=Community
set BAT="%ProgramFiles(x86)%\Microsoft Visual Studio\%VER%\%INSTANCENAME%\VC\Auxiliary\Build\%BATNAME%.bat"
if exist %BAT% goto :call_batch
set INSTANCENAME=BuildTools
set BAT="%ProgramFiles(x86)%\Microsoft Visual Studio\%VER%\%INSTANCENAME%\VC\Auxiliary\Build\%BATNAME%.bat"
if exist %BAT% goto :call_batch
set INSTANCENAME=Professional
set BAT="%ProgramFiles(x86)%\Microsoft Visual Studio\%VER%\%INSTANCENAME%\VC\Auxiliary\Build\%BATNAME%.bat"
if exist %BAT% goto :call_batch
set INSTANCENAME=Enterprise
set BAT="%ProgramFiles(x86)%\Microsoft Visual Studio\%VER%\%INSTANCENAME%\VC\Auxiliary\Build\%BATNAME%.bat"
if not exist %BAT% goto :error_batch
goto :call_batch
:error_batch
echo Visual Studio Community %VER% �܂��� Build Tools for Visual Studio %VER% ���C���X�g�[�����Ă�����s���Ă��������B
echo �������́Abuild.bat�̎O�s�ڂ�set VER=%VER%�̒l�����������ĉ������B
goto :exit
:call_batch
call %BAT%
cd /d %~dp0
rem ****************************************
rem search cmake.exe
rem ****************************************
(cmake 2>&1)>NUL
if errorlevel 9009 (
    echo �G���[�F���̃R���s���[�^��CMake��������܂���B�C���X�g�[�����Ă��������B
    echo �C���X�g�[�����Ă���̂Ɍ�����Ȃ���΁APATH��ʂ��Ă��������B
    goto :exit
)
rem ****************************************
rem build
rem ****************************************
set build_dir=build%ARCH%.dir
if exist ..\incbuild.bat call ..\incbuild.bat
if not exist "%build_dir%" mkdir %build_dir%
cd %build_dir%
cmake .. -G "NMake Makefiles" %param%
rem nmake clean
nmake install
cd ..
rem ****************************************
rem exit
rem ****************************************
:exit
set /p=�L�[�������ƏI�����܂�<NUL
pause >NUL
echo.
