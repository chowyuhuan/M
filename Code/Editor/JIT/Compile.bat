@echo off
set mcs=%1\Mono\bin\gmcs.bat
REM ���Թ����ڲ����ű��Ƴ�Assets�������ƶ���WebplayerTemplates�£�������£����������DLL����Assets�´�Сһ�£������Ǳ��ظ���warning���ʲ��Ƴ��ű�ֱ�ӱ����ˣ�ǰ���Ǳ������JITDLL.DLLҪ����ScriptAssemblies��Unity���Ὣ���ļ����µ�DLL���룬����ŵ������ļ��У�����Plugins�ᱨ�ظ��������
set scripts=%~dp0..\..\JITDLL\*.cs
set UnityEngine=%~dp0..\..\..\..\Library\UnityAssemblies\UnityEngine.dll
set UnityEngineUI=%~dp0..\..\..\..\Library\UnityAssemblies\UnityEngine.UI.dll
set AssemblyCSharp=%~dp0..\..\..\..\Library\ScriptAssemblies\Assembly-CSharp.dll
set OutPut=%~dp0%3\JITDLL.dll
if not exist %~dp0..\..\..\..\Logs\CompileDLL (md %~dp0..\..\..\..\Logs\CompileDLL)
if %time:~0,2% leq 9 (set hour=0%time:~1,1%) else (set hour=%time:~0,2%)
set LogFile=%~dp0..\..\..\..\Logs\CompileDLL\%date:~0,4%%date:~5,2%%date:~8,2%_%hour%_%time:~3,2%_%time:~6,2%.log

@echo ------------------------------- ����ָ�� ------------------------------------ >> %LogFile%
@echo %mcs% -target:library -define:%2 -reference:%UnityEngine%,%UnityEngineUI%,%AssemblyCSharp% -out:%OutPut% -optimize -unsafe -recurse:%scripts% >> %LogFile%
@echo ------------------------------- ������־ ------------------------------------ >> %LogFile%
%mcs% -target:library -define:%2 -reference:%UnityEngine%,%UnityEngineUI%,%AssemblyCSharp% -out:%OutPut% -nowarn:436 -optimize -unsafe  -recurse:%scripts% >> %LogFile% 2>&1
@echo ----------------------------------------------------------------------------- >> %LogFile%
exit /b %ErrorLevel%