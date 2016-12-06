#
# Module manifest for module 'PSLogging'
#
# Generated by: Dave Wyatt
#
# Generated on: 8/3/2013
#

@{

# Script module or binary module file associated with this manifest.
ModuleToProcess = 'PowerShellLogging.psm1'

# Version number of this module.
ModuleVersion = '1.2.1'

# ID used to uniquely identify this module
GUID = '345320b5-bdc3-4ab6-a13e-fcb019362fe6'

CompanyName = 'Avanade Inc.'
CopyRight = 'Copyright 2016 Avanade Inc.'

# Author of this module
Author = 'Avanade Inc.'

# Description of the functionality provided by this module
Description = 'Captures PowerShell console output to a log file.'

# Minimum version of the Windows PowerShell engine required by this module
PowerShellVersion = '2.0'

# Minimum version of the .NET Framework required by this module
DotNetFrameworkVersion = '2.0'

# Modules to import as nested modules of the module specified in RootModule/ModuleToProcess
NestedModules = @('PowerShellLoggingModule.dll')

# Functions to export from this module
FunctionsToExport = '*'

# Cmdlets to export from this module
CmdletsToExport = '*'

# Variables to export from this module
VariablesToExport = '*'

# Aliases to export from this module
AliasesToExport = '*'

# List of all modules packaged with this module.
# ModuleList = @()

# List of all files packaged with this module
FileList = @('PowerShellLogging.psm1','PowerShellLogging.psd1','PowerShellLogginModule.dll','en-US\about_PowerShellLogging.help.txt','en-US\PowerShellLoggingModule.dll-help.xml')

}

