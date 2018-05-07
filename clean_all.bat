@echo off
rem Removing all unneeded project's files.
echo.

echo Removing ".vs" directory.
rmdir /S /Q ".vs" 1>nul 2>nul
if not ErrorLevel 0 goto FAILURE

echo Removing "bin" directory.
rmdir /S /Q "bin" 1>nul 2>nul
if not ErrorLevel 0 goto FAILURE
rmdir /S /Q "UnitTests\bin" 1>nul 2>nul
if not ErrorLevel 0 goto FAILURE

echo Removing "obj" directory.
rmdir /S /Q "obj" 1>nul 2>nul
rmdir /S /Q "UnitTests\obj" 1>nul 2>nul
if not ErrorLevel 0 goto FAILURE

echo Removing "TestResults" directory.
rmdir /S /Q "TestResults" 1>nul 2>nul
if not ErrorLevel 0 goto FAILURE

echo.

:SUCCESS
echo Success.
goto END

:FAILURE
echo Failed.
goto END

:END
pause
