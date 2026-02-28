# Cloud Task Manager (2026)

Ten projekt jest aplikacją chmurową realizowaną w architekturze 3-warstwowej.

**Autor:** Piotr Wróblewski
**Nr albumu:** 57207

## Deklaracja Architektury (Mapowanie Azure)

| Warstwa | Komponent Lokalny | Usługa Azure |
|---|---|---|
| Prezentacja | React 19 (Vite) | Azure Static Web Apps |
| Aplikacja | Node.js / Express | Azure App Service |
| Dane | SQL Server (Dev) | Azure SQL Database (Serverless) |

## Status Projektu
* [x] **Artefakt 1:** Zaplanowane struktury folderów i diagram C4 (dostępny w /docs).
* [x] **Artefakt 2:** Środowisko wielokontenerowe uruchomione lokalnie (Docker Compose).