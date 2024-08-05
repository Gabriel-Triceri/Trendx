# Trendx
Teste pratico c# Trendx (Realização do Crud com banco de dados My server)

### Principais Funcionalidades
- **Cadastrar Tarefas**: Adiciona novas Tarefas ao sistema.
- **Visualizar Tarefas**: Permite a consulta de todas as Tarefas cadastrados ou uma específicada pelo ID.
- **Atualizar Tarefas**: Atualiza informações de uma tarefa existente pelo ID.
- **Deletar Tarefas**: Remove uma tarefa do sistema pelo ID.

## 🚀 Como Executar o Projeto
### Pré-Requisitos
Para executar este projeto, você precisará:
- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- Um sistema de gerenciamento de banco de dados Sql Server
- Visual Studio ou outro editor de código que suporte C# e ASP.NET Core

### Passos para Execução
1. **Clone o Repositório**
```bash
   git clone <url-do-repositorio>
   cd <pasta-do-projeto>
```

2. **Configurar a String de Conexão**

3. Abra o arquivo appsettings.json.

4. Modifique a string de conexão SqlServerConnection para apontar para seu banco de dados Sql Server.

5. **No terminal ou no console de comando do Visual Studio, execute:**
```bash
dotnet ef database update
``` 

6. **Iniciar o Projeto**

7. **Ao rodar a aplicação, será aberto uma guia do seu navegador padrão com o swagger configurado para testar as requisições.**

8. **Acessar a API via Swagger**


## 📝 Endpoints para Teste

### **Endpoint de GET**
- GET /api/task: Retorna uma lista de todas as Tarefas.
- GET /api/task/{id}: Retorna uma Tarefa específica pelo ID.

### **Endpoint de POST**
- POST /api/task: Cria uma nova Tarefa. Requer um corpo de solicitação com os detalhes da Tarefa.

### **Endpoint de PUT**
- PUT /api/task/{id}: Atualiza uma Terefa existente. Requer o ID da Tarefa e um corpo de solicitação com os detalhes atualizados.

### **Endpoint de DELETE**
- DELETE /api/task/{id}: Deleta uma Tarefa pelo ID.

### Autores
---
- <sub><b>RM97121 - Gabriel Tricerri André Niacaris</b></sub>

