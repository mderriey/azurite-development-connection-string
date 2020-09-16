# Using Azurite with the development connection string

Steps:

1. Install Azurite &mdash; I used the [npm method](https://docs.microsoft.com/en-us/azure/storage/common/storage-use-azurite#install-and-run-azurite-by-using-npm) and have v3.8.0 installed;
1. Start Azurite &mdash; Run `azurite --location '<repo-root>/.azurite'`;
1. Run the .NET Core console app in the `src/AzureDevelopmentConnectionString` directory;
1. Expected outcome is no exceptions thrown and the first 8 characters of a GUID should be printed to the console.
