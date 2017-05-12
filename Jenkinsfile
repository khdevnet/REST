#!groovy
node {
    def buildArtifacts = "\\buildartifacts"
    def buildArtifactsDir = "${env.WORKSPACE}\\$buildArtifacts"
    def solutionName = 'watchshop.sln'
    def reports = "buildartifacts/reports"
    def reportsDir = "$buildArtifactsDir\\reports"
    def buildResultTemplateDir =  "${env.WORKSPACE}\\buildtools\\report\\"
    def codeQualityDllWildCards = ["$buildArtifacts/*.Api.dll","$buildArtifacts/*.Domain.dll"];
   
    
 timestamps {
        stage('Checkout') {

            git 'https://github.com/khdevnet/REST.git'
             def thing = load 'Thing.groovy'
             echo thing.doStuff()   
        }
    }
}
