#!groovy
def buildArtifactsDir = "${env.WORKSPACE}\\buildartifacts"
node {
    timestamps {
        stage('Checkout') {
            git 'https://github.com/khdevnet/REST.git'
        }

        stage('Build') {
            println "$buildArtifactsDir"
            removeDir(buildArtifactsDir)
           // bat "\"${tool 'nuget'}\" restore watchshop.sln"
            //bat "\"${tool 'msbuild'}\" watchshop.sln  /p:DeployOnBuild=true;DeployTarget=Package /p:Configuration=Release;OutputPath=\"..\\..\\buildartifacts\" /p:Platform=\"Any CPU\" /p:ProductVersion=1.0.0.${env.BUILD_NUMBER}"
        }

        stage('Tests') {
            bat """setlocal enableDelayedExpansion
                    set testFiles= 
                    For /F "tokens=*" %%F IN (\'dir /b /s %WORKSPACE%\\buildartifacts\\*.Tests.dll\') DO (
                            set testFiles=!testFiles! %%F
                            )
                    ${tool 'nunit'} %testFiles%"""
        }

        stage('Archive') {
            archiveArtifacts artifacts: 'buildartifacts/_PublishedWebsites/WatchShop.Api_Package/**/*.*', onlyIfSuccessful: true
        }

        stage('Notifications') {
            emailext body: 'Test', subject: 'Test', to: 'khdevnet@gmail.com'
        }
    }
}

def removeDir(dirPath) {
    def dir = new File(dirPath)
    println "${dir.getPath()}"
    if (dir.exists()) dir.deleteDir()
}
