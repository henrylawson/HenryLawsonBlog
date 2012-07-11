Properties {
	$build_dir = Split-Path $psake.build_script_file	
	$artifacts_dir = Join-Path $build_dir "\..\Artifacts"
	$source_dir = Join-Path $build_dir "\..\Source\"
    $solution_file = Join-Path $source_dir "\HenryLawsonBlog.sln"
    $nunit_runners_dir = Join-Path $source_dir "\packages\NUnit.Runners.2.6.0.12051\tools"
    $env:Path += ";$nunit_runners_dir"
}

FormatTaskName (("-"*25) + "[{0}]" + ("-"*25))

Task Default -Depends BuildApp

Task BuildApp -Depends Clean, Build, Test

Task Build -Depends Clean {	
    Write-Host $psake.build_script_file
	Write-Host "Building Solution"
	Exec { msbuild "$solution_file" /t:Build /p:Configuration=Release /v:quiet /p:OutDir=$artifacts_dir } 
}

Task Clean {
	Write-Host "Creating Artifacts directory"
	if (Test-Path $artifacts_dir) 
	{	
		rd $artifacts_dir -rec -force | out-null
	}
	mkdir $artifacts_dir | out-null
}

Task Test {
	Write-Host "Executing tests"
    $test_assembly_file = Join-Path $artifacts_dir "\Blog.Tests.dll"
	$output_file = JOin-Path $artifacts_dir "\TestResult.xml"
	$error_file = JOin-Path $artifacts_dir "\TestResultError.xml"
	exec { nunit-console.exe "$test_assembly_file" /nologo }
}