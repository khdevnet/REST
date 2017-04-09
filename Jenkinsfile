#!groovy
node {
    def buildArtifacts = "buildartifacts"
    def buildArtifactsDir = "${env.WORKSPACE}\\$buildArtifacts"
    def solutionName = 'watchshop.sln'
    def reportsDir = "${env.WORKSPACE}\\reports"
    timestamps {
        stage('Clean') {
          removeDir(buildArtifactsDir)
          removeDir(reportsDir)
          makeDir(reportsDir) 
        }
        stage('Checkout') {
            git 'https://github.com/khdevnet/REST.git'
        }

        stage('Build') {
            bat "\"${tool 'nuget'}\" restore $solutionName"
            bat "\"${tool 'msbuild'}\" $solutionName  /p:DeployOnBuild=true;DeployTarget=Package /p:Configuration=Release;OutputPath=\"$buildArtifactsDir\" /p:Platform=\"Any CPU\" /p:ProductVersion=1.0.0.${env.BUILD_NUMBER}"
        }

        stage('Tests') {
          def testFilesName = getFiles(["$buildArtifacts/*.Tests.dll"], buildArtifactsDir).join(' ')
          bat """${tool 'nunit'} $testFilesName --work=$reportsDir"""
        }
        
        stage('CodeQuality') {
          def domainFilesName = getFiles(["$buildArtifacts/WatchShop*.Api.dll","$buildArtifacts/*.Domain.dll"], buildArtifactsDir)
          for(def fileName : domainFilesName ) { 
              echo filename
              bat """${tool 'fxcop'} /f:$fileName /o:$reportsDir\\${new File(fileName).name}.fxcop.xml"""
          }
        }

        stage('Archive') {
            archiveArtifacts artifacts: 'buildartifacts/_PublishedWebsites/WatchShop.Api_Package/**/*.*', onlyIfSuccessful: true
        }

        stage('Notifications') {
            emailext body: 'Test', subject: 'Test', to: 'khdevnet@gmail.com'
        }
    }
}
def getFiles(wildcards, rootDir=''){
    def files = []
    for(def wildcard : wildcards ) { 
        files.addAll(findFiles(glob: wildcard))
    }
    
    def names = []
    def prefix = rootDir == '' ? '' : rootDir + '\\'
    for(def file : files ) { names << prefix + file.name }
    return names
}

def makeDir(dirPath) {
     def dir = new File(dirPath)
     if (!dir.exists()) dir.mkdirs()
}

def removeDir(dirPath) {
     def dir = new File(dirPath)
     if (dir.exists()) dir.deleteDir()
}
def log(message){
    println message
} 
