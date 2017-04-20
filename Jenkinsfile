#!groovy
node {
    def buildArtifacts = "buildartifacts"
    def buildArtifactsDir = "${env.WORKSPACE}\\$buildArtifacts"
    def solutionName = 'watchshop.sln'
    def reportsDir = "${env.WORKSPACE}\\reports"
    def nunitTestReportXmlFilePath  = reportsDir + '\\TestResult.xml'
    def codeQualityDllWildCards = ["$buildArtifacts/WatchShop*.Api.dll", "$buildArtifacts/*.Domain.dll"];
    timestamps {
        stage('Checkout') {
            cleanDir(buildArtifactsDir)
            cleanDir(reportsDir)
            git 'https://github.com/khdevnet/REST.git'
        }

        stage('Build') {
            bat "\"${tool 'nuget'}\" restore $solutionName"
            bat "\"${tool 'msbuild'}\" $solutionName  /p:DeployOnBuild=true;DeployTarget=Package /p:Configuration=Release;OutputPath=\"$buildArtifactsDir\" /p:Platform=\"Any CPU\" /p:ProductVersion=1.0.0.${env.BUILD_NUMBER}"
        }

        stage('Tests') {
          def testFilesName = getFiles(["$buildArtifacts/*.Tests.dll"], buildArtifactsDir).join(' ')
          bat """${tool 'nunit'} $testFilesName --work=$reportsDir"""
          writeTestRunResultToReport(nunitTestReportXmlFilePath, reportsDir + '\\NunitTestResultReport.txt')
        }
        
        stage('CodeQuality') {
          def codeQualityDllNames = getFiles(codeQualityDllWildCards, buildArtifactsDir)
          for(def fileName : codeQualityDllNames ) { 
             try{
              bat """${tool 'fxcop'} /f:$fileName /o:$reportsDir\\${new File(fileName).name}.fxcop.xml"""
             } catch(Exception ex) {}
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

def writeTestRunResultToReport(nunitTestReportXmlFilePath,reportFilePath){
    def testXmlRootNode = new XmlParser().parse(new File(nunitTestReportXmlFilePath))
    def resultNode = findlastNode(testXmlRootNode.children(),'test-suite')
    def testReportFile = new File(reportFilePath)
    def resultNodeAttributes =  resultNode.attributes()
    testReportFile << 'total:' + resultNodeAttributes.get("total")
    testReportFile << ' passed:' + resultNodeAttributes.get("passed")
    testReportFile << ' failed:' + resultNodeAttributes.get("failed")
    testReportFile << ' warnings:' + resultNodeAttributes.get("warnings")
    testReportFile << ' inconclusive:' + resultNodeAttributes.get("inconclusive")
    testReportFile << ' skipped:' + resultNodeAttributes.get("skipped")
}

def findlastNode(list, nodeName){
    for(def element : list.reverse() ) { 
       if(element.name()==nodeName){
           return element
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

def cleanDir(dirPath) {
     def dir = new File(dirPath)
     if (dir.exists()) dir.deleteDir()
     if (!dir.exists()) dir.mkdirs()
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
