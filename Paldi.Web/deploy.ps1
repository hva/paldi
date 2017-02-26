C:\Users\Public\FluentMigrator.1.6.2\tools\Migrate.exe `
    -a $env:APPLICATION_PATH\bin\Paldi.Web.Migrations.dll `
    --db MySQL `
    --configPath $env:APPLICATION_PATH\Web.config `
    -c DefaultConnection

# to run from solution root:
# packages\FluentMigrator.1.6.2\tools\Migrate.exe -a Paldi.Web\bin\Paldi.Web.Migrations.dll --db MySQL --configPath Paldi.Web\Web.config -c DefaultConnection