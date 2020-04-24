@echo off
scriptcs %~dp0touch.csx -C -- %* %cd%
code %1
