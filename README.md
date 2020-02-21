# Plataforma integrada

Exercício feito com único propósito de ingresso no processo de seleção para oportunidade de desenvolvimento na Uppertools Tecnologia da Informação


# Justificativas

Os projetos foram desenvolvidos utilizando a IDE Visual Studio 2019 Community, no Sistema Operacional Windows 7.

Projeto CadastroEmpresaConsole:

Modelagem de classes: Foram feitas de acordo com resposta JSON da Web Service.
Consumo dos dados: Foi utilizada a biblioteca Refit para consumo dos dados, foi criada uma interface denominada EmpresaAPIService na qual serviu para buscar em um Web Service os dados em formato JSON de uma empresa a partir do Cnpj Informado. Também foi necessário o uso da biblioteca NewtonSoft.Json, em especial, [JsonProperty("NomeCampo")] para que os atributos das classes fossem atribuídos corretamente à resposta no formato JSON da Web Service.
Para esse projeto não foi implementado Banco de Dados, esse projeto apenas realiza a consulta na Web Service e mostra no Console alguns desses dados.
Esse projeto serviu como referência ao projeto CadastroEmpresaDesktop, logo suas classes e interface foram reaproveitadas.

Projeto CadastroEmpresaDesktop (Funcional):

Modelagem de classes: Foram referenciadas do projeto CadastroEmpresaConsole e com auxílio do Entity Framework (Code First) foram definidas as estruturas do banco de dados.
Banco de Dados: Foi utilizado o banco de dados local SQL Server Express, para realizar as seguintes funcionalidades: adição de uma empresa com parâmetro de entrada Cnpj, consulta a partir do Cnpj ou Nome e exclusão da empresa no banco de dados a partir de seu Cnpj. Para definir a banco de dados em qualquer computador basta acessar o console do gerenciador de pacotes da solução, selecionar o projeto CadastroEmpresaDesktop e digitar o comando “update-database”, que o banco de dados SQL Server Express, denominado como CadastroEmpresaDesktop.Context será criado.
Tela: A tela desse projeto contempla componentes como: bottons (que foram usados para disparar eventos e executar suas respectivas funções), TextBoxes (Para mostrar os Dados) e um MaskedTextBox (usado para inserção do Cnpj para garantir certos dados).
Validações: Antes da Inserção do registro e da consulta (ao Web Service) é feita uma validação do Cnpj para verificar sé é um número valido ou não, caso seja valido a aplicação tentará realizar essa operação, caso essa operação ocorra com sucesso o usuário será notificado, caso falhe uma mensagem de erro é informada ao usuário, falando sobre o erro. Possíveis erros que possam ocorrer: Não possuem dados desse Cnpj ou o Web Service esta offline.
Este foi o projeto que contempla os requisitos da atividade proposta.

Projeto CadastroEmpresaMVC:

Em seguida após concluir o Projeto CadastroEmpresaDesktop, tentei passar a mesma solução para um projeto Web MVC, no entanto, tive dificuldades para estabelecer as regras definidas (Pesquisar na Web Service e adicionar todos os dados a partir do Cnpj) sendo necessário preencher campo a campo.
Então  esse projeto ficou bastante simples, a modelagem de classes foi alterada para que telas das listas fossem acessadas (Atividade Principal, Atividades Secundarias e Quadro de Sócios), o Contexto foi alterado para criar todas as tabelas, com FK definida com o ID de cada Empresa e os Controladores foram adicionados como todos os métodos CRUD.
Apesar do projeto não estabelecer as regras definidas, ele está funcional (sem erros de compilação e execução). Apenas sendo necessário definir o Banco de Dados para seu uso.


## Arquitetura

A arquitetura do projeto CadastroEmpresaDesktop funciona da seguinte maneira:
O App faz um Request informando o Cnpj ao Web Service da empresa que deseja consultar, caso esse Cnpj informado possua informações na Web Service, é respondido uma página com todos dados dessa empresa no formato JSON.
Para consumir os dados dessa API REST e salvá-la em uma variável do tipo Empresa, onde esse tipo Empresa, representam as classes que remetem exatamente ao JSON fornecido pela Web Service, foi utilizada a biblioteca chamada Refit, que facilitou esse consumo, configurando a rota entre cliente e servidor.


## Tecnologias

Entity Framework: Ajudou muito no desenvolvimento do projeto, no entanto a cada alteração (na modelagem de classes) posterior ao "enable-migrations" tinha uma surpresa, eram erros de compilação, erros de duplicidade de chave primária, mas todos resolvidos.


## Conclusão

Foi um projeto que propôs uma excelente oportunidade de aprendizado e foi muito gratificante ver a aplicação funcionando. Agradeço a toda equipe da Uppertools e espero ter a oportunidade de fazer parte desse time! \o/\o/\o/
