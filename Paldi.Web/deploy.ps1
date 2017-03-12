$path = $env:APPLICATION_PATH
if (!$path) {
    $path = $PSScriptRoot
}

& $path\bin\FluentMigrator.1.6.2\Migrate.exe `
    -a $path\bin\Paldi.Web.Migrations.dll `
    --db MySQL `
    --configPath $path\Web.config `
    -c DefaultConnection