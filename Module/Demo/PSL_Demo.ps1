Import-Module ..\PowerShellLogging

$LogFile = Enable-LogFile #-Path C:\Log\ScriptName_Log_$(Get-Date -Format "yyyy-MM-dd_HHmmss").txt

Write-Host "REX"

rex

Write-Host "REX"
