rem dotnet test --filter TestCategory=Exchanges
rem dotnet test --filter FullyQualifiedName~TestCryptoApiSdk.Exchanges.Test --results-directory TestResults --logger trx --verbosity detailed
dotnet test --filter FullyQualifiedName~TestCryptoApiSdk.Exchanges.Test --results-directory ..\TestResults --logger trx --verbosity quiet
dotnet test --filter FullyQualifiedName~TestCryptoApiSdk.Exchanges.Test2 --results-directory ..\TestResults --logger trx --verbosity quiet