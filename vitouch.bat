@echo off
scriptcs %~dp0touch.csx -C -- %*
code %1
