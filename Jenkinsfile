node {

  def resourceGroupName = 'gr-CP3_devops3'
  def resourceGroupLocation = 'brazilsouth'
  def appServicePlanName = 'DevopsPlan'
  def appServicePlanTier = 'FREE'
  def webAppName = 'devops3-rm88532'
  def webAppRuntime = '"dotnet:6"'
node {

  def resourceGroupName = 'gr-GS2_devops'
  def resourceGroupLocation = 'brazilsouth'
  def appServicePlanName = 'DevopsPlan'
  def appServicePlanTier = 'FREE'
  def webAppName = 'globalsolution-rm88753'
  def webAppRuntime = '"dotnet:6"'
  def packagePath = 'target.zip'
 
  

stage('Extrair Codigo Fonte') {
     echo 'Extraindo codigo fonte...'
     checkout([$class: 'GitSCM', branches: [[name: '*/main']], doGenerateSubmoduleConfigurations: false, extensions: [], submoduleCfg: [], userRemoteConfigs: [[url: 'https://github.com/fsantos-92/fiap-ead-globalsolution.git']]])
   }

   stage('Build') {
     echo 'Realizando o Build...'
     sh 'dotnet publish --configuration Release Fiap.GlobalSolution.sln -o publish'
     sh ' cd publish && zip -r ../target.zip .'
     sh 'cd ..'
     sh 'ls'
     //sh 'zip -r target.zip publish'
     
   }
   stage('Credenciais Azure') {
    echo 'Obtendo credenciais...'
    withCredentials([usernamePassword(credentialsId: 'AzureService', 
      passwordVariable: 'AZURE_CLIENT_SECRET',
      usernameVariable: 'AZURE_CLIENT_ID')]) {
      echo 'Logando na Azure...'
      sh 'az login -u $AZURE_CLIENT_ID -p $AZURE_CLIENT_SECRET'
      //sh 'az webapp list-runtimes'
    }
   }

  stage('Criar Infra') {
   echo 'Criando o Grupo de Recursos...'
   sh "az group create --name $resourceGroupName --location $resourceGroupLocation"
   echo 'Criando Plano de ServiÃ§o...'
   sh "az appservice plan create --name $appServicePlanName --resource-group $resourceGroupName --sku $appServicePlanTier"
   echo 'Criando o Web App...'
   sh "az webapp create --name $webAppName --plan $appServicePlanName --resource-group $resourceGroupName"
 
  }

 stage('Deploy') {
    echo 'Realizando o Deploy na Azure...'
    //sh "az webapp deploy --resource-group $resourceGroupName --name $webAppName --src-path target.zip --type zip"
    sh 'ls'
    sh "az webapp deployment source config-zip -n $webAppName -g $resourceGroupName --src target.zip"
    //sh "az webapp deployment source config -n $webAppName -g $resourceGroupName --repo-url https://github.com/Danigol13/cp3_DevOps_menk --branch master --manual-integration"
 }

}