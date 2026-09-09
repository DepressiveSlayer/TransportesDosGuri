# Transportes dos Guri 🚌✈️

O **Transportes dos Guri** é uma plataforma desenvolvida para a gestão e venda de passagens e reservas de viagens (aéreas e terrestres), oferecendo um fluxo de agendamento integrado com pagamento via Pix e Boleto através do gateway Asaas.

Este repositório contém o esqueleto estrutural do MVP (Minimum Viable Product), desenvolvido como atividade prática da disciplina de **Programação IV**.

---

## 👨‍🎓 Informações Acadêmicas

* **Grupo:** Thiago Wurster Balbinot, Thiago Thomasi, Mateus Ferreira da Silva e Rhyan Mezaroba
* **Instituição:** Universidade do Oeste de Santa Catarina (UNOESC)
* **Curso:** Ciência da Computação
* **Disciplina:** Programação IV
* **Professor:** Roberson Junior Fernandes Alves
* **Semestre Letivo:** 2026/02

---

## 🛠️ Stacks

O projeto adota uma arquitetura desacoplada seguindo os princípios de **Clean Architecture**:

* **Backend:** .NET 10 (C#) Web API
  * **Persistência / ORM:** Dapper (Consultas/Comandos de alto desempenho) + Entity Framework Core (Identity / Autenticação)
  * **Autenticação:** ASP.NET Core Identity + JWT (JSON Web Tokens)
  * **Integração Externa:** Gateway Asaas (Cobranças Pix/Boleto e Clientes)
  * **Documentação:** OpenAPI / Swagger
* **Frontend:** Blazor WebAssembly (.NET 10 / WebAssembly)
  * **UI Framework:** MudBlazor / Tailwind CSS
  * **Gerenciamento de Estado:** Services com `HttpClient` injetado
* **Banco de Dados:** Microsoft SQL Server

---

## 📂 Estrutura de Pastas do Repositório

```text
TransportesDosGuri/
├── README.md
├── .gitignore
│
├── TransportesDosGuriBackend/
│   ├── TransportesDosGuri.API/   
│   ├── TransportesDosGuri.Core/             
│   └── TransportesDosGuri.Infrastructure/       
│
└── TransportesDosGuriDatabase/
│
├── TransportesDosGuriFrontend/
                        
