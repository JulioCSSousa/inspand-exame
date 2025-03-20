# INSPAND Developers Exam Full Stack #

### O que é este projeto

Este projeto visa avaliar os conhecimentos do desenvolvedor e seu entendimento sobre a arquitetura proposta. Existem funcionalidades não implementadas que ficam a cargo do candidato desenvolver.

### Resumo do projeto

O projeto está dividido em 2 partes:
* Back-end
  * Projeto construído em .NET Core **versão 9.0.102**, com arquitetura inspirada em **Clean Architecture**, contendo 3 sub-projetos:
    * Domain
    * Infrastructure
    * Web
* Front-end
  * Projeto construído em Vue.js **versão 3.5.14**

### Observações

- O banco de dados utilizado é o SQL Server. Caso não o tenha instalado, você pode usar o Docker Compose fornecido.
- Alternativamente, você pode utilizar outra instância do SQL Server de sua preferência e enviar o arquivo .sql junto ao projeto (caso utilize database first).

Utilitários:
- Um arquivo Docker Compose está disponível para facilitar a configuração do SQL Server (este conhecimento não será avaliado).

### Expectativas

- Implementação do desafio proposto
- Feedback sobre o projeto
- Análise da sua forma de codificação (não há problema se não conseguir finalizar tudo no tempo determinado)

### Desafio

Como administrador, desejo poder:
- Listar livros cadastrados na plataforma na home page
- Realizar operações de criação, edição e exclusão de livros

Para o cadastro de livros, são necessários os seguintes dados obrigatórios:
- Título
- Autor
- Descrição

Funcionalidade adicional (não obrigatória):
- Envio de e-mail para developers@inspand.com.br ao cadastrar um novo livro

**Critérios de aceite:**
- Não podem existir livros com títulos duplicados (exibir mensagem informativa)
- Título e autor devem ter entre 10 e 100 caracteres (exibir mensagem de validação)
- A descrição deve ter no máximo 1024 caracteres (exibir mensagem quando exceder)

**Observação:**
Para o envio de e-mail, implemente apenas a chamada do evento responsável pela ação, sem necessidade de implementar o envio efetivo.

### Feedback Esperado

Como parte da avaliação, forneça seu entendimento sobre cada camada do projeto:
1. Qual o papel da camada Domain?
 Resposta: A camada Domain contém o núcleo da lógica de negócio e define todas as entidades, objetos de valor, agregados, interfaces e regras relacionadas ao domínio do negócio.
3. Qual o papel da camada Infrastructure?
 Resposta: A camada Infrastructure é responsável por lidar com detalhes técnicos externos, como persistência (acesso a banco de dados), chamadas externas a APIs, integração com serviços externos, logging, envio de e-mails, etc.
5. Qual o papel da camada WebApp?
Resposta: A camada WebApp é a camada de apresentação da aplicação, geralmente um projeto Web (ASP.NET MVC ou APIs) que interage diretamente com o usuário final ou com consumidores de APIs.
7. Aponte um ponto de melhoria que considere relevante no projeto.
- Não sei dizer
### Regras

O candidato terá **5 horas** para desenvolvimento e feedback.

**Boa Prova!**

O **Sucesso!** pode ser aquilo que você é grato por ter conquistado ! :smile:

Powered by **INSPAND Developers**
