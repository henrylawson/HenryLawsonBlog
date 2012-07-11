function Get-ScriptDirectory
{
    $Invocation = (Get-Variable MyInvocation -Scope 1).Value
    Split-Path $Invocation.MyCommand.Path
}

get-module psake | remove-module
$psake_package_file = Join-Path (Get-ScriptDirectory) "\packages\psake.4.2.0.1\tools\psake.psm1"
$build_file = Join-Path (Get-ScriptDirectory) "\..\Build\psake.ps1"
import-module $psake_package_file
invoke-psake $build_file