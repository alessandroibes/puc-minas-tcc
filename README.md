<h1>Sistema de Gestão da Qualidade para o Ramo Automotivo</h1>

<h2>Descrição</h2>
<p>Este projeto aborda uma proposta arquitetural para um sistema de gestão da qualidade do ramo automotivo que utiliza recursos provenientes de serviços Web de terceiros e que pode ser acessado por meio da Internet utilizando dispositivos móveis ou desktop.</p><p>Uma solução arquitetural utilizando microsserviços do lado servidor e um projeto SPA (Single Page Application) do lado cliente é apresentada, juntamente com uma prova de conteito para validação dos requisitos arquiteturais mais relevantes (3 módulos são implementados na Prova de Conceito).</p>
<h2>Abordagens Arquiteturais</h2>
<p>A arquitetura proposta baseou-se no uso de microserviços, de forma que cada módulo do sistema disponibiliza uma variedade de recursos relacionados e funcionam de forma independente dos demais, com cada microserviço possuindo a sua própria base de dados. Apesar de todos os módulos estarem implantados da mesma forma (na nuvem através do serviço Azure), os mesmos foram concebidos para poderem ser implantados de diversar formas, podendo ser em nuvem, on primise, self-hosted, em containers, dentre outras.</p>
<h2>Prova de Conceito</h2>
<p>A prova de conceito desse projeto visa validar as escolhas arquiteturais e garantir que os requisitos funcionais e não funcionais do projeto estão sendo atendidos de forma adequada.</p>
<h3>Módulos Desenvolvido na Prova de Conceito</h3>
<ul>
  <li>Módulo de Autenticação e Autorização</li>
  <li>Módulo de Cadastro de Incidentes e Problemas</li>
  <li>Módulo de Controle de Processos Automotivos</li>
</ul>
<p>O objetivo desse protótico é verificar se o processo de autenticação dos usuários, assim como a validação dos perfis de acesso estão sendo atendidos. Foi validado se os módulos de cadastro de incidentes e problemas e também o controle de processos automotivos estão atendendo todas as necessidades do usuário relacionado aos requisitos de qualidade, afim de minimizar riscos e maximizar ganhos de produtividade na sequência do projeto.</p>
<h3>Casos de Uso implementados na Prova de Conceito</h3>
<ul>
  <li>Módulo de Autenticação e Autorização (Serviço de Autenticação)
    <ul>
      <li>Gerar Token</li>
      <li>Logar no Sistema</li>
      <li>Autenticar Usuário</li>
    </ul>
  </li>
  <li>Módulo de Cadastro de Incidentes e Problemas
    <ul>
      <li>Cadastrar RNC (Registro de não conformidade)</li>
      <li>Alterar RNC</li>
      <li>Listar RNC</li>
      <li>Ver Detalhes da RNC</li>
    </ul>
  </li>
  <li>Controle de Processos Automotivos
    <ul>
      <li>Cadastrar Definição de Workflow</li>
      <li>Listar Definições de Workflow</li>
      <li>Ver Detalhes da Definição de Workflow</li>
      <li>Alterar Definição de Workflow</li>
      <li>Criar workflow a partir de Modelo</li>
      <li>Preencher Workflow de Atividades</li>
      <li>Listar Workflows em Andamento</li>
      <li>Registrar Paradas e Problemas Ocorridos</li>
    </ul>
  </li>
</ul>
<h3>Tecnologias Utilizadas no Projeto</h3>
<table>
  <thead>
    <th>Módulo</th>
    <th>Tecnologias</th>
  </thead>
  <tbody>
    <tr>
      <td>Interface do Usuário</td>
      <td>Angular, Bootstrap, NPM</td>
    </tr>
    <tr>
      <td>API Getway</td>
      <td>ASP.NET Core Web API, NuGet</td>
    </tr>
    <tr>
      <td>Serviço de Autenticação</td>
      <td>ASP.NET Core Web API, ASP.NET Core Identity, Entity Framework Core, SQL Server, JWT, Auto Mapper, Swagger, Elmah.io, NuGet</td>
    </tr>
    <tr>
      <td>Cadastro de Incidentes e Problemas</td>
      <td>ASP.NET Core Web API, ASP.NET Core Identity, Entity Framework Core, SQL Server, JWT, Auto Mapper, Swagger, Elmah.io, NuGet</td>
    </tr>
    <tr>
      <td>Controle de Processos Automotivos</td>
      <td>ASP.NET Core Web API, ASP.NET Core Identity, Entity Framework Core, SQL Server, JWT, Auto Mapper, Swagger, Elmah.io, NuGet</td>
    </tr>
    <tr>
      <td>Divulgação e Transparência</td>
      <td>ASP.NET Core Web API, ASP.NET Core Identity, Entity Framework Core, SQL Server, JWT, Auto Mapper, Swagger, Elmah.io, NuGet</td>
    </tr>
  </tbody>
</table>
<h2>Diagramas</h2>
<h3>Diagrama de Componentes</h3>
<p>O diagrama de componentes do sistema, os quais impactam no design da arquitetura e seleção das tecnologias. Foram organizados para serem reutilizáveis e fornecerem interfaces bem definidas de acordo com suas responsabilidades.</p>
<img src="/Diagramas/DiagramaDeComponentes.jpeg">
<h2>Telas da Aplicação</h2>
<h3>Web</h3>
<p>Tela de login da aplicação</p>
<img src="/Prints/web-login.jpg">
<br />
<p>Tela de cadastro de Não Conformidade</p>
<img src="/Prints/web-criar-rnc.jpg">
<br />
<p>Tela de datalhes de Não Confirmidade</p>
<img src="/Prints/web-listar-rnc.jpg">
<br />
<p>Tela de cadastro de Definição de Workflow</p>
<img src="/Prints/web-criar-definicao-workflow.jpg">
<br />
<p>Tela de detalhes da Definição de Workflow</p>
<img src="/Prints/web-listar-definicao-workflow.jpg">
<br />
<p>Tela de preenchimento de Workflow</p>
<img src="/Prints/web-preencher-workflow.jpg">
<br />
<p>Tela de registro de Paradas</p>
<img src="/Prints/web-registrar-parada.jpg">
<h3>Mobile</h3>
<p>Tela de login da aplicação</p>
<img src="/Prints/mobile-login.jpg">
<br />
<p>Tela de cadastro de Definição de Workflow</p>
<img src="/Prints/mobile-criar-definicao-workflow.jpg">
<br />
<p>Tela de detalhes da Definição de Workflow</p>
<img src="/Prints/mobile-detalhar-definicao-workflow.jpg">
<br />
<p>Tela de listagem da Definição de Workflow</p>
<img src="/Prints/mobile-listar-definicao-workflow.jpg">
<br />
<p>Tela de preenchimento de Workflow</p>
<img src="/Prints/mobile-preencher-workflow.jpg">
<br />
<p>Modal de confirmação</p>
<img src="/Prints/mobile-modal-confirmacao.jpg">
<br />
<p>Tela Sobre</p>
<img src="/Prints/mobile-sobre.jpg">
