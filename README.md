# PUCH5

Azure Functions HTTP Trigger Project (C#)

## Opis projektu

Ten projekt zawiera prostą funkcję Azure Functions z wyzwalaczem HTTP, która zwraca odpowiedź w formacie JSON.

## Wymagania

- .NET 8.0 SDK
- Azure Functions Core Tools v4
- Azure CLI (do wdrożenia)

## Struktura projektu

```
HttpFunctionApp/
├── HelloFunction.cs      # Funkcja HTTP zwracająca JSON
├── Program.cs            # Punkt wejścia aplikacji
├── host.json             # Konfiguracja hosta
├── local.settings.json   # Ustawienia lokalne
└── HttpFunctionApp.csproj # Plik projektu
```

## Uruchomienie lokalne

1. Przejdź do katalogu projektu:
   ```bash
   cd HttpFunctionApp
   ```

2. Przywróć pakiety NuGet:
   ```bash
   dotnet restore
   ```

3. Zbuduj projekt:
   ```bash
   dotnet build
   ```

4. Uruchom lokalnie:
   ```bash
   func start
   ```

5. Funkcja będzie dostępna pod adresem:
   ```
   http://localhost:7071/api/Hello
   ```

## Testowanie

Wywołaj funkcję HTTP za pomocą przeglądarki lub curl:

```bash
curl http://localhost:7071/api/Hello
```

Przykładowa odpowiedź JSON:
```json
{
  "message": "Hello from Azure Functions!",
  "timestamp": "2024-01-01T12:00:00Z",
  "status": "success"
}
```

## Wdrożenie do Azure Portal

1. Zaloguj się do Azure CLI:
   ```bash
   az login
   ```

2. Utwórz grupę zasobów (jeśli nie istnieje):
   ```bash
   az group create --name myResourceGroup --location westeurope
   ```

3. Utwórz konto magazynu:
   ```bash
   az storage account create --name mystorageaccount --location westeurope --resource-group myResourceGroup --sku Standard_LRS
   ```

4. Utwórz aplikację funkcji:
   ```bash
   az functionapp create --resource-group myResourceGroup --consumption-plan-location westeurope --runtime dotnet-isolated --functions-version 4 --name myFunctionApp --storage-account mystorageaccount
   ```

5. Opublikuj aplikację:
   ```bash
   cd HttpFunctionApp
   func azure functionapp publish myFunctionApp
   ```

## Alternatywne wdrożenie przez Azure Portal

1. Zaloguj się do [Azure Portal](https://portal.azure.com)
2. Utwórz nowy zasób "Function App"
3. Wybierz:
   - Runtime: .NET 8 (Isolated)
   - Operating System: Linux lub Windows
   - Plan: Consumption
4. Po utworzeniu, przejdź do "Deployment Center"
5. Skonfiguruj wdrożenie z GitHub lub użyj ZIP deploy