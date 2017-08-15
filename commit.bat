@echo off
set /p message="Message for changes: "

git add -A
git commit -m "%message%"

PAUSE