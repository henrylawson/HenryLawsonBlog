get-module psake | remove-module
import-module .\packages\psake.4.2.0.1\tools\psake.psm1
invoke-psake .\..\Build\psake.ps1