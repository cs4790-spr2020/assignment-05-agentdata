#powershell script to cleanup obj and bin folders

dotnet clean .\BlabberApp.sln

$locations = (
"./BlabberApp.DataStore/obj/",
"./BlabberApp.Console/obj/",
"./BlabberApp.WebApi/obj/",
"./BlabberApp.Client/obj/",
"./BlabberApp.Domain/obj/",
"./BlabberApp.DomainTest/obj/",
"./BlabberApp.DataStoreTest/obj/",
"./BlabberApp.Services/obj",
"./BlabberApp.DataStore/bin/",
"./BlabberApp.DomainTest/bin/",
"./BlabberApp.Domain/bin/",
"./BlabberApp.Console/bin/",
"./BlabberApp.WebApi/bin/",
"./BlabberApp.Client/bin/",
"./BlabberApp.Services/bin",
"./BlabberApp.DataStoreTest/bin/",
"./BlabberApp.DataStoreTest/TestResults/",
"./BlabberApp.DomainTest/TestResults/",
"./BlabberApp.ServicesTest/TestResults/")

function purge($path)
{
    if(Test-Path $path)
    {
        Remove-Item -Recurse $path;
        Write-Output ($path+" removed successfully");
    }
    else
    {
        Write-Output ($path+" not found");
    }
}


foreach($location in $locations)
{
    purge($location);
}