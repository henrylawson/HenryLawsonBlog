Properties {
	$build_dir = Split-Path $psake.build_script_file	
	$artifacts_dir = Join-Path $build_dir "\..\Artifacts"
	$source_dir = Join-Path $build_dir "\..\Source\"
    $solution_file = Join-Path $source_dir "\HenryLawsonBlog.sln"
}

FormatTaskName (("-"*25) + "[{0}]" + ("-"*25))

Task Default -Depends BuildApp

Task BuildApp -Depends Clean, Build

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