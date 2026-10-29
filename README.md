# 📱 Contacter

**Contacter** è un'applicazione web sviluppata in **ASP.NET Core MVC** per la gestione sicura e centralizzata dei contatti personali. Il sistema si basa su un'architettura a strati che adotta il *Repository Pattern* e un *Service Layer* per disaccoppiare la logica di business dalla persistenza dei dati. Sfruttando Entity Framework Core e Microsoft SQL Server, il sistema garantisce un elevato standard di sicurezza grazie a un'autenticazione basata su cookie e alla crittografia irreversibile delle password tramite il `PasswordHasher` nativo di .NET, offrendo così una soluzione robusta, scalabile e manutenibile.

---

## 🛠️ Tecnologie Utilizzate

* **Framework:** .NET (ASP.NET Core MVC)
* **Accesso ai Dati (ORM):** Entity Framework Core (Database-First / Scaffolding)
* **Database:** Microsoft SQL Server (`DEV_CONTACTER`)
* **Autenticazione:** Cookie-based Authentication (`Microsoft.AspNetCore.Authentication.Cookies`)
* **Sicurezza:** Hashing delle password tramite `PasswordHasher<TUser>` (algoritmo PBKDF2)
* **Frontend:** Razor Views, Bootstrap 5

---

## 🏛️ Architettura del Progetto

Il progetto segue una **Clean Layered Architecture** per separare le responsabilità:

```text
Contacter/
│
├── Controllers/       # Gestione delle richieste HTTP e routing (AccountController, ContattiController)
├── Services/          # Logica di business e regole applicative (UtenteService, ContattoService)
├── Repositories/      # Astrazione delle query e accesso ai dati (UtenteRepository, ContattoRepository)
├── Models/            # Entità del database mappate con EF Core (Utenti, Contatti)
├── ViewModels/        # Oggetti per il trasferimento dei dati e validazione form (Login, Register)
└── Views/             # Interfaccia grafica utente in Razor (.cshtml)