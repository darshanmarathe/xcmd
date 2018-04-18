@echo off
scriptcs %~dp0touch.csx -C -- %* %cd%
ls %1 -l
code .
