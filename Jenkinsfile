#!groovy
pipeline {
    agent any

    stages {
        stage('Checkout') {
            steps {
                git 'https://github.com/khdevnet/REST.git'
            }
        }
        stage('Build') {
            steps {
                bat "if exist \"buildartifacts\" rd /s /q \"buildartifacts\""
             	bat "\"${tool 'nuget'}\" restore watchshop.sln"
	        bat "\"${tool 'msbuild'}\" watchshop.sln  /p:DeployOnBuild=true;DeployTarget=Package /p:Configuration=Release;OutputPath=\"..\\..\\buildartifacts\" /p:Platform=\"Any CPU\" /p:ProductVersion=1.0.0.${env.BUILD_NUMBER}"
            }
        }
        stage('Tests') {
            steps {
               bat '''setlocal enableDelayedExpansion
                   set testFiles= 
                   For /F "tokens=*" %%F IN (\'dir /b /s %WORKSPACE%\\buildartifacts\\*.Tests.dll\') DO (
		                   set testFiles=!testFiles! %%F
	                       )
                   %WORKSPACE%\\buildtools\\nunit\\nunit3-console.exe %testFiles%'''
            }
        }
        stage('Archive') {
            steps {
		archiveArtifacts artifacts: 'buildartifacts/_PublishedWebsites/WatchShop.Api_Package/**/*.*', onlyIfSuccessful: true
            }
        }
        stage('Notifications'){
            steps {
                emailext body: 'Test', subject: 'Test', to: 'khdevnet@gmail.com'
            }
        }
    }
}
